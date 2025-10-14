// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// Support for JSON Schema matching implementations.
/// </summary>
public static partial class JsonSchemaEvaluation
{
    /// <summary>
    /// Message provider for validation errors when more than one schema matches in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedMoreThanOneSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedMoreThanOneSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when no schema matches in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedNoSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedNoSchema.AsSpan(), buffer, out written);
}
