---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.GetBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.TryGet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.TryGet.cs#L88)

## GetBoolean {#getboolean}

Parses the current JSON token value from the source as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean). Returns `true` if the TokenType is JsonTokenType.True and `false` if the TokenType is JsonTokenType.False.

```csharp
public bool GetBoolean()
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of a JSON token that is not a boolean (i.e. [`True`](/api/corvus-text-json-internal-jsontokentype.html#true) or [`False`](/api/corvus-text-json-internal-jsontokentype.html#false)). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

