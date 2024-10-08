// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> Optional parameter to use a Custom Character to be used for redaction in PII responses. Default character will be * as before. We allow specific ascii characters for redaction. </summary>
    public readonly partial struct RedactionCharacter : IEquatable<RedactionCharacter>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RedactionCharacter"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RedactionCharacter(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ExclamationPointValue = "!";
        private const string NumberSignValue = "#";
        private const string DollarValue = "$";
        private const string PercentValue = "%";
        private const string AmpersandValue = "&";
        private const string AsteriskValue = "*";
        private const string PlusValue = "+";
        private const string MinusValue = "-";
        private const string EqualsValueValue = "=";
        private const string QuestionMarkValue = "?";
        private const string AtSignValue = "@";
        private const string CaretValue = "^";
        private const string UnderscoreValue = "_";
        private const string TildeValue = "~";

        /// <summary> Exclamation point character. </summary>
        public static RedactionCharacter ExclamationPoint { get; } = new RedactionCharacter(ExclamationPointValue);
        /// <summary> Number sign character. </summary>
        public static RedactionCharacter NumberSign { get; } = new RedactionCharacter(NumberSignValue);
        /// <summary> Dollar sign character. </summary>
        public static RedactionCharacter Dollar { get; } = new RedactionCharacter(DollarValue);
        /// <summary> Percent sign character. </summary>
        public static RedactionCharacter Percent { get; } = new RedactionCharacter(PercentValue);
        /// <summary> Ampersand character. </summary>
        public static RedactionCharacter Ampersand { get; } = new RedactionCharacter(AmpersandValue);
        /// <summary> Asterisk character. </summary>
        public static RedactionCharacter Asterisk { get; } = new RedactionCharacter(AsteriskValue);
        /// <summary> Plus sign character. </summary>
        public static RedactionCharacter Plus { get; } = new RedactionCharacter(PlusValue);
        /// <summary> Minus sign character. </summary>
        public static RedactionCharacter Minus { get; } = new RedactionCharacter(MinusValue);
        /// <summary> Equals sign character. </summary>
        public static RedactionCharacter EqualsValue { get; } = new RedactionCharacter(EqualsValueValue);
        /// <summary> Question mark character. </summary>
        public static RedactionCharacter QuestionMark { get; } = new RedactionCharacter(QuestionMarkValue);
        /// <summary> At sign character. </summary>
        public static RedactionCharacter AtSign { get; } = new RedactionCharacter(AtSignValue);
        /// <summary> Caret character. </summary>
        public static RedactionCharacter Caret { get; } = new RedactionCharacter(CaretValue);
        /// <summary> Underscore character. </summary>
        public static RedactionCharacter Underscore { get; } = new RedactionCharacter(UnderscoreValue);
        /// <summary> Tilde character. </summary>
        public static RedactionCharacter Tilde { get; } = new RedactionCharacter(TildeValue);
        /// <summary> Determines if two <see cref="RedactionCharacter"/> values are the same. </summary>
        public static bool operator ==(RedactionCharacter left, RedactionCharacter right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RedactionCharacter"/> values are not the same. </summary>
        public static bool operator !=(RedactionCharacter left, RedactionCharacter right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="RedactionCharacter"/>. </summary>
        public static implicit operator RedactionCharacter(string value) => new RedactionCharacter(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RedactionCharacter other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RedactionCharacter other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
