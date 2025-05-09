// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Artifacts
{
    internal partial class PipelineRunRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PipelineRunRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The workspace development endpoint, for example `https://myworkspace.dev.azuresynapse.net`. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        public PipelineRunRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        internal HttpMessage CreateQueryPipelineRunsByWorkspaceRequest(RunFilterParameters filterParameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/queryPipelineRuns", false);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(filterParameters);
            request.Content = content;
            return message;
        }

        /// <summary> Query pipeline runs in the workspace based on input filter conditions. </summary>
        /// <param name="filterParameters"> Parameters to filter the pipeline run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filterParameters"/> is null. </exception>
        public async Task<Response<PipelineRunsQueryResponse>> QueryPipelineRunsByWorkspaceAsync(RunFilterParameters filterParameters, CancellationToken cancellationToken = default)
        {
            if (filterParameters == null)
            {
                throw new ArgumentNullException(nameof(filterParameters));
            }

            using var message = CreateQueryPipelineRunsByWorkspaceRequest(filterParameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineRunsQueryResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = PipelineRunsQueryResponse.DeserializePipelineRunsQueryResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Query pipeline runs in the workspace based on input filter conditions. </summary>
        /// <param name="filterParameters"> Parameters to filter the pipeline run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filterParameters"/> is null. </exception>
        public Response<PipelineRunsQueryResponse> QueryPipelineRunsByWorkspace(RunFilterParameters filterParameters, CancellationToken cancellationToken = default)
        {
            if (filterParameters == null)
            {
                throw new ArgumentNullException(nameof(filterParameters));
            }

            using var message = CreateQueryPipelineRunsByWorkspaceRequest(filterParameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineRunsQueryResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = PipelineRunsQueryResponse.DeserializePipelineRunsQueryResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPipelineRunRequest(string runId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelineruns/", false);
            uri.AppendPath(runId, true);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get a pipeline run by its run ID. </summary>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        public async Task<Response<PipelineRun>> GetPipelineRunAsync(string runId, CancellationToken cancellationToken = default)
        {
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }

            using var message = CreateGetPipelineRunRequest(runId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineRun value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = PipelineRun.DeserializePipelineRun(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a pipeline run by its run ID. </summary>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        public Response<PipelineRun> GetPipelineRun(string runId, CancellationToken cancellationToken = default)
        {
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }

            using var message = CreateGetPipelineRunRequest(runId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        PipelineRun value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = PipelineRun.DeserializePipelineRun(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateQueryActivityRunsRequest(string pipelineName, string runId, RunFilterParameters filterParameters)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelines/", false);
            uri.AppendPath(pipelineName, true);
            uri.AppendPath("/pipelineruns/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/queryActivityruns", false);
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(filterParameters);
            request.Content = content;
            return message;
        }

        /// <summary> Query activity runs based on input filter conditions. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="filterParameters"> Parameters to filter the activity runs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/>, <paramref name="runId"/> or <paramref name="filterParameters"/> is null. </exception>
        public async Task<Response<ActivityRunsQueryResponse>> QueryActivityRunsAsync(string pipelineName, string runId, RunFilterParameters filterParameters, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }
            if (filterParameters == null)
            {
                throw new ArgumentNullException(nameof(filterParameters));
            }

            using var message = CreateQueryActivityRunsRequest(pipelineName, runId, filterParameters);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ActivityRunsQueryResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = ActivityRunsQueryResponse.DeserializeActivityRunsQueryResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Query activity runs based on input filter conditions. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="filterParameters"> Parameters to filter the activity runs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipelineName"/>, <paramref name="runId"/> or <paramref name="filterParameters"/> is null. </exception>
        public Response<ActivityRunsQueryResponse> QueryActivityRuns(string pipelineName, string runId, RunFilterParameters filterParameters, CancellationToken cancellationToken = default)
        {
            if (pipelineName == null)
            {
                throw new ArgumentNullException(nameof(pipelineName));
            }
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }
            if (filterParameters == null)
            {
                throw new ArgumentNullException(nameof(filterParameters));
            }

            using var message = CreateQueryActivityRunsRequest(pipelineName, runId, filterParameters);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ActivityRunsQueryResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = ActivityRunsQueryResponse.DeserializeActivityRunsQueryResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCancelPipelineRunRequest(string runId, bool? isRecursive)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pipelineruns/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/cancel", false);
            if (isRecursive != null)
            {
                uri.AppendQuery("isRecursive", isRecursive.Value, true);
            }
            uri.AppendQuery("api-version", "2020-12-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Cancel a pipeline run by its run ID. </summary>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="isRecursive"> If true, cancel all the Child pipelines that are triggered by the current pipeline. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        public async Task<Response> CancelPipelineRunAsync(string runId, bool? isRecursive = null, CancellationToken cancellationToken = default)
        {
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }

            using var message = CreateCancelPipelineRunRequest(runId, isRecursive);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Cancel a pipeline run by its run ID. </summary>
        /// <param name="runId"> The pipeline run identifier. </param>
        /// <param name="isRecursive"> If true, cancel all the Child pipelines that are triggered by the current pipeline. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="runId"/> is null. </exception>
        public Response CancelPipelineRun(string runId, bool? isRecursive = null, CancellationToken cancellationToken = default)
        {
            if (runId == null)
            {
                throw new ArgumentNullException(nameof(runId));
            }

            using var message = CreateCancelPipelineRunRequest(runId, isRecursive);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
