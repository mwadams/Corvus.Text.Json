---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigIntegerPolyfills — Corvus.Text.Json.Internal"
---
```csharp
public static class BigIntegerPolyfills
```

Polyfills for [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) methods that are not available in all target frameworks.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **BigIntegerPolyfills**

## Methods

| Method | Description |
|--------|-------------|
| [TryFormat(ref BigInteger, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-bigintegerpolyfills.tryformat.html#bool-tryformat-ref-biginteger-value-span-byte-destination-ref-int-byteswritten) `static` | Tries to format the value of the current [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) instance into the provided span of bytes. |
| [TryGetMinimumFormatBufferLength(ref BigInteger, ref int)](/api/corvus-text-json-internal-bigintegerpolyfills.trygetminimumformatbufferlength.html#bool-trygetminimumformatbufferlength-ref-biginteger-biginteger-ref-int-minimumlength) `static` | Gets the minimum format buffer length. |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref BigInteger)](/api/corvus-text-json-internal-bigintegerpolyfills.tryparse.html#bool-tryparse-readonlyspan-byte-segment-ref-biginteger-value) `static` |  |

