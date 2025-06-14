// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    /// <summary>
    /// A JSON IRI Reference.
    /// </summary>
    /// <remarks>
    /// <code>
    /// <![CDATA[
    ///     foo://user@example.com:8042/over/there?name=ferret#nose
    ///     \_/   \___________________/\_________/ \_________/ \__/
    ///       |           |                 |           |       |
    ///     scheme     authority           path       query  fragment
    ///           \___/\______________/
    ///             |        |
    ///          user      host (including port)
    /// ]]>
    /// </code>
    /// </remarks>
    public readonly ref struct JsonReference
    {
        private readonly ReadOnlySpan<byte> _originalUri;
        private readonly Utf8UriOffset _offsets;
        private readonly Utf8Uri.Flags _flags;

        /// <summary>
        /// Gets a value indicating whether this is a valid reference.
        /// </summary>
        bool IsValidReference { get; }

        /// <summary>
        /// Gets a value indicating whether this is a relative reference.
        /// </summary>
        public bool IsRelative => (_flags & Utf8Uri.Flags.UserEscaped) != 0;

        /// <summary>
        /// Gets a value indicating whether this is the default port for the scheme.
        /// </summary>
        public bool IsDefaultPort => (_flags & Utf8Uri.Flags.NotDefaultPort) == 0;

        /// <summary>
        /// Gets a value indicating whether this reference has a scheme
        /// </summary>
        public bool HasScheme => _offsets.User - _offsets.Scheme > 0;

        /// <summary>
        /// Gets a value indicating whether this reference has an authority
        /// </summary>
        public bool HasAuthority => _offsets.Path - _offsets.User > 0;

        /// <summary>
        /// Gets a value indicating whether this reference has a user
        /// </summary>
        public bool HasUser => _offsets.Host - _offsets.User > 0;
        /// <summary>
        /// Gets a value indicating whether this reference has a host
        /// </summary>
        public bool HasHost => _offsets.Path - _offsets.Host > 0;
        /// <summary>
        /// Gets a value indicating whether this reference has a path
        /// </summary>
        public bool HasPath => _offsets.Query - _offsets.Path > 0;
        /// <summary>
        /// Gets a value indicating whether this reference has a query
        /// </summary>
        public bool HasQuery => _offsets.Fragment - _offsets.Query > 0;
        /// <summary>
        /// Gets a value indicating whether this reference has a fragment
        /// </summary>
        public bool HasFragment => _offsets.End - _offsets.Fragment > 0;

        /// <summary>
        /// Gets the original (fully encoded) string.
        /// </summary>
        public ReadOnlySpan<byte> OriginalUri => _originalUri;

        /// <summary>
        /// Gets the value as a <see cref="Uri"/>.
        /// </summary>
        /// <returns>The URI representation of the reference.</returns>
        public Uri GetUri()
        {
            return new Uri(JsonReaderHelper.TranscodeHelper(_originalUri), UriKind.RelativeOrAbsolute);
        }

        private JsonReference(ReadOnlySpan<byte> uri)
        {
            _originalUri = uri;
            IsValidReference = Utf8Uri.ParseUriInfo(_originalUri, Utf8UriKind.RelativeOrAbsolute, requireAbsolute: false, allowIri: true, allowUNCPath: false, out _offsets, out _flags);
        }

        public static JsonReference Create(ReadOnlySpan<byte> uri)
        {
            if (!TryCreate(uri, out JsonReference reference))
            {
                ThrowHelper.ThrowArgumentException(SR.InvalidJsonReference);
            }

            return reference;
        }

        public static bool TryCreate(ReadOnlySpan<byte> uri, out JsonReference reference)
        {
            reference = new(uri);
            return reference.IsValidReference;
        }

        public static bool TryEncodeAndCreate(ReadOnlySpan<byte> uri, out JsonReference reference)
        {
            reference = new(uri);
            return reference.IsValidReference;
        }
     
        public ReadOnlySpan<byte> Scheme => HasAuthority ? _originalUri.Slice(_offsets.Scheme, _offsets.User - _offsets.Scheme - 3) : _originalUri.Slice(_offsets.Scheme, _offsets.User - _offsets.Scheme - 1);
        public ReadOnlySpan<byte> Authority => _originalUri.Slice(_offsets.User, _offsets.Path - _offsets.User);
        public ReadOnlySpan<byte> User => HasAuthority ? _originalUri.Slice(_offsets.User, _offsets.Host - _offsets.User - 1) : [];
        // This includes both host and port
        public ReadOnlySpan<byte> Host => _originalUri.Slice(_offsets.Host, _offsets.Port - _offsets.Host);
        public ReadOnlySpan<byte> Port => HasAuthority ? _originalUri.Slice(_offsets.Port + 1, _offsets.Path - _offsets.Port - 1) : [];
        public int PortValue => _offsets.PortValue;
        public ReadOnlySpan<byte> Path => _originalUri.Slice(_offsets.Path, _offsets.Query - _offsets.Path);
        public ReadOnlySpan<byte> Query => HasQuery ? _originalUri.Slice(_offsets.Query + 1, _offsets.Fragment - _offsets.Query - 1) : [];
        public ReadOnlySpan<byte> Fragment => HasFragment ? _originalUri.Slice(_offsets.Fragment + 1, _offsets.End - _offsets.Fragment - 1) : [];
    }
}
