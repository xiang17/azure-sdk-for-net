// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Library resource info. </summary>
    public partial class LibraryResourceInfo
    {
        /// <summary> Initializes a new instance of <see cref="LibraryResourceInfo"/>. </summary>
        internal LibraryResourceInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LibraryResourceInfo"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="recordId"> record Id of the library/package. </param>
        /// <param name="state"> Provisioning status of the library/package. </param>
        /// <param name="created"> The creation time of the library/package. </param>
        /// <param name="changed"> The last updated time of the library/package. </param>
        /// <param name="type"> The type of the resource. E.g. LibraryArtifact. </param>
        /// <param name="name"> Name of the library/package. </param>
        /// <param name="operationId"> Operation Id of the operation performed on library/package. </param>
        /// <param name="artifactId"> artifact Id of the library/package. </param>
        internal LibraryResourceInfo(string id, int? recordId, string state, string created, string changed, string type, string name, string operationId, string artifactId)
        {
            Id = id;
            RecordId = recordId;
            State = state;
            Created = created;
            Changed = changed;
            Type = type;
            Name = name;
            OperationId = operationId;
            ArtifactId = artifactId;
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public string Id { get; }
        /// <summary> record Id of the library/package. </summary>
        public int? RecordId { get; }
        /// <summary> Provisioning status of the library/package. </summary>
        public string State { get; }
        /// <summary> The creation time of the library/package. </summary>
        public string Created { get; }
        /// <summary> The last updated time of the library/package. </summary>
        public string Changed { get; }
        /// <summary> The type of the resource. E.g. LibraryArtifact. </summary>
        public string Type { get; }
        /// <summary> Name of the library/package. </summary>
        public string Name { get; }
        /// <summary> Operation Id of the operation performed on library/package. </summary>
        public string OperationId { get; }
        /// <summary> artifact Id of the library/package. </summary>
        public string ArtifactId { get; }
    }
}
