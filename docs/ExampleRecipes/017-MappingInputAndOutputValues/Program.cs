using Corvus.Text.Json;
using MappingInputAndOutputValues.Models;

// Parse source data
string sourceJson = """
    {
      "id": 123,
      "name": "John Doe"
    }
    """;

using var parsedSource = ParsedJsonDocument<SourceType>.Parse(sourceJson);
SourceType source = parsedSource.RootElement;
Console.WriteLine("Source data:");
Console.WriteLine($"  id: {source.Id}");
Console.WriteLine($"  name: {source.Name}");
Console.WriteLine();

// Transform source to target using builder pattern
Console.WriteLine("Transforming source to target...");
using JsonWorkspace workspace = JsonWorkspace.Create();

// Create target using CreateBuilder with a delegate
using var targetBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    // Extract values from source entities and create target
    // Since Source/Target are different schemas, we work with the underlying values
    if (source.Id.TryGetValue(out long idValue) && source.Name.TryGetValue(out string? nameValue))
    {
        b.Create(nameValue, idValue);  // parameters: fullName, identifier (alphabetical)
    }
});

TargetType target = targetBuilder.RootElement;
Console.WriteLine("Target data:");
Console.WriteLine($"  identifier: {target.Identifier}");
Console.WriteLine($"  fullName: {target.FullName}");
Console.WriteLine();
Console.WriteLine("Target JSON:");
Console.WriteLine(target);
Console.WriteLine();

// Demonstrate reverse transformation (target -> source)
Console.WriteLine("Reverse transformation (target -> source)...");
using var sourceBuilder = SourceType.CreateBuilder(workspace, (ref SourceType.Builder b) =>
{
    // Extract from target entities and create source
    if (target.Identifier.TryGetValue(out long identifierValue) && 
        target.FullName.TryGetValue(out string? fullNameValue))
    {
        b.Create(identifierValue, fullNameValue);  // parameters: id, name (alphabetical)
    }
});

SourceType reversedSource = sourceBuilder.RootElement;
Console.WriteLine("Reversed source JSON:");
Console.WriteLine(reversedSource);
Console.WriteLine();

// Demonstrate transformation with modification
Console.WriteLine("Transformation with modification...");
using var modifiedBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    // Extract, transform, then create - shows working with generated types
    if (source.Id.TryGetValue(out long idValue) && source.Name.TryGetValue(out string? nameValue))
    {
        b.Create(nameValue.ToUpperInvariant(), idValue + 1000);  // fullName, identifier
    }
});

TargetType modified = modifiedBuilder.RootElement;
Console.WriteLine("Modified target JSON:");
Console.WriteLine(modified);
