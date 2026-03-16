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
| [TryGetValue(int, ref byte\[\])](#trygetvalue-int-ref-byte) | Tries to get the value of the element at the specified index as a byte array. |
| [TryGetValue(int, ref sbyte)](#trygetvalue-int-ref-sbyte) | Tries to get the value of the element at the specified index as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetValue(int, ref byte)](#trygetvalue-int-ref-byte) | Tries to get the value of the element at the specified index as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetValue(int, ref short)](#trygetvalue-int-ref-short) | Tries to get the value of the element at the specified index as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetValue(int, ref ushort)](#trygetvalue-int-ref-ushort) | Tries to get the value of the element at the specified index as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetValue(int, ref int)](#trygetvalue-int-ref-int) | Tries to get the value of the element at the specified index as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetValue(int, ref uint)](#trygetvalue-int-ref-uint) | Tries to get the value of the element at the specified index as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetValue(int, ref long)](#trygetvalue-int-ref-long) | Tries to get the value of the element at the specified index as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetValue(int, ref ulong)](#trygetvalue-int-ref-ulong) | Tries to get the value of the element at the specified index as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryGetValue(int, ref double)](#trygetvalue-int-ref-double) | Tries to get the value of the element at the specified index as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetValue(int, ref float)](#trygetvalue-int-ref-float) | Tries to get the value of the element at the specified index as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetValue(int, ref decimal)](#trygetvalue-int-ref-decimal) | Tries to get the value of the element at the specified index as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetValue(int, ref BigInteger)](#trygetvalue-int-ref-biginteger) | Tries to get the value of the element at the specified index as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetValue(int, ref BigNumber)](#trygetvalue-int-ref-bignumber) | Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetValue(int, ref DateTime)](#trygetvalue-int-ref-datetime) | Tries to get the value of the element at the specified index as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetValue(int, ref DateTimeOffset)](#trygetvalue-int-ref-datetimeoffset) | Tries to get the value of the element at the specified index as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetValue(int, ref OffsetDateTime)](#trygetvalue-int-ref-offsetdatetime) | Tries to get the value of the element at the specified index as an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetValue(int, ref OffsetDate)](#trygetvalue-int-ref-offsetdate) | Tries to get the value of the element at the specified index as an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetValue(int, ref OffsetTime)](#trygetvalue-int-ref-offsettime) | Tries to get the value of the element at the specified index as an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetValue(int, ref LocalDate)](#trygetvalue-int-ref-localdate) | Tries to get the value of the element at the specified index as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetValue(int, ref Period)](#trygetvalue-int-ref-period) | Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetValue(int, ref Guid)](#trygetvalue-int-ref-guid) | Tries to get the value of the element at the specified index as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetValue(int, ref Int128)](#trygetvalue-int-ref-int128) | Tries to get the value of the element at the specified index as an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128). |
| [TryGetValue(int, ref UInt128)](#trygetvalue-int-ref-uint128) | Tries to get the value of the element at the specified index as a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128). |
| [TryGetValue(int, ref Half)](#trygetvalue-int-ref-half) | Tries to get the value of the element at the specified index as a [`Half`](https://learn.microsoft.com/dotnet/api/system.half). |
| [TryGetValue(int, ref DateOnly)](#trygetvalue-int-ref-dateonly) | Tries to get the value of the element at the specified index as a [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly). |
| [TryGetValue(int, ref TimeOnly)](#trygetvalue-int-ref-timeonly) | Tries to get the value of the element at the specified index as a [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly). |

## TryGetValue(int, ref byte[]) {#trygetvalue-int-ref-byte}

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

## TryGetValue(int, ref sbyte) {#trygetvalue-int-ref-sbyte}

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

## TryGetValue(int, ref byte) {#trygetvalue-int-ref-byte}

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

## TryGetValue(int, ref short) {#trygetvalue-int-ref-short}

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

## TryGetValue(int, ref ushort) {#trygetvalue-int-ref-ushort}

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

## TryGetValue(int, ref int) {#trygetvalue-int-ref-int}

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

## TryGetValue(int, ref uint) {#trygetvalue-int-ref-uint}

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

## TryGetValue(int, ref long) {#trygetvalue-int-ref-long}

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

## TryGetValue(int, ref ulong) {#trygetvalue-int-ref-ulong}

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

## TryGetValue(int, ref double) {#trygetvalue-int-ref-double}

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

## TryGetValue(int, ref float) {#trygetvalue-int-ref-float}

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

## TryGetValue(int, ref decimal) {#trygetvalue-int-ref-decimal}

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

## TryGetValue(int, ref BigInteger) {#trygetvalue-int-ref-biginteger}

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

## TryGetValue(int, ref BigNumber) {#trygetvalue-int-ref-bignumber}

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

## TryGetValue(int, ref DateTime) {#trygetvalue-int-ref-datetime}

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

## TryGetValue(int, ref DateTimeOffset) {#trygetvalue-int-ref-datetimeoffset}

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

## TryGetValue(int, ref OffsetDateTime) {#trygetvalue-int-ref-offsetdatetime}

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

## TryGetValue(int, ref OffsetDate) {#trygetvalue-int-ref-offsetdate}

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

## TryGetValue(int, ref OffsetTime) {#trygetvalue-int-ref-offsettime}

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

## TryGetValue(int, ref LocalDate) {#trygetvalue-int-ref-localdate}

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

## TryGetValue(int, ref Period) {#trygetvalue-int-ref-period}

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

## TryGetValue(int, ref Guid) {#trygetvalue-int-ref-guid}

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

## TryGetValue(int, ref Int128) {#trygetvalue-int-ref-int128}

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

## TryGetValue(int, ref UInt128) {#trygetvalue-int-ref-uint128}

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

## TryGetValue(int, ref Half) {#trygetvalue-int-ref-half}

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

## TryGetValue(int, ref DateOnly) {#trygetvalue-int-ref-dateonly}

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

## TryGetValue(int, ref TimeOnly) {#trygetvalue-int-ref-timeonly}

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

