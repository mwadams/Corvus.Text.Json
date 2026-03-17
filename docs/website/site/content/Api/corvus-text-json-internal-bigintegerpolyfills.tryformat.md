---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigIntegerPolyfills.TryFormat Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryFormat {#tryformat}

```csharp
public static bool TryFormat(ref BigInteger value, Span<byte> destination, ref int bytesWritten)
```

Tries to format the value of the current [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) instance into the provided span of bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The value to format. |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The span in which to write the formatted value as UTF-8. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the number of bytes that were written to the destination. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation was successful; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

