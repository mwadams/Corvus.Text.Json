---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "API Reference"
---
The API reference documentation is auto-generated from XML documentation comments in the source code.

## Namespaces

### Corvus.Text.Json

The core namespace containing the primary types for JSON parsing, generation, and manipulation:

- **`ParsedJsonDocument<T>`** — Pooled-memory JSON document parser. The main entry point for parsing JSON from strings, byte arrays, and streams.
- **`JsonElement`** — The fundamental JSON value type, analogous to `System.Text.Json.JsonElement` but with extended type support and mutability.
- **`JsonElement.Mutable`** — The mutable counterpart to `JsonElement`, obtained via `JsonDocumentBuilder`.
- **`JsonDocumentBuilder<T>`** — High-performance builder for creating and modifying JSON documents using pooled workspace memory.
- **`JsonWorkspace`** — Resource manager for pooled buffers and writers used by `JsonDocumentBuilder`.
- **`Utf8JsonWriter`** — Drop-in replacement for `System.Text.Json.Utf8JsonWriter` with workspace integration.
- **`JsonSchemaTypeGeneratorAttribute`** — Attribute for the Roslyn source generator that produces strongly-typed C# from JSON Schema.
- **`JsonSchemaResultsCollector`** — Collector for detailed schema validation results.
- **`UnescapedUtf8JsonString`** / **`UnescapedUtf16JsonString`** — Disposable ref structs for zero-allocation string access.

### Corvus.Numerics

Extended numeric types for arbitrary-precision arithmetic:

- **`BigNumber`** — Arbitrary-precision decimal type for values beyond `decimal`'s 28 significant digits. Supports standard arithmetic operators and formatting.
- **`BigInteger`** — Interop with `System.Numerics.BigInteger` for lossless handling of very large integers.

### Corvus.NodaTimeExtensions

NodaTime type integration for JSON Schema date/time formats:

- **`LocalDate`** extensions — Maps from JSON Schema `format: "date"`.
- **`OffsetDateTime`** extensions — Maps from JSON Schema `format: "date-time"`.
- **`OffsetTime`** extensions — Maps from JSON Schema `format: "time"`.
- **`Period`** extensions — Maps from JSON Schema `format: "duration"`.

These extensions provide `TryGetValue()` and `Get*()` methods on `JsonElement` for direct conversion from JSON string values to NodaTime types, avoiding intermediate `System.DateTime` representations.
