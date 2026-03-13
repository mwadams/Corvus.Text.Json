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

// Transform source to target using builder
Console.WriteLine("Transforming source to target...");
using JsonWorkspace workspace = JsonWorkspace.Create();

// Create target using CreateBuilder
// Property entities are compatible - pass values directly when types match
using var targetBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    b.Create(source.Name, source.Id);
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

// Property entities are compatible in both directions
using var sourceBuilder = SourceType.CreateBuilder(workspace, (ref SourceType.Builder b) =>
{
    b.Create(target.Identifier, target.FullName);
});

SourceType reversedSource = sourceBuilder.RootElement;
Console.WriteLine("Reversed source JSON:");
Console.WriteLine(reversedSource);
Console.WriteLine();

// Demonstrate transformation WITH value modification
Console.WriteLine("Transformation with modification...");

// Only extract to primitives when you need to transform the values
using var modifiedBuilder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    // Extract values when transforming them
    if (source.Id.TryGetValue(out long idValue) && source.Name.TryGetValue(out string? nameValue) && nameValue is not null)
    {
        b.Create(nameValue.ToUpperInvariant(), idValue + 1000);  // fullName, identifier
    }
});

TargetType modified = modifiedBuilder.RootElement;
Console.WriteLine("Modified target JSON:");
Console.WriteLine(modified);
