using Corvus.Text.Json;
using InterfacesAndMixInTypes.Models;

// Parse a composite type from JSON
string compositeJson =
    """
    {
      "budget": 123.7,
      "count": 4,
      "title": "Greeting",
      "description": "Hello world"
    }
    """;

using var parsedComposite = ParsedJsonDocument<CompositeType>.Parse(compositeJson);
CompositeType composite = parsedComposite.RootElement;

Console.WriteLine("Composite type:");
Console.WriteLine(composite);
Console.WriteLine();

// Implicit conversion to each of the composed types (allOf)
// This is similar to implementing multiple interfaces
Documentation documentation = composite;
Countable countable = composite;

Console.WriteLine($"Title: {documentation.Title}");
// Description is an optional property on Documentation - work with the generated type
if (!documentation.Description.IsUndefined())
{
    Console.WriteLine($"Description: {documentation.Description}");
}
Console.WriteLine($"Count: {countable.Count}");
Console.WriteLine($"Budget: {composite.Budget}");
