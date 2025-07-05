// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.DocumentResolvers;
using Corvus.Text.Json.CodeGeneration;

namespace TestUtilities
{
    public class TestJsonSchemaCodeGenerator
    {
        private readonly IDocumentResolver _documentResolver;
        private readonly VocabularyRegistry _vocabularyRegistry;
        private readonly JsonSchemaTypeBuilder _jsonSchemaTypeBuilder;
        private readonly IVocabulary _defaultVocabulary;
        private readonly string _rootPath;
        private readonly bool _validateFormat;
        private readonly bool _optionalAsNullable;
        private readonly bool _useImplicitOperatorString;
        private readonly bool _addExplicitUsings;

        public TestJsonSchemaCodeGenerator(string rootPath, bool validateFormat = true, bool optionalAsNullable = false, bool useImplicitOperatorString = false, bool addExplicitUsings = true)
        {
            _rootPath = rootPath;
            _documentResolver = new CompoundDocumentResolver(
                new FakeWebDocumentResolver(_rootPath),
                new FileSystemDocumentResolver()).AddMetaschema();

            _vocabularyRegistry = new();
            Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.RegisterAnalyser(_documentResolver, _vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft201909.VocabularyAnalyser.RegisterAnalyser(_documentResolver, _vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft7.VocabularyAnalyser.RegisterAnalyser(_vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft6.VocabularyAnalyser.RegisterAnalyser(_vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.RegisterAnalyser(_vocabularyRegistry);
            Corvus.Json.CodeGeneration.OpenApi30.VocabularyAnalyser.RegisterAnalyser(_vocabularyRegistry);

            _jsonSchemaTypeBuilder = new(_documentResolver, _vocabularyRegistry);
            _defaultVocabulary = Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.DefaultVocabulary;
            _validateFormat = validateFormat;
            _optionalAsNullable = optionalAsNullable;
            this._useImplicitOperatorString = useImplicitOperatorString;
            this._addExplicitUsings = addExplicitUsings;
        }

        public async Task GenerateCode(string virtualFileName, string jsonSchema)
        {
            string path = Path.Combine(_rootPath, virtualFileName);
            if (SchemaReferenceNormalization.TryNormalizeSchemaReference(path, out string? result))
            {
                path = result;
            }

            _jsonSchemaTypeBuilder.AddDocument(path, JsonDocument.Parse(jsonSchema));

            TypeDeclaration rootType = await _jsonSchemaTypeBuilder.AddTypeDeclarationsAsync(new JsonReference(path), _defaultVocabulary, true);

            var options = new CSharpLanguageProvider.Options(
                $"Test",
                alwaysAssertFormat: _validateFormat,
                optionalAsNullable: _optionalAsNullable,
                useImplicitOperatorString: _useImplicitOperatorString,
                addExplicitUsings: _addExplicitUsings);

            var languageProvider = CSharpLanguageProvider.DefaultWithOptions(options);
            IReadOnlyCollection<GeneratedCodeFile> generatedCode =
                _jsonSchemaTypeBuilder.GenerateCodeUsing(
                languageProvider,
                CancellationToken.None,
                rootType);

            // Set to false if we don't want to emit the types            
#if true
            foreach (var item in generatedCode)
            {
                string outputPath = Path.Combine("D:\\source\\mwadams\\Corvus.Text.Json\\benchmarks\\Corvus.Text.Json.BenchmarkModels\\Test\\", item.FileName);
                File.WriteAllText(outputPath, item.FileContent);
            }
#endif
        }
    }
}
