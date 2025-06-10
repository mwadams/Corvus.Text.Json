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
public class BenchmarkMatchUriTemplate
{
    private System.Text.Json.JsonDocument? _cjsUriTemplate;
    private JsonUriTemplate _cjsUriTemplateElement;
    private ParsedJsonDocument<JsonElement>? _ctjUriTemplate;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _cjsUriTemplate = System.Text.Json.JsonDocument.Parse("\"http://foo.bar/{?var}/?q=Test%20URL-encoded%20stuff\"");
        _ctjUriTemplate = ParsedJsonDocument<JsonElement>.Parse("\"http://foo.bar/{?var}/?q=Test%20URL-encoded%20stuff\"");
        _cjsUriTemplateElement = JsonUriTemplate.FromJson(_cjsUriTemplate.RootElement);
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _cjsUriTemplate?.Dispose();
        _ctjUriTemplate?.Dispose();
    }

    [Benchmark(Baseline = true)]
    public bool ValidateCorvusJsonSchema()
    {
        ValidationContext result = ValidateWithoutCoreType.TypeUriTemplate(_cjsUriTemplateElement, ValidationContext.ValidContext, ValidationLevel.Flag);
        return result.IsValid;
    }

    [Benchmark]
    public bool ValidateCorvusTextJson()
    {
        // This is normally all wrapped up in codegen; you don't have to do this yourself.
        JsonSchemaContext context = JsonSchemaContext.BeginContext(_ctjUriTemplate!, 0, false, false);

        try
        {
            return JsonSchemaMatching.MatchUriTemplate("http://foo.bar/{?var}/?q=Test%20URL-encoded%20stuff"u8, DummyPathProvider, ref context);
        }
        finally
        {
            context.Dispose();
        }
    }

    private static bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

}
