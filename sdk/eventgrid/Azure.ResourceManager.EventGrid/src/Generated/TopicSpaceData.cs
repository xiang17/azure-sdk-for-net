// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    /// <summary>
    /// A class representing the TopicSpace data model.
    /// The Topic space resource.
    /// </summary>
    public partial class TopicSpaceData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TopicSpaceData"/>. </summary>
        public TopicSpaceData()
        {
            TopicTemplates = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="TopicSpaceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="description"> Description for the Topic Space resource. </param>
        /// <param name="topicTemplates">
        /// The topic filters in the topic space.
        /// Example: "topicTemplates": [
        ///               "devices/foo/bar",
        ///               "devices/topic1/+",
        ///               "devices/${principal.name}/${principal.attributes.keyName}" ].
        /// </param>
        /// <param name="provisioningState"> Provisioning state of the TopicSpace resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TopicSpaceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, IList<string> topicTemplates, TopicSpaceProvisioningState? provisioningState, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Description = description;
            TopicTemplates = topicTemplates;
            ProvisioningState = provisioningState;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Description for the Topic Space resource. </summary>
        [WirePath("properties.description")]
        public string Description { get; set; }
        /// <summary>
        /// The topic filters in the topic space.
        /// Example: "topicTemplates": [
        ///               "devices/foo/bar",
        ///               "devices/topic1/+",
        ///               "devices/${principal.name}/${principal.attributes.keyName}" ].
        /// </summary>
        [WirePath("properties.topicTemplates")]
        public IList<string> TopicTemplates { get; }
        /// <summary> Provisioning state of the TopicSpace resource. </summary>
        [WirePath("properties.provisioningState")]
        public TopicSpaceProvisioningState? ProvisioningState { get; }
    }
}
