// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Allowed replication region. </summary>
    public readonly partial struct AllowedReplicationRegion : IEquatable<AllowedReplicationRegion>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AllowedReplicationRegion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AllowedReplicationRegion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "Default";
        private const string WestUS2Value = "WestUs2";
        private const string NorthEuropeValue = "NorthEurope";
        private const string AustraliaEastValue = "AustraliaEast";
        private const string BrazilSouthValue = "BrazilSouth";
        private const string SouthEastAsiaValue = "SouthEastAsia";
        private const string SouthAfricaNorthValue = "SouthAfricaNorth";
        private const string NoneValue = "None";

        /// <summary> Default. </summary>
        public static AllowedReplicationRegion Default { get; } = new AllowedReplicationRegion(DefaultValue);
        /// <summary> WestUs2. </summary>
        public static AllowedReplicationRegion WestUS2 { get; } = new AllowedReplicationRegion(WestUS2Value);
        /// <summary> NorthEurope. </summary>
        public static AllowedReplicationRegion NorthEurope { get; } = new AllowedReplicationRegion(NorthEuropeValue);
        /// <summary> AustraliaEast. </summary>
        public static AllowedReplicationRegion AustraliaEast { get; } = new AllowedReplicationRegion(AustraliaEastValue);
        /// <summary> BrazilSouth. </summary>
        public static AllowedReplicationRegion BrazilSouth { get; } = new AllowedReplicationRegion(BrazilSouthValue);
        /// <summary> SouthEastAsia. </summary>
        public static AllowedReplicationRegion SouthEastAsia { get; } = new AllowedReplicationRegion(SouthEastAsiaValue);
        /// <summary> SouthAfricaNorth. </summary>
        public static AllowedReplicationRegion SouthAfricaNorth { get; } = new AllowedReplicationRegion(SouthAfricaNorthValue);
        /// <summary> None. </summary>
        public static AllowedReplicationRegion None { get; } = new AllowedReplicationRegion(NoneValue);
        /// <summary> Determines if two <see cref="AllowedReplicationRegion"/> values are the same. </summary>
        public static bool operator ==(AllowedReplicationRegion left, AllowedReplicationRegion right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AllowedReplicationRegion"/> values are not the same. </summary>
        public static bool operator !=(AllowedReplicationRegion left, AllowedReplicationRegion right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AllowedReplicationRegion"/>. </summary>
        public static implicit operator AllowedReplicationRegion(string value) => new AllowedReplicationRegion(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AllowedReplicationRegion other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AllowedReplicationRegion other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
