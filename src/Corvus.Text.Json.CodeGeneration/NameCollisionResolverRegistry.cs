// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// A validation handler registry for implementers of
/// <see cref="ILanguageProvider"/>.
/// </summary>
public sealed class NameCollisionResolverRegistry
{
    private readonly HashSet<INameCollisionResolver> registeredBuilders = [];
    private readonly Dictionary<IKeyword, IReadOnlyCollection<INameCollisionResolver>> buildersByKeyword = [];

    /// <summary>
    /// Gets the registered name heuristics.
    /// </summary>
    public IReadOnlyCollection<INameCollisionResolver> RegisteredCollisionResolvers => this.registeredBuilders;

    /// <summary>
    /// Registers name heuristics with the language provider.
    /// </summary>
    /// <param name="builders">The heuristics to register.</param>
    public void RegisterNameCollisionResolvers(params INameCollisionResolver[] builders)
    {
        foreach (INameCollisionResolver handler in builders)
        {
            this.registeredBuilders.Add(handler);
        }
    }
}
