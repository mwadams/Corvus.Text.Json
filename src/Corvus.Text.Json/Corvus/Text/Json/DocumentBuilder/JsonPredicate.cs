// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json;

/// <summary>
/// A predicate for a JSON value.
/// </summary>
/// <typeparam name="T">The type of the JSON value.</typeparam>
/// <param name="item">The instance of the JSON value to test.</param>
/// <returns>The result of evaluating the predicate, <see langword="true"/> of <see langword="false"/>.</returns>
[CLSCompliant(false)]
public delegate bool JsonPredicate<T>(in T item)
    where T : struct, IJsonElement<T>;
