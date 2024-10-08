// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> Extended status information. </summary>
    public partial class ExtendedStatusInfo
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

        /// <summary> Initializes a new instance of <see cref="ExtendedStatusInfo"/>. </summary>
        internal ExtendedStatusInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ExtendedStatusInfo"/>. </summary>
        /// <param name="statusCode"> Status code providing additional information. </param>
        /// <param name="message"> The message giving detailed information about the status code. </param>
        /// <param name="subscriptionId"> The subscription that has failed credit line check. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ExtendedStatusInfo(string statusCode, string message, string subscriptionId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StatusCode = statusCode;
            Message = message;
            SubscriptionId = subscriptionId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Status code providing additional information. </summary>
        [WirePath("statusCode")]
        public string StatusCode { get; }
        /// <summary> The message giving detailed information about the status code. </summary>
        [WirePath("message")]
        public string Message { get; }
        /// <summary> The subscription that has failed credit line check. </summary>
        [WirePath("properties.subscriptionId")]
        public string SubscriptionId { get; }
    }
}
