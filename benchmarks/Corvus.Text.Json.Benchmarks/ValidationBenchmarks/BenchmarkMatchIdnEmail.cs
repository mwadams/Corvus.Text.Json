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
public class BenchmarkMatchIdnEmail
{
    private System.Text.Json.JsonDocument? _cjsEmail;
    private JsonIdnEmail _cjsEmailElement;
    private ParsedJsonDocument<JsonElement>? _ctjEmail;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cjsEmail = System.Text.Json.JsonDocument.Parse("\"Dörte@Sörensen.example.com\"");
        _ctjEmail = ParsedJsonDocument<JsonElement>.Parse("\"Dörte@Sörensen.example.com\"");
        _cjsEmailElement = JsonIdnEmail.FromJson(_cjsEmail.RootElement);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _cjsEmail?.Dispose();
        _ctjEmail?.Dispose();
    }

    [Benchmark(Baseline = true)]
    public bool ValidateCorvusJsonSchema()
    {
        ValidationContext result = ValidateWithoutCoreType.TypeIdnEmail(_cjsEmailElement, ValidationContext.ValidContext, ValidationLevel.Flag);
        return result.IsValid;
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        // This is normally all wrapped up in codegen; you don't have to do this yourself.
        JsonSchemaContext context = JsonSchemaContext.BeginContext(_ctjEmail!, 0, false, false);

        try
        {
            return JsonSchemaMatching.MatchIdnEmail("Dörte@Sörensen.example.com"u8, DummyPathProvider, ref context);
        }
        finally
        {
            context.Dispose();
        }
    }

    private bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

}
