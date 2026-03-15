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
| `IsRelative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a relative IRI. |
| `IsValid` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid IRI. |
| `OriginalIri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the original (fully encoded) string. |
| `Path` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the path component of the IRI. |
| `Port` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the port component of the IRI as a byte span. |
| `PortValue` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the port value as an integer. |
| `Query` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the query component of the IRI. |
| `Scheme` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the scheme component of the IRI. |
| `User` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the user component of the IRI. |

## Methods

### CreateIri `static`

```csharp
Utf8Iri CreateIri(ReadOnlySpan<byte> iri)
```

Creates a new UTF-8 IRI from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes from which to create the UTF-8 IRI. |

**Returns:** [`Utf8Iri`](/api/corvus-text-json-utf8iri.html)

A new UTF-8 IRI.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the IRI is invalid. |

### TryCreateIri `static`

```csharp
bool TryCreateIri(ReadOnlySpan<byte> iri, ref Utf8Iri utf8Iri)
```

Tries to create a new UTF-8 IRI from the specified IRI bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes from which to create the UTF-8 IRI. |
| `utf8Iri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | When this method returns, contains the created UTF-8 IRI if successful; otherwise, the default value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 IRI was created successfully; otherwise, `false`.

### GetUri

```csharp
Uri GetUri()
```

Gets the value as a `Uri`.

**Returns:** [`Uri`](https://learn.microsoft.com/dotnet/api/system.uri)

The URI representation of the UTF-8 IRI.

### TryFormatDisplay

```csharp
bool TryFormatDisplay(Span<byte> buffer, ref int writtenBytes)
```

Gets the IRI in canonical form for display.

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

Gets the IRI in canonical form.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer into which to write the result in canonical form with reserved characters encoded. |
| `writtenBytes` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written to the buffer; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8Iri iri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8IriReference iriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The IRI reference to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`ref Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

### TryApply

```csharp
bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

### TryMakeRelative

```csharp
bool TryMakeRelative(ref Utf8Iri targetIri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target IRI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target IRI is returned.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetIri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The target IRI to make relative. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The resulting IRI reference (relative or absolute). |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written; otherwise, `false`.

### TryMakeRelative

```csharp
bool TryMakeRelative(ref Utf8Uri targetUri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `targetUri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The target URI to make relative. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The resulting IRI reference (relative or absolute). |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written; otherwise, `false`.

### ToString `virtual`

```csharp
string ToString()
```

Returns a string representation of the IRI in display format.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation of the IRI.

