---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.AddItem Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddItem(ref JsonElement.Source, int)](#additem-ref-jsonelement-source-int) |  |
| [AddItem(JsonElement.ObjectBuilder.Build, int)](#additem-jsonelement-objectbuilder-build-int) |  |
| [AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#additem-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [AddItem(JsonElement.ArrayBuilder.Build, int)](#additem-jsonelement-arraybuilder-build-int) |  |
| [AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#additem-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |

## AddItem(ref JsonElement.Source, int) {#additem-ref-jsonelement-source-int}

```csharp
void AddItem(ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## AddItem(JsonElement.ObjectBuilder.Build, int) {#additem-jsonelement-objectbuilder-build-int}

```csharp
void AddItem(JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#additem-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int}

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## AddItem(JsonElement.ArrayBuilder.Build, int) {#additem-jsonelement-arraybuilder-build-int}

```csharp
void AddItem(JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#additem-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

