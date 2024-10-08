// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Automation.Models
{
    /// <summary> Day of the occurrence. Must be one of monday, tuesday, wednesday, thursday, friday, saturday, sunday. </summary>
    public readonly partial struct AutomationDayOfWeek : IEquatable<AutomationDayOfWeek>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AutomationDayOfWeek"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AutomationDayOfWeek(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MondayValue = "Monday";
        private const string TuesdayValue = "Tuesday";
        private const string WednesdayValue = "Wednesday";
        private const string ThursdayValue = "Thursday";
        private const string FridayValue = "Friday";
        private const string SaturdayValue = "Saturday";
        private const string SundayValue = "Sunday";

        /// <summary> Monday. </summary>
        public static AutomationDayOfWeek Monday { get; } = new AutomationDayOfWeek(MondayValue);
        /// <summary> Tuesday. </summary>
        public static AutomationDayOfWeek Tuesday { get; } = new AutomationDayOfWeek(TuesdayValue);
        /// <summary> Wednesday. </summary>
        public static AutomationDayOfWeek Wednesday { get; } = new AutomationDayOfWeek(WednesdayValue);
        /// <summary> Thursday. </summary>
        public static AutomationDayOfWeek Thursday { get; } = new AutomationDayOfWeek(ThursdayValue);
        /// <summary> Friday. </summary>
        public static AutomationDayOfWeek Friday { get; } = new AutomationDayOfWeek(FridayValue);
        /// <summary> Saturday. </summary>
        public static AutomationDayOfWeek Saturday { get; } = new AutomationDayOfWeek(SaturdayValue);
        /// <summary> Sunday. </summary>
        public static AutomationDayOfWeek Sunday { get; } = new AutomationDayOfWeek(SundayValue);
        /// <summary> Determines if two <see cref="AutomationDayOfWeek"/> values are the same. </summary>
        public static bool operator ==(AutomationDayOfWeek left, AutomationDayOfWeek right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AutomationDayOfWeek"/> values are not the same. </summary>
        public static bool operator !=(AutomationDayOfWeek left, AutomationDayOfWeek right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AutomationDayOfWeek"/>. </summary>
        public static implicit operator AutomationDayOfWeek(string value) => new AutomationDayOfWeek(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AutomationDayOfWeek other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AutomationDayOfWeek other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
