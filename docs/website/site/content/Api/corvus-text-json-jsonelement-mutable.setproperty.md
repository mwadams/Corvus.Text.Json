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
| [SetProperty(string, ref JsonElement.Source)](#setproperty-string-ref-jsonelement-source) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Source, int)](#setproperty-readonlyspan-char-ref-jsonelement-source-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Source, int)](#setproperty-readonlyspan-byte-ref-jsonelement-source-int) |  |
| [SetProperty(string, JsonElement.ObjectBuilder.Build, int)](#setproperty-string-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(string, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#setproperty-string-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build, int)](#setproperty-readonlyspan-char-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#setproperty-readonlyspan-char-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, int)](#setproperty-readonlyspan-byte-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](#setproperty-readonlyspan-byte-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(string, JsonElement.ArrayBuilder.Build, int)](#setproperty-string-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(string, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#setproperty-string-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build, int)](#setproperty-readonlyspan-char-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#setproperty-readonlyspan-char-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, int)](#setproperty-readonlyspan-byte-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](#setproperty-readonlyspan-byte-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |

## SetProperty(string, ref JsonElement.Source) {#setproperty-string-ref-jsonelement-source}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4338)

```csharp
public void SetProperty(string propertyName, ref JsonElement.Source source)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Source, int) {#setproperty-readonlyspan-char-ref-jsonelement-source-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4361)

```csharp
public void SetProperty(ReadOnlySpan<char> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Source, int) {#setproperty-readonlyspan-byte-ref-jsonelement-source-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4406)

```csharp
public void SetProperty(ReadOnlySpan<byte> propertyName, ref JsonElement.Source source, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `source` | [`ref JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(string, JsonElement.ObjectBuilder.Build, int) {#setproperty-string-jsonelement-objectbuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4457)

```csharp
public void SetProperty(string propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(string, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#setproperty-string-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build, int) {#setproperty-readonlyspan-char-jsonelement-objectbuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4523)

```csharp
public void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;char&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#setproperty-readonlyspan-char-tcontext-jsonelement-objectbuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(ReadOnlySpan<char> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, int) {#setproperty-readonlyspan-byte-jsonelement-objectbuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4626)

```csharp
public void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;byte&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int) {#setproperty-readonlyspan-byte-tcontext-jsonelement-objectbuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, TContext context, JsonElement.ObjectBuilder.Build<TContext> objectValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `TContext` |  |
| `objectValue` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(string, JsonElement.ArrayBuilder.Build, int) {#setproperty-string-jsonelement-arraybuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4726)

```csharp
public void SetProperty(string propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(string, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#setproperty-string-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(string propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build, int) {#setproperty-readonlyspan-char-jsonelement-arraybuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4792)

```csharp
public void SetProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#setproperty-readonlyspan-char-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, int) {#setproperty-readonlyspan-byte-jsonelement-arraybuilder-build-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4895)

```csharp
public void SetProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## SetProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int) {#setproperty-readonlyspan-byte-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void SetProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> arrayValue, int estimatedMemberCount)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `arrayValue` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `estimatedMemberCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

