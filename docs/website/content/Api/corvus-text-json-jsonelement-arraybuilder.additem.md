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
| [AddItem(JsonElement.ObjectBuilder.Build)](#void-additem-jsonelement-objectbuilder-build-value) |  |
| [AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;)](#void-additem-tcontext-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-value) |  |
| [AddItem(JsonElement.ArrayBuilder.Build)](#void-additem-jsonelement-arraybuilder-build-value) |  |
| [AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;)](#void-additem-tcontext-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-value) |  |
| [AddItem(string)](#void-additem-string-value) |  |
| [AddItem(ReadOnlySpan&lt;char&gt;)](#void-additem-readonlyspan-char-value) |  |
| [AddItem(ReadOnlySpan&lt;byte&gt;)](#void-additem-readonlyspan-byte-utf8string) |  |
| [AddItem(bool)](#void-additem-bool-value) |  |
| [AddItem(T)](#void-additem-t-t-value) |  |
| [AddItem(Guid)](#void-additem-guid-value) |  |
| [AddItem(ref DateTime)](#void-additem-ref-datetime-value) |  |
| [AddItem(ref DateTimeOffset)](#void-additem-ref-datetimeoffset-value) |  |
| [AddItem(ref OffsetDateTime)](#void-additem-ref-offsetdatetime-value) |  |
| [AddItem(ref OffsetDate)](#void-additem-ref-offsetdate-value) |  |
| [AddItem(ref OffsetTime)](#void-additem-ref-offsettime-value) |  |
| [AddItem(ref LocalDate)](#void-additem-ref-localdate-value) |  |
| [AddItem(ref Period)](#void-additem-ref-period-value) |  |
| [AddItem(sbyte)](#void-additem-sbyte-value) |  |
| [AddItem(byte)](#void-additem-byte-value) |  |
| [AddItem(int)](#void-additem-int-value) |  |
| [AddItem(uint)](#void-additem-uint-value) |  |
| [AddItem(long)](#void-additem-long-value) |  |
| [AddItem(ulong)](#void-additem-ulong-value) |  |
| [AddItem(short)](#void-additem-short-value) |  |
| [AddItem(ushort)](#void-additem-ushort-value) |  |
| [AddItem(float)](#void-additem-float-value) |  |
| [AddItem(double)](#void-additem-double-value) |  |
| [AddItem(decimal)](#void-additem-decimal-value) |  |
| [AddItem(ref BigInteger)](#void-additem-ref-biginteger-value) |  |
| [AddItem(ref BigNumber)](#void-additem-ref-bignumber-value) |  |
| [AddItem(Int128)](#void-additem-int128-value) |  |
| [AddItem(UInt128)](#void-additem-uint128-value) |  |
| [AddItem(Half)](#void-additem-half-value) |  |

## AddItem

```csharp
void AddItem(JsonElement.ObjectBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ObjectBuilder.Build`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ObjectBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ObjectBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-objectbuilder-build.html) |  |

---

## AddItem

```csharp
void AddItem(JsonElement.ArrayBuilder.Build value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonElement.ArrayBuilder.Build`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddItem

```csharp
void AddItem<TContext>(ref TContext context, JsonElement.ArrayBuilder.Build<TContext> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `value` | [`JsonElement.ArrayBuilder.Build<TContext>`](/api/corvus-text-json-jsonelement-arraybuilder-build.html) |  |

---

## AddItem

```csharp
void AddItem(string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddItem

```csharp
void AddItem(bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddItem

```csharp
void AddItem<T>(T value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |

---

## AddItem

```csharp
void AddItem(Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) |  |

---

## AddItem

```csharp
void AddItem(ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) |  |

---

## AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) |  |

---

## AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) |  |

---

## AddItem

```csharp
void AddItem(ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) |  |

---

## AddItem

```csharp
void AddItem(ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) |  |

---

## AddItem

```csharp
void AddItem(ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) |  |

---

## AddItem

```csharp
void AddItem(ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) |  |

---

## AddItem

```csharp
void AddItem(sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) |  |

---

## AddItem

```csharp
void AddItem(byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) |  |

---

## AddItem

```csharp
void AddItem(int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

---

## AddItem

```csharp
void AddItem(uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) |  |

---

## AddItem

```csharp
void AddItem(long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) |  |

---

## AddItem

```csharp
void AddItem(ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) |  |

---

## AddItem

```csharp
void AddItem(short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) |  |

---

## AddItem

```csharp
void AddItem(ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) |  |

---

## AddItem

```csharp
void AddItem(float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) |  |

---

## AddItem

```csharp
void AddItem(double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) |  |

---

## AddItem

```csharp
void AddItem(decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) |  |

---

## AddItem

```csharp
void AddItem(ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

---

## AddItem

```csharp
void AddItem(ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) |  |

---

## AddItem

```csharp
void AddItem(Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) |  |

---

## AddItem

```csharp
void AddItem(UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) |  |

---

## AddItem

```csharp
void AddItem(Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) |  |

---

