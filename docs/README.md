# ParsedJsonDocument and JsonDocumentBuilder Documentation

This folder contains documentation and examples for using the Corvus.Text.Json library.

## Contents

### Documentation

- **[MigratingFromV4ToV5.md](./MigratingFromV4ToV5.md)** - Guide for migrating from Corvus.Json (V4) to Corvus.Text.Json (V5):
  - Overview of architectural changes
  - Package and namespace mapping
  - Parsing, property access, serialization, equality, validation
  - Creating and mutating objects (functional → imperative)
  - Arrays, numeric arrays, tuples, unions, enums
  - Memory management (ParsedJsonDocument, JsonWorkspace)
  - Quick reference table and migration checklist

- **[ParsedJsonDocument.md](./ParsedJsonDocument.md)** - Guide for parsing and reading JSON documents:
  - Overview and key features
  - Basic usage examples
  - Working with arrays and nested objects
  - Parsing options
  - Memory management best practices
  - Performance tips

- **[JsonSchemaSourceGenerator.md](./JsonSchemaSourceGenerator.md)** - Guide for generating strongly-typed C# from JSON Schema:
  - Source generator setup and configuration
  - Working with generated types (properties, arrays, enums)
  - **Mutating generated types** (SetProperty, array mutators)
  - **Default property values** (schema defaults, DefaultInstance)
  - **Property indexers** (string, UTF-8, UTF-16 access)
  - **Composition patterns** (Match discrimination, Apply merging)
  - **RemoveProperty** on generated mutable types
  - Schema references ($ref, $defs)
  - Advanced scenarios (oneOf/anyOf/allOf, pattern properties, formats)
  - Serialization and validation

- **[JsonDocumentBuilder.md](./JsonDocumentBuilder.md)** - Guide for creating and modifying JSON documents:
  - Creating `JsonWorkspace` instances
  - Building documents from primitives
  - Creating objects and arrays
  - Nested structures
  - Modifying existing documents
  - **Property indexers** (string, UTF-8 access on elements)
  - Writing documents to various outputs
  - Memory management and performance tips

### Example Projects

- **[ParsedJsonDocumentExample/](./ParsedJsonDocumentExample/)** - Console application demonstrating `ParsedJsonDocument<T>`:
  - Parsing JSON from strings
  - Parsing JSON from byte arrays
  - Working with arrays (both foreach and indexer)
  - Working with nested objects
  - Enumerating object properties
  - Writing JSON output
  - Using static constants for literals
  - Parsing from streams (synchronous)
  - Parsing from streams (asynchronous)
  - Parsing from file streams

- **[JsonSchemaSourceGeneratorExample/](./JsonSchemaSourceGeneratorExample/)** - Console application demonstrating the JSON Schema source generator:
  - Parsing into strongly-typed generated models
  - Accessing properties and arrays
  - Building documents with nested objects and arrays
  - Modifying properties on mutable types
  - **Property indexers** (UTF-8 and string)
  - **Default property values** (schema defaults)
  - **Removing properties** from mutable documents

- **[JsonDocumentBuilderExample/](./JsonDocumentBuilderExample/)** - Console application demonstrating `JsonDocumentBuilder<T>`:
  - Creating documents from primitives
  - Building object documents
  - Creating nested objects
  - Building arrays
  - Creating arrays of objects
  - Creating from existing documents
  - Modifying documents
  - Building dynamic data
  - Complex nested structures
  - Array item operations (SetItem)
  - Removing properties during building
  - Removing array items (Remove, RemoveRange, RemoveWhere)
  - Building from external API data (enriching, merging, transforming)
  - Writing to files

## Running the Examples

### ParsedJsonDocument Example

```bash
cd ParsedJsonDocumentExample
dotnet run
```

### JsonDocumentBuilder Example

```bash
cd JsonDocumentBuilderExample
dotnet run
```

## Quick Start

### Reading JSON (ParsedJsonDocument)

```csharp
using Corvus.Text.Json;

string json = """
    {
        "name": "John",
        "age": 30
    }
    """;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

JsonElement root = doc.RootElement;
string name = root.GetProperty("name").GetString();
int age = root.GetProperty("age").GetInt32();

Console.WriteLine($"Name: {name}, Age: {age}");
```

### Creating JSON (JsonDocumentBuilder)

```csharp
using Corvus.Text.Json;

using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.BuildDocument(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("name"u8, "John"u8);
        objectBuilder.Add("age"u8, 30);
    }));

Console.WriteLine(doc.RootElement.ToString());
// Output: {"name":"John","age":30}
```

## Important Notes

- **Always dispose**: Both `ParsedJsonDocument<T>` and `JsonDocumentBuilder<T>` use pooled memory and must be disposed
- **Workspace lifetime**: `JsonWorkspace` must outlive all documents created from it
- **Memory lifetime**: When parsing from `ReadOnlyMemory<byte>`, the memory must remain valid for the document's lifetime
- **Thread safety**: Documents and workspaces are not thread-safe; use separate instances per thread
- **Version tracking**: In `JsonDocumentBuilder`, element references become invalid after modifications. Always re-get references from `doc.RootElement` after modifying the document to avoid `InvalidOperationException`

For more detailed information, see the respective documentation files.
