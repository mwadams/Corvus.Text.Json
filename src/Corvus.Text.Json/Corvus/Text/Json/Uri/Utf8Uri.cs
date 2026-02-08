// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NET

using System.Buffers;

#endif

using System.Diagnostics;
using System.Runtime.CompilerServices;
using NodaTime;

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Provides utilities for parsing and validating UTF-8 URI strings.
/// </summary>
internal static class Utf8Uri
{
    /// <summary>
    /// The maximum size for a URI buffer.
    /// </summary>
    internal const int c_MaxUriBufferSize = 0xFFF0;

    /// <summary>
    /// The maximum length for a URI scheme name.
    /// </summary>
    internal const int c_MaxUriSchemeName = 1024;

    /// <summary>
    /// An invalid Unicode character used as a dummy character parameter.
    /// </summary>
    internal const char c_DummyChar = (char)0xFFFF;     //An Invalid Unicode character used as a dummy char passed into the parameter

    /// <summary>
    /// End-of-line character.
    /// </summary>
    internal const byte c_EOL = 0x00;

    /// <summary>
    /// Flags used during URI parsing and validation.
    /// </summary>
    [Flags]
    internal enum Flags : ulong
    {
        Zero = 0x00000000,

        SchemeNotCanonical = 0x1,
        UserNotCanonical = 0x2,
        HostNotCanonical = 0x4,
        PortNotCanonical = 0x8,
        PathNotCanonical = 0x10,
        QueryNotCanonical = 0x20,
        FragmentNotCanonical = 0x40,
        CannotDisplayCanonical = 0x7F,

        E_UserNotCanonical = 0x80,
        E_HostNotCanonical = 0x100,
        E_PortNotCanonical = 0x200,
        E_PathNotCanonical = 0x400,
        E_QueryNotCanonical = 0x800,
        E_FragmentNotCanonical = 0x1000,
        E_CannotDisplayCanonical = 0x1F80,

        E_NonCanonical = E_UserNotCanonical | E_HostNotCanonical | E_PortNotCanonical | E_PathNotCanonical | E_QueryNotCanonical | E_FragmentNotCanonical | E_CannotDisplayCanonical,

        ShouldBeCompressed = 0x2000,
        FirstSlashAbsent = 0x4000,
        BackslashInPath = 0x8000,

        IndexMask = 0x0000FFFF,
        HostTypeMask = 0x00070000,
        HostNotParsed = 0x00000000,
        IPv6HostType = 0x00010000,
        IPv4HostType = 0x00020000,
        DnsHostType = 0x00030000,
        UncHostType = 0x00040000,
        BasicHostType = 0x00050000,
        UnusedHostType = 0x00060000,
        UnknownHostType = 0x00070000,

        UserEscaped = 0x00080000,
        AuthorityFound = 0x00100000,
        HasUserInfo = 0x00200000,
        LoopbackHost = 0x00400000,
        NotDefaultPort = 0x00800000,

        UserDrivenParsing = 0x01000000,
        CanonicalDnsHost = 0x02000000,
        ErrorOrParsingRecursion = 0x04000000,   // Used to signal a default parser error and also to confirm Port

        // and Host values in case of a custom user Parser
        DosPath = 0x08000000,

        UncPath = 0x10000000,
        ImplicitFile = 0x20000000,
        MinimalUriInfoSet = 0x40000000,
        AllUriInfoSet = unchecked(0x80000000),
        IdnHost = 0x100000000,
        HasUnicode = 0x200000000,

        // Is this component Iri canonical
        UserIriCanonical = 0x8000000000,

        PathIriCanonical = 0x10000000000,
        QueryIriCanonical = 0x20000000000,
        FragmentIriCanonical = 0x40000000000,
        IriCanonical = 0x78000000000,
        UnixPath = 0x100000000000,

        /// <summary>
        /// Disables any validation/normalization past the authority. Fragments will always be empty. GetComponents will throw for Path/Query.
        /// </summary>
        DisablePathAndQueryCanonicalization = 0x200000000000,

        /// <summary>
        /// Used to ensure that InitializeAndValidate is only called once per Uri instance and only from an override of InitializeAndValidate
        /// </summary>
        CustomParser_ParseMinimalAlreadyCalled = 0x4000000000000000,

        HasUnescapedUnicode = 0x8000000000000000,
    }

    [Flags]
    private enum Check
    {
        None = 0x0,
        EscapedCanonical = 0x1,
        DisplayCanonical = 0x2,
        DotSlashAttn = 0x4,
        DotSlashEscaped = 0x80,
        BackslashInPath = 0x10,
        ReservedFound = 0x20,
        NotIriCanonical = 0x40,
        FoundNonAscii = 0x8
    }

    /// <summary>
    /// Parses URI information from the specified UTF-8 URI string.
    /// </summary>
    /// <param name="uriString">The UTF-8 URI string to parse.</param>
    /// <param name="uriKind">The kind of URI to parse.</param>
    /// <param name="requireAbsolute">A value indicating whether to require an absolute URI.</param>
    /// <param name="allowIri">A value indicating whether to allow IRI parsing.</param>
    /// <param name="allowUNCPath">A value indicating whether to allow UNC path parsing.</param>
    /// <param name="uriInfo">When this method returns, contains the parsed URI offset information.</param>
    /// <param name="resultFlags">When this method returns, contains the parsing result flags.</param>
    /// <returns><see langword="true"/> if the URI was parsed successfully; otherwise, <see langword="false"/>.</returns>
    internal static bool ParseUriInfo(ReadOnlySpan<byte> uriString, Utf8UriKind uriKind, bool requireAbsolute, bool allowIri, bool allowUNCPath, out Utf8UriOffset uriInfo, out Flags resultFlags)
    {
        Utf8UriParser? syntax = null;
        Flags flags = Flags.Zero;
        Utf8UriParsingError err = ParseScheme(uriString, ref flags, ref syntax);

        if ((flags & Flags.HasUnicode) != 0 && !allowIri)
        {
            uriInfo = default;
            resultFlags = flags;
            return false;
        }

        // We won't use User factory for these errors
        if (err != Utf8UriParsingError.None)
        {
            if (uriKind != Utf8UriKind.Absolute && !requireAbsolute && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
            {
                // If it looks as a relative Uri, custom factory is ignored
                resultFlags = flags | Flags.UserEscaped;
                return GetUriInfoForRelativeReference(uriString, allowIri, out uriInfo);
            }

            uriInfo = default;
            resultFlags = flags;
            return false;
        }

        // Cannot be relative Uri if came here
        Debug.Assert(syntax != null);
        bool result = ParseCore(err, ref flags, ref syntax, uriKind, uriString, requireAbsolute, allowUNCPath, out uriInfo);
        if (!result)
        {
            uriInfo = default;
            resultFlags = flags;
            return false;
        }

        if ((flags & Flags.HasUnescapedUnicode) != 0 && !allowIri)
        {
            uriInfo = default;
            resultFlags = flags;
            return false;
        }

        resultFlags = flags;
        return true;
    }

    /// <summary>
    /// Validates the specified UTF-8 URI string.
    /// </summary>
    /// <param name="uriString">The UTF-8 URI string to validate.</param>
    /// <param name="uriKind">The kind of URI to validate.</param>
    /// <param name="requireAbsolute">A value indicating whether to require an absolute URI.</param>
    /// <param name="allowIri">A value indicating whether to allow IRI validation.</param>
    /// <param name="allowUNCPath">A value indicating whether to allow UNC path validation.</param>
    /// <returns><see langword="true"/> if the URI is valid; otherwise, <see langword="false"/>.</returns>
    internal static bool Validate(ReadOnlySpan<byte> uriString, Utf8UriKind uriKind, bool requireAbsolute, bool allowIri, bool allowUNCPath)
    {
        Utf8UriParser? syntax = null;
        Flags flags = Flags.Zero;
        Utf8UriParsingError err = ParseScheme(uriString, ref flags, ref syntax);

        if ((flags & Flags.HasUnicode) != 0 && !allowIri)
        {
            return false;
        }

        // We won't use User factory for these errors
        if (uriKind != Utf8UriKind.Absolute && err != Utf8UriParsingError.None)
        {
            // If it looks as a relative Uri, custom factory is ignored
            if (!requireAbsolute && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
                return ValidateRelativeReference(uriString, allowIri);

            return false;
        }

        // Cannot be relative Uri if came here
        Debug.Assert(syntax != null);
        bool result = ValidateCore(err, ref flags, ref syntax, uriKind, uriString, requireAbsolute, allowUNCPath);
        if (!result)
        {
            return false;
        }

        if ((flags & Flags.HasUnicode) != 0 && !allowIri)
        {
            return false;
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAbsoluteUri(Utf8UriParser? syntax) => syntax is not null;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsImplicitFile(Flags flags)
    {
        return (flags & Flags.ImplicitFile) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDosPath(Flags flags)
    {
        return (flags & Flags.DosPath) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool UserDrivenParsing(Flags flags)
    {
        return (flags & Flags.UserDrivenParsing) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Flags HostType(Flags flags)
    {
        return flags & Flags.HostTypeMask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsError(Flags flags)
    {
        return (flags & Flags.ErrorOrParsingRecursion) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool NotAny(Flags allFlags, Flags checkFlags)
    {
        return (allFlags & checkFlags) == 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool InFact(Flags allFlags, Flags checkFlags)
    {
        return (allFlags & checkFlags) != 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IriParsing(Utf8UriParser? syntax)
    {
        return syntax is null || syntax.InFact(Utf8UriSyntaxFlags.AllowIriParsing);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsFile(Utf8UriParser syntax)
    {
        return syntax.InFact(Utf8UriSyntaxFlags.FileLikeUri);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ValidatePathQueryAndFragmentSegment(ReadOnlySpan<byte> uriString, bool iriParsing)
    {
        return ValidateRelativeReference(uriString, iriParsing);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool GetUriInfoForRelativeReference(ReadOnlySpan<byte> uriString, bool iriParsing, out Utf8UriOffset uriInfo)
    {
        Utf8UriOffset info = default;
        int length = uriString.Length;

        GetUriInfoForQueryAndFragment(uriString, ref info, out int queryIdx, out int hashIdx);

        int idx = 0;
        if (ValidateRelativeReferenceCore(uriString, iriParsing, length, ref idx, queryIdx, hashIdx))
        {
            uriInfo = info;
            return true;
        }

        uriInfo = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void GetUriInfoForQueryAndFragment(ReadOnlySpan<byte> uriString, ref Utf8UriOffset info, out int queryIdx, out int hashIdx)
    {
        info.End = (ushort)uriString.Length;

        queryIdx = uriString.IndexOf((byte)'?');
        int hashStart = 0;

        if (queryIdx >= 0)
        {
            info.Query = (ushort)queryIdx;
            hashStart = queryIdx + 1;
        }
        else
        {
            info.Query = info.End;
        }

        hashIdx = uriString.Slice(hashStart).IndexOf((byte)'#');
        if (hashIdx >= 0)
        {
            info.Fragment = (ushort)(hashIdx + hashStart);
            if (info.Query == info.End)
            {
                info.Query = info.Fragment;
            }
        }
        else
        {
            info.Fragment = info.End;
        }
    }

    private static unsafe bool ValidateRelativeReference(ReadOnlySpan<byte> uriString, bool iriParsing)
    {
        int length = uriString.Length;

        int idx = 0;

        int queryIdx = uriString.IndexOf((byte)'?');

        int hashStart = queryIdx > 0 ? queryIdx + 1 : 0;

        int hashIdx = uriString.Slice(hashStart).IndexOf((byte)'#') + hashStart;

        return ValidateRelativeReferenceCore(uriString, iriParsing, length, ref idx, queryIdx, hashIdx);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe bool ValidateRelativeReferenceCore(ReadOnlySpan<byte> uriString, bool iriParsing, int length, ref int idx, int queryIdx, int hashIdx)
    {
        if (idx < length && uriString[idx] is not ((byte)'?' or (byte)'#'))
        {
            // Check the path
            fixed (byte* str = uriString)
            {
                while (str[idx] == (byte)' ')
                {
                    idx++;
                }

                Check result = CheckCanonical(str, ref idx, length, (queryIdx >= 0) ? (byte)'?' : (hashIdx >= 0) ? (byte)'#' : c_EOL, iriParsing, queryIdx >= 0, hashIdx >= 0);
                if ((result & (Check.BackslashInPath | Check.ReservedFound | Check.NotIriCanonical)) != 0)
                {
                    return false;
                }

                if ((result & (Check.DisplayCanonical | Check.EscapedCanonical)) == 0)
                {
                    return false;
                }

                if (!iriParsing && (result & Check.FoundNonAscii) != 0)
                {
                    // If we are not Iri parsing, we cannot have non-ascii characters in the path
                    return false;
                }
            }
        }

        if (idx < length && uriString[idx] == '?')
        {
            // Move past the delimiter
            idx++;
            if (idx < length)
            {
                // Check the query
                fixed (byte* str = uriString)
                {
                    Check result = CheckCanonical(str, ref idx, length, (hashIdx >= 0) ? (byte)'#' : c_EOL, iriParsing, queryIdx >= 0, hashIdx >= 0);
                    if ((result & (Check.BackslashInPath | Check.ReservedFound | Check.NotIriCanonical)) != 0)
                    {
                        return false;
                    }

                    if (!iriParsing && (result & Check.FoundNonAscii) != 0)
                    {
                        // If we are not Iri parsing, we cannot have non-ascii characters in the query
                        return false;
                    }
                }
            }
        }

        if (idx < length && uriString[idx] == '#')
        {
            // Move past the deliimiter
            idx++;
            if (idx < length)
            {
                // Check the fragment
                fixed (byte* str = uriString)
                {
                    Check result = CheckCanonical(str, ref idx, length, c_EOL, iriParsing, queryIdx >= 0, hashIdx >= 0);
                    if ((result & (Check.BackslashInPath | Check.ReservedFound | Check.NotIriCanonical)) != 0)
                    {
                        return false;
                    }

                    if (!iriParsing && (result & Check.FoundNonAscii) != 0)
                    {
                        // If we are not Iri parsing, we cannot have non-ascii characters in the query
                        return false;
                    }
                }
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ParseCore(Utf8UriParsingError err, ref Flags flags, ref Utf8UriParser syntax, Utf8UriKind uriKind, ReadOnlySpan<byte> uriString, bool requireAbsolute, bool allowUNCPath, out Utf8UriOffset uriInfo)
    {
        Debug.Assert(err == Utf8UriParsingError.None);

        Utf8UriOffset info = default;
        info.End = (ushort)uriString.Length;

        if (IsImplicitFile(flags))
        {
            // V1 compat
            // A relative Uri wins over implicit UNC path unless the UNC path is of the form "\\something" and
            // uriKind != Absolute
            // A relative Uri wins over implicit Unix path unless uriKind == Absolute

            if (NotAny(flags, Flags.DosPath) &&
                uriKind != Utf8UriKind.Absolute &&
                ((uriKind == Utf8UriKind.Relative || (uriString.Length >= 2 && (uriString[0] != (byte)'\\' || uriString[1] != (byte)'\\')))
#if NET
            || (!OperatingSystem.IsWindows() && InFact(flags, Flags.UnixPath))
#endif
            ))
            {
                flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri
                GetUriInfoForQueryAndFragment(uriString, ref info, out _, out _);
                syntax = null!; //make it be relative Uri
                uriInfo =
                    new()
                    {
                        Query = info.Query,
                        Fragment = info.Fragment,
                        End = info.End
                    };
                return requireAbsolute ? false : true;
                // Otherwise an absolute file Uri wins when it's of the form "\\something"
            }
            //
            // V1 compat issue
            // We should support relative Uris of the form c:\bla or c:/bla
            //
            else if (uriKind != Utf8UriKind.Absolute && InFact(flags, Flags.DosPath))
            {
                flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri
                GetUriInfoForQueryAndFragment(uriString, ref info, out _, out _);
                syntax = null!; //make it be relative Uri
                uriInfo =
                    new()
                    {
                        Query = info.Query,
                        Fragment = info.Fragment,
                        End = info.End
                    };
                return requireAbsolute ? false : true;
                // Otherwise an absolute file Uri wins when it's of the form "c:\something"
            }
        }

        if (IriParsing(syntax) && CheckForUnicodeOrEscapedUnreserved(uriString, out Flags localFlags))
        {
            flags |= localFlags;
        }

        bool success = true;

        if (syntax != null)
        {
            if ((err = PrivateParseMinimal(uriString, ref flags, ref syntax)) != Utf8UriParsingError.None)
            {
                if (uriKind != Utf8UriKind.Absolute && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
                {
                    // RFC 3986 Section 5.4.2 - http:(relativeUri) may be considered a valid relative Uri.
                    int offset = syntax.SchemeName.Length + 1;
                    bool result = GetUriInfoForRelativeReference(uriString.Slice(offset), IriParsing(syntax), out info);
                    uriInfo =
                        new()
                        {
                            Scheme = (ushort)offset,
                            End = (ushort)(info.End + offset),
                            User = (ushort)offset,
                            Host = (ushort)offset,
                            Port = (ushort)offset,
                            PortValue = 0,
                            Path = (ushort)(info.Path + offset),
                            Query = (ushort)(info.Query + offset),
                            Fragment = (ushort)(info.Fragment + offset)
                        };

                    syntax = null!; // convert to relative uri
                    flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri
                    return result;
                }
                else
                    success = false;
            }
            else if (uriKind == Utf8UriKind.Relative)
            {
                // Here we know that we can create an absolute Uri, but the user has requested only a relative one
                success = false;
            }
            else
            {
                success = true;
            }
            // will return from here

            // In this scenario we need to parse the whole string
            if (!success || !ValidateRemaining(err, ref flags, syntax, uriKind, uriString, out info))
            {
                uriInfo = default;
                return false;
            }
        }
        // If we encountered any parsing errors that indicate this may be a relative Uri,
        // and we'll allow relative Uri's, then create one.
        else if (err != Utf8UriParsingError.None && uriKind != Utf8UriKind.Absolute
            && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
        {
            success = true;
            flags &= (Flags.UserEscaped | Flags.HasUnicode); // the only flags that makes sense for a relative uri
        }
        else
        {
            success = false;
        }

        if (!allowUNCPath && (flags & Flags.UncPath) != 0)
        {
            uriInfo = default;
            return false;
        }

        uriInfo = success ? info : default;
        return success;
    }

    private static bool ValidateCore(Utf8UriParsingError err, ref Flags flags, ref Utf8UriParser syntax, Utf8UriKind uriKind, ReadOnlySpan<byte> uriString, bool requireAbsolute, bool allowUNCPath)
    {
        if (err == Utf8UriParsingError.None)
        {
            if (IsImplicitFile(flags))
            {
                // V1 compat
                // A relative Uri wins over implicit UNC path unless the UNC path is of the form "\\something" and
                // uriKind != Absolute
                // A relative Uri wins over implicit Unix path unless uriKind == Absolute
                if (NotAny(flags, Flags.DosPath) &&
                    uriKind != Utf8UriKind.Absolute &&
                   ((uriKind == Utf8UriKind.Relative || (uriString.Length >= 2 && (uriString[0] != (byte)'\\' || uriString[1] != (byte)'\\')))
#if NET
                || (!OperatingSystem.IsWindows() && InFact(flags, Flags.UnixPath))
#endif
                ))
                {
                    syntax = null!; //make it be relative Uri
                    flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri

                    if (CheckForUnicodeOrEscapedUnreserved(uriString, out Flags localFlags))
                    {
                        flags |= localFlags;
                    }

                    return requireAbsolute ? false : true;
                    // Otherwise an absolute file Uri wins when it's of the form "\\something"
                }
                //
                // V1 compat issue
                // We should support relative Uris of the form c:\bla or c:/bla
                //
                else if (uriKind != Utf8UriKind.Absolute && InFact(flags, Flags.DosPath))
                {
                    syntax = null!; //make it be relative Uri
                    flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri
                    return requireAbsolute ? false : true;
                    // Otherwise an absolute file Uri wins when it's of the form "c:\something"
                }
            }
        }
        else if (err > Utf8UriParsingError.LastRelativeUriOkErrIndex)
        {
            //This is a fatal error based solely on scheme name parsing
            return false;
        }

        if (IriParsing(syntax) && CheckForUnicodeOrEscapedUnreserved(uriString, out Flags localFlags2))
        {
            flags |= localFlags2;
        }

        bool success = true;

        if (syntax != null)
        {
            if ((err = PrivateParseMinimal(uriString, ref flags, ref syntax)) != Utf8UriParsingError.None)
            {
                if (uriKind != Utf8UriKind.Absolute && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
                {
                    // RFC 3986 Section 5.4.2 - http:(relativeUri) may be considered a valid relative Uri.
                    syntax = null!; // convert to relative uri
                    flags &= Flags.UserEscaped; // the only flag that makes sense for a relative uri
                    return true;
                }
                else
                    success = false;
            }
            else if (uriKind == Utf8UriKind.Relative)
            {
                // Here we know that we can create an absolute Uri, but the user has requested only a relative one
                success = false;
            }
            else
            {
                success = true;
            }
            // will return from here

            // In this scenario we need to parse the whole string
            if (!success || !ValidateRemaining(err, ref flags, syntax, uriKind, uriString, out _))
            {
                return false;
            }
        }
        // If we encountered any parsing errors that indicate this may be a relative Uri,
        // and we'll allow relative Uri's, then create one.
        else if (err != Utf8UriParsingError.None && uriKind != Utf8UriKind.Absolute
            && err <= Utf8UriParsingError.LastRelativeUriOkErrIndex)
        {
            success = true;
            flags &= (Flags.UserEscaped | Flags.HasUnicode); // the only flags that makes sense for a relative uri
        }
        else
        {
            success = false;
        }

        if (!allowUNCPath && (flags & Flags.UncPath) != 0)
        {
            return false;
        }

        return success;
    }

    private static Utf8UriOffset EnsureUriInfo(Utf8UriParser syntax, ref Flags flags, ReadOnlySpan<byte> uriString)
    {
        Debug.Assert((flags & Flags.MinimalUriInfoSet) == 0);
        return CreateUriInfo(syntax, ref flags, uriString);
    }

    //
    //
    // The method is called when we have to access info members.
    // This will create the info based on the copied parser context.
    // If multi-threading, this method may do duplicated yet harmless work.
    //
    private static unsafe Utf8UriOffset CreateUriInfo(Utf8UriParser syntax, ref Flags flags, ReadOnlySpan<byte> uriString)
    {
        Utf8UriOffset info = new Utf8UriOffset();

        // This will be revisited in ParseRemaining but for now just have it at least uriString.Length
        info.End = (ushort)uriString.Length;

        if (UserDrivenParsing(flags))
            goto Done;

        int idx;
        bool notCanonicalScheme = false;

        // The uriString may have leading spaces, figure that out
        // plus it will set idx value for next steps
        if ((flags & Flags.ImplicitFile) != 0)
        {
            idx = 0;
            while (Utf8UriHelper.IsLWS(uriString[idx]))
            {
                ++idx;
                ++info.Scheme;
            }

            if (InFact(flags, Flags.UncPath))
            {
                // For implicit file AND Unc only
                idx += 2;
                //skip any other slashes (compatibility with V1.0 parser)
                int end = (int)(flags & Flags.IndexMask);
                while (idx < end && (uriString[idx] == (byte)'/' || uriString[idx] == (byte)'\\'))
                {
                    ++idx;
                }
            }
        }
        else
        {
            // This is NOT an ImplicitFile uri
            idx = syntax.SchemeName.Length;

            while (uriString[idx++] != (byte)':')
            {
                ++info.Scheme;
            }

            if ((flags & Flags.AuthorityFound) != 0)
            {
                if (uriString[idx] == (byte)'\\' || uriString[idx + 1] == (byte)'\\')
                    notCanonicalScheme = true;

                idx += 2;
                if ((flags & (Flags.UncPath | Flags.DosPath)) != 0)
                {
                    // Skip slashes if it was allowed during ctor time
                    // NB: Today this is only allowed if a Unc or DosPath was found after the scheme
                    int end = (int)(flags & Flags.IndexMask);
                    while (idx < end && (uriString[idx] == (byte)'/' || uriString[idx] == (byte)'\\'))
                    {
                        notCanonicalScheme = true;
                        ++idx;
                    }
                }
            }
        }

        // Some schemes (mailto) do not have Authority-based syntax, still they do have a port
        if (syntax.DefaultPort != Utf8UriParser.NoDefaultPort)
            info.PortValue = (ushort)syntax.DefaultPort;

        //Here we set the indexes for already parsed components
        if ((flags & Flags.HostTypeMask) == Flags.UnknownHostType
            || InFact(flags, Flags.DosPath)
            )
        {
            //there is no Authority component defined
            info.User = (ushort)(flags & Flags.IndexMask);
            info.Host = info.User;
            info.Path = info.User;
            info.Port = info.User;
            flags &= ~Flags.IndexMask;
            if (notCanonicalScheme)
            {
                flags |= Flags.SchemeNotCanonical;
            }
            goto Done;
        }

        info.User = (ushort)idx;

        //Basic Host Type does not have userinfo and port
        if (HostType(flags) == Flags.BasicHostType)
        {
            info.Host = (ushort)idx;
            info.Path = (ushort)(flags & Flags.IndexMask);
            flags &= ~Flags.IndexMask;
            goto Done;
        }

        if ((flags & Flags.HasUserInfo) != 0)
        {
            // we previously found a userinfo, get it again
            while (uriString[idx] != '@')
            {
                ++idx;
            }
            ++idx;
            info.Host = (ushort)idx;
        }
        else
        {
            info.Host = (ushort)idx;
        }

        //Now reload the end of the parsed host

        idx = (int)(flags & Flags.IndexMask);

        //From now on we do not need IndexMask bits, and reuse the space for X_NotCanonical flags
        //clear them now
        flags &= ~Flags.IndexMask;

        // If this is not canonical, don't count on user input to be good
        if (notCanonicalScheme)
        {
            flags |= Flags.SchemeNotCanonical;
        }

        //Guessing this is a path start
        info.Path = (ushort)idx;

        // parse Port if any. The new spec allows a port after ':' to be empty (assuming default?)
        bool notEmpty = false;
        // Note we already checked on general port syntax in ParseMinimal()

        if (idx < info.End)
        {
            fixed (byte* userString = uriString)
            {
                if (userString[idx] == (byte)':')
                {
                    int port = 0;
                    info.Port = (ushort)idx;
                    //Check on some non-canonical cases http://host:0324/, http://host:03, http://host:0, etc
                    if (++idx < info.End)
                    {
                        port = userString[idx] - (byte)'0';
                        if ((uint)port <= ((byte)'9' - (byte)'0'))
                        {
                            notEmpty = true;
                            if (port == 0)
                            {
                                flags |= (Flags.PortNotCanonical | Flags.E_PortNotCanonical);
                            }
                            for (++idx; idx < info.End; ++idx)
                            {
                                int val = userString[idx] - (byte)'0';
                                if ((uint)val > ((byte)'9' - (byte)'0'))
                                {
                                    break;
                                }
                                port = (port * 10 + val);
                            }
                        }
                    }
                    if (notEmpty && syntax.DefaultPort != port)
                    {
                        info.PortValue = (ushort)port;
                        flags |= Flags.NotDefaultPort;
                    }
                    else
                    {
                        //This will tell that we do have a ':' but the port value does
                        //not follow to canonical rules
                        flags |= (Flags.PortNotCanonical | Flags.E_PortNotCanonical);
                    }
                    info.Path = (ushort)idx;
                }
            }
        }

    Done:
        flags |= Flags.MinimalUriInfoSet;
        return info;
    }

    //
    //This method does:
    //  - Creates info member
    //  - checks all components up to path on their canonical representation
    //  - continues parsing starting the path position
    //  - Sets the offsets of remaining components
    //  - Sets the Canonicalization flags if applied
    //
    private static unsafe bool ValidateRemaining(Utf8UriParsingError err, ref Flags flags, Utf8UriParser syntax, Utf8UriKind uriKind, ReadOnlySpan<byte> uriString, out Utf8UriOffset uriInfo)
    {
        // ensure we parsed up to the path
        Utf8UriOffset info = EnsureUriInfo(syntax, ref flags, uriString);

        Flags cF = Flags.Zero;

        if (UserDrivenParsing(flags))
            goto Done;

        // Do we have to continue building Iri'zed string from original string
        int idx = info.Scheme;
        int length = uriString.Length;
        Check result = Check.None;
        Utf8UriSyntaxFlags syntaxFlags = syntax.Flags;

        fixed (byte* str = uriString)
        {
            GetLengthWithoutTrailingSpaces(uriString, ref length, idx);

            if (IsImplicitFile(flags))
            {
                cF |= Flags.SchemeNotCanonical;
            }
            else
            {
                int i;
                string schemeName = syntax.SchemeName;
                for (i = 0; i < schemeName.Length; ++i)
                {
                    if (schemeName[i] != str[idx + i])
                        cF |= Flags.SchemeNotCanonical;
                }
                // For an authority Uri only // after the scheme would be canonical
                // (for compatibility with: http:\\host)
                if (((flags & Flags.AuthorityFound) != 0) && (idx + i + 3 >= length || str[idx + i + 1] != (byte)'/' ||
                    str[idx + i + 2] != (byte)'/'))
                {
                    cF |= Flags.SchemeNotCanonical;
                }
            }

            //Check the form of the user info
            if ((flags & Flags.HasUserInfo) != 0)
            {
                idx = info.User;
                result = CheckCanonical(str, ref idx, info.Host, (byte)'@', syntax, ref flags);
                if ((result & Check.DisplayCanonical) == 0)
                {
                    cF |= Flags.UserNotCanonical;
                }
                if ((result & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
                {
                    cF |= Flags.E_UserNotCanonical;
                }
                if (IriParsing(syntax) && ((result & (Check.DisplayCanonical | Check.EscapedCanonical | Check.BackslashInPath
                                                | Check.FoundNonAscii | Check.NotIriCanonical))
                                                == (Check.DisplayCanonical | Check.FoundNonAscii)))
                {
                    cF |= Flags.UserIriCanonical;
                }
            }
        }
        //
        // We have already checked on the port in EnsureUriInfo() that calls CreateUriInfo
        //
        //
        // Parsing the Path if any
        //
        // For iri parsing if we found unicode the idx has offset into _originalUnicodeString..
        // so restart parsing from there and make info.Path as uriString.Length

        idx = info.Path;

        fixed (byte* str = uriString)
        {
            if (IsImplicitFile(flags) || ((syntaxFlags & (Utf8UriSyntaxFlags.MayHaveQuery | Utf8UriSyntaxFlags.MayHaveFragment)) == 0))
            {
                result = CheckCanonical(str, ref idx, length, c_EOL, syntax, ref flags);
            }
            else
            {
                result = CheckCanonical(str, ref idx, length, (((syntaxFlags & Utf8UriSyntaxFlags.MayHaveQuery) != 0)
                    ? (byte)'?' : syntax.InFact(Utf8UriSyntaxFlags.MayHaveFragment) ? (byte)'#' : c_EOL), syntax, ref flags);
            }

            // ATTN:
            // This may render problems for unknown schemes, but in general for an authority based Uri
            // (that has slashes) a path should start with "/"
            // This becomes more interesting knowing how a file uri is used in "file://c:/path"
            // It will be converted to file:///c:/path
            //
            // However, even more interesting is that vsmacros://c:\path will not add the third slash in the _canoical_ case
            //
            // We use special syntax flag to check if the path is rooted, i.e. has a first slash
            //
            if (((flags & Flags.AuthorityFound) != 0) && ((syntaxFlags & Utf8UriSyntaxFlags.PathIsRooted) != 0)
                && (info.Path == length || (str[info.Path] != '/' && str[info.Path] != (byte)'\\')))
            {
                cF |= Flags.FirstSlashAbsent;
            }
        }
        // Check the need for compression or backslashes conversion
        // we included IsDosPath since it may come with other than FILE uri, for ex. scheme://C:\path
        // (This is very unfortunate that the original design has included that feature)
        bool nonCanonical = false;
        if (IsDosPath(flags) || (((flags & Flags.AuthorityFound) != 0) &&
            (((syntaxFlags & (Utf8UriSyntaxFlags.CompressPath | Utf8UriSyntaxFlags.ConvertPathSlashes)) != 0) ||
            syntax.InFact(Utf8UriSyntaxFlags.UnEscapeDotsAndSlashes))))
        {
            if (((result & Check.DotSlashEscaped) != 0) && syntax.InFact(Utf8UriSyntaxFlags.UnEscapeDotsAndSlashes))
            {
                cF |= (Flags.E_PathNotCanonical | Flags.PathNotCanonical);
                nonCanonical = true;
            }

            if (((syntaxFlags & (Utf8UriSyntaxFlags.ConvertPathSlashes)) != 0) && (result & Check.BackslashInPath) != 0)
            {
                cF |= Flags.PathNotCanonical;

                if (!IsDosPath(flags))
                {
                    cF |= Flags.E_PathNotCanonical;
                }

                nonCanonical = true;
            }

            if (((syntaxFlags & (Utf8UriSyntaxFlags.CompressPath)) != 0) && ((cF & Flags.E_PathNotCanonical) != 0 ||
                (result & Check.DotSlashAttn) != 0))
            {
                cF |= Flags.ShouldBeCompressed;
            }

            if ((result & Check.BackslashInPath) != 0)
                cF |= Flags.BackslashInPath;
        }
        else if ((result & Check.BackslashInPath) != 0)
        {
            // for a "generic" path '\' should be escaped
            cF |= Flags.E_PathNotCanonical;
            nonCanonical = true;
        }

        if ((result & Check.DisplayCanonical) == 0)
        {
            // For implicit file the user string is usually in perfect display format,
            // Hence, ignoring complains from CheckCanonical()
            // V1 compat. In fact we should simply ignore dontEscape parameter for Implicit file.
            // Currently we don't.
            if (((flags & Flags.ImplicitFile) == 0) || ((flags & Flags.UserEscaped) != 0) ||
                (result & Check.ReservedFound) != 0)
            {
                //means it's found as escaped or has unescaped Reserved Characters
                cF |= Flags.PathNotCanonical;
                nonCanonical = true;
            }
        }

        if (((flags & Flags.ImplicitFile) != 0) && (result & (Check.ReservedFound | Check.EscapedCanonical)) != 0)
        {
            // need to escape reserved chars or re-escape '%' if an "escaped sequence" was found
            result &= ~Check.EscapedCanonical;
        }

        if ((result & Check.EscapedCanonical) == 0)
        {
            //means it's found as not completely escaped
            cF |= Flags.E_PathNotCanonical;
        }

        if (IriParsing(syntax) && !nonCanonical && ((result & (Check.DisplayCanonical | Check.EscapedCanonical
                        | Check.FoundNonAscii | Check.NotIriCanonical))
                        == (Check.DisplayCanonical | Check.FoundNonAscii)))
        {
            cF |= Flags.PathIriCanonical;
        }

        //
        //Now we've got to parse the Query if any. Note that Query requires the presence of '?'
        //

        info.Query = (ushort)idx;

        fixed (byte* str = uriString)
        {
            if (idx < length && str[idx] == '?')
            {
                ++idx; // This is to exclude first '?' character from checking
                result = CheckCanonical(str, ref idx, length, ((syntaxFlags & (Utf8UriSyntaxFlags.MayHaveFragment)) != 0)
                    ? (byte)'#' : c_EOL, syntax, ref flags);

                if ((result & Check.DisplayCanonical) == 0)
                {
                    cF |= Flags.QueryNotCanonical;
                }

                if (IriParsing(syntax) && ((result & (Check.DisplayCanonical | Check.EscapedCanonical | Check.BackslashInPath
                            | Check.FoundNonAscii | Check.NotIriCanonical))
                            == (Check.DisplayCanonical | Check.FoundNonAscii)))
                {
                    cF |= Flags.QueryIriCanonical;
                }

                if ((result & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
                {
                    if ((cF & Flags.QueryIriCanonical) == 0)
                    {
                        cF |= Flags.E_QueryNotCanonical;
                    }
                }
            }
        }

        info.Fragment = (ushort)idx;

        fixed (byte* str = uriString)
        {
            if (idx < length && str[idx] == (byte)'#')
            {
                ++idx; // This is to exclude first '#' character from checking
                //We don't using c_DummyChar since want to allow '?' and '#' as unescaped
                result = CheckCanonical(str, ref idx, length, c_EOL, syntax, ref flags);
                if ((result & Check.DisplayCanonical) == 0)
                {
                    cF |= Flags.FragmentNotCanonical;
                }

                if (IriParsing(syntax) && ((result & (Check.DisplayCanonical | Check.EscapedCanonical | Check.BackslashInPath
                            | Check.FoundNonAscii | Check.NotIriCanonical))
                            == (Check.DisplayCanonical | Check.FoundNonAscii)))
                {
                    cF |= Flags.FragmentIriCanonical;
                }

                if ((result & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
                {
                    if ((cF & Flags.FragmentIriCanonical) == 0)
                    {
                        cF |= Flags.E_FragmentNotCanonical;
                    }
                }
            }
        }
        info.End = (ushort)idx;

    Done:
        cF |= Flags.AllUriInfoSet;

        uriInfo = info;
        return (IriParsing(syntax) && ((cF & Flags.IriCanonical) != 0)) || (cF & Flags.E_NonCanonical) == 0;
    }

    //
    // Used by ParseRemaining
    //
    private static unsafe Check CheckCanonical(byte* str, ref int idx, int end, byte delim, Utf8UriParser syntax, ref Flags flags)
    {
        Check res = Check.None;
        bool needsEscaping = false;
        bool foundEscaping = false;
        bool iriParsing = IriParsing(syntax);

        byte c;
        int i = idx;
        for (; i < end;)
        {
            int bytesConsumed = 1;
            c = str[i];

            // Fast path for common ASCII characters that don't need special handling
            if ((c >= (byte)'A' && c <= (byte)'Z') || (c >= (byte)'a' && c <= (byte)'z') || (c >= (byte)'0' && c <= (byte)'9'))
            {
                // alphanumeric characters are always safe
                i++;
                continue;
            }

            // Control chars usually should be escaped in any case
            if (c <= (byte)'\x1F' || (c >= (byte)'\x7F' && c <= (byte)'\x9F'))
            {
                needsEscaping = true;
                foundEscaping = true;
                res |= Check.ReservedFound;
            }
            else if (c > '~')
            {
                if (iriParsing)
                {
                    res |= Check.FoundNonAscii;
                    Rune.DecodeFromUtf8(new ReadOnlySpan<byte>(str + i, end - i), out Rune rune, out bytesConsumed);

                    if (!Utf8IriHelper.CheckIriUnicodeRange((uint)rune.Value, true))
                    {
                        res |= Check.NotIriCanonical;
                    }
                }

                needsEscaping = true;
            }
            else if (c == delim)
            {
                break;
            }
            else if (delim == (byte)'?' && c == (byte)'#' && (syntax != null && syntax.InFact(Utf8UriSyntaxFlags.MayHaveFragment)))
            {
                // this is a special case when deciding on Query/Fragment
                break;
            }
            else if (c == (byte)'?')
            {
                if (IsImplicitFile(flags) || (syntax != null && !syntax.InFact(Utf8UriSyntaxFlags.MayHaveQuery)
                    && delim != c_EOL))
                {
                    // If found as reserved this char is not suitable for safe unescaped display
                    // Will need to escape it when both escaping and unescaping the string
                    res |= Check.ReservedFound;
                    foundEscaping = true;
                    needsEscaping = true;
                }
            }
            else if (c == (byte)'#')
            {
                needsEscaping = true;
                if (IsImplicitFile(flags) || (syntax != null && !syntax.InFact(Utf8UriSyntaxFlags.MayHaveFragment)))
                {
                    // If found as reserved this char is not suitable for safe unescaped display
                    // Will need to escape it when both escaping and unescaping the string
                    res |= Check.ReservedFound;
                    foundEscaping = true;
                }
            }
            else if (c == (byte)'/' || c == (byte)'\\')
            {
                if ((res & Check.BackslashInPath) == 0 && c == (byte)'\\')
                {
                    res |= Check.BackslashInPath;
                }
                if ((res & Check.DotSlashAttn) == 0 && i + 1 != end && (str[i + 1] == (byte)'/' || str[i + 1] == (byte)'\\'))
                {
                    res |= Check.DotSlashAttn;
                }
            }
            else if (c == (byte)'.')
            {
                if ((res & Check.DotSlashAttn) == 0 && i + 1 == end || str[i + 1] == (byte)'.' || str[i + 1] == (byte)'/'
                    || str[i + 1] == (byte)'\\' || str[i + 1] == (byte)'?' || str[i + 1] == (byte)'#')
                {
                    res |= Check.DotSlashAttn;
                }
            }
            else if (((c <= (byte)'"' && c != (byte)'!') || (c >= (byte)'[' && c <= (byte)'^') || c == (byte)'>'
                    || c == (byte)'<' || c == (byte)'`'))
            {
                needsEscaping = true;

                // The check above validates only that we have valid IRI characters, which is not enough to
                // conclude that we have a valid canonical IRI.
                // If we have an IRI with Flags.HasUnicode, we need to set Check.NotIriCanonical so that the
                // path, query, and fragment will be validated.
                if ((flags & Flags.HasUnicode) != 0)
                {
                    res |= Check.NotIriCanonical;
                }
            }
            else if (c >= (byte)'{' && c <= (byte)'}') // includes '{', '|', '}'
            {
                needsEscaping = true;
            }
            else if (c == (byte)'%')
            {
                foundEscaping = true;
                //try unescape a byte hex escaping
                if (i + 2 < end)
                {
                    int unescaped = Utf8UriHelper.DecodeHexChars(str[i + 1], str[i + 2]);
                    if (unescaped != c_DummyChar)
                    {
                        byte unescapedByte = (byte)unescaped;
                        if (unescapedByte == (byte)'.' || unescapedByte == (byte)'/' || unescapedByte == (byte)'\\')
                        {
                            res |= Check.DotSlashEscaped;
                        }

                        i += 3; // Skip the '%' and two hex digits
                        continue;
                    }
                }

                // otherwise we follow to non escaped case
                needsEscaping = true;
            }

            i += bytesConsumed;
        }

        if (foundEscaping)
        {
            if (!needsEscaping)
            {
                res |= Check.EscapedCanonical;
            }
        }
        else
        {
            if (!needsEscaping)
            {
                res |= Check.EscapedCanonical;
            }
            else
            {
                res |= Check.DisplayCanonical;
            }
        }
        idx = i;
        return res;
    }

    // Used by relative reference validation
    private static unsafe Check CheckCanonical(byte* str, ref int idx, int end, byte delim, bool iriParsing, bool mayHaveQuery, bool mayHaveFragment)
    {
        Check res = Check.None;
        bool needsEscaping = false;
        bool foundEscaping = false;

        byte c;
        int i = idx;
        for (; i < end;)
        {
            int bytesConsumed = 1;
            c = str[i];

            // Fast path for common ASCII characters that don't need special handling
            if ((c >= (byte)'A' && c <= (byte)'Z') || (c >= (byte)'a' && c <= (byte)'z') || (c >= (byte)'0' && c <= (byte)'9'))
            {
                // alphanumeric characters are always safe
                i++;
                continue;
            }

            // Control chars usually should be escaped in any case
            if (c <= (byte)'\x1F' || (c >= (byte)'\x7F' && c <= (byte)'\x9F'))
            {
                needsEscaping = true;
                foundEscaping = true;
                res |= Check.ReservedFound;
            }
            else if (c > '~')
            {
                if (iriParsing)
                {
                    res |= Check.FoundNonAscii;
                    Rune.DecodeFromUtf8(new ReadOnlySpan<byte>(str + i, end - i), out Rune rune, out bytesConsumed);

                    if (!Utf8IriHelper.CheckIriUnicodeRange((uint)rune.Value, true))
                    {
                        res |= Check.NotIriCanonical;
                    }
                }

                needsEscaping = true;
            }
            else if (c == delim)
            {
                break;
            }
            else if (delim == (byte)'?' && c == (byte)'#' && mayHaveFragment)
            {
                // this is a special case when deciding on Query/Fragment
                break;
            }
            else if (c == (byte)'?')
            {
                if (!mayHaveQuery && delim != c_EOL)
                {
                    // If found as reserved this char is not suitable for safe unescaped display
                    // Will need to escape it when both escaping and unescaping the string
                    res |= Check.ReservedFound;
                    foundEscaping = true;
                    needsEscaping = true;
                }
            }
            else if (c == (byte)'#')
            {
                needsEscaping = true;
                if (!mayHaveFragment)
                {
                    // If found as reserved this char is not suitable for safe unescaped display
                    // Will need to escape it when both escaping and unescaping the string
                    res |= Check.ReservedFound;
                    foundEscaping = true;
                }
            }
            else if (c == (byte)'/' || c == (byte)'\\')
            {
                if ((res & Check.BackslashInPath) == 0 && c == (byte)'\\')
                {
                    res |= Check.BackslashInPath;
                }
                if ((res & Check.DotSlashAttn) == 0 && i + 1 != end && (str[i + 1] == (byte)'/' || str[i + 1] == (byte)'\\'))
                {
                    res |= Check.DotSlashAttn;
                }
            }
            else if (c == (byte)'.')
            {
                if ((res & Check.DotSlashAttn) == 0 && i + 1 == end || str[i + 1] == (byte)'.' || str[i + 1] == (byte)'/'
                    || str[i + 1] == (byte)'\\' || str[i + 1] == (byte)'?' || str[i + 1] == (byte)'#')
                {
                    res |= Check.DotSlashAttn;
                }
            }
            else if (((c <= (byte)'"' && c != (byte)'!') || (c >= (byte)'[' && c <= (byte)'^') || c == (byte)'>'
                    || c == (byte)'<' || c == (byte)'`'))
            {
                needsEscaping = true;

                // The check above validates only that we have valid IRI characters, which is not enough to
                // conclude that we have a valid canonical IRI.
                // If we have an IRI with Flags.HasUnicode, we need to set Check.NotIriCanonical so that the
                // path, query, and fragment will be validated.
                if (iriParsing)
                {
                    res |= Check.NotIriCanonical;
                }
            }
            else if (c >= (byte)'{' && c <= (byte)'}') // includes '{', '|', '}'
            {
                needsEscaping = true;
            }
            else if (c == (byte)'%')
            {
                if (!foundEscaping) foundEscaping = true;
                //try unescape a byte hex escaping
                if (i + 2 < end)
                {
                    int unescaped = Utf8UriHelper.DecodeHexChars(str[i + 1], str[i + 2]);
                    if (unescaped != c_DummyChar)
                    {
                        byte unescapedByte = (byte)unescaped;
                        if (unescapedByte == (byte)'.' || unescapedByte == (byte)'/' || unescapedByte == (byte)'\\')
                        {
                            res |= Check.DotSlashEscaped;
                        }

                        i += 3; // Skip the '%' and two hex digits
                        continue;
                    }
                }

                // otherwise we follow to non escaped case
                needsEscaping = true;
            }

            i += bytesConsumed;
        }

        if (foundEscaping)
        {
            if (!needsEscaping)
            {
                res |= Check.EscapedCanonical;
            }
        }
        else
        {
            if (!needsEscaping)
            {
                res |= Check.EscapedCanonical;
            }
            else
            {
                res |= Check.DisplayCanonical | Check.FoundNonAscii;
            }
        }
        idx = i;
        return res;
    }

    private static void GetLengthWithoutTrailingSpaces(ReadOnlySpan<byte> uriString, ref int length, int idx)
    {
        // Early exit if no trimming needed
        if (length <= idx)
        {
            return;
        }

        // Check if last character is whitespace before entering loop
        if (!Utf8UriHelper.IsLWS(uriString[length - 1]))
        {
            return;
        }

        // to avoid dereferencing ref length parameter for every update
        int local = length - 1;
        while (local > idx && Utf8UriHelper.IsLWS(uriString[local]))
        {
            --local;
        }
        length = local + 1; // Adjust for the fact we decremented past the last non-whitespace
    }

#if NET

    private static readonly SearchValues<byte> s_asciiOtherThanPercent = SearchValues.Create([
        0x0000, 0x0001, 0x0002, 0x0003, 0x0004, 0x0005, 0x0006, 0x0007, 0x0008, 0x0009, 0x000A, 0x000B, 0x000C, 0x000D, 0x000E, 0x000F,
        0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015, 0x0016, 0x0017, 0x0018, 0x0019, 0x001A, 0x001B, 0x001C, 0x001D, 0x001E, 0x001F,
        0x0020, 0x0021, 0x0022, 0x0023, 0x0024, /* % */ 0x0026, 0x0027, 0x0028, 0x0029, 0x002A, 0x002B, 0x002C, 0x002D, 0x002E, 0x002F,
        0x0030, 0x0031, 0x0032, 0x0033, 0x0034, 0x0035, 0x0036, 0x0037, 0x0038, 0x0039, 0x003A, 0x003B, 0x003C, 0x003D, 0x003E, 0x003F,
        0x0040, 0x0041, 0x0042, 0x0043, 0x0044, 0x0045, 0x0046, 0x0047, 0x0048, 0x0049, 0x004A, 0x004B, 0x004C, 0x004D, 0x004E, 0x004F,
        0x0050, 0x0051, 0x0052, 0x0053, 0x0054, 0x0055, 0x0056, 0x0057, 0x0058, 0x0059, 0x005A, 0x005B, 0x005C, 0x005D, 0x005E, 0x005F,
        0x0060, 0x0061, 0x0062, 0x0063, 0x0064, 0x0065, 0x0066, 0x0067, 0x0068, 0x0069, 0x006A, 0x006B, 0x006C, 0x006D, 0x006E, 0x006F,
        0x0070, 0x0071, 0x0072, 0x0073, 0x0074, 0x0075, 0x0076, 0x0077, 0x0078, 0x0079, 0x007A, 0x007B, 0x007C, 0x007D, 0x007E, 0x007F,
        ]);

#else
    private static ReadOnlySpan<byte> s_asciiOtherThanPercent => [
        0x0000, 0x0001, 0x0002, 0x0003, 0x0004, 0x0005, 0x0006, 0x0007, 0x0008, 0x0009, 0x000A, 0x000B, 0x000C, 0x000D, 0x000E, 0x000F,
        0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015, 0x0016, 0x0017, 0x0018, 0x0019, 0x001A, 0x001B, 0x001C, 0x001D, 0x001E, 0x001F,
        0x0020, 0x0021, 0x0022, 0x0023, 0x0024, /* % */ 0x0026, 0x0027, 0x0028, 0x0029, 0x002A, 0x002B, 0x002C, 0x002D, 0x002E, 0x002F,
        0x0030, 0x0031, 0x0032, 0x0033, 0x0034, 0x0035, 0x0036, 0x0037, 0x0038, 0x0039, 0x003A, 0x003B, 0x003C, 0x003D, 0x003E, 0x003F,
        0x0040, 0x0041, 0x0042, 0x0043, 0x0044, 0x0045, 0x0046, 0x0047, 0x0048, 0x0049, 0x004A, 0x004B, 0x004C, 0x004D, 0x004E, 0x004F,
        0x0050, 0x0051, 0x0052, 0x0053, 0x0054, 0x0055, 0x0056, 0x0057, 0x0058, 0x0059, 0x005A, 0x005B, 0x005C, 0x005D, 0x005E, 0x005F,
        0x0060, 0x0061, 0x0062, 0x0063, 0x0064, 0x0065, 0x0066, 0x0067, 0x0068, 0x0069, 0x006A, 0x006B, 0x006C, 0x006D, 0x006E, 0x006F,
        0x0070, 0x0071, 0x0072, 0x0073, 0x0074, 0x0075, 0x0076, 0x0077, 0x0078, 0x0079, 0x007A, 0x007B, 0x007C, 0x007D, 0x007E, 0x007F,
        ];
#endif

    /// <summary>
    /// Unescapes entire string and checks if it has unicode chars.Also checks for sequences that are 3986 Unreserved characters as these should be un-escaped
    /// </summary>
    private static bool CheckForUnicodeOrEscapedUnreserved(ReadOnlySpan<byte> data, out Flags flags)
    {
        flags = default;
        int i = IndexOfAnyExcept(data, s_asciiOtherThanPercent);
        if (i >= 0)
        {
            int length = data.Length;
            for (; i < length; i++)
            {
                byte b = data[i];
                if (b == (byte)'%')
                {
                    // Optimized bounds check: ensure we have at least 2 more bytes
                    if (i + 2 < length)
                    {
                        char value = Utf8UriHelper.DecodeHexChars(data[i + 1], data[i + 2]);

                        bool isAscii = IsAscii(value);
                        if (!isAscii || Contains(value, Utf8UriHelper.Unreserved))
                        {
                            flags |= Flags.HasUnicode;
                            return true;
                        }

                        i += 2; // Skip the two hex chars we just processed
                    }
                    // If we don't have enough bytes, continue to next iteration
                }
                else if (b > 0x7F)
                {
                    flags |= Flags.HasUnicode | Flags.HasUnescapedUnicode;
                    return true;
                }
            }
        }

        return false;
    }

    //
    //  This method is called first to figure out the scheme or a simple file path
    //  Is called only at the .ctor time
    //
    private static Utf8UriParsingError ParseScheme(ReadOnlySpan<byte> uriString, ref Flags flags, ref Utf8UriParser? syntax)
    {
        int length = uriString.Length;
        if (length == 0)
            return Utf8UriParsingError.EmptyUriString;

        if (length >= c_MaxUriBufferSize)
            return Utf8UriParsingError.SizeLimit;

        // Fast path for valid http(s) schemes with no leading whitespace that are expected to be very common.
        if (StartsWithAsciiOrdinalIgnoreCase(uriString, "https:"u8))
        {
            syntax = Utf8UriParser.HttpsUri;
            flags |= (Flags)6;
        }
        else if (StartsWithAsciiOrdinalIgnoreCase(uriString, "http:"u8))
        {
            syntax = Utf8UriParser.HttpUri;
            flags |= (Flags)5;
        }
        else
        {
            // STEP1: parse scheme, lookup this Uri Syntax or create one using UnknownV1SyntaxFlags uri syntax template
            Utf8UriParsingError err = Utf8UriParsingError.None;
            int idx = ParseSchemeCheckImplicitFile(uriString, ref err, ref flags, ref syntax);
            Debug.Assert((err is Utf8UriParsingError.None) == (syntax is not null));

            if (err != Utf8UriParsingError.None)
                return err;

            flags |= (Flags)idx;
        }

        return Utf8UriParsingError.None;
    }

    // verifies the syntax of the scheme part
    // Checks on implicit File: scheme due to simple Dos/Unc path passed
    // returns the start of the next component  position
    private static int ParseSchemeCheckImplicitFile(ReadOnlySpan<byte> uriString, ref Utf8UriParsingError err, ref Flags flags, ref Utf8UriParser? syntax)
    {
        Debug.Assert(err == Utf8UriParsingError.None);

        int i = 0;
        int length = uriString.Length;

        // Optimized whitespace skipping - first check if we even have whitespace
        if ((uint)i < (uint)length && Utf8UriHelper.IsLWS(uriString[i]))
        {
            do
            {
                i++;
            }
            while ((uint)i < (uint)length && Utf8UriHelper.IsLWS(uriString[i]));
        }

#if NET
        // Sadly, we don't support UNIX on .NET Framework (sorry Mono)
        // Unix: Unix path?
        // A path starting with 2 / or \ (including mixed) is treated as UNC and will be matched below
        if (!OperatingSystem.IsWindows() &&
            (uint)i < (uint)uriString.Length && uriString[i] == '/' &&
            ((uint)(i + 1) >= (uint)uriString.Length || uriString[i + 1] is not ((byte)'/' or (byte)'\\')))
        {
            flags |= (Flags.UnixPath | Flags.ImplicitFile | Flags.AuthorityFound);
            syntax = Utf8UriParser.UnixFileUri;
            return i;
        }
#endif

        // Find the colon.
        // Note that we don't support one-letter schemes that will be put into a DOS path bucket
        int colonOffset = uriString.Slice(i).IndexOf((byte)':');

        // Early bounds check: A string must have at least 3 characters and at least 1 before ':'
        // Combine checks to reduce branching
        if (colonOffset == 0 || (uint)(i + 2) >= (uint)length)
        {
            err = Utf8UriParsingError.BadFormat;
            return 0;
        }

        // Check for supported special cases like a DOS file path OR a UNC share path
        // NB: A string may not have ':' if this is a UNC path
        if (uriString[i + 1] is (byte)':' or (byte)'|')
        {
            // DOS-like path?
            if (IsAsciiLetter(uriString[i]))
            {
                if (uriString[i + 2] is (byte)'\\' or (byte)'/')
                {
                    flags |= (Flags.DosPath | Flags.ImplicitFile | Flags.AuthorityFound);
                    syntax = Utf8UriParser.FileUri;
                    return i;
                }

                err = Utf8UriParsingError.MustRootedPath;
                return 0;
            }

            err = uriString[i + 1] == (byte)':' ? Utf8UriParsingError.BadScheme : Utf8UriParsingError.BadFormat;
            return 0;
        }
        else if (uriString[i] is (byte)'/' or (byte)'\\')
        {
            // UNC share?
            if (uriString[i + 1] is (byte)'\\' or (byte)'/')
            {
                flags |= (Flags.UncPath | Flags.ImplicitFile | Flags.AuthorityFound);
                syntax = Utf8UriParser.FileUri;
                i += 2;

                // V1.1 compat this will simply eat any slashes prepended to a UNC path
                while ((uint)i < (uint)uriString.Length && uriString[i] is (byte)'/' or (byte)'\\')
                {
                    i++;
                }

                return i;
            }

            err = Utf8UriParsingError.BadFormat;
            return 0;
        }

        if (colonOffset < 0)
        {
            err = Utf8UriParsingError.BadFormat;
            return 0;
        }

        // This is a potentially valid scheme, but we have not identified it yet.
        // Check for illegal characters, canonicalize, and check the length.
        syntax = CheckSchemeSyntax(uriString.Slice(i, colonOffset), ref err);

        if (syntax is null)
        {
            return 0;
        }

        return i + colonOffset + 1;
    }

#if NET

    private static readonly SearchValues<byte> s_schemeChars =
        SearchValues.Create("+-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"u8);

#else
    private static ReadOnlySpan<byte> s_schemeChars => "+-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"u8;
#endif

    private static Utf8UriParser? CheckSchemeSyntax(ReadOnlySpan<byte> scheme, ref Utf8UriParsingError error)
    {
        Debug.Assert(error == Utf8UriParsingError.None);

        // Early validation for common error cases
        if (scheme.Length == 0)
        {
            error = Utf8UriParsingError.BadScheme;
            return null;
        }

        if (scheme.Length > c_MaxUriSchemeName)
        {
            error = Utf8UriParsingError.SchemeLimit;
            return null;
        }

        // First character must be ASCII letter - check early to avoid further processing
        byte firstChar = scheme[0];
        if (!IsAsciiLetter(firstChar))
        {
            error = Utf8UriParsingError.BadScheme;
            return null;
        }

        switch (scheme.Length)
        {
            case 2:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "ws"u8)) return Utf8UriParser.WsUri;
                break;

            case 3:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "wss"u8)) return Utf8UriParser.WssUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "ftp"u8)) return Utf8UriParser.FtpUri;
                break;

            case 4:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "http"u8)) return Utf8UriParser.HttpUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "file"u8)) return Utf8UriParser.FileUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "uuid"u8)) return Utf8UriParser.UuidUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "nntp"u8)) return Utf8UriParser.NntpUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "ldap"u8)) return Utf8UriParser.LdapUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "news"u8)) return Utf8UriParser.NewsUri;
                break;

            case 5:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "https"u8)) return Utf8UriParser.HttpsUri;
                break;

            case 6:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "mailto"u8)) return Utf8UriParser.MailToUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "gopher"u8)) return Utf8UriParser.GopherUri;
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "telnet"u8)) return Utf8UriParser.TelnetUri;
                break;

            case 7:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "net.tcp"u8)) return Utf8UriParser.NetTcpUri;
                break;

            case 8:
                if (EqualsAsciiOrdinalIgnoreCase(scheme, "net.pipe"u8)) return Utf8UriParser.NetPipeUri;
                break;
        }

        // scheme = alpha *(alpha | digit | '+' | '-' | '.')
        // We already checked length and first character, now check the rest
        if (ContainsAnyExcept(scheme, s_schemeChars))
        {
            error = Utf8UriParsingError.BadScheme;
            return null;
        }

        // Then look up the syntax in a string-based table. Note that this will allocate a string if we've had to fall
        // through to here
        return Utf8UriParser.FindOrFetchAsUnknownV1Syntax(Utf8UriHelper.AsciiSchemeToLowerInvariantString(scheme));
    }

    //
    //
    //  This method tries to parse the minimal information needed to certify the validity
    //  of a uri string
    //
    //      scheme://userinfo@host:Port/Path?Query#Fragment
    //
    //  The method must be called only at the .ctor time
    //
    //  Returns Utf8UriParsingError.None if the Uri syntax is valid, an error otherwise
    //
    private static unsafe Utf8UriParsingError PrivateParseMinimal(ReadOnlySpan<byte> uriString, ref Flags flags, ref Utf8UriParser syntax)
    {
        Debug.Assert(syntax != null);

        int idx = (int)(flags & Flags.IndexMask);
        int length = uriString.Length;

        // Means a custom Utf8UriParser did call "base" InitializeAndValidate()
        flags &= ~(Flags.IndexMask | Flags.UserDrivenParsing);

        //STEP2: Parse up to the port

        fixed (byte* pUriString = uriString)
        {
            // Cut trailing spaces in uriString
            if (length > idx && Utf8UriHelper.IsLWS(pUriString[length - 1]))
            {
                --length;
                while (length != idx && Utf8UriHelper.IsLWS(pUriString[--length]))
                    ;
                ++length;
            }

#if NET
            // Once again, we don't support netstandard on Linux. Sorry Mono.
            // Unix Path
            if (!OperatingSystem.IsWindows() && InFact(flags, Flags.UnixPath))
            {
                flags |= Flags.BasicHostType;
                flags |= (Flags)idx;
                return Utf8UriParsingError.None;
            }
#endif
            // Old Uri parser tries to figure out on a DosPath in all cases.
            // Hence http://c:/ is treated as DosPath without the host while it should be a host "c", port 80
            //
            // This block is compatible with Old Uri parser in terms it will look for the DosPath if the scheme
            // syntax allows both empty hostnames and DosPath
            //
            if (syntax.IsAllSet(Utf8UriSyntaxFlags.AllowEmptyHost | Utf8UriSyntaxFlags.AllowDOSPath)
                && NotAny(flags, Flags.ImplicitFile) && (idx + 1 < length))
            {
                byte c;
                int i = idx;

                // V1 Compat: Allow _compression_ of > 3 slashes only for File scheme.
                // This will skip all slashes and if their number is 2+ it sets the AuthorityFound flag
                for (; i < length; ++i)
                {
                    if (!((c = pUriString[i]) == '\\' || c == '/'))
                        break;
                }

                if (syntax.InFact(Utf8UriSyntaxFlags.FileLikeUri) || i - idx <= 3)
                {
                    // if more than one slash after the scheme, the authority is present
                    if (i - idx >= 2)
                    {
                        flags |= Flags.AuthorityFound;
                    }
                    // DOS-like path?
                    if (i + 1 < length && ((c = pUriString[i + 1]) == ':' || c == '|') &&
                        IsAsciiLetter(pUriString[i]))
                    {
                        if (i + 2 >= length || ((c = pUriString[i + 2]) != '\\' && c != '/'))
                        {
                            // report an error but only for a file: scheme
                            if (syntax.InFact(Utf8UriSyntaxFlags.FileLikeUri))
                                return Utf8UriParsingError.MustRootedPath;
                        }
                        else
                        {
                            // This will set IsDosPath
                            flags |= Flags.DosPath;

                            if (syntax.InFact(Utf8UriSyntaxFlags.MustHaveAuthority))
                            {
                                // when DosPath found and Authority is required, set this flag even if Authority is empty
                                flags |= Flags.AuthorityFound;
                            }
                            if (i != idx && i - idx != 2)
                            {
                                //This will remember that DosPath is rooted
                                idx = i - 1;
                            }
                            else
                            {
                                idx = i;
                            }
                        }
                    }
                    // UNC share?
                    else if (syntax.InFact(Utf8UriSyntaxFlags.FileLikeUri) && (i - idx >= 2 && i - idx != 3 &&
                        i < length && pUriString[i] != '?' && pUriString[i] != '#'))
                    {
                        // V1.0 did not support file:///, fixing it with minimal behavior change impact
                        // Only FILE scheme may have UNC Path flag set
                        flags |= Flags.UncPath;
                        idx = i;
                    }

#if NET
                    // More "sorry Mono" - we don't support running the netstandard build on Linux; it's .NET only.
                    else if (!OperatingSystem.IsWindows() && syntax.InFact(Utf8UriSyntaxFlags.FileLikeUri) && pUriString[i - 1] == '/' && i - idx == 3)
                    {
                        syntax = Utf8UriParser.UnixFileUri;
                        flags |= Flags.UnixPath | Flags.AuthorityFound;
                        idx += 2;
                    }
#endif
                }
            }
            //
            //STEP 1.5 decide on the Authority component
            //
            if ((flags & (Flags.UncPath | Flags.DosPath | Flags.UnixPath)) != 0)
            {
            }
            else if ((idx + 2) <= length)
            {
                byte first = pUriString[idx];
                byte second = pUriString[idx + 1];

                if (syntax.InFact(Utf8UriSyntaxFlags.MustHaveAuthority))
                {
                    // (V1.0 compatibility) This will allow http:\\ http:\/ http:/\
                    if ((first == '/' || first == '\\') && (second == '/' || second == '\\'))
                    {
                        flags |= Flags.AuthorityFound;
                        idx += 2;
                    }
                    else
                    {
                        return Utf8UriParsingError.BadAuthority;
                    }
                }
                else if (syntax.InFact(Utf8UriSyntaxFlags.OptionalAuthority) && (InFact(flags, Flags.AuthorityFound) ||
                    (first == '/' && second == '/')))
                {
                    flags |= Flags.AuthorityFound;
                    idx += 2;
                }
                // There is no Authority component, save the Path index
                // Ideally we would treat mailto like any other URI, but for historical reasons we have to separate out its host parsing.
                else if (syntax.NotAny(Utf8UriSyntaxFlags.MailToLikeUri))
                {
                    // By now we know the URI has no Authority, so if the URI must be normalized, initialize it without one.
                    if (InFact(flags, Flags.HasUnicode))
                    {
                        uriString = uriString.Slice(0, idx);
                    }
                    // Since there is no Authority, the path index is just the end of the scheme.
                    flags |= ((Flags)idx | Flags.UnknownHostType);
                    return Utf8UriParsingError.None;
                }
            }
            else if (syntax.InFact(Utf8UriSyntaxFlags.MustHaveAuthority))
            {
                return Utf8UriParsingError.BadAuthority;
            }
            // There is no Authority component, save the Path index
            // Ideally we would treat mailto like any other URI, but for historical reasons we have to separate out its host parsing.
            else if (syntax.NotAny(Utf8UriSyntaxFlags.MailToLikeUri))
            {
                // By now we know the URI has no Authority, so if the URI must be normalized, initialize it without one.
                if (InFact(flags, Flags.HasUnicode))
                {
                    uriString = uriString.Slice(0, idx);
                }
                // Since there is no Authority, the path index is just the end of the scheme.
                flags |= ((Flags)idx | Flags.UnknownHostType);
                return Utf8UriParsingError.None;
            }

            // vsmacros://c:\path\file
            // Note that two slashes say there must be an Authority but instead the path goes
            // Fro V1 compat the next block allow this case but not for schemes like http
            if (InFact(flags, Flags.DosPath))
            {
                flags |= (((flags & Flags.AuthorityFound) != 0) ? Flags.BasicHostType : Flags.UnknownHostType);
                flags |= (Flags)idx;
                return Utf8UriParsingError.None;
            }

            //STEP 2: Check the syntax of authority expecting at least one character in it
            //
            // Note here we do know that there is an authority in the string OR it's a DOS path

            // We may find a userInfo and the port when parsing an authority
            // Also we may find a registry based authority.
            // We must ensure that known schemes do use a server-based authority
            {
                Utf8UriParsingError err = Utf8UriParsingError.None;

                idx = CheckAuthorityHelper(pUriString, idx, length, ref err, ref flags, syntax); // REMOVED THE NEWHOST STRING MODIFICATION
                if (err != Utf8UriParsingError.None)
                    return err;

                if (idx < length)
                {
                    byte hostTerminator = pUriString[idx];

                    // This will disallow '\' as the host terminator for any scheme that is not implicitFile or cannot have a Dos Path
                    if (hostTerminator == '\\' && NotAny(flags, Flags.ImplicitFile) && syntax.NotAny(Utf8UriSyntaxFlags.AllowDOSPath))
                    {
                        return Utf8UriParsingError.BadAuthorityTerminator;
                    }
#if NET
                    // (Sorry Mono again, we still don't support you.)
                    // When the hostTerminator is '/' on Unix, use the UnixFile syntax (preserve backslashes)
                    else if (!OperatingSystem.IsWindows() && hostTerminator == '/' && NotAny(flags, Flags.ImplicitFile) && InFact(flags, Flags.UncPath) && syntax == Utf8UriParser.FileUri)
                    {
                        syntax = Utf8UriParser.UnixFileUri;
                    }
#endif
                }
            }

            // The Path (or Port) parsing index is reloaded on demand in CreateUriInfo when accessing a Uri property
            flags |= (Flags)idx;

            // The rest of the string will be parsed on demand
            // The Host/Authority is all checked, the type is known but the host value string
            // is not created/canonicalized at this point.
        }

        return Utf8UriParsingError.None;
    }

    //
    // Checks the syntax of an authority component. It may also get a userInfo if present
    // Returns an error if no/malformed authority found
    // Does not NOT touch info
    // Returns position of the Path component
    //
    // Must be called in the ctor only
    private static unsafe int CheckAuthorityHelper(byte* pString, int idx, int length,
        ref Utf8UriParsingError err, ref Flags flags, Utf8UriParser syntax)
    {
        int end = length;
        byte ch;
        int startInput = idx;
        int start = idx;
        bool hasUnicode = ((flags & Flags.HasUnicode) != 0);
        Utf8UriSyntaxFlags syntaxFlags = syntax.Flags;

        Debug.Assert((flags & Flags.HasUserInfo) == 0 && (flags & Flags.HostTypeMask) == 0);

        //Special case is an empty authority
        if (idx == length || ((ch = pString[idx]) == (byte)'/' || (ch == (byte)'\\' && IsFile(syntax)) || ch == (byte)'#' || ch == (byte)'?'))
        {
            if (syntax.InFact(Utf8UriSyntaxFlags.AllowEmptyHost))
            {
                flags &= ~Flags.UncPath;    //UNC cannot have an empty hostname
                if (InFact(flags, Flags.ImplicitFile))
                    err = Utf8UriParsingError.BadHostName;
                else
                    flags |= Flags.BasicHostType;
            }
            else
                err = Utf8UriParsingError.BadHostName;

            return idx;
        }

        // Attempt to parse user info first

        if ((syntaxFlags & Utf8UriSyntaxFlags.MayHaveUserInfo) != 0)
        {
            for (; start < end; ++start)
            {
                if (start == end - 1 || pString[start] == (byte)'?' || pString[start] == (byte)'#' || pString[start] == (byte)'\\' ||
                    pString[start] == (byte)'/')
                {
                    start = idx;
                    break;
                }
                else if (pString[start] == (byte)'@')
                {
                    flags |= Flags.HasUserInfo;
                    ++start;
                    ch = pString[start];
                    break;
                }
            }
        }

        if (ch == (byte)'[' && syntax.InFact(Utf8UriSyntaxFlags.AllowIPv6Host) &&
            IPv6AddressHelper.IsValid(pString, start, end, true))
        {
            flags |= Flags.IPv6HostType;
        }
        else if (IsAsciiDigit(ch) && syntax.InFact(Utf8UriSyntaxFlags.AllowIPv4Host) &&
            IPv4AddressHelper.IsValid(pString, start, ref end, false, NotAny(flags, Flags.ImplicitFile), false))
        {
            flags |= Flags.IPv4HostType;
        }
        else if (((syntaxFlags & Utf8UriSyntaxFlags.AllowDnsHost) != 0) && !IriParsing(syntax) &&
            Utf8UriDomainNameHelper.IsValid(new ReadOnlySpan<byte>(pString + start, end - start), iri: false, NotAny(flags, Flags.ImplicitFile), out int domainNameLength))
        {
            end = start + domainNameLength;

            // comes here if there are only ascii chars in host with original parsing and no Iri
            flags |= Flags.DnsHostType;

            // Canonical DNS hostnames don't contain uppercase letters
            if (!ContainsAnyInRange(new ReadOnlySpan<byte>(pString + start, domainNameLength), (byte)'A', (byte)'Z'))
            {
                flags |= Flags.CanonicalDnsHost;
            }
        }
        else if (((syntaxFlags & Utf8UriSyntaxFlags.AllowDnsHost) != 0) &&
            (hasUnicode || syntax.InFact(Utf8UriSyntaxFlags.AllowIdn)) &&
            Utf8UriDomainNameHelper.IsValid(new ReadOnlySpan<byte>(pString + start, end - start), iri: true, NotAny(flags, Flags.ImplicitFile), out domainNameLength))
        {
            end = start + domainNameLength;

            CheckAuthorityHelperHandleDnsIri(pString, start, end, hasUnicode,
                ref flags, ref err);
        }
        else if ((syntaxFlags & Utf8UriSyntaxFlags.AllowUncHost) != 0)
        {
            //
            // This must remain as the last check before BasicHost type
            //
            if (Utf8UriUncNameHelper.IsValid(pString, start, ref end, NotAny(flags, Flags.ImplicitFile)))
            {
                if (end - start <= Utf8UriUncNameHelper.MaximumInternetNameLength)
                {
                    flags |= Flags.UncHostType;
                }
            }
        }

        // The deal here is that we won't allow '\' host terminator except for the File scheme
        // If we see '\' we try to make it a part of a Basic host
        if (end < length && pString[end] == (byte)'\\' && (flags & Flags.HostTypeMask) != Flags.HostNotParsed
            && !IsFile(syntax))
        {
            flags &= ~Flags.HostTypeMask;
        }
        // Here we have checked the syntax up to the end of host
        // The only thing that can cause an exception is the port value
        // Spend some (duplicated) cycles on that.
        else if (end < length && pString[end] == (byte)':')
        {
            if (syntax.InFact(Utf8UriSyntaxFlags.MayHavePort))
            {
                int port = 0;
                int startPort = end;
                for (idx = end + 1; idx < length; ++idx)
                {
                    int val = pString[idx] - (byte)'0';
                    if ((uint)val <= ((byte)'9' - (byte)'0'))
                    {
                        if ((port = (port * 10 + val)) > 0xFFFF)
                            break;
                    }
                    else if (val == ((byte)'/' - (byte)'0') || val == ((byte)'?' - (byte)'0') || val == ((byte)'#' - (byte)'0'))
                    {
                        break;
                    }
                    else
                    {
                        // The second check is to keep compatibility with V1 until the Utf8UriParser is registered
                        err = Utf8UriParsingError.BadPort;
                        return idx;
                    }
                }
                // check on 0-ffff range
                if (port > 0xFFFF)
                {
                    if (syntax.InFact(Utf8UriSyntaxFlags.AllowAnyOtherHost))
                    {
                        flags &= ~Flags.HostTypeMask;
                    }
                    else
                    {
                        err = Utf8UriParsingError.BadPort;
                        return idx;
                    }
                }
            }
            else
            {
                flags &= ~Flags.HostTypeMask;
            }
        }

        // check on whether nothing has worked out
        if ((flags & Flags.HostTypeMask) == Flags.HostNotParsed)
        {
            //No user info for a Basic hostname
            flags &= ~Flags.HasUserInfo;
            // Some schemes do not allow HostType = Basic (plus V1 almost never understands this issue)
            //
            if (syntax.InFact(Utf8UriSyntaxFlags.AllowAnyOtherHost))
            {
                flags |= Flags.BasicHostType;
                for (end = idx; end < length; ++end)
                {
                    if (pString[end] == (byte)'/' || (pString[end] == (byte)'?' || pString[end] == (byte)'#'))
                    {
                        break;
                    }
                }
            }
            else
            {
                //
                // ATTN V1 compat: V1 supports hostnames like ".." and ".", and so we do but only for unknown schemes.
                //
                if (syntax.InFact(Utf8UriSyntaxFlags.MustHaveAuthority) ||
                         (syntax.InFact(Utf8UriSyntaxFlags.MailToLikeUri)))
                {
                    err = Utf8UriParsingError.BadHostName;
                    flags |= Flags.UnknownHostType;
                    return idx;
                }
            }
        }

        return end;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void CheckAuthorityHelperHandleDnsIri(byte* pString, int start, int end,
       bool hasUnicode, ref Flags flags,
       ref Utf8UriParsingError err)
    {
        // comes here only if host has unicode chars and iri is on or idn is allowed
        flags |= Flags.DnsHostType;

        // Normalization not required
    }

#if NET

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ContainsAnyInRange(ReadOnlySpan<byte> source, byte start, byte end) => source.ContainsAnyInRange(start, end);

#else
    internal static bool ContainsAnyInRange(ReadOnlySpan<byte> source, byte start, byte end)
    {
        for (int i = 0; i < source.Length; ++i)
        {
            if (source[i] >= start && source[i] <= end)
            {
                return true;
            }
        }

        return false;
    }
#endif

#if NET

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ContainsAnyExcept(ReadOnlySpan<byte> container, SearchValues<byte> exceptions) => container.ContainsAnyExcept(exceptions);

#else
    private static bool ContainsAnyExcept(ReadOnlySpan<byte> scheme, ReadOnlySpan<byte> schemaChars)
    {
        for (int i = 0; i < scheme.Length; i++)
        {
            if (schemaChars.IndexOf(scheme[i]) < 0)
            {
                return true;
            }
        }
        return false;
    }
#endif

#if NET

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int IndexOfAnyExcept(ReadOnlySpan<byte> value, SearchValues<byte> exceptions) => value.IndexOfAnyExcept(exceptions);

#else
    internal static int IndexOfAnyExcept(ReadOnlySpan<byte> value, ReadOnlySpan<byte> exceptions)
    {
        for (int i = 0; i < value.Length; i++)
        {
            if (exceptions.IndexOf(value[i]) < 0)
            {
                return i;
            }
        }
        return -1;
    }
#endif

#if NET

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool Contains(char value, SearchValues<char> search) => search.Contains(value);

#else
    private static bool Contains(char value, ReadOnlySpan<char> search)
    {
        return search.IndexOf(value) >= 0;
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsAsciiLetter(byte v)
    {
#if NET
        return char.IsAsciiLetter((char)v);
#else
        return v >= (byte)'a' && v <= (byte)'z' || v >= (byte)'A' && v <= (byte)'Z';
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsAsciiLetterOrDigit(byte v)
    {
#if NET
        return char.IsAsciiLetterOrDigit((char)v);
#else
        return v >= (byte)'a' && v <= (byte)'z' || v >= (byte)'A' && v <= (byte)'Z' || v >= (byte)'0' && v <= (byte)'9';
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsAsciiDigit(byte v)
    {
#if NET
        return char.IsAsciiDigit((char)v);
#else
        return v >= (byte)'0' && v <= (byte)'9';
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsAscii(char v)
    {
#if NET
        return char.IsAscii(v);
#else
        return (uint)v <= 0x007f;
#endif
    }

    private static bool StartsWithAsciiOrdinalIgnoreCase(ReadOnlySpan<byte> uriString, ReadOnlySpan<byte> asciiSpan)
    {
        if (uriString.Length < asciiSpan.Length)
        {
            return false;
        }
#if NET
        return Ascii.EqualsIgnoreCase(uriString.Slice(0, asciiSpan.Length), asciiSpan);
#else
        for (int i = 0; i < asciiSpan.Length; i++)
        {
            if (uriString[i] != asciiSpan[i] && char.ToLowerInvariant((char)uriString[i]) != char.ToLowerInvariant((char)asciiSpan[i]))
            {
                return false;
            }
        }

        return true;
#endif
    }

    private static bool EqualsAsciiOrdinalIgnoreCase(ReadOnlySpan<byte> uriString, ReadOnlySpan<byte> asciiSpan)
    {
        if (uriString.Length != asciiSpan.Length)
        {
            return false;
        }
#if NET
        return Ascii.EqualsIgnoreCase(uriString, asciiSpan);
#else
        for (int i = 0; i < asciiSpan.Length; i++)
        {
            if (uriString[i] != asciiSpan[i] && char.ToLowerInvariant((char)uriString[i]) != char.ToLowerInvariant((char)asciiSpan[i]))
            {
                return false;
            }
        }

        return true;
#endif
    }
}
