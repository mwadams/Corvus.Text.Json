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
| [StoreValue(Guid)](#storevalue-guid) | Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document. |
| [StoreValue(ref DateTime)](#storevalue-ref-datetime) | Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document. |
| [StoreValue(ref DateTimeOffset)](#storevalue-ref-datetimeoffset) | Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document. |
| [StoreValue(ref OffsetDateTime)](#storevalue-ref-offsetdatetime) | Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document. |
| [StoreValue(ref OffsetDate)](#storevalue-ref-offsetdate) | Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document. |
| [StoreValue(ref OffsetTime)](#storevalue-ref-offsettime) | Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document. |
| [StoreValue(ref LocalDate)](#storevalue-ref-localdate) | Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document. |
| [StoreValue(ref Period)](#storevalue-ref-period) | Stores a [`Period`](/api/corvus-text-json-period.html) value in the document. |
| [StoreValue(sbyte)](#storevalue-sbyte) | Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document. |
| [StoreValue(byte)](#storevalue-byte) | Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document. |
| [StoreValue(int)](#storevalue-int) | Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document. |
| [StoreValue(uint)](#storevalue-uint) | Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document. |
| [StoreValue(long)](#storevalue-long) | Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document. |
| [StoreValue(ulong)](#storevalue-ulong) | Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document. |
| [StoreValue(short)](#storevalue-short) | Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document. |
| [StoreValue(ushort)](#storevalue-ushort) | Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document. |
| [StoreValue(float)](#storevalue-float) | Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document. |
| [StoreValue(double)](#storevalue-double) | Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document. |
| [StoreValue(decimal)](#storevalue-decimal) | Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document. |
| [StoreValue(ref BigInteger)](#storevalue-ref-biginteger) | Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document. |
| [StoreValue(ref BigNumber)](#storevalue-ref-bignumber) | Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document. |
| [StoreValue(Int128)](#storevalue-int128) | Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document. |
| [StoreValue(UInt128)](#storevalue-uint128) | Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document. |
| [StoreValue(Half)](#storevalue-half) | Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document. |

## StoreValue(Guid) {#storevalue-guid}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document.

```csharp
public abstract int StoreValue(Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref DateTime) {#storevalue-ref-datetime}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document.

```csharp
public abstract int StoreValue(ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref DateTimeOffset) {#storevalue-ref-datetimeoffset}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document.

```csharp
public abstract int StoreValue(ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref OffsetDateTime) {#storevalue-ref-offsetdatetime}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document.

```csharp
public abstract int StoreValue(ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref OffsetDate) {#storevalue-ref-offsetdate}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document.

```csharp
public abstract int StoreValue(ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref OffsetTime) {#storevalue-ref-offsettime}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document.

```csharp
public abstract int StoreValue(ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref LocalDate) {#storevalue-ref-localdate}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document.

```csharp
public abstract int StoreValue(ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref Period) {#storevalue-ref-period}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Period`](/api/corvus-text-json-period.html) value in the document.

```csharp
public abstract int StoreValue(ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(sbyte) {#storevalue-sbyte}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document.

```csharp
public abstract int StoreValue(sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(byte) {#storevalue-byte}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document.

```csharp
public abstract int StoreValue(byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(int) {#storevalue-int}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document.

```csharp
public abstract int StoreValue(int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(uint) {#storevalue-uint}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document.

```csharp
public abstract int StoreValue(uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(long) {#storevalue-long}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document.

```csharp
public abstract int StoreValue(long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ulong) {#storevalue-ulong}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document.

```csharp
public abstract int StoreValue(ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(short) {#storevalue-short}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document.

```csharp
public abstract int StoreValue(short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ushort) {#storevalue-ushort}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document.

```csharp
public abstract int StoreValue(ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(float) {#storevalue-float}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document.

```csharp
public abstract int StoreValue(float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(double) {#storevalue-double}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document.

```csharp
public abstract int StoreValue(double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(decimal) {#storevalue-decimal}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document.

```csharp
public abstract int StoreValue(decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref BigInteger) {#storevalue-ref-biginteger}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document.

```csharp
public abstract int StoreValue(ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(ref BigNumber) {#storevalue-ref-bignumber}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document.

```csharp
public abstract int StoreValue(ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StoreValue(Int128) {#storevalue-int128}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document.

```csharp
public abstract int StoreValue(Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## StoreValue(UInt128) {#storevalue-uint128}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document.

```csharp
public abstract int StoreValue(UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## StoreValue(Half) {#storevalue-half}

**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L148)

Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document.

```csharp
public abstract int StoreValue(Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to store. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

