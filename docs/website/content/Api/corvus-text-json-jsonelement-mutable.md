---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElement.Mutable : IMutableJsonElement<JsonElement.Mutable>, IJsonElement<JsonElement.Mutable>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

## Implements

[`IMutableJsonElement<JsonElement.Mutable>`](/api/corvus-text-json-internal-imutablejsonelement-t.html), [`IJsonElement<JsonElement.Mutable>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [this\[int\]](/api/corvus-text-json-jsonelement-mutable.item.html) | [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |
| [this\[ReadOnlySpan&lt;byte&gt;\]](/api/corvus-text-json-jsonelement-mutable.item.html) | [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |
| [this\[ReadOnlySpan&lt;char&gt;\]](/api/corvus-text-json-jsonelement-mutable.item.html) | [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |
| [this\[string\]](/api/corvus-text-json-jsonelement-mutable.item.html) | [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) |  |
| [ValueKind](/api/corvus-text-json-jsonelement-mutable.valuekind.html) | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) |  |

## Methods

| Method | Description |
|--------|-------------|
| [AddItem(ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#additem-ref-jsonelement-source-int) |  |
| [AddItem(JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#additem-jsonelement-objectbuilder-build-int) |  |
| [AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#additem-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [AddItem(JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#additem-jsonelement-arraybuilder-build-int) |  |
| [AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#additem-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [AddItemNull()](/api/corvus-text-json-jsonelement-mutable.additemnull.html#additemnull) |  |
| [Apply(ref T)](/api/corvus-text-json-jsonelement-mutable.apply.html#apply-ref-t) |  |
| [Clone()](/api/corvus-text-json-jsonelement-mutable.clone.html#clone) |  |
| [CreateBuilder(JsonWorkspace)](/api/corvus-text-json-jsonelement-mutable.createbuilder.html#createbuilder-jsonworkspace) |  |
| [EnsurePropertyMap(ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.ensurepropertymap.html#ensurepropertymap-ref-jsonelement-mutable) `static` |  |
| [EnumerateArray()](/api/corvus-text-json-jsonelement-mutable.enumeratearray.html#enumeratearray) |  |
| [EnumerateObject()](/api/corvus-text-json-jsonelement-mutable.enumerateobject.html#enumerateobject) |  |
| [Equals(object)](/api/corvus-text-json-jsonelement-mutable.equals.html#equals-object) |  |
| [Equals(T)](/api/corvus-text-json-jsonelement-mutable.equals.html#equals-t) |  |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelement-mutable.evaluateschema.html#evaluateschema-ijsonschemaresultscollector) |  |
| [From(ref T)](/api/corvus-text-json-jsonelement-mutable.from.html#from-ref-t) `static` |  |
| [GetArrayLength()](/api/corvus-text-json-jsonelement-mutable.getarraylength.html#getarraylength) |  |
| [GetBigInteger()](/api/corvus-text-json-jsonelement-mutable.getbiginteger.html#getbiginteger) |  |
| [GetBigNumber()](/api/corvus-text-json-jsonelement-mutable.getbignumber.html#getbignumber) |  |
| [GetBoolean()](/api/corvus-text-json-jsonelement-mutable.getboolean.html#getboolean) |  |
| [GetByte()](/api/corvus-text-json-jsonelement-mutable.getbyte.html#getbyte) |  |
| [GetBytesFromBase64()](/api/corvus-text-json-jsonelement-mutable.getbytesfrombase64.html#getbytesfrombase64) |  |
| [GetDateTime()](/api/corvus-text-json-jsonelement-mutable.getdatetime.html#getdatetime) |  |
| [GetDateTimeOffset()](/api/corvus-text-json-jsonelement-mutable.getdatetimeoffset.html#getdatetimeoffset) |  |
| [GetDecimal()](/api/corvus-text-json-jsonelement-mutable.getdecimal.html#getdecimal) |  |
| [GetDouble()](/api/corvus-text-json-jsonelement-mutable.getdouble.html#getdouble) |  |
| [GetGuid()](/api/corvus-text-json-jsonelement-mutable.getguid.html#getguid) |  |
| [GetHalf()](/api/corvus-text-json-jsonelement-mutable.gethalf.html#gethalf) |  |
| [GetHashCode()](/api/corvus-text-json-jsonelement-mutable.gethashcode.html#gethashcode) |  |
| [GetInt128()](/api/corvus-text-json-jsonelement-mutable.getint128.html#getint128) |  |
| [GetInt16()](/api/corvus-text-json-jsonelement-mutable.getint16.html#getint16) |  |
| [GetInt32()](/api/corvus-text-json-jsonelement-mutable.getint32.html#getint32) |  |
| [GetInt64()](/api/corvus-text-json-jsonelement-mutable.getint64.html#getint64) |  |
| [GetLocalDate()](/api/corvus-text-json-jsonelement-mutable.getlocaldate.html#getlocaldate) |  |
| [GetOffsetDate()](/api/corvus-text-json-jsonelement-mutable.getoffsetdate.html#getoffsetdate) |  |
| [GetOffsetDateTime()](/api/corvus-text-json-jsonelement-mutable.getoffsetdatetime.html#getoffsetdatetime) |  |
| [GetOffsetTime()](/api/corvus-text-json-jsonelement-mutable.getoffsettime.html#getoffsettime) |  |
| [GetPeriod()](/api/corvus-text-json-jsonelement-mutable.getperiod.html#getperiod) |  |
| [GetProperty(string)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#getproperty-string) |  |
| [GetProperty(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#getproperty-readonlyspan-char) |  |
| [GetProperty(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#getproperty-readonlyspan-byte) |  |
| [GetPropertyCount()](/api/corvus-text-json-jsonelement-mutable.getpropertycount.html#getpropertycount) |  |
| [GetRawText()](/api/corvus-text-json-jsonelement-mutable.getrawtext.html#getrawtext) |  |
| [GetSByte()](/api/corvus-text-json-jsonelement-mutable.getsbyte.html#getsbyte) |  |
| [GetSingle()](/api/corvus-text-json-jsonelement-mutable.getsingle.html#getsingle) |  |
| [GetString()](/api/corvus-text-json-jsonelement-mutable.getstring.html#getstring) |  |
| [GetUInt128()](/api/corvus-text-json-jsonelement-mutable.getuint128.html#getuint128) |  |
| [GetUInt16()](/api/corvus-text-json-jsonelement-mutable.getuint16.html#getuint16) |  |
| [GetUInt32()](/api/corvus-text-json-jsonelement-mutable.getuint32.html#getuint32) |  |
| [GetUInt64()](/api/corvus-text-json-jsonelement-mutable.getuint64.html#getuint64) |  |
| [GetUtf16String()](/api/corvus-text-json-jsonelement-mutable.getutf16string.html#getutf16string) |  |
| [GetUtf8String()](/api/corvus-text-json-jsonelement-mutable.getutf8string.html#getutf8string) |  |
| [InsertItem(int, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#insertitem-int-ref-jsonelement-source-int) |  |
| [InsertItem(int, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#insertitem-int-jsonelement-objectbuilder-build-int) |  |
| [InsertItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#insertitem-int-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [InsertItem(int, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#insertitem-int-jsonelement-arraybuilder-build-int) |  |
| [InsertItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#insertitem-int-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [InsertItemNull(int)](/api/corvus-text-json-jsonelement-mutable.insertitemnull.html#insertitemnull-int) |  |
| [Remove(ref JsonElement)](/api/corvus-text-json-jsonelement-mutable.remove.html#remove-ref-jsonelement) |  |
| [RemoveAt(int)](/api/corvus-text-json-jsonelement-mutable.removeat.html#removeat-int) |  |
| [RemoveProperty(string)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#removeproperty-string) |  |
| [RemoveProperty(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#removeproperty-readonlyspan-char) |  |
| [RemoveProperty(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#removeproperty-readonlyspan-byte) |  |
| [RemoveRange(int, int)](/api/corvus-text-json-jsonelement-mutable.removerange.html#removerange-int-int) |  |
| [RemoveWhere(JsonPredicate&lt;T&gt;)](/api/corvus-text-json-jsonelement-mutable.removewhere.html#removewhere-jsonpredicate-t) |  |
| [RemoveWhere(JsonPredicate&lt;JsonElement&gt;)](/api/corvus-text-json-jsonelement-mutable.removewhere.html#removewhere-jsonpredicate-jsonelement) |  |
| [Replace(ref JsonElement, ref JsonElement.Source)](/api/corvus-text-json-jsonelement-mutable.replace.html#replace-ref-jsonelement-ref-jsonelement-source) |  |
| [SetItem(int, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#setitem-int-ref-jsonelement-source-int) |  |
| [SetItem(int, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#setitem-int-jsonelement-objectbuilder-build-int) |  |
| [SetItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#setitem-int-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetItem(int, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#setitem-int-jsonelement-arraybuilder-build-int) |  |
| [SetItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#setitem-int-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetItemNull(int)](/api/corvus-text-json-jsonelement-mutable.setitemnull.html#setitemnull-int) |  |
| [SetProperty(string, ref JsonElement.Source)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-string-ref-jsonelement-source) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-char-ref-jsonelement-source-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-byte-ref-jsonelement-source-int) |  |
| [SetProperty(string, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-string-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(string, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-string-ref-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-char-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-char-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-byte-jsonelement-objectbuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-byte-tcontext-jsonelement-objectbuilder-build-tcontext-int) |  |
| [SetProperty(string, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-string-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(string, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-string-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-char-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-char-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-byte-jsonelement-arraybuilder-build-int) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#setproperty-readonlyspan-byte-ref-tcontext-jsonelement-arraybuilder-build-tcontext-int) |  |
| [SetPropertyNull(string)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#setpropertynull-string) |  |
| [SetPropertyNull(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#setpropertynull-readonlyspan-char) |  |
| [SetPropertyNull(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#setpropertynull-readonlyspan-byte) |  |
| [ToString()](/api/corvus-text-json-jsonelement-mutable.tostring.html#tostring) |  |
| [ToString(string, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tostring.html#tostring-string-iformatprovider) |  |
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tryformat.html#tryformat-span-char-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tryformat.html#tryformat-span-byte-ref-int-readonlyspan-char-iformatprovider) |  |
| [TryGetBigInteger(ref BigInteger)](/api/corvus-text-json-jsonelement-mutable.trygetbiginteger.html#trygetbiginteger-ref-biginteger) |  |
| [TryGetBigNumber(ref BigNumber)](/api/corvus-text-json-jsonelement-mutable.trygetbignumber.html#trygetbignumber-ref-bignumber) |  |
| [TryGetByte(ref byte)](/api/corvus-text-json-jsonelement-mutable.trygetbyte.html#trygetbyte-ref-byte) |  |
| [TryGetBytesFromBase64(ref byte\[\])](/api/corvus-text-json-jsonelement-mutable.trygetbytesfrombase64.html#trygetbytesfrombase64-ref-byte) |  |
| [TryGetDateTime(ref DateTime)](/api/corvus-text-json-jsonelement-mutable.trygetdatetime.html#trygetdatetime-ref-datetime) |  |
| [TryGetDateTimeOffset(ref DateTimeOffset)](/api/corvus-text-json-jsonelement-mutable.trygetdatetimeoffset.html#trygetdatetimeoffset-ref-datetimeoffset) |  |
| [TryGetDecimal(ref decimal)](/api/corvus-text-json-jsonelement-mutable.trygetdecimal.html#trygetdecimal-ref-decimal) |  |
| [TryGetDouble(ref double)](/api/corvus-text-json-jsonelement-mutable.trygetdouble.html#trygetdouble-ref-double) |  |
| [TryGetGuid(ref Guid)](/api/corvus-text-json-jsonelement-mutable.trygetguid.html#trygetguid-ref-guid) |  |
| [TryGetHalf(ref Half)](/api/corvus-text-json-jsonelement-mutable.trygethalf.html#trygethalf-ref-half) |  |
| [TryGetInt128(ref Int128)](/api/corvus-text-json-jsonelement-mutable.trygetint128.html#trygetint128-ref-int128) |  |
| [TryGetInt16(ref short)](/api/corvus-text-json-jsonelement-mutable.trygetint16.html#trygetint16-ref-short) |  |
| [TryGetInt32(ref int)](/api/corvus-text-json-jsonelement-mutable.trygetint32.html#trygetint32-ref-int) |  |
| [TryGetInt64(ref long)](/api/corvus-text-json-jsonelement-mutable.trygetint64.html#trygetint64-ref-long) |  |
| [TryGetLocalDate(ref LocalDate)](/api/corvus-text-json-jsonelement-mutable.trygetlocaldate.html#trygetlocaldate-ref-localdate) |  |
| [TryGetOffsetDate(ref OffsetDate)](/api/corvus-text-json-jsonelement-mutable.trygetoffsetdate.html#trygetoffsetdate-ref-offsetdate) |  |
| [TryGetOffsetDateTime(ref OffsetDateTime)](/api/corvus-text-json-jsonelement-mutable.trygetoffsetdatetime.html#trygetoffsetdatetime-ref-offsetdatetime) |  |
| [TryGetOffsetTime(ref OffsetTime)](/api/corvus-text-json-jsonelement-mutable.trygetoffsettime.html#trygetoffsettime-ref-offsettime) |  |
| [TryGetPeriod(ref Period)](/api/corvus-text-json-jsonelement-mutable.trygetperiod.html#trygetperiod-ref-period) |  |
| [TryGetProperty(string, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#trygetproperty-string-ref-jsonelement-mutable) |  |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#trygetproperty-readonlyspan-char-ref-jsonelement-mutable) |  |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#trygetproperty-readonlyspan-byte-ref-jsonelement-mutable) |  |
| [TryGetSByte(ref sbyte)](/api/corvus-text-json-jsonelement-mutable.trygetsbyte.html#trygetsbyte-ref-sbyte) |  |
| [TryGetSingle(ref float)](/api/corvus-text-json-jsonelement-mutable.trygetsingle.html#trygetsingle-ref-float) |  |
| [TryGetUInt128(ref UInt128)](/api/corvus-text-json-jsonelement-mutable.trygetuint128.html#trygetuint128-ref-uint128) |  |
| [TryGetUInt16(ref ushort)](/api/corvus-text-json-jsonelement-mutable.trygetuint16.html#trygetuint16-ref-ushort) |  |
| [TryGetUInt32(ref uint)](/api/corvus-text-json-jsonelement-mutable.trygetuint32.html#trygetuint32-ref-uint) |  |
| [TryGetUInt64(ref ulong)](/api/corvus-text-json-jsonelement-mutable.trygetuint64.html#trygetuint64-ref-ulong) |  |
| [ValueEquals(string)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#valueequals-string) |  |
| [ValueEquals(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#valueequals-readonlyspan-byte) |  |
| [ValueEquals(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#valueequals-readonlyspan-char) |  |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelement-mutable.writeto.html#writeto-utf8jsonwriter) |  |

## Operators

| Operator | Description |
|----------|-------------|
| [operator ==(JsonElement.Mutable, JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-equality.html#operator-jsonelement-mutable-jsonelement-mutable) |  |
| [operator ==(JsonElement.Mutable, JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-equality.html#operator-jsonelement-mutable-jsonelement) |  |
| [explicit operator JsonElement.Mutable(JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-explicit.html#explicit-operator-jsonelement-mutable-jsonelement) |  |
| [implicit operator JsonElement(JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-implicit.html#implicit-operator-jsonelement-jsonelement-mutable) |  |
| [operator !=(JsonElement.Mutable, JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-inequality.html#operator-jsonelement-mutable-jsonelement-mutable) |  |
| [operator !=(JsonElement.Mutable, JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-inequality.html#operator-jsonelement-mutable-jsonelement) |  |

