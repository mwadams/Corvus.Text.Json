// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Sandbox;

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

    public static JsonDocumentBuilder<Mutable> CreateDocument(JsonWorkspace workspace, Builder.Build builder, int initialCapacity = 30)
    {
        // Create the document builder without a MetadataDb
        JsonDocumentBuilder<Mutable> documentBuilder = workspace.CreateDocument<Mutable>(-1);
        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, 0, initialCapacity);
        Builder.BuildValue(builder, ref cvb);
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
        ArgumentNullException.ThrowIfNull(writer);

        CheckValidInstance();

        _parent.WriteElementTo(_idx, writer);
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

    public static OtherNames From<T>(in T instance)
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

    public ref struct Builder
    {
        public delegate void Build(ref Builder builder);

        public readonly ref struct Source
        {
            public Build? Builder { get; }

            public OtherNames Instance { get; }

            public Source(OtherNames instance)
            {
                Builder = null;
                Instance = instance;
            }

            public Source(Build builder)
            {
                Builder = builder;
                Instance = default;
            }

            public static implicit operator Source(OtherNames instance) => new(instance);

            internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build builder)
                {
                    valueBuilder.AddProperty(utf8Name, (ref ComplexValueBuilder o) => BuildValue(builder, ref o));
                }
                else
                {
                    Debug.Assert(Instance.ValueKind != JsonValueKind.Undefined);
                    valueBuilder.AddProperty(utf8Name, Instance);
                }
            }

            internal void AddAsItem(ref ComplexValueBuilder valueBuilder)
            {
                if (Builder is Build builder)
                {
                    valueBuilder.AddItem((ref ComplexValueBuilder o) => BuildValue(builder, ref o));
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
            ComplexValueBuilder builder = ComplexValueBuilder.Create(parentDocument, targetIndex, initialElementCount);
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
            ArgumentNullException.ThrowIfNull(writer);

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
}
