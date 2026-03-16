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
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;char&gt;, ref bool)](/api/corvus-text-json-internal-imutablejsondocument.escapeandstorerawstringvalue.html#escapeandstorerawstringvalue-readonlyspan-char-ref-bool) | Escapes and stores a raw string value in the document. |
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;byte&gt;, ref bool)](/api/corvus-text-json-internal-imutablejsondocument.escapeandstorerawstringvalue.html#escapeandstorerawstringvalue-readonlyspan-byte-ref-bool) | Escapes and stores a raw string value in the document. |
| [GetArrayIndexElement(int, int)](/api/corvus-text-json-internal-imutablejsondocument.getarrayindexelement.html#getarrayindexelement-int-int) | Gets the array element at the specified index as a mutable JSON element. |
| [GetArrayIndexElement(int, int, ref IMutableJsonDocument, ref int)](/api/corvus-text-json-internal-imutablejsondocument.getarrayindexelement.html#getarrayindexelement-int-int-ref-imutablejsondocument-ref-int) | Gets the element at the specified array index within the current index. |
| [InsertAndDispose(int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.insertanddispose.html#insertanddispose-int-int-ref-complexvaluebuilder) | Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [OverwriteAndDispose(int, int, int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.overwriteanddispose.html#overwriteanddispose-int-int-int-int-ref-complexvaluebuilder) | Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [RemoveRange(int, int, int, int)](/api/corvus-text-json-internal-imutablejsondocument.removerange.html#removerange-int-int-int-int) | Removes a range of values from the document. |
| [SetAndDispose(ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.setanddispose.html#setanddispose-ref-complexvaluebuilder) | Sets the value of the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [StoreBooleanValue(bool)](/api/corvus-text-json-internal-imutablejsondocument.storebooleanvalue.html#storebooleanvalue-bool) | Stores a boolean value in the document. |
| [StoreNullValue()](/api/corvus-text-json-internal-imutablejsondocument.storenullvalue.html#storenullvalue) | Stores a null value in the document. |
| [StoreRawNumberValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawnumbervalue.html#storerawnumbervalue-readonlyspan-byte) | Stores a raw number value in the document. |
| [StoreRawStringValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawstringvalue.html#storerawstringvalue-readonlyspan-byte) | Stores a raw string value in the document. |
| [StoreValue(Guid)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-guid) | Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document. |
| [StoreValue(ref DateTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-datetime) | Stores a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value in the document. |
| [StoreValue(ref DateTimeOffset)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-datetimeoffset) | Stores a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value in the document. |
| [StoreValue(ref OffsetDateTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-offsetdatetime) | Stores an [`OffsetDateTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDateTime.html) value in the document. |
| [StoreValue(ref OffsetDate)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-offsetdate) | Stores an [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html) value in the document. |
| [StoreValue(ref OffsetTime)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-offsettime) | Stores an [`OffsetTime`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetTime.html) value in the document. |
| [StoreValue(ref LocalDate)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-localdate) | Stores a [`LocalDate`](https://www.nodatime.org/3.3.x/api/NodaTime.LocalDate.html) value in the document. |
| [StoreValue(ref Period)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-period) | Stores a [`Period`](/api/corvus-text-json-period.html) value in the document. |
| [StoreValue(sbyte)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-sbyte) | Stores an [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) value in the document. |
| [StoreValue(byte)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-byte) | Stores a [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) value in the document. |
| [StoreValue(int)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-int) | Stores an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value in the document. |
| [StoreValue(uint)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-uint) | Stores a [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value in the document. |
| [StoreValue(long)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-long) | Stores a [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value in the document. |
| [StoreValue(ulong)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ulong) | Stores a [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value in the document. |
| [StoreValue(short)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-short) | Stores a [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) value in the document. |
| [StoreValue(ushort)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ushort) | Stores a [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) value in the document. |
| [StoreValue(float)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-float) | Stores a [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value in the document. |
| [StoreValue(double)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-double) | Stores a [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value in the document. |
| [StoreValue(decimal)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-decimal) | Stores a [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value in the document. |
| [StoreValue(ref BigInteger)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-biginteger) | Stores a [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) value in the document. |
| [StoreValue(ref BigNumber)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-ref-bignumber) | Stores a [`BigNumber`](/api/corvus-numerics-bignumber.html) value in the document. |
| [StoreValue(Int128)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-int128) | Stores an [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) value in the document. |
| [StoreValue(UInt128)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-uint128) | Stores a [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) value in the document. |
| [StoreValue(Half)](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html#storevalue-half) | Stores a [`Half`](https://learn.microsoft.com/dotnet/api/system.half) value in the document. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement-mutable) |  |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement.Mutable)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalue.html#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement-mutable) |  |
| [TryGetNamedPropertyValueIndex(ref MetadataDb, int, int, ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#trygetnamedpropertyvalueindex-ref-metadatadb-int-int-readonlyspan-byte-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;char&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#trygetnamedpropertyvalueindex-int-readonlyspan-char-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html#trygetnamedpropertyvalueindex-int-readonlyspan-byte-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |

