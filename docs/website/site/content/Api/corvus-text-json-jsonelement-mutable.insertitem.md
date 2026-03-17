---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.InsertItem Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [InsertItem(int, ref JsonElement.Source, int)](#insertitem-int-ref-jsonelement-source-int) |  |
| [InsertItem(int, JsonElement.ObjectBuilder.Build, int)](#insertitem-int-jsonelement-objectbuilder-build-int) |  |
| [InsertItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#insertitem-int-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [InsertItem(int, JsonElement.ArrayBuilder.Build, int)](#insertitem-int-jsonelement-arraybuilder-build-int) |  |
| [InsertItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#insertitem-int-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |

## InsertItem(int, ref JsonElement.Source, int) {#insertitem-int-ref-jsonelement-source-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L5405)

```csharp
public void InsertItem(int itemIndex, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## InsertItem(int, JsonElement.ObjectBuilder.Build, int) {#insertitem-int-jsonelement-objectbuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L5445)

```csharp
public void InsertItem(int itemIndex, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## InsertItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#insertitem-int-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## InsertItem(int, JsonElement.ArrayBuilder.Build, int) {#insertitem-int-jsonelement-arraybuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L5518)

```csharp
public void InsertItem(int itemIndex, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## InsertItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#insertitem-int-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void InsertItem<TContext>(int itemIndex, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `itemIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

