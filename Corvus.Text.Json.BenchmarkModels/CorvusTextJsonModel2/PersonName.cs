// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson2;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct PersonName : IJsonElement<PersonName>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal PersonName(IJsonDocument parent, int idx)
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

    public NameComponent FirstName
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.FirstName, out NameComponent value))
            {
                return value;
            }

            return default;
        }
    }

    public NameComponent LastName
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.LastName, out NameComponent value))
            {
                return value;
            }

            return default;
        }
    }

    public OtherNames OtherNames
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.FirstName, out OtherNames value))
            {
                return value;
            }

            return default;
        }
    }


    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private JsonTokenType TokenType
    {
        get
        {
            return _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;
        }
    }

    public static PersonName From<T>(in T instance)
    where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, NameComponent.Builder.Source firstName, NameComponent.Builder.Source lastName, OtherNames.Builder.Source otherNames, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.StartObject();
        Builder.Create(ref cvb, firstName, lastName, otherNames);
        cvb.EndObject();
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, Builder.Build builder, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        Builder.BuildValue(builder, ref cvb);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
    {
        return workspace.CreateDocument<PersonName, Mutable>(this);
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

    private void CheckValidInstance()
    {
        if (_parent == null)
        {
            throw new InvalidOperationException();
        }
    }

    void IJsonElement.CheckValidInstance() => CheckValidInstance();

#if NET
    static PersonName IJsonElement<PersonName>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"PersonName: ValueKind = {ValueKind} : \"{ToString()}\"";

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

        public NameComponent.Mutable FirstName
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.FirstName, out NameComponent.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public NameComponent.Mutable LastName
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.LastName, out NameComponent.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public OtherNames.Mutable OtherNames
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.FirstName, out OtherNames.Mutable value))
                {
                    return value;
                }

                return default;
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

        public static explicit operator Mutable(PersonName personName)
        {
            if (personName._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, personName._idx);

        }

        public static implicit operator PersonName(Mutable personName)
        {
            return new(personName._parent, personName._idx);
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
        private string DebuggerDisplay => $"PersonName.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

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
        public delegate void Build(ref Builder builder);

        public readonly ref struct Source
        {
            public Build? Builder { get; }

            public PersonName Instance { get; }

            public Source(PersonName instance)
            {
                Builder = null;
                Instance = instance;
            }

            public Source(Build builder)
            {
                Builder = builder;
                Instance = default;
            }

            public static implicit operator Source(PersonName instance) => new(instance);

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build nameBuilder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref o) => BuildValue(nameBuilder, ref o));
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddProperty(utf8Name, Instance);
                }
            }

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build nameBuilder)
                {
                    valueBuilder.AddItem((ref o) => BuildValue(nameBuilder, ref o));
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

        public void Create(NameComponent.Builder.Source firstName, NameComponent.Builder.Source lastName, OtherNames.Builder.Source otherNames)
        {
            Create(ref _builder, firstName, lastName, otherNames);
        }

        internal static void Create(ref ComplexValueBuilder builder, NameComponent.Builder.Source firstName, NameComponent.Builder.Source lastName, OtherNames.Builder.Source otherNames)
        {
            firstName.AddAsProperty(JsonPropertyNames.FirstName, ref builder);
            lastName.AddAsProperty(JsonPropertyNames.LastName, ref builder);
            otherNames.AddAsProperty(JsonPropertyNames.OtherNames, ref builder);
        }

        internal static void BuildValue(Build value, ref ComplexValueBuilder o)
        {
            o.StartObject();
            Builder ovb = new(o);
            value(ref ovb);
            o = ovb._builder;
            o.EndObject();
        }
    }

    public static class JsonPropertyNames
    {
        // These are the fully escaped property names
        public static ReadOnlySpan<byte> FirstName => "firstName"u8;
        public static ReadOnlySpan<byte> LastName => "lastName"u8;
        public static ReadOnlySpan<byte> OtherNames => "otherNames"u8;
    }

    public static class JsonSchema
    {
        private const int FirstNameRequiredOffset = 0;
        private const int FirstNameRequiredBitMask = 0b0000_0000_0000_0001;
        private const int BitMaskOffset0 = FirstNameRequiredBitMask;

        private static ReadOnlySpan<byte> SchemaLocation() => "#/$defs/PersonName"u8;
        private static ReadOnlySpan<byte> Required0Location() => "#/required/0"u8;

        private static ReadOnlySpan<byte> ExpectedAnObjectValue() => "Expected an object value."u8;
        private static ReadOnlySpan<byte> RequiredPropertyFirstNameNotPresent() => "The required property 'firstName' was not present."u8;
        private static ReadOnlySpan<byte> RequiredPropertyFirstNamePresent() => "The required property 'firstName' was present."u8;
        private static ReadOnlySpan<byte> IgnoredBecauseTheValueWasNotOfTypeObject() => "Ignored because the value was not of type 'object'."u8;
        private static ReadOnlySpan<byte> EscapedTypeKeyword() => "type"u8;
        private static ReadOnlySpan<byte> EscapedPropertiesKeyword() => "properties"u8;
        private static ReadOnlySpan<byte> EscapedRequiredKeyword() => "required"u8;
        private static ReadOnlySpan<byte> EscapedFirstNameSchemaEvaluationPath() => "#/properties/firstName/$ref"u8;
        private static ReadOnlySpan<byte> EscapedFirstNameDocumentEvaluationPath() => "#/firstName"u8;
        private static ReadOnlySpan<byte> EscapedLastNameSchemaEvaluationPath() => "#/properties/lastName/$ref"u8;
        private static ReadOnlySpan<byte> EscapedLastNameDocumentEvaluationPath() => "#/lastName"u8;
        private static ReadOnlySpan<byte> EscapedOtherNamesSchemaEvaluationPath() => "#/properties/otherNames/$ref"u8;
        private static ReadOnlySpan<byte> EscapedOtherNamesDocumentEvaluationPath() => "#/otherNames"u8;

        /// <summary>
        /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
        /// </summary>
        /// <param name="parentDocument">The parent document.</param>
        /// <param name="parentIndex">The parent index.</param>
        /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
        internal static void ApplyJsonSchema(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
        {
            // You're not allowed to ask about non-value-like tokens
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray or
                JsonTokenType.PropertyName);

            context.PushSchemaLocation(SchemaLocation);

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);

            if (tokenType != JsonTokenType.StartObject)
            {
                context.Matched(false, ExpectedAnObjectValue, EscapedTypeKeyword);
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                context.Ignored(IgnoredBecauseTheValueWasNotOfTypeObject, EscapedPropertiesKeyword);
                context.Ignored(IgnoredBecauseTheValueWasNotOfTypeObject, EscapedRequiredKeyword);
                context.PopSchemaLocation();
                return;
            }

            Span<int> seenItems = stackalloc int[1];

            int propertyCount = 0;

            var enumerator = new ObjectEnumerator(parentDocument, parentIndex);
            while (enumerator.MoveNext())
            {
                int currentIndex = enumerator.CurrentIndex;
                ReadOnlySpan<byte> propertyName = parentDocument.GetPropertyNameRaw(currentIndex);

                if (TryGetValidator(propertyName, out JsonSchemaMatcherWithRequiredBitBuffer? matcher))
                {
                    context.AddLocalEvaluatedProperty(propertyCount);
                    matcher(parentDocument, currentIndex, ref context, seenItems);

                    if (!context.IsMatch && !context.HasCollector)
                    {
                        return;
                    }
                }

                propertyCount++;
            }

            // Do a quick test to see if we have all of the required bits set in each element
            if ((seenItems[0] ^ BitMaskOffset0) == 0)
            {
                if (context.HasCollector)
                {
                    // Add a "matched" for each of the individual matched properties
                    context.Matched(true, RequiredPropertyFirstNameNotPresent, Required0Location);
                }

                return;
            }

            // Sadly we don't, so we have to do the slow path
            if (!context.HasCollector)
            {
                // Which we can cut short if we are not doing collections
                context.Matched(false);
                return;
            }
            else
            {
                // We have missed at least one of the required properties
                // and we are doing collections, so test them all individually
                if ((seenItems[FirstNameRequiredOffset] & FirstNameRequiredBitMask) == 0)
                {
                    context.Matched(false, RequiredPropertyFirstNameNotPresent, Required0Location);
                    if (!context.HasCollector)
                    {
                        return;
                    }
                }
                else
                {
                    context.Matched(true, RequiredPropertyFirstNamePresent, Required0Location);
                }
            }

            context.PopSchemaLocation();
        }

        private static bool TryGetValidator(ReadOnlySpan<byte> span, [NotNullWhen(true)] out JsonSchemaMatcherWithRequiredBitBuffer? validator)
        {
            // We only have 1 property, so it is going to be vastly more efficient to do this
            // with property names
            if (JsonPropertyNames.FirstName.SequenceEqual(span))
            {
                validator = MatchFirstName;
                return true;
            }
            else if (JsonPropertyNames.LastName.SequenceEqual(span))
            {
                validator = MatchLastName;
                return true;
            }
            else if (JsonPropertyNames.OtherNames.SequenceEqual(span))
            {
                validator = MatchOtherNames;
                return true;
            }

            validator = default;
            return false;
        }

        private static void MatchFirstName(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                NameComponent.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedFirstNameSchemaEvaluationPath,
                    documentEvaluationPath: EscapedFirstNameDocumentEvaluationPath);

            NameComponent.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);
            context.CommitChildContext(childContext.IsMatch, ref childContext);
            requiredBitBuffer[FirstNameRequiredOffset] |= FirstNameRequiredBitMask;
        }

        private static void MatchLastName(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                NameComponent.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedLastNameSchemaEvaluationPath,
                    documentEvaluationPath: EscapedLastNameDocumentEvaluationPath);

            NameComponent.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
        }

        private static void MatchOtherNames(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                OtherNames.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedOtherNamesSchemaEvaluationPath,
                    documentEvaluationPath: EscapedOtherNamesDocumentEvaluationPath);

            OtherNames.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
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
