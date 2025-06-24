using Benchmark.CorvusTextJson2;
using Corvus.Text.Json;

using JsonWorkspace workspace = JsonWorkspace.Create();

using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.CreateDocumentBuilder(
    workspace,
    age: 51,
    name: new(static (ref personName) =>
    {
        personName.Create(
            firstName: "Michael"u8,
            lastName: "Adams"u8,
            otherNames: new(static (ref otherNames) =>
            {
                otherNames.Add("Francis"u8);
                otherNames.Add("James"u8);
            }));
    }),
    competedInYears: CompetedInYears.Source.FromArray([2012, 2016, 2024]));

Person person = docBuilder.RootElement;

EvaluateAndWriteResultsFlagOnly(person);
EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Basic);
EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Detailed);
EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Verbose);

string brokenJson =
    """
    {
        "age": 51,
        "name": {
            "firstName": "Michael",
            "lastName": 123,
            "otherNames": ["Francis", "James"]
        },
        "competedInYears": [2012, 2016, 2024]
    }
    """;

using var brokenPersonDoc = ParsedJsonDocument<Person>.Parse(brokenJson);
Person brokenPerson = brokenPersonDoc.RootElement;

EvaluateAndWriteResultsFlagOnly(brokenPerson);
EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Basic);
EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Detailed);
EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Verbose);

static void EvaluateAndWriteResultsFlagOnly(Person person)
{
    bool personEvaluationResult = person.EvaluateSchema();

    Console.WriteLine();
    Console.WriteLine("************");
    Console.WriteLine($"Evaluated Flag: {personEvaluationResult}\r\n{person}");
    Console.WriteLine("************");
    Console.WriteLine();
    Console.WriteLine("== Results ==");
    Console.WriteLine();
    Console.WriteLine("No results.");
    Console.WriteLine("************");
}

static void EvaluateAndWriteResults(Person person, JsonSchemaResultsLevel level)
{
    JsonSchemaResultsCollector collector = JsonSchemaResultsCollector.Create(level);
    bool personEvaluationResult = person.EvaluateSchema(collector);

    Console.WriteLine();
    Console.WriteLine("************");
    Console.WriteLine($"Evaluated {level}: {personEvaluationResult}\r\n{person}");
    Console.WriteLine();
    Console.WriteLine("== Results ==");
    Console.WriteLine();

    if (collector.GetResultCount() == 0)
    {
        Console.WriteLine("No results.");
        Console.WriteLine("************");
        return;
    }

    foreach(JsonSchemaResultsCollector.Result resultItem in collector.EnumerateResults())
    {
        Console.WriteLine($"Evaluated: {resultItem.IsMatch}\r\n\tMessage: \"{resultItem.GetMessageText()}\"\r\n\tat ({resultItem.GetEvaluationLocationText()}, {resultItem.GetSchemaEvaluationLocationText()}, {resultItem.GetDocumentEvaluationLocationText()})");
    }

    Console.WriteLine("************");
}
