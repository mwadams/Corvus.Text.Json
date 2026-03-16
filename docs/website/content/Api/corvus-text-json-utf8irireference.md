---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriReference — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8IriReference
```

A UTF-8 IRI Reference.

## Remarks

```csharp foo:// user@example.com:8042/over/there?name= ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Authority](/api/corvus-text-json-utf8irireference.authority.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the authority component of the reference. |
| [Fragment](/api/corvus-text-json-utf8irireference.fragment.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the fragment component of the reference. |
| [HasAuthority](/api/corvus-text-json-utf8irireference.hasauthority.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has an authority. |
| [HasFragment](/api/corvus-text-json-utf8irireference.hasfragment.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a fragment. |
| [HasHost](/api/corvus-text-json-utf8irireference.hashost.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a host. |
| [HasPath](/api/corvus-text-json-utf8irireference.haspath.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a path. |
| [HasPort](/api/corvus-text-json-utf8irireference.hasport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a port. |
| [HasQuery](/api/corvus-text-json-utf8irireference.hasquery.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a query. |
| [HasScheme](/api/corvus-text-json-utf8irireference.hasscheme.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a scheme. |
| [HasUser](/api/corvus-text-json-utf8irireference.hasuser.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a user. |
| [Host](/api/corvus-text-json-utf8irireference.host.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the host component of the reference (includes both host and port). |
| [IsDefaultPort](/api/corvus-text-json-utf8irireference.isdefaultport.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is the default port for the scheme. |
| [IsRelative](/api/corvus-text-json-utf8irireference.isrelative.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative reference. |
| [IsValid](/api/corvus-text-json-utf8irireference.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid reference. |
| [OriginalIriReference](/api/corvus-text-json-utf8irireference.originalirireference.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original string. |
| [Path](/api/corvus-text-json-utf8irireference.path.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the reference. |
| [Port](/api/corvus-text-json-utf8irireference.port.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the reference as a byte span. |
| [PortValue](/api/corvus-text-json-utf8irireference.portvalue.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| [Query](/api/corvus-text-json-utf8irireference.query.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the reference. |
| [Scheme](/api/corvus-text-json-utf8irireference.scheme.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the reference. |
| [User](/api/corvus-text-json-utf8irireference.user.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the reference. |

## Methods

| Method | Description |
|--------|-------------|
| [CreateIriReference(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-utf8irireference.createirireference.html#createirireference-readonlyspan-byte) `static` | Creates a new UTF-8 IRI Reference from the specified IRI bytes. |
| [GetUri()](/api/corvus-text-json-utf8irireference.geturi.html#geturi) | Gets the value as a [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri). |
| [ToString()](/api/corvus-text-json-utf8irireference.tostring.html#tostring) | Returns a string representation of the IRI reference in display format. |
| [TryApply](/api/corvus-text-json-utf8irireference.tryapply.html) | Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including hand... |
| [TryCreateIriReference(ReadOnlySpan&lt;byte&gt;, ref Utf8IriReference)](/api/corvus-text-json-utf8irireference.trycreateirireference.html#trycreateirireference-readonlyspan-byte-ref-utf8irireference) `static` | Tries to create a new UTF-8 IRI Reference from the specified IRI bytes. |
| [TryFormatCanonical(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8irireference.tryformatcanonical.html#tryformatcanonical-span-byte-ref-int) | Gets the IRI reference in canonical form. |
| [TryFormatDisplay(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-utf8irireference.tryformatdisplay.html#tryformatdisplay-span-byte-ref-int) | Gets the IRI reference in canonical form for display. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

