---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonEncodedText.ToString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L154)

## ToString {#tostring}

Converts the value of this instance to a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

```csharp
public override string ToString()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

Returns the underlying UTF-16 encoded string.

### Remarks

Returns an empty string on a default instance of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

