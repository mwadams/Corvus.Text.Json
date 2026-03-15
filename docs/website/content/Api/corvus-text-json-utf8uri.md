---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Uri — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8Uri
```

A UTF-8 URI.

## Remarks

```csharp foo:// user@example.com:8042/over/there?name= ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Authority](/api/corvus-text-json-utf8uri.authority.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the authority component of the reference. |
| [Fragment](/api/corvus-text-json-utf8uri.fragment.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the fragment component of the reference. |
| [HasAuthority](/api/corvus-text-json-utf8uri.hasauthority.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has an authority. |
| [HasFragment](/api/corvus-text-json-utf8uri.hasfragment.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a fragment. |
| [HasHost](/api/corvus-text-json-utf8uri.hashost.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a host. |
| [HasPath](/api/corvus-text-json-utf8uri.haspath.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a path. |
| [HasPort](/api/corvus-text-json-utf8uri.hasport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a port. |
| [HasQuery](/api/corvus-text-json-utf8uri.hasquery.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a query. |
| [HasScheme](/api/corvus-text-json-utf8uri.hasscheme.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a scheme. |
| [HasUser](/api/corvus-text-json-utf8uri.hasuser.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a user. |
| [Host](/api/corvus-text-json-utf8uri.host.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the host component of the reference (includes both host and port). |
| [IsDefaultPort](/api/corvus-text-json-utf8uri.isdefaultport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is the default port for the scheme. |
| [IsRelative](/api/corvus-text-json-utf8uri.isrelative.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative URI. |
| [IsValid](/api/corvus-text-json-utf8uri.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid URI. |
| [OriginalUri](/api/corvus-text-json-utf8uri.originaluri.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original (fully encoded) string. |
| [Path](/api/corvus-text-json-utf8uri.path.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the URI. |
| [Port](/api/corvus-text-json-utf8uri.port.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the URI as a byte span. |
| [PortValue](/api/corvus-text-json-utf8uri.portvalue.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| [Query](/api/corvus-text-json-utf8uri.query.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the URI. |
| [Scheme](/api/corvus-text-json-utf8uri.scheme.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the URI. |
| [User](/api/corvus-text-json-utf8uri.user.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the URI. |

## Methods

| Method | Description |
|--------|-------------|
| [CreateUri(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-utf8uri.createuri.html#utf8uri-createuri-readonlyspan-byte-uri) `static` | Creates a new UTF-8 URI from the specified URI bytes. |
| [GetUri()](/api/corvus-text-json-utf8uri.geturi.html#uri-geturi) | Gets the value as a [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri). |
| [ToString()](/api/corvus-text-json-utf8uri.tostring.html#string-tostring) | Returns a string representation of the URI in display format. |
| [TryApply(ref Utf8UriReference, Span&lt;byte&gt;, ref Utf8Uri)](/api/corvus-text-json-utf8uri.tryapply.html#bool-tryapply-ref-utf8urireference-urireference-span-byte-buffer-ref-utf8uri-result) | Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, incl... |
| [TryApply(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8Uri)](/api/corvus-text-json-utf8uri.tryapply.html#bool-tryapply-ref-utf8uri-uri-span-byte-buffer-ref-utf8uri-result) | Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, incl... |
| [TryCreateUri(ReadOnlySpan&lt;byte&gt;, ref Utf8Uri)](/api/corvus-text-json-utf8uri.trycreateuri.html#bool-trycreateuri-readonlyspan-byte-uri-ref-utf8uri-utf8uri) `static` | Tries to create a new UTF-8 URI from the specified URI bytes. |
| [TryFormatCanonical(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8uri.tryformatcanonical.html#bool-tryformatcanonical-span-byte-buffer-ref-int-writtenbytes) | Gets the URI in canonical form. |
| [TryFormatDisplay(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8uri.tryformatdisplay.html#bool-tryformatdisplay-span-byte-buffer-ref-int-writtenbytes) | Gets the URI in canonical form for display. |
| [TryMakeRelative(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8UriReference)](/api/corvus-text-json-utf8uri.trymakerelative.html#bool-trymakerelative-ref-utf8uri-targeturi-span-byte-buffer-ref-utf8urireference-result) | Makes a relative URI reference from the current (base) URI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned. |

