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


    /// <summary>
    /// Message provider for validation errors when all schemas match in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedAllSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedAllSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when all schemas do not match in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider DidNotMatchAllSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_DidNotMatchAllSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when at least one schema matches in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedAtLeastOneSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedAtLeastOneSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when at least one schema matches in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedExactlyOneSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedExactlyOneSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when no schemas matched in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider DidNotMatchAtLeastOneSchema = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_DidNotMatchAtLeastOneSchema.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when at least one constant value matches in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider MatchedAtLeastOneConstantValue = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_MatchedAtLeastOneConstantValue.AsSpan(), buffer, out written);

    /// <summary>
    /// Message provider for validation errors when no constant values matched in a composition constraint.
    /// </summary>
    public static readonly JsonSchemaMessageProvider DidNotMatchAtLeastOneConstantValue = static (buffer, out written) => JsonReaderHelper.TryGetUtf8FromText(SR.JsonSchema_DidNotMatchAtLeastOneConstantValue.AsSpan(), buffer, out written);
}
