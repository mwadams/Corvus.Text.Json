// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json
{
    /// <summary>
    ///   Represents a specific JSON value within a <see cref="JsonDocument"/>.
    /// </summary>
    public readonly partial struct JsonElementForBooleanFalseSchema
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
        {
            return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
        }

        /// <summary>
        /// JSON Schema support for the <see cref="JsonElement"/>
        /// </summary>
        public static class JsonSchema
        {
            internal static void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
            {
                // You're not allowed to ask about non-value-like entities
                Debug.Assert(parentDocument.GetJsonTokenType(parentIndex) is not
                    JsonTokenType.None or
                    JsonTokenType.EndObject or
                    JsonTokenType.EndArray or
                    JsonTokenType.PropertyName);

                context.EvaluatedBooleanSchema(false);
            }

            internal static bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector? resultsCollector)
            {
                return false;
            }

            /// <summary>
            /// Push the current context as a child context for the <see cref="JsonElement"/> schema evaluation.
            /// </summary>
            /// <typeparam name="T">The type of the instance to which to apply the child context.</typeparam>
            /// <param name="instance">The instance to which to apply the child context.</param>
            /// <param name="context">The current evaluation context.</param>
            /// <param name="schemaEvaluationPath">The (optional) path to the schema being evaluated in the child context.</param>
            /// <param name="documentEvaluationPath">The (optional) path in the document being evaluated in the child context.</param>
            /// <returns>The child context.</returns>
            [CLSCompliant(false)]
            public static JsonSchemaContext PushChildContext<T>(
                in T instance,
                ref JsonSchemaContext context,
                JsonSchemaPathProvider? schemaEvaluationPath = null,
                JsonSchemaPathProvider? documentEvaluationPath = null)
                where T : struct, IJsonElement<T>
            {
                return
                    context.PushChildContext(
                        instance.ParentDocument,
                        instance.ParentDocumentIndex,
                        useEvaluatedItems: false, // We don't use evaluated items
                        useEvaluatedProperties: false,
                        schemaEvaluationPath: schemaEvaluationPath,
                        documentEvaluationPath: documentEvaluationPath);
            }

            /// <summary>
            /// Push the current context as a child context for the <see cref="JsonElement"/> schema evaluation.
            /// </summary>
            /// <typeparam name="T">The type of the instance to which to apply the child context.</typeparam>
            /// <typeparam name="TContext">The type of the context to be passed to the path providers.</typeparam>
            /// <param name="instance">The instance to which to apply the child context.</param>
            /// <param name="providerContext">The context to be passed to the path providers.</param>
            /// <param name="context">The current evaluation context.</param>
            /// <param name="schemaEvaluationPath">The (optional) path to the schema being evaluated in the child context.</param>
            /// <param name="documentEvaluationPath">The (optional) path in the document being evaluated in the child context.</param>
            /// <returns>The child context.</returns>
            [CLSCompliant(false)]
            public static JsonSchemaContext PushChildContext<T, TContext>(
                in T instance,
                ref JsonSchemaContext context,
                TContext providerContext,
                JsonSchemaPathProvider<TContext>? schemaEvaluationPath = null,
                JsonSchemaPathProvider<TContext>? documentEvaluationPath = null)
                where T : struct, IJsonElement<T>
            {
                return
                    context.PushChildContext(
                        instance.ParentDocument,
                        instance.ParentDocumentIndex,
                        useEvaluatedItems: false, // We don't use evaluated items
                        useEvaluatedProperties: false,
                        schemaEvaluationPath: schemaEvaluationPath,
                        documentEvaluationPath: documentEvaluationPath,
                        providerContext: providerContext);
            }
        }
    }
}
