// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using BenchmarkDotNet.Attributes;
using Corvus.Json;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkUnevaluatedProperties
{
    private System.Text.Json.JsonDocument? documentA1;
    private Corvus.Text.Json.ParsedJsonDocument<Benchmark.CorvusTextJson2.Person>? documentB1;

    [GlobalSetup]
    public void Setup()
    {
        const string json = """
        {
            "name": { "firstName": "Michael", "lastName": "Adams", "otherNames": ["Francis", "James"] },
            "age": 52,
            "competedInYears": [2012, 2016, 2024]
        }
        """;

        this.documentA1 = System.Text.Json.JsonDocument.Parse(json);
        this.documentB1 = Corvus.Text.Json.ParsedJsonDocument<Benchmark.CorvusTextJson2.Person>.Parse(json);
    }

    [GlobalCleanup]
    public void CleanUp()
    {
        this.documentA1?.Dispose();
        this.documentB1?.Dispose();
    }

    [Benchmark(Baseline=true)]
    public bool ValidateCorvusJsonSchema()
    {
        return Benchmark.CorvusJsonSchema2.Person.FromJson(documentA1!.RootElement).IsValid();
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        return documentB1!.RootElement.IsSchemaMatch();
    }
}
