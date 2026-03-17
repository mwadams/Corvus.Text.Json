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

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L108)

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;) {#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

```csharp
public void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction, bool, bool) {#addproperty-readonlyspan-byte-complexvaluebuilder-valuebuilderaction-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L136)

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;, bool, bool) {#addproperty-readonlyspan-byte-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ComplexValueBuilder.ValueBuilderAction) {#addproperty-readonlyspan-char-complexvaluebuilder-valuebuilderaction}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L177)

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;) {#addproperty-readonlyspan-char-ref-tcontext-complexvaluebuilder-valuebuilderaction-tcontext}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

```csharp
public void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#addproperty-readonlyspan-byte-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L217)

Adds a property with a string value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-byte-bool-bool-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L231)

Adds a property with a string value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool) {#addproperty-readonlyspan-byte-readonlyspan-char-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L246)

Adds a property with a string value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;) {#addproperty-readonlyspan-char-readonlyspan-char}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L259)

Adds a property with a string value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addproperty-readonlyspan-char-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L274)

Adds a property with a string value to the current object, with control over escaping the value.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool escapeValue, bool valueRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |
| `escapeValue` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property value. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property value requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, bool) {#addproperty-readonlyspan-byte-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L409)

Adds a property with a boolean value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool) {#addproperty-readonlyspan-byte-bool-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L421)

Adds a property with a boolean value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, bool) {#addproperty-readonlyspan-char-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L434)

Adds a property with a boolean value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref T) {#addproperty-readonlyspan-byte-ref-t}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

Adds a property with a JSON element value to the current object.

```csharp
public void AddProperty<T>(ReadOnlySpan<byte> propertyName, ref T value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | `ref T` | The JSON element value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool) {#addproperty-readonlyspan-byte-t-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

Adds a property with a JSON element value to the current object, with control over escaping.

```csharp
public void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, T) {#addproperty-readonlyspan-char-t}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

Adds a property with a JSON element value to the current object.

```csharp
public void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | `T` | The JSON element value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Guid) {#addproperty-readonlyspan-byte-guid}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L502)

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool) {#addproperty-readonlyspan-byte-guid-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L514)

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Guid) {#addproperty-readonlyspan-char-guid}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L527)

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime) {#addproperty-readonlyspan-byte-ref-datetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L541)

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-datetime-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L553)

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime) {#addproperty-readonlyspan-char-ref-datetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L566)

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset) {#addproperty-readonlyspan-byte-ref-datetimeoffset}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L580)

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool) {#addproperty-readonlyspan-byte-ref-datetimeoffset-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L592)

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset) {#addproperty-readonlyspan-char-ref-datetimeoffset}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L605)

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime) {#addproperty-readonlyspan-byte-ref-offsetdatetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L619)

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdatetime-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L631)

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime) {#addproperty-readonlyspan-char-ref-offsetdatetime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L644)

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime) {#addproperty-readonlyspan-byte-ref-offsettime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L658)

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool) {#addproperty-readonlyspan-byte-ref-offsettime-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L670)

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime) {#addproperty-readonlyspan-char-ref-offsettime}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L683)

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate) {#addproperty-readonlyspan-byte-ref-offsetdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L697)

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool) {#addproperty-readonlyspan-byte-ref-offsetdate-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L709)

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate) {#addproperty-readonlyspan-char-ref-offsetdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L722)

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate) {#addproperty-readonlyspan-byte-ref-localdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L736)

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool) {#addproperty-readonlyspan-byte-ref-localdate-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L748)

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate) {#addproperty-readonlyspan-char-ref-localdate}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L761)

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period) {#addproperty-readonlyspan-byte-ref-period}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L775)

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool) {#addproperty-readonlyspan-byte-ref-period-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L787)

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref Period) {#addproperty-readonlyspan-char-ref-period}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L800)

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte) {#addproperty-readonlyspan-byte-sbyte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L815)

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool) {#addproperty-readonlyspan-byte-sbyte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L828)

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, sbyte) {#addproperty-readonlyspan-char-sbyte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L842)

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, byte) {#addproperty-readonlyspan-byte-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L856)

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool) {#addproperty-readonlyspan-byte-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L868)

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, byte) {#addproperty-readonlyspan-char-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L881)

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, int) {#addproperty-readonlyspan-byte-int}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L895)

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool) {#addproperty-readonlyspan-byte-int-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L907)

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, int) {#addproperty-readonlyspan-char-int}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L920)

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, uint) {#addproperty-readonlyspan-byte-uint}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L935)

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool) {#addproperty-readonlyspan-byte-uint-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L948)

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, uint) {#addproperty-readonlyspan-char-uint}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L962)

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, long) {#addproperty-readonlyspan-byte-long}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L976)

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool) {#addproperty-readonlyspan-byte-long-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L988)

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, long) {#addproperty-readonlyspan-char-long}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1001)

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ulong) {#addproperty-readonlyspan-byte-ulong}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1016)

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool) {#addproperty-readonlyspan-byte-ulong-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1029)

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ulong) {#addproperty-readonlyspan-char-ulong}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1043)

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, short) {#addproperty-readonlyspan-byte-short}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1057)

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool) {#addproperty-readonlyspan-byte-short-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1069)

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, short) {#addproperty-readonlyspan-char-short}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1082)

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ushort) {#addproperty-readonlyspan-byte-ushort}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1097)

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool) {#addproperty-readonlyspan-byte-ushort-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1110)

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ushort) {#addproperty-readonlyspan-char-ushort}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1124)

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, float) {#addproperty-readonlyspan-byte-float}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1138)

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool) {#addproperty-readonlyspan-byte-float-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1150)

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, float) {#addproperty-readonlyspan-char-float}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1163)

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, double) {#addproperty-readonlyspan-byte-double}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1177)

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool) {#addproperty-readonlyspan-byte-double-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1189)

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, double) {#addproperty-readonlyspan-char-double}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1202)

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, decimal) {#addproperty-readonlyspan-byte-decimal}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1216)

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool) {#addproperty-readonlyspan-byte-decimal-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1228)

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, decimal) {#addproperty-readonlyspan-char-decimal}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1241)

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger) {#addproperty-readonlyspan-byte-ref-biginteger}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1255)

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool) {#addproperty-readonlyspan-byte-ref-biginteger-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1267)

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger) {#addproperty-readonlyspan-char-ref-biginteger}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1280)

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber) {#addproperty-readonlyspan-byte-ref-bignumber}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1295)

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool) {#addproperty-readonlyspan-byte-ref-bignumber-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1308)

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber) {#addproperty-readonlyspan-char-ref-bignumber}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1327)

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Int128) {#addproperty-readonlyspan-byte-int128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1343)

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool) {#addproperty-readonlyspan-byte-int128-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1355)

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Int128) {#addproperty-readonlyspan-char-int128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1368)

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128) {#addproperty-readonlyspan-byte-uint128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1383)

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool) {#addproperty-readonlyspan-byte-uint128-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1396)

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, UInt128) {#addproperty-readonlyspan-char-uint128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1410)

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Half) {#addproperty-readonlyspan-byte-half}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1424)

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool) {#addproperty-readonlyspan-byte-half-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1436)

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object, with control over escaping.

```csharp
public void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddProperty(ReadOnlySpan&lt;char&gt;, Half) {#addproperty-readonlyspan-char-half}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1449)

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

```csharp
public void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

