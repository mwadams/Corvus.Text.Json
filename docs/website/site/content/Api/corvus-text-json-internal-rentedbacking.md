---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RentedBacking — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [RentedBacking.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/RentedBacking.cs#L20)

Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](/api/corvus-text-json-internal-simpletypesbacking.html).

```csharp
public readonly struct RentedBacking : IDisposable
```

## Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-internal-rentedbacking.dispose.html#dispose) |  |
| [Initialize(ref RentedBacking, int, ref T, RentedBacking.Writer&lt;T&gt;)](/api/corvus-text-json-internal-rentedbacking.initialize.html#initialize-ref-rentedbacking-int-ref-t-rentedbacking-writer-t) `static` |  |
| [Span()](/api/corvus-text-json-internal-rentedbacking.span.html#span) | Gets the written value as a span |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

