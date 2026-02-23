// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using Microsoft.CodeAnalysis.CSharp;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generator extensions for object-related functionality.
/// </summary>
internal static partial class CodeGeneratorExtensions
{
    /// <summary>
    /// Appends methods to apply object composition types.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to apply composition types.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendApplyObjectCompositionTypes(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        HashSet<TypeDeclaration> seenTypes = [];

        string applyMethodName = generator.GetUniqueMethodNameInScope("Apply");

        foreach (TypeDeclaration? type in typeDeclaration.AllOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (type is TypeDeclaration t && seenTypes.Add(t))
            {
                AppendApply(generator, t, applyMethodName);
            }
        }

        foreach (TypeDeclaration? type in typeDeclaration.AnyOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (type is TypeDeclaration t && seenTypes.Add(t))
            {
                AppendApply(generator, t, applyMethodName);
            }
        }

        foreach (TypeDeclaration? type in typeDeclaration.OneOfCompositionTypes().Values.SelectMany(t => t).Select(t => t.ReducedTypeDeclaration().ReducedType))
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (type is TypeDeclaration t && seenTypes.Add(t))
            {
                AppendApply(generator, t, applyMethodName);
            }
        }

        return generator;

        static CodeGenerator AppendApply(CodeGenerator generator, TypeDeclaration typeDeclaration, string applyMethodName)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0 || typeDeclaration.DoNotGenerate())
            {
                return generator;
            }

            if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType objectPropertyType)
            {
                if (objectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
                {
                    return generator;
                }
            }
            else if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localObjectPropertyType)
            {
                if (localObjectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
                {
                    return generator;
                }
            }
            else if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedObjectPropertyType)
            {
                if (localAndAppliedObjectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
                {
                    return generator;
                }
            }

            string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();

            return generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Apply a composed value.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <remarks>")
                .AppendLineIndent("/// This will add or update any property values provided by the <paramref name=\"value\"/>.")
                .AppendLineIndent("/// </remarks>")
                .AppendLineIndent("public void ", applyMethodName, "(in ", fqdtn, " value)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendLineIndent("")
                    .AppendLineIndent("foreach (var property in value.EnumerateObject())")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("JsonElementHelpers.SetPropertyUnsafe(this, property);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendLineIndent("")
                    .AppendLineIndent("_documentVersion = _parent.Version;")
                .PopIndent()
                .AppendLineIndent("}");
        }
    }

    /// <summary>
    /// Append EnumerateObject() method.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
    /// <param name="forMutable">Indicates that the value is intended for a mutable instance.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendEnumerateObject(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
        {
            return generator;
        }

        string fqdtn;

        if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType objectPropertyType)
        {
            if (objectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                return generator;
            }

            fqdtn = objectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
        }
        else if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localObjectPropertyType)
        {
            if (localObjectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                return generator;
            }

            fqdtn = localObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
        }
        else if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedObjectPropertyType)
        {
            if (localAndAppliedObjectPropertyType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                return generator;
            }

            fqdtn = localAndAppliedObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
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
            .ReserveName("EnumerateObject")
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Enumerates the object.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an object.</exception>")
            .AppendLineIndent("public ObjectEnumerator<", fqdtn, "> EnumerateObject()")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("return EnumeratorCreator.CreateObjectEnumerator<", fqdtn, ">(_parent, _idx);")
            .PopIndent()
            .AppendLineIndent("}");
    }

    /// <summary>
    /// Append GetPropertyCount() method.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendGetPropertyCount(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
        {
            return generator;
        }

        return generator
            .AppendSeparatorLine()
            .ReserveName("GetPropertyCount")
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Gets the number of properties in the object.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <exception cref=\"InvalidOperationException\">The value is not an object.</exception>")
            .AppendLineIndent("public int GetPropertyCount()")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("CheckValidInstance();")
                .AppendLineIndent("return _parent.GetPropertyCount(_idx);")
            .PopIndent()
            .AppendLineIndent("}");
    }

    /// <summary>
    /// Appends a JsonPropertyNames nested class containing property name constants.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the property names class.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendJsonPropertyNames(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (!typeDeclaration.HasPropertyDeclarations)
        {
            return generator;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Provides UTF8 and string versions of the JSON property names on the object.")
            .AppendLineIndent("/// </summary>")
            .BeginPublicStaticClassDeclaration(generator.JsonPropertyNamesClassName());

        int i = 0;
        foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (i > 0)
            {
                generator
                    .AppendLine();
            }

            generator
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Gets the JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent(
                    "public const string ",
                    property.DotnetPropertyName(),
                    " = ",
                    SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                    ";");
            i++;
        }

        foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (i > 0)
            {
                generator
                    .AppendLine();
            }

            generator
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Gets the JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent(
                    "public static ReadOnlySpan<byte> ",
                    property.DotnetPropertyName(),
                    "Utf8 => ",
                    SymbolDisplay.FormatLiteral(property.JsonPropertyName, true),
                    "u8;");
            i++;
        }

        return generator
            .EndClassStructOrEnumDeclaration();
    }

    /// <summary>
    /// Appends a JsonPropertyNamesEscaped nested class containing escaped property name constants.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the escaped property names class.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendJsonPropertyNamesEscaped(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (!typeDeclaration.HasPropertyDeclarations)
        {
            return generator;
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Provides escaped UTF-8 versions of the JSON property names on the object.")
            .AppendLineIndent("/// </summary>")
            .BeginPrivateStaticClassDeclaration(generator.JsonPropertyNamesEscapedClassName());

        int i = 0;

        foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (i > 0)
            {
                generator
                    .AppendLine();
            }

            string encodedName = JavaScriptEncoder.Default.Encode(property.JsonPropertyName);

            generator
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Gets the escaped UTF-8 JSON property name for <see cref=\"", property.DotnetPropertyName(), "\"/>.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent(
                    "public static ReadOnlySpan<byte> ",
                    property.DotnetPropertyName(),
                    " => ",
                    SymbolDisplay.FormatLiteral(encodedName, true),
                    "u8;");
            i++;
        }

        return generator
            .EndClassStructOrEnumDeclaration();
    }

    /// <summary>
    /// Append object indexer properties.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
    /// <param name="forMutable">Whether to emit the indexers for the mutable element.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendObjectIndexerProperties(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if ((typeDeclaration.ImpliedCoreTypesOrAny() & CoreTypes.Object) == 0)
        {
            return generator;
        }

        string fqdtn;

        if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType objectPropertyType)
        {
            if (objectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
            {
                return generator;
            }

            fqdtn = objectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
        }
        else if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localObjectPropertyType)
        {
            if (localObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
            {
                return generator;
            }

            fqdtn = localObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
        }
        else if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedObjectPropertyType)
        {
            if (localAndAppliedObjectPropertyType.ReducedType == WellKnownTypeDeclarations.JsonNotAny)
            {
                return generator;
            }

            fqdtn = localAndAppliedObjectPropertyType.ReducedType.FullyQualifiedDotnetTypeName();
        }
        else
        {
            fqdtn = WellKnownTypeDeclarations.JsonAny.DotnetTypeName();
        }

        AppendPropertyIndexer(generator, fqdtn, "ReadOnlySpan<byte>", forMutable);
        AppendPropertyIndexer(generator, fqdtn, "ReadOnlySpan<char>", forMutable);
        AppendPropertyIndexer(generator, fqdtn, "string", forMutable);

        return generator;

        static void AppendPropertyIndexer(CodeGenerator generator, string fqdtn, string propertyNameType, bool forMutable) => generator
                            .AppendSeparatorLine()
                            .AppendBlockIndent(
                            """
                            /// <summary>
                            /// Gets the value of the property with the given name.
                            /// </summary>
                            /// <param name="propertyName">The name of the property.</param>
                            /// <returns>The value of the property with the given name.</returns>
                            /// <exception cref="InvalidOperationException">The value is not an object.</exception>
                            """)
                            .AppendLineIndent("public ", fqdtn, forMutable ? ".Mutable" : "", " this[", propertyNameType, " propertyName]")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("get")
                                .AppendLineIndent("{")
                                .PushIndent()
                                    .AppendLineIndent("CheckValidInstance();")
                                    .AppendLineIndent("if (!_parent.TryGetNamedPropertyValue(_idx, propertyName, out ", fqdtn, forMutable ? ".Mutable" : "", " value))")
                                    .AppendLineIndent("{")
                                    .PushIndent()
                                        .AppendLineIndent("return default;")
                                    .PopIndent()
                                    .AppendLineIndent("}")
                                    .AppendSeparatorLine()
                                    .AppendLineIndent("return value;")
                                .PopIndent()
                                .AppendLineIndent("}")
                            .PopIndent()
                            .AppendLineIndent("}");
    }

    /// <summary>
    /// Append object properties.
    /// </summary>
    /// <param name="generator">The code generator.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the indexers.</param>
    /// <param name="forMutable">Whether to emit the indexers for the mutable element.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendObjectProperties(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forMutable = false)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;

            }

            bool isNullable = typeDeclaration.OptionalAsNullable() && property.RequiredOrOptional == RequiredOrOptional.Optional;
            string propertyType = $"{property.ReducedPropertyType.FullyQualifiedDotnetTypeName()}{(forMutable ? ".Mutable" : "")}";

            generator
                .AppendSeparatorLine()
                .AppendPropertyDocumentation(property)
                .AppendObsoleteAttribute(property)
                .BeginPublicReadOnlyPropertyDeclaration(propertyType, property.DotnetPropertyName(), isNullable)
                    .AppendLineIndent("if (_parent.TryGetNamedPropertyValue(_idx, ", generator.JsonPropertyNamesClassName(), ".", property.DotnetPropertyName(), "Utf8, out ", propertyType, " value))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("return value;")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendSeparatorLine()
                    .AppendLineIndent("return default;")
                .EndReadOnlyPropertyDeclaration();
        }

        return generator;
    }

    public static CodeGenerator AppendObjectPropertySetters(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        foreach (PropertyDeclaration property in typeDeclaration.PropertyDeclarations)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;

            }

            // Don't emit a setter for boolean false properties, as they cannot be set!
            if (property.ReducedPropertyType.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            string propertyTypeName = property.ReducedPropertyType.FullyQualifiedDotnetTypeName();

            string name = SymbolDisplay.FormatLiteral(property.JsonPropertyName, true);
            name = name.Substring(1, name.Length - 2);
            bool requiresEncoding = JavaScriptEncoder.Default.Encode(property.JsonPropertyName) != property.JsonPropertyName;
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Set the <c>", name, "</c> property.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <param name=\"value\">The value of the property to add.</param>")
                .AppendLineIndent("public void Set", property.DotnetPropertyName(), "(in ", propertyTypeName, ".", generator.SourceClassName(propertyTypeName), " value)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("CheckValidInstance();")
                    .AppendSeparatorLine()
                    .AppendLineIndent("ComplexValueBuilder cvb = ComplexValueBuilder.Create(_parent, 2);")
                    .AppendLineIndent("if (_parent.TryGetNamedPropertyValue(_idx, ", generator.JsonPropertyNamesClassName(), ".", property.DotnetPropertyName(), "Utf8, out IJsonDocument? elementParent, out int elementIdx))")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("// We are going to replace just the value")
                        .AppendLineIndent("value.AddAsItem(ref cvb);")
                        .AppendLineIndent("_parent.OverwriteAndDispose(_idx, elementIdx, elementIdx + elementParent.GetDbSize(elementIdx, true), 1, ref cvb);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendLineIndent("else")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("// We are going to insert the new value")
                        .AppendLineIndent("value.AddAsProperty(", generator.JsonPropertyNamesEscapedClassName(), ".", property.DotnetPropertyName(), ", ref cvb, escapeName: false, nameRequiresUnescaping: ", requiresEncoding ? "true" : "false", ");")
                        .AppendLineIndent("int endIndex = _idx + _parent.GetDbSize(_idx, false);")
                        .AppendLineIndent("_parent.InsertAndDispose(_idx, endIndex, ref cvb);")
                    .PopIndent()
                    .AppendLineIndent("}")
                    .AppendSeparatorLine()
                    .AppendLineIndent("_documentVersion = _parent.Version;")
                .PopIndent()
                .AppendLineIndent("}");



        }

        return generator;
    }

    /// <summary>
    /// Append the start of a public readonly property declaration.
    /// </summary>
    /// <param name="generator">The generator to which to append the property.</param>
    /// <param name="propertyType">The type of the property.</param>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="nullable">If true, make the property type nullable.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator BeginPublicReadOnlyPropertyDeclaration(this CodeGenerator generator, string propertyType, string propertyName, bool nullable = false)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        return generator
            .AppendLineIndent("public ", propertyType, nullable ? "? " : " ", propertyName)
            .AppendLineIndent("{")
            .PushIndent()
            .AppendLineIndent("get")
            .AppendLineIndent("{")
            .PushIndent();
    }

    /// <summary>
    /// Append the start of a public readonly property declaration.
    /// </summary>
    /// <param name="generator">The generator to which to append the property.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator EndReadOnlyPropertyDeclaration(this CodeGenerator generator)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        return generator
            .PopIndent()
            .AppendLineIndent("}")
            .PopIndent()
            .AppendLineIndent("}");
    }

    private static CodeGenerator AppendPropertyDocumentation(this CodeGenerator generator, PropertyDeclaration property)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        bool optional = property.RequiredOrOptional == RequiredOrOptional.Optional;

        string name = SymbolDisplay.FormatLiteral(property.JsonPropertyName, true);
        name = name.Substring(1, name.Length - 2);

        generator
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent(
            "/// Gets the ",
            optional ? "(optional) " : string.Empty,
            "<c>",
            name,
            "</c> ",
            "property.");

        // We include documentation attached to the local (unreduced) type; this is usually the means by
        // which property-specific documentation is attached to a particular instance of a common reference type.
        if (property.UnreducedPropertyType.ShortDocumentation() is string shortDocumentation)
        {
            generator
                .AppendBlockIndentWithPrefix(shortDocumentation, "/// ");
        }

        generator
            .AppendLineIndent("/// </summary>");

        bool usingRemarks = false;
        if (!optional)
        {
            usingRemarks = true;

            generator
                .AppendLineIndent("/// <remarks>")
                .AppendLineIndent("/// <para>")
                .AppendIndent("/// If the instance is valid, this property will not be <see cref=\"JsonValueKind.Undefined\"/>");

            if ((property.ReducedPropertyType.ImpliedCoreTypesOrAny() & CoreTypes.Null) != 0)
            {
                generator.Append(", but may be <see cref=\"JsonValueKind.Null\"/>");
            }

            generator
                .AppendLine(".")
                .AppendLineIndent("/// </para>");
        }
        else if (property.Owner.OptionalAsNullable())
        {
            usingRemarks = true;

            generator
                .AppendLineIndent("/// <remarks>")
                .AppendLineIndent("/// <para>")
                .AppendIndent("/// If this JSON property is <see cref=\"JsonValueKind.Undefined\"/>");

            if ((property.ReducedPropertyType.ImpliedCoreTypesOrAny() & CoreTypes.Null) != 0)
            {
                generator.Append(", or <see cref=\"JsonValueKind.Null\"/>");
            }

            generator
                .AppendLine(" then the value returned will be <see langword=\"null\" />.")
                .AppendLineIndent("/// </para>");
        }

        if (property.UnreducedPropertyType.LongDocumentation() is string longDocumentation)
        {
            if (!usingRemarks)
            {
                usingRemarks = true;
                generator
                    .AppendLineIndent("/// <remarks>");
            }

            generator
                .AppendParagraphs(longDocumentation);
        }

        if (property.ReducedPropertyType != property.UnreducedPropertyType && property.ReducedPropertyType.LongDocumentation() is string longDocumentationReduced)
        {
            if (!usingRemarks)
            {
                usingRemarks = true;
                generator
                    .AppendLineIndent("/// <remarks>");
            }

            generator
                .AppendParagraphs(longDocumentationReduced);
        }

        if (usingRemarks)
        {
            generator.AppendLineIndent("/// </remarks>");
        }

        return generator;
    }

    private static CodeGenerator AppendObsoleteAttribute(this CodeGenerator generator, PropertyDeclaration property)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (property.UnreducedPropertyType.IsDeprecated(out string? message) ||
            property.ReducedPropertyType.IsDeprecated(out message))
        {
            generator
                .AppendLineIndent(
                    "[Obsolete(",
                    SymbolDisplay.FormatLiteral(message ?? "This property is defined as deprecated in the JSON schema.", true),
                    ")]");
        }

        return generator;
    }
}
