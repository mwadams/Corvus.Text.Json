---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ArrayBuilder.BuildValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [BuildValue(JsonElement.ArrayBuilder.Build, ref ComplexValueBuilder)](#buildvalue-jsonelement-arraybuilder-build-ref-complexvaluebuilder) |  |
| [BuildValue(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, ref ComplexValueBuilder)](#buildvalue-ref-tcontext-jsonelement-arraybuilder-build-tcontext-ref-complexvaluebuilder) |  |

## BuildValue(JsonElement.ArrayBuilder.Build, ref ComplexValueBuilder) {#buildvalue-jsonelement-arraybuilder-build-ref-complexvaluebuilder}

```csharp
public static void BuildValue(JsonElement.ArrayBuilder.Build value, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

## BuildValue(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, ref ComplexValueBuilder) {#buildvalue-ref-tcontext-jsonelement-arraybuilder-build-tcontext-ref-complexvaluebuilder}

```csharp
public static void BuildValue<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

