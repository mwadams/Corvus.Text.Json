// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public readonly struct NameComponent : IJsonElement<NameComponent>
{
    private readonly IJsonDocument _parent;
    private readonly int _idx;

    internal NameComponent(IJsonDocument parent, int idx)
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
    public static bool operator ==(NameComponent left, NameComponent right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NameComponent left, NameComponent right)
    {
        return !left.Equals(right);
    }

    public static bool operator ==(NameComponent left, JsonElement right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NameComponent left, JsonElement right)
    {
        return !left.Equals(right);
    }

    public string? GetString()
    {
        CheckValidInstance();

        return _parent.GetString(_idx, JsonTokenType.String);
    }

    public UnescapedUtf8JsonString GetUtf8String()
    {
        CheckValidInstance();

        return _parent.GetUtf8JsonString(_idx, JsonTokenType.String);
    }

    public static NameComponent From<T>(in T instance)
    where T : struct, IJsonElement<T>
    {
        return new(instance.ParentDocument, instance.ParentDocumentIndex);
    }

    public static JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace, int year, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocumentBuilder<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
        cvb.AddItem(year);
        Debug.Assert(cvb.MemberCount == 1);
        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
        return documentBuilder;
    }

    public JsonDocumentBuilder<Mutable> CreateDocumentBuilder(JsonWorkspace workspace)
    {
        return workspace.CreateDocumentBuilder<NameComponent, Mutable>(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals(object? obj)
    {
        return (obj is IJsonElement other && Equals(new NameComponent(other.ParentDocument, other.ParentDocumentIndex)))
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
    static NameComponent IJsonElement<NameComponent>.CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex) => new(parentDocument, parentDocumentIndex);
#endif

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"NameComponent: ValueKind = {ValueKind} : \"{ToString()}\"";

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

        public static explicit operator Mutable(NameComponent nameComponent)
        {
            if (nameComponent._parent is not IMutableJsonDocument doc)
            {
                CodeGenThrowHelper.ThrowFormatException();
                // We will never get here
                return default;
            }

            return new(doc, nameComponent._idx);

        }

        public static implicit operator NameComponent(Mutable nameComponent)
        {
            return new(nameComponent._parent, nameComponent._idx);
        }

        public static implicit operator int(Mutable nameComponent)
        {
            nameComponent.CheckValidInstance();

            if (!nameComponent._parent.TryGetValue(nameComponent._idx, out int result))
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

        public string? GetString()
        {
            CheckValidInstance();

            return _parent.GetString(_idx, JsonTokenType.String);
        }

        public UnescapedUtf8JsonString GetUtf8String()
        {
            CheckValidInstance();

            return _parent.GetUtf8JsonString(_idx, JsonTokenType.String);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj)
        {
            return (obj is IJsonElement other && Equals(new NameComponent(other.ParentDocument, other.ParentDocumentIndex)))
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
        private string DebuggerDisplay => $"NameComponent.Mutable: ValueKind = {ValueKind} : \"{ToString()}\"";

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
            public NameComponent Instance { get; }

            public ReadOnlySpan<byte> Utf8StringValue { get; }

            public Source(NameComponent instance)
            {
                Instance = instance;
                Utf8StringValue = default;
            }

            public Source(ReadOnlySpan<byte> utf8StringValue)
            {
                Instance = default;
                Utf8StringValue = utf8StringValue;
            }

            public static implicit operator Source(NameComponent instance) => new(instance);
            public static implicit operator Source(ReadOnlySpan<byte> instance) => new(instance);

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Instance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddItem(Instance);
                }
                else
                {
                    valueBuilder.AddItem(Utf8StringValue);
                }
            }

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)
            {
                if (Instance.ValueKind != JsonValueKind.Undefined)
                {
                    valueBuilder.AddProperty(utf8Name, Instance, escapeName, nameRequiresUnescaping);
                }
                else
                {
                    valueBuilder.AddProperty(utf8Name, Utf8StringValue, escapeName, true, nameRequiresUnescaping, false);
                }
            }
        }
    }

    public static class JsonSchema
    {
        private static readonly JsonSchemaPathProvider SchemaLocation = static (buffer, out written) => JsonSchemaEvaluation.TryCopyPath("#/$defs/PersonNameElement"u8, buffer, out written);

        /// <summary>
        /// A constant for the <c>maxLength</c> keyword.
        /// </summary>
        public static readonly long MaxLength = 256;

        /// <summary>
        /// A constant for the <c>minLength</c> keyword.
        /// </summary>
        public static readonly long MinLength = 1;

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

            /* String matching
             * This would be if (tokenType != JsonTokenType.String) for the non-matching case where we have numeric keywords
             * to match, but no explicit type check */
            if (!JsonSchemaEvaluation.MatchTypeString(tokenType, "type"u8, ref context))
            {
                if (!context.HasCollector)
                {
                    context.PopSchemaLocation();
                    return;
                }

                // Ignore remaining string
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeString, "minLength"u8);
                context.IgnoredKeyword(JsonSchemaEvaluation.IgnoredNotTypeString, "maxLength"u8);
            }
            else
            {
                using UnescapedUtf8JsonString stringValue = parentDocument.GetUtf8JsonString(parentIndex, JsonTokenType.String);
                int length = JsonElementHelpers.GetUtf8StringLength(stringValue.Span);
                // Notice that we don't "short circuit" for the flags case, because the length test is fast.
                if (length <= MaxLength)
                {
                    context.EvaluatedKeyword(true, null, "maxLength"u8);
                }
                else
                {
                    context.EvaluatedKeyword(false, null, "maxLength"u8);
                }

                if (length >= MinLength)
                {
                    context.EvaluatedKeyword(true, null, "minLength"u8);
                }
                else
                {
                    context.EvaluatedKeyword(false, null, "minLength"u8);
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
                    schemaEvaluationPath: schemaEvaluationPath,
                    documentEvaluationPath: documentEvaluationPath,
                    providerContext: providerContext);
        }

    }
}
