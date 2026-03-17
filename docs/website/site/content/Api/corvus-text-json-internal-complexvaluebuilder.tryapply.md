---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.TryApply Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

## TryApply {#tryapply}

Tries to apply an object instance value to the document.

```csharp
public bool TryApply<T>(ref T value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the `value`. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The value to apply. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was applied.

### Remarks

If the value is a JSON object, its properties (if any) will be set on the current document, replacing any existing values if present, and the method returns `true`. Otherwise, no changes are made, and the method returns `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

