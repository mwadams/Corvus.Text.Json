---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json.Internal Namespace"
---
# Corvus.Text.Json.Internal Namespace

| Type | Kind | Description |
|------|------|-------------|
| [ArrayEnumerator](#arrayenumerator) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [ArrayReverseEnumerator](#arrayreverseenumerator) | struct | Provides an enumerator and enumerable for iterating over the elements of a JSON array in a document. |
| [BigIntegerPolyfills](#bigintegerpolyfills) | class | Polyfills for [`BigInteger`](#BigInteger) methods that are not available in all target frameworks. |
| [BuildWithContext](#buildwithcontext) | class |  |
| [BuildWithContext<TContext, TBuilder>](#buildwithcontext-tcontext,-tbuilder) | struct |  |
| [CodeGenDataType](#codegendatatype) | enum | Specifies the data type used in code generation scenarios. |
| [CodeGenNumericType](#codegennumerictype) | enum | Specifies the numeric type used in code generation scenarios. |
| [CodeGenThrowHelper](#codegenthrowhelper) | class | Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json. This class centralizes exception creation and throwing logic to ensure consistent erro... |
| [ComplexValueBuilder](#complexvaluebuilder) | struct | Provides a high-performance, low-allocation builder for constructing complex JSON values (objects and arrays) within an [`IMutableJsonDocument`](#IMutableJsonDocument). |
| [EnumeratorCreator](#enumeratorcreator) | class |  |
| [FixedStringJsonDocument<T>](#fixedstringjsondocument-t) | class | Represents a JSON document based on a fixed string value. |
| [IJsonDocument](#ijsondocument) | interface | The interface explicitly implemented by JSON Document providers for internal use only. |
| [IJsonElement](#ijsonelement) | interface | Implemented by JsonElement-derived types. |
| [IJsonElement<T>](#ijsonelement-t) | interface | Implemented by JsonElement-derived types. |
| [IMutableJsonDocument](#imutablejsondocument) | interface | Represents a mutable JSON document that supports editing and value storage operations. |
| [IMutableJsonElement<T>](#imutablejsonelement-t) | interface | Represents a mutable JSON element of type `T`. |
| [JsonDocument](#jsondocument) | class | Base class for JSON document implementations providing common functionality for parsing and accessing JSON data. |
| [JsonElementHelpers](#jsonelementhelpers) | class | Core helper methods for parsing and processing JSON numeric values into their component parts. |
| [JsonElementTensorHelpers](#jsonelementtensorhelpers) | class | Helper methods for JSON element for conversion to tensors. |
| [JsonRegexOptions](#jsonregexoptions) | enum |  |
| [JsonSchemaContext](#jsonschemacontext) | struct | The context for a JSON schema evaluation. |
| [JsonSchemaEvaluation](#jsonschemaevaluation) | class | Support for JSON Schema matching implementations. |
| [JsonSchemaMatcher](#jsonschemamatcher) | delegate | A matcher for a JSON schema. |
| [JsonSchemaMatcherWithRequiredBitBuffer](#jsonschemamatcherwithrequiredbitbuffer) | delegate | A matcher for a JSON schema that requires a bit buffer for tracking required properties. |
| [JsonTokenType](#jsontokentype) | enum | This enum defines the various JSON tokens that make up a JSON text and is used by the [`Utf8JsonReader`](#Utf8JsonReader) when moving from one token to the next. The [`Utf8JsonReader`](#Utf8JsonRea... |
| [MetadataDb](#metadatadb) | struct | Database storing metadata for parsed JSON document structure, including token information and structural relationships between JSON elements. |
| [NormalizedJsonNumber](#normalizedjsonnumber) | struct | Represents a normalized JSON number. |
| [ObjectEnumerator](#objectenumerator) | struct | An enumerable and enumerator for the properties of a JSON object. |
| [PropertySchemaMatchers<T>](#propertyschemamatchers-t) | class | A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance. |
| [RentedBacking](#rentedbacking) | struct | Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](#SimpleTypesBacking). |
| [SimpleTypesBacking](#simpletypesbacking) | struct | Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](#IJsonElement) creation. |
| [UniqueItemsHashSet](#uniqueitemshashset) | struct | A map that can be built |
| [Utf8UriComponents](#utf8uricomponents) | enum | Specifies the parts of a URI that should be included when retrieving URI components. |
| [Utf8UriFormat](#utf8uriformat) | enum | Specifies the format options for URI string representation. |
| [Utf8UriKind](#utf8urikind) | enum | Defines the kind of URI, controlling whether absolute or relative URIs are used. |


> Detailed type documentation for each type listed above will be available in future updates.
