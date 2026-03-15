---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReference — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8UriReference
```

A UTF-8 URI Reference.

## Remarks

```csharp foo:// user@example.com:8042/over/there?name= ferret#nose \_/ \___________________/\_________/ \_________/ \__/ | | | | | scheme authority path query fragment \___/\______________/ | | user host (including port) ```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Authority` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the authority component of the reference. |
| `Fragment` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the fragment component of the reference. |
| `HasAuthority` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has an authority. |
| `HasFragment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a fragment. |
| `HasHost` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a host. |
| `HasPath` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a path. |
| `HasPort` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a port. |
| `HasQuery` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a query. |
| `HasScheme` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a scheme. |
| `HasUser` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this reference has a user. |
| `Host` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the host component of the reference (includes both host and port). |
| `IsDefaultPort` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is the default port for the scheme. |
| `IsRelative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative reference. |
| `IsValid` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid reference. |
| `OriginalUriReference` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original string. |
| `Path` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the reference. |
| `Port` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the reference as a byte span. |
| `PortValue` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| `Query` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the reference. |
| `Scheme` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the reference. |
| `User` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the reference. |

## Methods

### CreateUriReference `static`

```csharp
Utf8UriReference CreateUriReference(ReadOnlySpan<byte> uri)
```

Creates a new UTF-8 URI Reference from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes to create the reference from. |

**Returns:** [`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html)

A new UTF-8 URI Reference.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the URI is invalid. |

### TryCreateUriReference `static`

```csharp
bool TryCreateUriReference(ReadOnlySpan<byte> uri, ref Utf8UriReference utf8UriReference)
```

Tries to create a new UTF-8 URI Reference from the specified URI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes from which to create the UTF-8 URI from. |
| `utf8UriReference` | [`ref Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | When this method returns, contains the created UTF-8 URI reference if successful; otherwise, the default value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 URI Reference was created successfully; otherwise, `false`.

### GetUri

```csharp
Uri GetUri()
```

Gets the value as a `Uri`.

**Returns:** [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri)

The URI representation of the reference.

### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI reference in canonical form for display.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer into which to write the result in canonical form with the encoded characters decoded for display. |
| `writtenBytes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written to the buffer; otherwise, `false`.

### TryFormatCanonical

```csharp
bool TryFormatCanonical(Span<byte> buffer, ref int writtenBytes)
```

Gets the URI reference in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written to the buffer; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`ref Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | The URI reference to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The resulting URI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Uri result)
```

Applies the given URI reference to the current (base) URI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base URI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The URI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The resulting URI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid URI; otherwise, `false`.

### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the URI reference in display format.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation of the URI reference.

