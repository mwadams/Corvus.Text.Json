---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriReference.CreateIriReference Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateIriReference `static`

```csharp
Utf8IriReference CreateIriReference(ReadOnlySpan<byte> iri)
```

Creates a new UTF-8 IRI Reference from the specified IRI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes to create the reference from. |

### Returns

[`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html)

A new UTF-8 IRI Reference.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the IRI is invalid. |

