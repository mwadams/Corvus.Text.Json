---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.SetProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [SetProperty(string, ref JsonElement.Source)](#void-setproperty-string-propertyname-ref-jsonelement-source-source) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Source, int)](#void-setproperty-readonlyspan-char-propertyname-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Source, int)](#void-setproperty-readonlyspan-byte-propertyname-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetProperty(string, JsonElement.ObjectBuilder.Build, int)](#void-setproperty-string-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(string, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-string-propertyname-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build, int)](#void-setproperty-readonlyspan-char-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-readonlyspan-char-propertyname-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, int)](#void-setproperty-readonlyspan-byte-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-readonlyspan-byte-propertyname-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(string, JsonElement.ArrayBuilder.Build, int)](#void-setproperty-string-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(string, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-string-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build, int)](#void-setproperty-readonlyspan-char-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-readonlyspan-char-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, int)](#void-setproperty-readonlyspan-byte-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#void-setproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |

## SetProperty

```csharp
void SetProperty(string propertyName, ref JsonElement.Source source)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(string propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

## SetProperty

```csharp
void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

---

