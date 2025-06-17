// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson2;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct NameComponentArray : IJsonElement<NameComponentArray>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    private NameComponentArray(IJsonDocument parent, int idx)
    {
        // parent is usually not null, but the Current property
        // on the enumerators (when initialized as `default`) can
        // get here with a null.
        Debug.Assert(idx >= 0);

        _parent = parent;
        _idx = idx;
    }

    public static bool operator ==(NameComponentArray left, NameComponentArray right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NameComponentArray left, NameComponentArray right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(NameComponentArray left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NameComponentArray left, JsonElement right)
    {
        return !left.Equals(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new NameComponentArray(other.ParentDocument, other.ParentDocumentIndex)))
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

    /// <summary>
    ///   Get the name component at a specified index.
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
    public NameComponent this[int index]
    {
        get
        {
            CheckValidInstance();

            return _parent.GetArrayIndexElement<NameComponent>(_idx, index);
        }
    }

    public int GetArrayLength()
    {
        CheckValidInstance();
        return _parent.GetArrayLength(_idx);
    }

    public ArrayEnumerator<NameComponent> GetArrayEnumerator()
    {
        CheckValidInstance();
        return EnumeratorCreator.CreateArrayEnumerator<NameComponent>(_parent, _idx);
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

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, Builder.Source value, int initialCapacity = 1)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        value.AddAsItem(ref cvb);
        Debug.Assert(cvb.MemberCount == 1);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
    {
        return workspace.CreateDocumentBuilder<NameComponentArray, Mutable>(this);
    }

    public static NameComponentArray From<T>(in T instance)
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

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static NameComponentArray IJsonElement<NameComponentArray>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
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

    public ref struct Builder
    {
        public delegate void Build(ref Builder builder);

        public readonly ref struct Source
        {
            public Build? Builder { get; }

            public NameComponentArray Instance { get; }

            public Source(NameComponentArray instance)
            {
                Builder = null;
                Instance = instance;
            }

            public Source(Build builder)
            {
                Builder = builder;
                Instance = default;
            }

            public static implicit operator Source(NameComponentArray instance) => new(instance);

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
            {
                if (Builder is Build builder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref o) => BuildValue(builder, ref o), escapeName, nameRequiresUnescaping);
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddProperty(utf8Name, Instance, escapeName, nameRequiresUnescaping);
                }
            }

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build builder)
                {
                    valueBuilder.AddItem((ref o) => BuildValue(builder, ref o));
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

        internal static Builder Create(IMutableJsonDocument parentDocument, int initialElementCount)
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

        public void Add(ReadOnlySpan<byte> name)
        {
            _builder.AddItem(name);
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
        ///   Get the name component at a specified index.
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
        public NameComponent.Mutable this[int index]
        {
            get
            {
                CheckValidInstance();

                return _parent.GetArrayIndexElement<NameComponent.Mutable>(_idx, index);
            }
        }

        public int GetArrayLength()
        {
            CheckValidInstance();
            return _parent.GetArrayLength(_idx);
        }

        public ArrayEnumerator<NameComponent.Mutable> GetArrayEnumerator()
        {
            CheckValidInstance();
            return EnumeratorCreator.CreateArrayEnumerator<NameComponent.Mutable>(_parent, _idx);
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

        public static explicit operator Mutable(NameComponentArray otherNames)
        {
            if (otherNames._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, otherNames._idx);

        }

        public static implicit operator NameComponentArray(Mutable otherNames)
        {
            return new(otherNames._parent, otherNames._idx);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new NameComponentArray(other.ParentDocument, other.ParentDocumentIndex)))
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

    public static class JsonSchema
    {
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/PersonNameElementArray"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> SchemaLocationForItems = static (_, buffer, out written) => JsonSchemaEvaluation.TryCopyPath("items/$ref"u8, buffer, out written);

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
                JsonTokenType.EndArray or
                JsonTokenType.PropertyName);

            context.PushSchemaLocation(SchemaLocation);

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);


            /* Array matching
             * This would be if (tokenType != JsonTokenType.StartArray) for the non-matching case where we have array keywords
             * to match, but no explicit type check */
            if (!JsonSchemaEvaluation.MatchTypeArray(tokenType, "type"u8, ref context))
            {
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                // Ignore remaining array
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeArray, "items"u8);
            }
            else
            {
                ArrayEnumerator arrayEnumerator = new(parentDocument, parentIndex);
                int length = 0;

                while (arrayEnumerator.MoveNext())
                {
                    JsonSchemaContext childContext = NameComponent.JsonSchema.PushChildContext(
                        parentDocument,
                        arrayEnumerator.CurrentIndex,
                        ref context,
                        providerContext: length,
                        schemaEvaluationPath: SchemaLocationForItems,
                        documentEvaluationPath: JsonSchemaEvaluation.ItemIndex);

                    NameComponent.JsonSchema.Evaluate(parentDocument, arrayEnumerator.CurrentIndex, ref childContext);
                    context.CommitChildContext(childContext.IsMatch, ref childContext);
                    if (!childContext.IsMatch && !context.HasCollector)
                    {
                        context.PopSchemaLocation();
                        return;
                    }

                    context.AddLocalEvaluatedItem(length);
                }
            }

            context.PopSchemaLocation();
        }

        internal static bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            JsonSchemaContext context = JsonSchemaContext.BeginContext(
                parentDocument,
                parentIndex,
                usingEvaluatedProperties: false,
                usingEvaluatedItems: false,
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
