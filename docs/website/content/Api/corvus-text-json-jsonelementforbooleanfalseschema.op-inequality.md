---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.Inequality Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Operator | Description |
|----------|-------------|
| [operator !=(JsonElementForBooleanFalseSchema, JsonElementForBooleanFalseSchema)](#operator-jsonelementforbooleanfalseschema-jsonelementforbooleanfalseschema) | Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are not equal. |
| [operator !=(JsonElementForBooleanFalseSchema, JsonElement)](#operator-jsonelementforbooleanfalseschema-jsonelement) | Determines whether a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) and a [`JsonElement`](/api/corvus-text-json-jsonelement.html) are not equal. |

## operator !=(JsonElementForBooleanFalseSchema, JsonElementForBooleanFalseSchema) {#operator-jsonelementforbooleanfalseschema-jsonelementforbooleanfalseschema}

```csharp
public static bool operator !=(JsonElementForBooleanFalseSchema left, JsonElementForBooleanFalseSchema right)
```

Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are not equal.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) | The first instance to compare. |
| `right` | [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) | The second instance to compare. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the instances are not equal; otherwise, `false`.

---

## operator !=(JsonElementForBooleanFalseSchema, JsonElement) {#operator-jsonelementforbooleanfalseschema-jsonelement}

```csharp
public static bool operator !=(JsonElementForBooleanFalseSchema left, JsonElement right)
```

Determines whether a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) and a [`JsonElement`](/api/corvus-text-json-jsonelement.html) are not equal.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) | The [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instance to compare. |
| `right` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | The [`JsonElement`](/api/corvus-text-json-jsonelement.html) instance to compare. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the instances are not equal; otherwise, `false`.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

