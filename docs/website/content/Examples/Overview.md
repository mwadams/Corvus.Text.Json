---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Example Recipes — JSON Schema Patterns in .NET"
---
This section contains runnable examples demonstrating common JSON Schema patterns using the V5 code generator (`Corvus.Text.Json`).

Each recipe is a standalone console application with its own JSON Schema, generated model types, and example code. The recipes are ordered by increasing complexity and build on each other conceptually.

## Prerequisites

- .NET 10.0 SDK (or later)
- The solution references the source generator and runtime library via local project references, so no NuGet packages need to be installed separately.

## Running a recipe

```bash
# From the repo root
dotnet run --project docs/ExampleRecipes/001-DataObject/DataObject.csproj

# Or from the recipe directory
cd docs/ExampleRecipes/001-DataObject
dotnet run
```

## Recipes

| # | Recipe | Key Concepts |
|---|---|---|
| [001](/examples/001-data-object/index.html) | Data Object | Parsing, property access, string comparison, serialization, equality |
| [002](/examples/002-data-object-validation/index.html) | Data Object Validation | Schema constraints, `EvaluateSchema()`, detailed validation results |
| [003](/examples/003-reusing-common-types/index.html) | Reusing Common Types | `$ref` / `$defs`, shared nested types |
| [004](/examples/004-open-versus-closed-types/index.html) | Open vs Closed Types | `additionalProperties`, mutable `RemoveProperty` / `SetProperty` |
| [005](/examples/005-extending-a-base-type/index.html) | Extending a Base Type | Schema inheritance via `$ref`, `From()` conversion |
| [006](/examples/006-constraining-a-base-type/index.html) | Constraining a Base Type | Tighter constraints on a base, validation differences |
| [007](/examples/007-strongly-typed-array/index.html) | Strongly Typed Array | Array mutation via builder, indexing, enumeration |
| [008](/examples/008-higher-rank-array/index.html) | Higher Rank Array | 2D arrays, multi-index access |
| [009](/examples/009-working-with-tensors/index.html) | Working with Tensors | 3D tensors, `TryGetNumericValues`, `Build`, `CreateBuilder`, `Rank`, `Dimension` |
| [010](/examples/010-creating-tuples/index.html) | Creating Tuples | `CreateTuple` via builder, `Item1`/`Item2`/`Item3` access |
| [011](/examples/011-interfaces-and-mixin-types/index.html) | Interfaces and Mix-In Types | `allOf` composition, `From()` conversion |
| [012](/examples/012-pattern-matching/index.html) | Pattern Matching | `oneOf`, `Match` with named parameters |
| [013](/examples/013-polymorphism-with-discriminators/index.html) | Polymorphism with Discriminators | `const` discriminator properties, `Match` |
| [014](/examples/014-string-enumerations/index.html) | String Enumerations | String `enum`, `Match` with state |
| [015](/examples/015-numeric-enumerations/index.html) | Numeric Enumerations | Numeric `const`, `ConstInstance`, explicit conversion |
| [016](/examples/016-maps/index.html) | Maps | Typed map (object with `additionalProperties`), builder construction |
| [017](/examples/017-mapping-input-output/index.html) | Mapping Input/Output | Cross-model mapping, `From()`, mutable pipeline |

## Related documentation

- [Getting Started with Code Generation](/getting-started/index.html)
- [ParsedJsonDocument](/docs/parsed-json-document/index.html)
- [JsonDocumentBuilder](/docs/json-document-builder/index.html)
- [Migrating from V4 to V5](/docs/migrating-from-v4-to-v5/index.html)
