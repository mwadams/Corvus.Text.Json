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
    /// Gets the number of properties in the instance.
    /// </summary>
    /// <returns>The number of properties in the instance.</returns>
    public int GetPropertyCount()
    {
        CheckValidInstance();
        return _parent.GetPropertyCount(_idx);
    }

    /// <summary>
    /// Gets an enumerator for the properties in the object.
    /// </summary>
    /// <returns></returns>
    public ObjectEnumerator<JsonElement> EnumerateObject()
    {
        CheckValidInstance();
        return EnumeratorCreator.CreateObjectEnumerator<JsonElement>(_parent, _idx);
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

    public static bool operator ==(PersonName left, PersonName right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PersonName left, PersonName right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(PersonName left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PersonName left, JsonElement right)
    {
        return !left.Equals(right);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, in NameComponent.Source firstName, in NameComponent.Source lastName, in OtherNames.Source otherNames, int initialCapacity = 30)
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
        return workspace.CreateDocumentBuilder<PersonName, Mutable>(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new PersonName(other.ParentDocument, other.ParentDocumentIndex)))
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

        public readonly NameComponent.Mutable FirstName
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

        public readonly NameComponent.Mutable LastName
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

        public readonly OtherNames.Mutable OtherNames
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

        public void SetFirstName(in NameComponent.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.FirstName, out Mutable element))
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

        public void SetLastName(in NameComponent.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.LastName, out Mutable element))
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

        public void SetOtherNames(in OtherNames.Source value)
        {
            CheckValidInstance();

            ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);
            if (_parent.TryGetNamedPropertyValue(_idx, JsonPropertyNames.OtherNames, out Mutable element))
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
        public readonly JsonValueKind ValueKind => TokenType.ToValueKind();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly JsonTokenType TokenType
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
        public override readonly bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new PersonName(other.ParentDocument, other.ParentDocumentIndex)))
                || (obj is null && this.IsNull());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals<T>(T other)
            where T : struct, IJsonElement
        {
            return JsonElementHelpers.DeepEquals(this, other);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
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
        private readonly string DebuggerDisplay => $"PersonName.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly IJsonDocument IJsonElement.ParentDocument => _parent;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int IJsonElement.ParentDocumentIndex => _idx;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonTokenType IJsonElement.TokenType => TokenType;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly JsonValueKind IJsonElement.ValueKind => ValueKind;
    }

    public readonly ref struct Source
    {
        private enum Kind
        {
            Unknown,
            JsonElement,
            PersonBuilderInstance,
        }

        private readonly Kind _kind;
        private readonly JsonElement _jsonElement;
        private readonly PersonName.Builder.Build? _objectBuilder;

        private Source(JsonElement instance)
        {
            _jsonElement = instance;
            _kind = Kind.JsonElement;
        }

        public Source(PersonName.Builder.Build builder)
        {
            _objectBuilder = builder;
            _kind = Kind.PersonBuilderInstance;
        }

        public static implicit operator Source(PersonName instance) => new(JsonElement.From(instance));

        internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);
                    break;
                case Kind.PersonBuilderInstance:
                    valueBuilder.AddProperty(utf8Name, _objectBuilder!, static (context, ref o) => PersonName.Builder.BuildValue(context, ref o), escapeName, nameRequiresUnescaping);
                    break;
                default:
                    Debug.Fail("Unexpected Kind");
                    break;
            }
        }

        internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
        {
            switch (_kind)
            {
                case Kind.JsonElement:
                    Debug.Assert(_jsonElement.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddItem(_jsonElement);
                    break;
                case Kind.PersonBuilderInstance:
                    Debug.Assert(_objectBuilder is not null);
                    valueBuilder.AddItem(_objectBuilder!, static (context, ref o) => PersonName.Builder.BuildValue(context, ref o));
                    break;
                default:
                    Debug.Fail("Unexpected Kind");
                    break;
            }
        }
    }

    public ref struct Builder
    {
        public delegate void Build(ref Builder builder);

        private ComplexValueBuilder _builder;

        internal Builder(ComplexValueBuilder builder) : this() => _builder = builder;

        internal static void BuildValue(Build value, ref ComplexValueBuilder o)
        {
            o.StartObject();
            Builder ovb = new(o);
            value(ref ovb);
            o = ovb._builder;
            o.EndObject();
        }

        public void Create(in NameComponent.Source firstName, in NameComponent.Source lastName, in OtherNames.Source otherNames)
        {
            Create(ref _builder, firstName, lastName, otherNames);
        }

        internal static void Create(ref ComplexValueBuilder builder, in NameComponent.Source firstName, in NameComponent.Source lastName, in OtherNames.Source otherNames)
        {
            firstName.AddAsProperty(JsonPropertyNamesEscaped.FirstName, ref builder, escapeName: false);
            lastName.AddAsProperty(JsonPropertyNamesEscaped.LastName, ref builder, escapeName: false);
            otherNames.AddAsProperty(JsonPropertyNamesEscaped.OtherNames, ref builder, escapeName: false);
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
        public static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/Name"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider<int> RequiredSchemaEvaluationPath = static (index, buffer, out written) => JsonSchemaEvaluation.SchemaLocationForIndexedKeyword("required"u8, index, buffer, out written);
        private static readonly JsonSchemaPathProvider FirstNameSchemaEvaluationPath = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("firstName/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider LastNameSchemaEvaluationPath = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("lastName/$ref"u8, buffer, out written);
        private static readonly JsonSchemaPathProvider OtherNamesSchemaEvaluationPath = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("otherNames/$ref"u8, buffer, out written);

        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyFirstNamePresent = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyPresent("firstName"u8, buffer, out written);
        private static readonly JsonSchemaMessageProvider<int> RequiredPropertyFirstNameNotPresent = static (_, buffer, out written) => JsonSchemaEvaluation.RequiredPropertyNotPresent("firstName"u8, buffer, out written);


        private const int FirstNameRequiredOffset = 0;
        private const int FirstNameRequiredBitMask = 0b0000_0000_0000_0001;
        private const int BitMaskOffset0 = FirstNameRequiredBitMask;

        /// <summary>
        /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
        /// </summary>
        /// <param name="parentDocument">The parent document.</param>
        /// <param name="parentIndex">The parent index.</param>
        /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
        internal static void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
        {
            // You're not allowed to ask about non-value-like tokens
            Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                JsonTokenType.None or
                JsonTokenType.EndObject or
                JsonTokenType.EndArray);

            JsonTokenType tokenType = parentDocument.GetJsonTokenType(parentIndex);

            if (!JsonSchemaEvaluation.MatchTypeObject(tokenType, "type"u8, ref context))
            {
                if (!context.HasCollector)
                {
                    return;
                }

                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeObject, "properties"u8);
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeObject, "required"u8);
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
                            return;
                        }
                    }

                    propertyCount++;
                }

                // Do a quick test to see if we have all of the required bits set in each element
                if ((seenItems[0] ^ BitMaskOffset0) == 0)
                {
                    // Add a "matched" for each of the individual matched properties
                    context.EvaluatedKeywordPath(true, 0, RequiredPropertyFirstNamePresent, RequiredSchemaEvaluationPath);
                    return;
                }

                // Sadly we don't, so we have to do the slow path
                if (!context.HasCollector)
                {
                    // Which we can cut short if we are not doing collections
                    context.EvaluatedBooleanSchema(false);
                    return;
                }
                else
                {
                    // We have missed at least one of the required properties
                    // and we are doing collections, so test them all individually
                    if ((seenItems[FirstNameRequiredOffset] & FirstNameRequiredBitMask) == 0)
                    {
                        context.EvaluatedKeywordPath(false, 0, RequiredPropertyFirstNameNotPresent, RequiredSchemaEvaluationPath);
                    }
                    else
                    {
                        context.EvaluatedKeywordPath(true, 0, RequiredPropertyFirstNamePresent, RequiredSchemaEvaluationPath);
                    }
                }
            }
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
                NameComponent.JsonSchema.PushChildContextUnescaped(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    JsonPropertyNames.FirstNameUtf8,
                    evaluationPath: FirstNameSchemaEvaluationPath);

            NameComponent.JsonSchema.Evaluate(parentDocument, parentDocumentIndex, ref childContext);
            context.CommitChildContext(childContext.IsMatch, ref childContext);
            requiredBitBuffer[FirstNameRequiredOffset] |= FirstNameRequiredBitMask;
        }

        private static void MatchLastName(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                NameComponent.JsonSchema.PushChildContextUnescaped(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    JsonPropertyNames.LastNameUtf8,
                    evaluationPath: LastNameSchemaEvaluationPath);

            NameComponent.JsonSchema.Evaluate(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
        }

        private static void MatchOtherNames(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
        {
            JsonSchemaContext childContext =
                OtherNames.JsonSchema.PushChildContextUnescaped(
                    parentDocument,
                    parentDocumentIndex,
                    ref context,
                    JsonPropertyNames.OtherNamesUtf8,
                    evaluationPath: OtherNamesSchemaEvaluationPath);

            OtherNames.JsonSchema.Evaluate(parentDocument, parentDocumentIndex, ref childContext);

            context.CommitChildContext(childContext.IsMatch, ref childContext);
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
    JsonSchemaPathProvider? evaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    propertyName,
                    evaluationPath: evaluationPath,
                    schemaEvaluationPath: SchemaLocation);
        }

        internal static JsonSchemaContext PushChildContextUnescaped(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            ReadOnlySpan<byte> propertyName,
            JsonSchemaPathProvider? evaluationPath = null)
        {
            return
                context.PushChildContextUnescaped(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    propertyName,
                    evaluationPath: evaluationPath,
                    schemaEvaluationPath: SchemaLocation);
        }

        internal static JsonSchemaContext PushChildContext(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            JsonSchemaPathProvider? evaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    evaluationPath: evaluationPath,
                    schemaEvaluationPath: SchemaLocation,
                    documentEvaluationPath: documentEvaluationPath);
        }

        internal static JsonSchemaContext PushChildContext<TContext>(
            IJsonDocument parentDocument,
            int parentDocumentIndex,
            ref JsonSchemaContext context,
            TContext providerContext,
            JsonSchemaPathProvider<TContext>? evaluationPath = null,
            JsonSchemaPathProvider<TContext>? documentEvaluationPath = null)
        {
            return
                context.PushChildContext(
                    parentDocument,
                    parentDocumentIndex,
                    useEvaluatedItems: false, // We don't use evaluated items
                    useEvaluatedProperties: false,
                    providerContext: providerContext,
                    evaluationPath: evaluationPath,
                    schemaEvaluationPath: static (_, buffer, out written) => SchemaLocation(buffer, out written),
                    documentEvaluationPath: documentEvaluationPath);
        }
    }
}
