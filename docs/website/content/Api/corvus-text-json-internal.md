---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json.Internal Namespace"
---
| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator](/api/corvus-text-json-internal-arrayenumerator.html) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [ArrayReverseEnumerator](/api/corvus-text-json-internal-arrayreverseenumerator.html) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [BigIntegerPolyfills](/api/corvus-text-json-internal-bigintegerpolyfills.html) | class | Polyfills for [`BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) methods that are not available in all target frameworks. |
| [BuildWithContext](/api/corvus-text-json-internal-buildwithcontext.html) | class |  |
| [BuildWithContext<TContext, TBuilder>](/api/corvus-text-json-internal-buildwithcontext-tcontext-tbuilder.html) | struct |  |
| [CodeGenDataType](/api/corvus-text-json-internal-codegendatatype.html) | enum | Specifies the data type used in code generation scenarios. |
| [CodeGenNumericType](/api/corvus-text-json-internal-codegennumerictype.html) | enum | Specifies the numeric type used in code generation scenarios. |
| [CodeGenThrowHelper](/api/corvus-text-json-internal-codegenthrowhelper.html) | class | Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json. This class centralizes exception creation and throwing logic to ensure consistent erro... |
| [ComplexValueBuilder](/api/corvus-text-json-internal-complexvaluebuilder.html) | struct | Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an \[`IMutableJsonDocument`\](/api/corvus-text-json-internal-imutablejsondocument.... |
| [ComplexValueBuilder.ComplexValueHandle](/api/corvus-text-json-internal-complexvaluebuilder-complexvaluehandle.html) | struct |  |
| [ComplexValueBuilder.ValueBuilderAction](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction.html) | delegate |  |
| [ComplexValueBuilder.ValueBuilderAction<TContext>](/api/corvus-text-json-internal-complexvaluebuilder-valuebuilderaction-tcontext.html) | delegate |  |
| [EnumeratorCreator](/api/corvus-text-json-internal-enumeratorcreator.html) | class |  |
| [FixedStringJsonDocument<T>](/api/corvus-text-json-internal-fixedstringjsondocument-t.html) | class | Represents a JSON document based on a fixed string value. |
| [IJsonDocument](/api/corvus-text-json-internal-ijsondocument.html) | interface | The interface explicitly implemented by JSON Document providers for internal use only. |
| [IJsonElement](/api/corvus-text-json-internal-ijsonelement.html) | interface | Implemented by JsonElement-derived types. |
| [IJsonElement<T>](/api/corvus-text-json-internal-ijsonelement-t.html) | interface | Implemented by JsonElement-derived types. |
| [IMutableJsonDocument](/api/corvus-text-json-internal-imutablejsondocument.html) | interface | Represents a mutable JSON document that supports editing and value storage operations. |
| [IMutableJsonElement<T>](/api/corvus-text-json-internal-imutablejsonelement-t.html) | interface | Represents a mutable JSON element of type `T`. |
| [JsonDocument](/api/corvus-text-json-internal-jsondocument.html) | class | Base class for JSON document implementations providing common functionality for parsing and accessing JSON data. |
| [JsonElementHelpers](/api/corvus-text-json-internal-jsonelementhelpers.html) | class | Core helper methods for parsing and processing JSON numeric values into their component parts. |
| [JsonElementTensorHelpers](/api/corvus-text-json-internal-jsonelementtensorhelpers.html) | class | Helper methods for JSON element for conversion to tensors. |
| [JsonRegexOptions](/api/corvus-text-json-internal-jsonregexoptions.html) | enum |  |
| [JsonSchemaContext](/api/corvus-text-json-internal-jsonschemacontext.html) | struct | The context for a JSON schema evaluation. |
| [JsonSchemaContext.EvaluatedIndexBuffer](/api/corvus-text-json-internal-jsonschemacontext-evaluatedindexbuffer.html) | struct |  |
| [JsonSchemaEvaluation](/api/corvus-text-json-internal-jsonschemaevaluation.html) | class | Support for JSON Schema matching implementations. |
| [JsonSchemaMatcher](/api/corvus-text-json-internal-jsonschemamatcher.html) | delegate | A matcher for a JSON schema. |
| [JsonSchemaMatcherWithRequiredBitBuffer](/api/corvus-text-json-internal-jsonschemamatcherwithrequiredbitbuffer.html) | delegate | A matcher for a JSON schema that requires a bit buffer for tracking required properties. |
| [JsonTokenType](/api/corvus-text-json-internal-jsontokentype.html) | enum | This enum defines the various JSON tokens that make up a JSON text and is used by the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) when moving from one token to the next. The \[`Utf... |
| [MetadataDb](/api/corvus-text-json-internal-metadatadb.html) | struct | Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements. |
| [NormalizedJsonNumber](/api/corvus-text-json-internal-normalizedjsonnumber.html) | struct | Represents a normalized JSON number. |
| [ObjectEnumerator](/api/corvus-text-json-internal-objectenumerator.html) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [PropertySchemaMatchers<T>](/api/corvus-text-json-internal-propertyschemamatchers-t.html) | class | A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance. |
| [PropertySchemaMatchers<T>.UnescapedNameProvider<T>](/api/corvus-text-json-internal-propertyschemamatchers-t-unescapednameprovider-t.html) | delegate |  |
| [RentedBacking](/api/corvus-text-json-internal-rentedbacking.html) | struct | Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](/api/corvus-text-json-internal-simpletypesbacking.html). |
| [RentedBacking.Writer<T>](/api/corvus-text-json-internal-rentedbacking-writer-t.html) | delegate |  |
| [SimpleTypesBacking](/api/corvus-text-json-internal-simpletypesbacking.html) | struct | Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) creation. |
| [SimpleTypesBacking.Writer<T>](/api/corvus-text-json-internal-simpletypesbacking-writer-t.html) | delegate |  |
| [UniqueItemsHashSet](/api/corvus-text-json-internal-uniqueitemshashset.html) | struct | A map that can be built |
| [UniqueItemsHashSet.UnescapedNameProvider](/api/corvus-text-json-internal-uniqueitemshashset-unescapednameprovider.html) | delegate |  |
| [Utf8UriComponents](/api/corvus-text-json-internal-utf8uricomponents.html) | enum | Specifies the parts of a URI that should be included when retrieving URI components. |
| [Utf8UriFormat](/api/corvus-text-json-internal-utf8uriformat.html) | enum | Specifies the format options for URI string representation. |
| [Utf8UriKind](/api/corvus-text-json-internal-utf8urikind.html) | enum | Defines the kind of URI, controlling whether absolute or relative URIs are used. |

