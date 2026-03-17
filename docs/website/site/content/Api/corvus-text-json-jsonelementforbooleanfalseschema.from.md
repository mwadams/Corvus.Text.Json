---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.From Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementForBooleanFalseSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonElementForBooleanFalseSchema.cs#L20)

## From {#from}

Creates a new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) from the specified JSON element instance.

```csharp
public static JsonElementForBooleanFalseSchema From<T>(ref T instance)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `instance` | `ref T` | The JSON element instance to create from. |

### Returns

[`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html)

A new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instance.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

