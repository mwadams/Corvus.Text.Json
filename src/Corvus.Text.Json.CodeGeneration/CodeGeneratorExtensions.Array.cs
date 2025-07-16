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

        /// <summary>
        /// Append GetArrayLength() method.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendGetArrayLength(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Array) == 0)
            {
                return generator;
            }

            return generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Gets the array length.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an array.</exception>")
                .AppendLineIndent("public int GetArrayLength()")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendLineIndent("return _parent.GetArrayLength(_idx);")
                .PopIndent()
                .AppendLineIndent("}");
        }


        /// <summary>
        /// Append EnumerateArray() method.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <param name="forMutable">Indicates that the method is for a mutable instance.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendEnumerateArray(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Array) == 0)
            {
                return generator;
            }

            string fqdtn;

            if (typeDeclaration.ArrayItemsType() is ArrayItemsTypeDeclaration itemsType)
            {
                if (itemsType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = itemsType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.ExplicitUnevaluatedItemsType() is ArrayItemsTypeDeclaration unevaluatedItemsType)
            {
                if (unevaluatedItemsType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = unevaluatedItemsType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else
            {
                fqdtn = WellKnownTypeDeclarations.JsonAny.DotnetTypeName();
            }

            if (forMutable)
            {
                fqdtn = fqdtn + ".Mutable";
            }

            return generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Enumerates the array.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an array.</exception>")
                .AppendLineIndent("public ArrayEnumerator<", fqdtn, "> EnumerateArray()" )
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendLineIndent("return EnumeratorCreator.CreateArrayEnumerator<", fqdtn, ">(_parent, _idx);")
                .PopIndent()
                .AppendLineIndent("}");
        }

        /// <summary>
        /// Append array indexer properties.
        /// </summary>
        /// <param name="generator">The code generator.</param>
        /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
        /// <param name="forMutable">Whether to emit the indexers for the mutable element.</param>
        /// <returns>A reference to the generator having completed the operation.</returns>
        public static CodeGenerator AppendArrayIndexerProperties(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Array) == 0)
            {
                return generator;
            }

            string fqdtn;

            if (typeDeclaration.ArrayItemsType() is ArrayItemsTypeDeclaration itemsType)
            {
                if (itemsType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = itemsType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else if (typeDeclaration.ExplicitUnevaluatedItemsType() is ArrayItemsTypeDeclaration unevaluatedItemsType)
            {
                if (unevaluatedItemsType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
                {
                    return generator;
                }

                fqdtn = unevaluatedItemsType.ReducedType.FullyQualifiedDotnetTypeName();
            }
            else
            {
                fqdtn = WellKnownTypeDeclarations.JsonAny.DotnetTypeName();
            }

            generator
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                    """
                    /// <summary>
                    /// Gets the item at the given index.
                    /// </summary>
                    /// <param name="index">The index at which to retrieve the item.</param>
                    /// <returns>The item at the given index.</returns>
                    /// <exception cref="IndexOutOfRangeException">The index was outside the bounds of the array.</exception>
                    /// <exception cref="InvalidOperationException">The value is not an array.</exception>
                    """)
                    .AppendLineIndent("public ", fqdtn, forMutable ? ".Mutable" : "", " this[int index]")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("get")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("CheckValidInstance();")
                            .AppendLineIndent("return _parent.GetArrayIndexElement<", fqdtn, forMutable ? ".Mutable" : "", ">(_idx, index);")
                        .PopIndent()
                        .AppendLineIndent("}")
                    .PopIndent()
                    .AppendLineIndent("}");

            return generator;
        }
    }
}
