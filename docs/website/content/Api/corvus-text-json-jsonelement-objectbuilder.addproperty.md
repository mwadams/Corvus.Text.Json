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
| [AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, bool, bool)](#addproperty-readonlyspan-byte-jsonelement-objectbuilder-build-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, bool, bool)](#addproperty-readonlyspan-byte-ref-tcontext-jsonelement-objectbuilder-build-tcontext-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, bool, bool)](#addproperty-readonlyspan-byte-jsonelement-arraybuilder-build-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, bool, bool)](#addproperty-readonlyspan-byte-ref-tcontext-jsonelement-arraybuilder-build-tcontext-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addproperty-readonlyspan-byte-readonlyspan-byte-bool-bool) |  |
| [AddProperty(string, string)](#addproperty-string-string) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#addproperty-readonlyspan-char-readonlyspan-char) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#addproperty-readonlyspan-byte-bool-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool)](#addproperty-readonlyspan-byte-t-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, string, bool, bool)](#addproperty-readonlyspan-byte-string-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool)](#addproperty-readonlyspan-byte-readonlyspan-char-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool)](#addproperty-readonlyspan-byte-guid-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool)](#addproperty-readonlyspan-byte-ref-datetime-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool)](#addproperty-readonlyspan-byte-ref-datetimeoffset-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool)](#addproperty-readonlyspan-byte-ref-offsetdatetime-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool)](#addproperty-readonlyspan-byte-ref-offsetdate-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool)](#addproperty-readonlyspan-byte-ref-offsettime-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool)](#addproperty-readonlyspan-byte-ref-localdate-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool)](#addproperty-readonlyspan-byte-ref-period-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool)](#addproperty-readonlyspan-byte-sbyte-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool)](#addproperty-readonlyspan-byte-byte-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool)](#addproperty-readonlyspan-byte-int-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool)](#addproperty-readonlyspan-byte-uint-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool)](#addproperty-readonlyspan-byte-long-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool)](#addproperty-readonlyspan-byte-ulong-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool)](#addproperty-readonlyspan-byte-short-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool)](#addproperty-readonlyspan-byte-ushort-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool)](#addproperty-readonlyspan-byte-float-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool)](#addproperty-readonlyspan-byte-double-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool)](#addproperty-readonlyspan-byte-decimal-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool)](#addproperty-readonlyspan-byte-ref-biginteger-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool)](#addproperty-readonlyspan-byte-ref-bignumber-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build)](#addproperty-readonlyspan-char-jsonelement-objectbuilder-build) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build)](#addproperty-readonlyspan-char-jsonelement-arraybuilder-build) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;)](#addproperty-readonlyspan-char-ref-tcontext-jsonelement-arraybuilder-build-tcontext) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addproperty-readonlyspan-char-readonlyspan-byte-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, bool)](#addproperty-readonlyspan-char-bool) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, T)](#addproperty-readonlyspan-char-t) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Guid)](#addproperty-readonlyspan-char-guid) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime)](#addproperty-readonlyspan-char-ref-datetime) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset)](#addproperty-readonlyspan-char-ref-datetimeoffset) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime)](#addproperty-readonlyspan-char-ref-offsetdatetime) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate)](#addproperty-readonlyspan-char-ref-offsetdate) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime)](#addproperty-readonlyspan-char-ref-offsettime) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate)](#addproperty-readonlyspan-char-ref-localdate) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref Period)](#addproperty-readonlyspan-char-ref-period) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, sbyte)](#addproperty-readonlyspan-char-sbyte) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, byte)](#addproperty-readonlyspan-char-byte) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, int)](#addproperty-readonlyspan-char-int) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, uint)](#addproperty-readonlyspan-char-uint) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, long)](#addproperty-readonlyspan-char-long) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ulong)](#addproperty-readonlyspan-char-ulong) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, short)](#addproperty-readonlyspan-char-short) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ushort)](#addproperty-readonlyspan-char-ushort) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, float)](#addproperty-readonlyspan-char-float) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, double)](#addproperty-readonlyspan-char-double) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, decimal)](#addproperty-readonlyspan-char-decimal) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger)](#addproperty-readonlyspan-char-ref-biginteger) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#addproperty-readonlyspan-char-ref-bignumber) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool)](#addproperty-readonlyspan-byte-int128-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool)](#addproperty-readonlyspan-byte-uint128-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool)](#addproperty-readonlyspan-byte-half-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Int128)](#addproperty-readonlyspan-char-int128) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, UInt128)](#addproperty-readonlyspan-char-uint128) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Half)](#addproperty-readonlyspan-char-half) |  |

## AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, bool, bool) {#addproperty-readonlyspan-byte-jsonelement-objectbuilder-build-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ObjectBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, bool, bool) {#addproperty-readonlyspan-byte-ref-tcontext-jsonelement-objectbuilder-build-tcontext-bool-bool}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, bool, bool) {#addproperty-readonlyspan-byte-jsonelement-arraybuilder-build-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, JsonElement.ArrayBuilder.Build value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, bool, bool) {#addproperty-readonlyspan-byte-ref-tcontext-jsonelement-arraybuilder-build-tcontext-bool-bool}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-byte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(string, string) {#addproperty-string-string}

```csharp
public void AddProperty(string propertyName, string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;) {#addproperty-readonlyspan-char-readonlyspan-char}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool) {#addproperty-readonlyspan-byte-bool-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool) {#addproperty-readonlyspan-byte-t-bool-bool}

```csharp
public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, string, bool, bool) {#addproperty-readonlyspan-byte-string-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, string value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-char-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool) {#addproperty-readonlyspan-byte-guid-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-datetime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool) {#addproperty-readonlyspan-byte-ref-datetimeoffset-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdatetime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdate-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsettime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool) {#addproperty-readonlyspan-byte-ref-localdate-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool) {#addproperty-readonlyspan-byte-ref-period-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool) {#addproperty-readonlyspan-byte-sbyte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool) {#addproperty-readonlyspan-byte-byte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool) {#addproperty-readonlyspan-byte-int-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool) {#addproperty-readonlyspan-byte-uint-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool) {#addproperty-readonlyspan-byte-long-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool) {#addproperty-readonlyspan-byte-ulong-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool) {#addproperty-readonlyspan-byte-short-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool) {#addproperty-readonlyspan-byte-ushort-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool) {#addproperty-readonlyspan-byte-float-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool) {#addproperty-readonlyspan-byte-double-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool) {#addproperty-readonlyspan-byte-decimal-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool) {#addproperty-readonlyspan-byte-ref-biginteger-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool) {#addproperty-readonlyspan-byte-ref-bignumber-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build) {#addproperty-readonlyspan-char-jsonelement-objectbuilder-build}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ObjectBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build) {#addproperty-readonlyspan-char-jsonelement-arraybuilder-build}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, JsonElement.ArrayBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;) {#addproperty-readonlyspan-char-ref-tcontext-jsonelement-arraybuilder-build-tcontext}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addproperty-readonlyspan-char-readonlyspan-byte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8String, bool escapeValue, bool valueRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, bool) {#addproperty-readonlyspan-char-bool}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, T) {#addproperty-readonlyspan-char-t}

```csharp
public void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | `T` |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Guid) {#addproperty-readonlyspan-char-guid}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime) {#addproperty-readonlyspan-char-ref-datetime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset) {#addproperty-readonlyspan-char-ref-datetimeoffset}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime) {#addproperty-readonlyspan-char-ref-offsetdatetime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate) {#addproperty-readonlyspan-char-ref-offsetdate}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime) {#addproperty-readonlyspan-char-ref-offsettime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate) {#addproperty-readonlyspan-char-ref-localdate}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref Period) {#addproperty-readonlyspan-char-ref-period}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, sbyte) {#addproperty-readonlyspan-char-sbyte}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, byte) {#addproperty-readonlyspan-char-byte}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, int) {#addproperty-readonlyspan-char-int}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, uint) {#addproperty-readonlyspan-char-uint}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, long) {#addproperty-readonlyspan-char-long}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ulong) {#addproperty-readonlyspan-char-ulong}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, short) {#addproperty-readonlyspan-char-short}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ushort) {#addproperty-readonlyspan-char-ushort}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, float) {#addproperty-readonlyspan-char-float}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, double) {#addproperty-readonlyspan-char-double}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, decimal) {#addproperty-readonlyspan-char-decimal}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger) {#addproperty-readonlyspan-char-ref-biginteger}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber) {#addproperty-readonlyspan-char-ref-bignumber}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool) {#addproperty-readonlyspan-byte-int128-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool) {#addproperty-readonlyspan-byte-uint128-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool) {#addproperty-readonlyspan-byte-half-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Int128) {#addproperty-readonlyspan-char-int128}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, UInt128) {#addproperty-readonlyspan-char-uint128}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Half) {#addproperty-readonlyspan-char-half}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

