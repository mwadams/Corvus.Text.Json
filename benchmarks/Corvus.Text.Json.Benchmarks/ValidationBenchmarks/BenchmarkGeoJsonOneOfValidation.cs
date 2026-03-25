// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

#if NET

using BenchmarkDotNet.Attributes;
using Corvus.Text.Json;

namespace ValidationBenchmarks;

/// <summary>
/// Benchmark for oneOf validation using the sourcemeta GeoJSON schema.
/// Compares CLI-generated baseline (frozen) vs source-generated (current) code.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkGeoJsonOneOfValidation
{
    private ParsedJsonDocument<Corvus.GeoJsonBenchmark.Baseline.GeojsonSchema>[]? baselineDocuments;
    private ParsedJsonDocument<Corvus.GeoJsonBenchmark.Current.GeoJsonSchema>[]? currentDocuments;

    [GlobalSetup]
    public void Setup()
    {
        string instancesPath = Path.Combine(
            AppContext.BaseDirectory,
            "geojson-instances.jsonl");

        string[] lines = File.ReadAllLines(instancesPath);

        baselineDocuments = new ParsedJsonDocument<Corvus.GeoJsonBenchmark.Baseline.GeojsonSchema>[lines.Length];
        currentDocuments = new ParsedJsonDocument<Corvus.GeoJsonBenchmark.Current.GeoJsonSchema>[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            baselineDocuments[i] = ParsedJsonDocument<Corvus.GeoJsonBenchmark.Baseline.GeojsonSchema>.Parse(lines[i]);
            currentDocuments[i] = ParsedJsonDocument<Corvus.GeoJsonBenchmark.Current.GeoJsonSchema>.Parse(lines[i]);
        }
    }

    [GlobalCleanup]
    public void CleanUp()
    {
        if (baselineDocuments is not null)
        {
            foreach (var doc in baselineDocuments)
            {
                doc.Dispose();
            }
        }

        if (currentDocuments is not null)
        {
            foreach (var doc in currentDocuments)
            {
                doc.Dispose();
            }
        }
    }

    [Benchmark(Baseline = true)]
    public int ValidateBaseline()
    {
        int validCount = 0;
        foreach (var doc in baselineDocuments!)
        {
            if (doc.RootElement.EvaluateSchema())
            {
                validCount++;
            }
        }

        return validCount;
    }

    [Benchmark]
    public int ValidateCurrent()
    {
        int validCount = 0;
        foreach (var doc in currentDocuments!)
        {
            if (doc.RootElement.EvaluateSchema())
            {
                validCount++;
            }
        }

        return validCount;
    }
}

#endif