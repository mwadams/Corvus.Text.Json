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
| [JsonElement.Source(JsonElement.ArrayBuilder.Build)](/api/corvus-text-json-jsonelement-source.ctor.html#jsonelement-source-jsonelement-arraybuilder-build-value) |  |
| [JsonElement.Source(JsonElement.ObjectBuilder.Build)](/api/corvus-text-json-jsonelement-source.ctor.html#jsonelement-source-jsonelement-objectbuilder-build-value) |  |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsUndefined](/api/corvus-text-json-jsonelement-source.isundefined.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Methods

| Method | Description |
|--------|-------------|
| [AddAsItem(ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasitem.html#void-addasitem-ref-complexvaluebuilder-valuebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool)](/api/corvus-text-json-jsonelement-source.addasproperty.html#void-addasproperty-readonlyspan-byte-utf8name-ref-complexvaluebuilder-valuebuilder-bool-escapename-bool-namerequiresunescaping) |  |
| [AddAsProperty(string, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasproperty.html#void-addasproperty-string-name-ref-complexvaluebuilder-valuebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder)](/api/corvus-text-json-jsonelement-source.addasproperty.html#void-addasproperty-readonlyspan-char-name-ref-complexvaluebuilder-valuebuilder) |  |
| [FormattedNumber(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-source.formattednumber.html#jsonelement-source-formattednumber-readonlyspan-byte-value) `static` |  |
| [Null()](/api/corvus-text-json-jsonelement-source.null.html#jsonelement-source-null) `static` |  |
| [RawString(ReadOnlySpan&lt;byte&gt;, bool)](/api/corvus-text-json-jsonelement-source.rawstring.html#jsonelement-source-rawstring-readonlyspan-byte-value-bool-requiresunescaping) `static` |  |

## Operators

| Operator | Description |
|----------|-------------|
| [implicit operator JsonElement.Source(ref JsonElement)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-ref-jsonelement-value) |  |
| [implicit operator JsonElement.Source(ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-ref-jsonelement-mutable-value) |  |
| [implicit operator JsonElement.Source(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-readonlyspan-byte-value) |  |
| [implicit operator JsonElement.Source(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-readonlyspan-char-value) |  |
| [implicit operator JsonElement.Source(string)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-string-value) |  |
| [implicit operator JsonElement.Source(DateTimeOffset)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-datetimeoffset-value) |  |
| [implicit operator JsonElement.Source(DateTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-datetime-value) |  |
| [implicit operator JsonElement.Source(OffsetDateTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-offsetdatetime-value) |  |
| [implicit operator JsonElement.Source(OffsetDate)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-offsetdate-value) |  |
| [implicit operator JsonElement.Source(OffsetTime)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-offsettime-value) |  |
| [implicit operator JsonElement.Source(LocalDate)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-localdate-value) |  |
| [implicit operator JsonElement.Source(Period)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-period-value) |  |
| [implicit operator JsonElement.Source(Guid)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-guid-value) |  |
| [implicit operator JsonElement.Source(Uri)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-uri-value) |  |
| [implicit operator JsonElement.Source(bool)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-bool-value) |  |
| [implicit operator JsonElement.Source(long)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-long-value) |  |
| [implicit operator JsonElement.Source(int)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-int-value) |  |
| [implicit operator JsonElement.Source(short)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-short-value) |  |
| [implicit operator JsonElement.Source(sbyte)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-sbyte-value) |  |
| [implicit operator JsonElement.Source(ulong)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-ulong-value) |  |
| [implicit operator JsonElement.Source(uint)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-uint-value) |  |
| [implicit operator JsonElement.Source(ushort)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-ushort-value) |  |
| [implicit operator JsonElement.Source(byte)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-byte-value) |  |
| [implicit operator JsonElement.Source(decimal)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-decimal-value) |  |
| [implicit operator JsonElement.Source(double)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-double-value) |  |
| [implicit operator JsonElement.Source(float)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-float-value) |  |
| [implicit operator JsonElement.Source(Int128)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-int128-value) |  |
| [implicit operator JsonElement.Source(UInt128)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-uint128-value) |  |
| [implicit operator JsonElement.Source(Half)](/api/corvus-text-json-jsonelement-source.op-implicit.html#static-implicit-operator-jsonelement-source-half-value) |  |

