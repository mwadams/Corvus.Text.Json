---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json Namespace"
---
# Corvus.Text.Json Namespace

| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator<TItem>](#arrayenumerator-titem) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [IByteBufferWriter](#ibytebufferwriter) | interface |  |
| [IJsonSchemaResultsCollector](#ijsonschemaresultscollector) | interface | Implemented by types that accumulate the results of a JSON Schema evaluation. |
| [JsonCommentHandling](#jsoncommenthandling) | enum | This enum defines the various ways the [`Utf8JsonReader`](#Utf8JsonReader) can deal with comments. |
| [JsonDocumentBuilder<T>](#jsondocumentbuilder-t) | class | A mutable JSON document builder that provides functionality to construct and modify JSON documents. |
| [JsonDocumentOptions](#jsondocumentoptions) | struct | Provides the ability for the user to define custom behavior when parsing JSON to create a [`JsonDocument`](#JsonDocument). |
| [JsonElement](#jsonelement) | struct | Represents a specific JSON value within a [`JsonDocument`](#JsonDocument). |
| [JsonElementExtensions](#jsonelementextensions) | class | Extension methods for [`IJsonElement`](#IJsonElement). |
| [JsonElementForBooleanFalseSchema](#jsonelementforbooleanfalseschema) | struct | Represents a specific JSON value within a [`JsonDocument`](#JsonDocument). |
| [JsonEncodedText](#jsonencodedtext) | struct | Provides a way to transform UTF-8 or UTF-16 encoded text into a form that is suitable for JSON. |
| [JsonException](#jsonexception) | class | Represents errors that occur during JSON parsing, reading, or writing operations. This exception is thrown when invalid JSON text is encountered, when the defined maximum depth is exceeded, or when... |
| [JsonPredicate<T>](#jsonpredicate-t) | delegate | A predicate for a JSON value. |
| [JsonProperty<TValue>](#jsonproperty-tvalue) | struct | Represents a single property for a JSON object. |
| [JsonReaderOptions](#jsonreaderoptions) | struct | Provides the ability for the user to define custom behavior when reading JSON. |
| [JsonReaderState](#jsonreaderstate) | struct | Defines an opaque type that holds and saves all the relevant state information which must be provided to the [`Utf8JsonReader`](#Utf8JsonReader) to continue reading after processing incomplete data... |
| [JsonSchemaMessageProvider](#jsonschemamessageprovider) | delegate | Provides a message for a JSON Schema validation result. |
| [JsonSchemaMessageProvider<TContext>](#jsonschemamessageprovider-tcontext) | delegate | Provides a message for a JSON Schema validation result, using a context value. |
| [JsonSchemaPathProvider](#jsonschemapathprovider) | delegate | Provides a path segment for a JSON Schema location or instance path. |
| [JsonSchemaPathProvider<TContext>](#jsonschemapathprovider-tcontext) | delegate | Provides a path segment for a JSON Schema location or instance path, using a context value. |
| [JsonSchemaResultsCollector](#jsonschemaresultscollector) | class | Collects and manages results from JSON schema validation operations with high-performance memory management, stack-based evaluation tracking, and configurable verbosity levels. |
| [JsonSchemaResultsLevel](#jsonschemaresultslevel) | enum | The level of result to collect for an [`IJsonSchemaResultsCollector`](#IJsonSchemaResultsCollector). |
| [JsonValueKind](#jsonvaluekind) | enum | Specifies the data type of a JSON value. |
| [JsonWorkspace](#jsonworkspace) | class | A workspace for manipulating JSON documents. |
| [JsonWriterOptions](#jsonwriteroptions) | struct | Provides the ability for the user to define custom behavior when writing JSON using the [`Utf8JsonWriter`](#Utf8JsonWriter). By default, the JSON is written without any indentation or extra white s... |
| [Matcher<TMatch, TContext, TResult>](#matcher-tmatch,-tcontext,-tresult) | delegate | A callback for a pattern match method. |
| [Matcher<TMatch, TOut>](#matcher-tmatch,-tout) | delegate | A callback for a pattern match method. |
| [ObjectEnumerator<TValue>](#objectenumerator-tvalue) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [ParsedJsonDocument<T>](#parsedjsondocument-t) | class | Represents the structure of a JSON value in a lightweight, read-only form. |
| [Period](#period) | struct | Represents a period of time expressed in human chronological terms: hours, days, weeks, months and so on. |
| [PeriodBuilder](#periodbuilder) | struct | A mutable builder class for [`Period`](#Period) values. Each property can be set independently, and then a Period can be created from the result using the [`BuildPeriod`](#BuildPeriod) method. |
| [RawUtf8JsonString](#rawutf8jsonstring) | struct | Represents a raw UTF-8 JSON string. |
| [UnescapedUtf16JsonString](#unescapedutf16jsonstring) | struct | Represents an Unescaped UTF-16 JSON string. |
| [UnescapedUtf8JsonString](#unescapedutf8jsonstring) | struct | Represents an Unescaped UTF-8 JSON string. |
| [Utf8Iri](#utf8iri) | struct | A UTF-8 IRI. |
| [Utf8IriReference](#utf8irireference) | struct | A UTF-8 IRI Reference. |
| [Utf8IriReferenceValue](#utf8irireferencevalue) | struct | A UTF-8 IRI reference value that has been parsed from a JSON document. |
| [Utf8IriValue](#utf8irivalue) | struct | A UTF-8 IRI value that has been parsed from a JSON document. |
| [Utf8JsonPointer](#utf8jsonpointer) | struct |  |
| [Utf8JsonReader](#utf8jsonreader) | struct | Provides a high-performance API for forward-only, read-only access to the UTF-8 encoded JSON text. It processes the text sequentially with no caching and adheres strictly to the JSON RFC by default... |
| [Utf8JsonWriter](#utf8jsonwriter) | class | Provides a high-performance API for forward-only, non-cached writing of UTF-8 encoded JSON text. |
| [Utf8Uri](#utf8uri) | struct | A UTF-8 URI. |
| [Utf8UriReference](#utf8urireference) | struct | A UTF-8 URI Reference. |
| [Utf8UriReferenceValue](#utf8urireferencevalue) | struct | A UTF-8 URI reference value that has been parsed from a JSON document. |
| [Utf8UriValue](#utf8urivalue) | struct | A UTF-8 URI value that has been parsed from a JSON document. |


> Detailed type documentation for each type listed above will be available in future updates.
