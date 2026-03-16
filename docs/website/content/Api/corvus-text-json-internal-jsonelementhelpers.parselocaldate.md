---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ParseLocalDate Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ParseLocalDate {#parselocaldate}

```csharp
public static LocalDate ParseLocalDate(ReadOnlySpan<byte> text)
```

Parse a local date from a UTF-8 encoded string for the `date` format.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded string to parse. |

### Returns

[`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html)

The resulting local date.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Thrown when the text cannot be parsed as a valid date. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

