---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriReference.TryApply Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryApply(ref Utf8Iri, Span&lt;byte&gt;, ref Utf8Iri)](#tryapply-ref-utf8iri-span-byte-ref-utf8iri) | Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including hand... |
| [TryApply(ref Utf8IriReference, Span&lt;byte&gt;, ref Utf8Iri)](#tryapply-ref-utf8irireference-span-byte-ref-utf8iri) | Applies the given IRI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, incl... |
| [TryApply(ref Utf8UriReference, Span&lt;byte&gt;, ref Utf8Iri)](#tryapply-ref-utf8urireference-span-byte-ref-utf8iri) | Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, incl... |
| [TryApply(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8Iri)](#tryapply-ref-utf8uri-span-byte-ref-utf8iri) | Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, incl... |

## TryApply(ref Utf8Iri, Span&lt;byte&gt;, ref Utf8Iri) {#tryapply-ref-utf8iri-span-byte-ref-utf8iri}

```csharp
public bool TryApply(ref Utf8Iri iri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

---

## TryApply(ref Utf8IriReference, Span&lt;byte&gt;, ref Utf8Iri) {#tryapply-ref-utf8irireference-span-byte-ref-utf8iri}

```csharp
public bool TryApply(ref Utf8IriReference iriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given IRI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iriReference` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The IRI reference to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

---

## TryApply(ref Utf8UriReference, Span&lt;byte&gt;, ref Utf8Iri) {#tryapply-ref-utf8urireference-span-byte-ref-utf8iri}

```csharp
public bool TryApply(ref Utf8UriReference uriReference, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uriReference` | [`ref Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

---

## TryApply(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8Iri) {#tryapply-ref-utf8uri-span-byte-ref-utf8iri}

```csharp
public bool TryApply(ref Utf8Uri uri, Span<byte> buffer, ref Utf8Iri result)
```

Applies the given URI reference to the current (base) IRI and writes the result to the provided buffer. It uses the rules of RFC 3986 Section 5.2 to resolve the reference against the base IRI, including handling of relative references and merging of paths as needed. This will fail if the IRI reference is a relative reference.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The IRI to apply. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The resulting IRI. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written and produced a valid IRI; otherwise, `false`.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

