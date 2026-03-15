// Copyright (c) William Adams. All rights reserved.
// Licensed under the Apache-2.0 license.

using BenchmarkDotNet.Attributes;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.DocumentResolvers;

namespace Corvus.Text.Json.CodeGeneration.Benchmarks;

[MemoryDiagnoser]
public class CodeGenerationBenchmarks
{
    private JsonSchemaTypeBuilder typeBuilder = null!;
    private List<TypeDeclaration> simpleTypes = null!;
    private List<TypeDeclaration> complexTypes = null!;
    private List<TypeDeclaration> compositionTypes = null!;
    private List<TypeDeclaration> krakendTypes = null!;

    [GlobalSetup]
    public async Task Setup()
    {
        string schemasDir = Path.Combine(AppContext.BaseDirectory, "Schemas");

        IDocumentResolver documentResolver = new CompoundDocumentResolver(
            new FileSystemDocumentResolver(),
            new HttpClientDocumentResolver(new HttpClient()));

        VocabularyRegistry vocabularyRegistry = new();
        Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.RegisterAnalyser(documentResolver, vocabularyRegistry);
        Corvus.Json.CodeGeneration.Draft7.VocabularyAnalyser.RegisterAnalyser(vocabularyRegistry);

        typeBuilder = new JsonSchemaTypeBuilder(documentResolver, vocabularyRegistry);

        var defaultVocabulary = Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.DefaultVocabulary;

        simpleTypes = [await typeBuilder.AddTypeDeclarationsAsync(
            new JsonReference(Path.Combine(schemasDir, "simple-object.json")),
            defaultVocabulary)];

        complexTypes = [await typeBuilder.AddTypeDeclarationsAsync(
            new JsonReference(Path.Combine(schemasDir, "complex-object.json")),
            defaultVocabulary)];

        compositionTypes = [await typeBuilder.AddTypeDeclarationsAsync(
            new JsonReference(Path.Combine(schemasDir, "composition-type.json")),
            defaultVocabulary)];

        var draft7Vocabulary = Corvus.Json.CodeGeneration.Draft7.VocabularyAnalyser.DefaultVocabulary;

        krakendTypes = [await typeBuilder.AddTypeDeclarationsAsync(
            new JsonReference(Path.Combine(schemasDir, "krakend.json")),
            draft7Vocabulary)];
    }

    private static CSharpLanguageProvider CreateLanguageProvider()
    {
        return CSharpLanguageProvider.DefaultWithOptions(
            new CSharpLanguageProvider.Options("BenchmarkModels"));
    }

    [Benchmark]
    public int SimpleObject()
    {
        var languageProvider = CreateLanguageProvider();
        var files = typeBuilder.GenerateCodeUsing(languageProvider, CancellationToken.None, simpleTypes);
        return files.Count;
    }

    [Benchmark]
    public int ComplexObject()
    {
        var languageProvider = CreateLanguageProvider();
        var files = typeBuilder.GenerateCodeUsing(languageProvider, CancellationToken.None, complexTypes);
        return files.Count;
    }

    [Benchmark]
    public int CompositionType()
    {
        var languageProvider = CreateLanguageProvider();
        var files = typeBuilder.GenerateCodeUsing(languageProvider, CancellationToken.None, compositionTypes);
        return files.Count;
    }

    [Benchmark]
    public int KrakenD()
    {
        var languageProvider = CreateLanguageProvider();
        var files = typeBuilder.GenerateCodeUsing(languageProvider, CancellationToken.None, krakendTypes);
        return files.Count;
    }
}