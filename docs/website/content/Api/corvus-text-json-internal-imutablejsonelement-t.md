---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonElement<T> — Corvus.Text.Json.Internal"
---
```csharp
public interface IMutableJsonElement<T> : IJsonElement<T>, IJsonElement
```

Represents a mutable JSON element of type `T`.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type implementing the interface. |

## Remarks

Note that mutable elements are ephemeral. If their underlying document is modified, they may no longer be valid, and their behaviour is undefined.

## Implements

[`IJsonElement<T>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

## Implemented By

[`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html), [`JsonElementForBooleanFalseSchema.Mutable`](/api/corvus-text-json-jsonelementforbooleanfalseschema-mutable.html)

