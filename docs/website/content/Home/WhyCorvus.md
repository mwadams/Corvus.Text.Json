---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Why Corvus.Text.Json?"
---
Corvus.Text.Json is a ground-up rethink of JSON handling in .NET. Where `System.Text.Json` gives you general-purpose parsing and serialization, Corvus.Text.Json starts from JSON Schema and generates strongly-typed C# models that use pooled memory, validate against the schema, and convert directly to .NET types — all with minimal allocations.

If you're building APIs, data pipelines, or any system that processes JSON at volume, here's what sets it apart:

- **92% fewer allocations** — `ArrayPool<byte>`-backed parsing eliminates GC pressure in high-throughput scenarios. In benchmarks, Corvus.Text.Json allocates 120 bytes vs 1,528 bytes for equivalent `JsonNode` operations.
- **Full JSON Schema support** — Draft 2019-09 and 2020-12 with complete validation diagnostics including schema location, evaluation path, and error messages for every failure. Not just basic type checking.
- **Source-generated models** — A Roslyn incremental source generator or `generatejsonschematypes` CLI tool produces strongly-typed C# from any JSON Schema. You get type-safe property accessors, validation, serialization, and implicit conversions from a single schema file.
- **NodaTime integration** — JSON Schema `date`, `date-time`, `time`, and `duration` formats map to NodaTime types (`LocalDate`, `OffsetDateTime`, `OffsetTime`, `Period`), not error-prone `System.DateTime`.
- **Mutable builder pattern** — `JsonDocumentBuilder` with `JsonWorkspace`-managed pooled memory, not per-node allocations like `JsonNode`. Ideal for request/response cycles and data pipelines.
- **Extended numeric types** — `BigNumber` for arbitrary-precision decimals and `BigInteger` for large integers, going beyond `decimal`'s 28 significant digits.

## Comparison

| Feature | System.Text.Json | Corvus.Text.Json |
|---------|-----------------|-----------------|
| Memory Model | Per-document allocations | ArrayPool-backed pooled memory |
| Schema Validation | None built-in | Full draft 2020-12 with diagnostics |
| Code Generation | None | Source generator + CLI tool |
| Date/Time Types | System.DateTime | NodaTime (LocalDate, OffsetDateTime) |
| Mutation | JsonNode (allocates per node) | Builder pattern (pooled workspace) |
| Numeric Precision | decimal (28 digits) | BigNumber (arbitrary precision) |
