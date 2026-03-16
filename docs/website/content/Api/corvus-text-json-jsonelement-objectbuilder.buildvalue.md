---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.BuildValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [BuildValue(JsonElement.ObjectBuilder.Build, ref ComplexValueBuilder)](#buildvalue-jsonelement-objectbuilder-build-ref-complexvaluebuilder) |  |
| [BuildValue(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, ref ComplexValueBuilder)](#buildvalue-ref-tcontext-jsonelement-objectbuilder-build-tcontext-ref-complexvaluebuilder) |  |

## BuildValue(JsonElement.ObjectBuilder.Build, ref ComplexValueBuilder) {#buildvalue-jsonelement-objectbuilder-build-ref-complexvaluebuilder}

```csharp
void BuildValue(JsonElement.ObjectBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

## BuildValue(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, ref ComplexValueBuilder) {#buildvalue-ref-tcontext-jsonelement-objectbuilder-build-tcontext-ref-complexvaluebuilder}

```csharp
void BuildValue<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

