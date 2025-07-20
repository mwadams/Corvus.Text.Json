// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal;

/// <summary>
/// A matcher for a JSON schema that requires a bit buffer for tracking required properties.
/// </summary>
/// <param name="parentDocument">The JSON document containing the element to match.</param>
/// <param name="parentDocumentIndex">The index of the element within the parent document.</param>
/// <param name="context">The schema evaluation context.</param>
/// <param name="requiredBitBuffer">A buffer for tracking which required properties have been matched.</param>
[CLSCompliant(false)]
public delegate void JsonSchemaMatcherWithRequiredBitBuffer(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer);

/// <summary>
/// A matcher for a JSON schema.
/// </summary>
/// <param name="parentDocument">The JSON document containing the element to match.</param>
/// <param name="parentDocumentIndex">The index of the element within the parent document.</param>
/// <param name="context">The schema evaluation context.</param>
[CLSCompliant(false)]
public delegate void JsonSchemaMatcher(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context);
