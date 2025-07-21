// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json.Internal;
using NodaTime;

namespace Corvus.Text.Json;

public readonly partial struct JsonElement
{
    /// <summary>
    /// Represents a source for creating mutable JSON elements from various value types.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="Source"/> ref struct provides a unified abstraction for converting .NET values
    /// into JSON element sources, enabling type-safe and efficient construction of mutable JSON documents
    /// through the <see cref="JsonDocumentBuilder{T}"/> infrastructure.
    /// </para>
    /// <para>
    /// <strong>Core Architecture:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description><strong>Type Abstraction:</strong> Unified interface for 40+ .NET types including primitives, strings, dates, and custom types</description></item>
    /// <item><description><strong>Value Storage:</strong> Optimized backing stores for different value categories (simple types, UTF-8/UTF-16 strings, complex builders)</description></item>
    /// <item><description><strong>Kind Classification:</strong> Internal discrimination system for efficient dispatch during JSON construction</description></item>
    /// <item><description><strong>Zero-Copy Design:</strong> Direct span-based operations for string and numeric data where possible</description></item>
    /// </list>
    /// <para>
    /// <strong>Integration with JsonDocumentBuilder:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description><see cref="CreateDocumentBuilder"/> creates document builders from Source instances</description></item>
    /// <item><description><see cref="AddAsProperty"/> and <see cref="AddAsItem"/> integrate with <see cref="ComplexValueBuilder"/> for nested structures</description></item>
    /// <item><description>Automatic format selection and optimization based on value type and characteristics</description></item>
    /// </list>
    /// <para>
    /// <strong>Performance Characteristics:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description>Stack-allocated ref struct with minimal heap allocations</description></item>
    /// <item><description>Direct UTF-8 formatting for numeric types using <see cref="SimpleTypesBacking"/></description></item>
    /// <item><description>Efficient span-based string handling with escape analysis</description></item>
    /// <item><description>Lazy evaluation and format-on-demand for complex values</description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <para>Basic value construction:</para>
    /// <code>
    /// using JsonWorkspace workspace = JsonWorkspace.Create();
    ///
    /// // Numeric values
    /// using var intDoc = JsonElement.CreateDocumentBuilder(workspace, 42);
    /// using var doubleDoc = JsonElement.CreateDocumentBuilder(workspace, 3.14159);
    ///
    /// // String values
    /// using var stringDoc = JsonElement.CreateDocumentBuilder(workspace, "Hello, World!");
    /// using var utf8Doc = JsonElement.CreateDocumentBuilder(workspace, "Hello"u8);
    ///
    /// // Boolean and null
    /// using var boolDoc = JsonElement.CreateDocumentBuilder(workspace, true);
    /// using var nullDoc = JsonElement.CreateDocumentBuilder(workspace, JsonElement.Source.Null());
    /// </code>
    /// </example>
    /// <example>
    /// <para>Complex object construction:</para>
    /// <code>
    /// using var objectDoc = JsonElement.CreateDocumentBuilder(workspace,
    ///     new((ref JsonObjectBuilder objBuilder) =>
    ///     {
    ///         objBuilder.Add("name", "John Doe");
    ///         objBuilder.Add("age", 30);
    ///         objBuilder.Add("active", true);
    ///         objBuilder.Add("metadata", new((ref JsonObjectBuilder metaBuilder) =>
    ///         {
    ///             metaBuilder.Add("created", DateTime.UtcNow);
    ///             metaBuilder.Add("version", 1);
    ///         }));
    ///     }));
    /// </code>
    /// </example>
    /// <example>
    /// <para>Array construction:</para>
    /// <code>
    /// using var arrayDoc = JsonElement.CreateDocumentBuilder(workspace,
    ///     new((ref JsonArrayBuilder arrayBuilder) =>
    ///     {
    ///         arrayBuilder.Add(1);
    ///         arrayBuilder.Add("two");
    ///         arrayBuilder.Add(3.0);
    ///         arrayBuilder.Add(new((ref JsonObjectBuilder objBuilder) =>
    ///         {
    ///             objBuilder.Add("nested", true);
    ///         }));
    ///     }));
    /// </code>
    /// </example>
    public readonly ref struct Source
    {
        /// <summary>
        /// Discriminates the type and storage mechanism for the source value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The Kind enum enables efficient dispatch during JSON construction by categorizing
        /// values based on their storage requirements and formatting needs:
        /// </para>
        /// <list type="bullet">
        /// <item><description><strong>Simple Values:</strong> Null, True, False - stored as kind only</description></item>
        /// <item><description><strong>Numeric Types:</strong> NumericSimpleType - formatted via SimpleTypesBacking</description></item>
        /// <item><description><strong>String Types:</strong> Multiple variants for UTF-8/UTF-16, escaped/unescaped</description></item>
        /// <item><description><strong>Complex Types:</strong> Array and object builders for nested structures</description></item>
        /// </list>
        /// </remarks>
        private enum Kind
        {
            // We only need to include the kinds we
            // actually need!
            Unknown,

            JsonElement,
            Null,
            True,
            False,
            NumericSimpleType,
            FormattedNumber,
            StringSimpleType,
            RawUtf8StringRequiresUnescaping,
            RawUtf8StringNotRequiresUnescaping,
            Utf8String,
            Utf16String,

            // Add additional kinds for composed schema builders
            JsonArrayBuilderInstance,

            JsonObjectBuilderInstance,
        }

        private readonly Kind _kind;
        private readonly JsonElement _jsonElement;
        private readonly SimpleTypesBacking _simpleTypeBacking;
        private readonly ReadOnlySpan<byte> _utf8Backing;
        private readonly ReadOnlySpan<char> _utf16Backing;
        private readonly JsonArrayBuilder.Build? _arrayBuilder;
        private readonly JsonObjectBuilder.Build? _objectBuilder;

        private Source(JsonElement jsonElement)
        {
            _jsonElement = jsonElement;
            _kind = Kind.JsonElement;
        }

        private Source(Kind kind)
        {
            Debug.Assert(kind is Kind.Null or Kind.True or Kind.False);
            _kind = kind;
        }

        private Source(ReadOnlySpan<byte> value)
        {
            _utf8Backing = value;
            _kind = Kind.Utf8String;
        }

        private Source(ReadOnlySpan<char> value)
        {
            _utf16Backing = value;
            _kind = Kind.Utf16String;
        }

        private Source(ReadOnlySpan<byte> value, Kind kind)
        {
            Debug.Assert(kind is Kind.FormattedNumber);

            _utf8Backing = value;
            _kind = kind;
        }

        private Source(ReadOnlySpan<byte> value, bool requiresUnescaping)
        {
            _utf8Backing = value;
            _kind = requiresUnescaping ? Kind.RawUtf8StringRequiresUnescaping : Kind.RawUtf8StringNotRequiresUnescaping;
        }

        private Source(long value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(int value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(short value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(sbyte value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(ulong value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(uint value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(ushort value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a byte value.
        /// </summary>
        /// <param name="value">The byte value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// This constructor uses <see cref="SimpleTypesBacking"/> to efficiently format the numeric value
        /// into UTF-8 bytes using <see cref="Utf8Formatter.TryFormat(byte, Span{byte}, out int)"/>.
        /// The formatted bytes are stored in a stack-allocated buffer for zero-allocation JSON generation.
        /// </para>
        /// <para>
        /// <strong>Performance Notes:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>No heap allocations during construction or formatting</description></item>
        /// <item><description>Direct UTF-8 output eliminates string conversion overhead</description></item>
        /// <item><description>Uses optimized formatting paths from System.Buffers.Text</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a JSON number without quotes.
        /// </para>
        /// </remarks>
        private Source(byte value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a decimal value.
        /// </summary>
        /// <param name="value">The decimal value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// This constructor uses <see cref="SimpleTypesBacking"/> to efficiently format the numeric value
        /// into UTF-8 bytes using <see cref="Utf8Formatter.TryFormat(decimal, Span{byte}, out int)"/>.
        /// The formatted bytes are stored in a stack-allocated buffer for zero-allocation JSON generation.
        /// </para>
        /// <para>
        /// <strong>Performance Notes:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>No heap allocations during construction or formatting</description></item>
        /// <item><description>Direct UTF-8 output eliminates string conversion overhead</description></item>
        /// <item><description>Uses optimized formatting paths from System.Buffers.Text</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a JSON number without quotes.
        /// </para>
        /// </remarks>
        private Source(decimal value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a double value.
        /// </summary>
        /// <param name="value">The double value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// This constructor uses <see cref="SimpleTypesBacking"/> to efficiently format the numeric value
        /// into UTF-8 bytes using <see cref="Utf8Formatter.TryFormat(double, Span{byte}, out int)"/>.
        /// The formatted bytes are stored in a stack-allocated buffer for zero-allocation JSON generation.
        /// </para>
        /// <para>
        /// <strong>Performance Notes:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>No heap allocations during construction or formatting</description></item>
        /// <item><description>Direct UTF-8 output eliminates string conversion overhead</description></item>
        /// <item><description>Uses optimized formatting paths from System.Buffers.Text</description></item>
        /// </list>
        /// <para>
        /// <strong>Special Values:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>NaN values are formatted as "NaN" (not valid JSON, use with caution)</description></item>
        /// <item><description>Infinity values are formatted as "Infinity" or "-Infinity"</description></item>
        /// <item><description>Consider validation for JSON compliance in strict scenarios</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a JSON number without quotes.
        /// </para>
        /// </remarks>
        private Source(double value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a float value.
        /// </summary>
        /// <param name="value">The float value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// This constructor uses <see cref="SimpleTypesBacking"/> to efficiently format the numeric value
        /// into UTF-8 bytes using <see cref="Utf8Formatter.TryFormat(float, Span{byte}, out int)"/>.
        /// The formatted bytes are stored in a stack-allocated buffer for zero-allocation JSON generation.
        /// </para>
        /// <para>
        /// <strong>Performance Notes:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>No heap allocations during construction or formatting</description></item>
        /// <item><description>Direct UTF-8 output eliminates string conversion overhead</description></item>
        /// <item><description>Uses optimized formatting paths from System.Buffers.Text</description></item>
        /// </list>
        /// <para>
        /// <strong>Special Values:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>NaN values are formatted as "NaN" (not valid JSON, use with caution)</description></item>
        /// <item><description>Infinity values are formatted as "Infinity" or "-Infinity"</description></item>
        /// <item><description>Consider validation for JSON compliance in strict scenarios</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a JSON number without quotes.
        /// </para>
        /// </remarks>
        private Source(float value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a DateTimeOffset value.
        /// </summary>
        /// <param name="value">The DateTimeOffset value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// Date and time values are formatted as JSON strings using specialized formatting logic.
        /// The value is pre-formatted into UTF-8 bytes and stored with <see cref="Kind.StringSimpleType"/>
        /// to indicate string representation in the final JSON.
        /// </para>
        /// <para>
        /// <strong>Formatting Behavior:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>Uses <see cref="Utf8Formatter.TryFormat(DateTimeOffset, Span{byte}, out int)"/> with ISO 8601 format</description></item>
        /// <item><description>Output includes surrounding quotes as per JSON string specification</description></item>
        /// <item><description>Preserves timezone offset information in the formatted output</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a quoted JSON string with ISO 8601 format
        /// including timezone offset (e.g., "2023-07-20T10:30:00+00:00").
        /// </para>
        /// </remarks>
        private Source(DateTimeOffset value)
        {
            //                                                                We inject the actual formatting code from the formatter infrastructure
            //                                                                                                                     |
            //                                                                                              /---------------------------------------------\
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            // ... and also get the kind to use from there
            //                 |
            //      /-------------------\
            _kind = Kind.StringSimpleType;
        }

        private Source(DateTime value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from an OffsetDateTime value.
        /// </summary>
        /// <param name="value">The OffsetDateTime value to convert to a JSON source.</param>
        /// <remarks>
        /// <para>
        /// NodaTime date and time values are formatted as JSON strings using specialized formatting logic
        /// from <see cref="JsonElementHelpers"/>. The value is pre-formatted into UTF-8 bytes and stored
        /// with <see cref="Kind.StringSimpleType"/> to indicate string representation in the final JSON.
        /// </para>
        /// <para>
        /// <strong>Formatting Behavior:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>Uses <see cref="JsonElementHelpers.TryFormatOffsetDateTime"/> for specialized NodaTime formatting</description></item>
        /// <item><description>Output includes surrounding quotes as per JSON string specification</description></item>
        /// <item><description>Preserves precise NodaTime semantics and timezone offset information</description></item>
        /// </list>
        /// <para>
        /// The resulting JSON will represent this value as a quoted JSON string with NodaTime's
        /// standard OffsetDateTime format including timezone offset.
        /// </para>
        /// </remarks>
        private Source(OffsetDateTime value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatOffsetDateTime(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(OffsetDate value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatOffsetDate(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(OffsetTime value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatOffsetTime(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(LocalDate value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatLocalDate(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(Period value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => JsonElementHelpers.TryFormatPeriod(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(Guid value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.StringSimpleType;
        }

        private Source(Uri value)
        {
            _utf16Backing = value.OriginalString.AsSpan();
            _kind = Kind.Utf16String;
        }

#if NET

        private Source(Int128 value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(UInt128 value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        private Source(Half value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => v.TryFormat(buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a JSON array builder.
        /// </summary>
        /// <param name="value">The array builder delegate to use as the source.</param>
        public Source(JsonArrayBuilder.Build value)
        {
            _arrayBuilder = value;
            _kind = Kind.JsonArrayBuilderInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Source"/> struct from a JSON object builder.
        /// </summary>
        /// <param name="value">The object builder delegate to use as the source.</param>
        public Source(JsonObjectBuilder.Build value)
        {
            _objectBuilder = value;
            _kind = Kind.JsonObjectBuilderInstance;
        }

        /// <summary>
        /// Implicitly converts a <see cref="JsonElement"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The JSON element to convert.</param>
        /// <returns>A source representing the JSON element.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(in JsonElement value)
        {
            // This would normally be
            //return new(JsonElement.From(value));
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a UTF-8 byte span to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The UTF-8 byte span to convert.</param>
        /// <returns>A source representing the UTF-8 string.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ReadOnlySpan<byte> value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a UTF-16 character span to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The UTF-16 character span to convert.</param>
        /// <returns>A source representing the UTF-16 string.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ReadOnlySpan<char> value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a string to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>A source representing the string.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(string value)
        {
            return new(value.AsSpan());
        }

        /// <summary>
        /// Implicitly converts a <see cref="DateTimeOffset"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The DateTimeOffset value to convert.</param>
        /// <returns>A source representing the DateTimeOffset value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(DateTimeOffset value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="DateTime"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>A source representing the DateTime value.</returns>
        public static implicit operator Source(DateTime value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an <see cref="OffsetDateTime"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The OffsetDateTime value to convert.</param>
        /// <returns>A source representing the OffsetDateTime value.</returns>
        public static implicit operator Source(OffsetDateTime value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an <see cref="OffsetDate"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The OffsetDate value to convert.</param>
        /// <returns>A source representing the OffsetDate value.</returns>
        public static implicit operator Source(OffsetDate value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an <see cref="OffsetTime"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The OffsetTime value to convert.</param>
        /// <returns>A source representing the OffsetTime value.</returns>
        public static implicit operator Source(OffsetTime value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="LocalDate"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The LocalDate value to convert.</param>
        /// <returns>A source representing the LocalDate value.</returns>
        public static implicit operator Source(LocalDate value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Period"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The Period value to convert.</param>
        /// <returns>A source representing the Period value.</returns>
        public static implicit operator Source(Period value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Guid"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The Guid value to convert.</param>
        /// <returns>A source representing the Guid value.</returns>
        public static implicit operator Source(Guid value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Uri"/> to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The Uri value to convert.</param>
        /// <returns>A source representing the Uri value.</returns>
        public static implicit operator Source(Uri value)
        {
            return new(value);
        }

        /// <summary>
        /// Creates a <see cref="Source"/> representing a null value.
        /// </summary>
        /// <returns>A source representing a null JSON value.</returns>
        /// <remarks>
        /// <para>
        /// This method creates a lightweight source that represents a JSON null value.
        /// The source stores only the <see cref="Kind.Null"/> discriminator without any
        /// additional data, making it extremely efficient for null value construction.
        /// </para>
        /// <para>
        /// <strong>Usage Examples:</strong>
        /// </para>
        /// <code>
        /// // Create a document with null value
        /// using var doc = JsonElement.CreateDocumentBuilder(workspace, JsonElement.Source.Null());
        ///
        /// // Add null property to object
        /// objBuilder.Add("nullProp", JsonElement.Source.Null());
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Source Null()
        {
            return new(Kind.Null);
        }

        /// <summary>
        /// Creates a <see cref="Source"/> from a raw UTF-8 string.
        /// </summary>
        /// <param name="value">The raw UTF-8 string bytes.</param>
        /// <param name="requiresUnescaping">Whether the string requires unescaping.</param>
        /// <returns>A source representing the raw UTF-8 string.</returns>
        /// <remarks>
        /// <para>
        /// This method creates a source from pre-existing UTF-8 string data, avoiding
        /// encoding conversion overhead. The <paramref name="requiresUnescaping"/> parameter
        /// indicates whether the string contains JSON escape sequences that need processing.
        /// </para>
        /// <para>
        /// <strong>Escape Handling:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description><c>requiresUnescaping = true</c>: String contains escape sequences like \n, \", \\</description></item>
        /// <item><description><c>requiresUnescaping = false</c>: String is literal and needs no unescaping</description></item>
        /// <item><description>The choice affects performance during JSON construction</description></item>
        /// </list>
        /// <para>
        /// <strong>Usage Examples:</strong>
        /// </para>
        /// <code>
        /// // Raw string without escapes
        /// var source1 = JsonElement.Source.RawString("hello"u8, requiresUnescaping: false);
        ///
        /// // String with escape sequences
        /// var source2 = JsonElement.Source.RawString("hello\\nworld"u8, requiresUnescaping: true);
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Source RawString(ReadOnlySpan<byte> value, bool requiresUnescaping)
        {
            return new(value, requiresUnescaping);
        }

        /// <summary>
        /// Creates a <see cref="Source"/> from a formatted number value.
        /// </summary>
        /// <param name="value">The raw UTF-8 bytes representing the formatted number.</param>
        /// <returns>A source representing the formatted number.</returns>
        /// <remarks>
        /// <para>
        /// This method creates a source from pre-formatted numeric data in UTF-8 encoding,
        /// avoiding the overhead of numeric formatting during JSON construction. The provided
        /// bytes should represent a valid JSON number without quotes.
        /// </para>
        /// <para>
        /// <strong>Format Requirements:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description>Must be valid JSON number format (e.g., "123", "-45.67", "1.23e-4")</description></item>
        /// <item><description>Must not include surrounding quotes</description></item>
        /// <item><description>Must be UTF-8 encoded</description></item>
        /// <item><description>Should follow JSON numeric format specification</description></item>
        /// </list>
        /// <para>
        /// <strong>Usage Examples:</strong>
        /// </para>
        /// <code>
        /// // Pre-formatted integer
        /// var source1 = JsonElement.Source.FormattedNumber("12345"u8);
        ///
        /// // Pre-formatted decimal
        /// var source2 = JsonElement.Source.FormattedNumber("123.456"u8);
        ///
        /// // Scientific notation
        /// var source3 = JsonElement.Source.FormattedNumber("1.23e+10"u8);
        /// </code>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Source FormattedNumber(ReadOnlySpan<byte> value)
        {
            return new(value, Kind.FormattedNumber);
        }

        /// <summary>
        /// Implicitly converts a boolean value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>A source representing the boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(bool value)
        {
            return new(value ? Kind.True : Kind.False);
        }

        /// <summary>
        /// Implicitly converts a long value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>A source representing the long value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(long value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an integer value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The integer value to convert.</param>
        /// <returns>A source representing the integer value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(int value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a short value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>A source representing the short value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(short value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a signed byte value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The signed byte value to convert.</param>
        /// <returns>A source representing the signed byte value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(sbyte value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an unsigned long value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The unsigned long value to convert.</param>
        /// <returns>A source representing the unsigned long value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ulong value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an unsigned integer value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The unsigned integer value to convert.</param>
        /// <returns>A source representing the unsigned integer value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(uint value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts an unsigned short value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The unsigned short value to convert.</param>
        /// <returns>A source representing the unsigned short value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ushort value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a byte value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <returns>A source representing the byte value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(byte value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a decimal value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>A source representing the decimal value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(decimal value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a double value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>A source representing the double value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(double value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a float value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>A source representing the float value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(float value)
        {
            return new(value);
        }

#if NET

        /// <summary>
        /// Implicitly converts an Int128 value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The Int128 value to convert.</param>
        /// <returns>A source representing the Int128 value.</returns>
        public static implicit operator Source(Int128 value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a UInt128 value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The UInt128 value to convert.</param>
        /// <returns>A source representing the UInt128 value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        public static implicit operator Source(UInt128 value)
        {
            return new(value);
        }

        /// <summary>
        /// Implicitly converts a Half value to a <see cref="Source"/>.
        /// </summary>
        /// <param name="value">The Half value to convert.</param>
        /// <returns>A source representing the Half value.</returns>
        public static implicit operator Source(Half value)
        {
            return new(value);
        }

#endif

        /// <summary>
        /// Adds this source as a property to a complex value builder.
        /// </summary>
        /// <param name="utf8Name">The UTF-8 encoded property name.</param>
        /// <param name="valueBuilder">The complex value builder to add the property to.</param>
        /// <param name="escapeName">Whether to escape the property name.</param>
        /// <param name="nameRequiresUnescaping">Whether the property name requires unescaping.</param>
        /// <remarks>
        /// <para>
        /// This method implements type-specific dispatch based on the internal <see cref="Kind"/> value,
        /// routing each source type to the appropriate <see cref="ComplexValueBuilder"/> method:
        /// </para>
        /// <list type="bullet">
        /// <item><description><strong>Primitives:</strong> Direct calls to type-specific AddProperty overloads</description></item>
        /// <item><description><strong>Numeric Types:</strong> Formatted as JSON numbers using pre-computed UTF-8 bytes</description></item>
        /// <item><description><strong>String Types:</strong> Handled with appropriate escaping and encoding parameters</description></item>
        /// <item><description><strong>Complex Types:</strong> Delegates to builder instances for recursive construction</description></item>
        /// </list>
        /// <para>
        /// <strong>Escape Handling:</strong>
        /// </para>
        /// <list type="bullet">
        /// <item><description><c>escapeName</c>: Controls whether property names are JSON-escaped</description></item>
        /// <item><description><c>nameRequiresUnescaping</c>: Indicates pre-escaped property names</description></item>
        /// <item><description>String values have separate escape handling based on their source type</description></item>
        /// </list>
        /// <para>
        /// This method is typically called automatically during JSON object construction and
        /// forms part of the internal document building pipeline.
        /// </para>
        /// </remarks>
        public void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.Null:
                    valueBuilder.AddPropertyNull(utf8Name, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.True:
                    valueBuilder.AddProperty(utf8Name, true, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.False:
                    valueBuilder.AddProperty(utf8Name, false, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.NumericSimpleType:
                    valueBuilder.AddPropertyFormattedNumber(utf8Name, _simpleTypeBacking.Span(), escapeName, nameRequiresUnescaping);
                    break;

                case Kind.FormattedNumber:
                    valueBuilder.AddPropertyFormattedNumber(utf8Name, _utf8Backing, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.StringSimpleType:
                    valueBuilder.AddProperty(utf8Name, _simpleTypeBacking.Span(), escapeName, escapeValue: true, nameRequiresUnescaping, valueRequiresUnescaping: false);
                    break;

                case Kind.RawUtf8StringRequiresUnescaping:
                    valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: true);
                    break;

                case Kind.RawUtf8StringNotRequiresUnescaping:
                    valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: false);
                    break;

                case Kind.Utf8String:
                    valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: true, nameRequiresUnescaping, valueRequiresUnescaping: false);
                    break;

                case Kind.Utf16String:
                    valueBuilder.AddProperty(utf8Name, _utf16Backing, escapeName, nameRequiresUnescaping);
                    break;

                case Kind.JsonArrayBuilderInstance:
                    valueBuilder.AddProperty(utf8Name, _arrayBuilder!, static (b, ref o) => JsonArrayBuilder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);
                    break;

                case Kind.JsonObjectBuilderInstance:
                    valueBuilder.AddProperty(utf8Name, _objectBuilder!, static (b, ref o) => JsonObjectBuilder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);
                    break;

                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }

        /// <summary>
        /// Adds this source as a property to a complex value builder.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="valueBuilder">The complex value builder to add the property to.</param>
        public void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
        {
            AddAsProperty(name.AsSpan(), ref valueBuilder);
        }

        /// <summary>
        /// Adds this source as a property to a complex value builder.
        /// </summary>
        /// <param name="name">The property name as a character span.</param>
        /// <param name="valueBuilder">The complex value builder to add the property to.</param>
        public void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(name, _jsonElement);
                    break;

                case Kind.Null:
                    valueBuilder.AddPropertyNull(name);
                    break;

                case Kind.True:
                    valueBuilder.AddProperty(name, true);
                    break;

                case Kind.False:
                    valueBuilder.AddProperty(name, false);
                    break;

                case Kind.NumericSimpleType:
                    valueBuilder.AddPropertyFormattedNumber(name, _simpleTypeBacking.Span());
                    break;

                case Kind.FormattedNumber:
                    valueBuilder.AddPropertyFormattedNumber(name, _utf8Backing);
                    break;

                case Kind.StringSimpleType:
                    valueBuilder.AddProperty(name, _simpleTypeBacking.Span(), escapeValue: true, valueRequiresUnescaping: false);
                    break;

                case Kind.RawUtf8StringRequiresUnescaping:
                    valueBuilder.AddProperty(name, _utf8Backing, escapeValue: false, valueRequiresUnescaping: true);
                    break;

                case Kind.RawUtf8StringNotRequiresUnescaping:
                    valueBuilder.AddProperty(name, _utf8Backing, escapeValue: false, valueRequiresUnescaping: false);
                    break;

                case Kind.Utf8String:
                    valueBuilder.AddProperty(name, _utf8Backing, escapeValue: true, valueRequiresUnescaping: false);
                    break;

                case Kind.Utf16String:
                    valueBuilder.AddProperty(name, _utf16Backing);
                    break;

                case Kind.JsonArrayBuilderInstance:
                    valueBuilder.AddProperty(name, _arrayBuilder!, static (b, ref o) => JsonArrayBuilder.BuildValue(b, ref o));
                    break;

                case Kind.JsonObjectBuilderInstance:
                    valueBuilder.AddProperty(name, _objectBuilder!, static (b, ref o) => JsonObjectBuilder.BuildValue(b, ref o));
                    break;

                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }

        /// <summary>
        /// Adds this source as an item to a complex value builder.
        /// </summary>
        /// <param name="valueBuilder">The complex value builder to add the item to.</param>
        /// <remarks>
        /// <para>
        /// This method implements type-specific dispatch based on the internal <see cref="Kind"/> value,
        /// routing each source type to the appropriate <see cref="ComplexValueBuilder"/> method for array items:
        /// </para>
        /// <list type="bullet">
        /// <item><description><strong>Primitives:</strong> Direct calls to type-specific AddItem overloads</description></item>
        /// <item><description><strong>Numeric Types:</strong> Formatted as JSON numbers using pre-computed UTF-8 bytes</description></item>
        /// <item><description><strong>String Types:</strong> Handled with appropriate escaping parameters</description></item>
        /// <item><description><strong>Complex Types:</strong> Delegates to builder instances for recursive construction</description></item>
        /// </list>
        /// <para>
        /// Unlike <see cref="AddAsProperty"/>, this method does not handle property name escaping
        /// since array items do not have names. String values are processed with their appropriate
        /// escape handling based on the source type.
        /// </para>
        /// <para>
        /// This method is typically called automatically during JSON array construction and
        /// forms part of the internal document building pipeline.
        /// </para>
        /// </remarks>
        public void AddAsItem(ref ComplexValueBuilder valueBuilder)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddItem(_jsonElement);
                    break;

                case Kind.Null:
                    valueBuilder.AddItemNull();
                    break;

                case Kind.True:
                    valueBuilder.AddItem(true);
                    break;

                case Kind.False:
                    valueBuilder.AddItem(false);
                    break;

                case Kind.NumericSimpleType:
                    valueBuilder.AddItemFormattedNumber(_simpleTypeBacking.Span());
                    break;

                case Kind.FormattedNumber:
                    valueBuilder.AddItemFormattedNumber(_utf8Backing);
                    break;

                case Kind.StringSimpleType:
                    valueBuilder.AddItem(_simpleTypeBacking.Span());
                    break;

                case Kind.RawUtf8StringRequiresUnescaping:
                    valueBuilder.AddItem(_utf8Backing, escapeValue: false, requiresUnescaping: true);
                    break;

                case Kind.RawUtf8StringNotRequiresUnescaping:
                    valueBuilder.AddItem(_utf8Backing, escapeValue: false, requiresUnescaping: false);
                    break;

                case Kind.Utf8String:
                    valueBuilder.AddItem(_utf8Backing, escapeValue: true, requiresUnescaping: false);
                    break;

                case Kind.Utf16String:
                    valueBuilder.AddItem(_utf16Backing);
                    break;

                case Kind.JsonArrayBuilderInstance:
                    valueBuilder.AddItem(_arrayBuilder!, static (b, ref o) => JsonArrayBuilder.BuildValue(b, ref o));
                    break;

                case Kind.JsonObjectBuilderInstance:
                    valueBuilder.AddItem(_objectBuilder!, static (b, ref o) => JsonObjectBuilder.BuildValue(b, ref o));
                    break;

                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }
    }

    /// <summary>
    /// Creates a JSON document builder from a source value.
    /// </summary>
    /// <param name="workspace">The JSON workspace to use for the document builder.</param>
    /// <param name="source">The source value to build the document from.</param>
    /// <param name="estimatedMemberCount">The estimated number of members in the document.</param>
    /// <returns>A JSON document builder containing the source value.</returns>
    /// <remarks>
    /// <para>
    /// This method represents the primary integration point between <see cref="Source"/> values
    /// and the <see cref="JsonDocumentBuilder{T}"/> infrastructure. It creates a complete
    /// mutable JSON document from any compatible .NET value.
    /// </para>
    /// <para>
    /// <strong>Construction Process:</strong>
    /// </para>
    /// <list type="number">
    /// <item><description>Creates a new <see cref="JsonDocumentBuilder{Mutable}"/> from the workspace</description></item>
    /// <item><description>Initializes a <see cref="ComplexValueBuilder"/> with the estimated capacity</description></item>
    /// <item><description>Calls <see cref="Source.AddAsItem"/> to convert the source into the document structure</description></item>
    /// <item><description>Finalizes the document and transfers ownership to the returned builder</description></item>
    /// </list>
    /// <para>
    /// <strong>Memory Management:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description>Uses workspace-managed memory pools for efficient allocation</description></item>
    /// <item><description>EstimatedMemberCount pre-sizes internal data structures to minimize reallocations</description></item>
    /// <item><description>Returns a disposable document builder that manages resource cleanup</description></item>
    /// </list>
    /// <para>
    /// <strong>Performance Best Practices:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description><strong>Capacity Estimation:</strong> Provide accurate <c>estimatedMemberCount</c> to minimize internal reallocations</description></item>
    /// <item><description><strong>String Handling:</strong> Use UTF-8 spans when possible to avoid encoding overhead</description></item>
    /// <item><description><strong>Nested Structures:</strong> Consider flattening deeply nested objects for better performance</description></item>
    /// <item><description><strong>Workspace Reuse:</strong> Reuse <see cref="JsonWorkspace"/> instances across multiple document creations</description></item>
    /// </list>
    /// <para>
    /// <strong>Memory Allocation Patterns:</strong>
    /// </para>
    /// <list type="bullet">
    /// <item><description><strong>Stack Allocation:</strong> Source and ComplexValueBuilder are ref structs with stack-only allocation</description></item>
    /// <item><description><strong>Pooled Memory:</strong> Document storage uses workspace-managed memory pools</description></item>
    /// <item><description><strong>Zero-Copy Scenarios:</strong> String and span data often referenced without copying</description></item>
    /// </list>
    /// <para>
    /// <strong>Usage Examples:</strong>
    /// </para>
    /// <code>
    /// // Simple value
    /// using var doc = JsonElement.CreateDocumentBuilder(workspace, 42);
    ///
    /// // Complex object
    /// using var doc = JsonElement.CreateDocumentBuilder(workspace,
    ///     new(objectBuilder => { /* build object */ }));
    ///
    /// // From existing JsonElement
    /// using var doc = JsonElement.CreateDocumentBuilder(workspace, existingElement);
    /// </code>
    /// </remarks>
    /// <remarks>This method is not CLS compliant.</remarks>
    [CLSCompliant(false)]
    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in Source source, int estimatedMemberCount = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, estimatedMemberCount);
        source.AddAsItem(ref cvb);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
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
        private readonly JsonTokenType TokenType
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
        public readonly JsonValueKind ValueKind => TokenType.ToValueKind();

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
        public readonly Mutable this[int index]
        {
            get
            {
                CheckValidInstance();

                return _parent.GetArrayIndexElement(_idx, index);
            }
        }

        /// <summary>
        /// Implicitly converts a <see cref="Mutable"/> to a <see cref="JsonElement"/>.
        /// </summary>
        /// <param name="value">The mutable JSON element to convert.</param>
        /// <returns>A <see cref="JsonElement"/> representing the same JSON value.</returns>
        public static implicit operator JsonElement(Mutable value)
        {
            return new(value._parent, value._idx);
        }

        /// <summary>
        /// Explicitly converts a <see cref="JsonElement"/> to a <see cref="Mutable"/>.
        /// </summary>
        /// <param name="value">The JSON element to convert.</param>
        /// <returns>A <see cref="Mutable"/> representing the same JSON value.</returns>
        /// <exception cref="FormatException">
        /// The JSON element is not from a mutable JSON document.
        /// </exception>
        public static explicit operator Mutable(JsonElement value)
        {
            if (value._parent is not IMutableJsonDocument)
            {
                ThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(value._parent, value._idx);
        }

        /// <summary>
        /// Determines whether two <see cref="Mutable"/> instances are equal.
        /// </summary>
        /// <param name="left">The first mutable JSON element to compare.</param>
        /// <param name="right">The second mutable JSON element to compare.</param>
        /// <returns>True if the instances are equal; otherwise, false.</returns>
        public static bool operator ==(Mutable left, Mutable right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two <see cref="Mutable"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first mutable JSON element to compare.</param>
        /// <param name="right">The second mutable JSON element to compare.</param>
        /// <returns>True if the instances are not equal; otherwise, false.</returns>
        public static bool operator !=(Mutable left, Mutable right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether a <see cref="Mutable"/> and a <see cref="JsonElement"/> are equal.
        /// </summary>
        /// <param name="left">The mutable JSON element to compare.</param>
        /// <param name="right">The JSON element to compare.</param>
        /// <returns>True if the instances are equal; otherwise, false.</returns>
        public static bool operator ==(Mutable left, JsonElement right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether a <see cref="Mutable"/> and a <see cref="JsonElement"/> are not equal.
        /// </summary>
        /// <param name="left">The mutable JSON element to compare.</param>
        /// <param name="right">The JSON element to compare.</param>
        /// <returns>True if the instances are not equal; otherwise, false.</returns>
        public static bool operator !=(Mutable left, JsonElement right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether this JSON element is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare with this JSON element.</param>
        /// <returns>True if the object is equal to this JSON element; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new JsonElement(other.ParentDocument, other.ParentDocumentIndex)))
                || (obj is null && this.IsNull());
        }

        /// <summary>
        /// Determines whether this JSON element is equal to another JSON element of type T.
        /// </summary>
        /// <typeparam name="T">The type of JSON element to compare with.</typeparam>
        /// <param name="other">The JSON element to compare with this instance.</param>
        /// <returns>True if the JSON elements are equal; otherwise, false.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals<T>(T other)
            where T : struct, IJsonElement
        {
            return JsonElementHelpers.DeepEquals(this, other);
        }

        /// <summary>
        /// Creates a JSON document builder from this mutable JSON element.
        /// </summary>
        /// <param name="workspace">The JSON workspace to use for the document builder.</param>
        /// <returns>A JSON document builder containing this mutable JSON element.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        public readonly JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
        {
            return workspace.CreateDocumentBuilder<Mutable, Mutable>(this);
        }

        /// <summary>
        /// Creates a mutable JSON element from another mutable JSON element instance.
        /// </summary>
        /// <typeparam name="T">The type of the source mutable JSON element.</typeparam>
        /// <param name="instance">The source mutable JSON element instance.</param>
        /// <returns>A new mutable JSON element representing the same JSON value.</returns>
        /// <remarks>This method is not CLS compliant.</remarks>
        [CLSCompliant(false)]
        public static Mutable From<T>(in T instance)
            where T : struct, IMutableJsonElement<T>
        {
            return new(instance.ParentDocument, instance.ParentDocumentIndex);
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
        public readonly int GetArrayLength()
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
        public readonly int GetPropertyCount()
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
        public readonly Mutable GetProperty(string propertyName)
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
        public readonly Mutable GetProperty(ReadOnlySpan<char> propertyName)
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
        public readonly Mutable GetProperty(ReadOnlySpan<byte> utf8PropertyName)
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
        public readonly bool TryGetProperty(string propertyName, out Mutable value)
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
        public readonly bool TryGetProperty(ReadOnlySpan<char> propertyName, out Mutable value)
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
        public readonly bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, out Mutable value)
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
        public readonly bool GetBoolean()
        {
            // CheckValidInstance is redundant.  Asking for the type will
            // return None, which then throws the same exception in the return statement.

            JsonTokenType type = TokenType;

#pragma warning disable IDE0075 // Simplify conditional expression
            return
                type == JsonTokenType.True ? true :
                type == JsonTokenType.False ? false :
                ThrowJsonElementWrongTypeException(type);
#pragma warning restore IDE0075 // Simplify conditional expression

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
        public readonly string? GetString()
        {
            CheckValidInstance();

            return _parent.GetString(_idx, JsonTokenType.String);
        }

        /// <summary>
        /// Gets the value of the element as an unescaped UTF-8 JSON string.
        /// </summary>
        /// <returns>The value of the element as an unescaped UTF-8 JSON string.</returns>
        /// <exception cref="InvalidOperationException">
        /// This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly UnescapedUtf8JsonString GetUtf8String()
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
        public readonly bool TryGetBytesFromBase64([NotNullWhen(true)] out byte[]? value)
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
        public readonly byte[] GetBytesFromBase64()
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
        public readonly bool TryGetSByte(out sbyte value)
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
        public readonly sbyte GetSByte()
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
        public readonly bool TryGetByte(out byte value)
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
        public readonly byte GetByte()
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
        public readonly bool TryGetInt16(out short value)
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
        public readonly short GetInt16()
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
        public readonly bool TryGetUInt16(out ushort value)
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
        public readonly ushort GetUInt16()
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
        public readonly bool TryGetInt32(out int value)
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
        public readonly int GetInt32()
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
        public readonly bool TryGetUInt32(out uint value)
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
        public readonly uint GetUInt32()
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
        public readonly bool TryGetInt64(out long value)
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
        public readonly long GetInt64()
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
        public readonly bool TryGetUInt64(out ulong value)
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
        public readonly ulong GetUInt64()
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
        public readonly bool TryGetDouble(out double value)
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
        public readonly double GetDouble()
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
        public readonly bool TryGetSingle(out float value)
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
        public readonly float GetSingle()
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
        public readonly bool TryGetDecimal(out decimal value)
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
        public readonly decimal GetDecimal()
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
        public readonly bool TryGetInt128(out Int128 value)
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
        public readonly Int128 GetInt128()
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
        public readonly bool TryGetUInt128(out UInt128 value)
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
        public readonly UInt128 GetUInt128()
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
        public readonly bool TryGetHalf(out Half value)
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
        public readonly Half GetHalf()
        {
            if (!TryGetHalf(out Half value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

#endif

        /// <summary>
        ///   Attempts to represent the current JSON number as a <see cref="BigNumber"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not parse the contents of a JSON string value.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="BigNumber"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        /// <seealso cref="GetRawText"/>
        public readonly bool TryGetBigNumber(out BigNumber value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the current JSON number as a <see cref="BigNumber"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="BigNumber"/>.</returns>
        /// <remarks>
        ///   This method does not parse the contents of a JSON string value.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
        /// </exception>
        /// <exception cref="FormatException">
        ///   The value cannot be represented as a <see cref="BigNumber"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        /// <seealso cref="GetRawText"/>
        public readonly BigNumber GetBigNumber()
        {
            if (!TryGetBigNumber(out BigNumber value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON number as a <see cref="BigInteger"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not parse the contents of a JSON string value.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the number can be represented as a <see cref="BigInteger"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        /// <seealso cref="GetRawText"/>
        public readonly bool TryGetBigInteger(out BigInteger value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the current JSON number as a <see cref="BigInteger"/>.
        /// </summary>
        /// <returns>The current JSON number as a <see cref="BigInteger"/>.</returns>
        /// <remarks>
        ///   This method does not parse the contents of a JSON string value.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.Number"/>.
        /// </exception>
        /// <exception cref="FormatException">
        ///   The value cannot be represented as a <see cref="BigInteger"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        /// <seealso cref="GetRawText"/>
        public readonly BigInteger GetBigInteger()
        {
            if (!TryGetBigInteger(out BigInteger value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON string as a <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not create a LocalDate representation of values other than JSON strings.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the string can be represented as a <see cref="LocalDate"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly bool TryGetLocalDate(out LocalDate value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the value of the element as a <see cref="LocalDate"/>.
        /// </summary>
        /// <remarks>
        ///   This method does not create a LocalDate representation of values other than JSON strings.
        /// </remarks>
        /// <returns>The value of the element as a <see cref="LocalDate"/>.</returns>
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
        public readonly LocalDate GetLocalDate()
        {
            if (!TryGetLocalDate(out LocalDate value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON string as a <see cref="OffsetTime"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not create a OffsetTime representation of values other than JSON strings.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the string can be represented as a <see cref="OffsetTime"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly bool TryGetOffsetTime(out OffsetTime value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the value of the element as a <see cref="OffsetTime"/>.
        /// </summary>
        /// <remarks>
        ///   This method does not create a OffsetTime representation of values other than JSON strings.
        /// </remarks>
        /// <returns>The value of the element as a <see cref="OffsetTime"/>.</returns>
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
        public readonly OffsetTime GetOffsetTime()
        {
            if (!TryGetOffsetTime(out OffsetTime value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON string as a <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not create a OffsetDateTime representation of values other than JSON strings.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the string can be represented as a <see cref="OffsetDateTime"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly bool TryGetOffsetDateTime(out OffsetDateTime value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the value of the element as a <see cref="OffsetDateTime"/>.
        /// </summary>
        /// <remarks>
        ///   This method does not create a OffsetDateTime representation of values other than JSON strings.
        /// </remarks>
        /// <returns>The value of the element as a <see cref="OffsetDateTime"/>.</returns>
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
        public readonly OffsetDateTime GetOffsetDateTime()
        {
            if (!TryGetOffsetDateTime(out OffsetDateTime value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON string as a <see cref="OffsetDate"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not create a OffsetDate representation of values other than JSON strings.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the string can be represented as a <see cref="OffsetDate"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly bool TryGetOffsetDate(out OffsetDate value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the value of the element as a <see cref="OffsetDate"/>.
        /// </summary>
        /// <remarks>
        ///   This method does not create a OffsetDate representation of values other than JSON strings.
        /// </remarks>
        /// <returns>The value of the element as a <see cref="OffsetDate"/>.</returns>
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
        public readonly OffsetDate GetOffsetDate()
        {
            if (!TryGetOffsetDate(out OffsetDate value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        /// <summary>
        ///   Attempts to represent the current JSON string as a <see cref="Period"/>.
        /// </summary>
        /// <param name="value">Receives the value.</param>
        /// <remarks>
        ///   This method does not create a Period representation of values other than JSON strings.
        /// </remarks>
        /// <returns>
        ///   <see langword="true"/> if the string can be represented as a <see cref="Period"/>,
        ///   <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   This value's <see cref="ValueKind"/> is not <see cref="JsonValueKind.String"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public readonly bool TryGetPeriod(out Period value)
        {
            CheckValidInstance();

            return _parent.TryGetValue(_idx, out value);
        }

        /// <summary>
        ///   Gets the value of the element as a <see cref="Period"/>.
        /// </summary>
        /// <remarks>
        ///   This method does not create a Period representation of values other than JSON strings.
        /// </remarks>
        /// <returns>The value of the element as a <see cref="Period"/>.</returns>
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
        public readonly Period GetPeriod()
        {
            if (!TryGetPeriod(out Period value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

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
        public readonly bool TryGetDateTime(out DateTime value)
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
        public readonly DateTime GetDateTime()
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
        public readonly bool TryGetDateTimeOffset(out DateTimeOffset value)
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
        public readonly DateTimeOffset GetDateTimeOffset()
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
        public readonly bool TryGetGuid(out Guid value)
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
        public readonly Guid GetGuid()
        {
            if (!TryGetGuid(out Guid value))
            {
                ThrowHelper.ThrowFormatException();
            }

            return value;
        }

        internal readonly string GetPropertyName()
        {
            CheckValidInstance();

            return _parent.GetNameOfPropertyValue(_idx);
        }

        internal readonly ReadOnlySpan<byte> GetPropertyNameRaw()
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
        public readonly string GetRawText()
        {
            CheckValidInstance();

            return _parent.GetRawValueAsString(_idx);
        }

        internal readonly RawUtf8JsonString GetRawValue()
        {
            CheckValidInstance();

            return _parent.GetRawValue(_idx, includeQuotes: true);
        }

        internal readonly string GetPropertyRawText()
        {
            CheckValidInstance();

            return _parent.GetPropertyRawValueAsString(_idx);
        }

        internal readonly bool ValueIsEscaped
        {
            get
            {
                CheckValidInstance();

                return _parent.ValueIsEscaped(_idx, isPropertyName: false);
            }
        }

        internal readonly ReadOnlySpan<byte> ValueSpan
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
        public readonly bool ValueEquals(string? text)
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
        public readonly bool ValueEquals(ReadOnlySpan<byte> utf8Text)
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
        public readonly bool ValueEquals(ReadOnlySpan<char> text)
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

        internal readonly bool TextEqualsHelper(ReadOnlySpan<byte> utf8Text, bool isPropertyName, bool shouldUnescape)
        {
            CheckValidInstance();

            return _parent.TextEquals(_idx, utf8Text, isPropertyName, shouldUnescape);
        }

        internal readonly bool TextEqualsHelper(ReadOnlySpan<char> text, bool isPropertyName)
        {
            CheckValidInstance();

            return _parent.TextEquals(_idx, text, isPropertyName);
        }

        internal readonly bool ValueIsEscapedHelper(bool isPropertyName)
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
        public readonly void WriteTo(Utf8JsonWriter writer)
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
        public readonly ArrayEnumerator<Mutable> EnumerateArray()
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
        public readonly ObjectEnumerator<Mutable> EnumerateObject()
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
        public override readonly string ToString()
        {
            if (_parent == null || _documentVersion != _parent.Version)
            {
                return string.Empty;
            }

            return _parent.ToString(_idx);
        }

        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            if (_parent is null)
            {
                return 0;
            }

            return _parent.GetHashCode(_idx);
        }

        /// <summary>
        ///   Get a JsonElement which can be safely stored beyond the lifetime of the
        ///   original <see cref="IMutableJsonDocument"/>.
        /// </summary>
        /// <returns>
        ///   A JsonElement which can be safely stored beyond the lifetime of the
        ///   original <see cref="IMutableJsonDocument"/>.
        /// </returns>
        public readonly JsonElement Clone()
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
        public void SetProperty(string propertyName, in DateTime value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<char> propertyName, in DateTime value)
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

        public void SetProperty(ReadOnlySpan<byte> propertyName, in DateTime value)
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
        public void SetProperty(string propertyName, in DateTimeOffset value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<char> propertyName, in DateTimeOffset value)
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

        public void SetProperty(ReadOnlySpan<byte> propertyName, in DateTimeOffset value)
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
        public void SetProperty(string propertyName, in OffsetDateTime value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<byte> propertyName, in OffsetDateTime value)
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

        public void SetProperty(ReadOnlySpan<char> propertyName, in OffsetDateTime value)
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
        public void SetProperty(string propertyName, in OffsetDate value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<byte> propertyName, in OffsetDate value)
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

        public void SetProperty(ReadOnlySpan<char> propertyName, in OffsetDate value)
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
        public void SetProperty(string propertyName, in OffsetTime value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<byte> propertyName, in OffsetTime value)
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

        public void SetProperty(ReadOnlySpan<char> propertyName, in OffsetTime value)
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
        public void SetProperty(string propertyName, in LocalDate value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<byte> propertyName, in LocalDate value)
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

        public void SetProperty(ReadOnlySpan<char> propertyName, in LocalDate value)
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
        public void SetProperty(string propertyName, in Period value)
        {
            SetProperty(propertyName.AsSpan(), value);
        }

        public void SetProperty(ReadOnlySpan<byte> propertyName, in Period value)
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

        public void SetProperty(ReadOnlySpan<char> propertyName, in Period value)
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

        public void SetItem(int itemIndex, in DateTime value)
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

        public void SetItem(int itemIndex, in DateTimeOffset value)
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

        public void SetItem(int itemIndex, in OffsetDateTime value)
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

        public void SetItem(int itemIndex, in OffsetDate value)
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

        public void SetItem(int itemIndex, in OffsetTime value)
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

        public void SetItem(int itemIndex, in LocalDate value)
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

        public void SetItem(int itemIndex, in Period value)
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

        private readonly void CheckValidInstance()
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

        readonly void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET

        static Mutable IJsonElement<Mutable>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);

#endif

        /// <summary>
        /// Evaluates the schema against this JSON element.
        /// </summary>
        /// <param name="resultsCollector">The optional results collector for schema validation.</param>
        /// <returns>True if the schema evaluation passes; otherwise, false.</returns>
        public readonly bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null) => JsonSchema.Evaluate(_parent, _idx, resultsCollector);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string DebuggerDisplay => $"JsonElement.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonValueKind IJsonElement.ValueKind => ValueKind;
    }
}
