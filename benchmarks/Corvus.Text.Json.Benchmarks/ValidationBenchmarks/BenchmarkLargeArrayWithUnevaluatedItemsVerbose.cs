// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BenchmarkDotNet.Attributes;
using Corvus.Json;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkLargeArrayWithUnevaluatedItemsVerbose
{
    private System.Text.Json.JsonDocument? documentA1;
    private Corvus.Text.Json.ParsedJsonDocument<Benchmark.CorvusTextJson2.PersonArray>? documentB1;
    private Corvus.Text.Json.JsonDocumentBuilder<Benchmark.CorvusTextJson2.PersonArray.Mutable>? documentB2;
    private Corvus.Text.Json.JsonWorkspace? workspace;

    [GlobalCleanup]
    public void CleanUp()
    {
        documentA1?.Dispose();
        documentB1?.Dispose();
        documentB2?.Dispose();
        workspace?.Dispose();
    }

    [GlobalSetup]
    public void Setup()
    {
        const string personJson = """
        {
            "name": { "firstName": "Michael", "lastName": "Adams", "otherNames": ["Francis", "James"] },
            "age": 52,
            "competedInYears": [2012, 2016, 2024]
        }
        """;

        // prefix item plus 10,000 names
        string json =
            "[33.4," + string.Join(",", Enumerable.Range(0, 10000).Select(i => personJson)) + "]";

        documentA1 = System.Text.Json.JsonDocument.Parse(json);
        documentB1 = Corvus.Text.Json.ParsedJsonDocument<Benchmark.CorvusTextJson2.PersonArray>.Parse(json);
        workspace = Corvus.Text.Json.JsonWorkspace.Create();
        documentB2 = documentB1.RootElement.CreateDocumentBuilder(workspace);
    }

    [Benchmark(Baseline = true)]
    public bool ValidateCorvusJsonSchema()
    {
        ValidationContext result = Benchmark.CorvusJsonSchema2.PersonArray.FromJson(documentA1!.RootElement).Validate(ValidationContext.ValidContext, ValidationLevel.Verbose);
        return result.IsValid;
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        using Corvus.Text.Json.JsonSchemaResultsCollector collector = Corvus.Text.Json.JsonSchemaResultsCollector.Create(Corvus.Text.Json.JsonSchemaResultsLevel.Verbose);
        return documentB1!.RootElement.EvaluateSchema(collector);
    }

    [Benchmark]
    public bool ValidateCorvusTextJsonDynamic()
    {
        using Corvus.Text.Json.JsonSchemaResultsCollector collector = Corvus.Text.Json.JsonSchemaResultsCollector.Create(Corvus.Text.Json.JsonSchemaResultsLevel.Verbose);
        return documentB2!.RootElement.EvaluateSchema(collector);
    }
}
