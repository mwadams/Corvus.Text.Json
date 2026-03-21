using System.Text.Json;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.DocumentResolvers;
using Corvus.Text.Json.Playground.Models;

namespace Corvus.Text.Json.Playground.Services;

/// <summary>
/// Wraps the V5 code generation pipeline for use in a WASM context.
/// This is the "QuickStart" wrapper that V5 doesn't provide out of the box.
/// </summary>
public class CodeGenerationService
{
    private const string UserSchemaUri = "schema://playground/user-schema.json";

    /// <summary>
    /// Generate C# types from a JSON Schema string.
    /// </summary>
    public async Task<GenerationResult> GenerateAsync(
        string schemaJson,
        string rootNamespace = "Playground",
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Parse the user's schema
            JsonDocument schemaDoc;
            try
            {
                schemaDoc = JsonDocument.Parse(schemaJson);
            }
            catch (JsonException ex)
            {
                return new GenerationResult
                {
                    Success = false,
                    ErrorMessage = $"Invalid JSON: {ex.Message}",
                };
            }

            // Create a prepopulated document resolver (no file I/O, WASM-safe)
            using PrepopulatedDocumentResolver documentResolver = new();
            documentResolver.AddMetaschema();
            documentResolver.AddDocument(UserSchemaUri, schemaDoc);

            // Register vocabulary analyzers (same as GenerationDriverV5)
            VocabularyRegistry vocabularyRegistry = new();
            Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.RegisterAnalyser(documentResolver, vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft201909.VocabularyAnalyser.RegisterAnalyser(documentResolver, vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft7.VocabularyAnalyser.RegisterAnalyser(vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft6.VocabularyAnalyser.RegisterAnalyser(vocabularyRegistry);
            Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.RegisterAnalyser(vocabularyRegistry);
            Corvus.Json.CodeGeneration.OpenApi30.VocabularyAnalyser.RegisterAnalyser(vocabularyRegistry);
            vocabularyRegistry.RegisterVocabularies(
                Corvus.Json.CodeGeneration.CorvusVocabulary.SchemaVocabulary.DefaultInstance);

            IVocabulary defaultVocabulary =
                Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.DefaultVocabulary;

            // Build type declarations
            JsonSchemaTypeBuilder typeBuilder = new(documentResolver, vocabularyRegistry);
            JsonReference reference = new(UserSchemaUri);
            TypeDeclaration rootType = await typeBuilder
                .AddTypeDeclarationsAsync(reference, defaultVocabulary, rebaseAsRoot: false);

            // Configure the C# language provider
            var options = new CodeGeneration.CSharpLanguageProvider.Options(
                rootNamespace,
                addExplicitUsings: true);

            var languageProvider = CodeGeneration.CSharpLanguageProvider.DefaultWithOptions(options);

            // Generate code
            IReadOnlyCollection<GeneratedCodeFile> generatedCode =
                typeBuilder.GenerateCodeUsing(
                    languageProvider,
                    [rootType],
                    cancellationToken);

            // Build the type map from TypeDeclaration metadata
            var typeMap = BuildTypeMap(rootType, generatedCode);

            return new GenerationResult
            {
                Success = true,
                GeneratedFiles = generatedCode,
                TypeMap = typeMap,
            };
        }
        catch (Exception ex)
        {
            return new GenerationResult
            {
                Success = false,
                ErrorMessage = $"Code generation failed: {ex.Message}",
            };
        }
    }

    private static List<TypeMapEntry> BuildTypeMap(
        TypeDeclaration rootType,
        IReadOnlyCollection<GeneratedCodeFile> generatedFiles)
    {
        var entries = new List<TypeMapEntry>();
        var visited = new HashSet<TypeDeclaration>();
        CollectTypeMapEntries(rootType, generatedFiles, entries, visited);
        return entries;
    }

    private static void CollectTypeMapEntries(
        TypeDeclaration typeDecl,
        IReadOnlyCollection<GeneratedCodeFile> generatedFiles,
        List<TypeMapEntry> entries,
        HashSet<TypeDeclaration> visited)
    {
        TypeDeclaration reduced = typeDecl.ReducedTypeDeclaration().ReducedType;
        if (!visited.Add(reduced))
        {
            return;
        }

        string? fullName = generatedFiles
            .Where(f => f.TypeDeclaration == reduced)
            .Select(f => CodeGeneration.CSharpLanguageProvider.GetFullyQualifiedDotnetTypeName(f))
            .FirstOrDefault();

        if (fullName is null)
        {
            return;
        }

        string shortName = fullName.Contains('.')
            ? fullName[(fullName.LastIndexOf('.') + 1)..]
            : fullName;

        string kind = InferKind(reduced);
        string? pointer = reduced.LocatedSchema.Location.ToString();

        var properties = new List<TypeMapProperty>();
        foreach (PropertyDeclaration prop in reduced.PropertyDeclarations)
        {
            string propTypeName = "unknown";
            TypeDeclaration propReduced = prop.ReducedPropertyType.ReducedTypeDeclaration().ReducedType;
            string? propFullName = generatedFiles
                .Where(f => f.TypeDeclaration == propReduced)
                .Select(f => CodeGeneration.CSharpLanguageProvider.GetFullyQualifiedDotnetTypeName(f))
                .FirstOrDefault();

            if (propFullName is not null)
            {
                propTypeName = propFullName.Contains('.')
                    ? propFullName[(propFullName.LastIndexOf('.') + 1)..]
                    : propFullName;
            }

            properties.Add(new TypeMapProperty(
                prop.JsonPropertyName,
                propTypeName,
                prop.ReducedPropertyType.LocatedSchema.Location.ToString(),
                prop.RequiredOrOptional == RequiredOrOptional.Required ||
                    prop.RequiredOrOptional == RequiredOrOptional.ComposedRequired));
        }

        entries.Add(new TypeMapEntry(shortName, fullName, kind, pointer, properties));

        // Recurse into property types
        foreach (PropertyDeclaration prop in reduced.PropertyDeclarations)
        {
            CollectTypeMapEntries(prop.ReducedPropertyType, generatedFiles, entries, visited);
        }
    }

    private static string InferKind(TypeDeclaration typeDecl)
    {
        CoreTypes coreTypes = typeDecl.ImpliedCoreTypes();

        if (coreTypes.HasFlag(CoreTypes.Object))
        {
            return "object";
        }

        if (coreTypes.HasFlag(CoreTypes.Array))
        {
            return "array";
        }

        if (coreTypes.HasFlag(CoreTypes.String))
        {
            return "string";
        }

        if (coreTypes.HasFlag(CoreTypes.Integer))
        {
            return "integer";
        }

        if (coreTypes.HasFlag(CoreTypes.Number))
        {
            return "number";
        }

        if (coreTypes.HasFlag(CoreTypes.Boolean))
        {
            return "boolean";
        }

        if (coreTypes.HasFlag(CoreTypes.Null))
        {
            return "null";
        }

        return "unknown";
    }
}
