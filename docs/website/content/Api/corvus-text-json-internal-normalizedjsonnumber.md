---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "NormalizedJsonNumber — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct NormalizedJsonNumber
```

Represents a normalized JSON number.

## Constructors

### NormalizedJsonNumber

```csharp
NormalizedJsonNumber(bool isNegative, byte[] integral, byte[] fractional, int exponent)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `isNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `integral` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) |  |
| `fractional` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) |  |
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsNegative` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |
| `Integral` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The normalized integral part of the original JSON representation of the number. |
| `Fractional` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The normalized fractional part of the original JSON representation of the number. |
| `Exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent to apply after concatenating the integral and fractional parts. |

