// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct Year : IJsonElement<Year>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal Year(IJsonDocument parent, int idx)
    {
        // parent is usually not null, but the Current property
        // on the enumerators (when initialized as `default`) can
        // get here with a null.
        Debug.Assert(idx >= 0);

        _parent = parent;
        _idx = idx;
    }

    /// <summary>
    ///   The <see cref="JsonValueKind"/> that the value is.
    /// </summary>
    /// <exception cref="ObjectDisposedException">
    ///   The parent <see cref="JsonDocument"/> has been disposed.
    /// </exception>
    public JsonValueKind ValueKind => TokenType.ToValueKind();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private JsonTokenType TokenType
    {
        get
        {
            return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
        }
    }

    public static implicit operator int(Year year)
    {
        year.CheckValidInstance();

        if (!year._parent.TryGetValue(year._idx, out int result))
        {
            CodeGenThrowHelper.ThrowFormatException(CodeGenNumericType.Int32);
        }

        return result;
    }

    public static bool operator ==(Year left, Year right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Year left, Year right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(Year left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Year left, JsonElement right)
    {
        return !left.Equals(right);
    }

    public static Year From<T>(in T instance)
    where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in Source source, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        source.AddAsItem(ref cvb);
        Debug.Assert(cvb.MemberCount == 1);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
    {
        return workspace.CreateDocumentBuilder<Year, Mutable>(this);
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
        ////ArgumentNullException.ThrowIfNull(writer);

        CheckValidInstance();

        _parent.WriteElementTo(_idx, writer);
    }

    /// <summary>
    ///   Gets a string representation for the current value appropriate to the value type.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     For JsonElement built from <see cref="JsonDocument"/>:
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
        if (_parent is null)
        {
            return string.Empty;
        }

        return _parent.ToString(_idx);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        if (_parent == null)
        {
            return 0;
        }

        return _parent.GetHashCode(_idx);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
    {
        return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new Year(other.ParentDocument, other.ParentDocumentIndex)))
            || (obj is null && this.IsNull());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals<T>(T other)
        where T : struct, IJsonElement
    {
        return JsonElementHelpers.DeepEquals(this, other);
    }

    private void CheckValidInstance()
    {
        if (_parent == null)
        {
            throw new InvalidOperationException();
        }
    }

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static Year IJsonElement<Year>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Year: ValueKind = {ValueKind} : \"{ToString()}\"";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IJsonDocument IJsonElement.ParentDocument => _parent;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    int IJsonElement.ParentDocumentIndex => _idx;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonTokenType IJsonElement.TokenType => TokenType;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonValueKind IJsonElement.ValueKind => ValueKind;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public readonly struct Mutable : IMutableJsonElement<Mutable>
    {
        private readonly IMutableJsonDocument _parent;
        private readonly int _idx;
        private readonly ulong _documentVersion;

        internal Mutable(IJsonDocument parent, int idx)
        {
            // parent is usually not null, but the Current property
            // on the enumerators (when initialized as `default`) can
            // get here with a null.
            Debug.Assert(idx >= 0);
            Debug.Assert(parent is IMutableJsonDocument);

            _parent = (IMutableJsonDocument)parent;
            _idx = idx;
            _documentVersion = _parent.Version;
        }

        /// <summary>
        ///   The <see cref="JsonValueKind"/> that the value is.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The parent <see cref="JsonDocument"/> has been disposed.
        /// </exception>
        public JsonValueKind ValueKind => TokenType.ToValueKind();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private JsonTokenType TokenType
        {
            get
            {
                return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
            }
        }

        public static explicit operator Mutable(Year year)
        {
            if (year._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, year._idx);

        }

        public static implicit operator Year(Mutable year)
        {
            return new(year._parent, year._idx);
        }

        public static implicit operator int(Mutable year)
        {
            year.CheckValidInstance();

            if (!year._parent.TryGetValue(year._idx, out int result))
            {
                CodeGenThrowHelper.ThrowFormatException(CodeGenNumericType.Int32);
            }

            return result;
        }

        public static implicit operator JsonElement(Mutable person)
        {
            return JsonElement.From(person);
        }

        public static bool operator ==(Mutable left, Mutable right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Mutable left, Mutable right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Mutable left, JsonElement right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Mutable left, JsonElement right)
        {
            return !left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
        }

        public static Mutable From<T>(in T instance)
        where T : struct, IMutableJsonElement<T>
        {
            return new(instance.ParentDocument, instance.ParentDocumentIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new Year(other.ParentDocument, other.ParentDocumentIndex)))
                || (obj is null && this.IsNull());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals<T>(T other)
            where T : struct, IJsonElement
        {
            return JsonElementHelpers.DeepEquals(this, other);
        }

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
            ////ArgumentNullException.ThrowIfNull(writer);

            CheckValidInstance();

            _parent.WriteElementTo(_idx, writer);
        }

        /// <summary>
        ///   Gets a string representation for the current value appropriate to the value type.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     For JsonElement built from <see cref="JsonDocument"/>:
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

            return _parent.ToString(_idx);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            if (_parent == null)
            {
                return 0;
            }

            return _parent.GetHashCode(_idx);
        }

#if NET
        static Mutable IJsonElement<Mutable>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => $"Year.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonValueKind IJsonElement.ValueKind => ValueKind;
    }

    public readonly ref struct Source
    {
        private enum Kind
        {
            JsonElement,
            NumericSimpleType,
            FormattedNumber,
        }

        private readonly Kind _kind;
        private readonly JsonElement _jsonElement;
        private readonly SimpleTypesBacking _simpleTypeBacking;
        private readonly ReadOnlySpan<byte> _utf8Backing;

        private Source(JsonElement jsonElement)
        {
            _jsonElement = jsonElement;
            _kind = Kind.JsonElement;
        }

        private Source(ReadOnlySpan<byte> value, Kind kind)
        {
            Debug.Assert(kind is Kind.FormattedNumber);

            _utf8Backing = value;
            _kind = kind;
        }

        private Source(int value)
        {
            SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written));
            _kind = Kind.NumericSimpleType;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(Year instance) => new(JsonElement.From(instance));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(int instance) => new(instance);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Source FormattedNumber(ReadOnlySpan<byte> value)
        {
            return new(value, Kind.FormattedNumber);
        }

        public void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);
                    break;
                case Kind.NumericSimpleType:
                    valueBuilder.AddPropertyFormattedNumber(utf8Name, _simpleTypeBacking.Span(), escapeName, nameRequiresUnescaping);
                    break;
                case Kind.FormattedNumber:
                    valueBuilder.AddPropertyFormattedNumber(utf8Name, _utf8Backing, escapeName, nameRequiresUnescaping);
                    break;
                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }

        public void AddAsItem(ref ComplexValueBuilder valueBuilder)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddItem(_jsonElement);
                    break;
                case Kind.NumericSimpleType:
                    valueBuilder.AddItemFormattedNumber(_simpleTypeBacking.Span());
                    break;
                case Kind.FormattedNumber:
                    valueBuilder.AddItemFormattedNumber(_utf8Backing);
                    break;
                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }
    }

    public static class JsonSchema
    {
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/Age"u8, buffer, out written);

        /// <summary>
        /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
        /// </summary>
        /// <param name="parentDocument">The parent document.</param>
        /// <param name="parentIndex">The parent index.</param>
        /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
        internal static void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
        {
            // You're not allowed to ask about non-value-like entities
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray);

            context.PushSchemaLocation(SchemaLocation);

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);

            /* Number matching
             * This would be if (tokenType != JsonTokenType.Number) for the non-matching case where we have numeric keywords
             * to match, but no explicit type check */
            if (!JsonSchemaEvaluation.MatchTypeNumber(tokenType, "type"u8, ref context))
            {
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                // Ignore remaining numerics
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeNumber, "format"u8);
            }
            else 
            {
                ReadOnlyMemory<byte> number = parentDocument.GetRawSimpleValue(parentIndex, false);
                JsonElementHelpers.ParseNumber(number.Span, out bool isNegative, out ReadOnlySpan<byte> integral, out ReadOnlySpan<byte> fractional, out int exponent);
                if (!JsonSchemaEvaluation.MatchInt32(isNegative, integral, fractional, exponent, "format"u8, ref context))
                {
                    if (!context.HasCollector)
                    {
                        context.PopSchemaLocation();
                        return;
                    }
                }
            }

            context.PopSchemaLocation();
        }

        internal static bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            JsonSchemaContext context = JsonSchemaContext.BeginContext(
                parentDocument,
                parentIndex,
                usingEvaluatedItems: false,
                usingEvaluatedProperties: false,
                resultsCollector: resultsCollector);

            try
            {
                Evaluate(parentDocument, parentIndex, ref context);
                return context.IsMatch;
            }
            finally
            {
                context.Dispose();
            }
        }

        internal static JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            ReadOnlySpan<byte> propertyName,
            JsonSchemaPathProvider? schemaEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    propertyName,
                    reducedEvaluationPath: schemaEvaluationPath);
        }

        internal static JsonSchemaContext PushChildContextUnescaped(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            ReadOnlySpan<byte> propertyName,
            JsonSchemaPathProvider? schemaEvaluationPath = null)
        {
            return
                context.PushChildContextUnescaped(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    propertyName,
                    reducedEvaluationPath: schemaEvaluationPath);
        }

        internal static JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            JsonSchemaPathProvider? schemaEvaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }

        internal static JsonSchemaContext PushChildContext<TContext>(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            TContext providerContext,
            JsonSchemaPathProvider<TContext>? schemaEvaluationPath = null,
            JsonSchemaPathProvider<TContext>? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath,
                    providerContext: providerContext);
        }

    }
}
