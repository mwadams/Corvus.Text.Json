---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "SimpleTypesBacking — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [SimpleTypesBacking.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/SimpleTypesBacking.cs#L20)

Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) creation.

```csharp
public readonly struct SimpleTypesBacking
```

## Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

## Methods

| Method | Description |
|--------|-------------|
| [Initialize(ref SimpleTypesBacking, ref T, SimpleTypesBacking.Writer&lt;T&gt;)](/api/corvus-text-json-internal-simpletypesbacking.initialize.html#initialize-ref-simpletypesbacking-ref-t-simpletypesbacking-writer-t) `static` |  |
| [Span()](/api/corvus-text-json-internal-simpletypesbacking.span.html#span) | Gets the written value as a span |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

