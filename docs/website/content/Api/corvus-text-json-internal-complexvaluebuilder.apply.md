---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.Apply Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Apply {#apply}

```csharp
void Apply<T>(ref T value)
```

Apply an object instance value to the document.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the `value`. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The value to apply. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if the `value` is not a JSON object. |

### Remarks

The value must be a JSON object. Its properties will be set on the current document, replacing any existing values if present.

