// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    internal partial class IntegrationRuntimeObjectMetadataRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of IntegrationRuntimeObjectMetadataRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public IntegrationRuntimeObjectMetadataRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2018-06-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal RequestUriBuilder CreateRefreshRequestUri(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DataFactory/factories/", false);
            uri.AppendPath(factoryName, true);
            uri.AppendPath("/integrationRuntimes/", false);
            uri.AppendPath(integrationRuntimeName, true);
            uri.AppendPath("/refreshObjectMetadata", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateRefreshRequest(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DataFactory/factories/", false);
            uri.AppendPath(factoryName, true);
            uri.AppendPath("/integrationRuntimes/", false);
            uri.AppendPath(integrationRuntimeName, true);
            uri.AppendPath("/refreshObjectMetadata", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Refresh a SSIS integration runtime object metadata. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="factoryName"> The factory name. </param>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> RefreshAsync(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(factoryName, nameof(factoryName));
            Argument.AssertNotNullOrEmpty(integrationRuntimeName, nameof(integrationRuntimeName));

            using var message = CreateRefreshRequest(subscriptionId, resourceGroupName, factoryName, integrationRuntimeName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Refresh a SSIS integration runtime object metadata. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="factoryName"> The factory name. </param>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response Refresh(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(factoryName, nameof(factoryName));
            Argument.AssertNotNullOrEmpty(integrationRuntimeName, nameof(integrationRuntimeName));

            using var message = CreateRefreshRequest(subscriptionId, resourceGroupName, factoryName, integrationRuntimeName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal RequestUriBuilder CreateGetRequestUri(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, GetSsisObjectMetadataContent content)
        {
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DataFactory/factories/", false);
            uri.AppendPath(factoryName, true);
            uri.AppendPath("/integrationRuntimes/", false);
            uri.AppendPath(integrationRuntimeName, true);
            uri.AppendPath("/getObjectMetadata", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            return uri;
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, GetSsisObjectMetadataContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.DataFactory/factories/", false);
            uri.AppendPath(factoryName, true);
            uri.AppendPath("/integrationRuntimes/", false);
            uri.AppendPath(integrationRuntimeName, true);
            uri.AppendPath("/getObjectMetadata", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (content != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content0 = new Utf8JsonRequestContent();
                content0.JsonWriter.WriteObjectValue(content, ModelSerializationExtensions.WireOptions);
                request.Content = content0;
            }
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get a SSIS integration runtime object metadata by specified path. The return is pageable metadata list. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="factoryName"> The factory name. </param>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="content"> The parameters for getting a SSIS object metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<SsisObjectMetadataListResult>> GetAsync(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, GetSsisObjectMetadataContent content = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(factoryName, nameof(factoryName));
            Argument.AssertNotNullOrEmpty(integrationRuntimeName, nameof(integrationRuntimeName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, factoryName, integrationRuntimeName, content);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SsisObjectMetadataListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = SsisObjectMetadataListResult.DeserializeSsisObjectMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a SSIS integration runtime object metadata by specified path. The return is pageable metadata list. </summary>
        /// <param name="subscriptionId"> The subscription identifier. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="factoryName"> The factory name. </param>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="content"> The parameters for getting a SSIS object metadata. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="factoryName"/> or <paramref name="integrationRuntimeName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<SsisObjectMetadataListResult> Get(string subscriptionId, string resourceGroupName, string factoryName, string integrationRuntimeName, GetSsisObjectMetadataContent content = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(factoryName, nameof(factoryName));
            Argument.AssertNotNullOrEmpty(integrationRuntimeName, nameof(integrationRuntimeName));

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, factoryName, integrationRuntimeName, content);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SsisObjectMetadataListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = SsisObjectMetadataListResult.DeserializeSsisObjectMetadataListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
