using Corvus.Text.Json;
using CreatingTuples.Models;

// Parse a JSON array as a tuple
string threeTupleJson =
    """
    [3, "Hello", false]
    """;

using var parsedTuple = ParsedJsonDocument<ThreeTuple>.Parse(threeTupleJson);
ThreeTuple threeTuple = parsedTuple.RootElement;

Console.WriteLine("Parsed tuple:");
Console.WriteLine(threeTuple);
Console.WriteLine();

// Access the item values via Item1, Item2, Item3 properties
Console.WriteLine($"Item1: {threeTuple.Item1}");
Console.WriteLine($"Item2: {threeTuple.Item2}");
Console.WriteLine($"Item3: {threeTuple.Item3}");
Console.WriteLine();

// Create a tuple via mutable builder
using JsonWorkspace workspace = JsonWorkspace.Create();
using var builtDoc = ThreeTuple.CreateBuilder(workspace, ThreeTuple.Build(static (ref ThreeTuple.Builder b) =>
{
    b.CreateTuple(42, "World", true);
}));
ThreeTuple threeTuple2 = builtDoc.RootElement;

Console.WriteLine("Built tuple (via Build + CreateTuple):");
Console.WriteLine(threeTuple2);
Console.WriteLine();

// Create a tuple directly with Build(sources)
// This Build overload is available for fixed-size tuples (items: false / unevaluatedItems: false)
// It avoids the delegate indirection and is the recommended approach for simple tuple construction.
ThreeTuple.Source tupleSource = ThreeTuple.Build(99, "Direct", false);
using var directDoc = ThreeTuple.CreateBuilder(workspace, tupleSource);
ThreeTuple threeTuple3 = directDoc.RootElement;

Console.WriteLine("Built tuple (via Build from sources):");
Console.WriteLine(threeTuple3);
Console.WriteLine();

// Compare tuples
if (threeTuple.Equals(threeTuple2))
{
    Console.WriteLine("The tuples are equal");
}
else
{
    Console.WriteLine("The tuples are not equal");
}
