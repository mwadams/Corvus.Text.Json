---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryFormatOptimized Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## TryFormatOptimized {#tryformatoptimized}

```csharp
public bool TryFormatOptimized(Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

Tries to format this instance into the provided UTF-16 span with zero allocations.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of characters written. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format string. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeded; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

