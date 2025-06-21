// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGenerationExtensions
    {
        private const string JsonSchemaClassNameKey = "CSharp_JsonSchema_JsonSchemaClassNameKey";
        private const string JsonPropertyNamesEscapedClassNameKey = "CSharp_JsonSchema_JsonPropertyNamesEscapedClassNameKey";
        private const string JsonSchemaClassBaseName = "JsonSchema";
        private const string JsonPropertyNamesEscapedClassBaseName = "JsonPropertyNamesEscaped";

        /// <summary>
        /// Make the scoped json schema class name available.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator PushJsonSchemaClassNameAndScope(this CodeGenerator generator)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (!generator.TryPeekMetadata(JsonSchemaClassNameKey, out (string, string) _))
            {
                string jsonSchemaClassName = generator.GetTypeNameInScope(JsonSchemaClassBaseName);
                return generator
                    .PushMetadata(JsonSchemaClassNameKey, (jsonSchemaClassName, generator.GetChildScope(jsonSchemaClassName, null)));
            }

            return generator;
        }

        /// <summary>
        /// Remove the scoped json schema class name.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator PopJsonSchemaClassNameAndScope(this CodeGenerator generator)
        {
            return generator
                .PopMetadata(JsonSchemaClassNameKey);
        }

        /// <summary>
        /// Make the escaped json property names class name available.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        /// <remarks>
        /// This is safe to call multiple times.
        /// </remarks>
        public static CodeGenerator PushJsonPropertyNamesEscapedClassNameAndScope(this CodeGenerator generator)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (generator.TryPeekMetadata(JsonPropertyNamesEscapedClassNameKey, out (string, string) _))
            {
                return generator;
            }

            string jsonPropertyNamesClass = generator.GetTypeNameInScope(JsonPropertyNamesEscapedClassBaseName);
            return generator
                .PushMetadata(JsonPropertyNamesEscapedClassNameKey, (jsonPropertyNamesClass, generator.GetChildScope(jsonPropertyNamesClass, null)));
        }

        /// <summary>
        /// Remove the scoped escaped json property names class name.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator PopJsonPropertyNamesEscapedClassNameAndScope(this CodeGenerator generator)
        {
            return generator
                .PopMetadata(JsonPropertyNamesEscapedClassNameKey);
        }


        /// <summary>
        /// Gets the validation class name.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>The validation class name.</returns>
        public static string JsonSchemaClassName(this CodeGenerator generator)
        {
            if (generator.TryPeekMetadata(JsonSchemaClassNameKey, out (string, string)? value) &&
                value is (string className, string _))
            {
                return className;
            }

            throw new InvalidOperationException("The validation class name has not been created.");
        }

        /// <summary>
        /// Gets the validation class scope.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>The fully-qualified validation class scope.</returns>
        public static string JsonSchemaClassScope(this CodeGenerator generator)
        {
            if (generator.TryPeekMetadata(JsonSchemaClassNameKey, out (string, string)? value) &&
                value is (string _, string scope))
            {
                return scope;
            }

            throw new InvalidOperationException("The validation class scope  has not been created.");
        }

        public static CodeGenerator AppendEvaluateSchemaMethod(this CodeGenerator generator)
        {
            return generator
                .ReserveName("EvaluateSchema")
                .AppendSeparatorLine()
                .AppendBlockIndent(
                    """
                    [MethodImpl(MethodImplOptions.AggressiveInlining)]
                    public bool EvaluateSchema(IJsonSchemaResultsCollector? resultsCollector = null)
                    {
                        return JsonSchema.Evaluate(_parent, _idx, resultsCollector);
                    }
                    """);
        }
    }
}
