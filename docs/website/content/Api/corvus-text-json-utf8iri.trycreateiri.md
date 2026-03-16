---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Iri.TryCreateIri Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryCreateIri {#trycreateiri}

```csharp
public static bool TryCreateIri(ReadOnlySpan<byte> iri, ref Utf8Iri utf8Iri)
```

Tries to create a new UTF-8 IRI from the specified IRI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `iri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The IRI bytes from which to create the UTF-8 IRI. |
| `utf8Iri` | [`ref Utf8Iri`](/api/corvus-text-json-utf8iri.html) | When this method returns, contains the created UTF-8 IRI if successful; otherwise, the default value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 IRI was created successfully; otherwise, `false`.

