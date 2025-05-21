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

    public static implicit operator OtherNames(NameComponent nameComponent)
    {
        return From(nameComponent);
    }

    public static implicit operator OtherNames(NameComponentArray nameComponentArray)
    {
        return From(nameComponentArray);
    }

    public TResult Match<TResult>(Func<NameComponent, TResult> nameComponent, Func<NameComponentArray, TResult> nameComponentArray, Func<OtherNames, TResult> noMatch)
    {
        if (NameComponent.JsonSchema.IsMatch(_parent, _idx))
        {
            return nameComponent(NameComponent.From(this));
        }

        if (NameComponentArray.JsonSchema.IsMatch(_parent, _idx))
        {
            return nameComponentArray(NameComponentArray.From(this));
        }

        return noMatch(this);
    }

    public TResult Match<TContext, TResult>(TContext context, Func<TContext, NameComponent, TResult> nameComponent, Func<TContext, NameComponentArray, TResult> nameComponentArray, Func<TContext, OtherNames, TResult> noMatch)
    {
        if (NameComponent.JsonSchema.IsMatch(_parent, _idx))
        {
            return nameComponent(context, NameComponent.From(this));
        }

        if (NameComponentArray.JsonSchema.IsMatch(_parent, _idx))
        {
            return nameComponentArray(context, NameComponentArray.From(this));
        }

        return noMatch(context, this);
    }

    public static OtherNames From<T>(in T instance)
    where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 0, initialCapacity);
        cvb.AddItem(year);
        Debug.Assert(cvb.MemberCount == 1);
        documentBuilder.InsertAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
    {
        return workspace.CreateDocument<OtherNames, Mutable>(this);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSchemaMatch(IJsonSchemaResultsCollector? resultsCollector = null)
    {
        return JsonSchema.IsMatch(_parent, _idx, resultsCollector);
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
        private readonly IJsonDocument _parent;
        private readonly int _idx;

        internal Mutable(IJsonDocument parent, int idx)
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


    public ref struct Builder
    {
        public readonly ref struct Source
        {
            public JsonElement JsonElementInstance { get; }

            public ReadOnlySpan<byte> NameComponentSpan { get; }

            public NameComponentArray.Builder.Build? NameComponentArrayBuilder { get; }

            public Source(OtherNames instance)
            {
                JsonElementInstance = JsonElement.From(instance);
                NameComponentSpan = default;
                NameComponentArrayBuilder = default;
            }

            public Source(NameComponent instance)
            {
                JsonElementInstance = JsonElement.From(instance);
                NameComponentSpan = default;
                NameComponentArrayBuilder = default;
            }

            public Source(NameComponentArray instance)
            {
                JsonElementInstance = JsonElement.From(instance);
                NameComponentSpan = default;
                NameComponentArrayBuilder = default;
            }

            public Source(ReadOnlySpan<byte> instance)
            {
                JsonElementInstance = default;
                NameComponentSpan = instance;
                NameComponentArrayBuilder = default;
            }

            public Source(NameComponentArray.Builder.Build instance)
            {
                JsonElementInstance = default;
                NameComponentSpan = default;
                NameComponentArrayBuilder = instance;
            }

            public static implicit operator Source(OtherNames instance) => new(instance);
            public static implicit operator Source(NameComponentArray instance) => new(instance);
            public static implicit operator Source(NameComponent instance) => new(instance);
            public static implicit operator Source(ReadOnlySpan<byte> instance) => new(instance);
            public static implicit operator Source(NameComponentArray.Builder.Build instance) => new(instance);

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                // Where we might be one of multiple JsonElement types, we flatten into a single JsonElement value
                // in the source. Note that where we can be only *one* JsonElement type, we just use the instance
                // directly.
                // We can always check Undefined for instances, nullability for builders,
                // and use the individual values for primitives (you don't need separate primitives for each
                // instance of e.g. a string value - just the one true string value).
                if (JsonElementInstance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddItem(JsonElementInstance);
                }
                else if (NameComponentArrayBuilder is NameComponentArray.Builder.Build nameComponentArrayBuilder)
                {
                    NameComponentArray.Builder.Source source = new(nameComponentArrayBuilder);
                    source.AddAsItem(ref valueBuilder);
                }
                else
                {
                    valueBuilder.AddItem(NameComponentSpan);
                }
            }

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder)
            {

                if (JsonElementInstance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddProperty(utf8Name, JsonElementInstance);
                }
                else if (NameComponentArrayBuilder is NameComponentArray.Builder.Build nameComponentArrayBuilder)
                {
                    NameComponentArray.Builder.Source source = new(nameComponentArrayBuilder);
                    source.AddAsProperty(utf8Name, ref valueBuilder);
                }
                else
                {
                    valueBuilder.AddProperty(utf8Name, NameComponentSpan);
                }
            }
        }
    }

    public static class JsonSchema
    {
        public static ReadOnlySpan<byte> SchemaLocation() => "#/$defs/OtherNames"u8;

        private static ReadOnlySpan<byte> OneOf0Location() => "#/oneOf/0/$ref"u8;
        private static ReadOnlySpan<byte> OneOf1Location() => "#/oneOf/1/$ref"u8;
        private static ReadOnlySpan<byte> EscapedOneOfKeyword() => "oneOf"u8;
        private static ReadOnlySpan<byte> MatchedMoreThanOneSchema() => "Matched more than one schema."u8;
        private static ReadOnlySpan<byte> MatchedNoSchema() => "Matched no schema."u8;

        /// <summary>
        /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
        /// </summary>
        /// <param name="parentDocument">The parent document.</param>
        /// <param name="parentIndex">The parent index.</param>
        /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
        internal static void ApplyJsonSchema(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
        {
            // You're not allowed to ask about non-value-like entities
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray or
                JsonTokenType.PropertyName);

            context.PushSchemaLocation(SchemaLocation);

            int oneOfMatchCount = 0;

            JsonSchemaContext oneOf0Context =
                NameComponent.JsonSchema.PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: OneOf0Location);

            NameComponent.JsonSchema.ApplyJsonSchema(parentDocument, parentIndex, ref oneOf0Context);

            if (oneOf0Context.IsMatch)
            {
                oneOfMatchCount++;
                context.CommitChildContext(isMatch: true, ref oneOf0Context);
                context.ApplyEvaluated(ref oneOf0Context);
            }
            else
            {
                context.PopChildContext(ref oneOf0Context);
            }

            JsonSchemaContext oneOf1Context =
                NameComponentArray.JsonSchema.PushChildContext(parentDocument, parentIndex, ref context, schemaEvaluationPath: OneOf1Location);

            NameComponentArray.JsonSchema.ApplyJsonSchema(parentDocument, parentIndex, ref oneOf1Context);

            if (oneOf1Context.IsMatch)
            {
                oneOfMatchCount++;
                context.CommitChildContext(true, ref oneOf1Context);
                context.ApplyEvaluated(ref oneOf1Context);
            }
            else
            {
                context.PopChildContext(ref oneOf1Context);
            }

            if (oneOfMatchCount == 1)
            {
                context.Matched(true, schemaEvaluationPath: EscapedOneOfKeyword);
            }
            else if (oneOfMatchCount > 1)
            {
                context.Matched(false, MatchedMoreThanOneSchema, schemaEvaluationPath: EscapedOneOfKeyword);
            }
            else
            {
                context.Matched(false, MatchedNoSchema, schemaEvaluationPath: EscapedOneOfKeyword);
            }

            context.PopSchemaLocation();
        }

        internal static bool IsMatch(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            JsonSchemaContext context = JsonSchemaContext.BeginContext(
                parentDocument,
                parentIndex,
                usingEvaluatedProperties: false,
                usingEvaluatedItems: false,
                resultsCollector: resultsCollector);

            try
            {
                ApplyJsonSchema(parentDocument, parentIndex, ref context);
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
