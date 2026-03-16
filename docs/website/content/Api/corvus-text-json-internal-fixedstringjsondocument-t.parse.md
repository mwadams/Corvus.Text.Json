---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "FixedStringJsonDocument<T>.Parse Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Parse {#parse}

```csharp
FixedStringJsonDocument<T> Parse(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
```

Parse an instance of the fixed string to a document, using caching.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `rawJsonStringValue` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The raw JSON string value, including quotes. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

### Returns

[`FixedStringJsonDocument<T>`](/api/corvus-text-json-internal-fixedstringjsondocument-t.html)

A fixed string document representing the value, from the cache.

