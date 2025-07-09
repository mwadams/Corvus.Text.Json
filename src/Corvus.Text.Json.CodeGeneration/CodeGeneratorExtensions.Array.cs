// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
        /// <summary>
        /// Append the static property which provides the rank of the array.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the property.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendArrayRankStaticProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (typeDeclaration.ArrayRank() is int rank)
            {
                generator
                    .ReserveName("Rank")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                        """
                    /// <summary>
                    /// Gets the rank of the array.
                    /// </summary>
                    """)
                    .AppendIndent("public static int Rank => ")
                    .Append(rank)
                    .AppendLine(";");
            }

            return generator;
        }

        /// <summary>
        /// Append the static property which provides the dimension of the array.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the property.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendArrayDimensionStaticProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (typeDeclaration.ArrayDimension() is int dimension)
            {
                generator
                    .ReserveName("Dimension")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                        """
                    /// <summary>
                    /// Gets the dimension of the array.
                    /// </summary>
                    """)
                    .AppendIndent("public static int Dimension => ")
                    .Append(dimension)
                    .AppendLine(";");
            }

            return generator;
        }

        /// <summary>
        /// Append the static property which provides the value buffer size of the array.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the property.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendArrayValueBufferSizeStaticProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (typeDeclaration.ArrayValueBufferSize() is int valueBufferSize)
            {
                generator
                    .ReserveName("ValueBufferSize")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                        """
                    /// <summary>
                    /// Gets the total size of a buffer required to represent the array.
                    /// </summary>
                    /// <remarks>
                    /// This calculates the array based on the dimension of each rank. It is generally
                    /// used to determine the size of the buffer required by
                    /// <see cref="TryGetNumericValues"/>.
                    /// </remarks>
                    """)
                    .AppendIndent("public static int ValueBufferSize => ")
                    .Append(valueBufferSize)
                    .AppendLine(";");
            }

            return generator;
        }
    }
}
