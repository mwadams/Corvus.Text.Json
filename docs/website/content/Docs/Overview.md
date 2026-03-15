---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Documentation"
---
Corvus.Text.Json documentation covers the core APIs, migration guides, and reference material for building high-performance JSON applications in .NET.

## [Parsing & Reading JSON](/docs/parsed-json-document.html)

Parse JSON into read-only, strongly-typed models backed by pooled memory. `ParsedJsonDocument<T>` is a high-performance alternative to `System.Text.Json`'s `JsonDocument` — it adds generic type support, zero-copy element access, and `ArrayPool<byte>`-backed parsing so you can handle high-throughput workloads with minimal GC impact. Learn about parsing from strings, streams, and byte arrays; navigating JSON structures; extracting values including NodaTime types and extended numerics; and serialization patterns for web APIs and data pipelines.

## [Building & Mutating JSON](/docs/json-document-builder.html)

Create and modify JSON documents in-place with workspace-managed pooled memory. `JsonDocumentBuilder<T>` and `JsonWorkspace` are a builder-pattern alternative to `System.Text.Json`'s `JsonNode` — instead of per-node heap allocations, a shared workspace pools memory across operations, making it ideal for request/response cycles and data pipelines. Learn how to create documents from scratch, modify properties in-place, work with nested structures, and serialize with zero-allocation writer rentals.

## [Migrating from V4 to V5](/docs/migrating-from-v4-to-v5.html)

A comprehensive guide for migrating code from the V4 code generator (`Corvus.Json`) to V5 (`Corvus.Text.Json`). Covers package and namespace changes, the shift from functional `With*()` mutation to imperative `Set*()` mutation, parsing changes, validation API differences, composition types, and a quick reference table mapping V4 patterns to V5 equivalents.
