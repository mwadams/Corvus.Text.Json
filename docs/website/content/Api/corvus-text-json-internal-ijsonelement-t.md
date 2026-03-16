---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement<T> — Corvus.Text.Json.Internal"
---
```csharp
public interface IJsonElement<T> : IJsonElement
```

Implemented by JsonElement-derived types.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type implementing the interface. |

## Implements

[`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

## Implemented By

[`IMutableJsonElement<T>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`JsonElement`](/api/corvus-text-json-jsonelement.html), [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html), [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html), [`JsonElementForBooleanFalseSchema.Mutable`](/api/corvus-text-json-jsonelementforbooleanfalseschema-mutable.html)

## Methods

| Method | Description |
|--------|-------------|
| [CreateInstance(IJsonDocument, int)](/api/corvus-text-json-internal-ijsonelement-t.createinstance.html#createinstance-ijsondocument-int) `static` | Creates an instance of the element from the parent document and the handle of the element in the parent document. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

