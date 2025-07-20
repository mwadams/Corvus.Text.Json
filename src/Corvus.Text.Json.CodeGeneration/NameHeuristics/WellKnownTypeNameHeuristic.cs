// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// A name heuristic based on the <see cref="WellKnownTypeDeclarations"/>.
/// </summary>
public sealed class WellKnownTypeNameHeuristic : IBuiltInTypeNameHeuristic
{
    private WellKnownTypeNameHeuristic()
    {
    }

    /// <summary>
    /// Gets a singleton instance of the <see cref="WellKnownTypeNameHeuristic"/>.
    /// </summary>
    public static WellKnownTypeNameHeuristic Instance { get; } = new();

    /// <inheritdoc/>
    public bool IsOptional => false;

    /// <inheritdoc/>
    public uint Priority => 1;

    /// <inheritdoc/>
    public bool TryGetName(ILanguageProvider languageProvider, TypeDeclaration typeDeclaration, JsonReferenceBuilder reference, Span<char> typeNameBuffer, out int written)
    {
        if (typeDeclaration.LocatedSchema.Location.Equals(WellKnownTypeDeclarations.JsonAny.LocatedSchema.Location))
        {
            typeDeclaration.SetDotnetNamespace("Corvus.Text.Json");
            typeDeclaration.SetDotnetTypeName("JsonElement");
            written = 0;
            return true;
        }
        else if (typeDeclaration.LocatedSchema.Location.Equals(WellKnownTypeDeclarations.JsonNotAny.LocatedSchema.Location))
        {
            typeDeclaration.SetDotnetNamespace("Corvus.Text.Json");
            typeDeclaration.SetDotnetTypeName("JsonElementForBooleanFalseSchema");
            written = 0;
            return true;
        }

        written = 0;
        return false;
    }
}
