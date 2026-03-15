---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument — Corvus.Text.Json.Internal"
---
```csharp
public interface IMutableJsonDocument : IJsonDocument, IDisposable
```

Represents a mutable JSON document that supports editing and value storage operations.

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Implemented By

[`JsonDocumentBuilder<T>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [ParentWorkspaceIndex](/api/corvus-text-json-internal-imutablejsondocument.parentworkspaceindex.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the index of the parent workspace. |
| [Version](/api/corvus-text-json-internal-imutablejsondocument.version.html) | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | Gets the version of the document. |
| [Workspace](/api/corvus-text-json-internal-imutablejsondocument.workspace.html) | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | Gets the JSON workspace associated with this document. |

## Methods

| Method | Description |
|--------|-------------|
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;char&gt;, ref bool)](/api/corvus-text-json-internal-imutablejsondocument.escapeandstorerawstringvalue.html#int-escapeandstorerawstringvalue-readonlyspan-char-value-ref-bool-requiredescaping) | Escapes and stores a raw string value in the document. |
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;byte&gt;, ref bool)](/api/corvus-text-json-internal-imutablejsondocument.escapeandstorerawstringvalue.html#int-escapeandstorerawstringvalue-readonlyspan-byte-value-ref-bool-requiredescaping) | Escapes and stores a raw string value in the document. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-imutablejsondocument.getarrayindexelement.html#jsonelement-mutable-getarrayindexelement-int-currentindex-int-arrayindex) | Gets the array element at the specified index as a mutable JSON element. |
| [GetArrayIndexElement(int, int, ref IMutableJsonDocument, ref int)](/api/corvus-text-json-internal-imutablejsondocument.getarrayindexelement.html#void-getarrayindexelement-int-currentindex-int-arrayindex-ref-imutablejsondocument-parentdocument-ref-int-parentdocumentindex) | Gets the element at the specified array index within the current index. |
| [InsertAndDispose(int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.insertanddispose.html#void-insertanddispose-int-complexobjectstartindex-int-index-ref-complexvaluebuilder-cvb) | Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [OverwriteAndDispose(int, int, int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.overwriteanddispose.html#void-overwriteanddispose-int-complexobjectstartindex-int-startindex-int-endindex-int-memberstooverwrite-ref-complexvaluebuilder-cvb) | Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [RemoveRange(int, int, int, int)](/api/corvus-text-json-internal-imutablejsondocument.removerange.html#void-removerange-int-complexobjectstartindex-int-startindex-int-endindex-int-memberstoremove) | Removes a range of values from the document. |
| [SetAndDispose(ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.setanddispose.html#void-setanddispose-ref-complexvaluebuilder-cvb) | Sets the value of the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [StoreBooleanValue(bool)](/api/corvus-text-json-internal-imutablejsondocument.storebooleanvalue.html#int-storebooleanvalue-bool-value) | Stores a boolean value in the document. |
| [StoreNullValue()](/api/corvus-text-json-internal-imutablejsondocument.storenullvalue.html#int-storenullvalue) | Stores a null value in the document. |
| [StoreRawNumberValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawnumbervalue.html#int-storerawnumbervalue-readonlyspan-byte-value) | Stores a raw number value in the document. |
| [StoreRawStringValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawstringvalue.html#int-storerawstringvalue-readonlyspan-byte-value) | Stores a raw string value in the document. |
| [StoreValue(Guid)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-guid-value) | Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document. |
| [StoreValue(ref DateTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-datetime-value) | Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document. |
| [StoreValue(ref DateTimeOffset)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-datetimeoffset-value) | Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document. |
| [StoreValue(ref OffsetDateTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-offsetdatetime-value) | Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document. |
| [StoreValue(ref OffsetDate)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-offsetdate-value) | Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document. |
| [StoreValue(ref OffsetTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-offsettime-value) | Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document. |
| [StoreValue(ref LocalDate)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-localdate-value) | Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document. |
| [StoreValue(ref Period)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-period-value) | Stores a [`Period`](/api/corvus-text-json-period.html) value in the document. |
| [StoreValue(sbyte)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-sbyte-value) | Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document. |
| [StoreValue(byte)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-byte-value) | Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document. |
| [StoreValue(int)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-int-value) | Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document. |
| [StoreValue(uint)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-uint-value) | Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document. |
| [StoreValue(long)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-long-value) | Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document. |
| [StoreValue(ulong)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ulong-value) | Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document. |
| [StoreValue(short)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-short-value) | Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document. |
| [StoreValue(ushort)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ushort-value) | Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document. |
| [StoreValue(float)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-float-value) | Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document. |
| [StoreValue(double)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-double-value) | Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document. |
| [StoreValue(decimal)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-decimal-value) | Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document. |
| [StoreValue(ref BigInteger)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-biginteger-value) | Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document. |
| [StoreValue(ref BigNumber)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-ref-bignumber-value) | Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document. |
| [StoreValue(Int128)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-int128-value) | Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document. |
| [StoreValue(UInt128)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-uint128-value) | Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document. |
| [StoreValue(Half)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#int-storevalue-half-value) | Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-char-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalue.html#bool-trygetnamedpropertyvalue-int-index-readonlyspan-byte-propertyname-ref-jsonelement-mutable-value) |  |
| [TryGetNamedPropertyValueIndex(ref MetadataDb, int, int, ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#bool-trygetnamedpropertyvalueindex-ref-metadatadb-parseddata-int-startindex-int-endindex-readonlyspan-byte-propertyname-ref-int-valueindex) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;char&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#bool-trygetnamedpropertyvalueindex-int-index-readonlyspan-char-propertyname-ref-int-valueindex) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#bool-trygetnamedpropertyvalueindex-int-index-readonlyspan-byte-propertyname-ref-int-valueindex) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |

