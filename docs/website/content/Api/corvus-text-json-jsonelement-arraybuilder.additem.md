---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ArrayBuilder.AddItem Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddItem(JsonElement.ObjectBuilder.Build)](#additem-jsonelement-objectbuilder-build) |  |
| [AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;)](#additem-ref-tcontext-jsonelement-objectbuilder-build-tcontext) |  |
| [AddItem(JsonElement.ArrayBuilder.Build)](#additem-jsonelement-arraybuilder-build) |  |
| [AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;)](#additem-ref-tcontext-jsonelement-arraybuilder-build-tcontext) |  |
| [AddItem(string)](#additem-string) |  |
| [AddItem(ReadOnlySpan&lt;char&gt;)](#additem-readonlyspan-char) |  |
| [AddItem(ReadOnlySpan&lt;byte&gt;)](#additem-readonlyspan-byte) |  |
| [AddItem(bool)](#additem-bool) |  |
| [AddItem(T)](#additem-t) |  |
| [AddItem(Guid)](#additem-guid) |  |
| [AddItem(ref DateTime)](#additem-ref-datetime) |  |
| [AddItem(ref DateTimeOffset)](#additem-ref-datetimeoffset) |  |
| [AddItem(ref OffsetDateTime)](#additem-ref-offsetdatetime) |  |
| [AddItem(ref OffsetDate)](#additem-ref-offsetdate) |  |
| [AddItem(ref OffsetTime)](#additem-ref-offsettime) |  |
| [AddItem(ref LocalDate)](#additem-ref-localdate) |  |
| [AddItem(ref Period)](#additem-ref-period) |  |
| [AddItem(sbyte)](#additem-sbyte) |  |
| [AddItem(byte)](#additem-byte) |  |
| [AddItem(int)](#additem-int) |  |
| [AddItem(uint)](#additem-uint) |  |
| [AddItem(long)](#additem-long) |  |
| [AddItem(ulong)](#additem-ulong) |  |
| [AddItem(short)](#additem-short) |  |
| [AddItem(ushort)](#additem-ushort) |  |
| [AddItem(float)](#additem-float) |  |
| [AddItem(double)](#additem-double) |  |
| [AddItem(decimal)](#additem-decimal) |  |
| [AddItem(ref BigInteger)](#additem-ref-biginteger) |  |
| [AddItem(ref BigNumber)](#additem-ref-bignumber) |  |
| [AddItem(Int128)](#additem-int128) |  |
| [AddItem(UInt128)](#additem-uint128) |  |
| [AddItem(Half)](#additem-half) |  |

## AddItem(JsonElement.ObjectBuilder.Build) {#additem-jsonelement-objectbuilder-build}

```csharp
public void AddItem(JsonElement.ObjectBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;) {#additem-ref-tcontext-jsonelement-objectbuilder-build-tcontext}

```csharp
public void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddItem(JsonElement.ArrayBuilder.Build) {#additem-jsonelement-arraybuilder-build}

```csharp
public void AddItem(JsonElement.ArrayBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;) {#additem-ref-tcontext-jsonelement-arraybuilder-build-tcontext}

```csharp
public void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddItem(string) {#additem-string}

```csharp
public void AddItem(string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## AddItem(ReadOnlySpan&lt;char&gt;) {#additem-readonlyspan-char}

```csharp
public void AddItem(ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddItem(ReadOnlySpan&lt;byte&gt;) {#additem-readonlyspan-byte}

```csharp
public void AddItem(ReadOnlySpan<byte> utf8String)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddItem(bool) {#additem-bool}

```csharp
public void AddItem(bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddItem(T) {#additem-t}

```csharp
public void AddItem<T>(T value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |

---

## AddItem(Guid) {#additem-guid}

```csharp
public void AddItem(Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

---

## AddItem(ref DateTime) {#additem-ref-datetime}

```csharp
public void AddItem(ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

---

## AddItem(ref DateTimeOffset) {#additem-ref-datetimeoffset}

```csharp
public void AddItem(ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

---

## AddItem(ref OffsetDateTime) {#additem-ref-offsetdatetime}

```csharp
public void AddItem(ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |

---

## AddItem(ref OffsetDate) {#additem-ref-offsetdate}

```csharp
public void AddItem(ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |

---

## AddItem(ref OffsetTime) {#additem-ref-offsettime}

```csharp
public void AddItem(ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |

---

## AddItem(ref LocalDate) {#additem-ref-localdate}

```csharp
public void AddItem(ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |

---

## AddItem(ref Period) {#additem-ref-period}

```csharp
public void AddItem(ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

---

## AddItem(sbyte) {#additem-sbyte}

```csharp
public void AddItem(sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

---

## AddItem(byte) {#additem-byte}

```csharp
public void AddItem(byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

---

## AddItem(int) {#additem-int}

```csharp
public void AddItem(int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

---

## AddItem(uint) {#additem-uint}

```csharp
public void AddItem(uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

---

## AddItem(long) {#additem-long}

```csharp
public void AddItem(long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

---

## AddItem(ulong) {#additem-ulong}

```csharp
public void AddItem(ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

---

## AddItem(short) {#additem-short}

```csharp
public void AddItem(short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

---

## AddItem(ushort) {#additem-ushort}

```csharp
public void AddItem(ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

---

## AddItem(float) {#additem-float}

```csharp
public void AddItem(float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

---

## AddItem(double) {#additem-double}

```csharp
public void AddItem(double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

---

## AddItem(decimal) {#additem-decimal}

```csharp
public void AddItem(decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

---

## AddItem(ref BigInteger) {#additem-ref-biginteger}

```csharp
public void AddItem(ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

---

## AddItem(ref BigNumber) {#additem-ref-bignumber}

```csharp
public void AddItem(ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

---

## AddItem(Int128) {#additem-int128}

```csharp
public void AddItem(Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

---

## AddItem(UInt128) {#additem-uint128}

```csharp
public void AddItem(UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

---

## AddItem(Half) {#additem-half}

```csharp
public void AddItem(Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

