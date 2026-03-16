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
| [CreateDocument](/api/corvus-text-json-jsonelementforbooleanfalseschema.createdocument.html) `static` | Creates a JSON document containing the specified integer value. |
| [Equals](/api/corvus-text-json-jsonelementforbooleanfalseschema.equals.html) | Determines whether the specified object is equal to the current instance. |
| [EvaluateSchema(IJsonSchemaResultsCollector)](/api/corvus-text-json-jsonelementforbooleanfalseschema.evaluateschema.html#evaluateschema-ijsonschemaresultscollector) | Evaluates this element against the boolean false schema. |
| [From(ref T)](/api/corvus-text-json-jsonelementforbooleanfalseschema.from.html#from-ref-t) `static` | Creates a new [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) from the specified JSON element instance. |
| [GetHashCode()](/api/corvus-text-json-jsonelementforbooleanfalseschema.gethashcode.html#gethashcode) | Gets the hash code for the current instance. |
| [ParseValue](/api/corvus-text-json-jsonelementforbooleanfalseschema.parsevalue.html) `static` | Parses UTF8-encoded text representing a single JSON value into a [`JsonElement`](/api/corvus-text-json-jsonelement.html). |
| [ToString()](/api/corvus-text-json-jsonelementforbooleanfalseschema.tostring.html#tostring) | Gets a string representation for the current value appropriate to the value type. |
| [TryParseValue(ref Utf8JsonReader, ref Nullable&lt;JsonElementForBooleanFalseSchema&gt;)](/api/corvus-text-json-jsonelementforbooleanfalseschema.tryparsevalue.html#tryparsevalue-ref-utf8jsonreader-ref-nullable-jsonelementforbooleanfalseschema) `static` |  |
| [WriteTo(Utf8JsonWriter)](/api/corvus-text-json-jsonelementforbooleanfalseschema.writeto.html#writeto-utf8jsonwriter) | Write the element into the provided writer as a JSON value. |

## Operators

| Operator | Description |
|----------|-------------|
| [Equality](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-equality.html) | Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are equal. |
| [implicit operator int(JsonElementForBooleanFalseSchema)](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-implicit.html#implicit-operator-int-jsonelementforbooleanfalseschema) | Implicitly converts a [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) to an [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32). |
| [Inequality](/api/corvus-text-json-jsonelementforbooleanfalseschema.op-inequality.html) | Determines whether two [`JsonElementForBooleanFalseSchema`](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) instances are not equal. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

