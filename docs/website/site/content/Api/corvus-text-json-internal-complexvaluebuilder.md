---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L43)

Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html).

```csharp
public readonly struct ComplexValueBuilder
```

## Remarks

[`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) is a ref struct designed for use in stack-based scenarios, enabling efficient construction of JSON objects and arrays by directly manipulating the underlying metadata database. This builder supports adding properties and items of various types, including primitives, strings, numbers, booleans, nulls, and complex/nested values. It also provides methods for starting and ending JSON objects and arrays, as well as for integrating with [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) for document mutation. Typical usage involves creating a builder via [`Create`](/api/corvus-text-json-internal-complexvaluebuilder.html#create), using [`AddProperty`](/api/corvus-text-json-internal-complexvaluebuilder.html#addproperty) and [`AddItem`](/api/corvus-text-json-internal-complexvaluebuilder.html#additem) methods to populate the structure, and then finalizing with [`EndObject`](/api/corvus-text-json-internal-complexvaluebuilder.html#endobject) or [`EndArray`](/api/corvus-text-json-internal-complexvaluebuilder.html#endarray). This type is not thread-safe and must not be stored on the heap.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [MemberCount](/api/corvus-text-json-internal-complexvaluebuilder.membercount.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets the number of members (properties or items) added to the current object or array. |

## Methods

| Method | Description |
|--------|-------------|
| [AddItem](/api/corvus-text-json-internal-complexvaluebuilder.additem.html) | Adds an item to the current array as a UTF-8 string. |
| [AddItemArrayValue](/api/corvus-text-json-internal-complexvaluebuilder.additemarrayvalue.html) | Adds an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values as an item to the current array. |
| [AddItemFormattedNumber(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-complexvaluebuilder.additemformattednumber.html#additemformattednumber-readonlyspan-byte) | Adds a formatted number item to the current array. |
| [AddItemNull()](/api/corvus-text-json-internal-complexvaluebuilder.additemnull.html#additemnull) | Adds a null item to the current array. |
| [AddItemRawString(ReadOnlySpan&lt;byte&gt;, bool)](/api/corvus-text-json-internal-complexvaluebuilder.additemrawstring.html#additemrawstring-readonlyspan-byte-bool) | Adds an item to the current array as a raw string. |
| [AddProperty](/api/corvus-text-json-internal-complexvaluebuilder.addproperty.html) |  |
| [AddPropertyArrayValue](/api/corvus-text-json-internal-complexvaluebuilder.addpropertyarrayvalue.html) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object. |
| [AddPropertyFormattedNumber](/api/corvus-text-json-internal-complexvaluebuilder.addpropertyformattednumber.html) | Adds a property with a formatted number value to the current object. |
| [AddPropertyNull](/api/corvus-text-json-internal-complexvaluebuilder.addpropertynull.html) | Adds a property with a null value to the current object. |
| [AddPropertyRawString](/api/corvus-text-json-internal-complexvaluebuilder.addpropertyrawstring.html) | Adds a property with a raw string value to the current object, with control over escaping and unescaping. |
| [Apply(ref T)](/api/corvus-text-json-internal-complexvaluebuilder.apply.html#apply-ref-t) | Apply an object instance value to the document. |
| [Create(IMutableJsonDocument, int)](/api/corvus-text-json-internal-complexvaluebuilder.create.html#create-imutablejsondocument-int) `static` | Creates a new [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) for the specified parent document, pre-allocating space for the given number of elements. |
| [EndArray()](/api/corvus-text-json-internal-complexvaluebuilder.endarray.html#endarray) | Ends the current JSON array, finalizing its structure in the builder. |
| [EndItem(ref ComplexValueBuilder.ComplexValueHandle)](/api/corvus-text-json-internal-complexvaluebuilder.enditem.html#enditem-ref-complexvaluebuilder-complexvaluehandle) |  |
| [EndObject()](/api/corvus-text-json-internal-complexvaluebuilder.endobject.html#endobject) | Ends the current JSON object, finalizing its structure in the builder. |
| [EndProperty(ref ComplexValueBuilder.ComplexValueHandle)](/api/corvus-text-json-internal-complexvaluebuilder.endproperty.html#endproperty-ref-complexvaluebuilder-complexvaluehandle) |  |
| [InsertAndDispose(int, int, ref MetadataDb)](/api/corvus-text-json-internal-complexvaluebuilder.insertanddispose.html#insertanddispose-int-int-ref-metadatadb) | Inserts the built data into the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) at the given index and disposes this builder. |
| [OverwriteAndDispose(int, int, int, int, ref MetadataDb)](/api/corvus-text-json-internal-complexvaluebuilder.overwriteanddispose.html#overwriteanddispose-int-int-int-int-ref-metadatadb) | Overwrites a range of data in the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) with the built data and disposes this builder. |
| [RemoveProperty](/api/corvus-text-json-internal-complexvaluebuilder.removeproperty.html) | Removes a property from the current object. |
| [SetAndDispose(ref MetadataDb)](/api/corvus-text-json-internal-complexvaluebuilder.setanddispose.html#setanddispose-ref-metadatadb) | Transfers the built data to the specified [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) and disposes this builder. |
| [StartArray()](/api/corvus-text-json-internal-complexvaluebuilder.startarray.html#startarray) | Starts a new JSON array in the builder. |
| [StartItem()](/api/corvus-text-json-internal-complexvaluebuilder.startitem.html#startitem) | Start an array item. |
| [StartObject()](/api/corvus-text-json-internal-complexvaluebuilder.startobject.html#startobject) | Starts a new JSON object in the builder. |
| [StartProperty](/api/corvus-text-json-internal-complexvaluebuilder.startproperty.html) | Add a property name to the current object. |
| [TryApply(ref T)](/api/corvus-text-json-internal-complexvaluebuilder.tryapply.html#tryapply-ref-t) | Tries to apply an object instance value to the document. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

