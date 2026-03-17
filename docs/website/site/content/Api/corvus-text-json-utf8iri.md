---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Iri — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8Iri
```

A UTF-8 IRI.

## Remarks

```csharp foo:// user@example.com:8042/over/there?name= ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Authority](/api/corvus-text-json-utf8iri.authority.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the authority component of the reference. |
| [Fragment](/api/corvus-text-json-utf8iri.fragment.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the fragment component of the reference. |
| [HasAuthority](/api/corvus-text-json-utf8iri.hasauthority.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has an authority. |
| [HasFragment](/api/corvus-text-json-utf8iri.hasfragment.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a fragment. |
| [HasHost](/api/corvus-text-json-utf8iri.hashost.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a host. |
| [HasPath](/api/corvus-text-json-utf8iri.haspath.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a path. |
| [HasPort](/api/corvus-text-json-utf8iri.hasport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a port. |
| [HasQuery](/api/corvus-text-json-utf8iri.hasquery.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a query. |
| [HasScheme](/api/corvus-text-json-utf8iri.hasscheme.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a scheme. |
| [HasUser](/api/corvus-text-json-utf8iri.hasuser.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a user. |
| [Host](/api/corvus-text-json-utf8iri.host.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the host component of the reference (includes both host and port). |
| [IsDefaultPort](/api/corvus-text-json-utf8iri.isdefaultport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is the default port for the scheme. |
| [IsRelative](/api/corvus-text-json-utf8iri.isrelative.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative IRI. |
| [IsValid](/api/corvus-text-json-utf8iri.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid IRI. |
| [OriginalIri](/api/corvus-text-json-utf8iri.originaliri.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original (fully encoded) string. |
| [Path](/api/corvus-text-json-utf8iri.path.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the IRI. |
| [Port](/api/corvus-text-json-utf8iri.port.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the IRI as a byte span. |
| [PortValue](/api/corvus-text-json-utf8iri.portvalue.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| [Query](/api/corvus-text-json-utf8iri.query.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the IRI. |
| [Scheme](/api/corvus-text-json-utf8iri.scheme.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the IRI. |
| [User](/api/corvus-text-json-utf8iri.user.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the IRI. |

## Methods

| Method | Description |
|--------|-------------|
| [CreateIri(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-utf8iri.createiri.html#createiri-readonlyspan-byte) `static` | Creates a new UTF-8 IRI from the specified IRI bytes. |
| [GetUri()](/api/corvus-text-json-utf8iri.geturi.html#geturi) | Gets the value as a [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri). |
| [ToString()](/api/corvus-text-json-utf8iri.tostring.html#tostring) | Returns a string representation of the IRI in display format. |
| [TryApply](/api/corvus-text-json-utf8iri.tryapply.html) | Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including hand... |
| [TryCreateIri(ReadOnlySpan&lt;byte&gt;, ref Utf8Iri)](/api/corvus-text-json-utf8iri.trycreateiri.html#trycreateiri-readonlyspan-byte-ref-utf8iri) `static` | Tries to create a new UTF-8 IRI from the specified IRI bytes. |
| [TryFormatCanonical(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8iri.tryformatcanonical.html#tryformatcanonical-span-byte-ref-int) | Gets the IRI in canonical form. |
| [TryFormatDisplay(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8iri.tryformatdisplay.html#tryformatdisplay-span-byte-ref-int) | Gets the IRI in canonical form for display. |
| [TryMakeRelative](/api/corvus-text-json-utf8iri.trymakerelative.html) | Makes a relative IRI reference from the current (base) IRI to the target IRI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target IRI is returned. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

