---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Source — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElement.Source
```

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonElement.Source(JsonElement.ArrayBuilder.Build)](/api/corvus-text-json-jsonelement-source.ctor.html#jsonelement-source-jsonelement-arraybuilder-build) |  |
| [JsonElement.Source(JsonElement.ObjectBuilder.Build)](/api/corvus-text-json-jsonelement-source.ctor.html#jsonelement-source-jsonelement-objectbuilder-build) |  |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsUndefined](/api/corvus-text-json-jsonelement-source.isundefined.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Methods

| Method | Description |
|--------|-------------|
| [AddAsItem(ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasitem.html#addasitem-ref-complexvaluebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool)](/api/corvus-text-json-jsonelement-source.addasproperty.html#addasproperty-readonlyspan-byte-ref-complexvaluebuilder-bool-bool) |  |
| [AddAsProperty(string, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasproperty.html#addasproperty-string-ref-complexvaluebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasproperty.html#addasproperty-readonlyspan-char-ref-complexvaluebuilder) |  |
| [FormattedNumber(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-source.formattednumber.html#formattednumber-readonlyspan-byte) `static` |  |
| [Null()](/api/corvus-text-json-jsonelement-source.null.html#null) `static` |  |
| [RawString(ReadOnlySpan&lt;byte&gt;, bool)](/api/corvus-text-json-jsonelement-source.rawstring.html#rawstring-readonlyspan-byte-bool) `static` |  |

## Operators

| Operator | Description |
|----------|-------------|
| [implicit operator JsonElement.Source(ref JsonElement)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-ref-jsonelement) |  |
| [implicit operator JsonElement.Source(ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-ref-jsonelement-mutable) |  |
| [implicit operator JsonElement.Source(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-readonlyspan-byte) |  |
| [implicit operator JsonElement.Source(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-readonlyspan-char) |  |
| [implicit operator JsonElement.Source(string)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-string) |  |
| [implicit operator JsonElement.Source(DateTimeOffset)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-datetimeoffset) |  |
| [implicit operator JsonElement.Source(DateTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-datetime) |  |
| [implicit operator JsonElement.Source(OffsetDateTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-offsetdatetime) |  |
| [implicit operator JsonElement.Source(OffsetDate)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-offsetdate) |  |
| [implicit operator JsonElement.Source(OffsetTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-offsettime) |  |
| [implicit operator JsonElement.Source(LocalDate)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-localdate) |  |
| [implicit operator JsonElement.Source(Period)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-period) |  |
| [implicit operator JsonElement.Source(Guid)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-guid) |  |
| [implicit operator JsonElement.Source(Uri)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-uri) |  |
| [implicit operator JsonElement.Source(bool)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-bool) |  |
| [implicit operator JsonElement.Source(long)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-long) |  |
| [implicit operator JsonElement.Source(int)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-int) |  |
| [implicit operator JsonElement.Source(short)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-short) |  |
| [implicit operator JsonElement.Source(sbyte)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-sbyte) |  |
| [implicit operator JsonElement.Source(ulong)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-ulong) |  |
| [implicit operator JsonElement.Source(uint)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-uint) |  |
| [implicit operator JsonElement.Source(ushort)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-ushort) |  |
| [implicit operator JsonElement.Source(byte)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-byte) |  |
| [implicit operator JsonElement.Source(decimal)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-decimal) |  |
| [implicit operator JsonElement.Source(double)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-double) |  |
| [implicit operator JsonElement.Source(float)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-float) |  |
| [implicit operator JsonElement.Source(Int128)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-int128) |  |
| [implicit operator JsonElement.Source(UInt128)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-uint128) |  |
| [implicit operator JsonElement.Source(Half)](/api/corvus-text-json-jsonelement-source.op-implicit.html#implicit-operator-jsonelement-source-half) |  |

