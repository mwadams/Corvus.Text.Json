---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryFormatUtf8Optimized Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [BigNumber.OptimizedFormatting.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.OptimizedFormatting.cs#L141)

## TryFormatUtf8Optimized {#tryformatutf8optimized}

Tries to format this instance into the provided UTF-8 span with zero allocations.

```csharp
public bool TryFormatUtf8Optimized(Span<byte> utf8Destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The destination span. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written. |
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

