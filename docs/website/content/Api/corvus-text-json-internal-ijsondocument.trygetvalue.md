---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetValue(int, ref byte\[\])](#bool-trygetvalue-int-index-ref-byte-value) | Tries to get the value of the element at the specified index as a byte array. |
| [TryGetValue(int, ref sbyte)](#bool-trygetvalue-int-index-ref-sbyte-value) | Tries to get the value of the element at the specified index as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetValue(int, ref byte)](#bool-trygetvalue-int-index-ref-byte-value) | Tries to get the value of the element at the specified index as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetValue(int, ref short)](#bool-trygetvalue-int-index-ref-short-value) | Tries to get the value of the element at the specified index as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetValue(int, ref ushort)](#bool-trygetvalue-int-index-ref-ushort-value) | Tries to get the value of the element at the specified index as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetValue(int, ref int)](#bool-trygetvalue-int-index-ref-int-value) | Tries to get the value of the element at the specified index as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetValue(int, ref uint)](#bool-trygetvalue-int-index-ref-uint-value) | Tries to get the value of the element at the specified index as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetValue(int, ref long)](#bool-trygetvalue-int-index-ref-long-value) | Tries to get the value of the element at the specified index as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetValue(int, ref ulong)](#bool-trygetvalue-int-index-ref-ulong-value) | Tries to get the value of the element at the specified index as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryGetValue(int, ref double)](#bool-trygetvalue-int-index-ref-double-value) | Tries to get the value of the element at the specified index as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetValue(int, ref float)](#bool-trygetvalue-int-index-ref-float-value) | Tries to get the value of the element at the specified index as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetValue(int, ref decimal)](#bool-trygetvalue-int-index-ref-decimal-value) | Tries to get the value of the element at the specified index as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetValue(int, ref BigInteger)](#bool-trygetvalue-int-index-ref-biginteger-value) | Tries to get the value of the element at the specified index as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetValue(int, ref BigNumber)](#bool-trygetvalue-int-index-ref-bignumber-value) | Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetValue(int, ref DateTime)](#bool-trygetvalue-int-index-ref-datetime-value) | Tries to get the value of the element at the specified index as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetValue(int, ref DateTimeOffset)](#bool-trygetvalue-int-index-ref-datetimeoffset-value) | Tries to get the value of the element at the specified index as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetValue(int, ref OffsetDateTime)](#bool-trygetvalue-int-index-ref-offsetdatetime-value) | Tries to get the value of the element at the specified index as an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetValue(int, ref OffsetDate)](#bool-trygetvalue-int-index-ref-offsetdate-value) | Tries to get the value of the element at the specified index as an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetValue(int, ref OffsetTime)](#bool-trygetvalue-int-index-ref-offsettime-value) | Tries to get the value of the element at the specified index as an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetValue(int, ref LocalDate)](#bool-trygetvalue-int-index-ref-localdate-value) | Tries to get the value of the element at the specified index as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetValue(int, ref Period)](#bool-trygetvalue-int-index-ref-period-value) | Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetValue(int, ref Guid)](#bool-trygetvalue-int-index-ref-guid-value) | Tries to get the value of the element at the specified index as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetValue(int, ref Int128)](#bool-trygetvalue-int-index-ref-int128-value) | Tries to get the value of the element at the specified index as an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128). |
| [TryGetValue(int, ref UInt128)](#bool-trygetvalue-int-index-ref-uint128-value) | Tries to get the value of the element at the specified index as a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128). |
| [TryGetValue(int, ref Half)](#bool-trygetvalue-int-index-ref-half-value) | Tries to get the value of the element at the specified index as a [`Half`](https://learn.microsoft.com/dotnet/api/system.half). |
| [TryGetValue(int, ref DateOnly)](#bool-trygetvalue-int-index-ref-dateonly-value) | Tries to get the value of the element at the specified index as a [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly). |
| [TryGetValue(int, ref TimeOnly)](#bool-trygetvalue-int-index-ref-timeonly-value) | Tries to get the value of the element at the specified index as a [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly). |

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte[] value)
```

Tries to get the value of the element at the specified index as a byte array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The byte array value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref sbyte value)
```

Tries to get the value of the element at the specified index as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref byte value)
```

Tries to get the value of the element at the specified index as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref short value)
```

Tries to get the value of the element at the specified index as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ushort value)
```

Tries to get the value of the element at the specified index as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref int value)
```

Tries to get the value of the element at the specified index as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref uint value)
```

Tries to get the value of the element at the specified index as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref long value)
```

Tries to get the value of the element at the specified index as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref ulong value)
```

Tries to get the value of the element at the specified index as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref double value)
```

Tries to get the value of the element at the specified index as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref float value)
```

Tries to get the value of the element at the specified index as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref decimal value)
```

Tries to get the value of the element at the specified index as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigInteger value)
```

Tries to get the value of the element at the specified index as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref BigNumber value)
```

Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTime value)
```

Tries to get the value of the element at the specified index as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateTimeOffset value)
```

Tries to get the value of the element at the specified index as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDateTime value)
```

Tries to get the value of the element at the specified index as an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetDate value)
```

Tries to get the value of the element at the specified index as an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref OffsetTime value)
```

Tries to get the value of the element at the specified index as an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref LocalDate value)
```

Tries to get the value of the element at the specified index as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Period value)
```

Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Guid value)
```

Tries to get the value of the element at the specified index as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Int128 value)
```

Tries to get the value of the element at the specified index as an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref UInt128 value)
```

Tries to get the value of the element at the specified index as a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref Half value)
```

Tries to get the value of the element at the specified index as a [`Half`](https://learn.microsoft.com/dotnet/api/system.half).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref DateOnly value)
```

Tries to get the value of the element at the specified index as a [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly) | The [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

## TryGetValue `abstract`

```csharp
bool TryGetValue(int index, ref TimeOnly value)
```

Tries to get the value of the element at the specified index as a [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly) | The [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

---

