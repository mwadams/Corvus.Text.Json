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

    private Person(IJsonDocument parent, int idx)
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Name, out PersonName value))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Age, out Age value))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.CompetedInYears, out CompetedInYears value))
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

    public static implicit operator JsonElement(Person person)
    {
        return JsonElement.From(person);
    }

    public static bool operator ==(Person left, Person right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Person left, Person right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(Person left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Person left, JsonElement right)
    {
        return !left.Equals(right);
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
        CheckValidInstance();

        _parent.WriteElementTo(_idx, writer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new Person(other.ParentDocument, other.ParentDocumentIndex)))
            || (obj is null && this.IsNull());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals<T>(T other)
        where T : struct, IJsonElement
    {
        return JsonElementHelpers.DeepEquals(this, other);
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

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in Age.Builder.Source age, in PersonName.Builder.Source name, in CompetedInYears.Builder.Source competedInYears, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.StartObject();
        Builder.Create(ref cvb, age, name, competedInYears);
        cvb.EndObject();
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, Builder.Build builder, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        Builder.BuildValue(builder, ref cvb);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
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
        return workspace.CreateDocumentBuilder<Person, Mutable>(this);
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

        public readonly PersonName.Mutable Name
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Name, out PersonName.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public readonly Age.Mutable Age
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Age, out Age.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public readonly CompetedInYears.Mutable CompetedInYears
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.CompetedInYears, out CompetedInYears.Mutable value))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Name, out Mutable element))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.Age, out Mutable element))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.CompetedInYears, out Mutable element))
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
        public readonly JsonValueKind ValueKind => TokenType.ToValueKind();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly JsonTokenType TokenType
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
        public override readonly bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new Person(other.ParentDocument, other.ParentDocumentIndex)))
                || (obj is null && this.IsNull());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals<T>(T other)
            where T : struct, IJsonElement
        {
            return JsonElementHelpers.DeepEquals(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsSchemaMatch(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.IsMatch(_parent, _idx, resultsCollector);
        }

        public static Mutable From<T>(in T instance)
        where T : struct, IMutableJsonElement<T>
        {
            return new(instance.ParentDocument, instance.ParentDocumentIndex);
        }

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
        public override readonly string ToString()
        {
            if (_parent == null || _documentVersion != _parent.Version)
            {
                return string.Empty;
            }

            return _parent.ToString(_idx);
        }

        /// <inheritdoc/>
        public override readonly int GetHashCode()
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
        private readonly string DebuggerDisplay => $"Person.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonValueKind IJsonElement.ValueKind => ValueKind;
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

        internal static Builder Create(IMutableJsonDocument parentDocument, int initialElementCount)
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
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("#/$defs/Person"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> RequiredSchemaEvaluationPath = static (index, buffer, out written) => JsonSchemaMatching.SchemaLocationForIndexedKeyword("required"u8, index, buffer, out written);
        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyNamePresent = static (_, buffer, out written) => JsonSchemaMatching.RequiredPropertyPresent("name"u8, buffer, out written);
        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyNameNotPresent = static (_, buffer, out written) => JsonSchemaMatching.RequiredPropertyNotPresent("name"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider NameSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/name/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider AgeSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/age/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider CompetedInYearsSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/competedInYears/$ref"u8, buffer, out written);


        private const int NameRequiredOffset = 0;
        private const int NameRequiredBitMask = 0b0000_0000_0000_0001;
        private const int BitMaskOffset0 = NameRequiredBitMask;

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

            if (!JsonSchemaMatching.MatchTypeObject(tokenType, Keywords_230108d7f4a74123bc27f0a38784d172.Type, ref context))
            {
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                context.Ignored(JsonSchemaMatching.IgnoredNotTypeObject, Keywords_230108d7f4a74123bc27f0a38784d172.Properties);
                context.Ignored(JsonSchemaMatching.IgnoredNotTypeObject, Keywords_230108d7f4a74123bc27f0a38784d172.Required);
                context.Ignored(JsonSchemaMatching.IgnoredNotTypeObject, Keywords_230108d7f4a74123bc27f0a38784d172.UnevaluatedProperties);
            }
            else
            {
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
                            context.PopSchemaLocation();
                            return;
                        }
                    }

                    if (!context.HasLocalOrAppliedEvaluatedProperty(propertyCount))
                    {
                        // We push and commit the child context as an optimization for "NotAny" - no need to actually validate with anything in between, just
                        // jump straight to "isMatch: false"; but benefit from the output generation.
                        JsonSchemaContext childContext = context.PushChildContext(parentDocument, currentIndex, false, false, propertyName: propertyName, schemaEvaluationPath: Keywords_230108d7f4a74123bc27f0a38784d172.UnevaluatedProperties);
                        context.CommitChildContext(isMatch: false, ref childContext);
                        if (!context.HasCollector)
                        {
                            context.PopSchemaLocation();
                            return;
                        }
                    }

                    propertyCount++;
                }

                // Do a quick test to see if we have all of the required bits set in each element
                if ((seenItems[0] ^ BitMaskOffset0) == 0)
                {
                    // Add a "matched" for each of the individual matched properties
                    context.Matched(true, 0, RequiredPropertyNameNotPresent, RequiredSchemaEvaluationPath);
                    context.PopSchemaLocation();
                    return;
                }

                // Sadly we don't, so we have to do the slow path
                if (!context.HasCollector)
                {
                    // Which we can cut short if we are not doing collections
                    context.Matched(false);
                    context.PopSchemaLocation();
                    return;
                }
                else
                {
                    // We have missed at least one of the required properties
                    // and we are doing collections, so test them all individually
                    if ((seenItems[NameRequiredOffset] & NameRequiredBitMask) == 0)
                    {
                        context.Matched(false, 0, RequiredPropertyNameNotPresent, RequiredSchemaEvaluationPath);
                    }
                    else
                    {
                        context.Matched(true, 0, RequiredPropertyNamePresent, RequiredSchemaEvaluationPath);
                    }
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
                    JsonPropertyNames.Name,
                    schemaEvaluationPath: NameSchemaEvaluationPath);

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
                    JsonPropertyNames.Age,
                    schemaEvaluationPath: AgeSchemaEvaluationPath);

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
                    JsonPropertyNames.CompetedInYears,
                    schemaEvaluationPath: CompetedInYearsSchemaEvaluationPath);

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
                    schemaEvaluationPath: schemaEvaluationPath);
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
