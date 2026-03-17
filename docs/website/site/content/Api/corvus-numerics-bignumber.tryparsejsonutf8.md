---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryParseJsonUtf8 Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [BigNumber.OptimizedFormatting.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.OptimizedFormatting.cs#L321)

## TryParseJsonUtf8 {#tryparsejsonutf8}

Tries to parse a BigNumber from UTF-8 bytes in JSON format with zero allocations.

```csharp
public static bool TryParseJsonUtf8(ReadOnlySpan<byte> utf8Source, ref BigNumber result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Source` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed BigNumber. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

### Remarks

This method is optimized for parsing JSON-formatted numbers with InvariantCulture semantics. It expects input in formats like: "123", "-456", "1234E-3", "1234E2", "0". The method parses directly from UTF-8 bytes without conversion to chars, maintaining zero heap allocations for typical numbers.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

