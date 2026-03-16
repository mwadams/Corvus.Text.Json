---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddProperty Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction)](#addproperty-readonlyspan-byte-complexvaluebuilder-valuebuilderaction) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction, bool, bool)](#addproperty-readonlyspan-byte-complexvaluebuilder-valuebuilderaction-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;, bool, bool)](#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext-bool-bool) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ComplexValueBuilder.ValueBuilderAction)](#addproperty-readonlyspan-char-complexvaluebuilder-valuebuilderaction) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#addproperty-readonlyspan-char-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#addproperty-readonlyspan-byte-readonlyspan-byte) | Adds a property with a string value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool, bool)](#addproperty-readonlyspan-byte-readonlyspan-byte-bool-bool-bool-bool) | Adds a property with a string value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool)](#addproperty-readonlyspan-byte-readonlyspan-char-bool-bool) | Adds a property with a string value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#addproperty-readonlyspan-char-readonlyspan-char) | Adds a property with a string value to the current object. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addproperty-readonlyspan-char-readonlyspan-byte-bool-bool) | Adds a property with a string value to the current object, with control over escaping the value. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool)](#addproperty-readonlyspan-byte-bool) | Adds a property with a boolean value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#addproperty-readonlyspan-byte-bool-bool-bool) | Adds a property with a boolean value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, bool)](#addproperty-readonlyspan-char-bool) | Adds a property with a boolean value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref T)](#addproperty-readonlyspan-byte-ref-t) | Adds a property with a JSON element value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool)](#addproperty-readonlyspan-byte-t-bool-bool) | Adds a property with a JSON element value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, T)](#addproperty-readonlyspan-char-t) | Adds a property with a JSON element value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid)](#addproperty-readonlyspan-byte-guid) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool)](#addproperty-readonlyspan-byte-guid-bool-bool) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Guid)](#addproperty-readonlyspan-char-guid) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime)](#addproperty-readonlyspan-byte-ref-datetime) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool)](#addproperty-readonlyspan-byte-ref-datetime-bool-bool) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime)](#addproperty-readonlyspan-char-ref-datetime) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset)](#addproperty-readonlyspan-byte-ref-datetimeoffset) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool)](#addproperty-readonlyspan-byte-ref-datetimeoffset-bool-bool) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset)](#addproperty-readonlyspan-char-ref-datetimeoffset) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime)](#addproperty-readonlyspan-byte-ref-offsetdatetime) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool)](#addproperty-readonlyspan-byte-ref-offsetdatetime-bool-bool) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime)](#addproperty-readonlyspan-char-ref-offsetdatetime) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime)](#addproperty-readonlyspan-byte-ref-offsettime) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool)](#addproperty-readonlyspan-byte-ref-offsettime-bool-bool) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime)](#addproperty-readonlyspan-char-ref-offsettime) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate)](#addproperty-readonlyspan-byte-ref-offsetdate) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool)](#addproperty-readonlyspan-byte-ref-offsetdate-bool-bool) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate)](#addproperty-readonlyspan-char-ref-offsetdate) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate)](#addproperty-readonlyspan-byte-ref-localdate) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool)](#addproperty-readonlyspan-byte-ref-localdate-bool-bool) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate)](#addproperty-readonlyspan-char-ref-localdate) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period)](#addproperty-readonlyspan-byte-ref-period) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool)](#addproperty-readonlyspan-byte-ref-period-bool-bool) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref Period)](#addproperty-readonlyspan-char-ref-period) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte)](#addproperty-readonlyspan-byte-sbyte) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool)](#addproperty-readonlyspan-byte-sbyte-bool-bool) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, sbyte)](#addproperty-readonlyspan-char-sbyte) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte)](#addproperty-readonlyspan-byte-byte) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool)](#addproperty-readonlyspan-byte-byte-bool-bool) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, byte)](#addproperty-readonlyspan-char-byte) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int)](#addproperty-readonlyspan-byte-int) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool)](#addproperty-readonlyspan-byte-int-bool-bool) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, int)](#addproperty-readonlyspan-char-int) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint)](#addproperty-readonlyspan-byte-uint) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool)](#addproperty-readonlyspan-byte-uint-bool-bool) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, uint)](#addproperty-readonlyspan-char-uint) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long)](#addproperty-readonlyspan-byte-long) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool)](#addproperty-readonlyspan-byte-long-bool-bool) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, long)](#addproperty-readonlyspan-char-long) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong)](#addproperty-readonlyspan-byte-ulong) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool)](#addproperty-readonlyspan-byte-ulong-bool-bool) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ulong)](#addproperty-readonlyspan-char-ulong) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short)](#addproperty-readonlyspan-byte-short) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool)](#addproperty-readonlyspan-byte-short-bool-bool) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, short)](#addproperty-readonlyspan-char-short) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort)](#addproperty-readonlyspan-byte-ushort) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool)](#addproperty-readonlyspan-byte-ushort-bool-bool) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ushort)](#addproperty-readonlyspan-char-ushort) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float)](#addproperty-readonlyspan-byte-float) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool)](#addproperty-readonlyspan-byte-float-bool-bool) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, float)](#addproperty-readonlyspan-char-float) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double)](#addproperty-readonlyspan-byte-double) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool)](#addproperty-readonlyspan-byte-double-bool-bool) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, double)](#addproperty-readonlyspan-char-double) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal)](#addproperty-readonlyspan-byte-decimal) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool)](#addproperty-readonlyspan-byte-decimal-bool-bool) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, decimal)](#addproperty-readonlyspan-char-decimal) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger)](#addproperty-readonlyspan-byte-ref-biginteger) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool)](#addproperty-readonlyspan-byte-ref-biginteger-bool-bool) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger)](#addproperty-readonlyspan-char-ref-biginteger) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](#addproperty-readonlyspan-byte-ref-bignumber) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool)](#addproperty-readonlyspan-byte-ref-bignumber-bool-bool) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#addproperty-readonlyspan-char-ref-bignumber) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128)](#addproperty-readonlyspan-byte-int128) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool)](#addproperty-readonlyspan-byte-int128-bool-bool) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Int128)](#addproperty-readonlyspan-char-int128) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128)](#addproperty-readonlyspan-byte-uint128) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool)](#addproperty-readonlyspan-byte-uint128-bool-bool) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, UInt128)](#addproperty-readonlyspan-char-uint128) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half)](#addproperty-readonlyspan-byte-half) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool)](#addproperty-readonlyspan-byte-half-bool-bool) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Half)](#addproperty-readonlyspan-char-half) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object. |

## AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction) {#addproperty-readonlyspan-byte-complexvaluebuilder-valuebuilderaction}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;) {#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction, bool, bool) {#addproperty-readonlyspan-byte-complexvaluebuilder-valuebuilderaction-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;, bool, bool) {#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext-bool-bool}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ComplexValueBuilder.ValueBuilderAction) {#addproperty-readonlyspan-char-complexvaluebuilder-valuebuilderaction}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;) {#addproperty-readonlyspan-char-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext}

```csharp
public void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#addproperty-readonlyspan-byte-readonlyspan-byte}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
```

Adds a property with a string value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-byte-bool-bool-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-char-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;) {#addproperty-readonlyspan-char-readonlyspan-char}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Adds a property with a string value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addproperty-readonlyspan-char-readonlyspan-byte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool escapeValue, bool valueRequiresUnescaping)
```

Adds a property with a string value to the current object, with control over escaping the value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, bool) {#addproperty-readonlyspan-byte-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool) {#addproperty-readonlyspan-byte-bool-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a boolean value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, bool) {#addproperty-readonlyspan-char-bool}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref T) {#addproperty-readonlyspan-byte-ref-t}

```csharp
public void AddProperty<T>(ReadOnlySpan<byte> propertyName, ref T value)
```

Adds a property with a JSON element value to the current object.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref T` | The JSON element value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool) {#addproperty-readonlyspan-byte-t-bool-bool}

```csharp
public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a JSON element value to the current object, with control over escaping.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `T` | The JSON element value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, T) {#addproperty-readonlyspan-char-t}

```csharp
public void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

Adds a property with a JSON element value to the current object.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `T` | The JSON element value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Guid) {#addproperty-readonlyspan-byte-guid}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
```

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool) {#addproperty-readonlyspan-byte-guid-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Guid) {#addproperty-readonlyspan-char-guid}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime) {#addproperty-readonlyspan-byte-ref-datetime}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-datetime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime) {#addproperty-readonlyspan-char-ref-datetime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset) {#addproperty-readonlyspan-byte-ref-datetimeoffset}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool) {#addproperty-readonlyspan-byte-ref-datetimeoffset-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset) {#addproperty-readonlyspan-char-ref-datetimeoffset}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime) {#addproperty-readonlyspan-byte-ref-offsetdatetime}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdatetime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime) {#addproperty-readonlyspan-char-ref-offsetdatetime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime) {#addproperty-readonlyspan-byte-ref-offsettime}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsettime-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime) {#addproperty-readonlyspan-char-ref-offsettime}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate) {#addproperty-readonlyspan-byte-ref-offsetdate}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdate-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate) {#addproperty-readonlyspan-char-ref-offsetdate}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate) {#addproperty-readonlyspan-byte-ref-localdate}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool) {#addproperty-readonlyspan-byte-ref-localdate-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate) {#addproperty-readonlyspan-char-ref-localdate}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period) {#addproperty-readonlyspan-byte-ref-period}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value)
```

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool) {#addproperty-readonlyspan-byte-ref-period-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref Period) {#addproperty-readonlyspan-char-ref-period}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte) {#addproperty-readonlyspan-byte-sbyte}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
```

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool) {#addproperty-readonlyspan-byte-sbyte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, sbyte) {#addproperty-readonlyspan-char-sbyte}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, byte) {#addproperty-readonlyspan-byte-byte}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
```

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool) {#addproperty-readonlyspan-byte-byte-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, byte) {#addproperty-readonlyspan-char-byte}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, int) {#addproperty-readonlyspan-byte-int}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, int value)
```

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool) {#addproperty-readonlyspan-byte-int-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, int) {#addproperty-readonlyspan-char-int}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, uint) {#addproperty-readonlyspan-byte-uint}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
```

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool) {#addproperty-readonlyspan-byte-uint-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, uint) {#addproperty-readonlyspan-char-uint}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, long) {#addproperty-readonlyspan-byte-long}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, long value)
```

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool) {#addproperty-readonlyspan-byte-long-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, long) {#addproperty-readonlyspan-char-long}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ulong) {#addproperty-readonlyspan-byte-ulong}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
```

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool) {#addproperty-readonlyspan-byte-ulong-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ulong) {#addproperty-readonlyspan-char-ulong}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, short) {#addproperty-readonlyspan-byte-short}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, short value)
```

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool) {#addproperty-readonlyspan-byte-short-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, short) {#addproperty-readonlyspan-char-short}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ushort) {#addproperty-readonlyspan-byte-ushort}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
```

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool) {#addproperty-readonlyspan-byte-ushort-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ushort) {#addproperty-readonlyspan-char-ushort}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, float) {#addproperty-readonlyspan-byte-float}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, float value)
```

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool) {#addproperty-readonlyspan-byte-float-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, float) {#addproperty-readonlyspan-char-float}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, double) {#addproperty-readonlyspan-byte-double}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, double value)
```

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool) {#addproperty-readonlyspan-byte-double-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, double) {#addproperty-readonlyspan-char-double}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, decimal) {#addproperty-readonlyspan-byte-decimal}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
```

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool) {#addproperty-readonlyspan-byte-decimal-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, decimal) {#addproperty-readonlyspan-char-decimal}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger) {#addproperty-readonlyspan-byte-ref-biginteger}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool) {#addproperty-readonlyspan-byte-ref-biginteger-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger) {#addproperty-readonlyspan-char-ref-biginteger}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber) {#addproperty-readonlyspan-byte-ref-bignumber}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool) {#addproperty-readonlyspan-byte-ref-bignumber-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber) {#addproperty-readonlyspan-char-ref-bignumber}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Int128) {#addproperty-readonlyspan-byte-int128}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
```

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool) {#addproperty-readonlyspan-byte-int128-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Int128) {#addproperty-readonlyspan-char-int128}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128) {#addproperty-readonlyspan-byte-uint128}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool) {#addproperty-readonlyspan-byte-uint128-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, UInt128) {#addproperty-readonlyspan-char-uint128}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Half) {#addproperty-readonlyspan-byte-half}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
```

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool) {#addproperty-readonlyspan-byte-half-bool-bool}

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Half) {#addproperty-readonlyspan-char-half}

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

