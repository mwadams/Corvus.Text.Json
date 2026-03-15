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
| [AppendElementToMetadataDb(int, JsonWorkspace, ref MetadataDb)](/api/corvus-text-json-internal-ijsondocument.appendelementtometadatadb.html#void-appendelementtometadatadb-int-index-jsonworkspace-workspace-ref-metadatadb-db) | Appends the element at the specified index to the metadata database. |
| [BuildRentedMetadataDb(int, JsonWorkspace, ref byte\[\])](/api/corvus-text-json-internal-ijsondocument.buildrentedmetadatadb.html#int-buildrentedmetadatadb-int-parentdocumentindex-jsonworkspace-workspace-ref-byte-rentedbacking) | Builds a rented metadata database for the specified parent document index. |
| [CloneElement(int)](/api/corvus-text-json-internal-ijsondocument.cloneelement.html#jsonelement-cloneelement-int-index) | Clones the element at the specified index. |
| [CloneElement(int)](/api/corvus-text-json-internal-ijsondocument.cloneelement.html#telement-cloneelement-telement-int-index) | Clones the element at the specified index. |
| [EnsurePropertyMap(int)](/api/corvus-text-json-internal-ijsondocument.ensurepropertymap.html#void-ensurepropertymap-int-index) | Ensures the property map is available for the specified index. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#jsonelement-getarrayindexelement-int-currentindex-int-arrayindex) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#telement-getarrayindexelement-telement-int-currentindex-int-arrayindex) | Gets the element at the specified array index within the current index. |
| [GetArrayIndexElement(int, int, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html#void-getarrayindexelement-int-currentindex-int-arrayindex-ref-ijsondocument-parentdocument-ref-int-parentdocumentindex) | Gets the element at the specified array index within the current index. |
| [GetArrayInsertionIndex(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayinsertionindex.html#int-getarrayinsertionindex-int-currentindex-int-arrayindex) | Gets DB index of the item at the array index within the array that starts at `currentIndex`. |
| [GetArrayLength(int)](/api/corvus-text-json-internal-ijsondocument.getarraylength.html#int-getarraylength-int-index) | Gets the length of the array at the specified index. |
| [GetDbSize(int, bool)](/api/corvus-text-json-internal-ijsondocument.getdbsize.html#int-getdbsize-int-index-bool-includeendelement) | Gets the size of the database for the element at the specified index. |
| [GetHashCode(int)](/api/corvus-text-json-internal-ijsondocument.gethashcode.html#int-gethashcode-int-index) | Gets the hash code for the specified index. |
| [GetJsonTokenType(int)](/api/corvus-text-json-internal-ijsondocument.getjsontokentype.html#jsontokentype-getjsontokentype-int-index) | Gets the JSON token type for the specified index. |
| [GetNameOfPropertyValue(int)](/api/corvus-text-json-internal-ijsondocument.getnameofpropertyvalue.html#string-getnameofpropertyvalue-int-index) | Gets the name of the property value at the specified index. |
| [GetPropertyCount(int)](/api/corvus-text-json-internal-ijsondocument.getpropertycount.html#int-getpropertycount-int-index) | Gets the number of properties for the element at the specified index. |
| [GetPropertyName(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyname.html#jsonelement-getpropertyname-int-index) | Gets the property name as a JSON element. |
| [GetPropertyNameRaw(int)](/api/corvus-text-json-internal-ijsondocument.getpropertynameraw.html#readonlyspan-byte-getpropertynameraw-int-index) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameRaw(int, bool)](/api/corvus-text-json-internal-ijsondocument.getpropertynameraw.html#readonlymemory-byte-getpropertynameraw-int-index-bool-includequotes) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameUnescaped(int)](/api/corvus-text-json-internal-ijsondocument.getpropertynameunescaped.html#unescapedutf8jsonstring-getpropertynameunescaped-int-index) | Gets the property name as a JSON element. |
| [GetPropertyRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyrawvalueasstring.html#string-getpropertyrawvalueasstring-int-valueindex) | Gets the raw value of the property at the specified index as a string. |
| [GetRawSimpleValue(int, bool)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalue.html#readonlymemory-byte-getrawsimplevalue-int-index-bool-includequotes) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValue(int)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalue.html#readonlymemory-byte-getrawsimplevalue-int-index) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValueUnsafe(int)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalueunsafe.html#readonlymemory-byte-getrawsimplevalueunsafe-int-index) | Gets the raw simple value of the element at the specified index, without checking if the document has been disposed. |
| [GetRawValue(int, bool)](/api/corvus-text-json-internal-ijsondocument.getrawvalue.html#rawutf8jsonstring-getrawvalue-int-index-bool-includequotes) | Gets the raw value of the element at the specified index. |
| [GetRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getrawvalueasstring.html#string-getrawvalueasstring-int-index) | Gets the raw value of the element at the specified index as a string. |
| [GetStartIndex(int)](/api/corvus-text-json-internal-ijsondocument.getstartindex.html#int-getstartindex-int-endindex) | Gets the start index of the element from the end index. |
| [GetString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getstring.html#string-getstring-int-index-jsontokentype-expectedtype) | Gets the string value of the element at the specified index. |
| [GetUtf16JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf16jsonstring.html#unescapedutf16jsonstring-getutf16jsonstring-int-index-jsontokentype-expectedtype) | Gets the UTF-16 JSON string value of the element at the specified index. |
| [GetUtf8JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf8jsonstring.html#unescapedutf8jsonstring-getutf8jsonstring-int-index-jsontokentype-expectedtype) | Gets the UTF-8 JSON string value of the element at the specified index. |
| [TextEquals(int, ReadOnlySpan&lt;char&gt;, bool)](/api/corvus-text-json-internal-ijsondocument.textequals.html#bool-textequals-int-index-readonlyspan-char-othertext-bool-ispropertyname) | Determines whether the text at the specified index equals the specified text. |
| [TextEquals(int, ReadOnlySpan&lt;byte&gt;, bool, bool)](/api/corvus-text-json-internal-ijsondocument.textequals.html#bool-textequals-int-index-readonlyspan-byte-otherutf8text-bool-ispropertyname-bool-shouldunescape) | Determines whether the UTF-8 text at the specified index equals the specified text. |
| [ToString(int)](/api/corvus-text-json-internal-ijsondocument.tostring.html#string-tostring-int-index) | Converts the element at the specified index to a string. |
| [ToString(int, string, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tostring.html#string-tostring-int-index-string-format-iformatprovider-formatprovider) | Gets the display string representation of the element at the specified index according to the specified format and format provider. |
| [TryFormat(int, Span&lt;char&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tryformat.html#bool-tryformat-int-index-span-char-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-formatprovider) | Formats the value to the provided destination span according to the specified format and format provider. |
| [TryFormat(int, Span&lt;byte&gt;, ref int, ReadOnlySpan&lt;char&gt;, IFormatProvider)](/api/corvus-text-json-internal-ijsondocument.tryformat.html#bool-tryformat-int-index-span-byte-destination-ref-int-charswritten-readonlyspan-char-format-iformatprovider-formatprovider) | Formats the value to the provided destination UTF-8 span according to the specified format and format provider. |
| [TryGetLine(int, ref ReadOnlyMemory&lt;byte&gt;)](/api/corvus-text-json-internal-ijsondocument.trygetline.html#bool-trygetline-int-linenumber-ref-readonlymemory-byte-line) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLine(int, ref string)](/api/corvus-text-json-internal-ijsondocument.trygetline.html#bool-trygetline-int-linenumber-ref-string-line) | Tries to get the specified line from the original source document as a string. |
| [TryGetLineAndOffset(int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffset.html#bool-trygetlineandoffset-int-index-ref-int-line-ref-int-charoffset-ref-long-linebyteoffset) | Tries to get the line number and character offset in the original source document for the element at the specified index. |
| [TryGetLineAndOffsetForPointer(ReadOnlySpan&lt;byte&gt;, int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffsetforpointer.html#bool-trygetlineandoffsetforpointer-readonlyspan-byte-jsonpointer-int-index-ref-int-line-ref-int-charoffset-ref-long-linebyteoffset) | Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-char-propertyname-ref-jsonelement-value) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-byte-propertyname-ref-jsonelement-value) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref TElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-telement-int-index-readonlyspan-byte-propertyname-ref-telement-value) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref TElement)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-telement-int-index-readonlyspan-char-propertyname-ref-telement-value) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-char-propertyname-ref-ijsondocument-elementparent-ref-int-elementindex) | Tries to get the value of a named property as a mutable JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref IJsonDocument, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-byte-propertyname-ref-ijsondocument-elementparent-ref-int-elementindex) | Tries to get the value of a named property as a mutable JSON element. |
| [TryGetString(int, JsonTokenType, ref string)](/api/corvus-text-json-internal-ijsondocument.trygetstring.html#bool-trygetstring-int-index-jsontokentype-expectedtype-ref-string-result) | Tries to get the string value of the element at the specified index. |
| [TryGetValue(int, ref byte\[\])](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-byte-value) | Tries to get the value of the element at the specified index as a byte array. |
| [TryGetValue(int, ref sbyte)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-sbyte-value) | Tries to get the value of the element at the specified index as an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte). |
| [TryGetValue(int, ref byte)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-byte-value) | Tries to get the value of the element at the specified index as a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte). |
| [TryGetValue(int, ref short)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-short-value) | Tries to get the value of the element at the specified index as a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16). |
| [TryGetValue(int, ref ushort)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-ushort-value) | Tries to get the value of the element at the specified index as a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16). |
| [TryGetValue(int, ref int)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-int-value) | Tries to get the value of the element at the specified index as an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [TryGetValue(int, ref uint)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-uint-value) | Tries to get the value of the element at the specified index as a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32). |
| [TryGetValue(int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-long-value) | Tries to get the value of the element at the specified index as a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64). |
| [TryGetValue(int, ref ulong)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-ulong-value) | Tries to get the value of the element at the specified index as a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64). |
| [TryGetValue(int, ref double)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-double-value) | Tries to get the value of the element at the specified index as a [`Double`](https://learn.microsoft.com/dotnet/api/system.double). |
| [TryGetValue(int, ref float)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-float-value) | Tries to get the value of the element at the specified index as a [`Single`](https://learn.microsoft.com/dotnet/api/system.single). |
| [TryGetValue(int, ref decimal)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-decimal-value) | Tries to get the value of the element at the specified index as a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal). |
| [TryGetValue(int, ref BigInteger)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-biginteger-value) | Tries to get the value of the element at the specified index as a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger). |
| [TryGetValue(int, ref BigNumber)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-bignumber-value) | Tries to get the value of the element at the specified index as a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryGetValue(int, ref DateTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-datetime-value) | Tries to get the value of the element at the specified index as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [TryGetValue(int, ref DateTimeOffset)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-datetimeoffset-value) | Tries to get the value of the element at the specified index as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [TryGetValue(int, ref OffsetDateTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-offsetdatetime-value) | Tries to get the value of the element at the specified index as an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html). |
| [TryGetValue(int, ref OffsetDate)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-offsetdate-value) | Tries to get the value of the element at the specified index as an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html). |
| [TryGetValue(int, ref OffsetTime)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-offsettime-value) | Tries to get the value of the element at the specified index as an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html). |
| [TryGetValue(int, ref LocalDate)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-localdate-value) | Tries to get the value of the element at the specified index as a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html). |
| [TryGetValue(int, ref Period)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-period-value) | Tries to get the value of the element at the specified index as a [`Period`](/api/corvus-text-json-period.html). |
| [TryGetValue(int, ref Guid)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-guid-value) | Tries to get the value of the element at the specified index as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid). |
| [TryGetValue(int, ref Int128)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-int128-value) | Tries to get the value of the element at the specified index as an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128). |
| [TryGetValue(int, ref UInt128)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-uint128-value) | Tries to get the value of the element at the specified index as a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128). |
| [TryGetValue(int, ref Half)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-half-value) | Tries to get the value of the element at the specified index as a [`Half`](https://learn.microsoft.com/dotnet/api/system.half). |
| [TryGetValue(int, ref DateOnly)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-dateonly-value) | Tries to get the value of the element at the specified index as a [`DateOnly`](https://learn.microsoft.com/dotnet/api/system.dateonly). |
| [TryGetValue(int, ref TimeOnly)](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html#bool-trygetvalue-int-index-ref-timeonly-value) | Tries to get the value of the element at the specified index as a [`TimeOnly`](https://learn.microsoft.com/dotnet/api/system.timeonly). |
| [TryResolveJsonPointer(ReadOnlySpan&lt;byte&gt;, int, ref TValue)](/api/corvus-text-json-internal-ijsondocument.tryresolvejsonpointer.html#bool-tryresolvejsonpointer-tvalue-readonlyspan-byte-jsonpointer-int-index-ref-tvalue-value) | Try to resolve the given JSON pointer. |
| [ValueIsEscaped(int, bool)](/api/corvus-text-json-internal-ijsondocument.valueisescaped.html#bool-valueisescaped-int-index-bool-ispropertyname) | Determines whether the value at the specified index is escaped. |
| [WriteElementTo(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writeelementto.html#void-writeelementto-int-index-utf8jsonwriter-writer) | Writes the element at the specified index to the provided JSON writer. |
| [WritePropertyName(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writepropertyname.html#void-writepropertyname-int-index-utf8jsonwriter-writer) | Writes the property name at the specified index to the provided JSON writer. |

