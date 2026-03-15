---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.AddProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-jsonelement-objectbuilder-build-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, bool, bool)](#void-addproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-jsonelement-arraybuilder-build-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, bool, bool)](#void-addproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-readonlyspan-byte-utf8string-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(string, string)](#void-addproperty-string-propertyname-string-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#void-addproperty-readonlyspan-char-propertyname-readonlyspan-char-value) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-bool-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool)](#void-addproperty-t-readonlyspan-byte-propertyname-t-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, string, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-string-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-readonlyspan-char-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-guid-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetime-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetimeoffset-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdatetime-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdate-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsettime-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-localdate-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-period-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-sbyte-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-byte-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-int-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-uint-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-long-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ulong-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-short-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ushort-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-float-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-double-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-decimal-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-biginteger-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-bignumber-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build)](#void-addproperty-readonlyspan-char-propertyname-jsonelement-objectbuilder-build-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build)](#void-addproperty-readonlyspan-char-propertyname-jsonelement-arraybuilder-build-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;)](#void-addproperty-tcontext-readonlyspan-char-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-addproperty-readonlyspan-char-propertyname-readonlyspan-byte-utf8string-bool-escapevalue-bool-valuerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, bool)](#void-addproperty-readonlyspan-char-propertyname-bool-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, T)](#void-addproperty-t-readonlyspan-char-propertyname-t-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Guid)](#void-addproperty-readonlyspan-char-propertyname-guid-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime)](#void-addproperty-readonlyspan-char-propertyname-ref-datetime-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset)](#void-addproperty-readonlyspan-char-propertyname-ref-datetimeoffset-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime)](#void-addproperty-readonlyspan-char-propertyname-ref-offsetdatetime-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate)](#void-addproperty-readonlyspan-char-propertyname-ref-offsetdate-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime)](#void-addproperty-readonlyspan-char-propertyname-ref-offsettime-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate)](#void-addproperty-readonlyspan-char-propertyname-ref-localdate-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref Period)](#void-addproperty-readonlyspan-char-propertyname-ref-period-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, sbyte)](#void-addproperty-readonlyspan-char-propertyname-sbyte-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, byte)](#void-addproperty-readonlyspan-char-propertyname-byte-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, int)](#void-addproperty-readonlyspan-char-propertyname-int-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, uint)](#void-addproperty-readonlyspan-char-propertyname-uint-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, long)](#void-addproperty-readonlyspan-char-propertyname-long-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ulong)](#void-addproperty-readonlyspan-char-propertyname-ulong-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, short)](#void-addproperty-readonlyspan-char-propertyname-short-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ushort)](#void-addproperty-readonlyspan-char-propertyname-ushort-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, float)](#void-addproperty-readonlyspan-char-propertyname-float-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, double)](#void-addproperty-readonlyspan-char-propertyname-double-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, decimal)](#void-addproperty-readonlyspan-char-propertyname-decimal-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger)](#void-addproperty-readonlyspan-char-propertyname-ref-biginteger-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#void-addproperty-readonlyspan-char-propertyname-ref-bignumber-value) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-int128-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-uint128-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-half-value-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Int128)](#void-addproperty-readonlyspan-char-propertyname-int128-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, UInt128)](#void-addproperty-readonlyspan-char-propertyname-uint128-value) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Half)](#void-addproperty-readonlyspan-char-propertyname-half-value) |  |

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(string propertyName, string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, string value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8String, bool escapeValue, bool valueRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

---

