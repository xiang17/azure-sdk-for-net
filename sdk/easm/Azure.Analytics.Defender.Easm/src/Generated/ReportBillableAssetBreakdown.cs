// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Analytics.Defender.Easm
{
    /// <summary> The breakdown of billable asset counts for each asset type. </summary>
    public partial class ReportBillableAssetBreakdown
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

        /// <summary> Initializes a new instance of <see cref="ReportBillableAssetBreakdown"/>. </summary>
        internal ReportBillableAssetBreakdown()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ReportBillableAssetBreakdown"/>. </summary>
        /// <param name="kind"> The kind of billable asset. </param>
        /// <param name="count"> The number of assets of this type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ReportBillableAssetBreakdown(ReportBillableAssetBreakdownKind? kind, long? count, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Kind = kind;
            Count = count;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The kind of billable asset. </summary>
        public ReportBillableAssetBreakdownKind? Kind { get; }
        /// <summary> The number of assets of this type. </summary>
        public long? Count { get; }
    }
}
