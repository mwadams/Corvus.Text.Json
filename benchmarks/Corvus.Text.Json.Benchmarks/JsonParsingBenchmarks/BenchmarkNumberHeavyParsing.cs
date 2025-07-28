// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BenchmarkDotNet.Attributes;
using System.Text;

namespace JsonParsingBenchmarks;

/// <summary>
/// Benchmark for parsing JSON with many numbers in various formats.
/// Tests numeric parsing performance with integers, floats, scientific notation, etc.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkNumberHeavyParsing
{
    private string? numberHeavyJson;

    [GlobalSetup]
    public void Setup()
    {
        // Number-heavy JSON - tests numeric parsing performance
        numberHeavyJson = GenerateNumberHeavyJson();
    }

    [Benchmark]
    public double ParseNumberHeavyCorvus()
    {
        using var document = Corvus.Text.Json.ParsedJsonDocument<Corvus.Text.Json.JsonElement>.Parse(numberHeavyJson!);
        var root = document.RootElement;

        double sum = 0;

        if (root.ValueKind == Corvus.Text.Json.JsonValueKind.Object)
        {
            foreach (var property in root.EnumerateObject())
            {
                if (property.Value.ValueKind == Corvus.Text.Json.JsonValueKind.Number)
                {
                    if (property.Value.TryGetDouble(out var number))
                    {
                        sum += number;
                    }
                }
            }
        }

        return sum;
    }

    [Benchmark(Baseline = true)]
    public double ParseNumberHeavySystemTextJson()
    {
        using var document = System.Text.Json.JsonDocument.Parse(numberHeavyJson!);
        var root = document.RootElement;

        double sum = 0;

        if (root.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            foreach (var property in root.EnumerateObject())
            {
                if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Number)
                {
                    if (property.Value.TryGetDouble(out var number))
                    {
                        sum += number;
                    }
                }
            }
        }

        return sum;
    }

    #region JSON Generation

    private static string GenerateNumberHeavyJson()
    {
        var sb = new StringBuilder();
        sb.AppendLine("{");

        var random = new Random(42); // Fixed seed for consistent benchmarks

        for (int i = 0; i < 1000; i++)
        {
            if (i > 0) sb.AppendLine(",");

            string value = (i % 10) switch
            {
                0 => random.Next(-1000000, 1000000).ToString(),
                1 => (random.NextDouble() * 1000000 - 500000).ToString("F6"),
                2 => (random.NextDouble() * 1e10).ToString("E"),
                3 => (random.NextDouble() * 1e-10).ToString("E"),
                4 => "0",
                5 => "-0",
                6 => random.Next(0, 2) == 0 ? int.MaxValue.ToString() : int.MinValue.ToString(),
                7 => (Math.PI * random.NextDouble() * 1000).ToString("F15"),
                8 => (random.NextDouble() * 1e100).ToString("E"),
                _ => ((random.NextDouble() < 0.5 ? -1 : 1) * random.NextDouble() * Math.Pow(10, random.Next(-50, 50))).ToString("E")
            };

            sb.Append($"  \"number_{i}\": {value}");
        }

        sb.AppendLine();
        sb.AppendLine("}");
        return sb.ToString();
    }

    #endregion
}
