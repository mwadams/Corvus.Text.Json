// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   Represents a specific JSON value within a <see cref="JsonDocument"/>.
    /// </summary>
    public readonly partial struct JsonElement
    {
        public static class JsonSchema
        {
            /// <summary>
            /// Applies the JSON schema semantics defined by this type to the instance determined by the given document and index.
            /// </summary>
            /// <param name="parentDocument">The parent document.</param>
            /// <param name="parentIndex">The parent index.</param>
            /// <param name="context">A reference to the validation context, configured with the appropriate values.</param>
            internal static void ApplyJsonSchema(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
            {
                // You're not allowed to ask about non-value-like entities
                Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                    JsonTokenType.None or
                    JsonTokenType.EndObject or
                    JsonTokenType.EndArray or
                    JsonTokenType.PropertyName);

                context.Matched(true);
            }

            [CLSCompliant(false)]
            public static bool IsMatch(IJsonDocument parentDocument, int parentIndex)
            {
                // You're not allowed to ask about non-value-like entities
                Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                    JsonTokenType.None or
                    JsonTokenType.EndObject or
                    JsonTokenType.EndArray or
                    JsonTokenType.PropertyName);

                return true;
            }

            [CLSCompliant(false)]
            public static JsonSchemaContext PushChildContext(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, JsonSchemaPathProvider escapedPropertyPath)
            {
                return
                    context.PushChildContext(
                        parentDocument,
                        parentDocumentIndex,
                        useEvaluatedItems: false, // We don't use evaluated items or properties
                        useEvaluatedProperties: false,
                        documentEvaluationPath: escapedPropertyPath);
            }
        }
    }
}
