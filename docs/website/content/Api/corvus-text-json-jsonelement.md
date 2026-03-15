---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElement : IJsonElement<JsonElement>, IJsonElement, IFormattable, ISpanFormattable, IUtf8SpanFormattable
```

Represents a specific JSON value within a [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html).

## Implements

[`IJsonElement<JsonElement>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IUtf8SpanFormattable`](https://learn.microsoft.com/dotnet/api/system.iutf8spanformattable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [this\[int\]](/api/corvus-text-json-jsonelement.item.html) | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | Get the value at a specified index when the current value is a [`Array`](/api/corvus-text-json-jsonvaluekind.html#array). |
| [this\[ReadOnlySpan&lt;byte&gt;\]](/api/corvus-text-json-jsonelement.item.html) | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | Gets the value of the property with the given UTF-8 encoded name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [this\[ReadOnlySpan&lt;char&gt;\]](/api/corvus-text-json-jsonelement.item.html) | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [this\[string\]](/api/corvus-text-json-jsonelement.item.html) | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [ValueKind](/api/corvus-text-json-jsonelement.valuekind.html) | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is. |

## Methods

| Method | Description |
|--------|-------------|
| [Clone()](/api/corvus-text-json-jsonelement.clone.html#jsonelement-clone) | Get a JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html). |
| [CreateArrayBuilder(JsonWorkspace, int)](/api/corvus-text-json-jsonelement.createarraybuilder.html#jsondocumentbuilder-jsonelement-mutable-createarraybuilder-jsonworkspace-workspace-int-estimatedmembercount) `static` | Creates an empty mutable array document builder. |
| [CreateBuilder(JsonWorkspace, ref JsonElement.Source, int)](/api/corvus-text-json-jsonelement.createbuilder.html#jsondocumentbuilder-jsonelement-mutable-createbuilder-jsonworkspace-workspace-ref-jsonelement-source-source-int-estimatedmembercount) `static` |  |
| [CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ArrayBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement.createbuilder.html#jsondocumentbuilder-jsonelement-mutable-createbuilder-tcontext-jsonworkspace-workspace-ref-tcontext-context-jsonelement-arraybuilder-build-tcontext-builder-int-estimatedmembercount) `static` |  |
| [CreateBuilder(JsonWorkspace, ref TContext, JsonElement.ObjectBuilder.Build&lt;TContext&gt;, int)](/api/corvus-text-json-jsonelement.createbuilder.html#jsondocumentbuilder-jsonelement-mutable-createbuilder-tcontext-jsonworkspace-workspace-ref-tcontext-context-jsonelement-objectbuilder-build-tcontext-builder-int-estimatedmembercount) `static` |  |
| [CreateBuilder(JsonWorkspace)](/api/corvus-text-json-jsonelement.createbuilder.html#jsondocumentbuilder-jsonelement-mutable-createbuilder-jsonworkspace-workspace) | Creates a mutable document builder from this JsonElement using the specified workspace. |
| [CreateObjectBuilder(JsonWorkspace, int)](/api/corvus-text-json-jsonelement.createobjectbuilder.html#jsondocumentbuilder-jsonelement-mutable-createobjectbuilder-jsonworkspace-workspace-int-estimatedmembercount) `static` | Creates an empty mutable object document builder. |
| [EnsurePropertyMap()](/api/corvus-text-json-jsonelement.ensurepropertymap.html#void-ensurepropertymap) | Ensures that a fast-lookup property map is created for this element. |
| [EnumerateArray()](/api/corvus-text-json-jsonelement.enumeratearray.html#arrayenumerator-jsonelement-enumeratearray) | Get an enumerator to enumerate the values in the JSON array represented by this JsonElement. |
| [EnumerateObject()](/api/corvus-text-json-jsonelement.enumerateobject.html#objectenumerator-jsonelement-enumerateobject) | Get an enumerator to enumerate the properties in the JSON object represented by this JsonElement. |
| [Equals(object)](/api/corvus-text-json-jsonelement.equals.html#bool-equals-object-obj) | Determines whether the specified object is equal to the current JsonElement. |
| [Equals(T)](/api/corvus-text-json-jsonelement.equals.html#bool-equals-t-t-other) | Determines whether the current JsonElement is equal to another JsonElement-like value through deep comparison. |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelement.evaluateschema.html#bool-evaluateschema-ijsonschemaresultscollector-resultscollector) | Evaluates the JSON Schema for this element. |
| [From(ref T)](/api/corvus-text-json-jsonelement.from.html#jsonelement-from-t-ref-t-instance) `static` |  |
| [GetArrayLength()](/api/corvus-text-json-jsonelement.getarraylength.html#int-getarraylength) | Get the number of values contained within the current array value. |
| [GetBigInteger()](/api/corvus-text-json-jsonelement.getbiginteger.html#biginteger-getbiginteger) | Gets the current JSON number as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [GetBigNumber()](/api/corvus-text-json-jsonelement.getbignumber.html#bignumber-getbignumber) | Gets the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [GetBoolean()](/api/corvus-text-json-jsonelement.getboolean.html#bool-getboolean) | Gets the value of the element as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean). |
| [GetByte()](/api/corvus-text-json-jsonelement.getbyte.html#byte-getbyte) | Gets the current JSON number as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [GetBytesFromBase64()](/api/corvus-text-json-jsonelement.getbytesfrombase64.html#byte-getbytesfrombase64) | Gets the value of the element as bytes. |
| [GetDateTime()](/api/corvus-text-json-jsonelement.getdatetime.html#datetime-getdatetime) | Gets the value of the element as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [GetDateTimeOffset()](/api/corvus-text-json-jsonelement.getdatetimeoffset.html#datetimeoffset-getdatetimeoffset) | Gets the value of the element as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [GetDecimal()](/api/corvus-text-json-jsonelement.getdecimal.html#decimal-getdecimal) | Gets the current JSON number as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [GetDouble()](/api/corvus-text-json-jsonelement.getdouble.html#double-getdouble) | Gets the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [GetGuid()](/api/corvus-text-json-jsonelement.getguid.html#guid-getguid) | Gets the value of the element as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [GetHashCode()](/api/corvus-text-json-jsonelement.gethashcode.html#int-gethashcode) |  |
| [GetInt16()](/api/corvus-text-json-jsonelement.getint16.html#short-getint16) | Gets the current JSON number as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [GetInt32()](/api/corvus-text-json-jsonelement.getint32.html#int-getint32) | Gets the current JSON number as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [GetInt64()](/api/corvus-text-json-jsonelement.getint64.html#long-getint64) | Gets the current JSON number as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [GetLocalDate()](/api/corvus-text-json-jsonelement.getlocaldate.html#localdate-getlocaldate) | Gets the value of the element as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [GetOffsetDate()](/api/corvus-text-json-jsonelement.getoffsetdate.html#offsetdate-getoffsetdate) | Gets the value of the element as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [GetOffsetDateTime()](/api/corvus-text-json-jsonelement.getoffsetdatetime.html#offsetdatetime-getoffsetdatetime) | Gets the value of the element as a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [GetOffsetTime()](/api/corvus-text-json-jsonelement.getoffsettime.html#offsettime-getoffsettime) | Gets the value of the element as a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [GetPeriod()](/api/corvus-text-json-jsonelement.getperiod.html#period-getperiod) | Gets the value of the element as a [`Period`](/api/corvus-text-json-period.html). |
| [GetProperty(string)](/api/corvus-text-json-jsonelement.getproperty.html#jsonelement-getproperty-string-propertyname) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`. |
| [GetProperty(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement.getproperty.html#jsonelement-getproperty-readonlyspan-char-propertyname) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`. |
| [GetProperty(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement.getproperty.html#jsonelement-getproperty-readonlyspan-byte-utf8propertyname) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `utf8PropertyName`. |
| [GetPropertyCount()](/api/corvus-text-json-jsonelement.getpropertycount.html#int-getpropertycount) | Get the number of properties contained within the current object value. |
| [GetRawText()](/api/corvus-text-json-jsonelement.getrawtext.html#string-getrawtext) | Gets the original input data backing this value, returning it as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetSByte()](/api/corvus-text-json-jsonelement.getsbyte.html#sbyte-getsbyte) | Gets the current JSON number as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [GetSingle()](/api/corvus-text-json-jsonelement.getsingle.html#float-getsingle) | Gets the current JSON number as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [GetString()](/api/corvus-text-json-jsonelement.getstring.html#string-getstring) | Gets the value of the element as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetUInt16()](/api/corvus-text-json-jsonelement.getuint16.html#ushort-getuint16) | Gets the current JSON number as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [GetUInt32()](/api/corvus-text-json-jsonelement.getuint32.html#uint-getuint32) | Gets the current JSON number as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [GetUInt64()](/api/corvus-text-json-jsonelement.getuint64.html#ulong-getuint64) | Gets the current JSON number as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [GetUtf16String()](/api/corvus-text-json-jsonelement.getutf16string.html#unescapedutf16jsonstring-getutf16string) | Gets the value of the element as a [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html). |
| [GetUtf8String()](/api/corvus-text-json-jsonelement.getutf8string.html#unescapedutf8jsonstring-getutf8string) | Gets the value of the element as a [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html). |
| [ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions)](/api/corvus-text-json-jsonelement.parsevalue.html#jsonelement-parsevalue-readonlyspan-byte-utf8json-jsondocumentoptions-options) `static` | Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions)](/api/corvus-text-json-jsonelement.parsevalue.html#jsonelement-parsevalue-readonlyspan-char-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(string, JsonDocumentOptions)](/api/corvus-text-json-jsonelement.parsevalue.html#jsonelement-parsevalue-string-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ref Utf8JsonReader)](/api/corvus-text-json-jsonelement.parsevalue.html#jsonelement-parsevalue-ref-utf8jsonreader-reader) `static` | Parses one JSON value (including objects or arrays) from the provided reader. |
| [ToString()](/api/corvus-text-json-jsonelement.tostring.html#string-tostring) | Gets a string representation for the current value appropriate to the value type. |
| [ToString(string, IFormatProvider)](/api/corvus-text-json-jsonelement.tostring.html#string-tostring-string-format-iformatprovider-formatprovider) |  |
| [TryFormat(Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement.tryformat.html#bool-tryformat-span-char-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryFormat(Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-jsonelement.tryformat.html#bool-tryformat-span-byte-utf8destination-ref-int-byteswritten-readonlyspan-char-format-iformatprovider-provider) |  |
| [TryGetBigInteger(ref BigInteger)](/api/corvus-text-json-jsonelement.trygetbiginteger.html#bool-trygetbiginteger-ref-biginteger-value) | Attempts to represent the current JSON number as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetBigNumber(ref BigNumber)](/api/corvus-text-json-jsonelement.trygetbignumber.html#bool-trygetbignumber-ref-bignumber-value) | Attempts to represent the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetBoolean(ref bool)](/api/corvus-text-json-jsonelement.trygetboolean.html#bool-trygetboolean-ref-bool-value) | Tries to get the value as a boolean |
| [TryGetByte(ref byte)](/api/corvus-text-json-jsonelement.trygetbyte.html#bool-trygetbyte-ref-byte-value) | Attempts to represent the current JSON number as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetBytesFromBase64(ref byte\[\])](/api/corvus-text-json-jsonelement.trygetbytesfrombase64.html#bool-trygetbytesfrombase64-ref-byte-value) | Attempts to represent the current JSON string as bytes assuming it is Base64 encoded. |
| [TryGetDateTime(ref DateTime)](/api/corvus-text-json-jsonelement.trygetdatetime.html#bool-trygetdatetime-ref-datetime-value) | Attempts to represent the current JSON string as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetDateTimeOffset(ref DateTimeOffset)](/api/corvus-text-json-jsonelement.trygetdatetimeoffset.html#bool-trygetdatetimeoffset-ref-datetimeoffset-value) | Attempts to represent the current JSON string as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetDecimal(ref decimal)](/api/corvus-text-json-jsonelement.trygetdecimal.html#bool-trygetdecimal-ref-decimal-value) | Attempts to represent the current JSON number as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetDouble(ref double)](/api/corvus-text-json-jsonelement.trygetdouble.html#bool-trygetdouble-ref-double-value) | Attempts to represent the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetGuid(ref Guid)](/api/corvus-text-json-jsonelement.trygetguid.html#bool-trygetguid-ref-guid-value) | Attempts to represent the current JSON string as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetInt16(ref short)](/api/corvus-text-json-jsonelement.trygetint16.html#bool-trygetint16-ref-short-value) | Attempts to represent the current JSON number as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetInt32(ref int)](/api/corvus-text-json-jsonelement.trygetint32.html#bool-trygetint32-ref-int-value) | Attempts to represent the current JSON number as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetInt64(ref long)](/api/corvus-text-json-jsonelement.trygetint64.html#bool-trygetint64-ref-long-value) | Attempts to represent the current JSON number as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetLine(int, ref ReadOnlyMemory&lt;byte&gt;)](/api/corvus-text-json-jsonelement.trygetline.html#bool-trygetline-int-linenumber-ref-readonlymemory-byte-line) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLine(int, ref string)](/api/corvus-text-json-jsonelement.trygetline.html#bool-trygetline-int-linenumber-ref-string-line) | Tries to get the specified line from the original source document as a string. |
| [TryGetLineAndOffset(ref int, ref int)](/api/corvus-text-json-jsonelement.trygetlineandoffset.html#bool-trygetlineandoffset-ref-int-line-ref-int-charoffset) | Tries to get the 1-based line number and character offset of this element in the original source document. |
| [TryGetLineAndOffset(ref int, ref int, ref long)](/api/corvus-text-json-jsonelement.trygetlineandoffset.html#bool-trygetlineandoffset-ref-int-line-ref-int-charoffset-ref-long-linebyteoffset) | Tries to get the 1-based line number, character offset, and byte offset of this element in the original source document. |
| [TryGetLocalDate(ref LocalDate)](/api/corvus-text-json-jsonelement.trygetlocaldate.html#bool-trygetlocaldate-ref-localdate-value) | Attempts to represent the current JSON string as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetOffsetDate(ref OffsetDate)](/api/corvus-text-json-jsonelement.trygetoffsetdate.html#bool-trygetoffsetdate-ref-offsetdate-value) | Attempts to represent the current JSON string as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetOffsetDateTime(ref OffsetDateTime)](/api/corvus-text-json-jsonelement.trygetoffsetdatetime.html#bool-trygetoffsetdatetime-ref-offsetdatetime-value) | Attempts to represent the current JSON string as a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetOffsetTime(ref OffsetTime)](/api/corvus-text-json-jsonelement.trygetoffsettime.html#bool-trygetoffsettime-ref-offsettime-value) | Attempts to represent the current JSON string as a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetPeriod(ref Period)](/api/corvus-text-json-jsonelement.trygetperiod.html#bool-trygetperiod-ref-period-value) | Attempts to represent the current JSON string as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetProperty(string, ref JsonElement)](/api/corvus-text-json-jsonelement.trygetproperty.html#bool-trygetproperty-string-propertyname-ref-jsonelement-value) | Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement)](/api/corvus-text-json-jsonelement.trygetproperty.html#bool-trygetproperty-readonlyspan-char-propertyname-ref-jsonelement-value) | Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement)](/api/corvus-text-json-jsonelement.trygetproperty.html#bool-trygetproperty-readonlyspan-byte-utf8propertyname-ref-jsonelement-value) | Looks for a property named `utf8PropertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetSByte(ref sbyte)](/api/corvus-text-json-jsonelement.trygetsbyte.html#bool-trygetsbyte-ref-sbyte-value) | Attempts to represent the current JSON number as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetSingle(ref float)](/api/corvus-text-json-jsonelement.trygetsingle.html#bool-trygetsingle-ref-float-value) | Attempts to represent the current JSON number as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetUInt16(ref ushort)](/api/corvus-text-json-jsonelement.trygetuint16.html#bool-trygetuint16-ref-ushort-value) | Attempts to represent the current JSON number as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetUInt32(ref uint)](/api/corvus-text-json-jsonelement.trygetuint32.html#bool-trygetuint32-ref-uint-value) | Attempts to represent the current JSON number as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetUInt64(ref ulong)](/api/corvus-text-json-jsonelement.trygetuint64.html#bool-trygetuint64-ref-ulong-value) | Attempts to represent the current JSON number as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryParseValue(ref Utf8JsonReader, ref Nullable&lt;JsonElement&gt;)](/api/corvus-text-json-jsonelement.tryparsevalue.html#bool-tryparsevalue-ref-utf8jsonreader-reader-ref-nullable-jsonelement-element) `static` |  |
| [ValueEquals(string)](/api/corvus-text-json-jsonelement.valueequals.html#bool-valueequals-string-text) | Compares `text` to the string value of this element. |
| [ValueEquals(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-jsonelement.valueequals.html#bool-valueequals-readonlyspan-byte-utf8text) | Compares the text represented by `utf8Text` to the string value of this element. |
| [ValueEquals(ReadOnlySpan&lt;char&gt;)](/api/corvus-text-json-jsonelement.valueequals.html#bool-valueequals-readonlyspan-char-text) | Compares `text` to the string value of this element. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelement.writeto.html#void-writeto-utf8jsonwriter-writer) | Write the element into the provided writer as a JSON value. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator ==(JsonElement, JsonElement)](/api/corvus-text-json-jsonelement.op-equality.html#static-bool-operator-jsonelement-left-jsonelement-right) | Compares two JsonElement values for equality. |
| [operator !=(JsonElement, JsonElement)](/api/corvus-text-json-jsonelement.op-inequality.html#static-bool-operator-jsonelement-left-jsonelement-right) | Compares two JsonElement values for inequality. |

