---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument — Corvus.Text.Json.Internal"
---
```csharp
public interface IJsonDocument : IDisposable
```

The interface explicitly implemented by JSON Document providers for internal use only.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Implemented By

[`FixedStringJsonDocument<T>`](/api/corvus-text-json-internal-fixedstringjsondocument-t.html), [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html), [`JsonDocumentBuilder<T>`](/api/corvus-text-json-jsondocumentbuilder-t.html), [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsDisposable](/api/corvus-text-json-internal-ijsondocument.isdisposable.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the document is disposable. |
| [IsImmutable](/api/corvus-text-json-internal-ijsondocument.isimmutable.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the document is immutable. |

## Methods

| Method | Description |
|--------|-------------|
| [AppendElementToMetadataDb(int, JsonWorkspace, ref MetadataDb)](/api/corvus-text-json-internal-ijsondocument.appendelementtometadatadb.html#appendelementtometadatadb-int-jsonworkspace-ref-metadatadb) | Appends the element at the specified index to the metadata database. |
| [BuildRentedMetadataDb(int, JsonWorkspace, ref byte\[\])](/api/corvus-text-json-internal-ijsondocument.buildrentedmetadatadb.html#buildrentedmetadatadb-int-jsonworkspace-ref-byte) | Builds a rented metadata database for the specified parent document index. |
| [CloneElement(int)](/api/corvus-text-json-internal-ijsondocument.cloneelement.html#cloneelement-int) | Clones the element at the specified index. |
| [CloneElement(int)](/api/corvus-text-json-internal-ijsondocument.cloneelement.html#cloneelement-int) | Clones the element at the specified index. |
| [EnsurePropertyMap(int)](/api/corvus-text-json-internal-ijsondocument.ensurepropertymap.html#ensurepropertymap-int) | Ensures the property map is available for the specified index. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#getarrayindexelement-int-int) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#getarrayindexelement-int-int) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#getarrayindexelement-int-int-ref-ijsondocument-ref-int) | Gets the element at the specified array index within the current index. |
| [GetArrayInsertionIndex(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayinsertionindex.html#getarrayinsertionindex-int-int) | Gets DB index of the item at the array index within the array that starts at `currentIndex`. |
| [GetArrayLength(int)](/api/corvus-text-json-internal-ijsondocument.getarraylength.html#getarraylength-int) | Gets the length of the array at the specified index. |
| [GetDbSize(int, bool)](/api/corvus-text-json-internal-ijsondocument.getdbsize.html#getdbsize-int-bool) | Gets the size of the database for the element at the specified index. |
| [GetHashCode(int)](/api/corvus-text-json-internal-ijsondocument.gethashcode.html#gethashcode-int) | Gets the hash code for the specified index. |
| [GetJsonTokenType(int)](/api/corvus-text-json-internal-ijsondocument.getjsontokentype.html#getjsontokentype-int) | Gets the JSON token type for the specified index. |
| [GetNameOfPropertyValue(int)](/api/corvus-text-json-internal-ijsondocument.getnameofpropertyvalue.html#getnameofpropertyvalue-int) | Gets the name of the property value at the specified index. |
| [GetPropertyCount(int)](/api/corvus-text-json-internal-ijsondocument.getpropertycount.html#getpropertycount-int) | Gets the number of properties for the element at the specified index. |
| [GetPropertyName(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyname.html#getpropertyname-int) | Gets the property name as a JSON element. |
| [GetPropertyNameRaw(int)](/api/corvus-text-json-internal-ijsondocument.getpropertynameraw.html#getpropertynameraw-int) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameRaw(int, bool)](/api/corvus-text-json-internal-ijsondocument.getpropertynameraw.html#getpropertynameraw-int-bool) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameUnescaped(int)](/api/corvus-text-json-internal-ijsondocument.getpropertynameunescaped.html#getpropertynameunescaped-int) | Gets the property name as a JSON element. |
| [GetPropertyRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyrawvalueasstring.html#getpropertyrawvalueasstring-int) | Gets the raw value of the property at the specified index as a string. |
| [GetRawSimpleValue(int, bool)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalue.html#getrawsimplevalue-int-bool) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValue(int)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalue.html#getrawsimplevalue-int) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValueUnsafe(int)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalueunsafe.html#getrawsimplevalueunsafe-int) | Gets the raw simple value of the element at the specified index, without checking if the document has been disposed. |
| [GetRawValue(int, bool)](/api/corvus-text-json-internal-ijsondocument.getrawvalue.html#getrawvalue-int-bool) | Gets the raw value of the element at the specified index. |
| [GetRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getrawvalueasstring.html#getrawvalueasstring-int) | Gets the raw value of the element at the specified index as a string. |
| [GetStartIndex(int)](/api/corvus-text-json-internal-ijsondocument.getstartindex.html#getstartindex-int) | Gets the start index of the element from the end index. |
| [GetString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getstring.html#getstring-int-jsontokentype) | Gets the string value of the element at the specified index. |
| [GetUtf16JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf16jsonstring.html#getutf16jsonstring-int-jsontokentype) | Gets the UTF-16 JSON string value of the element at the specified index. |
| [GetUtf8JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf8jsonstring.html#getutf8jsonstring-int-jsontokentype) | Gets the UTF-8 JSON string value of the element at the specified index. |
| [TextEquals(int, ReadOnlySpan&lt;char&gt;, bool)](/api/corvus-text-json-internal-ijsondocument.textequals.html#textequals-int-readonlyspan-char-bool) | Determines whether the text at the specified index equals the specified text. |
| [TextEquals(int, ReadOnlySpan&lt;byte&gt;, bool, bool)](/api/corvus-text-json-internal-ijsondocument.textequals.html#textequals-int-readonlyspan-byte-bool-bool) | Determines whether the UTF-8 text at the specified index equals the specified text. |
| [ToString(int)](/api/corvus-text-json-internal-ijsondocument.tostring.html#tostring-int) | Converts the element at the specified index to a string. |
| [ToString(int, string, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tostring.html#tostring-int-string-iformatprovider) | Gets the display string representation of the element at the specified index according to the specified format and format provider. |
| [TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tryformat.html#tryformat-int-span-char-ref-int-readonlyspan-char-iformatprovider) | Formats the value to the provided destination span according to the specified format and format provider. |
| [TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tryformat.html#tryformat-int-span-byte-ref-int-readonlyspan-char-iformatprovider) | Formats the value to the provided destination UTF-8 span according to the specified format and format provider. |
| [TryGetLine(int, ref ReadOnlyMemory&lt;byte&gt;)](/api/corvus-text-json-internal-ijsondocument.trygetline.html#trygetline-int-ref-readonlymemory-byte) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLine(int, ref string)](/api/corvus-text-json-internal-ijsondocument.trygetline.html#trygetline-int-ref-string) | Tries to get the specified line from the original source document as a string. |
| [TryGetLineAndOffset(int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffset.html#trygetlineandoffset-int-ref-int-ref-int-ref-long) | Tries to get the line number and character offset in the original source document for the element at the specified index. |
| [TryGetLineAndOffsetForPointer(ReadOnlySpan&lt;byte&gt;, int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffsetforpointer.html#trygetlineandoffsetforpointer-readonlyspan-byte-int-ref-int-ref-int-ref-long) | Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref TElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-telement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref TElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-char-ref-telement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-char-ref-ijsondocument-ref-int) | Tries to get the value of a named property as a mutable JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-ijsondocument-ref-int) | Tries to get the value of a named property as a mutable JSON element. |
| [TryGetString(int, JsonTokenType, ref string)](/api/corvus-text-json-internal-ijsondocument.trygetstring.html#trygetstring-int-jsontokentype-ref-string) | Tries to get the string value of the element at the specified index. |
| [TryGetValue(int, ref byte\[\])](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-byte) | Tries to get the value of the element at the specified index as a byte array. |
| [TryGetValue(int, ref sbyte)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-sbyte) | Tries to get the value of the element at the specified index as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetValue(int, ref byte)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-byte) | Tries to get the value of the element at the specified index as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetValue(int, ref short)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-short) | Tries to get the value of the element at the specified index as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetValue(int, ref ushort)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-ushort) | Tries to get the value of the element at the specified index as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetValue(int, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-int) | Tries to get the value of the element at the specified index as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetValue(int, ref uint)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-uint) | Tries to get the value of the element at the specified index as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetValue(int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-long) | Tries to get the value of the element at the specified index as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetValue(int, ref ulong)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-ulong) | Tries to get the value of the element at the specified index as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryGetValue(int, ref double)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-double) | Tries to get the value of the element at the specified index as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetValue(int, ref float)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-float) | Tries to get the value of the element at the specified index as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetValue(int, ref decimal)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-decimal) | Tries to get the value of the element at the specified index as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetValue(int, ref BigInteger)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-biginteger) | Tries to get the value of the element at the specified index as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetValue(int, ref BigNumber)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-bignumber) | Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetValue(int, ref DateTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-datetime) | Tries to get the value of the element at the specified index as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetValue(int, ref DateTimeOffset)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-datetimeoffset) | Tries to get the value of the element at the specified index as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetValue(int, ref OffsetDateTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-offsetdatetime) | Tries to get the value of the element at the specified index as an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetValue(int, ref OffsetDate)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-offsetdate) | Tries to get the value of the element at the specified index as an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetValue(int, ref OffsetTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-offsettime) | Tries to get the value of the element at the specified index as an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetValue(int, ref LocalDate)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-localdate) | Tries to get the value of the element at the specified index as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetValue(int, ref Period)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-period) | Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetValue(int, ref Guid)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-guid) | Tries to get the value of the element at the specified index as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetValue(int, ref Int128)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-int128) | Tries to get the value of the element at the specified index as an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128). |
| [TryGetValue(int, ref UInt128)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-uint128) | Tries to get the value of the element at the specified index as a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128). |
| [TryGetValue(int, ref Half)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-half) | Tries to get the value of the element at the specified index as a [`Half`](https://learn.microsoft.com/dotnet/api/system.half). |
| [TryGetValue(int, ref DateOnly)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-dateonly) | Tries to get the value of the element at the specified index as a [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly). |
| [TryGetValue(int, ref TimeOnly)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#trygetvalue-int-ref-timeonly) | Tries to get the value of the element at the specified index as a [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly). |
| [TryResolveJsonPointer(ReadOnlySpan&lt;byte&gt;, int, ref TValue)](/api/corvus-text-json-internal-ijsondocument.tryresolvejsonpointer.html#tryresolvejsonpointer-readonlyspan-byte-int-ref-tvalue) | Try to resolve the given JSON pointer. |
| [ValueIsEscaped(int, bool)](/api/corvus-text-json-internal-ijsondocument.valueisescaped.html#valueisescaped-int-bool) | Determines whether the value at the specified index is escaped. |
| [WriteElementTo(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writeelementto.html#writeelementto-int-utf8jsonwriter) | Writes the element at the specified index to the provided JSON writer. |
| [WritePropertyName(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writepropertyname.html#writepropertyname-int-utf8jsonwriter) | Writes the property name at the specified index to the provided JSON writer. |

