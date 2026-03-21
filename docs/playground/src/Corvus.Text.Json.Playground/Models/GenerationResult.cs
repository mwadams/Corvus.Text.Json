using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.Playground.Models;

/// <summary>
/// Result of a code generation operation.
/// </summary>
public class GenerationResult
{
    /// <summary>
    /// Gets or sets a value indicating whether code generation succeeded.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the generated code files (hidden from user, used for compilation).
    /// </summary>
    public IReadOnlyCollection<GeneratedCodeFile> GeneratedFiles { get; set; } = [];

    /// <summary>
    /// Gets or sets the type map entries for display.
    /// </summary>
    public IReadOnlyList<TypeMapEntry> TypeMap { get; set; } = [];

    /// <summary>
    /// Gets or sets the error message if generation failed.
    /// </summary>
    public string? ErrorMessage { get; set; }
}
