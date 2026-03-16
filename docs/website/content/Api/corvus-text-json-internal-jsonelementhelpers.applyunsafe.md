---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ApplyUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ApplyUnsafe {#applyunsafe}

```csharp
public static void ApplyUnsafe<TTarget, TSource>(TTarget targetElement, ref TSource sourceElement)
```

Applies all properties from a source JSON object element to a target JSON object element.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TTarget` | The type of the target element implementing [`IMutableJsonElement`](/api/corvus-text-json-internal-imutablejsonelement-t.html). |
| `TSource` | The type of the source element implementing [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetElement` | `TTarget` | The target JSON object element to which properties will be applied. |
| `sourceElement` | `ref TSource` | The source JSON object element from which properties will be copied. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The source element's [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |

### Remarks

This method performs a merge of properties from the source JSON object to the target JSON object. Each property from the source object is copied to the target object, replacing any existing properties with the same name. The source element must be a JSON object element. The target element is assumed to be valid and is not validated by this method. This method is not CLS-compliant due to its generic constraint requirements.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

