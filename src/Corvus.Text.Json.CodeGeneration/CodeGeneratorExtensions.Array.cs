// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generator extensions for array-related functionality.
/// </summary>
internal static partial class CodeGeneratorExtensions
{

    /// <summary>
    /// Append mutation methods for arrays.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the mutators.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendArrayMutators(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if ((typeDeclaration.ImpliedCoreTypes() & CoreTypes.Array) == 0)
        {
            return generator;
        }

        // Do not add the standard mutators if this is a tuple.
        if (typeDeclaration.IsTuple())
        {
            return generator;
        }

        // Get the type for the array items.
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

        // Set an item
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("///   Sets the value of an array element at the specified index.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"itemIndex\">The zero-based index of the array element to set.</param>")
            .AppendLineIndent("/// <param name=\"value\">The item value to set.</param>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">")
            .AppendLineIndent("///   This element's <see cref=\"ValueKind\"/> is not <see cref=\"JsonValueKind.Array\"/>,")
            .AppendLineIndent("///   or the element reference is stale due to document mutations.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ObjectDisposedException\">")
            .AppendLineIndent("///   The parent <see cref=\"JsonDocument\"/> has been disposed.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ArgumentOutOfRangeException\">")
            .AppendLineIndent("///   <paramref name=\"itemIndex\"/> is negative or greater than the array length.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <remarks>")
            .AppendLineIndent("///   <para>")
            .AppendLineIndent("///     This method allows replacing existing array elements or appending new elements")
            .AppendLineIndent("///     when <paramref name=\"itemIndex\"/> equals the current array length.")
            .AppendLineIndent("///   </para>")
            .AppendLineIndent("/// </remarks>")
            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
            .AppendLineIndent("public void SetItem(int itemIndex, in ", fqdtn, ".", generator.SourceClassName(fqdtn), " value)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 30);")
                .AppendLineIndent("value.AddAsItem(ref cvb);")
                .AppendLineIndent("int arrayLength = GetArrayLength();")
                .AppendLineIndent("if (itemIndex == arrayLength)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("_parent.InsertAndDispose(_idx, _idx + _parent.GetDbSize(_idx, false), ref cvb);")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendLineIndent("else")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("_parent.GetArrayIndexElement(_idx, itemIndex, out IMutableJsonDocument elementParent, out int elementIdx);")
                    .AppendLineIndent("_parent.OverwriteAndDispose(_idx, elementIdx, elementIdx + elementParent.GetDbSize(elementIdx, true), 1, ref cvb);")
                .PopIndent()
                .AppendLineIndent("}")
                .AppendSeparatorLine()
                .AppendLineIndent("_documentVersion = _parent.Version;")
            .PopIndent()
            .AppendLineIndent("}");

        // Insert an item
        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("///   Inserts an item into the array at the specified index.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"itemIndex\">The zero-based index of the array element at which to insert.</param>")
            .AppendLineIndent("/// <param name=\"value\">The item value to insert.</param>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">")
            .AppendLineIndent("///   This element's <see cref=\"ValueKind\"/> is not <see cref=\"JsonValueKind.Array\"/>,")
            .AppendLineIndent("///   or the element reference is stale due to document mutations.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ObjectDisposedException\">")
            .AppendLineIndent("///   The parent <see cref=\"JsonDocument\"/> has been disposed.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ArgumentOutOfRangeException\">")
            .AppendLineIndent("///   <paramref name=\"itemIndex\"/> is negative or greater than the array length.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <remarks>")
            .AppendLineIndent("///   <para>")
            .AppendLineIndent("///     This method allows inserting array elements or appending new elements")
            .AppendLineIndent("///     when <paramref name=\"itemIndex\"/> equals the current array length.")
            .AppendLineIndent("///   </para>")
            .AppendLineIndent("/// </remarks>")
            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
            .AppendLineIndent("public void InsertItem(int itemIndex, in ", fqdtn, ".", generator.SourceClassName(fqdtn), " value)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 30);")
                .AppendLineIndent("value.AddAsItem(ref cvb);")
                .AppendLineIndent("_parent.InsertAndDispose(_idx, _parent.GetArrayInsertionIndex(_idx, itemIndex), ref cvb);")
                .AppendLineIndent("_documentVersion = _parent.Version;")
            .PopIndent()
            .AppendLineIndent("}");

        // Remove items
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("///   Removes a range of items from the array starting at the specified index.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"startIndex\">The zero-based index at which to begin removing items.</param>")
            .AppendLineIndent("/// <param name=\"count\">The number of items to remove.</param>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">")
            .AppendLineIndent("///   This element's <see cref=\"ValueKind\"/> is not <see cref=\"JsonValueKind.Array\"/>,")
            .AppendLineIndent("///   or the element reference is stale due to document mutations.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ObjectDisposedException\">")
            .AppendLineIndent("///   The parent <see cref=\"JsonDocument\"/> has been disposed.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ArgumentOutOfRangeException\">")
            .AppendLineIndent("///   <paramref name=\"startIndex\"/> is negative or greater than the current array length.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
            .AppendLineIndent("public void RemoveRange(int startIndex, int count)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("JsonElementHelpers.RemoveRangeUnsafe(this, startIndex, count);")
                .AppendLineIndent("_documentVersion = _parent.Version;")
            .PopIndent()
            .AppendLineIndent("}")
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("///   Removes a single item from the array at the specified index.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"index\">The zero-based index of the item to remove.</param>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">")
            .AppendLineIndent("///   This element's <see cref=\"ValueKind\"/> is not <see cref=\"JsonValueKind.Array\"/>,")
            .AppendLineIndent("///   or the element reference is stale due to document mutations.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ObjectDisposedException\">")
            .AppendLineIndent("///   The parent <see cref=\"JsonDocument\"/> has been disposed.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ArgumentOutOfRangeException\">")
            .AppendLineIndent("///   <paramref name=\"index\"/> is negative or greater than or equal to the current array length.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
            .AppendLineIndent("public void Remove(int index)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("JsonElementHelpers.RemoveRangeUnsafe(this, index, 1);")
                .AppendLineIndent("_documentVersion = _parent.Version;")
            .PopIndent()
            .AppendLineIndent("}")
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("///   Removes all array elements that match the specified predicate.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"predicate\">The predicate function that determines which elements to remove.</param>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">")
            .AppendLineIndent("///   This element's <see cref=\"ValueKind\"/> is not <see cref=\"JsonValueKind.Array\"/>,")
            .AppendLineIndent("///   or the element reference is stale due to document mutations.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ObjectDisposedException\">")
            .AppendLineIndent("///   The parent <see cref=\"JsonDocument\"/> has been disposed.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <exception cref=\"ArgumentNullException\">")
            .AppendLineIndent("///   <paramref name=\"predicate\"/> is <see langword=\"null\"/>.")
            .AppendLineIndent("/// </exception>")
            .AppendLineIndent("/// <remarks>")
            .AppendLineIndent("///   <para>")
            .AppendLineIndent("///     This method efficiently removes elements in a single pass by iterating backwards")
            .AppendLineIndent("///     through the array and removing consecutive blocks of matching elements.")
            .AppendLineIndent("///   </para>")
            .AppendLineIndent("///   <para>")
            .AppendLineIndent("///     The predicate function is called for each element in the array. If the predicate")
            .AppendLineIndent("///     returns <see langword=\"true\"/>, the element will be removed from the array.")
            .AppendLineIndent("///   </para>")
            .AppendLineIndent("/// </remarks>")
            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
            .AppendLineIndent("public void RemoveWhere(JsonPredicate<", fqdtn, "> predicate)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("JsonElementHelpers.RemoveWhereUnsafe<Mutable, ", fqdtn, ">(this, predicate);")
                .AppendLineIndent("_documentVersion = _parent.Version;")
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }


    /// <summary>
    /// Append the static property which provides the dimension (fixed length) of the array.
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
                /// Gets the fixed length of the array at its current rank.
                /// </summary>
                """)
                .AppendIndent("public static int Dimension => ")
                .Append(dimension)
                .AppendLine(";");
        }

        return generator;
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
            fqdtn += ".Mutable";
        }

        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Enumerates the array.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an array.</exception>")
            .AppendLineIndent("public ArrayEnumerator<", fqdtn, "> EnumerateArray()")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("return EnumeratorCreator.CreateArrayEnumerator<", fqdtn, ">(_parent, _idx);")
            .PopIndent()
            .AppendLineIndent("}");
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
}
