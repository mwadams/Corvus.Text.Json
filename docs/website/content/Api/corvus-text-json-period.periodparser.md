---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.PeriodParser Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## PeriodParser `static`

```csharp
bool PeriodParser(ReadOnlySpan<byte> text, ref PeriodBuilder builder)
```

A parser for a json period.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to parse. |
| `builder` | [`ref PeriodBuilder`](/api/corvus-text-json-periodbuilder.html) | The resulting period builder. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

A period builder parsed from the read only span.

