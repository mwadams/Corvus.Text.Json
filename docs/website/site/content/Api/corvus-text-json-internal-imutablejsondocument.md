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
| [EscapeAndStoreRawStringValue](/api/corvus-text-json-internal-imutablejsondocument.escapeandstorerawstringvalue.html) | Escapes and stores a raw string value in the document. |
| [GetArrayIndexElement](/api/corvus-text-json-internal-imutablejsondocument.getarrayindexelement.html) | Gets the array element at the specified index as a mutable JSON element. |
| [InsertAndDispose(int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.insertanddispose.html#insertanddispose-int-int-ref-complexvaluebuilder) | Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [OverwriteAndDispose(int, int, int, int, ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.overwriteanddispose.html#overwriteanddispose-int-int-int-int-ref-complexvaluebuilder) | Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [RemoveRange(int, int, int, int)](/api/corvus-text-json-internal-imutablejsondocument.removerange.html#removerange-int-int-int-int) | Removes a range of values from the document. |
| [SetAndDispose(ref ComplexValueBuilder)](/api/corvus-text-json-internal-imutablejsondocument.setanddispose.html#setanddispose-ref-complexvaluebuilder) | Sets the value of the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html). |
| [StoreBooleanValue(bool)](/api/corvus-text-json-internal-imutablejsondocument.storebooleanvalue.html#storebooleanvalue-bool) | Stores a boolean value in the document. |
| [StoreNullValue()](/api/corvus-text-json-internal-imutablejsondocument.storenullvalue.html#storenullvalue) | Stores a null value in the document. |
| [StoreRawNumberValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawnumbervalue.html#storerawnumbervalue-readonlyspan-byte) | Stores a raw number value in the document. |
| [StoreRawStringValue(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-imutablejsondocument.storerawstringvalue.html#storerawstringvalue-readonlyspan-byte) | Stores a raw string value in the document. |
| [StoreValue](/api/corvus-text-json-internal-imutablejsondocument.storevalue.html) | Stores a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value in the document. |
| [TryGetNamedPropertyValue](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalue.html) |  |
| [TryGetNamedPropertyValueIndex](/api/corvus-text-json-internal-imutablejsondocument.trygetnamedpropertyvalueindex.html) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

