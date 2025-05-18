// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    /// <summary>
    /// A matcher for a JSON schema.
    /// </summary>
    /// <param name="parentDocument"></param>
    /// <param name="parentDocumentIndex"></param>
    /// <param name="context"></param>
    [CLSCompliant(false)]
    public delegate void JsonSchemaMatcherWithRequiredBitBuffer(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer);

    /// <summary>
    /// A matcher for a JSON schema.
    /// </summary>
    /// <param name="parentDocument"></param>
    /// <param name="parentDocumentIndex"></param>
    /// <param name="context"></param>
    [CLSCompliant(false)]
    public delegate void JsonSchemaMatcher(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context);
}
