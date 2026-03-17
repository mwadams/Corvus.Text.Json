---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetRawText Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L1970)

## GetRawText {#getrawtext}

Gets the original input data backing this value, returning it as a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

```csharp
public string GetRawText()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The original input data backing this value, returning it as a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Note that this method allocates.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

