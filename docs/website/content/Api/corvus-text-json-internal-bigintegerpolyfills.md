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
| [TryFormat(ref BigInteger, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-bigintegerpolyfills.tryformat.html#tryformat-ref-biginteger-span-byte-ref-int) `static` | Tries to format the value of the current [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) instance into the provided span of bytes. |
| [TryGetMinimumFormatBufferLength(ref BigInteger, ref int)](/api/corvus-text-json-internal-bigintegerpolyfills.trygetminimumformatbufferlength.html#trygetminimumformatbufferlength-ref-biginteger-ref-int) `static` | Gets the minimum format buffer length. |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref BigInteger)](/api/corvus-text-json-internal-bigintegerpolyfills.tryparse.html#tryparse-readonlyspan-byte-ref-biginteger) `static` |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

