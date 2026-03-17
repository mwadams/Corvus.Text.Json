# Running Tests

This guide covers the test projects in the solution and how to run them.

## Quick start

```powershell
# Run the standard test suite (excludes slow stress tests)
dotnet test Corvus.Text.Json.slnx --filter "Category!=failing&Category!=outerloop"
```

Always exclude the `failing` and `outerloop` categories when running the full suite. The `outerloop` tests are long-running stress and thread-safety tests that are not suitable for routine development.

## Test projects

The solution contains five runnable test projects and four supporting model/utility projects.

### Runnable test projects

| Project | Frameworks | Description |
|---------|-----------|-------------|
| `Corvus.Text.Json.Tests` | net9.0, net10.0, net481 | Core library tests — parsing, writing, schema validation, mutable documents, migration equivalence |
| `Corvus.Text.Json.Validator.Tests` | net9.0, net10.0, net481 | Dynamic schema validator (runtime compilation) |
| `Corvus.Text.Json.CodeGenerator.Tests` | net10.0 | CLI code generator |
| `Corvus.Text.Json.Migration.Analyzers.Tests` | net10.0 | V4→V5 migration Roslyn analyzers and code fixes |
| `Corvus.Numerics.Tests` | net9.0, net10.0, net481 | `BigNumber` / `BigInteger` arithmetic |

### Supporting projects (not runnable)

| Project | Purpose |
|---------|---------|
| `Corvus.Text.Json.Tests.GeneratedModels` | Source-generated V5 model types used by the main test suite |
| `Corvus.Text.Json.Tests.GeneratedModels.OptionalAsNullable` | V5 models with `OptionalAsNullable` enabled |
| `Corvus.Text.Json.Tests.MigrationModels.V4` | V4-generated model types (references `src-v4/Corvus.Json.ExtendedTypes`) |
| `Corvus.Text.Json.Tests.MigrationModels.V5` | V5 equivalents of the V4 models |
| `Corvus.JsonSchemaTestSuite.CodeGenerator` | Utility that regenerates xUnit test classes from the JSON Schema Test Suite submodule |

## Running specific test areas

### All V5 library tests

```powershell
dotnet test tests\Corvus.Text.Json.Tests --filter "Category!=failing&Category!=outerloop"
```

This is the main test suite covering the V5 library: reader, writer, parsed documents, mutable documents, schema validation, and generated type behaviour.

### Migration equivalence tests (V4 vs V5)

The `MigrationEquivalenceTests` folder within the main test project compares V4-generated and V5-generated types side-by-side for parsing, serialization, mutation, validation, and property access:

```powershell
dotnet test tests\Corvus.Text.Json.Tests --filter "FullyQualifiedName~MigrationEquivalence&Category!=failing&Category!=outerloop"
```

### Migration analyzer tests

```powershell
dotnet test tests\Corvus.Text.Json.Migration.Analyzers.Tests
```

These test the Roslyn analyzers (CVJ001–CVJ025) and their associated code fixes. No category filter needed — they run quickly.

### JSON Schema Test Suite

Tests are generated from the [JSON Schema Test Suite](https://github.com/json-schema-org/JSON-Schema-Test-Suite) submodule and tagged by draft:

```powershell
# All schema drafts
dotnet test tests\Corvus.Text.Json.Tests --filter "Trait~JsonSchemaTestSuite&Category!=failing&Category!=outerloop"

# A single draft
dotnet test tests\Corvus.Text.Json.Tests --filter "JsonSchemaTestSuite=Draft202012&Category!=failing&Category!=outerloop"
dotnet test tests\Corvus.Text.Json.Tests --filter "JsonSchemaTestSuite=Draft201909&Category!=failing&Category!=outerloop"
dotnet test tests\Corvus.Text.Json.Tests --filter "JsonSchemaTestSuite=Draft7&Category!=failing&Category!=outerloop"
dotnet test tests\Corvus.Text.Json.Tests --filter "JsonSchemaTestSuite=Draft6&Category!=failing&Category!=outerloop"
dotnet test tests\Corvus.Text.Json.Tests --filter "JsonSchemaTestSuite=Draft4&Category!=failing&Category!=outerloop"
```

### Numerics tests

```powershell
dotnet test tests\Corvus.Numerics.Tests
```

### Validator tests

```powershell
dotnet test tests\Corvus.Text.Json.Validator.Tests --filter "Category!=failing&Category!=outerloop"
```

### Code generator tests

```powershell
dotnet test tests\Corvus.Text.Json.CodeGenerator.Tests
```

## Running a single test class or method

```powershell
# Single class
dotnet test Corvus.Text.Json.slnx --filter "ClassName=Corvus.Text.Json.Tests.ParsedJsonDocumentTests&Category!=failing&Category!=outerloop"

# Single method (substring match)
dotnet test Corvus.Text.Json.slnx --filter "FullyQualifiedName~ParseValidUtf8BOM&Category!=failing&Category!=outerloop"
```

## Outerloop (stress) tests

The `[OuterLoop]` attribute (from `Microsoft.DotNet.XUnitExtensions`) marks long-running stress and thread-safety tests. These are excluded from routine runs but should be run before major releases:

```powershell
dotnet test tests\Corvus.Text.Json.Tests --filter "Category=outerloop"
```

## Target framework selection

The main test projects multi-target `net9.0`, `net10.0`, and `net481`. To run against a specific framework:

```powershell
dotnet test tests\Corvus.Text.Json.Tests -f net10.0 --filter "Category!=failing&Category!=outerloop"
dotnet test tests\Corvus.Text.Json.Tests -f net481 --filter "Category!=failing&Category!=outerloop"
```

## Regenerating JSON Schema Test Suite tests

If you update the `JSON-Schema-Test-Suite` submodule, regenerate the test classes:

```powershell
dotnet run --project tests\Corvus.JsonSchemaTestSuite.CodeGenerator
```

This writes xUnit test files into `tests/Corvus.Text.Json.Tests/JsonSchemaTestSuite/`.
