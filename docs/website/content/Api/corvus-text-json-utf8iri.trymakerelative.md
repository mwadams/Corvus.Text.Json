---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Iri.TryMakeRelative Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryMakeRelative(ref Utf8Iri, Span&lt;byte&gt;, ref Utf8IriReference)](#trymakerelative-ref-utf8iri-span-byte-ref-utf8irireference) | Makes a relative IRI reference from the current (base) IRI to the target IRI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target IRI is returned. |
| [TryMakeRelative(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8IriReference)](#trymakerelative-ref-utf8uri-span-byte-ref-utf8irireference) | Makes a relative IRI reference from the current (base) IRI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned. |

## TryMakeRelative(ref Utf8Iri, Span&lt;byte&gt;, ref Utf8IriReference) {#trymakerelative-ref-utf8iri-span-byte-ref-utf8irireference}

```csharp
public bool TryMakeRelative(ref Utf8Iri targetIri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target IRI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target IRI is returned.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetIri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | The target IRI to make relative. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The resulting IRI reference (relative or absolute). |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written; otherwise, `false`.

---

## TryMakeRelative(ref Utf8Uri, Span&lt;byte&gt;, ref Utf8IriReference) {#trymakerelative-ref-utf8uri-span-byte-ref-utf8irireference}

```csharp
public bool TryMakeRelative(ref Utf8Uri targetUri, Span<byte> buffer, ref Utf8IriReference result)
```

Makes a relative IRI reference from the current (base) IRI to the target URI. If the scheme, host, and port match, a relative reference is created; otherwise, the full target URI is returned.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetUri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | The target URI to make relative. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to which to write the backing for the result. This needs to have a lifetime scoped to that of the resulting reference. |
| `result` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | The resulting IRI reference (relative or absolute). |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the result was successfully written; otherwise, `false`.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

