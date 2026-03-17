---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteBase64StringSegment Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.WriteValues.StringSegment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.StringSegment.cs#L32)

## WriteBase64StringSegment {#writebase64stringsegment}

Writes the input bytes as a partial JSON string.

```csharp
public void WriteBase64StringSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The bytes to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

