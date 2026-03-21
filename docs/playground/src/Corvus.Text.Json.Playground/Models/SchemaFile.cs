namespace Corvus.Text.Json.Playground.Models;

/// <summary>
/// Represents a JSON Schema file loaded into the playground.
/// </summary>
public class SchemaFile
{
    /// <summary>
    /// Gets or sets the display name for this schema file (e.g. "person.json").
    /// </summary>
    public string Name { get; set; } = "schema.json";

    /// <summary>
    /// Gets or sets the JSON content of the schema.
    /// </summary>
    public string Content { get; set; } = "{\n  \"type\": \"object\"\n}";

    /// <summary>
    /// Gets or sets a value indicating whether this schema should be generated as a root type.
    /// </summary>
    public bool IsRootType { get; set; }
}
