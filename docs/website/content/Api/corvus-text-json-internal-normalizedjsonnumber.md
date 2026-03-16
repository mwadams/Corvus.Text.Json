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

| Constructor | Description |
|-------------|-------------|
| [NormalizedJsonNumber(bool, byte\[\], byte\[\], int)](/api/corvus-text-json-internal-normalizedjsonnumber.ctor.html#normalizedjsonnumber-bool-byte-byte-int) |  |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Exponent](/api/corvus-text-json-internal-normalizedjsonnumber.exponent.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent to apply after concatenating the integral and fractional parts. |
| [Fractional](/api/corvus-text-json-internal-normalizedjsonnumber.fractional.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The normalized fractional part of the original JSON representation of the number. |
| [Integral](/api/corvus-text-json-internal-normalizedjsonnumber.integral.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The normalized integral part of the original JSON representation of the number. |
| [IsNegative](/api/corvus-text-json-internal-normalizedjsonnumber.isnegative.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the number is negative. |

