# Corvus.Text.Json

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

High-performance, source-generated, strongly-typed C# models from JSON Schema — with pooled-memory parsing, full draft 4 through 2020-12 validation, and 120B per-document allocation.

## Features

- **Source Generation** — Generate strongly-typed C# from JSON Schema at build time with the Roslyn incremental source generator, or ahead of time with the `generatejsonschematypes` CLI tool.
- **Schema Validation** — Full JSON Schema draft 4, 6, 7, 2019-09, and 2020-12 validation. Over 10× faster than other .NET JSON Schema validators.
- **Pooled Memory** — `ParsedJsonDocument<T>` uses `ArrayPool<byte>` for minimal GC impact. Just 120B per-document vs 1,528B for `JsonNode` — 92% less memory.
- **Mutable Documents** — `JsonDocumentBuilder<T>` and `JsonWorkspace` provide a builder pattern for creating and modifying JSON with pooled workspace memory.
- **Extended Types** — `BigNumber` for arbitrary-precision decimals, `BigInteger` for large integers, plus NodaTime integration for `date`, `date-time`, `time`, and `duration` formats.
- **Pattern Matching** — Type-safe `Match()` for `oneOf`/`anyOf` discriminated unions with exhaustive dispatch.

## Quick Start

```csharp
// 1. Define a schema (Schemas/person.json)
// {
//     "$schema": "https://json-schema.org/draft/2020-12/schema",
//     "type": "object",
//     "required": ["name"],
//     "properties": {
//         "name": { "type": "string", "minLength": 1 },
//         "age": { "type": "integer", "format": "int32", "minimum": 0 }
//     }
// }

// 2. Use the source generator
[JsonSchemaTypeGenerator("Schemas/person.json")]
public readonly partial struct Person;

// 3. Parse and access properties
using var doc = ParsedJsonDocument<Person>.Parse(
    """{"name":"Alice","age":30}""");
Person person = doc.RootElement;

string name = (string)person.Name;           // "Alice"
int age = person.Age;                        // 30

// 4. Validate against the schema
bool valid = person.EvaluateSchema();        // true

// 5. Mutate with the builder pattern
using JsonWorkspace workspace = JsonWorkspace.Create();
using var builder = person.CreateBuilder(workspace);
Person.Mutable root = builder.RootElement;
root.SetAge(31);

Console.WriteLine(root.ToString());
// {"name":"Alice","age":31}
```

## NuGet Packages

| Package | Description |
|---|---|
| **Corvus.Text.Json** | Core runtime library. Required by all generated types. |
| **Corvus.Text.Json.SourceGenerator** | Roslyn incremental source generator. Generates C# from JSON Schema at build time. |
| **Corvus.Text.Json.CodeGenerator** | CLI tool (`generatejsonschematypes`) for ahead-of-time code generation. |
| **Corvus.Text.Json.Validator** | Dynamically load and validate JSON against JSON Schema at runtime using Roslyn. |

### Install

```bash
# Core library
dotnet add package Corvus.Text.Json

# CLI code generator
dotnet tool install --global Corvus.Text.Json.CodeGenerator
```

For the source generator, add as an analyzer reference:

```xml
<PackageReference Include="Corvus.Text.Json.SourceGenerator" Version="5.0.0">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
```

## Target Frameworks

- .NET 10.0, 9.0, 8.0
- .NET Standard 2.0

## Documentation

Full documentation is available at the [Corvus.Text.Json documentation website](docs/website/.output/index.html).

To build and preview the docs locally:

```powershell
cd docs/website
./preview.ps1
```

Then open http://localhost:5000.

### Guides

- [Parsing & Reading JSON](docs/ParsedJsonDocument.md)
- [Building & Mutating JSON](docs/JsonDocumentBuilder.md)
- [Source Generator](docs/SourceGenerator.md)
- [CLI Code Generation](docs/CodeGenerator.md)
- [Dynamic Schema Validation](docs/Validator.md)
- [Migrating from V4](docs/MigratingFromV4ToV5.md)

## Building

```bash
dotnet build Corvus.Text.Json.slnx
```

## Testing

```bash
dotnet test Corvus.Text.Json.slnx --filter "Category!=failing&Category!=outerloop"
```

## Comparison with System.Text.Json

| Feature | System.Text.Json | Corvus.Text.Json |
|---|---|---|
| Read-only parsing | `JsonDocument` (pooled) | `ParsedJsonDocument<T>` (pooled, generic) |
| Mutable documents | `JsonNode` (allocates per node) | Builder pattern on pooled memory |
| Schema validation | None built-in | Draft 4/6/7/2019-09/2020-12 with full diagnostics |
| Code generation | Serialization to/from POCOs | Strongly-typed entities from JSON Schema |
| Date/Time | `DateTime`, `DateTimeOffset` | All .NET types plus NodaTime |
| Numeric precision | `decimal` (28 digits) | `BigNumber` (arbitrary precision), `Int128`, `Half` |
| String/URI handling | .NET string allocation | Zero-allocation UTF-8/UTF-16 access |

## License

Licensed under the MIT License. See [LICENSE.txt](LICENSE.txt).

## About

Corvus.Text.Json is built and maintained by [endjin](https://endjin.com).
