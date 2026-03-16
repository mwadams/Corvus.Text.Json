---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.Implicit Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## implicit operator int {#implicit-operator-int}

```csharp
static implicit operator int(JsonElementForBooleanFalseSchema age)
```

Implicitly converts a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) to an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `age` | [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) | The JSON element to convert. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The integer value of the JSON element.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The JSON element cannot be converted to an integer. |

