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
| [Item\[...\]](/api/corvus-text-json-jsonelement.item.html) | | Get the value at a specified index when the current value is a [`Array`](/api/corvus-text-json-jsonvaluekind.html#array). |
| [ValueKind](/api/corvus-text-json-jsonelement.valuekind.html) | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is. |

## Methods

| Method | Description |
|--------|-------------|
| [Clone()](/api/corvus-text-json-jsonelement.clone.html#clone) | Get a JsonElement which can be safely stored beyond the lifetime of the original [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html). |
| [CreateArrayBuilder(JsonWorkspace, int)](/api/corvus-text-json-jsonelement.createarraybuilder.html#createarraybuilder-jsonworkspace-int) `static` | Creates an empty mutable array document builder. |
| [CreateBuilder](/api/corvus-text-json-jsonelement.createbuilder.html) `static` |  |
| [CreateObjectBuilder(JsonWorkspace, int)](/api/corvus-text-json-jsonelement.createobjectbuilder.html#createobjectbuilder-jsonworkspace-int) `static` | Creates an empty mutable object document builder. |
| [EnsurePropertyMap()](/api/corvus-text-json-jsonelement.ensurepropertymap.html#ensurepropertymap) | Ensures that a fast-lookup property map is created for this element. |
| [EnumerateArray()](/api/corvus-text-json-jsonelement.enumeratearray.html#enumeratearray) | Get an enumerator to enumerate the values in the JSON array represented by this JsonElement. |
| [EnumerateObject()](/api/corvus-text-json-jsonelement.enumerateobject.html#enumerateobject) | Get an enumerator to enumerate the properties in the JSON object represented by this JsonElement. |
| [Equals](/api/corvus-text-json-jsonelement.equals.html) | Determines whether the specified object is equal to the current JsonElement. |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelement.evaluateschema.html#evaluateschema-ijsonschemaresultscollector) | Evaluates the JSON Schema for this element. |
| [From(ref T)](/api/corvus-text-json-jsonelement.from.html#from-ref-t) `static` |  |
| [GetArrayLength()](/api/corvus-text-json-jsonelement.getarraylength.html#getarraylength) | Get the number of values contained within the current array value. |
| [GetBigInteger()](/api/corvus-text-json-jsonelement.getbiginteger.html#getbiginteger) | Gets the current JSON number as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [GetBigNumber()](/api/corvus-text-json-jsonelement.getbignumber.html#getbignumber) | Gets the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [GetBoolean()](/api/corvus-text-json-jsonelement.getboolean.html#getboolean) | Gets the value of the element as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean). |
| [GetByte()](/api/corvus-text-json-jsonelement.getbyte.html#getbyte) | Gets the current JSON number as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [GetBytesFromBase64()](/api/corvus-text-json-jsonelement.getbytesfrombase64.html#getbytesfrombase64) | Gets the value of the element as bytes. |
| [GetDateTime()](/api/corvus-text-json-jsonelement.getdatetime.html#getdatetime) | Gets the value of the element as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [GetDateTimeOffset()](/api/corvus-text-json-jsonelement.getdatetimeoffset.html#getdatetimeoffset) | Gets the value of the element as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [GetDecimal()](/api/corvus-text-json-jsonelement.getdecimal.html#getdecimal) | Gets the current JSON number as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [GetDouble()](/api/corvus-text-json-jsonelement.getdouble.html#getdouble) | Gets the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [GetGuid()](/api/corvus-text-json-jsonelement.getguid.html#getguid) | Gets the value of the element as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [GetHashCode()](/api/corvus-text-json-jsonelement.gethashcode.html#gethashcode) |  |
| [GetInt16()](/api/corvus-text-json-jsonelement.getint16.html#getint16) | Gets the current JSON number as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [GetInt32()](/api/corvus-text-json-jsonelement.getint32.html#getint32) | Gets the current JSON number as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [GetInt64()](/api/corvus-text-json-jsonelement.getint64.html#getint64) | Gets the current JSON number as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [GetLocalDate()](/api/corvus-text-json-jsonelement.getlocaldate.html#getlocaldate) | Gets the value of the element as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [GetOffsetDate()](/api/corvus-text-json-jsonelement.getoffsetdate.html#getoffsetdate) | Gets the value of the element as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [GetOffsetDateTime()](/api/corvus-text-json-jsonelement.getoffsetdatetime.html#getoffsetdatetime) | Gets the value of the element as a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [GetOffsetTime()](/api/corvus-text-json-jsonelement.getoffsettime.html#getoffsettime) | Gets the value of the element as a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [GetPeriod()](/api/corvus-text-json-jsonelement.getperiod.html#getperiod) | Gets the value of the element as a [`Period`](/api/corvus-text-json-period.html). |
| [GetProperty](/api/corvus-text-json-jsonelement.getproperty.html) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`. |
| [GetPropertyCount()](/api/corvus-text-json-jsonelement.getpropertycount.html#getpropertycount) | Get the number of properties contained within the current object value. |
| [GetRawText()](/api/corvus-text-json-jsonelement.getrawtext.html#getrawtext) | Gets the original input data backing this value, returning it as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetSByte()](/api/corvus-text-json-jsonelement.getsbyte.html#getsbyte) | Gets the current JSON number as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [GetSingle()](/api/corvus-text-json-jsonelement.getsingle.html#getsingle) | Gets the current JSON number as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [GetString()](/api/corvus-text-json-jsonelement.getstring.html#getstring) | Gets the value of the element as a [`String`](https://learn.microsoft.com/dotnet/api/system.string). |
| [GetUInt16()](/api/corvus-text-json-jsonelement.getuint16.html#getuint16) | Gets the current JSON number as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [GetUInt32()](/api/corvus-text-json-jsonelement.getuint32.html#getuint32) | Gets the current JSON number as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [GetUInt64()](/api/corvus-text-json-jsonelement.getuint64.html#getuint64) | Gets the current JSON number as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [GetUtf16String()](/api/corvus-text-json-jsonelement.getutf16string.html#getutf16string) | Gets the value of the element as a [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html). |
| [GetUtf8String()](/api/corvus-text-json-jsonelement.getutf8string.html#getutf8string) | Gets the value of the element as a [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html). |
| [ParseValue](/api/corvus-text-json-jsonelement.parsevalue.html) `static` | Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ToString](/api/corvus-text-json-jsonelement.tostring.html) | Gets a string representation for the current value appropriate to the value type. |
| [TryFormat](/api/corvus-text-json-jsonelement.tryformat.html) |  |
| [TryGetBigInteger(ref BigInteger)](/api/corvus-text-json-jsonelement.trygetbiginteger.html#trygetbiginteger-ref-biginteger) | Attempts to represent the current JSON number as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetBigNumber(ref BigNumber)](/api/corvus-text-json-jsonelement.trygetbignumber.html#trygetbignumber-ref-bignumber) | Attempts to represent the current JSON number as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetBoolean(ref bool)](/api/corvus-text-json-jsonelement.trygetboolean.html#trygetboolean-ref-bool) | Tries to get the value as a boolean |
| [TryGetByte(ref byte)](/api/corvus-text-json-jsonelement.trygetbyte.html#trygetbyte-ref-byte) | Attempts to represent the current JSON number as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetBytesFromBase64(ref byte\[\])](/api/corvus-text-json-jsonelement.trygetbytesfrombase64.html#trygetbytesfrombase64-ref-byte) | Attempts to represent the current JSON string as bytes assuming it is Base64 encoded. |
| [TryGetDateTime(ref DateTime)](/api/corvus-text-json-jsonelement.trygetdatetime.html#trygetdatetime-ref-datetime) | Attempts to represent the current JSON string as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetDateTimeOffset(ref DateTimeOffset)](/api/corvus-text-json-jsonelement.trygetdatetimeoffset.html#trygetdatetimeoffset-ref-datetimeoffset) | Attempts to represent the current JSON string as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetDecimal(ref decimal)](/api/corvus-text-json-jsonelement.trygetdecimal.html#trygetdecimal-ref-decimal) | Attempts to represent the current JSON number as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetDouble(ref double)](/api/corvus-text-json-jsonelement.trygetdouble.html#trygetdouble-ref-double) | Attempts to represent the current JSON number as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetGuid(ref Guid)](/api/corvus-text-json-jsonelement.trygetguid.html#trygetguid-ref-guid) | Attempts to represent the current JSON string as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetInt16(ref short)](/api/corvus-text-json-jsonelement.trygetint16.html#trygetint16-ref-short) | Attempts to represent the current JSON number as an [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetInt32(ref int)](/api/corvus-text-json-jsonelement.trygetint32.html#trygetint32-ref-int) | Attempts to represent the current JSON number as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetInt64(ref long)](/api/corvus-text-json-jsonelement.trygetint64.html#trygetint64-ref-long) | Attempts to represent the current JSON number as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetLine](/api/corvus-text-json-jsonelement.trygetline.html) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLineAndOffset](/api/corvus-text-json-jsonelement.trygetlineandoffset.html) | Tries to get the 1-based line number and character offset of this element in the original source document. |
| [TryGetLocalDate(ref LocalDate)](/api/corvus-text-json-jsonelement.trygetlocaldate.html#trygetlocaldate-ref-localdate) | Attempts to represent the current JSON string as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetOffsetDate(ref OffsetDate)](/api/corvus-text-json-jsonelement.trygetoffsetdate.html#trygetoffsetdate-ref-offsetdate) | Attempts to represent the current JSON string as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetOffsetDateTime(ref OffsetDateTime)](/api/corvus-text-json-jsonelement.trygetoffsetdatetime.html#trygetoffsetdatetime-ref-offsetdatetime) | Attempts to represent the current JSON string as a [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetOffsetTime(ref OffsetTime)](/api/corvus-text-json-jsonelement.trygetoffsettime.html#trygetoffsettime-ref-offsettime) | Attempts to represent the current JSON string as a [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetPeriod(ref Period)](/api/corvus-text-json-jsonelement.trygetperiod.html#trygetperiod-ref-period) | Attempts to represent the current JSON string as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetProperty](/api/corvus-text-json-jsonelement.trygetproperty.html) | Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetSByte(ref sbyte)](/api/corvus-text-json-jsonelement.trygetsbyte.html#trygetsbyte-ref-sbyte) | Attempts to represent the current JSON number as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetSingle(ref float)](/api/corvus-text-json-jsonelement.trygetsingle.html#trygetsingle-ref-float) | Attempts to represent the current JSON number as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetUInt16(ref ushort)](/api/corvus-text-json-jsonelement.trygetuint16.html#trygetuint16-ref-ushort) | Attempts to represent the current JSON number as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetUInt32(ref uint)](/api/corvus-text-json-jsonelement.trygetuint32.html#trygetuint32-ref-uint) | Attempts to represent the current JSON number as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetUInt64(ref ulong)](/api/corvus-text-json-jsonelement.trygetuint64.html#trygetuint64-ref-ulong) | Attempts to represent the current JSON number as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryParseValue(ref Utf8JsonReader, ref Nullable&lt;JsonElement&gt;)](/api/corvus-text-json-jsonelement.tryparsevalue.html#tryparsevalue-ref-utf8jsonreader-ref-nullable-jsonelement) `static` |  |
| [ValueEquals](/api/corvus-text-json-jsonelement.valueequals.html) | Compares `text` to the string value of this element. |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelement.writeto.html#writeto-utf8jsonwriter) | Write the element into the provided writer as a JSON value. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator ==(JsonElement, JsonElement)](/api/corvus-text-json-jsonelement.op-equality.html#operator-jsonelement-jsonelement) | Compares two JsonElement values for equality. |
| [operator !=(JsonElement, JsonElement)](/api/corvus-text-json-jsonelement.op-inequality.html#operator-jsonelement-jsonelement) | Compares two JsonElement values for inequality. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

