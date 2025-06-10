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
public class BenchmarkMatchIri
{
    private System.Text.Json.JsonDocument? _cjsIri;
    private JsonIri _cjsIriElement;
    private ParsedJsonDocument<JsonElement>? _ctjIri;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cjsIri = System.Text.Json.JsonDocument.Parse("\"http://ƒøø.ßår/?∂éœ=πîx#πîüx\"");
        _ctjIri = ParsedJsonDocument<JsonElement>.Parse("\"http://ƒøø.ßår/?∂éœ=πîx#πîüx\"");
        _cjsIriElement = JsonIri.FromJson(_cjsIri.RootElement);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _cjsIri?.Dispose();
        _ctjIri?.Dispose();
    }

    [Benchmark(Baseline = true)]
    public bool ValidateCorvusJsonSchema()
    {
        ValidationContext result = ValidateWithoutCoreType.TypeIri(_cjsIriElement, ValidationContext.ValidContext, ValidationLevel.Flag);
        return result.IsValid;
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        // This is normally all wrapped up in codegen; you don't have to do this yourself.
        JsonSchemaContext context = JsonSchemaContext.BeginContext(_ctjIri!, 0, false, false);

        try
        {
            return JsonSchemaMatching.MatchIri("http://ƒøø.ßår/?∂éœ=πîx#πîüx"u8, DummyPathProvider, ref context);
        }
        finally
        {
            context.Dispose();
        }
    }

    private static bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

}
