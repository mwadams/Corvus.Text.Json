---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReference — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8UriReference.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Uri/Utf8UriReference.cs#L29)

A UTF-8 URI Reference.

```csharp
public readonly struct Utf8UriReference
```

## Remarks

```csharp foo:// user@example.com:8042/over/there?name= ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Authority](/api/corvus-text-json-utf8urireference.authority.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the authority component of the reference. |
| [Fragment](/api/corvus-text-json-utf8urireference.fragment.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the fragment component of the reference. |
| [HasAuthority](/api/corvus-text-json-utf8urireference.hasauthority.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has an authority. |
| [HasFragment](/api/corvus-text-json-utf8urireference.hasfragment.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a fragment. |
| [HasHost](/api/corvus-text-json-utf8urireference.hashost.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a host. |
| [HasPath](/api/corvus-text-json-utf8urireference.haspath.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a path. |
| [HasPort](/api/corvus-text-json-utf8urireference.hasport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a port. |
| [HasQuery](/api/corvus-text-json-utf8urireference.hasquery.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a query. |
| [HasScheme](/api/corvus-text-json-utf8urireference.hasscheme.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a scheme. |
| [HasUser](/api/corvus-text-json-utf8urireference.hasuser.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a user. |
| [Host](/api/corvus-text-json-utf8urireference.host.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the host component of the reference (includes both host and port). |
| [IsDefaultPort](/api/corvus-text-json-utf8urireference.isdefaultport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is the default port for the scheme. |
| [IsRelative](/api/corvus-text-json-utf8urireference.isrelative.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative reference. |
| [IsValid](/api/corvus-text-json-utf8urireference.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid reference. |
| [OriginalUriReference](/api/corvus-text-json-utf8urireference.originalurireference.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original string. |
| [Path](/api/corvus-text-json-utf8urireference.path.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the reference. |
| [Port](/api/corvus-text-json-utf8urireference.port.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the reference as a byte span. |
| [PortValue](/api/corvus-text-json-utf8urireference.portvalue.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| [Query](/api/corvus-text-json-utf8urireference.query.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the reference. |
| [Scheme](/api/corvus-text-json-utf8urireference.scheme.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the reference. |
| [User](/api/corvus-text-json-utf8urireference.user.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the reference. |

## Methods

| Method | Description |
|--------|-------------|
| [CreateUriReference(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-utf8urireference.createurireference.html#createurireference-readonlyspan-byte) `static` | Creates a new UTF-8 URI Reference from the specified URI bytes. |
| [GetUri()](/api/corvus-text-json-utf8urireference.geturi.html#geturi) | Gets the value as a [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri). |
| [ToString()](/api/corvus-text-json-utf8urireference.tostring.html#tostring) | Returns a string representation of the URI reference in display format. |
| [TryApply](/api/corvus-text-json-utf8urireference.tryapply.html) | Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, incl... |
| [TryCreateUriReference(ReadOnlySpan&lt;byte&gt;, ref Utf8UriReference)](/api/corvus-text-json-utf8urireference.trycreateurireference.html#trycreateurireference-readonlyspan-byte-ref-utf8urireference) `static` | Tries to create a new UTF-8 URI Reference from the specified URI bytes. |
| [TryFormatCanonical(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8urireference.tryformatcanonical.html#tryformatcanonical-span-byte-ref-int) | Gets the URI reference in canonical form. |
| [TryFormatDisplay(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8urireference.tryformatdisplay.html#tryformatdisplay-span-byte-ref-int) | Gets the URI reference in canonical form for display. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

