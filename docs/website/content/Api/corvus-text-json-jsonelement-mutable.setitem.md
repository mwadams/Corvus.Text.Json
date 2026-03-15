---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.SetItem Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [SetItem(int, ref JsonElement.Source, int)](#void-setitem-int-itemindex-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetItem(int, JsonElement.ObjectBuilder.Build, int)](#void-setitem-int-itemindex-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#void-setitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetItem(int, JsonElement.ArrayBuilder.Build, int)](#void-setitem-int-itemindex-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#void-setitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |

## SetItem

```csharp
void SetItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetItem

```csharp
void SetItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetItem

```csharp
void SetItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

