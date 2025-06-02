// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct CompetedInYears : IJsonElement<CompetedInYears>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal CompetedInYears(IJsonDocument parent, int idx)
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

    public static CompetedInYears From<T>(in T instance)
    where T : struct, IJsonElement<T>
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

    public JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
    {
        return workspace.CreateDocumentBuilder<CompetedInYears, Mutable>(this);
    }

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static CompetedInYears IJsonElement<CompetedInYears>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"CompetedInYears: ValueKind = {ValueKind} : \"{ToString()}\"";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IJsonDocument IJsonElement.ParentDocument => _parent;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    int IJsonElement.ParentDocumentIndex => _idx;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonTokenType IJsonElement.TokenType => TokenType;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonValueKind IJsonElement.ValueKind => ValueKind;

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, Builder.Build builder, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1, -1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        Builder.BuildValue(builder, ref cvb);
        Debug.Assert(cvb.MemberCount == 1);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
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
                return _parent.GetRawValueAsString(_idx);
            }
            case JsonTokenType.String:
                return _parent.GetString(_idx, JsonTokenType.String)!;
            case JsonTokenType.Comment:
            case JsonTokenType.EndArray:
            case JsonTokenType.EndObject:
            default:
                Debug.Fail($"No handler for {nameof(JsonTokenType)}.{TokenType}");
                return string.Empty;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSchemaMatch(IJsonSchemaResultsCollector? resultsCollector = null)
    {
        return JsonSchema.IsMatch(_parent, _idx, resultsCollector);
    }

    public ref struct Builder
    {
        public delegate void Build(ref Builder builder);

        public readonly ref struct Source
        {
            public Build? Builder { get; }

            public CompetedInYears Instance { get; }

            public Source(CompetedInYears instance)
            {
                Builder = null;
                Instance = instance;
            }

            public Source(Build builder)
            {
                Builder = builder;
                Instance = default;
            }

            public static implicit operator Source(CompetedInYears instance) => new(instance);

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
            {
                if (Builder is Build competedInYearsBuilder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref o) => BuildValue(competedInYearsBuilder, ref o), escapeName, nameRequiresUnescaping);
                }
                else
                {
                    valueBuilder.AddProperty(utf8Name, Instance, escapeName, nameRequiresUnescaping);
                }
            }

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build competedInYearsBuilder)
                {
                    valueBuilder.AddItem((ref o) => BuildValue(competedInYearsBuilder, ref o));
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddItem(Instance);
                }
            }
        }

        private ComplexValueBuilder _builder;

        internal Builder(ComplexValueBuilder builder) : this() => _builder = builder;

        internal static Builder Create(IMutableJsonDocument parentDocument, int targetIndex, int initialElementCount)
        {
            ComplexValueBuilder builder = ComplexValueBuilder.Create(parentDocument, initialElementCount);
            return new Builder(builder);
        }

        internal static void BuildValue(Build value, ref ComplexValueBuilder o)
        {
            o.StartArray();
            Builder ovb = new(o);
            value(ref ovb);
            o = ovb._builder;
            o.EndArray();
        }

        public void Add(Year.Builder.Source year)
        {
            year.AddAsItem(ref _builder);
        }
    }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSchemaMatch(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.IsMatch(_parent, _idx, resultsCollector);
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
                    return _parent.GetRawValueAsString(_idx);
                }
                case JsonTokenType.String:
                    return _parent.GetString(_idx, JsonTokenType.String)!;
                case JsonTokenType.Comment:
                case JsonTokenType.EndArray:
                case JsonTokenType.EndObject:
                default:
                    Debug.Fail($"No handler for {nameof(JsonTokenType)}.{TokenType}");
                    return string.Empty;
            }
        }

#if NET
        static Mutable IJsonElement<Mutable>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => $"CompetedInYears.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        JsonValueKind IJsonElement.ValueKind => ValueKind;
    }

    public static class JsonSchema
    {
        public static ReadOnlySpan<byte> SchemaLocation() => "#/$defs/CompetedInYears"u8;
        private static ReadOnlySpan<byte> ExpectedAnArrayValue() => "Expected an array value."u8;
        private static ReadOnlySpan<byte> IgnoredBecauseTheValueWasNotOfTypeArray() => "Ignored because the value was not of type 'array'."u8;
        private static ReadOnlySpan<byte> EscapedTypeKeyword() => "type"u8;
        private static ReadOnlySpan<byte> EscapedItemsKeyword() => "items"u8;

        public static bool SchemaLocationForItemIndex(int index, Span<byte> buffer, out int written)
        {
            if (buffer.Length < 13)
            {
                written = 0;
                return false;
            }

            "#/items/$ref/"u8.CopyTo(buffer);
            if (!Utf8Formatter.TryFormat(index, buffer[13..], out int bytesWritten))
            {
                written = 0;
                return false;
            }

            written = bytesWritten + 13;
            return true;
        }

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

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);

            if (tokenType != JsonTokenType.StartArray)
            {
                context.Matched(false, ExpectedAnArrayValue, EscapedTypeKeyword);
                if (!context.HasCollector)
                {
                    return;
                }

                context.Ignored(IgnoredBecauseTheValueWasNotOfTypeArray, EscapedItemsKeyword);
                context.PopSchemaLocation();
                return;
            }

            ArrayEnumerator arrayEnumerator = new(parentDocument, parentIndex);
            int length = 0;

            while (arrayEnumerator.MoveNext())
            {
                JsonSchemaContext childContext = Year.JsonSchema.PushChildContext(
                    parentDocument,
                    arrayEnumerator.CurrentIndex,
                    ref context,
                    providerContext: length,
                    schemaEvaluationPath: SchemaLocationForItemIndex);

                Year.JsonSchema.ApplyJsonSchema(parentDocument, arrayEnumerator.CurrentIndex, ref childContext);
                if (!childContext.IsMatch)
                {
                    context.Matched(false);
                    if (!context.HasCollector)
                    {
                        return;
                    }
                }

                context.CommitChildContext(childContext.IsMatch, ref childContext);
                context.AddLocalEvaluatedItem(length);
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
