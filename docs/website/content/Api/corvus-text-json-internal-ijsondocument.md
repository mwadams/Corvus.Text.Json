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
| [CloneElement](/api/corvus-text-json-internal-ijsondocument.cloneelement.html) | Clones the element at the specified index. |
| [EnsurePropertyMap(int)](/api/corvus-text-json-internal-ijsondocument.ensurepropertymap.html#ensurepropertymap-int) | Ensures the property map is available for the specified index. |
| [GetArrayIndexElement](/api/corvus-text-json-internal-ijsondocument.getarrayindexelement.html) | Gets the element at the specified array index within the current index. |
| [GetArrayInsertionIndex(int, int)](/api/corvus-text-json-internal-ijsondocument.getarrayinsertionindex.html#getarrayinsertionindex-int-int) | Gets DB index of the item at the array index within the array that starts at `currentIndex`. |
| [GetArrayLength(int)](/api/corvus-text-json-internal-ijsondocument.getarraylength.html#getarraylength-int) | Gets the length of the array at the specified index. |
| [GetDbSize(int, bool)](/api/corvus-text-json-internal-ijsondocument.getdbsize.html#getdbsize-int-bool) | Gets the size of the database for the element at the specified index. |
| [GetHashCode(int)](/api/corvus-text-json-internal-ijsondocument.gethashcode.html#gethashcode-int) | Gets the hash code for the specified index. |
| [GetJsonTokenType(int)](/api/corvus-text-json-internal-ijsondocument.getjsontokentype.html#getjsontokentype-int) | Gets the JSON token type for the specified index. |
| [GetNameOfPropertyValue(int)](/api/corvus-text-json-internal-ijsondocument.getnameofpropertyvalue.html#getnameofpropertyvalue-int) | Gets the name of the property value at the specified index. |
| [GetPropertyCount(int)](/api/corvus-text-json-internal-ijsondocument.getpropertycount.html#getpropertycount-int) | Gets the number of properties for the element at the specified index. |
| [GetPropertyName(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyname.html#getpropertyname-int) | Gets the property name as a JSON element. |
| [GetPropertyNameRaw](/api/corvus-text-json-internal-ijsondocument.getpropertynameraw.html) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameUnescaped(int)](/api/corvus-text-json-internal-ijsondocument.getpropertynameunescaped.html#getpropertynameunescaped-int) | Gets the property name as a JSON element. |
| [GetPropertyRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getpropertyrawvalueasstring.html#getpropertyrawvalueasstring-int) | Gets the raw value of the property at the specified index as a string. |
| [GetRawSimpleValue](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalue.html) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValueUnsafe(int)](/api/corvus-text-json-internal-ijsondocument.getrawsimplevalueunsafe.html#getrawsimplevalueunsafe-int) | Gets the raw simple value of the element at the specified index, without checking if the document has been disposed. |
| [GetRawValue(int, bool)](/api/corvus-text-json-internal-ijsondocument.getrawvalue.html#getrawvalue-int-bool) | Gets the raw value of the element at the specified index. |
| [GetRawValueAsString(int)](/api/corvus-text-json-internal-ijsondocument.getrawvalueasstring.html#getrawvalueasstring-int) | Gets the raw value of the element at the specified index as a string. |
| [GetStartIndex(int)](/api/corvus-text-json-internal-ijsondocument.getstartindex.html#getstartindex-int) | Gets the start index of the element from the end index. |
| [GetString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getstring.html#getstring-int-jsontokentype) | Gets the string value of the element at the specified index. |
| [GetUtf16JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf16jsonstring.html#getutf16jsonstring-int-jsontokentype) | Gets the UTF-16 JSON string value of the element at the specified index. |
| [GetUtf8JsonString(int, JsonTokenType)](/api/corvus-text-json-internal-ijsondocument.getutf8jsonstring.html#getutf8jsonstring-int-jsontokentype) | Gets the UTF-8 JSON string value of the element at the specified index. |
| [TextEquals](/api/corvus-text-json-internal-ijsondocument.textequals.html) | Determines whether the text at the specified index equals the specified text. |
| [ToString](/api/corvus-text-json-internal-ijsondocument.tostring.html) | Converts the element at the specified index to a string. |
| [TryFormat](/api/corvus-text-json-internal-ijsondocument.tryformat.html) | Formats the value to the provided destination span according to the specified format and format provider. |
| [TryGetLine](/api/corvus-text-json-internal-ijsondocument.trygetline.html) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLineAndOffset(int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffset.html#trygetlineandoffset-int-ref-int-ref-int-ref-long) | Tries to get the line number and character offset in the original source document for the element at the specified index. |
| [TryGetLineAndOffsetForPointer(ReadOnlySpan&lt;byte&gt;, int, ref int, ref int, ref long)](/api/corvus-text-json-internal-ijsondocument.trygetlineandoffsetforpointer.html#trygetlineandoffsetforpointer-readonlyspan-byte-int-ref-int-ref-int-ref-long) | Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document. |
| [TryGetNamedPropertyValue](/api/corvus-text-json-internal-ijsondocument.trygetnamedpropertyvalue.html) | Tries to get the value of a named property as a JSON element. |
| [TryGetString(int, JsonTokenType, ref string)](/api/corvus-text-json-internal-ijsondocument.trygetstring.html#trygetstring-int-jsontokentype-ref-string) | Tries to get the string value of the element at the specified index. |
| [TryGetValue](/api/corvus-text-json-internal-ijsondocument.trygetvalue.html) | Tries to get the value of the element at the specified index as a byte array. |
| [TryResolveJsonPointer(ReadOnlySpan&lt;byte&gt;, int, ref TValue)](/api/corvus-text-json-internal-ijsondocument.tryresolvejsonpointer.html#tryresolvejsonpointer-readonlyspan-byte-int-ref-tvalue) | Try to resolve the given JSON pointer. |
| [ValueIsEscaped(int, bool)](/api/corvus-text-json-internal-ijsondocument.valueisescaped.html#valueisescaped-int-bool) | Determines whether the value at the specified index is escaped. |
| [WriteElementTo(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writeelementto.html#writeelementto-int-utf8jsonwriter) | Writes the element at the specified index to the provided JSON writer. |
| [WritePropertyName(int, Utf8JsonWriter)](/api/corvus-text-json-internal-ijsondocument.writepropertyname.html#writepropertyname-int-utf8jsonwriter) | Writes the property name at the specified index to the provided JSON writer. |

