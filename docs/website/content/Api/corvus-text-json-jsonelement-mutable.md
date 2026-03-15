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
| [AddItem(ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#void-additem-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [AddItem(JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#void-additem-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [AddItem(ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#void-additem-tcontext-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [AddItem(JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#void-additem-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [AddItem(ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.additem.html#void-additem-tcontext-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [AddItemNull()](/api/corvus-text-json-jsonelement-mutable.additemnull.html#void-additemnull) |  |
| [Apply(ref T)](/api/corvus-text-json-jsonelement-mutable.apply.html#void-apply-t-ref-t-value) |  |
| [Clone()](/api/corvus-text-json-jsonelement-mutable.clone.html#jsonelement-clone) |  |
| [CreateBuilder(JsonWorkspace)](/api/corvus-text-json-jsonelement-mutable.createbuilder.html#jsondocumentbuilder-jsonelement-mutable-createbuilder-jsonworkspace-workspace) |  |
| [EnsurePropertyMap(ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.ensurepropertymap.html#void-ensurepropertymap-ref-jsonelement-mutable-element) `static` |  |
| [EnumerateArray()](/api/corvus-text-json-jsonelement-mutable.enumeratearray.html#arrayenumerator-jsonelement-mutable-enumeratearray) |  |
| [EnumerateObject()](/api/corvus-text-json-jsonelement-mutable.enumerateobject.html#objectenumerator-jsonelement-mutable-enumerateobject) |  |
| [Equals(object)](/api/corvus-text-json-jsonelement-mutable.equals.html#bool-equals-object-obj) |  |
| [Equals(T)](/api/corvus-text-json-jsonelement-mutable.equals.html#bool-equals-t-t-other) |  |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelement-mutable.evaluateschema.html#bool-evaluateschema-ijsonschemaresultscollector-resultscollector) |  |
| [From(ref T)](/api/corvus-text-json-jsonelement-mutable.from.html#jsonelement-mutable-from-t-ref-t-instance) `static` |  |
| [GetArrayLength()](/api/corvus-text-json-jsonelement-mutable.getarraylength.html#int-getarraylength) |  |
| [GetBigInteger()](/api/corvus-text-json-jsonelement-mutable.getbiginteger.html#biginteger-getbiginteger) |  |
| [GetBigNumber()](/api/corvus-text-json-jsonelement-mutable.getbignumber.html#bignumber-getbignumber) |  |
| [GetBoolean()](/api/corvus-text-json-jsonelement-mutable.getboolean.html#bool-getboolean) |  |
| [GetByte()](/api/corvus-text-json-jsonelement-mutable.getbyte.html#byte-getbyte) |  |
| [GetBytesFromBase64()](/api/corvus-text-json-jsonelement-mutable.getbytesfrombase64.html#byte-getbytesfrombase64) |  |
| [GetDateTime()](/api/corvus-text-json-jsonelement-mutable.getdatetime.html#datetime-getdatetime) |  |
| [GetDateTimeOffset()](/api/corvus-text-json-jsonelement-mutable.getdatetimeoffset.html#datetimeoffset-getdatetimeoffset) |  |
| [GetDecimal()](/api/corvus-text-json-jsonelement-mutable.getdecimal.html#decimal-getdecimal) |  |
| [GetDouble()](/api/corvus-text-json-jsonelement-mutable.getdouble.html#double-getdouble) |  |
| [GetGuid()](/api/corvus-text-json-jsonelement-mutable.getguid.html#guid-getguid) |  |
| [GetHalf()](/api/corvus-text-json-jsonelement-mutable.gethalf.html#half-gethalf) |  |
| [GetHashCode()](/api/corvus-text-json-jsonelement-mutable.gethashcode.html#int-gethashcode) |  |
| [GetInt128()](/api/corvus-text-json-jsonelement-mutable.getint128.html#int128-getint128) |  |
| [GetInt16()](/api/corvus-text-json-jsonelement-mutable.getint16.html#short-getint16) |  |
| [GetInt32()](/api/corvus-text-json-jsonelement-mutable.getint32.html#int-getint32) |  |
| [GetInt64()](/api/corvus-text-json-jsonelement-mutable.getint64.html#long-getint64) |  |
| [GetLocalDate()](/api/corvus-text-json-jsonelement-mutable.getlocaldate.html#localdate-getlocaldate) |  |
| [GetOffsetDate()](/api/corvus-text-json-jsonelement-mutable.getoffsetdate.html#offsetdate-getoffsetdate) |  |
| [GetOffsetDateTime()](/api/corvus-text-json-jsonelement-mutable.getoffsetdatetime.html#offsetdatetime-getoffsetdatetime) |  |
| [GetOffsetTime()](/api/corvus-text-json-jsonelement-mutable.getoffsettime.html#offsettime-getoffsettime) |  |
| [GetPeriod()](/api/corvus-text-json-jsonelement-mutable.getperiod.html#period-getperiod) |  |
| [GetProperty(string)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#jsonelement-mutable-getproperty-string-propertyname) |  |
| [GetProperty(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#jsonelement-mutable-getproperty-readonlyspan-char-propertyname) |  |
| [GetProperty(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.getproperty.html#jsonelement-mutable-getproperty-readonlyspan-byte-utf8propertyname) |  |
| [GetPropertyCount()](/api/corvus-text-json-jsonelement-mutable.getpropertycount.html#int-getpropertycount) |  |
| [GetRawText()](/api/corvus-text-json-jsonelement-mutable.getrawtext.html#string-getrawtext) |  |
| [GetSByte()](/api/corvus-text-json-jsonelement-mutable.getsbyte.html#sbyte-getsbyte) |  |
| [GetSingle()](/api/corvus-text-json-jsonelement-mutable.getsingle.html#float-getsingle) |  |
| [GetString()](/api/corvus-text-json-jsonelement-mutable.getstring.html#string-getstring) |  |
| [GetUInt128()](/api/corvus-text-json-jsonelement-mutable.getuint128.html#uint128-getuint128) |  |
| [GetUInt16()](/api/corvus-text-json-jsonelement-mutable.getuint16.html#ushort-getuint16) |  |
| [GetUInt32()](/api/corvus-text-json-jsonelement-mutable.getuint32.html#uint-getuint32) |  |
| [GetUInt64()](/api/corvus-text-json-jsonelement-mutable.getuint64.html#ulong-getuint64) |  |
| [GetUtf16String()](/api/corvus-text-json-jsonelement-mutable.getutf16string.html#unescapedutf16jsonstring-getutf16string) |  |
| [GetUtf8String()](/api/corvus-text-json-jsonelement-mutable.getutf8string.html#unescapedutf8jsonstring-getutf8string) |  |
| [InsertItem(int, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#void-insertitem-int-itemindex-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [InsertItem(int, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#void-insertitem-int-itemindex-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [InsertItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#void-insertitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [InsertItem(int, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#void-insertitem-int-itemindex-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [InsertItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.insertitem.html#void-insertitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [InsertItemNull(int)](/api/corvus-text-json-jsonelement-mutable.insertitemnull.html#void-insertitemnull-int-itemindex) |  |
| [Remove(ref JsonElement)](/api/corvus-text-json-jsonelement-mutable.remove.html#bool-remove-ref-jsonelement-item) |  |
| [RemoveAt(int)](/api/corvus-text-json-jsonelement-mutable.removeat.html#void-removeat-int-index) |  |
| [RemoveProperty(string)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#bool-removeproperty-string-propertyname) |  |
| [RemoveProperty(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#bool-removeproperty-readonlyspan-char-propertyname) |  |
| [RemoveProperty(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.removeproperty.html#bool-removeproperty-readonlyspan-byte-propertyname) |  |
| [RemoveRange(int, int)](/api/corvus-text-json-jsonelement-mutable.removerange.html#void-removerange-int-startindex-int-count) |  |
| [RemoveWhere(JsonPredicate&lt;T&gt;)](/api/corvus-text-json-jsonelement-mutable.removewhere.html#void-removewhere-t-jsonpredicate-t-predicate) |  |
| [RemoveWhere(JsonPredicate&lt;JsonElement&gt;)](/api/corvus-text-json-jsonelement-mutable.removewhere.html#void-removewhere-jsonpredicate-jsonelement-predicate) |  |
| [Replace(ref JsonElement, ref JsonElement.Source)](/api/corvus-text-json-jsonelement-mutable.replace.html#bool-replace-ref-jsonelement-olditem-ref-jsonelement-source-newitem) |  |
| [SetItem(int, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#void-setitem-int-itemindex-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetItem(int, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#void-setitem-int-itemindex-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetItem(int, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#void-setitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetItem(int, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#void-setitem-int-itemindex-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetItem(int, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setitem.html#void-setitem-tcontext-int-itemindex-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetItemNull(int)](/api/corvus-text-json-jsonelement-mutable.setitemnull.html#void-setitemnull-int-itemindex) |  |
| [SetProperty(string, ref JsonElement.Source)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-string-propertyname-ref-jsonelement-source-source) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-char-propertyname-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-byte-propertyname-ref-jsonelement-source-source-int-estimatedmembercount) |  |
| [SetProperty(string, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-string-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(string, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-string-propertyname-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-char-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-readonlyspan-char-propertyname-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ObjectBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-byte-propertyname-jsonelement-objectbuilder-build-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-readonlyspan-byte-propertyname-tcontext-context-jsonelement-objectbuilder-build-tcontext-objectvalue-int-estimatedmembercount) |  |
| [SetProperty(string, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-string-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(string, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-string-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-char-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;char&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-readonlyspan-char-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, JsonElement.ArrayBuilder.Build, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-readonlyspan-byte-propertyname-jsonelement-arraybuilder-build-arrayvalue-int-estimatedmembercount) |  |
| [SetProperty(ReadOnlySpan&lt;byte&gt;, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement-mutable.setproperty.html#void-setproperty-tcontext-readonlyspan-byte-propertyname-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-arrayvalue-int-estimatedmembercount) |  |
| [SetPropertyNull(string)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#void-setpropertynull-string-propertyname) |  |
| [SetPropertyNull(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#void-setpropertynull-readonlyspan-char-propertyname) |  |
| [SetPropertyNull(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.setpropertynull.html#void-setpropertynull-readonlyspan-byte-propertyname) |  |
| [ToString()](/api/corvus-text-json-jsonelement-mutable.tostring.html#string-tostring) |  |
| [ToString(string, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tostring.html#string-tostring-string-format-iformatprovider-formatprovider) |  |
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tryformat.html#bool-tryformat-span-char-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement-mutable.tryformat.html#bool-tryformat-span-byte-utf8destination-ref-int-byteswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryGetBigInteger(ref BigInteger)](/api/corvus-text-json-jsonelement-mutable.trygetbiginteger.html#bool-trygetbiginteger-ref-biginteger-value) |  |
| [TryGetBigNumber(ref BigNumber)](/api/corvus-text-json-jsonelement-mutable.trygetbignumber.html#bool-trygetbignumber-ref-bignumber-value) |  |
| [TryGetByte(ref byte)](/api/corvus-text-json-jsonelement-mutable.trygetbyte.html#bool-trygetbyte-ref-byte-value) |  |
| [TryGetBytesFromBase64(ref byte\[\])](/api/corvus-text-json-jsonelement-mutable.trygetbytesfrombase64.html#bool-trygetbytesfrombase64-ref-byte-value) |  |
| [TryGetDateTime(ref DateTime)](/api/corvus-text-json-jsonelement-mutable.trygetdatetime.html#bool-trygetdatetime-ref-datetime-value) |  |
| [TryGetDateTimeOffset(ref DateTimeOffset)](/api/corvus-text-json-jsonelement-mutable.trygetdatetimeoffset.html#bool-trygetdatetimeoffset-ref-datetimeoffset-value) |  |
| [TryGetDecimal(ref decimal)](/api/corvus-text-json-jsonelement-mutable.trygetdecimal.html#bool-trygetdecimal-ref-decimal-value) |  |
| [TryGetDouble(ref double)](/api/corvus-text-json-jsonelement-mutable.trygetdouble.html#bool-trygetdouble-ref-double-value) |  |
| [TryGetGuid(ref Guid)](/api/corvus-text-json-jsonelement-mutable.trygetguid.html#bool-trygetguid-ref-guid-value) |  |
| [TryGetHalf(ref Half)](/api/corvus-text-json-jsonelement-mutable.trygethalf.html#bool-trygethalf-ref-half-value) |  |
| [TryGetInt128(ref Int128)](/api/corvus-text-json-jsonelement-mutable.trygetint128.html#bool-trygetint128-ref-int128-value) |  |
| [TryGetInt16(ref short)](/api/corvus-text-json-jsonelement-mutable.trygetint16.html#bool-trygetint16-ref-short-value) |  |
| [TryGetInt32(ref int)](/api/corvus-text-json-jsonelement-mutable.trygetint32.html#bool-trygetint32-ref-int-value) |  |
| [TryGetInt64(ref long)](/api/corvus-text-json-jsonelement-mutable.trygetint64.html#bool-trygetint64-ref-long-value) |  |
| [TryGetLocalDate(ref LocalDate)](/api/corvus-text-json-jsonelement-mutable.trygetlocaldate.html#bool-trygetlocaldate-ref-localdate-value) |  |
| [TryGetOffsetDate(ref OffsetDate)](/api/corvus-text-json-jsonelement-mutable.trygetoffsetdate.html#bool-trygetoffsetdate-ref-offsetdate-value) |  |
| [TryGetOffsetDateTime(ref OffsetDateTime)](/api/corvus-text-json-jsonelement-mutable.trygetoffsetdatetime.html#bool-trygetoffsetdatetime-ref-offsetdatetime-value) |  |
| [TryGetOffsetTime(ref OffsetTime)](/api/corvus-text-json-jsonelement-mutable.trygetoffsettime.html#bool-trygetoffsettime-ref-offsettime-value) |  |
| [TryGetPeriod(ref Period)](/api/corvus-text-json-jsonelement-mutable.trygetperiod.html#bool-trygetperiod-ref-period-value) |  |
| [TryGetProperty(string, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#bool-trygetproperty-string-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#bool-trygetproperty-readonlyspan-char-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.trygetproperty.html#bool-trygetproperty-readonlyspan-byte-utf8propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetSByte(ref sbyte)](/api/corvus-text-json-jsonelement-mutable.trygetsbyte.html#bool-trygetsbyte-ref-sbyte-value) |  |
| [TryGetSingle(ref float)](/api/corvus-text-json-jsonelement-mutable.trygetsingle.html#bool-trygetsingle-ref-float-value) |  |
| [TryGetUInt128(ref UInt128)](/api/corvus-text-json-jsonelement-mutable.trygetuint128.html#bool-trygetuint128-ref-uint128-value) |  |
| [TryGetUInt16(ref ushort)](/api/corvus-text-json-jsonelement-mutable.trygetuint16.html#bool-trygetuint16-ref-ushort-value) |  |
| [TryGetUInt32(ref uint)](/api/corvus-text-json-jsonelement-mutable.trygetuint32.html#bool-trygetuint32-ref-uint-value) |  |
| [TryGetUInt64(ref ulong)](/api/corvus-text-json-jsonelement-mutable.trygetuint64.html#bool-trygetuint64-ref-ulong-value) |  |
| [ValueEquals(string)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#bool-valueequals-string-text) |  |
| [ValueEquals(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#bool-valueequals-readonlyspan-byte-utf8text) |  |
| [ValueEquals(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement-mutable.valueequals.html#bool-valueequals-readonlyspan-char-text) |  |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelement-mutable.writeto.html#void-writeto-utf8jsonwriter-writer) |  |

## Operators

| Operator | Description |
|----------|-------------|
| [operator ==(JsonElement.Mutable, JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-equality.html#static-bool-operator-jsonelement-mutable-left-jsonelement-mutable-right) |  |
| [operator ==(JsonElement.Mutable, JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-equality.html#static-bool-operator-jsonelement-mutable-left-jsonelement-right) |  |
| [explicit operator JsonElement.Mutable(JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-explicit.html#static-explicit-operator-jsonelement-mutable-jsonelement-value) |  |
| [implicit operator JsonElement(JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-implicit.html#static-implicit-operator-jsonelement-jsonelement-mutable-value) |  |
| [operator !=(JsonElement.Mutable, JsonElement.Mutable)](/api/corvus-text-json-jsonelement-mutable.op-inequality.html#static-bool-operator-jsonelement-mutable-left-jsonelement-mutable-right) |  |
| [operator !=(JsonElement.Mutable, JsonElement)](/api/corvus-text-json-jsonelement-mutable.op-inequality.html#static-bool-operator-jsonelement-mutable-left-jsonelement-right) |  |

