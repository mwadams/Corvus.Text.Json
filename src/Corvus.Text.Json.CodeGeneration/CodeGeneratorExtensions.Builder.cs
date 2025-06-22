// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
        private const string BuilderClassNameKey = "CSharp_BuilderClassNameKey";
        private const string BuilderClassBaseName = "Builder";

        /// <summary>
        /// Make the scoped Builder class name available.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator PushBuilderClassNameAndScope(this CodeGenerator generator)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (!generator.TryPeekMetadata(BuilderClassNameKey, out (string, string) _))
            {
                string builderClassName = generator.GetTypeNameInScope(BuilderClassBaseName);
                return generator
                    .PushMetadata(BuilderClassNameKey, (builderClassName, generator.GetChildScope(builderClassName, null)));
            }

            return generator;
        }

        /// <summary>
        /// Remove the scoped json schema class name.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator PopBuilderClassNameAndScope(this CodeGenerator generator)
        {
            return generator
                .PopMetadata(BuilderClassNameKey);
        }

        /// <summary>
        /// Appends the builder 
        /// </summary>
        /// <param name="generator">The generator to which to append the separator line.</param>
        /// <param name="typeDeclaration">The type declaration for which the builder is to be appended.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendBuilder(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }
            string builderName = generator.BuilderClassName();

            generator
                .AppendSeparatorLine()
                .BeginRefStruct(GeneratedTypeAccessibility.Public, builderName);
                ////.AppendBuilderBuildDelegate(generator, typeDeclaration)
                ////.AppendBuilderSourceRefStruct(generator, typeDeclaration)
                ////.AppendBuilderConstructor(generator, typeDeclaration)
                ////.AppendBuildereMethods(generator, typeDeclaration)
                ////.EndClassOrStructDeclaration();

            return generator;
        }

        /// <summary>
        /// Gets the builder class name.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>The validation class name.</returns>
        public static string BuilderClassName(this CodeGenerator generator)
        {
            if (generator.TryPeekMetadata(BuilderClassNameKey, out (string, string)? value) &&
                value is (string className, string _))
            {
                return className;
            }

            throw new InvalidOperationException("The validation class name has not been created.");
        }

        /// <summary>
        /// Gets the builder class scope.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <returns>The fully-qualified validation class scope.</returns>
        public static string BuilderClassScope(this CodeGenerator generator)
        {
            if (generator.TryPeekMetadata(BuilderClassNameKey, out (string, string)? value) &&
                value is (string _, string scope))
            {
                return scope;
            }

            throw new InvalidOperationException("The validation class scope  has not been created.");
        }

    }
}
