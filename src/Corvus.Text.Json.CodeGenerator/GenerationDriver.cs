using System.Text.Json;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;
using Corvus.Json.CodeGeneration.DocumentResolvers;
using Corvus.Json.CodeGenerator;
using Corvus.Json.Internal;
using Spectre.Console;

namespace Corvus.Text.Json.CodeGenerator;

/// <summary>
/// Drives code generation from our command line model.
/// </summary>
public static class GenerationDriver
{
    internal static async Task<int> GenerateTypes(GeneratorConfig generatorConfig, Engine generationEngine, CancellationToken cancellationToken)
    {
        return generationEngine switch
        {
            Engine.V4 => await GenerationDriverV4.GenerateTypes(generatorConfig, cancellationToken).ConfigureAwait(false),
            Engine.V5 => await GenerationDriverV5.GenerateTypes(generatorConfig, cancellationToken).ConfigureAwait(false),
            _ => throw new NotSupportedException($"Unsupported generation engine: {generationEngine}")
        };
    }
}
