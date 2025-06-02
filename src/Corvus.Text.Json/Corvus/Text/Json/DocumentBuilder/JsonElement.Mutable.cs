// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    public readonly partial struct JsonElement
    {
        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, JsonObjectBuilder.Build builder, int estimatedMemberCount = 30)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, estimatedMemberCount);
            JsonObjectBuilder.BuildValue(builder, ref cvb);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, JsonArrayBuilder.Build builder, int estimatedMemberCount = 30)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, estimatedMemberCount);
            JsonArrayBuilder.BuildValue(builder, ref cvb);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, string value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, ReadOnlySpan<char> value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, ReadOnlySpan<byte> value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocumentRawString(JsonWorkspace workspace, ReadOnlySpan<byte> value, bool requiresUnescaping)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value, false, requiresUnescaping);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, bool value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocumentNull(JsonWorkspace workspace)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItemNull();
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocumentFormattedNumber(JsonWorkspace workspace, ReadOnlySpan<byte> formattedNumber)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItemFormattedNumber(formattedNumber);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, long value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, ulong value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, int value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, uint value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, short value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, ushort value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, sbyte value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, byte value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, double value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, float value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, decimal value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

#if NET
        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, Int128 value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, UInt128 value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }

        [CLSCompliant(false)]
        public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, Half value)
        {
            // Create the document builder without a MetadataDb
            JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 1);
            cvb.AddItem(value);
            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
            return documentBuilder;
        }
#endif

        [CLSCompliant(false)]
        public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
        {
            return workspace.CreateDocument<JsonElement, Mutable>(this);
        }

        /// <summary>
        ///   Represents a specific JSON value within a <see cref="IMutableJsonDocument"/>.
        /// </summary>
        [DebuggerDisplay("{DebuggerDisplay,nq}")]
        public partial struct Mutable : IMutableJsonElement<Mutable>
        {
            private readonly IMutableJsonDocument _parent;
            private readonly int _idx;
            private ulong _documentVersion;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            internal Mutable(IJsonDocument parent, int idx)
            {
                // parent is usually not null, but the Current property
                // on the enumerators (when initialized as `default`) can
                // get here with a null.
                Debug.Assert(idx >= 0);

                _parent = (IMutableJsonDocument)parent;
                _idx = idx;
                _documentVersion = _parent?.Version ?? 0;
            }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private JsonTokenType TokenType
            {
                get
                {
                    return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
                }
            }

            /// <summary>
            ///   The <see cref="JsonValueKind"/> that the value is.
            /// </summary>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public JsonValueKind ValueKind => TokenType.ToValueKind();

            /// <summary>
            ///   Get the value at a specified index when the current value is a
            ///   <see cref="JsonValueKind.Array"/>.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Array"/>.
            /// </exception>
            /// <exception cref="IndexOutOfRangeException">
            ///   <paramref name="index"/> is not in the range [0, <see cref="GetArrayLength"/>()).
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public Mutable this[int index]
            {
                get
                {
                    CheckValidInstance();

                    return _parent.GetArrayIndexElement(_idx, index);
                }
            }

            public static implicit operator JsonElement(Mutable value)
            {
                return new(value._parent, value._idx);
            }

            public static explicit operator Mutable(JsonElement value)
            {
                if (value._parent is not IMutableJsonDocument doc)
                {
                    ThrowHelper.ThrowFormatException();
                    // We will never get here
                    return default;
                }

                return new(value._parent, value._idx);
            }

            [CLSCompliant(false)]
            public static Mutable From<T>(in T instance)
                where T : struct, IMutableJsonElement<T>
            {
                return new(instance.ParentDocument, instance.ParentDocumentIndex);
            }

            [CLSCompliant(false)]
            public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
            {
                return workspace.CreateDocument<JsonElement, Mutable>(this);
            }

            internal static bool IsValid(IJsonDocument parentDocument, int parentIndex)
            {
                return IsValid(parentDocument, parentIndex);
            }

            /// <summary>
            ///   Get the number of values contained within the current array value.
            /// </summary>
            /// <returns>The number of values contained within the current array value.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Array"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public int GetArrayLength()
            {
                CheckValidInstance();

                return _parent.GetArrayLength(_idx);
            }

            /// <summary>
            ///   Get the number of properties contained within the current object value.
            /// </summary>
            /// <returns>The number of properties contained within the current object value.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public int GetPropertyCount()
            {
                CheckValidInstance();

                return _parent.GetPropertyCount(_idx);
            }

            /// <summary>
            ///   Gets a <see cref="Mutable"/> representing the value of a required property identified
            ///   by <paramref name="propertyName"/>.
            /// </summary>
            /// <remarks>
            ///   Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///
            ///   If a property is defined multiple times for the same object, the last such definition is
            ///   what is matched.
            /// </remarks>
            /// <param name="propertyName">Name of the property whose value to return.</param>
            /// <returns>
            ///   A <see cref="Mutable"/> representing the value of the requested property.
            /// </returns>
            /// <seealso cref="EnumerateObject"/>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="KeyNotFoundException">
            ///   No property was found with the requested name.
            /// </exception>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="propertyName"/> is <see langword="null"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public Mutable GetProperty(string propertyName)
            {
                ArgumentNullException.ThrowIfNull(propertyName);

                if (TryGetProperty(propertyName, out Mutable property))
                {
                    return property;
                }

                throw new KeyNotFoundException();
            }

            /// <summary>
            ///   Gets a <see cref="Mutable"/> representing the value of a required property identified
            ///   by <paramref name="propertyName"/>.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///   </para>
            ///
            ///   <para>
            ///     If a property is defined multiple times for the same object, the last such definition is
            ///     what is matched.
            ///   </para>
            /// </remarks>
            /// <param name="propertyName">Name of the property whose value to return.</param>
            /// <returns>
            ///   A <see cref="Mutable"/> representing the value of the requested property.
            /// </returns>
            /// <seealso cref="EnumerateObject"/>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="KeyNotFoundException">
            ///   No property was found with the requested name.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public Mutable GetProperty(ReadOnlySpan<char> propertyName)
            {
                if (TryGetProperty(propertyName, out Mutable property))
                {
                    return property;
                }

                throw new KeyNotFoundException();
            }

            /// <summary>
            ///   Gets a <see cref="Mutable"/> representing the value of a required property identified
            ///   by <paramref name="utf8PropertyName"/>.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///   </para>
            ///
            ///   <para>
            ///     If a property is defined multiple times for the same object, the last such definition is
            ///     what is matched.
            ///   </para>
            /// </remarks>
            /// <param name="utf8PropertyName">
            ///   The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return.
            /// </param>
            /// <returns>
            ///   A <see cref="Mutable"/> representing the value of the requested property.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="KeyNotFoundException">
            ///   No property was found with the requested name.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="EnumerateObject"/>
            public Mutable GetProperty(ReadOnlySpan<byte> utf8PropertyName)
            {
                if (TryGetProperty(utf8PropertyName, out Mutable property))
                {
                    return property;
                }

                throw new KeyNotFoundException();
            }

            /// <summary>
            ///   Looks for a property named <paramref name="propertyName"/> in the current object, returning
            ///   whether or not such a property existed. When the property exists <paramref name="value"/>
            ///   is assigned to the value of that property.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///   </para>
            ///
            ///   <para>
            ///     If a property is defined multiple times for the same object, the last such definition is
            ///     what is matched.
            ///   </para>
            /// </remarks>
            /// <param name="propertyName">Name of the property to find.</param>
            /// <param name="value">Receives the value of the located property.</param>
            /// <returns>
            ///   <see langword="true"/> if the property was found, <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="ArgumentNullException">
            ///   <paramref name="propertyName"/> is <see langword="null"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="EnumerateObject"/>
            public bool TryGetProperty(string propertyName, out Mutable value)
            {
                ArgumentNullException.ThrowIfNull(propertyName);

                return TryGetProperty(propertyName.AsSpan(), out value);
            }

            /// <summary>
            ///   Looks for a property named <paramref name="propertyName"/> in the current object, returning
            ///   whether or not such a property existed. When the property exists <paramref name="value"/>
            ///   is assigned to the value of that property.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///   </para>
            ///
            ///   <para>
            ///     If a property is defined multiple times for the same object, the last such definition is
            ///     what is matched.
            ///   </para>
            /// </remarks>
            /// <param name="propertyName">Name of the property to find.</param>
            /// <param name="value">Receives the value of the located property.</param>
            /// <returns>
            ///   <see langword="true"/> if the property was found, <see langword="false"/> otherwise.
            /// </returns>
            /// <seealso cref="EnumerateObject"/>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetProperty(ReadOnlySpan<char> propertyName, out Mutable value)
            {
                CheckValidInstance();

                return _parent.TryGetNamedPropertyValue(_idx, propertyName, out value);
            }

            /// <summary>
            ///   Looks for a property named <paramref name="utf8PropertyName"/> in the current object, returning
            ///   whether or not such a property existed. When the property exists <paramref name="value"/>
            ///   is assigned to the value of that property.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     Property name matching is performed as an ordinal, case-sensitive, comparison.
            ///   </para>
            ///
            ///   <para>
            ///     If a property is defined multiple times for the same object, the last such definition is
            ///     what is matched.
            ///   </para>
            /// </remarks>
            /// <param name="utf8PropertyName">
            ///   The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return.
            /// </param>
            /// <param name="value">Receives the value of the located property.</param>
            /// <returns>
            ///   <see langword="true"/> if the property was found, <see langword="false"/> otherwise.
            /// </returns>
            /// <seealso cref="EnumerateObject"/>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, out Mutable value)
            {
                CheckValidInstance();

                return _parent.TryGetNamedPropertyValue(_idx, utf8PropertyName, out value);
            }

            /// <summary>
            ///   Gets the value of the element as a <see cref="bool"/>.
            /// </summary>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>The value of the element as a <see cref="bool"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is neither <see cref="JsonValueKind.True"/> or
            ///   <see cref="JsonValueKind.False"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool GetBoolean()
            {
                // CheckValidInstance is redundant.  Asking for the type will
                // return None, which then throws the same exception in the return statement.

                JsonTokenType type = TokenType;

                return
                    type == JsonTokenType.True ? true :
                    type == JsonTokenType.False ? false :
                    ThrowJsonElementWrongTypeException(type);

                static bool ThrowJsonElementWrongTypeException(JsonTokenType actualType)
                {
                    throw ThrowHelper.GetJsonElementWrongTypeException(nameof(Boolean), actualType.ToValueKind());
                }
            }

            /// <summary>
            ///   Gets the value of the element as a <see cref="string"/>.
            /// </summary>
            /// <remarks>
            ///   This method does not create a string representation of values other than JSON strings.
            /// </remarks>
            /// <returns>The value of the element as a <see cref="string"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is neither <see cref="JsonValueKind.String"/> nor <see cref="JsonValueKind.Null"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="ToString"/>
            public string? GetString()
            {
                CheckValidInstance();

                return _parent.GetString(_idx, JsonTokenType.String);
            }

            public UnescapedUtf8JsonString GetUtf8String()
            {
                CheckValidInstance();

                return _parent.GetUtf8JsonString(_idx, JsonTokenType.String);
            }

            /// <summary>
            ///   Attempts to represent the current JSON string as bytes assuming it is Base64 encoded.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///  This method does not create a byte[] representation of values other than base 64 encoded JSON strings.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the entire token value is encoded as valid Base64 text and can be successfully decoded to bytes.
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetBytesFromBase64([NotNullWhen(true)] out byte[]? value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the value of the element as bytes.
            /// </summary>
            /// <remarks>
            ///   This method does not create a byte[] representation of values other than Base64 encoded JSON strings.
            /// </remarks>
            /// <returns>The value decode to bytes.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value is not encoded as Base64 text and hence cannot be decoded to bytes.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="ToString"/>
            public byte[] GetBytesFromBase64()
            {
                if (!TryGetBytesFromBase64(out byte[]? value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as an <see cref="sbyte"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as an <see cref="sbyte"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public bool TryGetSByte(out sbyte value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as an <see cref="sbyte"/>.
            /// </summary>
            /// <returns>The current JSON number as an <see cref="sbyte"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as an <see cref="sbyte"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public sbyte GetSByte()
            {
                if (TryGetSByte(out sbyte value))
                {
                    return value;
                }

                throw new FormatException();
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="byte"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="byte"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetByte(out byte value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="byte"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="byte"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="byte"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public byte GetByte()
            {
                if (TryGetByte(out byte value))
                {
                    return value;
                }

                throw new FormatException();
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as an <see cref="short"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as an <see cref="short"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetInt16(out short value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as an <see cref="short"/>.
            /// </summary>
            /// <returns>The current JSON number as an <see cref="short"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as an <see cref="short"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public short GetInt16()
            {
                if (TryGetInt16(out short value))
                {
                    return value;
                }

                throw new FormatException();
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="ushort"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="ushort"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public bool TryGetUInt16(out ushort value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="ushort"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="ushort"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="ushort"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public ushort GetUInt16()
            {
                if (TryGetUInt16(out ushort value))
                {
                    return value;
                }

                throw new FormatException();
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as an <see cref="int"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as an <see cref="int"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetInt32(out int value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as an <see cref="int"/>.
            /// </summary>
            /// <returns>The current JSON number as an <see cref="int"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as an <see cref="int"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public int GetInt32()
            {
                if (!TryGetInt32(out int value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="uint"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="uint"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public bool TryGetUInt32(out uint value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="uint"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="uint"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="uint"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public uint GetUInt32()
            {
                if (!TryGetUInt32(out uint value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="long"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="long"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetInt64(out long value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="long"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="long"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="long"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public long GetInt64()
            {
                if (!TryGetInt64(out long value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="ulong"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="ulong"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public bool TryGetUInt64(out ulong value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="ulong"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="ulong"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="ulong"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public ulong GetUInt64()
            {
                if (!TryGetUInt64(out ulong value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="double"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   <para>
            ///     This method does not parse the contents of a JSON string value.
            ///   </para>
            ///
            ///   <para>
            ///     On .NET Core this method does not return <see langword="false"/> for values larger than
            ///     <see cref="double.MaxValue"/> (or smaller than <see cref="double.MinValue"/>),
            ///     instead <see langword="true"/> is returned and <see cref="double.PositiveInfinity"/> (or
            ///     <see cref="double.NegativeInfinity"/>) is emitted.
            ///   </para>
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="double"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetDouble(out double value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="double"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="double"/>.</returns>
            /// <remarks>
            ///   <para>
            ///     This method does not parse the contents of a JSON string value.
            ///   </para>
            ///
            ///   <para>
            ///     On .NET Core this method returns <see cref="double.PositiveInfinity"/> (or
            ///     <see cref="double.NegativeInfinity"/>) for values larger than
            ///     <see cref="double.MaxValue"/> (or smaller than <see cref="double.MinValue"/>).
            ///   </para>
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="double"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public double GetDouble()
            {
                if (!TryGetDouble(out double value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="float"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   <para>
            ///     This method does not parse the contents of a JSON string value.
            ///   </para>
            ///
            ///   <para>
            ///     On .NET Core this method does not return <see langword="false"/> for values larger than
            ///     <see cref="float.MaxValue"/> (or smaller than <see cref="float.MinValue"/>),
            ///     instead <see langword="true"/> is returned and <see cref="float.PositiveInfinity"/> (or
            ///     <see cref="float.NegativeInfinity"/>) is emitted.
            ///   </para>
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="float"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetSingle(out float value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="float"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="float"/>.</returns>
            /// <remarks>
            ///   <para>
            ///     This method does not parse the contents of a JSON string value.
            ///   </para>
            ///
            ///   <para>
            ///     On .NET Core this method returns <see cref="float.PositiveInfinity"/> (or
            ///     <see cref="float.NegativeInfinity"/>) for values larger than
            ///     <see cref="float.MaxValue"/> (or smaller than <see cref="float.MinValue"/>).
            ///   </para>
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="float"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public float GetSingle()
            {
                if (!TryGetSingle(out float value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="decimal"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="decimal"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public bool TryGetDecimal(out decimal value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="decimal"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="decimal"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="decimal"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public decimal GetDecimal()
            {
                if (!TryGetDecimal(out decimal value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

#if NET
            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="Int128"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="Int128"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public bool TryGetInt128(out Int128 value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="Int128"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="Int128"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="Int128"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public Int128 GetInt128()
            {
                if (!TryGetInt128(out Int128 value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="UInt128"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="UInt128"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            [CLSCompliant(false)]
            public bool TryGetUInt128(out UInt128 value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="UInt128"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="UInt128"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="UInt128"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            [CLSCompliant(false)]
            public UInt128 GetUInt128()
            {
                if (!TryGetUInt128(out UInt128 value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON number as a <see cref="Half"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the number can be represented as a <see cref="Half"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public bool TryGetHalf(out Half value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the current JSON number as a <see cref="Half"/>.
            /// </summary>
            /// <returns>The current JSON number as a <see cref="Half"/>.</returns>
            /// <remarks>
            ///   This method does not parse the contents of a JSON string value.
            /// </remarks>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="Half"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="GetRawText"/>
            public Half GetHalf()
            {
                if (!TryGetHalf(out Half value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }
#endif

            /// <summary>
            ///   Attempts to represent the current JSON string as a <see cref="DateTime"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not create a DateTime representation of values other than JSON strings.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the string can be represented as a <see cref="DateTime"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetDateTime(out DateTime value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the value of the element as a <see cref="DateTime"/>.
            /// </summary>
            /// <remarks>
            ///   This method does not create a DateTime representation of values other than JSON strings.
            /// </remarks>
            /// <returns>The value of the element as a <see cref="DateTime"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="DateTime"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="ToString"/>
            public DateTime GetDateTime()
            {
                if (!TryGetDateTime(out DateTime value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON string as a <see cref="DateTimeOffset"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not create a DateTimeOffset representation of values other than JSON strings.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the string can be represented as a <see cref="DateTimeOffset"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetDateTimeOffset(out DateTimeOffset value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the value of the element as a <see cref="DateTimeOffset"/>.
            /// </summary>
            /// <remarks>
            ///   This method does not create a DateTimeOffset representation of values other than JSON strings.
            /// </remarks>
            /// <returns>The value of the element as a <see cref="DateTimeOffset"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="DateTimeOffset"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="ToString"/>
            public DateTimeOffset GetDateTimeOffset()
            {
                if (!TryGetDateTimeOffset(out DateTimeOffset value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            /// <summary>
            ///   Attempts to represent the current JSON string as a <see cref="Guid"/>.
            /// </summary>
            /// <param name="value">Receives the value.</param>
            /// <remarks>
            ///   This method does not create a Guid representation of values other than JSON strings.
            /// </remarks>
            /// <returns>
            ///   <see langword="true"/> if the string can be represented as a <see cref="Guid"/>,
            ///   <see langword="false"/> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public bool TryGetGuid(out Guid value)
            {
                CheckValidInstance();

                return _parent.TryGetValue(_idx, out value);
            }

            /// <summary>
            ///   Gets the value of the element as a <see cref="Guid"/>.
            /// </summary>
            /// <remarks>
            ///   This method does not create a Guid representation of values other than JSON strings.
            /// </remarks>
            /// <returns>The value of the element as a <see cref="Guid"/>.</returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <exception cref="FormatException">
            ///   The value cannot be represented as a <see cref="Guid"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            /// <seealso cref="ToString"/>
            public Guid GetGuid()
            {
                if (!TryGetGuid(out Guid value))
                {
                    ThrowHelper.ThrowFormatException();
                }

                return value;
            }

            internal string GetPropertyName()
            {
                CheckValidInstance();

                return _parent.GetNameOfPropertyValue(_idx);
            }

            internal ReadOnlySpan<byte> GetPropertyNameRaw()
            {
                CheckValidInstance();

                return _parent.GetPropertyNameRaw(_idx);
            }

            /// <summary>
            ///   Gets the original input data backing this value, returning it as a <see cref="string"/>.
            /// </summary>
            /// <returns>
            ///   The original input data backing this value, returning it as a <see cref="string"/>.
            /// </returns>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public string GetRawText()
            {
                CheckValidInstance();

                return _parent.GetRawValueAsString(_idx);
            }

            internal RawUtf8JsonString GetRawValue()
            {
                CheckValidInstance();

                return _parent.GetRawValue(_idx, includeQuotes: true);
            }

            internal string GetPropertyRawText()
            {
                CheckValidInstance();

                return _parent.GetPropertyRawValueAsString(_idx);
            }

            internal bool ValueIsEscaped
            {
                get
                {
                    CheckValidInstance();

                    return _parent.ValueIsEscaped(_idx, isPropertyName: false);
                }
            }

            internal ReadOnlySpan<byte> ValueSpan
            {
                get
                {
                    CheckValidInstance();

                    return _parent.GetRawValue(_idx, includeQuotes: false).Span;
                }
            }

            public static void EnsurePropertyMap(in Mutable element)
            {
                element._parent.EnsurePropertyMap(element._idx);
            }

            /// <summary>
            ///   Compares <paramref name="text" /> to the string value of this element.
            /// </summary>
            /// <param name="text">The text to compare against.</param>
            /// <returns>
            ///   <see langword="true" /> if the string value of this element matches <paramref name="text"/>,
            ///   <see langword="false" /> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <remarks>
            ///   This method is functionally equal to doing an ordinal comparison of <paramref name="text" /> and
            ///   the result of calling <see cref="GetString" />, but avoids creating the string instance.
            /// </remarks>
            public bool ValueEquals(string? text)
            {
                // CheckValidInstance is done in the helper

                if (TokenType == JsonTokenType.Null)
                {
                    return text == null;
                }

                return TextEqualsHelper(text.AsSpan(), isPropertyName: false);
            }

            /// <summary>
            ///   Compares the text represented by <paramref name="utf8Text" /> to the string value of this element.
            /// </summary>
            /// <param name="utf8Text">The UTF-8 encoded text to compare against.</param>
            /// <returns>
            ///   <see langword="true" /> if the string value of this element has the same UTF-8 encoding as
            ///   <paramref name="utf8Text" />, <see langword="false" /> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <remarks>
            ///   This method is functionally equal to doing an ordinal comparison of the string produced by UTF-8 decoding
            ///   <paramref name="utf8Text" /> with the result of calling <see cref="GetString" />, but avoids creating the
            ///   string instances.
            /// </remarks>
            public bool ValueEquals(ReadOnlySpan<byte> utf8Text)
            {
                // CheckValidInstance is done in the helper

                if (TokenType == JsonTokenType.Null)
                {
                    // This is different than Length == 0, in that it tests true for null, but false for ""
#pragma warning disable CA2265
                    return utf8Text.Slice(0, 0) == default;
#pragma warning restore CA2265
                }

                return TextEqualsHelper(utf8Text, isPropertyName: false, shouldUnescape: true);
            }

            /// <summary>
            ///   Compares <paramref name="text" /> to the string value of this element.
            /// </summary>
            /// <param name="text">The text to compare against.</param>
            /// <returns>
            ///   <see langword="true" /> if the string value of this element matches <paramref name="text"/>,
            ///   <see langword="false" /> otherwise.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
            /// </exception>
            /// <remarks>
            ///   This method is functionally equal to doing an ordinal comparison of <paramref name="text" /> and
            ///   the result of calling <see cref="GetString" />, but avoids creating the string instance.
            /// </remarks>
            public bool ValueEquals(ReadOnlySpan<char> text)
            {
                // CheckValidInstance is done in the helper

                if (TokenType == JsonTokenType.Null)
                {
                    // This is different than Length == 0, in that it tests true for null, but false for ""
#pragma warning disable CA2265
                    return text.Slice(0, 0) == default;
#pragma warning restore CA2265
                }

                return TextEqualsHelper(text, isPropertyName: false);
            }

            internal bool TextEqualsHelper(ReadOnlySpan<byte> utf8Text, bool isPropertyName, bool shouldUnescape)
            {
                CheckValidInstance();

                return _parent.TextEquals(_idx, utf8Text, isPropertyName, shouldUnescape);
            }

            internal bool TextEqualsHelper(ReadOnlySpan<char> text, bool isPropertyName)
            {
                CheckValidInstance();

                return _parent.TextEquals(_idx, text, isPropertyName);
            }

            internal bool ValueIsEscapedHelper(bool isPropertyName)
            {
                CheckValidInstance();

                return _parent.ValueIsEscaped(_idx, isPropertyName);
            }

            /// <summary>
            ///   Write the element into the provided writer as a JSON value.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <exception cref="ArgumentNullException">
            ///   The <paramref name="writer"/> parameter is <see langword="null"/>.
            /// </exception>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is <see cref="JsonValueKind.Undefined"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public void WriteTo(Utf8JsonWriter writer)
            {
                ArgumentNullException.ThrowIfNull(writer);

                CheckValidInstance();

                _parent.WriteElementTo(_idx, writer);
            }

            /// <summary>
            ///   Get an enumerator to enumerate the values in the JSON array represented by this Mutable.
            /// </summary>
            /// <returns>
            ///   An enumerator to enumerate the values in the JSON array represented by this Mutable.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Array"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public ArrayEnumerator<Mutable> EnumerateArray()
            {
                CheckValidInstance();

                JsonTokenType tokenType = TokenType;

                if (tokenType != JsonTokenType.StartArray)
                {
                    ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, tokenType);
                }

                return new ArrayEnumerator<Mutable>(_parent, _idx);
            }

            /// <summary>
            ///   Get an enumerator to enumerate the properties in the JSON object represented by this Mutable.
            /// </summary>
            /// <returns>
            ///   An enumerator to enumerate the properties in the JSON object represented by this Mutable.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Object"/>.
            /// </exception>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            [CLSCompliant(false)]
            public ObjectEnumerator<Mutable> EnumerateObject()
            {
                CheckValidInstance();

                JsonTokenType tokenType = TokenType;

                if (tokenType != JsonTokenType.StartObject)
                {
                    ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, tokenType);
                }

                return new ObjectEnumerator<Mutable>(_parent, _idx);
            }

            /// <summary>
            ///   Gets a string representation for the current value appropriate to the value type.
            /// </summary>
            /// <remarks>
            ///   <para>
            ///     For Mutable built from <see cref="IMutableJsonDocument"/>:
            ///   </para>
            ///
            ///   <para>
            ///     For <see cref="JsonValueKind.Null"/>, <see cref="string.Empty"/> is returned.
            ///   </para>
            ///
            ///   <para>
            ///     For <see cref="JsonValueKind.True"/>, <see cref="bool.TrueString"/> is returned.
            ///   </para>
            ///
            ///   <para>
            ///     For <see cref="JsonValueKind.False"/>, <see cref="bool.FalseString"/> is returned.
            ///   </para>
            ///
            ///   <para>
            ///     For <see cref="JsonValueKind.String"/>, the value of <see cref="GetString"/>() is returned.
            ///   </para>
            ///
            ///   <para>
            ///     For other types, the value of <see cref="GetRawText"/>() is returned.
            ///   </para>
            /// </remarks>
            /// <returns>
            ///   A string representation for the current value appropriate to the value type.
            /// </returns>
            /// <exception cref="ObjectDisposedException">
            ///   The parent <see cref="JsonDocument"/> has been disposed.
            /// </exception>
            public override string ToString()
            {
                if (_parent == null || _documentVersion != _parent.Version)
                {
                    return string.Empty;
                }

                switch (TokenType)
                {
                    case JsonTokenType.None:
                    case JsonTokenType.Null:
                        return string.Empty;
                    case JsonTokenType.True:
                        return bool.TrueString;
                    case JsonTokenType.False:
                        return bool.FalseString;
                    case JsonTokenType.Number:
                    case JsonTokenType.StartArray:
                    case JsonTokenType.StartObject:
                    {
                        // null parent should have hit the None case
                        Debug.Assert(_parent != null);
                        return _parent.GetRawValueAsString(_idx);
                    }
                    case JsonTokenType.String:
                        return GetString()!;
                    case JsonTokenType.Comment:
                    case JsonTokenType.EndArray:
                    case JsonTokenType.EndObject:
                    default:
                        Debug.Fail($"No handler for {nameof(JsonTokenType)}.{TokenType}");
                        return string.Empty;
                }
            }

            /// <summary>
            ///   Get a JsonElement which can be safely stored beyond the lifetime of the
            ///   original <see cref="IMutableJsonDocument"/>.
            /// </summary>
            /// <returns>
            ///   A JsonElement which can be safely stored beyond the lifetime of the
            ///   original <see cref="IMutableJsonDocument"/>.
            /// </returns>
            public JsonElement Clone()
            {
                CheckValidInstance();

                return _parent.CloneElement(_idx);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, JsonObjectBuilder.Build objectValue, int estimatedMemberCount = 30)
            {
                SetProperty(propertyName.AsSpan(), objectValue, estimatedMemberCount);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, JsonObjectBuilder.Build objectValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem((ref o) => JsonObjectBuilder.BuildValue(objectValue, ref o));
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, (ref o) => JsonObjectBuilder.BuildValue(objectValue, ref o));
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, JsonObjectBuilder.Build objectValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem((ref o) => JsonObjectBuilder.BuildValue(objectValue, ref o));
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, (ref o) => JsonObjectBuilder.BuildValue(objectValue, ref o));
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, JsonArrayBuilder.Build arrayValue, int estimatedMemberCount = 30)
            {
                SetProperty(propertyName.AsSpan(), arrayValue, estimatedMemberCount);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, JsonArrayBuilder.Build arrayValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem((ref o) => JsonArrayBuilder.BuildValue(arrayValue, ref o));
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, (ref o) => JsonArrayBuilder.BuildValue(arrayValue, ref o));
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, JsonArrayBuilder.Build arrayValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem((ref o) => JsonArrayBuilder.BuildValue(arrayValue, ref o));
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, (ref o) => JsonArrayBuilder.BuildValue(arrayValue, ref o));
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, string utf8StringValue)
            {
                SetProperty(propertyName.AsSpan(), utf8StringValue.AsSpan());
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> utf8StringValue)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem(utf8StringValue);
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, utf8StringValue);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8StringValue)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItem(utf8StringValue);
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, utf8StringValue);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetPropertyNull(string propertyName)
            {
                SetPropertyNull(propertyName.AsSpan());
            }
            public void SetPropertyNull(ReadOnlySpan<char> propertyName)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItemNull();
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddPropertyNull(propertyName);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetPropertyNull(ReadOnlySpan<byte> propertyName)
            {
                CheckValidInstance();

                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement value))
                {
                    // We are going to replace just the value
                    cvb.AddItemNull();
                    _parent.OverwriteAndDispose(_idx, value._idx, value._idx + value._parent.GetDbSize(value._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddPropertyNull(propertyName);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, bool value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, bool value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, bool value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty<T>(string propertyName, T value)
                where T : struct, IJsonElement<T>
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty<T>(ReadOnlySpan<char> propertyName, T value)
                where T : struct, IJsonElement<T>
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty<T>(ReadOnlySpan<byte> propertyName, T value)
                where T : struct, IJsonElement<T>
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, Guid value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, Guid value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, Guid value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, DateTime value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, DateTime value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, DateTime value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, DateTimeOffset value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, DateTimeOffset value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }


            public void SetProperty(ReadOnlySpan<byte> propertyName, DateTimeOffset value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [CLSCompliant(false)]
            public void SetProperty(string propertyName, sbyte value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<char> propertyName, sbyte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<byte> propertyName, sbyte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, byte value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, byte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, byte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, int value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, int value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, int value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [CLSCompliant(false)]
            public void SetProperty(string propertyName, uint value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<char> propertyName, uint value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<byte> propertyName, uint value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, long value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, long value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, long value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [CLSCompliant(false)]
            public void SetProperty(string propertyName, ulong value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<char> propertyName, ulong value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<byte> propertyName, ulong value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, short value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, short value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, short value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [CLSCompliant(false)]
            public void SetProperty(string propertyName, ushort value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<char> propertyName, ushort value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<byte> propertyName, ushort value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, float value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, float value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, float value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, double value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, double value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, double value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, decimal value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, decimal value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, decimal value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

#if NET
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, Int128 value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, Int128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, Int128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [CLSCompliant(false)]
            public void SetProperty(string propertyName, UInt128 value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<char> propertyName, UInt128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetProperty(string propertyName, Half value)
            {
                SetProperty(propertyName.AsSpan(), value);
            }

            public void SetProperty(ReadOnlySpan<char> propertyName, Half value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetProperty(ReadOnlySpan<byte> propertyName, Half value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                if (_parent.TryGetNamedPropertyValue(_idx, propertyName, out JsonElement element))
                {
                    // We are going to replace just the value
                    cvb.AddItem(value);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }
                else
                {
                    // We are going to insert the new value
                    cvb.AddProperty(propertyName, value);
                    int endIndex = _idx + _parent.GetDbSize(_idx, false);
                    _parent.InsertAndDispose(_idx, endIndex, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

#endif

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetItem(int itemIndex, string value)
            {
                SetItem(itemIndex, value.AsSpan());
            }

            public void SetItem(int itemIndex, ReadOnlySpan<char> value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, ReadOnlySpan<byte> value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, JsonObjectBuilder.Build objectValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                cvb.AddItem((ref o) => JsonObjectBuilder.BuildValue(objectValue, ref o));
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, JsonArrayBuilder.Build arrayValue, int estimatedMemberCount = 30)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, estimatedMemberCount);
                cvb.AddItem((ref o) => JsonArrayBuilder.BuildValue(arrayValue, ref o));
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItemNull(int itemIndex)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItemNull();
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, bool value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem<T>(int itemIndex, T value)
                where T : struct, IJsonElement<T>
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, Guid value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, DateTime value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, DateTimeOffset value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem(int itemIndex, sbyte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, byte value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, int value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem(int itemIndex, uint value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, long value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem(int itemIndex, ulong value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, short value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem(int itemIndex, ushort value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, float value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, double value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, decimal value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }


#if NET
            public void SetItem(int itemIndex, Int128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            [CLSCompliant(false)]
            public void SetItem(int itemIndex, UInt128 value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }

            public void SetItem(int itemIndex, Half value)
            {
                CheckValidInstance();
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 1);
                cvb.AddItem(value);
                int arrayLength = GetArrayLength();
                if (itemIndex == arrayLength)
                {
                    _parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);
                }
                else
                {
                    Mutable element = _parent.GetArrayIndexElement(_idx, itemIndex);
                    _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
                }

                _documentVersion = _parent.Version;
            }
#endif

            private void CheckValidInstance()
            {
                if (_parent == null)
                {
                    throw new InvalidOperationException();
                }

                if (_documentVersion != _parent.Version)
                {
                    throw new InvalidOperationException();
                }
            }

            void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
            static Mutable IJsonElement<Mutable>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new Mutable(parentDocument, parentDocumentIndex);
#endif

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private string DebuggerDisplay => $"JsonElement.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            IJsonDocument IJsonElement.ParentDocument => _parent;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            int IJsonElement.ParentDocumentIndex => _idx;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            JsonTokenType IJsonElement.TokenType => TokenType;

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            JsonValueKind IJsonElement.ValueKind => ValueKind;
        }
    }
}
