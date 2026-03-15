---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriReference.TryCreateIriReference Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryCreateIriReference `static`

```csharp
bool TryCreateIriReference(ReadOnlySpan<byte> iri, ref Utf8IriReference utf8Iri)
```

Tries to create a new UTF-8 IRI Reference from the specified IRI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes from which to create the UTF-8 IRI from. |
| `utf8Iri` | [`ref Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) | When this method returns, contains the created UTF-8 IRI reference if successful; otherwise, the default value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 IRI Reference was created successfully; otherwise, `false`.

