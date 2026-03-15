---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.StoreValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [StoreValue(Guid)](#int-storevalue-guid-value) | Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document. |
| [StoreValue(ref DateTime)](#int-storevalue-ref-datetime-value) | Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document. |
| [StoreValue(ref DateTimeOffset)](#int-storevalue-ref-datetimeoffset-value) | Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document. |
| [StoreValue(ref OffsetDateTime)](#int-storevalue-ref-offsetdatetime-value) | Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document. |
| [StoreValue(ref OffsetDate)](#int-storevalue-ref-offsetdate-value) | Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document. |
| [StoreValue(ref OffsetTime)](#int-storevalue-ref-offsettime-value) | Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document. |
| [StoreValue(ref LocalDate)](#int-storevalue-ref-localdate-value) | Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document. |
| [StoreValue(ref Period)](#int-storevalue-ref-period-value) | Stores a [`Period`](/api/corvus-text-json-period.html) value in the document. |
| [StoreValue(sbyte)](#int-storevalue-sbyte-value) | Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document. |
| [StoreValue(byte)](#int-storevalue-byte-value) | Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document. |
| [StoreValue(int)](#int-storevalue-int-value) | Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document. |
| [StoreValue(uint)](#int-storevalue-uint-value) | Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document. |
| [StoreValue(long)](#int-storevalue-long-value) | Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document. |
| [StoreValue(ulong)](#int-storevalue-ulong-value) | Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document. |
| [StoreValue(short)](#int-storevalue-short-value) | Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document. |
| [StoreValue(ushort)](#int-storevalue-ushort-value) | Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document. |
| [StoreValue(float)](#int-storevalue-float-value) | Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document. |
| [StoreValue(double)](#int-storevalue-double-value) | Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document. |
| [StoreValue(decimal)](#int-storevalue-decimal-value) | Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document. |
| [StoreValue(ref BigInteger)](#int-storevalue-ref-biginteger-value) | Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document. |
| [StoreValue(ref BigNumber)](#int-storevalue-ref-bignumber-value) | Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document. |
| [StoreValue(Int128)](#int-storevalue-int128-value) | Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document. |
| [StoreValue(UInt128)](#int-storevalue-uint128-value) | Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document. |
| [StoreValue(Half)](#int-storevalue-half-value) | Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document. |

## StoreValue `abstract`

```csharp
int StoreValue(Guid value)
```

Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref DateTime value)
```

Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref DateTimeOffset value)
```

Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDateTime value)
```

Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref OffsetDate value)
```

Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref OffsetTime value)
```

Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref LocalDate value)
```

Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref Period value)
```

Stores a [`Period`](/api/corvus-text-json-period.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(sbyte value)
```

Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(byte value)
```

Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(int value)
```

Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(uint value)
```

Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(long value)
```

Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ulong value)
```

Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(short value)
```

Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ushort value)
```

Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(float value)
```

Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(double value)
```

Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(decimal value)
```

Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref BigInteger value)
```

Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(ref BigNumber value)
```

Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(Int128 value)
```

Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(UInt128 value)
```

Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## StoreValue `abstract`

```csharp
int StoreValue(Half value)
```

Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

