// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson2;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct Person : IJsonElement<Person>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal Person(IJsonDocument parent, int idx)
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

    public PersonName Name
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Name, out PersonName value))
            {
                return value;
            }

            return default;
        }
    }

    public Age Age
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Age, out Age value))
            {
                return value;
            }

            return default;
        }
    }

    public CompetedInYears CompetedInYears
    {
        get
        {
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.CompetedInYears, out CompetedInYears value))
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

    public static Person From<T>(in T instance)
        where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
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

    public JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace)
    {
        return workspace.CreateDocument<Person, Mutable>(this);
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
    static Person IJsonElement<Person>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Person: ValueKind = {ValueKind} : \"{ToString()}\"";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IJsonDocument IJsonElement.ParentDocument => _parent;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    int IJsonElement.ParentDocumentIndex => _idx;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonTokenType IJsonElement.TokenType => TokenType;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    JsonValueKind IJsonElement.ValueKind => ValueKind;

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, in Age.Builder.Source age, in PersonName.Builder.Source name, in CompetedInYears.Builder.Source competedInYears, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.StartObject();
        Builder.Create(ref cvb, age, name, competedInYears);
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

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct Mutable : IMutableJsonElement<Mutable>
    {
        private readonly IMutableJsonDocument _parent;
        private readonly int _idx;
        private ulong _documentVersion;

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

        public PersonName.Mutable Name
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Name, out PersonName.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public Age.Mutable Age
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Age, out Age.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public CompetedInYears.Mutable CompetedInYears
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.CompetedInYears, out CompetedInYears.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public void SetName(in PersonName.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Name, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.Name, ref cvb, escapeName: false, nameRequiresUnescaping: false);
                int endIndex = _idx + _parent.GetDbSize(_idx, false);
                _parent.InsertAndDispose(_idx, endIndex, ref cvb);
            }

            _documentVersion = _parent.Version;
        }

        public void SetAge(in Age.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.Age, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.Age, ref cvb, escapeName: false, nameRequiresUnescaping: false);
                int endIndex = _idx + _parent.GetDbSize(_idx, false);
                _parent.InsertAndDispose(_idx, endIndex, ref cvb);
            }

            _documentVersion = _parent.Version;
        }

        public void SetCompetedInYears(in CompetedInYears.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.CompetedInYears, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.CompetedInYears, ref cvb, escapeName: false, nameRequiresUnescaping: false);
                int endIndex = _idx + _parent.GetDbSize(_idx, false);
                _parent.InsertAndDispose(_idx, endIndex, ref cvb);
            }

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


        public static explicit operator Mutable(Person person)
        {
            if (person._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, person._idx);

        }

        public static implicit operator Person(Mutable person)
        {
            return new(person._parent, person._idx);
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
        private string DebuggerDisplay => $"Person.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

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

            public Person Instance { get; }

            public Source(Person instance)
            {
                Builder = null;
                Instance = instance;
            }

            public Source(Build builder)
            {
                Builder = builder;
                Instance = default;
            }

            public static implicit operator Source(Person instance) => new(instance);

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
            {
                if (Builder is Build personBuilder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref o) => BuildValue(personBuilder, ref o), escapeName, nameRequiresUnescaping);
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddProperty(utf8Name, Instance, escapeName, nameRequiresUnescaping);
                }
            }

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build personBuilder)
                {
                    valueBuilder.AddItem((ref o) => BuildValue(personBuilder, ref o));
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
            o.StartObject();
            Builder ovb = new(o);
            value(ref ovb);
            o = ovb._builder;
            o.EndObject();
        }

        public void Create(in Age.Builder.Source age, in PersonName.Builder.Source name, in CompetedInYears.Builder.Source competedInYears)
        {
            Create(ref _builder, age, name, competedInYears);
        }

        internal static void Create(ref ComplexValueBuilder builder, in Age.Builder.Source age, in PersonName.Builder.Source name, in CompetedInYears.Builder.Source competedInYears)
        {
            age.AddAsProperty(JsonPropertyNamesEscaped.Age, ref builder, escapeName: false);
            name.AddAsProperty(JsonPropertyNamesEscaped.Name, ref builder, escapeName: false);
            competedInYears.AddAsProperty(JsonPropertyNamesEscaped.CompetedInYears, ref builder, escapeName: false);
        }
    }

    public static class JsonPropertyNames
    {
        public static ReadOnlySpan<byte> Name => "name"u8;
        public static ReadOnlySpan<byte> Age => "age"u8;
        public static ReadOnlySpan<byte> CompetedInYears => "competedInYears"u8;
    }

    private static class JsonPropertyNamesEscaped
    {
        public static ReadOnlySpan<byte> Name => "name"u8;
        public static ReadOnlySpan<byte> Age => "age"u8;
        public static ReadOnlySpan<byte> CompetedInYears => "competedInYears"u8;
    }

    public static class JsonSchema
    {
        private const int NameRequiredOffset = 0;
        private const int NameRequiredBitMask = 0b0000_0000_0000_0001;
        private const int BitMaskOffset0 = NameRequiredBitMask;

        private static ReadOnlySpan<byte> SchemaLocation() => "#/$defs/Person"u8;
        private static ReadOnlySpan<byte> Required0Location() => "#/required/0"u8;

        private static ReadOnlySpan<byte> ExpectedAnObjectValue() => "Expected an object value."u8;
        private static ReadOnlySpan<byte> RequiredPropertyNameNotPresent() => "The required property 'name' was not present."u8;
        private static ReadOnlySpan<byte> RequiredPropertyNamePresent() => "The required property 'name' was present."u8;
        private static ReadOnlySpan<byte> IgnoredBecauseTheValueWasNotOfTypeObject() => "Ignored because the value was not of type 'object'."u8;
        private static ReadOnlySpan<byte> EscapedTypeKeyword() => "type"u8;
        private static ReadOnlySpan<byte> EscapedPropertiesKeyword() => "properties"u8;
        private static ReadOnlySpan<byte> EscapedRequiredKeyword() => "required"u8;
        private static ReadOnlySpan<byte> EscapedUnevaluatedPropertiesKeyword() => "unevaluatedProperties"u8;
        private static ReadOnlySpan<byte> EscapedNameSchemaEvaluationPath() => "#/properties/name/$ref"u8;
        private static ReadOnlySpan<byte> EscapedNameDocumentEvaluationPath() => "#/name"u8;
        private static ReadOnlySpan<byte> EscapedAgeSchemaEvaluationPath() => "#/properties/age/$ref"u8;
        private static ReadOnlySpan<byte> EscapedAgeDocumentEvaluationPath() => "#/age"u8;
        private static ReadOnlySpan<byte> EscapedCompetedInYearsSchemaEvaluationPath() => "#/properties/competedInYears/$ref"u8;
        private static ReadOnlySpan<byte> EscapedCompetedInYearsDocumentEvaluationPath() => "#/competedInYears"u8;

        // NEXT TIME: Implement the validation for Person
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

                if (TryGetValidator(propertyName, out JsonSchemaMatcherWithRequiredBitBuffer? validator))
                {
                    context.AddLocalEvaluatedProperty(propertyCount);
                    validator(parentDocument, currentIndex, ref context, seenItems);

                    if (!context.IsMatch && !context.HasCollector)
                    {
                        return;
                    }
                }

                if (!context.HasLocalOrAppliedEvaluatedProperty(propertyCount))
                {
                    // We push and commit the child context as an optimization for "NotAny" - no need to actually validate with anything in between, just
                    // jump straight to "isMatch: false"; but benefit from the output generation.
                    // TODO: we have to re-evaluate the property name, because we aren't allowed to use the ReadOnlySpan prior to dotnet 9.
                    // we could optimize after this to use allows ref struct on the generic on NET9 and up and #ifdef this. It would be faster.
                    JsonSchemaContext childContext = context.PushChildContext(parentDocument, currentIndex, false, false, schemaEvaluationPath: EscapedUnevaluatedPropertiesKeyword);
                    context.CommitChildContext(isMatch: false, ref childContext);
                    if (!context.HasCollector)
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
                    context.Matched(true, RequiredPropertyNameNotPresent, Required0Location);
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
                if ((seenItems[NameRequiredOffset] & NameRequiredBitMask) == 0)
                {
                    context.Matched(false, RequiredPropertyNameNotPresent, Required0Location);
                    if (!context.HasCollector)
                    {
                        return;
                    }
                }
                else
                {
                    context.Matched(true, RequiredPropertyNamePresent, Required0Location);
                }
            }

            context.PopSchemaLocation();
        }

        private static bool TryGetValidator(ReadOnlySpan<byte> span, [NotNullWhen(true)] out JsonSchemaMatcherWithRequiredBitBuffer? validator)
        {
            // We only have 1 property, so it is going to be vastly more efficient to do this
            // with property names
            if (JsonPropertyNamesEscaped.Name.SequenceEqual(span))
            {
                validator = MatchName;
                return true;
            }
            else if (JsonPropertyNamesEscaped.Age.SequenceEqual(span))
            {
                validator = MatchAge;
                return true;
            }
            else if (JsonPropertyNamesEscaped.CompetedInYears.SequenceEqual(span))
            {
                validator = MatchCompetedInYears;
                return true;
            }

            validator = default;
            return false;
        }

        private static void MatchName(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                PersonName.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedNameSchemaEvaluationPath,
                    documentEvaluationPath: EscapedNameDocumentEvaluationPath);

            PersonName.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);
            context.CommitChildContext(childContext.IsMatch, ref childContext);

            requiredBitBuffer[NameRequiredOffset] |= NameRequiredBitMask;
        }

        private static void MatchAge(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                Age.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedAgeSchemaEvaluationPath,
                    documentEvaluationPath: EscapedAgeDocumentEvaluationPath);

            Age.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
        }

        private static void MatchCompetedInYears(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                CompetedInYears.JsonSchema.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    schemaEvaluationPath: EscapedCompetedInYearsSchemaEvaluationPath,
                    documentEvaluationPath: EscapedCompetedInYearsDocumentEvaluationPath);

            CompetedInYears.JsonSchema.ApplyJsonSchema(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
        }

        internal static bool IsMatch(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector = null)
        {
            JsonSchemaContext context = JsonSchemaContext.BeginContext(
                parentDocument,
                parentIndex,
                usingEvaluatedProperties: true,
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
                    useEvaluatedProperties: true, // But we do use evaluated properties
                    providerContext: providerContext,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }
    }
}
