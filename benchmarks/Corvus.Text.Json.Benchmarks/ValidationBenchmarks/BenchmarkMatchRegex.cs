// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using BenchmarkDotNet.Attributes;
using Corvus.Json;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkMatchRegex
{
    
    private System.Text.Json.JsonDocument? _cjsRegex;
    private JsonRegex _cjsRegexElement;
    private ParsedJsonDocument<JsonElement>? _ctjRegex;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cjsRegex = System.Text.Json.JsonDocument.Parse("\"\\\\D+(?<digit>\\\\d+)\\\\D+(?<digit>\\\\d+)?\"");
        _ctjRegex = ParsedJsonDocument<JsonElement>.Parse("\"\\\\D+(?<digit>\\\\d+)\\\\D+(?<digit>\\\\d+)?\"");
        _cjsRegexElement = JsonRegex.FromJson(_cjsRegex.RootElement);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _cjsRegex?.Dispose();
        _ctjRegex?.Dispose();
    }

    [Benchmark(Baseline = true)]
    public bool ValidateCorvusJsonSchema()
    {
        ValidationContext result = ValidateWithoutCoreType.TypeRegex(_cjsRegexElement, ValidationContext.ValidContext, ValidationLevel.Flag);
        return result.IsValid;
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        // This is normally all wrapped up in codegen; you don't have to do this yourself.
        JsonSchemaContext context = JsonSchemaContext.BeginContext(_ctjRegex!, 0, false, false);

        try
        {
            return JsonSchemaMatching.MatchRegex("\\D+(?<digit>\\d+)\\D+(?<digit>\\d+)?"u8, DummyPathProvider, ref context);
        }
        finally
        {
            context.Dispose();
        }
    }

    private static bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

}
