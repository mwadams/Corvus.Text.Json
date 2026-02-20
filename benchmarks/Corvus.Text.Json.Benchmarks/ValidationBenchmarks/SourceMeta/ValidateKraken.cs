// <copyright file="ValidateLargeDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Corvus.Json.Benchmarking;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class ValidateKraken
{
    private List<Corvus.Text.Json.ParsedJsonDocument<SourceMetaBenchmarkModels.Kraken>> corvusTextJsonDocuments = [];
    private List<Corvus.Json.ParsedValue<CorvusJsonSchema.Kraken>> corvusJsonSchemaDocuments = [];

    /// <summary>
    /// Global setup.
    /// </summary>
    [GlobalSetup]
    public void GlobalSetup()
    {
        foreach (string json in File.ReadAllLines("ValidationBenchmarks/SourceMeta/instances.jsonl"))
        {
            var documentB1 = Corvus.Text.Json.ParsedJsonDocument<SourceMetaBenchmarkModels.Kraken>.Parse(json);
            corvusTextJsonDocuments.Add(documentB1);
            var documentA1 = ParsedValue<CorvusJsonSchema.Kraken>.Parse(json);
            corvusJsonSchemaDocuments.Add(documentA1);
        }
    }

    /// <summary>
    /// Global clean-up.
    /// </summary>
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        foreach (var doc in corvusTextJsonDocuments)
        {
            doc.Dispose();
        }

        foreach (var doc in corvusJsonSchemaDocuments)
        {
            doc.Dispose();
        }
    }

    /// <summary>
    /// Validates using the Corvus.Text.Json types.
    /// </summary>
    [Benchmark(Baseline = true)]
    public bool ValidateKrakenCorvusJsonSchema()
    {
        bool result = true;
        foreach (var doc in corvusJsonSchemaDocuments)
        {
            result = result && doc.Instance.IsValid();
        }

        return result;
    }

    /// <summary>
    /// Validates using the Corvus.Text.Json types.
    /// </summary>
    [Benchmark]
    public bool ValidateKrakenCorvusTextJson()
    {
        bool result = true;
        foreach (var doc in corvusTextJsonDocuments)
        {
            result = result && doc.RootElement.EvaluateSchema();
        }

        return result;
    }
}
