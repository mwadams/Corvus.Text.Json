---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryParsePeriod Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryParsePeriod {#tryparseperiod}

```csharp
public static bool TryParsePeriod(ReadOnlySpan<byte> text, ref Period value)
```

Parse a period from a string for the `duration` format.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string to parse. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The resulting duration. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the duration could be parsed.

