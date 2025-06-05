// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.FirstName, out NameComponent value))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.LastName, out NameComponent value))
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
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.FirstName, out OtherNames value))
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

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in NameComponent.Builder.Source firstName, in NameComponent.Builder.Source lastName, in OtherNames.Builder.Source otherNames, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.StartObject();
        Builder.Create(ref cvb, firstName, lastName, otherNames);
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

    public JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
    {
        return workspace.CreateDocumentBuilder<PersonName, Mutable>(this);
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

        public NameComponent.Mutable FirstName
        {
            get
            {
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.FirstName, out NameComponent.Mutable value))
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
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.LastName, out NameComponent.Mutable value))
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
                if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.FirstName, out OtherNames.Mutable value))
                {
                    return value;
                }

                return default;
            }
        }

        public void SetFirstName(in NameComponent.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.FirstName, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.FirstName, ref cvb, escapeName: false, nameRequiresUnescaping: false);
                int endIndex = _idx + _parent.GetDbSize(_idx, false);
                _parent.InsertAndDispose(_idx, endIndex, ref cvb);
            }

            _documentVersion = _parent.Version;
        }

        public void SetLastName(in NameComponent.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.LastName, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.LastName, ref cvb, escapeName: false, nameRequiresUnescaping: false);
                int endIndex = _idx + _parent.GetDbSize(_idx, false);
                _parent.InsertAndDispose(_idx, endIndex, ref cvb);
            }

            _documentVersion = _parent.Version;
        }

        public void SetOtherNames(in OtherNames.Builder.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNamesEscaped.OtherNames, out Mutable element))
            {
                // We are going to replace just the value
                value.AddAsItem(ref cvb);
                _parent.OverwriteAndDispose(_idx, element._idx, element._idx + element._parent.GetDbSize(element._idx, true), 1, ref cvb);
            }
            else
            {
                // We are going to insert the new value
                value.AddAsProperty(JsonPropertyNamesEscaped.OtherNames, ref cvb, escapeName: false, nameRequiresUnescaping: false);
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

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
            {
                if (Builder is Build nameBuilder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref o) => BuildValue(nameBuilder, ref o), escapeName, nameRequiresUnescaping);
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddProperty(utf8Name, Instance, escapeName, nameRequiresUnescaping);
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

        public void Create(in NameComponent.Builder.Source firstName, in NameComponent.Builder.Source lastName, in OtherNames.Builder.Source otherNames)
        {
            Create(ref _builder, firstName, lastName, otherNames);
        }

        internal static void Create(ref ComplexValueBuilder builder, in NameComponent.Builder.Source firstName, in NameComponent.Builder.Source lastName, in OtherNames.Builder.Source otherNames)
        {
            firstName.AddAsProperty(JsonPropertyNamesEscaped.FirstName, ref builder, escapeName: false);
            lastName.AddAsProperty(JsonPropertyNamesEscaped.LastName, ref builder, escapeName: false);
            otherNames.AddAsProperty(JsonPropertyNamesEscaped.OtherNames, ref builder, escapeName: false);
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
        public static ReadOnlySpan<byte> FirstNameUtf8 => "firstName"u8;
        public const string FirstName = "firstName";
        public static ReadOnlySpan<byte> LastNameUtf8 => "lastName"u8;
        public const string LastName = "lastName";
        public static ReadOnlySpan<byte> OtherNamesUtf8 => "otherNames"u8;
        public const string OtherNames = "otherNames";
    }

    private static class JsonPropertyNamesEscaped
    {
        public static ReadOnlySpan<byte> FirstName => "firstName"u8;
        public static ReadOnlySpan<byte> LastName => "lastName"u8;
        public static ReadOnlySpan<byte> OtherNames => "otherNames"u8;
    }

    public static class JsonSchema
    {
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("#/$defs/Age"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> RequiredSchemaEvaluationPath = static (index, buffer, out written) => JsonSchemaMatching.SchemaLocationForIndexedKeyword("required"u8, index, buffer, out written);
        private static readonly JsonSchemaPathProvider FirstNameSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/firstName/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider FirstNameDocumentEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("firstName"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider LastNameSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/lastName/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider LastNameDocumentEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("lastName"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider OtherNamesSchemaEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties/otherNames/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider OtherNamesDocumentEvaluationPath = static (buffer, out written) => JsonSchemaMatching.TryCopyPath("otherNames"u8, buffer, out written);

        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyFirstNamePresent = static (_, buffer, out written) => JsonSchemaMatching.RequiredPropertyPresent("firstName"u8, buffer, out written);
        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyFirstNameNotPresent = static (_, buffer, out written) => JsonSchemaMatching.RequiredPropertyNotPresent("firstName"u8, buffer, out written);


        private const int FirstNameRequiredOffset = 0;
        private const int FirstNameRequiredBitMask = 0b0000_0000_0000_0001;
        private const int BitMaskOffset0 = FirstNameRequiredBitMask;

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

            if (!JsonSchemaMatching.MatchTypeObject(tokenType, __Keywords.Type, ref context))
            {
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                context.Ignored(JsonSchemaMatching.IgnoredNotTypeObject, __Keywords.Properties);
                context.Ignored(JsonSchemaMatching.IgnoredNotTypeObject, __Keywords.Required);
            }
            else
            {
                // Object matching code
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
                    context.Matched(true, 0, RequiredPropertyFirstNameNotPresent, RequiredSchemaEvaluationPath);
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
                    if ((seenItems[FirstNameRequiredOffset] & FirstNameRequiredBitMask) == 0)
                    {
                        context.Matched(false, 0, RequiredPropertyFirstNameNotPresent, RequiredSchemaEvaluationPath);
                    }
                    else
                    {
                        context.Matched(true, 0, RequiredPropertyFirstNamePresent, RequiredSchemaEvaluationPath);
                    }
                }
            }

            context.PopSchemaLocation();
        }

        private static bool TryGetValidator(ReadOnlySpan<byte> span, [NotNullWhen(true)] out JsonSchemaMatcherWithRequiredBitBuffer? validator)
        {
            // We only have 1 property, so it is going to be vastly more efficient to do this
            // with property names
            if (JsonPropertyNamesEscaped.FirstName.SequenceEqual(span))
            {
                validator = MatchFirstName;
                return true;
            }
            else if (JsonPropertyNamesEscaped.LastName.SequenceEqual(span))
            {
                validator = MatchLastName;
                return true;
            }
            else if (JsonPropertyNamesEscaped.OtherNames.SequenceEqual(span))
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
                    schemaEvaluationPath: FirstNameSchemaEvaluationPath,
                    documentEvaluationPath: FirstNameDocumentEvaluationPath);

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
                    schemaEvaluationPath: LastNameSchemaEvaluationPath,
                    documentEvaluationPath: LastNameDocumentEvaluationPath);

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
                    schemaEvaluationPath: OtherNamesSchemaEvaluationPath,
                    documentEvaluationPath: OtherNamesDocumentEvaluationPath);

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
                    useEvaluatedProperties: false,
                    providerContext: providerContext,
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath);
        }
    }
}
