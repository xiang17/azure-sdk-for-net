// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Artifacts
{
    internal partial class PipelineRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PipelineRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The workspace development endpoint, for example `https://myworkspace.dev.azuresynapse.net`. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        public PipelineRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        internal HttpMessage CreateGetPipelinesByWorkspaceRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines", false);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Lists pipelines. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<PipelineListResponse>> GetPipelinesByWorkspaceAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPipelinesByWorkspaceRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineListResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = PipelineListResponse.DeserializePipelineListResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists pipelines. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<PipelineListResponse> GetPipelinesByWorkspace(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPipelinesByWorkspaceRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineListResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = PipelineListResponse.DeserializePipelineListResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateOrUpdatePipelineRequest(string pipelineName, PipelineResource pipeline, string ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(pipeline);
            request.Content = content;
            return message;
        }

        /// <summary> Creates or updates a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="pipeline"> Pipeline resource definition. </param>
        /// <param name="ifMatch"> ETag of the pipeline entity.  Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> or <paramref name="pipeline"/> is null. </exception>
        public async Task<Response> CreateOrUpdatePipelineAsync(string pipelineName, PipelineResource pipeline, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            using var message = CreateCreateOrUpdatePipelineRequest(pipelineName, pipeline, ifMatch);
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

        /// <summary> Creates or updates a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="pipeline"> Pipeline resource definition. </param>
        /// <param name="ifMatch"> ETag of the pipeline entity.  Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> or <paramref name="pipeline"/> is null. </exception>
        public Response CreateOrUpdatePipeline(string pipelineName, PipelineResource pipeline, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            using var message = CreateCreateOrUpdatePipelineRequest(pipelineName, pipeline, ifMatch);
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

        internal HttpMessage CreateGetPipelineRequest(string pipelineName, string ifNoneMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public async Task<Response<PipelineResource>> GetPipelineAsync(string pipelineName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateGetPipelineRequest(pipelineName, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineResource value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = PipelineResource.DeserializePipelineResource(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 304:
                    return Response.FromValue((PipelineResource)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public Response<PipelineResource> GetPipeline(string pipelineName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateGetPipelineRequest(pipelineName, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineResource value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = PipelineResource.DeserializePipelineResource(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 304:
                    return Response.FromValue((PipelineResource)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeletePipelineRequest(string pipelineName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Deletes a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public async Task<Response> DeletePipelineAsync(string pipelineName, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateDeletePipelineRequest(pipelineName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public Response DeletePipeline(string pipelineName, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateDeletePipelineRequest(pipelineName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRenamePipelineRequest(string pipelineName, ArtifactRenameRequest request)
        {
            var message = _pipeline.CreateMessage();
            var request0 = message.Request;
            request0.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendPath("/rename", false);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request0.Uri = uri;
            request0.Headers.Add("Accept", "application/json");
            request0.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(request);
            request0.Content = content;
            return message;
        }

        /// <summary> Renames a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="request"> proposed new name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> or <paramref name="request"/> is null. </exception>
        public async Task<Response> RenamePipelineAsync(string pipelineName, ArtifactRenameRequest request, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var message = CreateRenamePipelineRequest(pipelineName, request);
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

        /// <summary> Renames a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="request"> proposed new name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> or <paramref name="request"/> is null. </exception>
        public Response RenamePipeline(string pipelineName, ArtifactRenameRequest request, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var message = CreateRenamePipelineRequest(pipelineName, request);
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

        internal HttpMessage CreateCreatePipelineRunRequest(string pipelineName, string referencePipelineRunId, bool? isRecovery, string startActivityName, IDictionary<string, object> parameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendPath("/createRun", false);
            uri.AppendQuery("api-version", "2020-12-01", true);
            if (referencePipelineRunId != null)
            {
                uri.AppendQuery("referencePipelineRunId", referencePipelineRunId, true);
            }
            if (isRecovery != null)
            {
                uri.AppendQuery("isRecovery", isRecovery.Value, true);
            }
            if (startActivityName != null)
            {
                uri.AppendQuery("startActivityName", startActivityName, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (parameters != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in parameters)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        content.JsonWriter.WriteNullValue();
                        continue;
                    }
                    content.JsonWriter.WriteObjectValue<object>(item.Value);
                }
                content.JsonWriter.WriteEndObject();
                request.Content = content;
            }
            return message;
        }

        /// <summary> Creates a run of a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="referencePipelineRunId"> The pipeline run identifier. If run ID is specified the parameters of the specified run will be used to create a new run. </param>
        /// <param name="isRecovery"> Recovery mode flag. If recovery mode is set to true, the specified referenced pipeline run and the new run will be grouped under the same groupId. </param>
        /// <param name="startActivityName"> In recovery mode, the rerun will start from this activity. If not specified, all activities will run. </param>
        /// <param name="parameters"> Parameters of the pipeline run. These parameters will be used only if the runId is not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public async Task<Response<CreateRunResponse>> CreatePipelineRunAsync(string pipelineName, string referencePipelineRunId = null, bool? isRecovery = null, string startActivityName = null, IDictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateCreatePipelineRunRequest(pipelineName, referencePipelineRunId, isRecovery, startActivityName, parameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        CreateRunResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = CreateRunResponse.DeserializeCreateRunResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a run of a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="referencePipelineRunId"> The pipeline run identifier. If run ID is specified the parameters of the specified run will be used to create a new run. </param>
        /// <param name="isRecovery"> Recovery mode flag. If recovery mode is set to true, the specified referenced pipeline run and the new run will be grouped under the same groupId. </param>
        /// <param name="startActivityName"> In recovery mode, the rerun will start from this activity. If not specified, all activities will run. </param>
        /// <param name="parameters"> Parameters of the pipeline run. These parameters will be used only if the runId is not specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/> is null. </exception>
        public Response<CreateRunResponse> CreatePipelineRun(string pipelineName, string referencePipelineRunId = null, bool? isRecovery = null, string startActivityName = null, IDictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }

            using var message = CreateCreatePipelineRunRequest(pipelineName, referencePipelineRunId, isRecovery, startActivityName, parameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        CreateRunResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = CreateRunResponse.DeserializeCreateRunResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPipelinesByWorkspaceNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Lists pipelines. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<PipelineListResponse>> GetPipelinesByWorkspaceNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetPipelinesByWorkspaceNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineListResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = PipelineListResponse.DeserializePipelineListResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists pipelines. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<PipelineListResponse> GetPipelinesByWorkspaceNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetPipelinesByWorkspaceNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineListResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = PipelineListResponse.DeserializePipelineListResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
