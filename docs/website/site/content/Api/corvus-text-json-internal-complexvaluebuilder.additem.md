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
| [AddItem(ReadOnlySpan&lt;byte&gt;)](#additem-readonlyspan-byte) | Adds an item to the current array as a UTF-8 string. |
| [AddItem(string)](#additem-string) | Adds an item to the current array as a string. |
| [AddItem(ReadOnlySpan&lt;byte&gt;, bool, bool)](#additem-readonlyspan-byte-bool-bool) | Adds an item to the current array as a UTF-8 string with control over escaping. |
| [AddItem(ReadOnlySpan&lt;char&gt;)](#additem-readonlyspan-char) | Adds an item to the current array as a character span. |
| [AddItem(ComplexValueBuilder.ValueBuilderAction)](#additem-complexvaluebuilder-valuebuilderaction) |  |
| [AddItem(ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#additem-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext) |  |
| [AddItem(bool)](#additem-bool) | Adds a boolean item to the current array. |
| [AddItem(ref T)](#additem-ref-t) | Adds a JSON element item to the current array. |
| [AddItem(Guid)](#additem-guid) | Adds a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) item to the current array. |
| [AddItem(ref DateTime)](#additem-ref-datetime) | Adds a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) item to the current array. |
| [AddItem(ref DateTimeOffset)](#additem-ref-datetimeoffset) | Adds a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) item to the current array. |
| [AddItem(ref OffsetDateTime)](#additem-ref-offsetdatetime) | Adds an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) item to the current array. |
| [AddItem(ref OffsetDate)](#additem-ref-offsetdate) | Adds an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) item to the current array. |
| [AddItem(ref OffsetTime)](#additem-ref-offsettime) | Adds an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) item to the current array. |
| [AddItem(ref LocalDate)](#additem-ref-localdate) | Adds a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) item to the current array. |
| [AddItem(ref Period)](#additem-ref-period) | Adds a [`Period`](/api/corvus-text-json-period.html) item to the current array. |
| [AddItem(sbyte)](#additem-sbyte) | Adds an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) item to the current array. |
| [AddItem(byte)](#additem-byte) | Adds a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) item to the current array. |
| [AddItem(int)](#additem-int) | Adds an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) item to the current array. |
| [AddItem(uint)](#additem-uint) | Adds a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) item to the current array. |
| [AddItem(long)](#additem-long) | Adds a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) item to the current array. |
| [AddItem(ulong)](#additem-ulong) | Adds a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) item to the current array. |
| [AddItem(short)](#additem-short) | Adds a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) item to the current array. |
| [AddItem(ushort)](#additem-ushort) | Adds a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) item to the current array. |
| [AddItem(float)](#additem-float) | Adds a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) item to the current array. |
| [AddItem(double)](#additem-double) | Adds a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) item to the current array. |
| [AddItem(decimal)](#additem-decimal) | Adds a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) item to the current array. |
| [AddItem(ref BigNumber)](#additem-ref-bignumber) | Adds a [`BigNumber`](/api/corvus-numerics-bignumber.html) item to the current array. |
| [AddItem(ref BigInteger)](#additem-ref-biginteger) | Adds a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) item to the current array. |
| [AddItem(Int128)](#additem-int128) | Adds an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) item to the current array. |
| [AddItem(UInt128)](#additem-uint128) | Adds a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) item to the current array. |
| [AddItem(Half)](#additem-half) | Adds a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) item to the current array. |

## AddItem(ReadOnlySpan&lt;byte&gt;) {#additem-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2337)

Adds an item to the current array as a UTF-8 string.

```csharp
public void AddItem(ReadOnlySpan<byte> utf8String)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(string) {#additem-string}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2347)

Adds an item to the current array as a string.

```csharp
public void AddItem(string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The item value as a string. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ReadOnlySpan&lt;byte&gt;, bool, bool) {#additem-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2358)

Adds an item to the current array as a UTF-8 string with control over escaping.

```csharp
public void AddItem(ReadOnlySpan<byte> utf8String, bool escapeValue, bool requiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the value. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ReadOnlySpan&lt;char&gt;) {#additem-readonlyspan-char}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2369)

Adds an item to the current array as a character span.

```csharp
public void AddItem(ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The item value as a character span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ComplexValueBuilder.ValueBuilderAction) {#additem-complexvaluebuilder-valuebuilderaction}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2392)

```csharp
public void AddItem(ComplexValueBuilder.ValueBuilderAction createValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `createValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;) {#additem-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

```csharp
public void AddItem<TContext>(ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `context` | `ref TContext` |  |
| `createValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(bool) {#additem-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2437)

Adds a boolean item to the current array.

```csharp
public void AddItem(bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref T) {#additem-ref-t}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

Adds a JSON element item to the current array.

```csharp
public void AddItem<T>(ref T value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref T` | The JSON element value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(Guid) {#additem-guid}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2476)

Adds a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) item to the current array.

```csharp
public void AddItem(Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref DateTime) {#additem-ref-datetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2487)

Adds a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) item to the current array.

```csharp
public void AddItem(ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref DateTimeOffset) {#additem-ref-datetimeoffset}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2498)

Adds a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) item to the current array.

```csharp
public void AddItem(ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref OffsetDateTime) {#additem-ref-offsetdatetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2509)

Adds an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) item to the current array.

```csharp
public void AddItem(ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref OffsetDate) {#additem-ref-offsetdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2520)

Adds an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) item to the current array.

```csharp
public void AddItem(ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref OffsetTime) {#additem-ref-offsettime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2531)

Adds an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) item to the current array.

```csharp
public void AddItem(ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref LocalDate) {#additem-ref-localdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2542)

Adds a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) item to the current array.

```csharp
public void AddItem(ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref Period) {#additem-ref-period}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2553)

Adds a [`Period`](/api/corvus-text-json-period.html) item to the current array.

```csharp
public void AddItem(ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](/api/corvus-text-json-period.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(sbyte) {#additem-sbyte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2565)

Adds an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) item to the current array.

```csharp
public void AddItem(sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(byte) {#additem-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2576)

Adds a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) item to the current array.

```csharp
public void AddItem(byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(int) {#additem-int}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2587)

Adds an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) item to the current array.

```csharp
public void AddItem(int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(uint) {#additem-uint}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2599)

Adds a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) item to the current array.

```csharp
public void AddItem(uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(long) {#additem-long}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2610)

Adds a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) item to the current array.

```csharp
public void AddItem(long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ulong) {#additem-ulong}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2622)

Adds a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) item to the current array.

```csharp
public void AddItem(ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(short) {#additem-short}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2633)

Adds a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) item to the current array.

```csharp
public void AddItem(short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ushort) {#additem-ushort}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2645)

Adds a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) item to the current array.

```csharp
public void AddItem(ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(float) {#additem-float}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2656)

Adds a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) item to the current array.

```csharp
public void AddItem(float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(double) {#additem-double}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2667)

Adds a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) item to the current array.

```csharp
public void AddItem(double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(decimal) {#additem-decimal}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2678)

Adds a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) item to the current array.

```csharp
public void AddItem(decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref BigNumber) {#additem-ref-bignumber}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2690)

Adds a [`BigNumber`](/api/corvus-numerics-bignumber.html) item to the current array.

```csharp
public void AddItem(ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(ref BigInteger) {#additem-ref-biginteger}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2701)

Adds a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) item to the current array.

```csharp
public void AddItem(ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddItem(Int128) {#additem-int128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2714)

Adds an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) item to the current array.

```csharp
public void AddItem(Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddItem(UInt128) {#additem-uint128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2726)

Adds a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) item to the current array.

```csharp
public void AddItem(UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddItem(Half) {#additem-half}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2737)

Adds a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) item to the current array.

```csharp
public void AddItem(Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

