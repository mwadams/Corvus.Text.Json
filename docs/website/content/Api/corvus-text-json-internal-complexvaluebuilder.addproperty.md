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
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction)](#void-addproperty-readonlyspan-byte-propertyname-complexvaluebuilder-valuebuilderaction-createcomplexvalue) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#void-addproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-complexvaluebuilder-valuebuilderaction-tcontext-createcomplexvalue) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ComplexValueBuilder.ValueBuilderAction, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-complexvaluebuilder-valuebuilderaction-createcomplexvalue-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;, bool, bool)](#void-addproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-complexvaluebuilder-valuebuilderaction-tcontext-createcomplexvalue-bool-escapename-bool-namerequiresunescaping) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ComplexValueBuilder.ValueBuilderAction)](#void-addproperty-readonlyspan-char-propertyname-complexvaluebuilder-valuebuilderaction-createcomplexvalue) |  |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref TContext, ComplexValueBuilder.ValueBuilderAction&lt;TContext&gt;)](#void-addproperty-tcontext-readonlyspan-char-propertyname-ref-tcontext-context-complexvaluebuilder-valuebuilderaction-tcontext-createcomplexvalue) |  |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#void-addproperty-readonlyspan-byte-propertyname-readonlyspan-byte-utf8string) | Adds a property with a string value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-readonlyspan-byte-utf8string-bool-escapename-bool-escapevalue-bool-namerequiresunescaping-bool-valuerequiresunescaping) | Adds a property with a string value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-readonlyspan-char-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a string value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#void-addproperty-readonlyspan-char-propertyname-readonlyspan-char-value) | Adds a property with a string value to the current object. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-addproperty-readonlyspan-char-propertyname-readonlyspan-byte-value-bool-escapevalue-bool-valuerequiresunescaping) | Adds a property with a string value to the current object, with control over escaping the value. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool)](#void-addproperty-readonlyspan-byte-propertyname-bool-value) | Adds a property with a boolean value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-bool-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a boolean value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, bool)](#void-addproperty-readonlyspan-char-propertyname-bool-value) | Adds a property with a boolean value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref T)](#void-addproperty-t-readonlyspan-byte-propertyname-ref-t-value) | Adds a property with a JSON element value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, T, bool, bool)](#void-addproperty-t-readonlyspan-byte-propertyname-t-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a JSON element value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, T)](#void-addproperty-t-readonlyspan-char-propertyname-t-value) | Adds a property with a JSON element value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid)](#void-addproperty-readonlyspan-byte-propertyname-guid-value) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Guid, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-guid-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Guid)](#void-addproperty-readonlyspan-char-propertyname-guid-value) | Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetime-value) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetime-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTime)](#void-addproperty-readonlyspan-char-propertyname-ref-datetime-value) | Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetimeoffset-value) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref DateTimeOffset, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-datetimeoffset-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref DateTimeOffset)](#void-addproperty-readonlyspan-char-propertyname-ref-datetimeoffset-value) | Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdatetime-value) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdatetime-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDateTime)](#void-addproperty-readonlyspan-char-propertyname-ref-offsetdatetime-value) | Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsettime-value) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetTime, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsettime-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetTime)](#void-addproperty-readonlyspan-char-propertyname-ref-offsettime-value) | Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdate-value) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref OffsetDate, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-offsetdate-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref OffsetDate)](#void-addproperty-readonlyspan-char-propertyname-ref-offsetdate-value) | Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate)](#void-addproperty-readonlyspan-byte-propertyname-ref-localdate-value) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref LocalDate, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-localdate-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref LocalDate)](#void-addproperty-readonlyspan-char-propertyname-ref-localdate-value) | Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period)](#void-addproperty-readonlyspan-byte-propertyname-ref-period-value) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref Period, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-period-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref Period)](#void-addproperty-readonlyspan-char-propertyname-ref-period-value) | Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte)](#void-addproperty-readonlyspan-byte-propertyname-sbyte-value) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, sbyte, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-sbyte-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, sbyte)](#void-addproperty-readonlyspan-char-propertyname-sbyte-value) | Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte)](#void-addproperty-readonlyspan-byte-propertyname-byte-value) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, byte, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-byte-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, byte)](#void-addproperty-readonlyspan-char-propertyname-byte-value) | Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int)](#void-addproperty-readonlyspan-byte-propertyname-int-value) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, int, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-int-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, int)](#void-addproperty-readonlyspan-char-propertyname-int-value) | Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint)](#void-addproperty-readonlyspan-byte-propertyname-uint-value) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, uint, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-uint-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, uint)](#void-addproperty-readonlyspan-char-propertyname-uint-value) | Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long)](#void-addproperty-readonlyspan-byte-propertyname-long-value) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, long, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-long-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, long)](#void-addproperty-readonlyspan-char-propertyname-long-value) | Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong)](#void-addproperty-readonlyspan-byte-propertyname-ulong-value) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ulong, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ulong-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ulong)](#void-addproperty-readonlyspan-char-propertyname-ulong-value) | Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short)](#void-addproperty-readonlyspan-byte-propertyname-short-value) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, short, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-short-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, short)](#void-addproperty-readonlyspan-char-propertyname-short-value) | Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort)](#void-addproperty-readonlyspan-byte-propertyname-ushort-value) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ushort, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ushort-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ushort)](#void-addproperty-readonlyspan-char-propertyname-ushort-value) | Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float)](#void-addproperty-readonlyspan-byte-propertyname-float-value) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, float, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-float-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, float)](#void-addproperty-readonlyspan-char-propertyname-float-value) | Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double)](#void-addproperty-readonlyspan-byte-propertyname-double-value) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, double, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-double-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, double)](#void-addproperty-readonlyspan-char-propertyname-double-value) | Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal)](#void-addproperty-readonlyspan-byte-propertyname-decimal-value) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, decimal, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-decimal-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, decimal)](#void-addproperty-readonlyspan-char-propertyname-decimal-value) | Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger)](#void-addproperty-readonlyspan-byte-propertyname-ref-biginteger-value) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigInteger, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-biginteger-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigInteger)](#void-addproperty-readonlyspan-char-propertyname-ref-biginteger-value) | Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](#void-addproperty-readonlyspan-byte-propertyname-ref-bignumber-value) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, ref BigNumber, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-ref-bignumber-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#void-addproperty-readonlyspan-char-propertyname-ref-bignumber-value) | Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128)](#void-addproperty-readonlyspan-byte-propertyname-int128-value) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Int128, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-int128-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Int128)](#void-addproperty-readonlyspan-char-propertyname-int128-value) | Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128)](#void-addproperty-readonlyspan-byte-propertyname-uint128-value) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, UInt128, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-uint128-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, UInt128)](#void-addproperty-readonlyspan-char-propertyname-uint128-value) | Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half)](#void-addproperty-readonlyspan-byte-propertyname-half-value) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object. |
| [AddProperty(ReadOnlySpan&lt;byte&gt;, Half, bool, bool)](#void-addproperty-readonlyspan-byte-propertyname-half-value-bool-escapename-bool-namerequiresunescaping) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object, with control over escaping. |
| [AddProperty(ReadOnlySpan&lt;char&gt;, Half)](#void-addproperty-readonlyspan-char-propertyname-half-value) | Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object. |

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<byte> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ComplexValueBuilder.ValueBuilderAction createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty

```csharp
void AddProperty<TContext>(ReadOnlySpan<char> propertyName, ref TContext context, ComplexValueBuilder.ValueBuilderAction<TContext> createComplexValue)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `context` | `ref TContext` |  |
| `createComplexValue` | [`ComplexValueBuilder.ValueBuilderAction<TContext>`](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) |  |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String)
```

Adds a property with a string value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a UTF-8 byte span. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> utf8String, bool escapeName, bool escapeValue, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ReadOnlySpan<char> value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Adds a property with a string value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property value as a character span. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool escapeValue, bool valueRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, bool value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, bool value)
```

Adds a property with a boolean value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

---

## AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, ref T value)
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

## AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<byte> propertyName, T value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty<T>(ReadOnlySpan<char> propertyName, T value)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value)
```

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Guid value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Guid value)
```

Adds a property with a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTime value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTime value)
```

Adds a property with a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref DateTimeOffset value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref DateTimeOffset value)
```

Adds a property with a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDateTime value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDateTime value)
```

Adds a property with a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) | The [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetTime value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetTime value)
```

Adds a property with a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) | The [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref OffsetDate value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref OffsetDate value)
```

Adds a property with a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) | The [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref LocalDate value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref LocalDate value)
```

Adds a property with a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) | The [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value)
```

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref Period value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref Period value)
```

Adds a property with a [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref Period`](/api/corvus-text-json-period.html) | The [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value)
```

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, sbyte value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, sbyte value)
```

Adds a property with an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`sbyte`](https://learn.microsoft.com/dotnet/api/system.sbyte) | The [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value)
```

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, byte value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, byte value)
```

Adds a property with a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`byte`](https://learn.microsoft.com/dotnet/api/system.byte) | The [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value)
```

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, int value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, int value)
```

Adds a property with an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value)
```

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, uint value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, uint value)
```

Adds a property with a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value)
```

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, long value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, long value)
```

Adds a property with a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value)
```

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ulong value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ulong value)
```

Adds a property with a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value)
```

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, short value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, short value)
```

Adds a property with a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`short`](https://learn.microsoft.com/dotnet/api/system.int16) | The [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value)
```

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ushort value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ushort value)
```

Adds a property with a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ushort`](https://learn.microsoft.com/dotnet/api/system.uint16) | The [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value)
```

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, float value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, float value)
```

Adds a property with a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value)
```

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, double value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, double value)
```

Adds a property with a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value)
```

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, decimal value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, decimal value)
```

Adds a property with a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigInteger value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigInteger value)
```

Adds a property with a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, ref BigNumber value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, ref BigNumber value)
```

Adds a property with a [`BigNumber`](/api/corvus-numerics-bignumber.html) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value)
```

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Int128 value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Int128 value)
```

Adds a property with an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) | The [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, UInt128 value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, UInt128 value)
```

Adds a property with a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) | The [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value)
```

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

---

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<byte> propertyName, Half value, bool escapeName, bool nameRequiresUnescaping)
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

## AddProperty

```csharp
void AddProperty(ReadOnlySpan<char> propertyName, Half value)
```

Adds a property with a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `value` | [`Half`](https://learn.microsoft.com/dotnet/api/system.half) | The [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value. |

---

