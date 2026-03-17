---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.CreateBuilder Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [CreateBuilder(JsonWorkspace, ref JsonElement.Source, int)](#createbuilder-jsonworkspace-ref-jsonelement-source-int) |  |
| [CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#createbuilder-jsonworkspace-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#createbuilder-jsonworkspace-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [CreateBuilder(JsonWorkspace)](#createbuilder-jsonworkspace) | Creates a mutable document builder from this JsonElement using the specified workspace. |

## CreateBuilder(JsonWorkspace, ref JsonElement.Source, int) {#createbuilder-jsonworkspace-ref-jsonelement-source-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1518)

```csharp
public static JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#createbuilder-jsonworkspace-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L24)

```csharp
public static JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> builder, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `context` | `ref TContext` |  |
| `builder` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#createbuilder-jsonworkspace-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L24)

```csharp
public static JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder<TContext>(JsonWorkspace workspace, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> builder, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) |  |
| `context` | `ref TContext` |  |
| `builder` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CreateBuilder(JsonWorkspace) {#createbuilder-jsonworkspace}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L235)

Creates a mutable document builder from this JsonElement using the specified workspace.

```csharp
public JsonDocumentBuilder<JsonElement.Mutable> CreateBuilder(JsonWorkspace workspace)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JsonWorkspace to use for creating the document builder. |

### Returns

[`JsonDocumentBuilder<JsonElement.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JsonDocumentBuilder configured for mutable operations on this JsonElement.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

