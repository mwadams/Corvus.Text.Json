namespace Corvus.Text.Json.CodeGenerator;

/// <summary>
/// The various schema types that are available.
/// </summary>
public enum SchemaVariant
{
    /// <summary>
    /// No schema variant has been specified.
    /// </summary>
    NotSpecified,

    /// <summary>
    /// JSON Schema Draft 6.
    /// </summary>
    Draft6,

    /// <summary>
    /// JSON Schema Draft 7.
    /// </summary>
    Draft7,

    /// <summary>
    /// JSON Schema Draft 2019-09.
    /// </summary>
    Draft201909,

    /// <summary>
    /// JSON Schema Draft 2020-12.
    /// </summary>
    Draft202012,

    /// <summary>
    /// JSON Schema Draft 4.
    /// </summary>
    Draft4,

    /// <summary>
    /// OpenAPI 3.0 schema.
    /// </summary>
    OpenApi30,
}