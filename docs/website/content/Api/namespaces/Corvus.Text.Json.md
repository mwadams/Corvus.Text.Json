The primary public API for Corvus.Text.Json. This namespace contains the core types for parsing, reading, building, and validating JSON documents using strongly-typed, pooled-memory models generated from JSON Schema.

Key types include `ParsedJsonDocument<T>` (read-only, pooled-memory parsing), `JsonDocumentBuilder<T>` (mutable document construction), `JsonElement` (the immutable value type), `JsonElement.Mutable` (the mutable builder variant), `JsonElement.Source` (for implicit conversions from .NET primitives), `JsonWorkspace` (pooled memory management), and `Utf8JsonReader`/`Utf8JsonWriter` (high-performance streaming I/O).

URI types (`Utf8Uri`, `Utf8IriReference`, etc.) provide zero-allocation URI parsing and validation for JSON Schema format keywords.
