---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddItem Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddItem(ReadOnlySpan&lt;byte&gt;)](#void-additem-readonlyspan-byte-utf8string) | Adds an item to the current array as a UTF-8 string. |
| [AddItem(string)](#void-additem-string-value) | Adds an item to the current array as a string. |
| [AddItem(ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-additem-readonlyspan-byte-utf8string-bool-escapevalue-bool-requiresunescaping) | Adds an item to the current array as a UTF-8 string with control over escaping. |
| [AddItem(ReadOnlySpan&lt;char&gt;)](#void-additem-readonlyspan-char-value) | Adds an item to the current array as a character span. |
| [AddItem(ComplexValueBuilder.ValueBuilderAction)](#void-additem-complexvaluebuilder-valuebuilderaction-createvalue) |  |
| [AddItem(ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#void-additem-tcontext-ref-tcontext-context-complexvaluebuilder-valuebuilderaction-tcontext-createvalue) |  |
| [AddItem(bool)](#void-additem-bool-value) | Adds a boolean item to the current array. |
| [AddItem(ref T)](#void-additem-t-ref-t-value) | Adds a JSON element item to the current array. |
| [AddItem(Guid)](#void-additem-guid-value) | Adds a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) item to the current array. |
| [AddItem(ref DateTime)](#void-additem-ref-datetime-value) | Adds a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) item to the current array. |
| [AddItem(ref DateTimeOffset)](#void-additem-ref-datetimeoffset-value) | Adds a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) item to the current array. |
| [AddItem(ref OffsetDateTime)](#void-additem-ref-offsetdatetime-value) | Adds an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) item to the current array. |
| [AddItem(ref OffsetDate)](#void-additem-ref-offsetdate-value) | Adds an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) item to the current array. |
| [AddItem(ref OffsetTime)](#void-additem-ref-offsettime-value) | Adds an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) item to the current array. |
| [AddItem(ref LocalDate)](#void-additem-ref-localdate-value) | Adds a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) item to the current array. |
| [AddItem(ref Period)](#void-additem-ref-period-value) | Adds a [`Period`](/api/corvus-text-json-period.html) item to the current array. |
| [AddItem(sbyte)](#void-additem-sbyte-value) | Adds an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) item to the current array. |
| [AddItem(byte)](#void-additem-byte-value) | Adds a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) item to the current array. |
| [AddItem(int)](#void-additem-int-value) | Adds an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) item to the current array. |
| [AddItem(uint)](#void-additem-uint-value) | Adds a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) item to the current array. |
| [AddItem(long)](#void-additem-long-value) | Adds a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) item to the current array. |
| [AddItem(ulong)](#void-additem-ulong-value) | Adds a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) item to the current array. |
| [AddItem(short)](#void-additem-short-value) | Adds a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) item to the current array. |
| [AddItem(ushort)](#void-additem-ushort-value) | Adds a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) item to the current array. |
| [AddItem(float)](#void-additem-float-value) | Adds a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) item to the current array. |
| [AddItem(double)](#void-additem-double-value) | Adds a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) item to the current array. |
| [AddItem(decimal)](#void-additem-decimal-value) | Adds a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) item to the current array. |
| [AddItem(ref BigNumber)](#void-additem-ref-bignumber-value) | Adds a [`BigNumber`](/api/corvus-numerics-bignumber.html) item to the current array. |
| [AddItem(ref BigInteger)](#void-additem-ref-biginteger-value) | Adds a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) item to the current array. |
| [AddItem(Int128)](#void-additem-int128-value) | Adds an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) item to the current array. |
| [AddItem(UInt128)](#void-additem-uint128-value) | Adds a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) item to the current array. |
| [AddItem(Half)](#void-additem-half-value) | Adds a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) item to the current array. |

## AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String)
```

Adds an item to the current array as a UTF-8 string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |

---

## AddItem

```csharp
void AddItem(string value)
```

Adds an item to the current array as a string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The item value as a string. |

---

## AddItem

```csharp
void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue, bool requiresUnescaping)
```

Adds an item to the current array as a UTF-8 string with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the value. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

---

## AddItem

```csharp
void AddItem(ReadOnlySpan<char> value)
```

Adds an item to the current array as a character span.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a character span. |

---

## AddItem

```csharp
void AddItem(ComplexValueBuilder.ValueBuilderAction createValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `createValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddItem

```csharp
void AddItem<TContext>(ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `createValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddItem

```csharp
void AddItem(bool value)
```

Adds a boolean item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

---

## AddItem

```csharp
void AddItem<T>(ref T value)
```

Adds a JSON element item to the current array.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The JSON element value. |

---

## AddItem

```csharp
void AddItem(Guid value)
```

Adds a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

---

## AddItem

```csharp
void AddItem(ref DateTime value)
```

Adds a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

---

## AddItem

```csharp
void AddItem(ref DateTimeOffset value)
```

Adds a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

---

## AddItem

```csharp
void AddItem(ref OffsetDateTime value)
```

Adds an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

---

## AddItem

```csharp
void AddItem(ref OffsetDate value)
```

Adds an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

---

## AddItem

```csharp
void AddItem(ref OffsetTime value)
```

Adds an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

---

## AddItem

```csharp
void AddItem(ref LocalDate value)
```

Adds a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

---

## AddItem

```csharp
void AddItem(ref Period value)
```

Adds a [`Period`](/api/corvus-text-json-period.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value. |

---

## AddItem

```csharp
void AddItem(sbyte value)
```

Adds an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

---

## AddItem

```csharp
void AddItem(byte value)
```

Adds a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

---

## AddItem

```csharp
void AddItem(int value)
```

Adds an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

---

## AddItem

```csharp
void AddItem(uint value)
```

Adds a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

---

## AddItem

```csharp
void AddItem(long value)
```

Adds a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

---

## AddItem

```csharp
void AddItem(ulong value)
```

Adds a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

---

## AddItem

```csharp
void AddItem(short value)
```

Adds a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

---

## AddItem

```csharp
void AddItem(ushort value)
```

Adds a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

---

## AddItem

```csharp
void AddItem(float value)
```

Adds a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

---

## AddItem

```csharp
void AddItem(double value)
```

Adds a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

---

## AddItem

```csharp
void AddItem(decimal value)
```

Adds a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

---

## AddItem

```csharp
void AddItem(ref BigNumber value)
```

Adds a [`BigNumber`](/api/corvus-numerics-bignumber.html) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

---

## AddItem

```csharp
void AddItem(ref BigInteger value)
```

Adds a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

---

## AddItem

```csharp
void AddItem(Int128 value)
```

Adds an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

---

## AddItem

```csharp
void AddItem(UInt128 value)
```

Adds a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

---

## AddItem

```csharp
void AddItem(Half value)
```

Adds a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) item to the current array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

---

