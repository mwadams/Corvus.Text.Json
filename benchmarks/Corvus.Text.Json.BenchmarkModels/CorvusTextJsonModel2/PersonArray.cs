// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson2;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly partial struct PersonArray: IJsonElement<PersonArray>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    private PersonArray(IJsonDocument parent, int idx)
    {
        // parent is usually not null, but the Current property
        // on the enumerators (when initialized as `default`) can
        // get here with a null.
        Debug.Assert(idx >= 0);

        _parent = parent;
        _idx = idx;
    }

    public static bool operator ==(PersonArray left, PersonArray right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PersonArray left, PersonArray right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(PersonArray left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PersonArray left, JsonElement right)
    {
        return !left.Equals(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new PersonArray(other.ParentDocument, other.ParentDocumentIndex)))
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
    public Person this[int index]
    {
        get
        {
            CheckValidInstance();

            return _parent.GetArrayIndexElement<Person>(_idx, index);
        }
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
    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in Source value, int initialCapacity = 1)
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
        return workspace.CreateDocumentBuilder<PersonArray, Mutable>(this);
    }

    public static PersonArray From<T>(in T instance)
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
    static PersonArray IJsonElement<PersonArray>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
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

    public readonly ref struct Source
    {
        private enum Kind
        {
            Unknown,
            JsonElement,
            ArrayBuilder
        }

        private readonly Kind _kind;
        private readonly JsonElement _jsonElement;
        private readonly Builder.Build? _arrayBuilder;

        public Source(JsonElement instance)
        {
            _jsonElement = instance;
            _kind = Kind.JsonElement;
        }

        public Source(Builder.Build builder)
        {
            _arrayBuilder = builder;
            _kind = Kind.ArrayBuilder;
        }

        public static implicit operator Source(PersonArray instance) => new(JsonElement.From(instance));
        public static implicit operator Source(Builder.Build instance) => new(instance);

        internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);
                    break;
                case Kind.ArrayBuilder:
                    valueBuilder.AddProperty(utf8Name, _arrayBuilder!, static (context, ref o) => Builder.BuildValue(context, ref o), escapeName, nameRequiresUnescaping);
                    break;
                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }

        internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddItem(_jsonElement);
                    break;
                case Kind.ArrayBuilder:
                    valueBuilder.AddItem(_arrayBuilder!, static (context, ref o) => Builder.BuildValue(context, ref o));
                    break;
                default:
                    Debug.Fail("Unrecognized kind.");
                    break;
            }
        }
    }

    /// <summary>
    /// Builder for <see cref="PersonArray"/> instances.
    /// </summary>
    public ref struct Builder
    {
        private bool _addedPrefixItems = false;

        public delegate void Build(ref Builder builder);

        private ComplexValueBuilder _builder;

        internal Builder(ComplexValueBuilder builder) : this() => _builder = builder;

        internal static void BuildValue(Build value, ref ComplexValueBuilder o)
        {
            o.StartArray();
            Builder ovb = new(o);
            value(ref ovb);
            o = ovb._builder;
            o.EndArray();
        }

        public void CreateTuple(in PrefixItems0.Source value)
        {
            value.AddAsItem(ref _builder);
            _addedPrefixItems = true;
        }

        public void Add(in Person.Source value)
        {
            if (!_addedPrefixItems)
            {
                CodeGenThrowHelper.ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst();
            }

            value.AddAsItem(ref _builder);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private JsonTokenType TokenType
        {
            get
            {
                return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
            }
        }

        public static explicit operator Mutable(PersonArray otherNames)
        {
            if (otherNames._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, otherNames._idx);

        }

        public static implicit operator PersonArray(Mutable otherNames)
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
            return (obj is IJsonElement other && Equals(new PersonArray(other.ParentDocument, other.ParentDocumentIndex)))
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
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/PersonArray"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> SchemaLocationForUnevaluatedItems = static (_, buffer, out written) => JsonSchemaEvaluation.TryCopyPath("unevaluatedItems/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> PrefixItemsWithIndex = (index, buffer, out written) => JsonSchemaEvaluation.SchemaLocationForIndexedKeyword("prefixItems"u8, index, buffer, out written);
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
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeArray, "prefixItems"u8);
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeArray, "unevaluatedItems"u8);
            }
            else
            {
                ArrayEnumerator arrayEnumerator = new(parentDocument, parentIndex);
                int length = 0;

                while (arrayEnumerator.MoveNext())
                {
                    switch (length)
                    {
                        case 0:
                        {
                            JsonSchemaContext childContext = PersonArray.PrefixItems0.JsonSchema.PushChildContext(
                                parentDocument,
                                arrayEnumerator.CurrentIndex,
                                ref context,
                                providerContext: length,
                                schemaEvaluationPath: PrefixItemsWithIndex,
                                documentEvaluationPath: JsonSchemaEvaluation.ItemIndex);

                            PersonArray.PrefixItems0.JsonSchema.Evaluate(parentDocument, arrayEnumerator.CurrentIndex, ref childContext);
                            if (!childContext.IsMatch)
                            {
                                context.CommitChildContext(false, ref childContext);
                                if (!context.HasCollector)
                                {
                                    context.PopSchemaLocation();
                                    return;
                                }
                            }
                            else
                            {
                                context.CommitChildContext(true, ref childContext);
                                context.AddLocalEvaluatedItem(length);
                            }

                            length++;
                            break;
                        }

                        default:
                        {
                            JsonSchemaContext childContext = Person.JsonSchema.PushChildContext(
                                parentDocument,
                                arrayEnumerator.CurrentIndex,
                                ref context,
                                providerContext: length,
                                schemaEvaluationPath: SchemaLocationForUnevaluatedItems,
                                documentEvaluationPath: JsonSchemaEvaluation.ItemIndex);

                            Person.JsonSchema.Evaluate(parentDocument, arrayEnumerator.CurrentIndex, ref childContext);

                            if (!childContext.IsMatch)
                            {
                                context.CommitChildContext(false, ref childContext);
                                if (!context.HasCollector)
                                {
                                    context.PopSchemaLocation();
                                    return;
                                }
                            }
                            else
                            {
                                context.CommitChildContext(true, ref childContext);
                                context.AddLocalEvaluatedItem(length);
                            }

                            length++;
                            break;
                        }
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
                    useEvaluatedItems: true, // We do use evaluated items
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
                    useEvaluatedItems: true, // We do use evaluated items
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
                    useEvaluatedItems: true, // We do use evaluated items
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
                    useEvaluatedItems: true, // We do use evaluated items
                    useEvaluatedProperties: false,
                    providerContext: providerContext,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }
    }
}
