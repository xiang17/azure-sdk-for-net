﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Files.Shares;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Files.Shares.Tests;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class BlockBlobToShareFileTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public BlockBlobToShareFileTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(
            BlobServiceClient service = default,
            string containerName = default)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        /// <summary>
        /// Gets the specific storage resource from the given BlockBlobClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected override StorageResourceItem GetSourceStorageResourceItem(BlockBlobClient blob)
            => new BlockBlobStorageResource(blob);

        /// <summary>
        /// Calls the OpenRead method on the BlockBlobClient.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        ///
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected override Task<Stream> SourceOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected override async Task<bool> SourceExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<BlockBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);

            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await blobClient.UploadAsync(contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await blobClient.UploadAsync(originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetBlobOptions()));
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetDestinationObjectClientAsync(ShareClient container, long? objectLength = null, bool createResource = false, string objectName = null, ShareClientOptions options = null, Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                await fileClient.CreateAsync(objectLength.Value);

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri sourceUri = fileClient.GenerateSasUri(Sas.ShareFileSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new ShareFileClient(sourceUri, GetShareOptions()));
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            ShareFileClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> DestinationOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        protected override async Task<bool> DestinationExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        public BlobClientOptions GetBlobOptions()
        {
            var options = new BlobClientOptions((BlobClientOptions.ServiceVersion)_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public ShareClientOptions GetShareOptions()
        {
            var options = new ShareClientOptions((ShareClientOptions.ServiceVersion)_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        protected override Task VerifyPropertiesCopyAsync(
            DataTransfer transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            BlockBlobClient sourceClient,
            ShareFileClient destinationClient)
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_DefaultProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_PreserveProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_NoPreserveProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_NewProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }
    }
}
