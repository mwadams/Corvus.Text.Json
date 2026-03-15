// <copyright file="AdditionalSchemaFile.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Text.Json.Validator;

/// <summary>
/// Specifies an additional schema file to preload into the document resolver.
/// </summary>
/// <param name="canonicalUri">The canonical URI for the schema.</param>
/// <param name="filePath">The file path to load the schema from.</param>
public sealed class AdditionalSchemaFile(string canonicalUri, string filePath)
{
    /// <summary>
    /// Gets the canonical URI for the schema.
    /// </summary>
    public string CanonicalUri { get; } = canonicalUri;

    /// <summary>
    /// Gets the file path to load the schema from.
    /// </summary>
    public string FilePath { get; } = filePath;
}