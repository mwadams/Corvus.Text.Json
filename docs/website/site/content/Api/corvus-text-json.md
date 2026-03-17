---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json Namespace"
---
The primary public API for Corvus.Text.Json. This namespace contains the core types for parsing, reading, building, and validating JSON documents using strongly-typed, pooled-memory models generated from JSON Schema.

Key types include [`ParsedJsonDocument<T>`](/api/corvus-text-json-parsedjsondocument-t.html) (read-only, pooled-memory parsing), [`JsonDocumentBuilder<T>`](/api/corvus-text-json-jsondocumentbuilder-t.html) (mutable document construction), [`JsonElement`](/api/corvus-text-json-jsonelement.html) (the immutable value type), [`JsonElement.Mutable`](/api/corvus-text-json-jsonelement-mutable.html) (the mutable builder variant), [`JsonElement.Source`](/api/corvus-text-json-jsonelement-source.html) (for implicit conversions from .NET primitives), [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) (pooled memory management), and [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html)/[`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) (high-performance streaming I/O).

URI types ([`Utf8Uri`](/api/corvus-text-json-utf8uri.html), [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html), etc.) provide zero-allocation URI parsing and validation for JSON Schema format keywords.

| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator<TItem>](/api/corvus-text-json-arrayenumerator-titem.html) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [IByteBufferWriter](/api/corvus-text-json-ibytebufferwriter.html) | interface |  |
| [IJsonSchemaResultsCollector](/api/corvus-text-json-ijsonschemaresultscollector.html) | interface | Implemented by types that accumulate the results of a JSON Schema evaluation. |
| [JsonCommentHandling](/api/corvus-text-json-jsoncommenthandling.html) | enum | This enum defines the various ways the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) can deal with comments. |
| [JsonDocumentBuilder<T>](/api/corvus-text-json-jsondocumentbuilder-t.html) | class | A mutable JSON document builder that provides functionality to construct and modify JSON documents. |
| [JsonDocumentOptions](/api/corvus-text-json-jsondocumentoptions.html) | struct | Provides the ability for the user to define custom behavior when parsing JSON to create a `JsonDocument`. |
| [JsonElement](/api/corvus-text-json-jsonelement.html) | struct | Represents a specific JSON value within a [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html). |
| [JsonElement.ArrayBuilder](/api/corvus-text-json-jsonelement-arraybuilder.html) | struct |  |
| [JsonElement.ArrayBuilder.Build](/api/corvus-text-json-jsonelement-arraybuilder-build.html) | delegate |  |
| [JsonElement.ArrayBuilder.Build<T>](/api/corvus-text-json-jsonelement-arraybuilder-build-t.html) | delegate |  |
| [JsonElement.JsonSchema](/api/corvus-text-json-jsonelement-jsonschema.html) | class |  |
| [JsonElement.Mutable](/api/corvus-text-json-jsonelement-mutable.html) | struct |  |
| [JsonElement.ObjectBuilder](/api/corvus-text-json-jsonelement-objectbuilder.html) | struct |  |
| [JsonElement.ObjectBuilder.Build](/api/corvus-text-json-jsonelement-objectbuilder-build.html) | delegate |  |
| [JsonElement.ObjectBuilder.Build<T>](/api/corvus-text-json-jsonelement-objectbuilder-build-t.html) | delegate |  |
| [JsonElement.Source](/api/corvus-text-json-jsonelement-source.html) | struct |  |
| [JsonElement.Source<TContext>](/api/corvus-text-json-jsonelement-source-tcontext.html) | struct |  |
| [JsonElementExtensions](/api/corvus-text-json-jsonelementextensions.html) | class | Extension methods for [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |
| [JsonElementForBooleanFalseSchema](/api/corvus-text-json-jsonelementforbooleanfalseschema.html) | struct | Represents a placeholder for the `false` boolean schema which disallows any value. |
| [JsonElementForBooleanFalseSchema.JsonSchema](/api/corvus-text-json-jsonelementforbooleanfalseschema-jsonschema.html) | class |  |
| [JsonElementForBooleanFalseSchema.Mutable](/api/corvus-text-json-jsonelementforbooleanfalseschema-mutable.html) | struct |  |
| [JsonEncodedText](/api/corvus-text-json-jsonencodedtext.html) | struct | Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON. |
| [JsonException](/api/corvus-text-json-jsonexception.html) | class | Represents errors that occur during JSON parsing, reading, or writing operations. This exception is thrown when invalid JSON text is encountered, when the defined maximum depth is exceeded, or when... |
| [JsonPredicate<T>](/api/corvus-text-json-jsonpredicate-t.html) | delegate | A predicate for a JSON value. |
| [JsonProperty<TValue>](/api/corvus-text-json-jsonproperty-tvalue.html) | struct | Represents a single property for a JSON object. |
| [JsonReaderOptions](/api/corvus-text-json-jsonreaderoptions.html) | struct | Provides the ability for the user to define custom behavior when reading JSON. |
| [JsonReaderState](/api/corvus-text-json-jsonreaderstate.html) | struct | Defines an opaque type that holds and saves all the relevant state information which must be provided to the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) to continue reading after ... |
| [JsonSchemaMessageProvider](/api/corvus-text-json-jsonschemamessageprovider.html) | delegate | Provides a message for a JSON Schema validation result. |
| [JsonSchemaMessageProvider<TContext>](/api/corvus-text-json-jsonschemamessageprovider-tcontext.html) | delegate | Provides a message for a JSON Schema validation result, using a context value. |
| [JsonSchemaPathProvider](/api/corvus-text-json-jsonschemapathprovider.html) | delegate | Provides a path segment for a JSON Schema location or instance path. |
| [JsonSchemaPathProvider<TContext>](/api/corvus-text-json-jsonschemapathprovider-tcontext.html) | delegate | Provides a path segment for a JSON Schema location or instance path, using a context value. |
| [JsonSchemaResultsCollector](/api/corvus-text-json-jsonschemaresultscollector.html) | class |  |
| [JsonSchemaResultsCollector.Result](/api/corvus-text-json-jsonschemaresultscollector-result.html) | struct |  |
| [JsonSchemaResultsCollector.ResultsEnumerator](/api/corvus-text-json-jsonschemaresultscollector-resultsenumerator.html) | struct |  |
| [JsonSchemaResultsLevel](/api/corvus-text-json-jsonschemaresultslevel.html) | enum | The level of result to collect for an [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html). |
| [JsonValueKind](/api/corvus-text-json-jsonvaluekind.html) | enum | Specifies the data type of a JSON value. |
| [JsonWorkspace](/api/corvus-text-json-jsonworkspace.html) | class | A workspace for manipulating JSON documents. |
| [JsonWriterOptions](/api/corvus-text-json-jsonwriteroptions.html) | struct | Provides the ability for the user to define custom behavior when writing JSON using the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html). By default, the JSON is written without any in... |
| [Matcher<TMatch, TContext, TResult>](/api/corvus-text-json-matcher-tmatch-tcontext-tresult.html) | delegate | A callback for a pattern match method. |
| [Matcher<TMatch, TOut>](/api/corvus-text-json-matcher-tmatch-tout.html) | delegate | A callback for a pattern match method. |
| [ObjectEnumerator<TValue>](/api/corvus-text-json-objectenumerator-tvalue.html) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [ParsedJsonDocument<T>](/api/corvus-text-json-parsedjsondocument-t.html) | class | Represents the structure of a JSON value in a lightweight, read-only form. |
| [Period](/api/corvus-text-json-period.html) | struct | Represents a period of time expressed in human chronological terms: hours, days, weeks, months and so on. |
| [PeriodBuilder](/api/corvus-text-json-periodbuilder.html) | struct | A mutable builder class for [`Period`](/api/corvus-text-json-period.html) values. Each property can be set independently, and then a Period can be created from the result using the \[`BuildPeriod`\](... |
| [RawUtf8JsonString](/api/corvus-text-json-rawutf8jsonstring.html) | struct | Represents a raw UTF-8 JSON string. |
| [UnescapedUtf16JsonString](/api/corvus-text-json-unescapedutf16jsonstring.html) | struct | Represents an Unescaped UTF-16 JSON string. |
| [UnescapedUtf8JsonString](/api/corvus-text-json-unescapedutf8jsonstring.html) | struct | Represents an Unescaped UTF-8 JSON string. |
| [Utf8Iri](/api/corvus-text-json-utf8iri.html) | struct | A UTF-8 IRI. |
| [Utf8IriReference](/api/corvus-text-json-utf8irireference.html) | struct | A UTF-8 IRI Reference. |
| [Utf8IriReferenceValue](/api/corvus-text-json-utf8irireferencevalue.html) | struct | A UTF-8 IRI reference value that has been parsed from a JSON document. |
| [Utf8IriValue](/api/corvus-text-json-utf8irivalue.html) | struct | A UTF-8 IRI value that has been parsed from a JSON document. |
| [Utf8JsonPointer](/api/corvus-text-json-utf8jsonpointer.html) | struct |  |
| [Utf8JsonReader](/api/corvus-text-json-utf8jsonreader.html) | struct | Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default... |
| [Utf8JsonWriter](/api/corvus-text-json-utf8jsonwriter.html) | class | Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text. |
| [Utf8Uri](/api/corvus-text-json-utf8uri.html) | struct | A UTF-8 URI. |
| [Utf8UriReference](/api/corvus-text-json-utf8urireference.html) | struct | A UTF-8 URI Reference. |
| [Utf8UriReferenceValue](/api/corvus-text-json-utf8urireferencevalue.html) | struct | A UTF-8 URI reference value that has been parsed from a JSON document. |
| [Utf8UriValue](/api/corvus-text-json-utf8urivalue.html) | struct | A UTF-8 URI value that has been parsed from a JSON document. |

