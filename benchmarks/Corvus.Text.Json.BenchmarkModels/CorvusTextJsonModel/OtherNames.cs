// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct OtherNames : IJsonElement<OtherNames>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal OtherNames(IJsonDocument parent, int idx)
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

    public static implicit operator OtherNames(in NameComponent value)
    {
        return From(value);
    }

    public static implicit operator OtherNames(in NameComponentArray value)
    {
        return From(value);
    }

    public static explicit operator NameComponent(in OtherNames value)
    {
        return new(value._parent, value._idx);
    }

    public static explicit operator NameComponentArray(in OtherNames value)
    {
        return new(value._parent, value._idx);
    }

    public static bool operator ==(OtherNames left, OtherNames right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OtherNames left, OtherNames right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(OtherNames left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OtherNames left, JsonElement right)
    {
        return !left.Equals(right);
    }


    public TResult Match<TResult>(Matcher<NameComponent, TResult> nameComponent, Matcher<NameComponentArray, TResult> nameComponentArray, Matcher<OtherNames, TResult> noMatch)
    {
        if (NameComponent.JsonSchema.Evaluate(_parent, _idx))
        {
            return nameComponent(NameComponent.From(this));
        }

        if (NameComponentArray.JsonSchema.Evaluate(_parent, _idx))
        {
            return nameComponentArray(NameComponentArray.From(this));
        }

        return noMatch(this);
    }

    public TResult Match<TContext, TResult>(in TContext context, Matcher<NameComponent, TContext, TResult> nameComponent, Matcher<NameComponentArray, TContext, TResult> nameComponentArray, Matcher<OtherNames, TContext, TResult> noMatch)
    {
        if (NameComponent.JsonSchema.Evaluate(_parent, _idx))
        {
            return nameComponent(NameComponent.From(this), context);
        }

        if (NameComponentArray.JsonSchema.Evaluate(_parent, _idx))
        {
            return nameComponentArray(NameComponentArray.From(this), context);
        }

        return noMatch(this, context);
    }

    public bool TryGetAsNameComponent(out NameComponent value)
    {
        if (NameComponent.JsonSchema.Evaluate(_parent, _idx))
        {
            value = NameComponent.From(this);
            return true;
        }

        value = default;
        return false;
    }

    public bool TryGetAsNameComponentArray(out NameComponentArray value)
    {
        if (NameComponentArray.JsonSchema.Evaluate(_parent, _idx))
        {
            value = NameComponentArray.From(this);
            return true;
        }

        value = default;
        return false;
    }

    public static OtherNames From<T>(in T instance)
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
        return workspace.CreateDocumentBuilder<OtherNames, Mutable>(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new OtherNames(other.ParentDocument, other.ParentDocumentIndex)))
            || (obj is null && this.IsNull());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals<T>(T other)
        where T : struct, IJsonElement
    {
        return JsonElementHelpers.DeepEquals(this, other);
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

    private void CheckValidInstance()
    {
        if (_parent == null)
        {
            throw new InvalidOperationException();
        }
    }

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static OtherNames IJsonElement<OtherNames>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"OtherNames: ValueKind = {ValueKind} : \"{ToString()}\"";

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

        public static explicit operator Mutable(OtherNames age)
        {
            if (age._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, age._idx);

        }

        public static implicit operator OtherNames(Mutable age)
        {
            return new(age._parent, age._idx);
        }

        public static implicit operator int(Mutable age)
        {
            age.CheckValidInstance();

            if (!age._parent.TryGetValue(age._idx, out int result))
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
            return left.Equals(right);
        }

        public static bool operator ==(Mutable left, JsonElement right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Mutable left, JsonElement right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new OtherNames(other.ParentDocument, other.ParentDocumentIndex)))
                || (obj is null && this.IsNull());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals<T>(T other)
            where T : struct, IJsonElement
        {
            return JsonElementHelpers.DeepEquals(this, other);
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
        private string DebuggerDisplay => $"OtherNames.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

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
            Unknown,
            JsonElement,
            StringSimpleType,
            RawUtf8StringRequiresUnescaping,
            RawUtf8StringNotRequiresUnescaping,
            Utf8String,
            Utf16String,
            NameComponentArray
        }

        private readonly Kind _kind;
        private readonly JsonElement _jsonElement;
        private readonly SimpleTypesBacking _simpleTypeBacking;
        private readonly ReadOnlySpan<byte> _utf8Backing;
        private readonly ReadOnlySpan<char> _utf16Backing;
        private readonly NameComponentArray.Builder.Build? NameComponentArrayBuilderInstance { get; }

        private Source(JsonElement jsonElement)
        {
            _jsonElement = jsonElement;
            _kind = Kind.JsonElement;
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

        private Source(ReadOnlySpan<byte> value, bool requiresUnescaping)
        {
            _utf8Backing = value;
            _kind = requiresUnescaping ? Kind.RawUtf8StringRequiresUnescaping : Kind.RawUtf8StringNotRequiresUnescaping;
        }

        public Source(NameComponentArray.Builder.Build value)
        {
            NameComponentArrayBuilderInstance = value;
            _kind = Kind.NameComponentArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(OtherNames instance) => new(JsonElement.From(instance));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(NameComponentArray instance) => new(JsonElement.From(instance));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(NameComponent instance) => new(JsonElement.From(instance));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(NameComponentArray.Builder.Build instance) => new(instance);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ReadOnlySpan<byte> value) => new(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(ReadOnlySpan<char> value) => new(value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Source(string value) => new(value.AsSpan());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Source RawString(ReadOnlySpan<byte> value, bool requiresUnescaping) => new(value, requiresUnescaping);

        public void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);
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
                case Kind.NameComponentArray:
                    valueBuilder.AddProperty(utf8Name, NameComponentArrayBuilderInstance!, static (b, ref o) => NameComponentArray.Builder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);
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
                case Kind.NameComponentArray:
                    valueBuilder.AddItem(NameComponentArrayBuilderInstance!, static (b, ref o) => NameComponentArray.Builder.BuildValue(b, ref o));
                    break;
                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }
    }

    public static class JsonSchema
    {
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/OtherNames"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider OneOf0SchemaEvaluationPath = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("oneOf/0/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider OneOf1SchemaEvaluationPath = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("oneOf/1/$ref"u8, buffer, out written);

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

            int oneOfMatchCount = 0;

            JsonSchemaContext oneOf0Context =
                NameComponent.JsonSchema.PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: OneOf0SchemaEvaluationPath);

            NameComponent.JsonSchema.Evaluate(parentDocument, parentIndex, ref oneOf0Context);

            if (oneOf0Context.IsMatch)
            {
                oneOfMatchCount++;
                context.ApplyEvaluated(ref oneOf0Context);
            }

            JsonSchemaContext oneOf1Context =
                NameComponentArray.JsonSchema.PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: OneOf1SchemaEvaluationPath);

            NameComponentArray.JsonSchema.Evaluate(parentDocument, parentIndex, ref oneOf1Context);

            if (oneOf1Context.IsMatch)
            {
                oneOfMatchCount++;
                context.ApplyEvaluated(ref oneOf1Context);
            }

            if (oneOfMatchCount == 1)
            {
                context.CommitChildContext(true, ref oneOf1Context);
                context.CommitChildContext(true, ref oneOf0Context);
                context.EvaluatedKeyword(true, null, "oneOf"u8);

            }
            else if (oneOfMatchCount > 1)
            {
                context.CommitChildContext(false, ref oneOf1Context);
                context.CommitChildContext(false, ref oneOf0Context);
                context.EvaluatedKeyword(false, JsonSchemaEvaluation.MatchedMoreThanOneSchema, "oneOf"u8);

                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }
            }
            else
            {
                context.CommitChildContext(false, ref oneOf1Context);
                context.CommitChildContext(false, ref oneOf0Context);
                context.EvaluatedKeyword(false, JsonSchemaEvaluation.MatchedNoSchema, "oneOf"u8);
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
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
                    providerContext: providerContext,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }
    }
}
