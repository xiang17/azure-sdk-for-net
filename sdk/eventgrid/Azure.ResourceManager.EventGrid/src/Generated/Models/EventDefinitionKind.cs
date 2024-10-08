// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.EventGrid.Models
{
    /// <summary> The kind of event type used. </summary>
    public readonly partial struct EventDefinitionKind : IEquatable<EventDefinitionKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EventDefinitionKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EventDefinitionKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InlineValue = "Inline";

        /// <summary> Inline. </summary>
        public static EventDefinitionKind Inline { get; } = new EventDefinitionKind(InlineValue);
        /// <summary> Determines if two <see cref="EventDefinitionKind"/> values are the same. </summary>
        public static bool operator ==(EventDefinitionKind left, EventDefinitionKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EventDefinitionKind"/> values are not the same. </summary>
        public static bool operator !=(EventDefinitionKind left, EventDefinitionKind right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EventDefinitionKind"/>. </summary>
        public static implicit operator EventDefinitionKind(string value) => new EventDefinitionKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EventDefinitionKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EventDefinitionKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
