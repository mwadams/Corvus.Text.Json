// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   Represents a single property for a JSON object.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [CLSCompliant(false)]
    public readonly struct JsonProperty<TValue>
        where TValue : struct, IJsonElement<TValue>
    {
        /// <summary>
        ///   The value of this property.
        /// </summary>
        public TValue Value { get; }

        internal JsonProperty(TValue value)
        {
            Value = value;
        }

        /// <summary>
        ///   The name of this property.
        /// </summary>
        public string Name
        {
            get
            {
                Value.CheckValidInstance();
                return Value.ParentDocument.GetNameOfPropertyValue(Value.ParentDocumentIndex);

            }
        }

        public UnescapedUtf8JsonString NameSpan
        {
            get
            {
                return Value.ParentDocument.GetUtf8JsonString(Value.ParentDocumentIndex - JsonDocument.DbRow.Size, JsonTokenType.PropertyName);
            }
        }

        /// <summary>
        ///   Compares <paramref name="text" /> to the name of this property.
        /// </summary>
        /// <param name="text">The text to compare against.</param>
        /// <returns>
        ///   <see langword="true" /> if the name of this property matches <paramref name="text"/>,
        ///   <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="Type"/> is not <see cref="JsonTokenType.PropertyName"/>.
        /// </exception>
        /// <remarks>
        ///   This method is functionally equal to doing an ordinal comparison of <paramref name="text" /> and
        ///   <see cref="Name" />, but can avoid creating the string instance.
        /// </remarks>
        public bool NameEquals(string? text)
        {
            return NameEquals(text.AsSpan());
        }

        /// <summary>
        ///   Compares the text represented by <paramref name="utf8Text" /> to the name of this property.
        /// </summary>
        /// <param name="utf8Text">The UTF-8 encoded text to compare against.</param>
        /// <returns>
        ///   <see langword="true" /> if the name of this property has the same UTF-8 encoding as
        ///   <paramref name="utf8Text" />, <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="Type"/> is not <see cref="JsonTokenType.PropertyName"/>.
        /// </exception>
        /// <remarks>
        ///   This method is functionally equal to doing an ordinal comparison of <paramref name="utf8Text" /> and
        ///   <see cref="Name" />, but can avoid creating the string instance.
        /// </remarks>
        public bool NameEquals(ReadOnlySpan<byte> utf8Text)
        {
            Value.CheckValidInstance();
            return Value.ParentDocument.TextEquals(Value.ParentDocumentIndex, utf8Text, isPropertyName: true, shouldUnescape: true);
        }

        /// <summary>
        ///   Compares <paramref name="text" /> to the name of this property.
        /// </summary>
        /// <param name="text">The text to compare against.</param>
        /// <returns>
        ///   <see langword="true" /> if the name of this property matches <paramref name="text"/>,
        ///   <see langword="false" /> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="Type"/> is not <see cref="JsonTokenType.PropertyName"/>.
        /// </exception>
        /// <remarks>
        ///   This method is functionally equal to doing an ordinal comparison of <paramref name="text" /> and
        ///   <see cref="Name" />, but can avoid creating the string instance.
        /// </remarks>
        public bool NameEquals(ReadOnlySpan<char> text)
        {
            Value.CheckValidInstance();
            return Value.ParentDocument.TextEquals(Value.ParentDocumentIndex, text, isPropertyName: true);
        }

        internal bool EscapedNameEquals(ReadOnlySpan<byte> utf8Text)
        {
            Value.CheckValidInstance();
            return Value.ParentDocument.TextEquals(Value.ParentDocumentIndex, utf8Text, isPropertyName: true, shouldUnescape: false);
        }

        internal bool NameIsEscaped => Value.ParentDocument.ValueIsEscaped(Value.ParentDocumentIndex, isPropertyName: true);

        internal ReadOnlySpan<byte> RawNameSpan
        {
            get
            {
                Value.CheckValidInstance();
                return Value.ParentDocument.GetPropertyNameRaw(Value.ParentDocumentIndex);
            }
        }

        /// <summary>
        ///   Write the property into the provided writer as a named JSON object property.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <exception cref="ArgumentNullException">
        ///   The <paramref name="writer"/> parameter is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   This <see cref="Name"/>'s length is too large to be a JSON object property.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///   This <see cref="Value"/>'s <see cref="JsonElement.ValueKind"/> would result in an invalid JSON.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>>
        public void WriteTo(Utf8JsonWriter writer)
        {
            ArgumentNullException.ThrowIfNull(writer);

            Value.CheckValidInstance();

            Value.ParentDocument.WritePropertyName(Value.ParentDocumentIndex, writer);
            Value.ParentDocument.WriteElementTo(Value.ParentDocumentIndex, writer);
        }

        /// <summary>
        ///   Provides a <see cref="string"/> representation of the property for
        ///   debugging purposes.
        /// </summary>
        /// <returns>
        ///   A string containing the un-interpreted value of the property, beginning
        ///   at the declaring open-quote and ending at the last character that is part of
        ///   the value.
        /// </returns>
        public override string ToString()
        {
            Value.CheckValidInstance();
            return Value.ParentDocument.GetPropertyRawValueAsString(Value.ParentDocumentIndex);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
            => Value.ValueKind == JsonValueKind.Undefined ? "<Undefined>" : $"\"{ToString()}\"";
    }
}
