---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetBoolean {#getboolean}

```csharp
bool GetBoolean()
```

Parses the current JSON token value from the source as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean). Returns `true` if the TokenType is JsonTokenType.True and `false` if the TokenType is JsonTokenType.False.

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a boolean (i.e. [`True`](/api/corvus-text-json-internal-jsontokentype.html#true) or [`False`](/api/corvus-text-json-internal-jsontokentype.html#false)). |

