# JSON Schema Patterns in .NET - Mapping Input and Output Values

This recipe demonstrates how to efficiently convert between different schema representations of similar entities - a common pattern in layered architectures where data transforms between API, domain, and persistence layers.

## The Pattern

In real-world applications, you often need to map data between different representations:
- **API schema** → **Domain model** → **Database schema**
- **External API response** → **Internal representation**
- **Legacy system format** → **Modern API format**

While these representations often contain similar data, property names and structures may differ. For example:
- API uses `id` and `name`
- Database uses `identifier` and `fullName`
- CRM uses `customerId` and `displayName`

Corvus.Text.Json provides efficient builder patterns for zero-allocation transformations between these formats.

## The Schemas

### source.json (Input format)

```json
{
  "type": "object",
  "required": ["id", "name"],
  "properties": {
    "id": { "type": "integer" },
    "name": { "type": "string" }
  }
}
```

### target.json (Output format)

```json
{
  "type": "object",
  "required": ["identifier", "fullName"],
  "properties": {
    "identifier": { "type": "integer" },
    "fullName": { "type": "string" }
  }
}
```

These are independent schemas that could be defined in different assemblies or namespaces. The generated types don't need to know about each other.

## Generated Code Usage

### Parsing the source data

```csharp
string sourceJson = """
    {
      "id": 123,
      "name": "John Doe"
    }
    """;

using var parsedSource = ParsedJsonDocument<SourceType>.Parse(sourceJson);
SourceType source = parsedSource.RootElement;
Console.WriteLine($"Source - id: {source.Id}, name: {source.Name}");
// Output: Source - id: 123, name: John Doe
```

## Three Levels of Transformation

This recipe demonstrates three transformation patterns with increasing complexity:

### Level 1: Zero-Allocation Property Mapping

Use `From()` to convert property entities between compatible schemas without extracting primitive values:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using var parsedSource = ParsedJsonDocument<SourceType>.Parse(sourceJson);
SourceType source = parsedSource.RootElement;

// Map to target type - use From() to convert property entities (no allocation)
using var targetBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    b.Create(TargetType.FullNameEntity.From(source.Name), TargetType.IdentifierEntity.From(source.Id));
});

TargetType target = targetBuilder.RootElement;
Console.WriteLine($"Target - identifier: {target.Identifier}, fullName: {target.FullName}");
// Output: Target - identifier: 123, fullName: John Doe
```

**Key points:**
- Property entity types are compatible when their schemas match (both are strings, both are integers, etc.)
- Use `TargetEntityType.From(sourceProperty)` to explicitly convert between compatible entity types
- `From()` creates a zero-allocation view over the same underlying JSON data
- No string allocation occurs - both source and target reference the same parsed data

### Level 2: Bidirectional Mapping

The same pattern works in reverse to map target back to source:

```csharp
// Reverse transformation (target -> source)
using var sourceBuilder = SourceType.CreateBuilder(workspace, (ref SourceType.Builder b) =>
{
    b.Create(SourceType.IdEntity.From(target.Identifier), SourceType.NameEntity.From(target.FullName));
});

SourceType reversedSource = sourceBuilder.RootElement;
Console.WriteLine(reversedSource);
// Output: {"id":123,"name":"John Doe"}
```

This demonstrates that compatibility works bidirectionally - you can map from source to target and back again using the same zero-allocation pattern.

### Level 3: Transformation with Value Modification

Only use `TryGetValue()` when you need to modify the actual values:

```csharp
using var modifiedBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    // Extract ONLY when transforming values
    if (source.Id.TryGetValue(out long idValue) && source.Name.TryGetValue(out string? nameValue) && nameValue is not null)
    {
        b.Create(nameValue.ToUpperInvariant(), idValue + 1000);
    }
});

TargetType modified = modifiedBuilder.RootElement;
Console.WriteLine(modified);
// Output: {"fullName":"JOHN DOE","identifier":1123}
```

**When to extract:**
- Use `TryGetValue()` only when performing arithmetic operations, string transformations, or other value modifications
- For simple remapping (like Levels 1 and 2), use `From()` to avoid allocation

### Multi-stage transformation pipelines

You can chain multiple transformations efficiently using the same workspace:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

// Stage 1: API → Domain
using var apiDoc = ParsedJsonDocument<ApiSchema>.Parse(apiJson);
ApiSchema api = apiDoc.RootElement;

DomainModel.Mutable.Source domainSource = DomainModel.Mutable.Build((ref DomainModel.Mutable.Builder b) =>
{
    b.SetEntityId(api.Id);
    b.SetEntityName(api.Name);
    // ... additional transformations
});

using var domainBuilder = DomainModel.Mutable.CreateBuilder(workspace, in domainSource);
DomainModel.Mutable domain = domainBuilder.RootElement;

// Stage 2: Domain → Database
DatabaseRecord.Mutable.Source dbSource = DatabaseRecord.Mutable.Build((ref DatabaseRecord.Mutable.Builder b) =>
{
    b.SetPrimaryKey(domain.EntityId);
    b.SetDisplayName(domain.EntityName);
    // ... additional transformations
});

using var dbBuilder = DatabaseRecord.Mutable.CreateBuilder(workspace, in dbSource);
DatabaseRecord.Mutable db = dbBuilder.RootElement;

// All transformations share the same workspace memory pool
```

## Performance Characteristics

The builder pattern provides several performance benefits:

1. **Workspace-scoped allocations** - All temporary buffers come from `ArrayPool<byte>` via the workspace
2. **Zero-copy transformations** - Property values are referenced, not copied, when possible
3. **Batch operations** - Multiple property sets happen in a single builder construction
4. **Deterministic cleanup** - `using` declarations ensure pooled memory is returned promptly

## Key Differences from V4

### V4 (Corvus.Json)
```csharp
// Create with builder method
TargetType target = TargetType.Create(
    identifier: source.Id,
    fullName: source.Name);

// Or use WithProperty for transformations
TargetType target = TargetType.Empty
    .WithProperty("identifier", source.Id)
    .WithProperty("fullName", source.Name);

// Or use As<T>() for compatible schemas
TargetType target = source.As<TargetType>();
```

### V5 (Corvus.Text.Json)
```csharp
// Use workspace and builder pattern
using JsonWorkspace workspace = JsonWorkspace.Create();

TargetType.Mutable.Source targetSource = TargetType.Mutable.Build((ref TargetType.Mutable.Builder b) =>
{
    b.SetIdentifier(source.Id);
    b.SetFullName(source.Name);
});

using var targetBuilder = TargetType.Mutable.CreateBuilder(workspace, in targetSource);
TargetType.Mutable target = targetBuilder.RootElement;
```

**Key differences:**
- V5 requires explicit `JsonWorkspace` for memory management
- V5 uses builder pattern with `Build()` and `CreateBuilder()` instead of `Create()` or `WithProperty()`
- V5 uses property setters (`SetIdentifier()`, `SetFullName()`) instead of property parameters
- V5 doesn't provide `.As<T>()` cross-schema conversion (use builder pattern)
- V5 provides better performance through workspace-pooled allocations
- V5 makes allocation lifetime explicit through `using` declarations

## Running the Example

```bash
cd docs/ExampleRecipes/017-MappingInputAndOutputValues
dotnet run
```

## Related Patterns

- [001-DataObject](../001-DataObject/) - Creating and manipulating data objects
- [004-OpenVersusClosedTypes](../004-OpenVersusClosedTypes/) - Mutable operations on open types
- [016-Maps](../016-Maps/) - Working with dynamic property sets
- [011-InterfacesAndMixInTypes](../011-InterfacesAndMixInTypes/) - Type composition with `allOf`

## Real-World Scenarios

This pattern is especially useful for:

1. **API Gateways** - Transform external API responses to internal models
2. **Data Layer Mapping** - Convert domain models to database DTOs
3. **Event Transformation** - Reshape events between microservices
4. **Legacy Integration** - Adapt old formats to new schemas
5. **Multi-tenant Systems** - Transform data for different tenant schemas
