---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema — Corvus.Text.Json"
---
```csharp
public readonly struct JsonElementForBooleanFalseSchema : IJsonElement<JsonElementForBooleanFalseSchema>, IJsonElement
```

Represents a placeholder for the `false` boolean schema which disallows any value.

## Implements

[`IJsonElement<JsonElementForBooleanFalseSchema>`](/api/corvus-text-json-internal-ijsonelement.html), [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [ValueKind](/api/corvus-text-json-jsonelementforbooleanfalseschema.valuekind.html) | [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) | The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is. |

## Methods

| Method | Description |
|--------|-------------|
| [CreateDocument(JsonWorkspace, int, int)](/api/corvus-text-json-jsonelementforbooleanfalseschema.createdocument.html#jsondocumentbuilder-jsonelementforbooleanfalseschema-mutable-createdocument-jsonworkspace-workspace-int-year-int-initialcapacity) `static` | Creates a JSON document containing the specified integer value. |
| [CreateDocument(JsonWorkspace)](/api/corvus-text-json-jsonelementforbooleanfalseschema.createdocument.html#jsondocumentbuilder-jsonelementforbooleanfalseschema-mutable-createdocument-jsonworkspace-workspace) | Creates a JSON document from the current instance. |
| [Equals(object)](/api/corvus-text-json-jsonelementforbooleanfalseschema.equals.html#bool-equals-object-obj) | Determines whether the specified object is equal to the current instance. |
| [Equals(T)](/api/corvus-text-json-jsonelementforbooleanfalseschema.equals.html#bool-equals-t-t-other) | Determines whether the specified JSON element is equal to the current instance. |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelementforbooleanfalseschema.evaluateschema.html#bool-evaluateschema-ijsonschemaresultscollector-resultscollector) | Evaluates this element against the boolean false schema. |
| [From(ref T)](/api/corvus-text-json-jsonelementforbooleanfalseschema.from.html#jsonelementforbooleanfalseschema-from-t-ref-t-instance) `static` | Creates a new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) from the specified JSON element instance. |
| [GetHashCode()](/api/corvus-text-json-jsonelementforbooleanfalseschema.gethashcode.html#int-gethashcode) | Gets the hash code for the current instance. |
| [ParseValue(ReadOnlySpan&lt;byte&gt;, JsonDocumentOptions)](/api/corvus-text-json-jsonelementforbooleanfalseschema.parsevalue.html#jsonelementforbooleanfalseschema-parsevalue-readonlyspan-byte-utf8json-jsondocumentoptions-options) `static` | Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ReadOnlySpan&lt;char&gt;, JsonDocumentOptions)](/api/corvus-text-json-jsonelementforbooleanfalseschema.parsevalue.html#jsonelementforbooleanfalseschema-parsevalue-readonlyspan-char-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(string, JsonDocumentOptions)](/api/corvus-text-json-jsonelementforbooleanfalseschema.parsevalue.html#jsonelementforbooleanfalseschema-parsevalue-string-json-jsondocumentoptions-options) `static` | Parses text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ParseValue(ref Utf8JsonReader)](/api/corvus-text-json-jsonelementforbooleanfalseschema.parsevalue.html#jsonelementforbooleanfalseschema-parsevalue-ref-utf8jsonreader-reader) `static` | Parses one JSON value (including objects or arrays) from the provided reader. |
| [ToString()](/api/corvus-text-json-jsonelementforbooleanfalseschema.tostring.html#string-tostring) | Gets a string representation for the current value appropriate to the value type. |
| [TryParseValue(ref Utf8JsonReader, ref Nullable&lt;JsonElementForBooleanFalseSchema&gt;)](/api/corvus-text-json-jsonelementforbooleanfalseschema.tryparsevalue.html#bool-tryparsevalue-ref-utf8jsonreader-reader-ref-nullable-jsonelementforbooleanfalseschema-element) `static` |  |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelementforbooleanfalseschema.writeto.html#void-writeto-utf8jsonwriter-writer) | Write the element into the provided writer as a JSON value. |

## Operators

| Operator | Description |
|----------|-------------|
| [operator ==(JsonElementForBooleanFalseSchema, JsonElementForBooleanFalseSchema)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-equality.html#static-bool-operator-jsonelementforbooleanfalseschema-left-jsonelementforbooleanfalseschema-right) | Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are equal. |
| [operator ==(JsonElementForBooleanFalseSchema, JsonElement)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-equality.html#static-bool-operator-jsonelementforbooleanfalseschema-left-jsonelement-right) | Determines whether a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) and a [`JsonElement`](/api/corvus-text-json-jsonelement.html) are equal. |
| [implicit operator int(JsonElementForBooleanFalseSchema)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-implicit.html#static-implicit-operator-int-jsonelementforbooleanfalseschema-age) | Implicitly converts a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) to an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [operator !=(JsonElementForBooleanFalseSchema, JsonElementForBooleanFalseSchema)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-inequality.html#static-bool-operator-jsonelementforbooleanfalseschema-left-jsonelementforbooleanfalseschema-right) | Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are not equal. |
| [operator !=(JsonElementForBooleanFalseSchema, JsonElement)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-inequality.html#static-bool-operator-jsonelementforbooleanfalseschema-left-jsonelement-right) | Determines whether a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) and a [`JsonElement`](/api/corvus-text-json-jsonelement.html) are not equal. |

