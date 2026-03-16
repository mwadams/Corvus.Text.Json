---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.ParseAsync Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## ParseAsync {#parseasync}

```csharp
public static Task<ParsedJsonDocument<T>> ParseAsync(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
```

Parse a [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as UTF-8 encoded data representing a single JSON value into a ParsedJsonDocument. The Stream will be read to completion.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | JSON data to parse. |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) | Options to control the reader behavior during parsing. *(optional)* |
| `cancellationToken` | [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) | The token to monitor for cancellation requests. *(optional)* |

### Returns

[`Task<ParsedJsonDocument<T>>`](https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1)

A Task to produce a ParsedJsonDocument{T} representation of the JSON value.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`JsonException`](/api/corvus-text-json-jsonexception.html) | `utf8Json` does not represent a valid single JSON value. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | `options` contains unsupported options. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

