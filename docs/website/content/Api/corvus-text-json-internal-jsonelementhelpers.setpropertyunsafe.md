---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.SetPropertyUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## SetPropertyUnsafe {#setpropertyunsafe}

```csharp
public static void SetPropertyUnsafe<TTarget, TValue>(TTarget targetElement, JsonProperty<TValue> property)
```

Sets a property value on a target element.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TTarget` | The type of the target element. |
| `TValue` | The type of the value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetElement` | `TTarget` | The target element instance. |
| `property` | [`JsonProperty<TValue>`](/api/corvus-text-json-jsonproperty-tvalue.html) | The property to set. |

