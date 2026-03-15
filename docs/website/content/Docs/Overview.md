---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Documentation"
---
Corvus.Text.Json documentation covers the core APIs, migration guides, and reference material for building high-performance JSON applications in .NET.

## [ParsedJsonDocument](/docs/parsed-json-document.html)

`ParsedJsonDocument<T>` is the primary entry point for parsing JSON. It provides a lightweight, read-only representation backed by `ArrayPool<byte>` pooled memory. Learn about parsing from strings, byte arrays, and streams; navigating JSON structures; extracting strongly-typed values including NodaTime types and extended numerics; and serialization patterns for web APIs and data pipelines.

## [JsonDocumentBuilder](/docs/json-document-builder.html)

`JsonDocumentBuilder<T>` and `JsonWorkspace` provide the mutable counterpart to `ParsedJsonDocument`. Learn how to create JSON documents from scratch using the builder pattern, modify existing documents in-place, work with nested objects and arrays, rent writers from the workspace for zero-allocation serialization, and integrate with ASP.NET Core pipelines.

## [Migrating from V4 to V5](/docs/migrating-from-v4.html)

A comprehensive guide for migrating code from the V4 code generator (`Corvus.Json`) to V5 (`Corvus.Text.Json`). Covers package and namespace changes, the shift from functional `With*()` mutation to imperative `Set*()` mutation, parsing changes, validation API differences, composition types, and a quick reference table mapping V4 patterns to V5 equivalents.
