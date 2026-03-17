---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Iri.CreateIri Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8Iri.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Uri/Utf8Iri.cs#L188)

## CreateIri {#createiri}

Creates a new UTF-8 IRI from the specified IRI bytes.

```csharp
public static Utf8Iri CreateIri(ReadOnlySpan<byte> iri)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes from which to create the UTF-8 IRI. |

### Returns

[`Utf8Iri`](/api/corvus-text-json-utf8iri.html)

A new UTF-8 IRI.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the IRI is invalid. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

