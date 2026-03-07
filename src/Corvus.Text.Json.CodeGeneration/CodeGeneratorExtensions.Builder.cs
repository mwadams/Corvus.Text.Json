// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Corvus.Json.CodeGeneration;
using static Corvus.Text.Json.CodeGeneration.CodeGeneratorExtensions;

namespace Corvus.Text.Json.CodeGeneration;

/// <summary>
/// Code generator extensions for builder pattern functionality.
/// </summary>
internal static partial class CodeGeneratorExtensions
{
    /// <summary>
    /// Appends the builder pattern methods for the specified type declaration.
    /// </summary>
    /// <param name="generator">The generator to which to append the separator line.</param>
    /// <param name="typeDeclaration">The type declaration for which the builder is to be appended.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    public static CodeGenerator AppendSourceAndBuilder(this CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        List<ComposedBuilder> builders = [];

        return generator
            .AppendSourceRefStruct(typeDeclaration, builders)
            .AppendSourceOfContextRefStruct(typeDeclaration, builders)
            .AppendBuilderRefStruct(typeDeclaration, builders, forArray: true)
            .AppendBuilderRefStruct(typeDeclaration, builders, forArray: false)
            .AppendCommonBuild(typeDeclaration, builders)
            .AppendCommonBuildDocuments(typeDeclaration, builders);
    }

    private static CodeGenerator AppendAddAsItem(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, bool forContext = false)
    {
        HashSet<string> seenKinds = [];
        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        generator
            .ReserveNameIfNotReserved("AddAsItem")
            .AppendSeparatorLine()
            .AppendLineIndent("internal void AddAsItem(ref ComplexValueBuilder valueBuilder)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("switch(_kind)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("case Kind.Unknown:")
                    .PushIndent()
                        .AppendLineIndent("break;")
                    .PopIndent();

        if (forContext)
        {
            generator
                    .AppendLineIndent("case Kind.Source:")
                    .PushIndent()
                        .AppendLineIndent("_source.AddAsItem(ref valueBuilder);")
                        .AppendLineIndent("break;")
                    .PopIndent();
        }

        if (!forContext)
        {
            generator
                        .AppendLineIndent("case Kind.JsonElement:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_jsonElement);")
                            .AppendLineIndent("break;")
                        .PopIndent();

            if ((core & CoreTypes.Null) != 0)
            {
                if (seenKinds.Add("Null"))
                {
                    generator
                        .AppendLineIndent("case Kind.Null:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItemNull();")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & CoreTypes.Boolean) != 0)
            {
                if (seenKinds.Add("True"))
                {
                    generator
                        .AppendLineIndent("case Kind.True:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(true);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("False"))
                {
                    generator
                        .AppendLineIndent("case Kind.False:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & CoreTypes.String) != 0)
            {
                if (seenKinds.Add("RawUtf8StringRequiresUnescaping"))
                {
                    generator
                        .AppendLineIndent("case Kind.RawUtf8StringRequiresUnescaping:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_utf8Backing, escapeValue: false, requiresUnescaping: true);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("RawUtf8StringNotRequiresUnescaping"))
                {
                    generator
                        .AppendLineIndent("case Kind.RawUtf8StringNotRequiresUnescaping:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_utf8Backing, escapeValue: false, requiresUnescaping: false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf8String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf8String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_utf8Backing, escapeValue: true, requiresUnescaping: false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf16String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf16String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_utf16Backing);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (typeDeclaration.Format() is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType &&
                    seenKinds.Add("StringSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.StringSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_simpleTypeBacking.Span(), escapeValue: false, requiresUnescaping: false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                if (seenKinds.Add("NumericSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.NumericSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_simpleTypeBacking.Span());")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("FormattedNumber"))
                {
                    generator.AppendLineIndent("case Kind.FormattedNumber:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItemFormattedNumber(_utf8Backing);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }
        }

        bool isObject = (core & CoreTypes.Object) != 0;
        bool isArray = (core & CoreTypes.Array) != 0;
        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;
        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        if (isObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
        {
            generator
                .AppendLineIndent("case Kind.", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ":")
                .PushIndent();


            if (forContext)
            {
                generator
                        .AppendLineIndent("valueBuilder.AddItem(BuildWithContext.Create(_context, _objectBuilder!), static (in b, ref o) => ", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b.Context, b.Build, ref o));");
            }
            else
            {
                generator
                        .AppendLineIndent("valueBuilder.AddItem(_objectBuilder!, static (in b, ref o) => ", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b, ref o));");
            }

            generator
                    .AppendLineIndent("break;")
                .PopIndent();
        }

        HashSet<string> numericArrayKinds = [];

        if (isArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
        {
            generator
                .AppendLineIndent("case Kind.", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ":")
                .PushIndent();

            if (forContext)
            {
                generator
                        .AppendLineIndent("valueBuilder.AddItem(BuildWithContext.Create(_context, _arrayBuilder!), static (in b, ref o) => ", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b.Context, b.Build, ref o));");
            }
            else
            {
                generator
                        .AppendLineIndent("valueBuilder.AddItem(_arrayBuilder!, static (in b, ref o) => ", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b, ref o));");
            }

            generator
                    .AppendLineIndent("break;")
                .PopIndent();

            if (!forContext && typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
            {
                NumericTypeName numericTypeName = typeDeclaration.PreferredDotnetNumericTypeName() ?? throw new InvalidOperationException("Expected numeric type name");
                string numericArrayKindName = GetNumericArrayKind(generator, numericTypeName);
                if (numericArrayKinds.Add(numericArrayKindName))
                {
                    if (numericTypeName.IsNetOnly)
                    {
                        generator
                            .AppendLine("#if NET");
                    }

                    generator
                        .AppendLineIndent("case Kind.", numericArrayKindName, ":")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItemArrayValue(_", numericTypeName.Name, "Array!);")
                            .AppendLineIndent("break;")
                        .PopIndent();

                    if (numericTypeName.IsNetOnly)
                    {
                        generator
                            .AppendLine("#endif");
                    }
                }
            }
        }

        foreach (ComposedBuilder composedBuilder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (composedBuilder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
            {
                if (!(composedBuilder.IsObject && typeDeclaration.HasPropertyDeclarations))
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent();

                        if (forContext)
                        {
                            generator
                                    .AppendLineIndent("valueBuilder.AddItem(BuildWithContext.Create(_context, _", composedBuilder.ObjectInstanceName, "!), static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ObjectBuilderName!, ".BuildValue(b.Context, b.Build, ref o));");
                        }
                        else
                        {
                            generator
                                    .AppendLineIndent("valueBuilder.AddItem(_", composedBuilder.ObjectInstanceName, "!, static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ObjectBuilderName!, ".BuildValue(b, ref o));");
                        }

                        generator
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }
            }

            if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
            {
                if (seenKinds.Add(composedBuilder.ArrayKindName))
                {
                    generator
                        .AppendLineIndent("case Kind.", composedBuilder.ArrayKindName, ":")
                        .PushIndent();

                    if (forContext)
                    {
                        generator
                                .AppendLineIndent("valueBuilder.AddItem(BuildWithContext.Create(_context, _", composedBuilder.ArrayInstanceName, "!), static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName!, ".BuildValue(b.Context, b.Build, ref o));");
                    }
                    else
                    {
                        generator
                                .AppendLineIndent("valueBuilder.AddItem(_", composedBuilder.ArrayInstanceName, "!, static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName!, ".BuildValue(b, ref o));");
                    }

                    generator
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if (!forContext && composedBuilder.StringFormat is string format &&
                FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                requiresSimpleType &&
                seenKinds.Add("StringSimpleType"))
            {
                generator
                    .AppendLineIndent("case Kind.StringSimpleType:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddItem(_simpleTypeBacking.Span(), escapeValue: false, requiresUnescaping: true);")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }

            if (!forContext && composedBuilder.NumericArrayKindName is not null && composedBuilder.NumericArrayTypeName is not null)
            {
                if (numericArrayKinds.Add(composedBuilder.NumericArrayKindName))
                {
                    bool isNetOnly = composedBuilder.NumericArrayTypeName.Value.IsNetOnly;
                    if (isNetOnly)
                    {
                        generator.AppendLine("#if NET");
                    }

                    generator
                        .AppendLineIndent("case Kind.", composedBuilder.NumericArrayKindName, ":")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItemArrayValue(_", composedBuilder.NumericArrayTypeName.Value.Name, "Array!);")
                            .AppendLineIndent("break;")
                        .PopIndent();

                    if (isNetOnly)
                    {
                        generator.AppendLine("#endif");
                    }
                }
            }
        }

        return generator
                    .AppendLineIndent("default:")
                    .PushIndent()
                        .AppendLineIndent("Debug.Fail(\"Unexpected Kind\");")
                        .AppendLineIndent("break;")
                    .PopIndent()
                .PopIndent()
                .AppendLineIndent("}")
            .PopIndent()
            .AppendLineIndent("}");
    }

    private static CodeGenerator AppendAddAsProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, string nameType, string nameName, bool includeEscaping, bool forContext = false)
    {
        generator
            .AppendSeparatorLine()
            .AppendLineIndent("internal void AddAsProperty(", nameType, " ", nameName, ", ref ComplexValueBuilder valueBuilder", includeEscaping ? ", bool escapeName = true, bool nameRequiresUnescaping = false" : "", ")")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("switch(_kind)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("case Kind.Unknown:")
                    .PushIndent()
                        .AppendLineIndent("break;")
                    .PopIndent();

        if (forContext)
        {
            generator
                    .AppendLineIndent("case Kind.Source:")
                    .PushIndent()
                        .AppendLineIndent("_source.AddAsProperty(", nameName, ", ref valueBuilder", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                        .AppendLineIndent("break;")
                    .PopIndent();
        }

        HashSet<string> seenKinds = [];
        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        if (!forContext)
        {
            generator
                    .AppendLineIndent("case Kind.JsonElement:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _jsonElement", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                        .AppendLineIndent("break;")
                    .PopIndent();



            if ((core & CoreTypes.Null) != 0)
            {
                if (seenKinds.Add("Null"))
                {
                    generator
                        .AppendLineIndent("case Kind.Null:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyNull(", nameName, includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & CoreTypes.Boolean) != 0)
            {
                if (seenKinds.Add("True"))
                {
                    generator
                        .AppendLineIndent("case Kind.True:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", true", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("False"))
                {
                    generator
                        .AppendLineIndent("case Kind.False:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", false", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & CoreTypes.String) != 0)
            {
                if (seenKinds.Add("RawUtf8StringRequiresUnescaping"))
                {
                    generator
                        .AppendLineIndent("case Kind.RawUtf8StringRequiresUnescaping:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyRawString(", nameName, ", _utf8Backing, ", includeEscaping ? "escapeName, nameRequiresUnescaping, valueRequiresUnescaping: true" : "valueRequiresUnescaping: true", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("RawUtf8StringNotRequiresUnescaping"))
                {
                    generator
                        .AppendLineIndent("case Kind.RawUtf8StringNotRequiresUnescaping:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyRawString(", nameName, ", _utf8Backing, ", includeEscaping ? "escapeName, nameRequiresUnescaping, valueRequiresUnescaping: false" : "valueRequiresUnescaping: false", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf8String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf8String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _utf8Backing, ", includeEscaping ? "escapeName, escapeValue: true, nameRequiresUnescaping, valueRequiresUnescaping: false" : "escapeValue: true, valueRequiresUnescaping: false", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf16String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf16String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _utf16Backing", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (typeDeclaration.Format() is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType &&
                    seenKinds.Add("StringSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.StringSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _simpleTypeBacking.Span()", includeEscaping ? ", escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: false" : ", escapeValue: false, valueRequiresUnescaping: false", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                if (seenKinds.Add("NumericSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.NumericSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyFormattedNumber(", nameName, ", _simpleTypeBacking.Span()", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("FormattedNumber"))
                {
                    generator.AppendLineIndent("case Kind.FormattedNumber:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyFormattedNumber(", nameName, ", _utf8Backing", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }
        }

        bool isObject = (core & CoreTypes.Object) != 0;
        bool isArray = (core & CoreTypes.Array) != 0;

        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;
        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        if (isObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
        {
            string builderName = isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
            generator
                .AppendLineIndent("case Kind.", builderName, ":")
                .PushIndent();

            if (forContext)
            {
                generator
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", BuildWithContext.Create(_context, _objectBuilder!), static (in b, ref o) => ", builderName, ".BuildValue(b.Context, b.Build, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
            }
            else
            {
                generator
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _objectBuilder!, static (in b, ref o) => ", builderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
            }

            generator
                    .AppendLineIndent("break;")
                .PopIndent();
        }

        HashSet<string> numericArrayKinds = [];

        if (isArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
        {
            string builderName = isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();

            generator
                .AppendLineIndent("case Kind.", builderName, ":")
                .PushIndent();

            if (forContext)
            {
                generator
                    .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", BuildWithContext.Create(_context, _arrayBuilder!), static (in b, ref o) => ", builderName, ".BuildValue(b.Context, b.Build, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
            }
            else
            {
                generator
                    .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _arrayBuilder!, static (in b, ref o) => ", builderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
            }

            generator
                    .AppendLineIndent("break;")
                .PopIndent();

            if (!forContext && typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
            {
                NumericTypeName numericTypeName = typeDeclaration.PreferredDotnetNumericTypeName() ?? throw new InvalidOperationException("Expected numeric type name");
                string numericArrayKindName = GetNumericArrayKind(generator, numericTypeName);
                if (numericArrayKinds.Add(numericArrayKindName))
                {
                    if (numericTypeName.IsNetOnly)
                    {
                        generator
                            .AppendLine("#if NET");
                    }

                    generator
                        .AppendLineIndent("case Kind.", numericArrayKindName, ":")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyArrayValue(", nameName, ", _", numericTypeName.Name, "Array!", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();

                    if (numericTypeName.IsNetOnly)
                    {
                        generator
                            .AppendLine("#endif");
                    }
                }
            }
        }

        foreach (ComposedBuilder composedBuilder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (composedBuilder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null && composedBuilder.ObjectBuilderName is not null)
            {
                if (!(composedBuilder.IsObject && typeDeclaration.HasPropertyDeclarations))
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent();

                        if (forContext)
                        {
                            generator
                                    .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", BuildWithContext.Create(_context, _", composedBuilder.ObjectInstanceName, "!), static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ObjectBuilderName, ".BuildValue(b.Context, b.Build, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
                        }
                        else
                        {
                            generator
                                    .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _", composedBuilder.ObjectInstanceName, "!, static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ObjectBuilderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
                        }


                        generator
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }
            }

            if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null && composedBuilder.ArrayBuilderName is not null)
            {
                if (seenKinds.Add(composedBuilder.ArrayKindName))
                {
                    generator
                        .AppendLineIndent("case Kind.", composedBuilder.ArrayKindName, ":")
                        .PushIndent();

                    if (forContext)
                    {
                        generator
                                .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", BuildWithContext.Create(_context, _", composedBuilder.ArrayInstanceName, "!), static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName, ".BuildValue(b.Context, b.Build, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
                    }
                    else
                    {
                        generator
                                .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _", composedBuilder.ArrayInstanceName, "!, static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");
                    }

                    generator
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _", composedBuilder.ArrayInstanceName, "!, static (in b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");");

                    generator
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if (!forContext && composedBuilder.NumericArrayKindName is not null && composedBuilder.NumericArrayTypeName is not null)
            {
                if (numericArrayKinds.Add(composedBuilder.NumericArrayKindName))
                {
                    bool isNetOnly = composedBuilder.NumericArrayTypeName.Value.IsNetOnly;
                    if (isNetOnly)
                    {
                        generator.AppendLine("#if NET");
                    }

                    generator
                        .AppendLineIndent("case Kind.", composedBuilder.NumericArrayKindName, ":")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyArrayValue(", nameName, ", _", composedBuilder.NumericArrayTypeName.Value.Name, "Array!", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                            .AppendLineIndent("break;")
                        .PopIndent();

                    if (isNetOnly)
                    {
                        generator.AppendLine("#endif");
                    }
                }
            }

            if (!forContext && composedBuilder.StringFormat is string format &&
                FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                requiresSimpleType &&
                seenKinds.Add("StringSimpleType"))
            {
                generator
                    .AppendLineIndent("case Kind.StringSimpleType:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _simpleTypeBacking.Span()", includeEscaping ? ", escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: false" : ", escapeValue: false, valueRequiresUnescaping: false", ");")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }
        }

        return generator
                    .AppendLineIndent("default:")
                    .PushIndent()
                        .AppendLineIndent("Debug.Fail(\"Unexpected Kind\");")
                        .AppendLineIndent("break;")
                    .PopIndent()
                .PopIndent()
                .AppendLineIndent("}")
            .PopIndent()
            .AppendLineIndent("}");
    }

    private static CodeGenerator AppendAddPropertyMethod(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isAlsoArray)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        HashSet<string> seenTypes = [];

        bool seenFallback = false;

        if (typeDeclaration.FallbackObjectPropertyType() is FallbackObjectPropertyType fallbackType)
        {
            seenFallback = true;
            if (!fallbackType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                string fqdtn = fallbackType.ReducedType.FullyQualifiedDotnetTypeName();
                if (seenTypes.Add(fqdtn))
                {
                    AppendAddPropertyMethods(generator, fqdtn, isAlsoArray);
                }
            }
        }

        if (typeDeclaration.LocalEvaluatedPropertyType() is FallbackObjectPropertyType localFallbackType)
        {
            seenFallback = true;

            if (!localFallbackType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                string fqdtn = localFallbackType.ReducedType.FullyQualifiedDotnetTypeName();
                if (seenTypes.Add(fqdtn))
                {
                    AppendAddPropertyMethods(generator, fqdtn, isAlsoArray);
                }
            }
        }

        if (typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is FallbackObjectPropertyType localAndAppliedFallbackType)
        {
            seenFallback = true;
            if (!localAndAppliedFallbackType.ReducedType.IsBuiltInJsonNotAnyType())
            {
                string fqdtn = localAndAppliedFallbackType.ReducedType.FullyQualifiedDotnetTypeName();
                if (seenTypes.Add(fqdtn))
                {
                    AppendAddPropertyMethods(generator, fqdtn, isAlsoArray);
                }
            }
        }

        if (!seenFallback)
        {
            AppendAddPropertyMethods(generator, "JsonElement", isAlsoArray);
        }

        return generator;

        static void AppendAddPropertyMethods(CodeGenerator generator, string propertyTypeName, bool isAlsoArray)
        {
            AppendAddPropertyMethod(generator, propertyTypeName, isAlsoArray, "ReadOnlySpan<byte>");
            AppendAddPropertyMethod(generator, propertyTypeName, isAlsoArray, "ReadOnlySpan<char>");
            AppendAddPropertyMethod(generator, propertyTypeName, isAlsoArray, "string");
        }

        static void AppendAddPropertyMethod(CodeGenerator generator, string propertyTypeName, bool isAlsoArray, string nameType)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Add a property to the object.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <param name=\"propertyName\">The name of the property to add.</param>")
                .AppendLineIndent("/// <param name=\"value\">The value of the property to add.</param>")
                .AppendLineIndent("public void AddProperty(", nameType, " propertyName, in ", propertyTypeName, ".", generator.SourceClassName(propertyTypeName), " value)")
                .AppendLineIndent("{")
                .PushIndent();

            generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("value.AddAsProperty(propertyName, ref _builder);")
                .PopIndent()
                .AppendLineIndent("}");
        }
    }

    private static CodeGenerator AppendArrayBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isObject)
    {
        bool allowsNonPrefixItems = !typeDeclaration.IsTuple();
        bool hasTuple = false;

        generator
            .AppendFixedSizeNumericArray(typeDeclaration, isObject);

        if (typeDeclaration.TupleType() is TupleTypeDeclaration tupleType)
        {
            hasTuple = true;
            if (allowsNonPrefixItems)
            {
                generator
                    .ReserveName("_addedPrefixItems")
                    .AppendSeparatorLine()
                    .AppendLineIndent("private bool _addedPrefixItems = false;");
            }

            generator
                .AppendSeparatorLine()
                .AppendCreateTuple(typeDeclaration, tupleType, allowsNonPrefixItems);
        }
        else if(typeDeclaration.ExplicitTupleType() is TupleTypeDeclaration tupleType2)
        {
            hasTuple = true;
            if (allowsNonPrefixItems)
            {
                generator
                    .ReserveName("_addedPrefixItems")
                    .AppendSeparatorLine()
                    .AppendLineIndent("private bool _addedPrefixItems = false;");
            }

            generator
                .AppendSeparatorLine()
                .AppendCreateTuple(typeDeclaration, tupleType2, allowsNonPrefixItems);
        }

        if (allowsNonPrefixItems)
        {
            TypeDeclaration arrayItemsTypeDeclaration = typeDeclaration.ArrayItemsType()?.ReducedType ?? WellKnownTypeDeclarations.JsonAny;

            // You aren't allowed to create NotAny types.
            if (arrayItemsTypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                return generator;
            }

            string arrayItemsType = arrayItemsTypeDeclaration.FullyQualifiedDotnetTypeName();


            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Add an item to the array.")
                .AppendLineIndent("/// </summary>");

            if (hasTuple)
            {
                generator
                    .AppendLineIndent("/// <remarks>")
                    .AppendLineIndent("/// You must call <see cref=\"CreateTuple\"/> before adding additional items.")
                    .AppendLineIndent("/// </remarks>");
            }

            generator
                .AppendLineIndent("public void Add(in ", arrayItemsType, ".", generator.SourceClassName(arrayItemsType), " value)")
                .AppendLineIndent("{")
                .PushIndent();

            if (hasTuple)
            {
                // Note that we are already in the allowsNonPrefixItems case here, so we know we have added the _addedPrefixItems field.
                generator
                    .AppendLineIndent("if (!_addedPrefixItems)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("CodeGenThrowHelper.ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst();")
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("value.AddAsItem(ref _builder);")
                .PopIndent()
                .AppendLineIndent("}");
        }

        return generator;
    }

    private static CodeGenerator AppendSourceRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        return generator
            .AppendSeparatorLine()
            .BeginRefStruct(GeneratedTypeAccessibility.Public, generator.SourceClassName(), isReadOnly: false)
                .CollectBuilderSourcesAndAppendSourceKindEnum(typeDeclaration, builders)
                .AppendSourceFields(typeDeclaration, builders)
                .AppendSourceConstructors(typeDeclaration, builders)
                .AppendSourceConversionOperators(typeDeclaration, builders)
                .AppendSourceFactoryMethods(typeDeclaration, builders)
                .AppendAddAsProperty(typeDeclaration, builders, "ReadOnlySpan<byte>", "utf8Name", includeEscaping: true)
                .AppendAddAsProperty(typeDeclaration, builders, "ReadOnlySpan<char>", "name", includeEscaping: false)
                .AppendAddAsProperty(typeDeclaration, builders, "string", "name", includeEscaping: false)
                .AppendAddAsItem(typeDeclaration, builders)
            .EndClassStructOrEnumDeclaration();
    }

    private static CodeGenerator AppendSourceOfContextRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        if (!builders.Any(b => b.ArrayBuilderName is not null || b.ObjectBuilderName is not null) && (typeDeclaration.ImpliedCoreTypesOrAny() & (CoreTypes.Object | CoreTypes.Array)) == 0)
        {
            return generator;
        }

        string gs = """
            #if NET9_0_OR_GREATER
            where TContext : allows ref struct
            #endif
            """;

        return generator
            .AppendSeparatorLine()
            .BeginRefStruct(GeneratedTypeAccessibility.Public, $"{generator.SourceClassName()}<TContext>", isReadOnly: false, genericConstraints: gs)
                .AppendKindEnumForBuilders(typeDeclaration, builders)
                .AppendSourceFields(typeDeclaration, builders, forContext: true)
                .AppendSourceConstructors(typeDeclaration, builders, forContext: true)
                .AppendAddAsProperty(typeDeclaration, builders, "ReadOnlySpan<byte>", "utf8Name", includeEscaping: true, forContext: true)
                .AppendAddAsProperty(typeDeclaration, builders, "ReadOnlySpan<char>", "name", includeEscaping: false, forContext: true)
                .AppendAddAsProperty(typeDeclaration, builders, "string", "name", includeEscaping: false, forContext: true)
                .AppendAddAsItem(typeDeclaration, builders, forContext: true)
            .EndClassStructOrEnumDeclaration();
    }

    private static CodeGenerator AppendBuilderRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, bool forArray)
    {
        bool forObject = !forArray;

        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        bool isArray = (core & CoreTypes.Array) != 0;
        bool isObject = (core & CoreTypes.Object) != 0;

        if (forArray && !isArray)
        {
            return generator;
        }

        if (forObject & !isObject)
        {
            return generator;
        }

        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        if (forArray && builders.Any(b => b.IsArray) && !hasFallbackArrayType)
        {
            return generator;
        }

        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;

        if (forObject && builders.Any(b => b.IsObject) && !hasFallbackObjectType)
        {
            return generator;
        }

        string builderClassName;

        if (forArray)
        {
            builderClassName = isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();
        }
        else
        {
            builderClassName = isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
        }

        generator
                .AppendSeparatorLine()
                .BeginRefStruct(GeneratedTypeAccessibility.Public, builderClassName, isReadOnly: false)
                    .ReserveName("Build")
                    .ReserveName("_builder")
                    .AppendLineIndent("public delegate void Build(ref ", builderClassName, " builder);")
                    .AppendSeparatorLine()
                    .AppendLine("#if NET9_0_OR_GREATER")
                    .AppendLineIndent("public delegate void Build<TContext>(in TContext context, ref ", builderClassName, " builder)")
                    .PushIndent()
                        .AppendLineIndent("where TContext : allows ref struct;")
                    .PopIndent()
                    .AppendLine("#else")
                    .AppendLineIndent("public delegate void Build<TContext>(in TContext context, ref ", builderClassName, " builder);")
                    .AppendLine("#endif")
                    .AppendSeparatorLine()
                    .AppendLineIndent("internal ComplexValueBuilder _builder;")
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                        $$"""
                        internal {{builderClassName}}(ComplexValueBuilder builder)
                        {
                            _builder = builder;
                        }
                        """);

        if (forArray)
        {
            generator
                .AppendArrayBuilders(typeDeclaration, isObject);
        }

        if (forObject)
        {
            generator
                .AppendObjectBuilders(typeDeclaration, isArray, builders);
        }

        generator
            .ReserveName("BuildValue");

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("internal static void BuildValue(Build value, ref ComplexValueBuilder o)")
            .AppendLineIndent("{")
            .PushIndent();

        if (forArray)
        {
            generator
                .AppendLineIndent("o.StartArray();");
        }
        else
        {
            generator
                .AppendLineIndent("o.StartObject();");
        }

        generator
                .AppendSeparatorLine()
                .AppendLineIndent(builderClassName, " ovb = new(o);")
                .AppendLineIndent("value(ref ovb);")
                .AppendLineIndent("o = ovb._builder;");

        if (forArray)
        {
            generator
                .AppendLineIndent("o.EndArray();");
        }
        else
        {
            generator
                .AppendLineIndent("o.EndObject();");
        }

        generator
            .PopIndent()
            .AppendLineIndent("}");

        generator
    .AppendSeparatorLine()
    .AppendLineIndent("internal static void BuildValue<TContext>(in TContext context, Build<TContext> value, ref ComplexValueBuilder o)")
    .AppendLine("#if NET9_0_OR_GREATER")
    .PushIndent()
        .AppendLineIndent("where TContext : allows ref struct")
    .PopIndent()
    .AppendLine("#endif")
    .AppendLineIndent("{")
    .PushIndent();

        if (forArray)
        {
            generator
                .AppendLineIndent("o.StartArray();");
        }
        else
        {
            generator
                .AppendLineIndent("o.StartObject();");
        }

        generator
                .AppendSeparatorLine()
                .AppendLineIndent(builderClassName, " ovb = new(o);")
                .AppendLineIndent("value(context, ref ovb);")
                .AppendLineIndent("o = ovb._builder;");

        if (forArray)
        {
            generator
                .AppendLineIndent("o.EndArray();");
        }
        else
        {
            generator
                .AppendLineIndent("o.EndObject();");
        }

        generator
            .PopIndent()
            .AppendLineIndent("}");


        return generator
            .EndClassStructOrEnumDeclaration();
    }

    private static CodeGenerator AppendCallStaticCreateWithBuilder(this CodeGenerator generator, MethodParameter[] parameters)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        generator
            .AppendIndent("Create(ref _builder");
     

        for (int i = 0; i < parameters.Length; ++i)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            generator
                .Append(", ")
                .Append(parameters[i].GetName(generator));
        }

        return generator
            .AppendLine(");");
    }


    private static CodeGenerator AppendCallStaticCreateWithBuilderAndContext(this CodeGenerator generator, MethodParameter[] parameters)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        generator
            .AppendIndent("Create(", parameters[0].GetName(generator), ", ref _builder");


        for (int i = 1; i < parameters.Length; ++i)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            generator
                .Append(", ")
                .Append(parameters[i].GetName(generator));
        }

        return generator
            .AppendLine(");");
    }

    /// <summary>
    /// Appends methods to create <c>JsonDocumentBuilder&lt;Mutable&gt;</c> instances for the specified type declaration.
    /// </summary>
    /// <param name="generator">The code generator to which to append the methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the document builder creation methods.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    private static CodeGenerator AppendCommonBuildDocuments(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        // We only expect 1 row for a simple type.
        int initialCapacity = 1;

        if ((typeDeclaration.ImpliedCoreTypes() & (CoreTypes.Object | CoreTypes.Array)) != 0)
        {
            // But we allow a default initial capacity of 30 for objects or arrays

            if (typeDeclaration.IsFixedSizeNumericArray())
            {
                // If this is a fixed size array, we use the value buffer size as the initial capacity
                initialCapacity = typeDeclaration.ArrayValueBufferSize() + (2 * typeDeclaration.ArrayRank()) ?? 30;
            }
            else
            {
                initialCapacity = 30;
            }
        }

        generator
            .ReserveNameIfNotReserved("BuildDocument")
            .AppendSeparatorLine()
            .AppendBlockIndent(
            $$"""
            /// <summary>
            /// Creates and initializes a mutable document from a value.
            /// </summary>
            /// <param name="workspace">The JSON workspace.</param>
            /// <param name="value">The value with which to initialize the builder.</param>
            /// <param name="initialCapacity">The (optional) estimate of the capacity to reserve for the document.</param>
            /// <returns>An instance of a mutable document initialized with the given value.</returns>
            public static JsonDocumentBuilder<{{generator.MutableClassName()}}> BuildDocument(
                JsonWorkspace workspace, scoped in {{generator.SourceClassName()}} value, int initialCapacity = {{initialCapacity}})
            {
                // Create the document builder without a MetadataDb
                JsonDocumentBuilder<{{generator.MutableClassName()}}> documentBuilder = workspace.BuildDocument<{{generator.MutableClassName()}}>(-1);
                ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
                value.AddAsItem(ref cvb);
                Debug.Assert(cvb.MemberCount == 1);
                ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
                return documentBuilder;
            }
            """);

        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        bool isArray = (core & CoreTypes.Array) != 0;
        bool isObject = (core & CoreTypes.Object) != 0;

        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;

        string sourceClassName = generator.SourceClassName();

        if (isArray && isObject)
        {
            if (hasFallbackArrayType && generator.ArrayBuilderClassName() is string arrayBuilderClassName)
            {
                AppendBuildDocumentForBuilder(generator, initialCapacity, sourceClassName, arrayBuilderClassName, forContextOnly: true);
            }

            if (hasFallbackObjectType && generator.ObjectBuilderClassName() is string objectBuilderClassName)
            {
                AppendBuildDocumentForBuilder(generator, initialCapacity, sourceClassName, objectBuilderClassName, forContextOnly: true);
            }
        }
        else
        {
            if (((isObject && hasFallbackObjectType) || (isArray && hasFallbackArrayType)) &&
                generator.BuilderClassName() is string builderClassName)
            {
                AppendBuildDocumentForBuilder(generator, initialCapacity, sourceClassName, builderClassName);
            }
        }

        foreach (ComposedBuilder builder in builders)
        {
            // Don't add them for built-in JsonNotAny types
            if (builder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (builder.IsArray && builder.ArrayBuilderName is string arrayBuilderClassName1)
            {
                AppendBuildDocumentForBuilder(generator, initialCapacity, $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{generator.SourceClassName(builder.TypeDeclaration.FullyQualifiedDotnetTypeName())}", $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{arrayBuilderClassName1}");
            }

            if (builder.IsObject && builder.ObjectBuilderName is string objectBuilderClassName1)
            {
                AppendBuildDocumentForBuilder(generator, initialCapacity, $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{generator.SourceClassName(builder.TypeDeclaration.FullyQualifiedDotnetTypeName())}", $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{objectBuilderClassName1}");
            }
        }

        return generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Creates and initializes a mutable document from this instance.")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("/// <param name=\"workspace\">The JSON workspace.</param>")
            .AppendLineIndent("/// <returns>An instance of a mutable document initialized with this instance.</returns>")
            .AppendLineIndent("public JsonDocumentBuilder<", generator.MutableClassName(), "> BuildDocument(JsonWorkspace workspace)")
            .AppendLineIndent("{")
            .PushIndent()
                .AppendLineIndent("return workspace.BuildDocument<", typeDeclaration.DotnetTypeName(), ", ", generator.MutableClassName(), ">(this);")
            .PopIndent()
            .AppendLineIndent("}");

        static void AppendBuildDocumentForBuilder(CodeGenerator generator, int initialCapacity, string sourceClassName, string builderClassName, bool forContextOnly = false)
        {
            if (!forContextOnly)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendBlockIndent(
                        $$"""
                        /// <summary>
                        /// Creates and initializes a mutable document from a value.
                        /// </summary>
                        /// <param name="workspace">The JSON workspace.</param>
                        /// <param name="value">The value with which to initialize the builder.</param>
                        /// <param name="initialCapacity">The (optional) estimate of the capacity to reserve for the document.</param>
                        /// <returns>An instance of a mutable document initialized with the given value.</returns>
                        public static JsonDocumentBuilder<{{generator.MutableClassName()}}> BuildDocument(
                            JsonWorkspace workspace, scoped in {{builderClassName}}.Build value, int initialCapacity = {{initialCapacity}})
                        {
                            // Create the document builder without a MetadataDb
                            JsonDocumentBuilder<{{generator.MutableClassName()}}> documentBuilder = workspace.BuildDocument<{{generator.MutableClassName()}}>(-1);
                            ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
                            var source = new {{sourceClassName}}(value);
                            source.AddAsItem(ref cvb);
                            Debug.Assert(cvb.MemberCount == 1);
                            ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
                            return documentBuilder;
                        }
                        """);
            }

            generator
                .AppendSeparatorLine()
                .AppendBlockIndent(
                    $$"""
                    /// <summary>
                    /// Creates and initializes a mutable document from a value.
                    /// </summary>
                    /// <typeparam name="TContext">The type of the context to pass to the builder.</typeparam>
                    /// <param name="workspace">The JSON workspace.</param>
                    /// <param name="context">The context to pass to the builder.</param>
                    /// <param name="value">The value with which to initialize the builder.</param>
                    /// <param name="initialCapacity">The (optional) estimate of the capacity to reserve for the document.</param>
                    /// <returns>An instance of a mutable document initialized with the given value.</returns>
                    public static JsonDocumentBuilder<{{generator.MutableClassName()}}> BuildDocument<TContext>(
                        JsonWorkspace workspace, scoped in TContext context, scoped in {{builderClassName}}.Build<TContext> value, int initialCapacity = {{initialCapacity}})
                        #if NET9_0_OR_GREATER
                        where TContext : allows ref struct
                        #endif
                    {
                        // Create the document builder without a MetadataDb
                        JsonDocumentBuilder<{{generator.MutableClassName()}}> documentBuilder = workspace.BuildDocument<{{generator.MutableClassName()}}>(-1);
                        ComplexValueBuilder cvb = ComplexValueBuilder.Create(documentBuilder, initialCapacity);
                        var source = new {{sourceClassName}}<TContext>(context, value);
                        source.AddAsItem(ref cvb);
                        Debug.Assert(cvb.MemberCount == 1);
                        ((IMutableJsonDocument)documentBuilder).SetAndDispose(ref cvb);
                        return documentBuilder;
                    }
                    """);
        }
    }

    /// <summary>
    /// Appends methods to create <c>Source</c> and <c>Source&lt;TContext&gt;</c> instances for the specified type declaration.
    /// </summary>
    /// <param name="generator">The code generator to which to append the methods.</param>
    /// <param name="typeDeclaration">The type declaration for which to emit the document builder creation methods.</param>
    /// <returns>A reference to the generator having completed the operation.</returns>
    private static CodeGenerator AppendCommonBuild(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        // We only expect row for a simple type.
        int initialCapacity = 1;

        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        if ((core & (CoreTypes.Object | CoreTypes.Array)) != 0)
        {
            bool isArray = (core & CoreTypes.Array) != 0;
            bool isObject = (core & CoreTypes.Object) != 0;
            string sourceClassName = generator.SourceClassName();

            bool hasFallbackArrayType =
                typeDeclaration.ExplicitArrayItemsType() is not null;

            bool hasFallbackObjectType =
                typeDeclaration.LocalEvaluatedPropertyType() is not null ||
                typeDeclaration.HasPropertyDeclarations;

            if (isObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
            {
                AppendCreateBuild(generator, initialCapacity, sourceClassName, isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName() );
            }

            if (isArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
            {
                AppendCreateBuild(generator, initialCapacity, sourceClassName, isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName());
            }
        }

        foreach (ComposedBuilder builder in builders)
        {
            // Don't add them for built-in JsonNotAny types
            if (builder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (builder.ArrayBuilderName is string arrayBuilderClassName1)
            {
                AppendCreateBuild(generator, initialCapacity, $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{generator.SourceClassName(builder.TypeDeclaration.FullyQualifiedDotnetTypeName())}", $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{arrayBuilderClassName1}");
            }

            if (builder.ObjectBuilderName is string objectBuilderClassName1)
            {
                AppendCreateBuild(generator, initialCapacity, $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{generator.SourceClassName(builder.TypeDeclaration.FullyQualifiedDotnetTypeName())}", $"{builder.TypeDeclaration.FullyQualifiedDotnetTypeName()}.{objectBuilderClassName1}");
            }
        }

        return generator;

        static void AppendCreateBuild(CodeGenerator generator, int initialCapacity, string sourceClassName, string builderClassName)
        {
            generator
                .AppendSeparatorLine()
                .AppendBlockIndent(
                    $$"""
                    /// <summary>
                    /// Build an instance of the value.
                    /// </summary>
                    /// <param name="buildValue">The callback that builds the value.</param>
                    /// <param name="initialCapacity">The (optional) estimate of the capacity to reserve for the document.</param>
                    /// <returns>The source from which to build the value.</returns>
                    public static {{sourceClassName}} Build(
                        scoped in {{builderClassName}}.Build buildValue, int initialCapacity = {{initialCapacity}})
                    {
                        return new {{sourceClassName}}(buildValue);
                    }
                    """);

            generator
                .AppendSeparatorLine()
                .AppendBlockIndent(
                    $$"""
                    /// <summary>
                    /// Build an instance of the value.
                    /// </summary>
                    /// <typeparam name="TContext">The type of the context to pass to the builder.</typeparam>
                    /// <param name="context">The context to pass to the builder.</param>
                    /// <param name="buildValue">The callback that builds the value.</param>
                    /// <param name="initialCapacity">The (optional) estimate of the capacity to reserve for the document.</param>
                    /// <returns>The source from which to build the value.</returns>
                    public static {{sourceClassName}}<TContext> Build<TContext>(
                        scoped in TContext context, scoped in {{builderClassName}}.Build<TContext> buildValue, int initialCapacity = {{initialCapacity}})
                        #if NET9_0_OR_GREATER
                        where TContext : allows ref struct
                        #endif
                    {
                        return new {{sourceClassName}}<TContext>(context, buildValue);
                    }
                    """);
        }
    }

    private static CodeGenerator AppendCreateAddProperties(this CodeGenerator generator, MethodParameter[] parameters, PropertyDeclaration[] properties)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        int parameterIndex = 0;

        // The next parameter is the builder, so we grab the builder name
        // then start the parameter index up one more
        string builderName = parameters[parameterIndex++].GetName(generator);

        foreach (PropertyDeclaration property in properties)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (property.RequiredOrOptional != RequiredOrOptional.Optional)
            {
                parameterIndex = AppendRequiredProperty(generator, parameters, parameterIndex, property, builderName);
            }
            else
            {
                parameterIndex = AppendOptionalProperty(generator, parameters, parameterIndex, property, builderName);
            }
        }

        return generator;
    }

    private static CodeGenerator AppendCreateTuple(this CodeGenerator generator, TypeDeclaration typeDeclaration, TupleTypeDeclaration tupleType, bool allowsNonPrefixItems)
    {
        generator
            .AppendSeparatorLine()
            .AppendIndent("public void CreateTuple(in ");

        int index = 0;
        foreach (ReducedTypeDeclaration item in tupleType.ItemsTypes)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (index > 0)
            {
                generator.Append(", in ");
            }

            index++;

            string fqdtn = item.ReducedType.FullyQualifiedDotnetTypeName();
            generator
                .Append(fqdtn)
                .Append(".")
                .Append(generator.SourceClassName(fqdtn))
                .Append(" item")
                .Append(index);
        }

        generator
            .AppendLine(")")
            .AppendLineIndent("{")
            .PushIndent();

        for (int i = 1; i <= tupleType.ItemsTypes.Length; i++)
        {
            generator
                .AppendLineIndent("item", i.ToString(), ".AddAsItem(ref _builder);");
        }

        if (allowsNonPrefixItems)
        {
            generator
                .AppendLineIndent("_addedPrefixItems = true;");
        }

        generator
            .PopIndent()
            .AppendLineIndent("}");

        return generator;
    }

    private static CodeGenerator AppendFixedSizeNumericArray(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isObject)
    {
        if (typeDeclaration.IsFixedSizeNumericArray())
        {
            NumericTypeName numericTypeName = typeDeclaration.PreferredDotnetNumericTypeName() ?? throw new InvalidOperationException("Expected numeric type name");

            if (numericTypeName.IsNetOnly)
            {
                generator
                    .AppendLine("#if NET");
            }

            generator
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Creates a tensor from the given numeric span.")
                .AppendLineIndent("/// </summary>")
                .AppendLineIndent("/// <param name=\"tensor\">The data from which to create the tensor.</param>")
                .AppendLineIndent("/// <returns>The number of items consumed.</returns>")
                .AppendLineIndent("/// <exception cref=\"ArgumentException\">The tensor did not contain the correct number of values for the array rank and dimension.</exception>")
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public int CreateTensor(ReadOnlySpan<", numericTypeName.Name, "> tensor)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("    return CreateTensor(tensor, false);")
                .PopIndent()
                .AppendLineIndent("}");

            if (typeDeclaration.ArrayRank() > 1)
            {
                TypeDeclaration arrayItemsType = typeDeclaration.ArrayItemsType()!.ReducedType;
                bool isAlsoObject = (arrayItemsType.ImpliedCoreTypesOrAny() & CoreTypes.Object) != 0;

                string arrayItemsTypeName = arrayItemsType.FullyQualifiedDotnetTypeName() ?? throw new InvalidOperationException("Expected an array items type name.");
                string builderClassName = isAlsoObject ? generator.ArrayBuilderClassName(arrayItemsTypeName) : generator.BuilderClassName(arrayItemsTypeName);
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Creates a tensor from the given numeric span.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"tensor\">The data from which to create the tensor.</param>")
                    .AppendLineIndent("/// <param name=\"createArray\">Determines whether to create the wrapping array around the items.</param>")
                    .AppendLineIndent("/// <returns>The number of items consumed.</returns>")
                    .AppendLineIndent("/// <exception cref=\"ArgumentException\">The tensor did not contain the correct number of values for the array rank and dimension.</exception>")
                    .AppendLineIndent("internal int CreateTensor(ReadOnlySpan<", numericTypeName.Name, "> tensor, bool createArray)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendSeparatorLine()
                        .AppendLineIndent("int index = 0;")
                        .AppendLineIndent("if (tensor.Length != ValueBufferSize)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("CodeGenThrowHelper.ThrowArgumentException_ArrayBufferLength(nameof(tensor), ValueBufferSize);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (createArray)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("_builder.StartArray();")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("while (index < tensor.Length)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("ComplexValueBuilder.ComplexValueHandle handle = default;")
                            .AppendSeparatorLine()
                            .AppendLineIndent("handle = _builder.StartItem();")
                            .AppendLineIndent(arrayItemsTypeName, ".", builderClassName, " inner = new(_builder);")
                            .AppendLineIndent("index += inner.CreateTensor(tensor.Slice(index, ", arrayItemsTypeName, ".ValueBufferSize), createArray: true);")
                            .AppendLineIndent("_builder = inner._builder;")
                            .AppendSeparatorLine()
                            .AppendLineIndent("_builder.EndItem(handle);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (createArray)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("_builder.EndArray();")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("return ValueBufferSize;")
                    .PopIndent()
                    .AppendLineIndent("}");
            }
            else
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("/// <summary>")
                    .AppendLineIndent("/// Creates a tensor from the given numeric span.")
                    .AppendLineIndent("/// </summary>")
                    .AppendLineIndent("/// <param name=\"tensor\">The data from which to create the tensor.</param>")
                    .AppendLineIndent("/// <param name=\"createArray\">Determines whether to create the wrapping array around the items.</param>")
                    .AppendLineIndent("/// <returns>The number of items consumed.</returns>")
                    .AppendLineIndent("/// <exception cref=\"ArgumentException\">The tensor did not contain the correct number of values for the array rank and dimension.</exception>")
                    .AppendLineIndent("internal int CreateTensor(ReadOnlySpan<", numericTypeName.Name, "> tensor, bool createArray)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("if (tensor.Length != ValueBufferSize)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("CodeGenThrowHelper.ThrowArgumentException_ArrayBufferLength(nameof(tensor), ValueBufferSize);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("if (createArray)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("_builder.AddItemArrayValue(tensor);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendLineIndent("else")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("foreach (int item in tensor)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("_builder.AddItem(item);")
                            .PopIndent()
                            .AppendLineIndent("}")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendSeparatorLine()
                        .AppendLineIndent("return ValueBufferSize;")
                    .PopIndent()
                    .AppendLineIndent("}");
            }

            if (numericTypeName.IsNetOnly)
            {
                generator
                    .AppendLine("#endif");
            }
        }

        return generator;
    }

    private static void AppendFixedSizeNumericArrayFactoryMethod(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
    {
        NumericTypeName? arrayType = typeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName();
        if (arrayType is NumericTypeName at)
        {
            if (at.IsNetOnly)
            {
                if (seenArrayValues.Add($"[{at.Name}]"))
                {
                    generator
                        .ReserveNameIfNotReserved("FromArray")
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("public static ", generator.SourceClassName(), " FromArray(ReadOnlySpan<", at.Name, "> value)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("if (value.Length != ValueBufferSize)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("throw new ArgumentException(nameof(value));")
                            .PopIndent()
                            .AppendLineIndent("}")
                            .AppendSeparatorLine()
                        .AppendLineIndent("return new(value);")
                        .PopIndent()
                        .AppendLineIndent("}")
                        .AppendLine("#endif");
                }
            }
            else
            {
                if (seenArrayValues.Add($"[{at.Name}]"))
                {
                    generator
                        .ReserveNameIfNotReserved("FromArray")
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static ", generator.SourceClassName(), " FromArray(ReadOnlySpan<", at.Name, "> value)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("if (value.Length != ValueBufferSize)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("throw new ArgumentException(nameof(value));")
                            .PopIndent()
                            .AppendLineIndent("}")
                            .AppendSeparatorLine()
                        .AppendLineIndent("return new(value);")
                        .PopIndent()
                        .AppendLineIndent("}");
                }
            }
        }
    }

    private static CodeGenerator AppendNumericArrayConstructors(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
    {
        if (typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
        {
            NumericTypeName? arrayType = typeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName();

            if (arrayType is NumericTypeName at)
            {
                if (at.IsNetOnly)
                {
                    if (seenArrayValues.Add($"[{at.Name}]"))
                    {
                        generator
                            .AppendLine("#if NET")
                            .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<", at.Name, "> value)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("_", at.Name, "Array = value;")
                                .AppendLineIndent("_kind = Kind.", GetNumericArrayKind(generator, at), ";")
                            .PopIndent()
                            .AppendLineIndent("}")
                            .AppendLine("#endif");
                    }
                }
                else
                {
                    if (seenArrayValues.Add($"[{at.Name}]"))
                    {
                        generator
                            .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<", at.Name, "> value)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("_", at.Name, "Array = value;")
                                .AppendLineIndent("_kind = Kind.", GetNumericArrayKind(generator, at), ";")
                            .PopIndent()
                            .AppendLineIndent("}");
                    }
                }
            }
        }

        return generator;
    }

    private static void AppendNumericArrayFactoryMethod(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
    {
        NumericTypeName? arrayType = typeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName();
        if (arrayType is NumericTypeName at)
        {
            if (at.IsNetOnly)
            {
                if (seenArrayValues.Add($"[{at.Name}]"))
                {
                    generator
                        .ReserveNameIfNotReserved("FromArray")
                        .AppendSeparatorLine()
                        .AppendLine("#if NET")
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static ", generator.SourceClassName(), " FromArray(ReadOnlySpan<", at.Name, "> value) => new(value);")
                        .AppendLine("#endif");
                }
            }
            else
            {
                if (seenArrayValues.Add($"[{at.Name}]"))
                {
                    generator
                        .ReserveNameIfNotReserved("FromArray")
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static ", generator.SourceClassName(), " FromArray(ReadOnlySpan<", at.Name, "> value) => new(value);");
                }
            }
        }
    }

    private static void AppendNumericArrayTypeFields(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
    {
        if (typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
        {
            NumericTypeName? arrayType = typeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName();
            if (arrayType is NumericTypeName at)
            {
                if (at.IsNetOnly)
                {
                    if (seenArrayValues.Add($"[{at.Name}]"))
                    {
                        generator
                            .ReserveNameIfNotReserved($"_{at.Name}Array")
                            .AppendLine("#if NET")
                            .AppendLineIndent("private readonly ReadOnlySpan<", at.Name, "> _", at.Name, "Array;")
                            .AppendLine("#endif");
                    }
                }
                else
                {
                    if (seenArrayValues.Add($"[{at.Name}]"))
                    {
                        generator
                            .ReserveNameIfNotReserved($"_{at.Name}Array")
                            .AppendLineIndent("private readonly ReadOnlySpan<", at.Name, "> _", at.Name, "Array;");
                    }
                }
            }
        }
    }

    private static CodeGenerator AppendObjectBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isAlsoArray, List<ComposedBuilder> builders)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        return generator
            .AppendObjectCreateMethods(typeDeclaration, isAlsoArray, builders)
            .AppendAddPropertyMethod(typeDeclaration, isAlsoArray);
    }

    private static CodeGenerator AppendObjectCreateMethods(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isAlsoArray, List<ComposedBuilder> builders)
    {
        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        if (!typeDeclaration.HasPropertyDeclarations)
        {
            return generator;
        }

        // The static method requires the builder
        MethodParameter[] staticMethodParameters = BuildMethodParameters(generator, typeDeclaration);

        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        PropertyDeclaration[] orderedProperties = BuildOrderedProperties(typeDeclaration);

        if (generator.IsCancellationRequested)
        {
            return generator;
        }

        generator
                .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Creates an instance of a <see cref=\"", typeDeclaration.DotnetTypeName(), "\"/>.")
            .AppendLineIndent("/// </summary>")
            .BeginReservedMethodDeclaration(
                "internal static",
                "void",
                "Create",
                staticMethodParameters);

        generator
                .AppendCreateAddProperties(staticMethodParameters, orderedProperties)
            .EndMethodDeclaration();

        MethodParameter[] nonStaticMethodParameters = [.. staticMethodParameters.Skip(1)];

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Creates an instance of a <see cref=\"", typeDeclaration.DotnetTypeName(), "\"/>.")
            .AppendLineIndent("/// </summary>")
            .BeginReservedMethodDeclaration(
                "public",
                "void",
                "Create",
                nonStaticMethodParameters
                )
                .AppendCallStaticCreateWithBuilder(nonStaticMethodParameters)
            .EndMethodDeclaration();


        if ((typeDeclaration.ImpliedCoreTypesOrAny() & (CoreTypes.Object | CoreTypes.Array)) != 0 &&
            typeDeclaration.PropertyDeclarations.Any(p =>
                p.ReducedPropertyType.SingleConstantValue().ValueKind == JsonValueKind.Undefined &&
                !p.ReducedPropertyType.IsBuiltInJsonNotAnyType() &&
                (p.ReducedPropertyType.ImpliedCoreTypesOrAny() & (CoreTypes.Object | CoreTypes.Array)) != 0)
            )
        {
            MethodParameter[] staticMethodParametersWithContext = BuildMethodParametersWithContext(generator, typeDeclaration);
            MethodParameter[] nonStaticMethodParametersWithContext = [staticMethodParametersWithContext[0], ..staticMethodParametersWithContext.Skip(2)];

            generator
                    .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Creates an instance of a <see cref=\"", typeDeclaration.DotnetTypeName(), "\"/>.")
                .AppendLineIndent("/// </summary>")
                .BeginReservedMethodDeclaration(
                    "internal static",
                    "void",
                    "Create<TContext>",
                    """
                    #if NET9_0_OR_GREATER
                    where TContext : allows ref struct
                    #endif
                    """,
                    staticMethodParametersWithContext);

            generator
                    .AppendCreateAddProperties([.. staticMethodParametersWithContext.Skip(1)], orderedProperties)
                .EndMethodDeclaration();

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("/// <summary>")
                .AppendLineIndent("/// Creates an instance of a <see cref=\"", typeDeclaration.DotnetTypeName(), "\"/>.")
                .AppendLineIndent("/// </summary>")
                .BeginReservedMethodDeclaration(
                    "public",
                    "void",
                    "Create<TContext>",
                    """
                    #if NET9_0_OR_GREATER
                    where TContext : allows ref struct
                    #endif
                    """,
                    nonStaticMethodParametersWithContext)
                    .AppendCallStaticCreateWithBuilderAndContext(nonStaticMethodParametersWithContext)
                .EndMethodDeclaration();

        }

        return generator;
    }

    private static int AppendOptionalProperty(CodeGenerator generator, MethodParameter[] parameters, int parameterIndex, PropertyDeclaration property, string builderName)
    {
        if (generator.IsCancellationRequested)
        {
            return parameterIndex;
        }

        string propertyNamesClass = generator.JsonPropertyNamesEscapedClassName();
        string parameterName = parameters[parameterIndex++].GetName(generator);

        generator
            .AppendLineIndent(
                parameterName,
                ".AddAsProperty(",
                propertyNamesClass,
                ".",
                property.DotnetPropertyName(),
                ", ref ",
                builderName,
                ", escapeName: false);");

        return parameterIndex;
    }

    private static int AppendRequiredProperty(CodeGenerator generator, MethodParameter[] parameters, int parameterIndex, PropertyDeclaration property, string builderName)
    {
        if (generator.IsCancellationRequested)
        {
            return parameterIndex;
        }

        string propertyNamesClass = generator.JsonPropertyNamesEscapedClassName();
        if (property.ReducedPropertyType.SingleConstantValue().ValueKind != JsonValueKind.Undefined)
        {
            generator
                .AppendLineIndent(
                    builderName,
                    ".AddProperty(",
                    propertyNamesClass,
                    ".",
                    property.DotnetPropertyName(),
                    ", ",
                    property.ReducedPropertyType.FullyQualifiedDotnetTypeName(),
                    ".ConstInstance);");
        }
        else
        {
            string parameterName = parameters[parameterIndex++].GetName(generator);

            generator
                .AppendLineIndent(
                    parameterName,
                    ".AddAsProperty(",
                    propertyNamesClass,
                    ".",
                    property.DotnetPropertyName(),
                    ", ref ",
                    builderName,
                    ", escapeName: false);");
        }
       
        return parameterIndex;
    }

    private static CodeGenerator AppendSourceConstructors(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, bool forContext = false)
    {
        HashSet<string> seenConstructorParameters = [];
        HashSet<string> seenNumericArrayTypes = [];
        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        if (!forContext)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private ", generator.SourceClassName(), "(JsonElement jsonElement)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("_jsonElement = jsonElement;")
                    .AppendLineIndent("_kind = jsonElement.ValueKind == JsonValueKind.Undefined ? Kind.Unknown : Kind.JsonElement;")
                .PopIndent()
                .AppendLineIndent("}");


            if ((core & CoreTypes.String) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<byte> value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf8Backing = value;")
                        .AppendLineIndent("_kind = Kind.Utf8String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<char> value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf16Backing = value;")
                        .AppendLineIndent("_kind = Kind.Utf16String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<byte> value, bool requiresUnescaping)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf8Backing = value;")
                        .AppendLineIndent("_kind = requiresUnescaping ? Kind.RawUtf8StringRequiresUnescaping : Kind.RawUtf8StringNotRequiresUnescaping;")
                    .PopIndent()
                    .AppendLineIndent("}");

                if (typeDeclaration.Format() is string format)
                {
                    FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConstructors(generator, typeDeclaration, format, seenConstructorParameters);
                }
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private ", generator.SourceClassName(), "(ReadOnlySpan<byte> value, Kind kind)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("Debug.Assert(kind is Kind.FormattedNumber);")
                        .AppendLineIndent("_utf8Backing = value;")
                        .AppendLineIndent("_kind = kind;")
                    .PopIndent()
                    .AppendLineIndent("}");

                if (typeDeclaration.Format() is not string format ||
                    !FormatHandlerRegistry.Instance.NumberFormatHandlers.AppendFormatSourceConstructors(generator, typeDeclaration, format, seenConstructorParameters))
                {
                    // There were no format-specific constructors, so we fall back to a default of double for number,
                    // and long for integer.
                    if ((core & CoreTypes.Number) != 0)
                    {
                        if (seenConstructorParameters.Add("double"))
                        {
                            generator
                                .AppendSeparatorLine()
                                .AppendLineIndent("private ", generator.SourceClassName(), "(double value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (isAlsoArray, buffer, out written) => Utf8Formatter.TryFormat(isAlsoArray, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                        }
                    }
                    else
                    {
                        if (seenConstructorParameters.Add("long"))
                        {
                            generator
                                .AppendSeparatorLine()
                                .AppendLineIndent("private ", generator.SourceClassName(), "(long value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (isAlsoArray, buffer, out written) => Utf8Formatter.TryFormat(isAlsoArray, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                        }
                    }
                }
            }

            if ((core & CoreTypes.Boolean) != 0)
            {
                if (seenConstructorParameters.Add("bool"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private ", generator.SourceClassName(), "(bool value) { _kind = value ? Kind.True : Kind.False; }");
                }
            }

            if ((core & CoreTypes.Null) != 0)
            {
                if (seenConstructorParameters.Add("null"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private ", generator.SourceClassName(), "(Kind kind) { Debug.Assert(kind == Kind.Null); _kind = Kind.Null; }");
                }
            }


            generator
                .AppendNumericArrayConstructors(typeDeclaration, seenNumericArrayTypes);
        }
        else
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private ", generator.SourceClassName(), "(", generator.SourceClassName(), " source) { _kind = Kind.Source; _context = default!; _source = source; }")
                .AppendSeparatorLine()
                .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "<TContext>(", generator.SourceClassName(), " source) => new (source);");
        }

        string buildContextType = forContext ? "Build<TContext>" : "Build";

        // This is the "has builder" case
        if ((core & (CoreTypes.Array | CoreTypes.Object)) != 0)
        {
            bool isArray = (core & CoreTypes.Array) != 0;
            bool isObject = (core & CoreTypes.Object) != 0;

            bool hasFallbackObjectType =
                typeDeclaration.LocalEvaluatedPropertyType() is not null ||
                typeDeclaration.HasPropertyDeclarations;
            bool hasFallbackArrayType =
                typeDeclaration.ExplicitArrayItemsType() is not null;

            if (isObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
            {
                string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent(
                        "internal ", generator.SourceClassName(), "(",
                        forContext ? "scoped in TContext context, " : "",
                         fqdtn,
                        ".",
                        isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(),
                        ".", buildContextType, " value) {", forContext ? "_context = context; " : "", "_objectBuilder = value; _kind = Kind.",
                        isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(),
                        "; }");
            }

            if (isArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
            {
                string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent(
                        "internal ", generator.SourceClassName(), "(",
                        forContext ? "scoped in TContext context, " : "",
                        fqdtn,
                        ".",
                        isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(),
                        ".", buildContextType, " value) {", forContext ? "_context = context; " : "", "_arrayBuilder = value; _kind = Kind.",
                        isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(),
                        "; }");
            }
        }

        foreach (ComposedBuilder composedBuilder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (composedBuilder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            generator
                .AppendNumericArrayConstructors(composedBuilder.TypeDeclaration, seenNumericArrayTypes);

            if (composedBuilder.TypeDeclaration.Format() is string format)
            {
                CoreTypes composedCore = composedBuilder.TypeDeclaration.ImpliedCoreTypesOrAny();
                if ((composedCore & (CoreTypes.Number | CoreTypes.Integer)) != 0)
                {
                    FormatHandlerRegistry.Instance.NumberFormatHandlers.AppendFormatSourceConstructors(generator, composedBuilder.TypeDeclaration, format, seenConstructorParameters);
                }

                if ((composedCore & CoreTypes.String) != 0)
                {
                    FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConstructors(generator, composedBuilder.TypeDeclaration, format, seenConstructorParameters);
                }
            }

            if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
            {
                if (!(composedBuilder.IsObject && typeDeclaration.HasPropertyDeclarations))
                {
                    string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public ", generator.SourceClassName(), "(",
                            forContext ? "scoped in TContext context, " : "",
                            fqdtn,
                            ".",
                            composedBuilder.IsArray ? generator.ObjectBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                            ".", buildContextType, " value) {", forContext ? "_context = context; " : "", "_",
                            composedBuilder.ObjectInstanceName,
                            " = value; _kind = Kind.",
                            composedBuilder.ObjectKindName,
                            "; }");
                }
            }

            if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
            {
                string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent(
                        "public ", generator.SourceClassName(), "(",
                        forContext ? "scoped in TContext context, " : "",
                        fqdtn,
                        ".",
                        composedBuilder.IsObject ? generator.ArrayBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                        ".", buildContextType, " value) {", forContext ? "_context = context; " : "", "_",
                        composedBuilder.ArrayInstanceName,
                        " = value; _kind = Kind.",
                        composedBuilder.ArrayKindName,
                        "; }");
            }
        }

        return generator;
    }

    private static CodeGenerator AppendSourceConversionOperators(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        HashSet<string> seenConversionOperators = [];

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(", typeDeclaration.DotnetTypeName(), " instance) => new(JsonElement.From(instance));");

        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        if ((core & CoreTypes.String) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(ReadOnlySpan<byte> value) => new (value);")
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(ReadOnlySpan<char> value) => new (value);")
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(string value) => new (value.AsSpan());");

            if (typeDeclaration.Format() is string format)
            {
                FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConversionOperators(generator, typeDeclaration, format, seenConversionOperators);
            }
        }

        bool hasNumericBuilder = builders.Any(b => (b.TypeDeclaration.ImpliedCoreTypesOrAny() & (CoreTypes.Number | CoreTypes.Integer)) != 0);
        if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0 && !hasNumericBuilder)
        {
            if (typeDeclaration.Format() is not string format ||
                !FormatHandlerRegistry.Instance.NumberFormatHandlers.AppendFormatSourceConversionOperators(generator, typeDeclaration, format, seenConversionOperators))
            {
                // There were no format-specific constructors, so we fall back to a default of double for number,
                // and long for integer.
                if ((core & CoreTypes.Number) != 0)
                {
                    if (seenConversionOperators.Add("double"))
                    {
                        generator
                            .AppendSeparatorLine()
                            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(double value) => new (value);");
                    }
                }
                else
                {
                    if (seenConversionOperators.Add("long"))
                    {
                        generator
                            .AppendSeparatorLine()
                            .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                            .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(long value) => new (value);");
                    }
                }
            }
        }

        if ((core & CoreTypes.Boolean) != 0)
        {
            if (seenConversionOperators.Add("bool"))
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator ", generator.SourceClassName(), "(bool value) => new (value);");
            }
        }

        foreach (ComposedBuilder composedBuilder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (composedBuilder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (composedBuilder.TypeDeclaration.Format() is string format)
            {
                CoreTypes composedCore = composedBuilder.TypeDeclaration.ImpliedCoreTypesOrAny();
                if ((composedCore & (CoreTypes.Number | CoreTypes.Integer)) != 0)
                {
                    FormatHandlerRegistry.Instance.NumberFormatHandlers.AppendFormatSourceConversionOperators(generator, composedBuilder.TypeDeclaration, format, seenConversionOperators);
                }

                if ((composedCore & CoreTypes.String) != 0)
                {
                    FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConversionOperators(generator, composedBuilder.TypeDeclaration, format, seenConversionOperators);
                }
            }

            if (!(composedBuilder.IsObject && typeDeclaration.HasPropertyDeclarations))
            {
                string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent(
                            "public static implicit operator ", generator.SourceClassName(), "(",
                            fqdtn,
                            " instance) => new(JsonElement.From(instance));");
            }
        }

        return generator;
    }

    private static CodeGenerator AppendSourceFactoryMethods(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        if ((core & CoreTypes.String) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static ", generator.SourceClassName(), " RawString(ReadOnlySpan<byte> value, bool requiresUnescaping) => new(value, requiresUnescaping);");
        }

        if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static ", generator.SourceClassName(), " FormattedNumber(ReadOnlySpan<byte> value) => new(value, Kind.FormattedNumber);");
        }

        if ((core & CoreTypes.Null) != 0)
        {
            generator
                .AppendSeparatorLine()
                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                .AppendLineIndent("public static ", generator.SourceClassName(), " Null() => new(Kind.Null);");
        }

        HashSet<string> seenArrayTypes = [];
        if ((core & CoreTypes.Array) != 0)
        {
            if (typeDeclaration.IsNumericArray())
            {
                if (!typeDeclaration.IsFixedSizeArray() && !typeDeclaration.IsTuple())
                {
                    generator
                        .AppendNumericArrayFactoryMethod(typeDeclaration, seenArrayTypes);
                }

                // If the composed schema has a non-fixed size array
                if (typeDeclaration.IsFixedSizeNumericArray() && !ComposedSchemaHasNonFixedSizeNumericArray(builders, typeDeclaration))
                {
                    generator
                        .AppendFixedSizeNumericArrayFactoryMethod(typeDeclaration, seenArrayTypes);
                }
            }
        }

        foreach (ComposedBuilder composedBuilder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            core = composedBuilder.TypeDeclaration.ImpliedCoreTypesOrAny();
            TypeDeclaration t = composedBuilder.TypeDeclaration;
            if ((core & CoreTypes.Array) != 0)
            {
                if (t.IsNumericArray())
                {
                    if (!t.IsFixedSizeArray() && !t.IsTuple())
                    {
                        generator
                            .AppendNumericArrayFactoryMethod(t, seenArrayTypes);
                    }

                    if (t.IsFixedSizeArray() && !ComposedSchemaHasNonFixedSizeNumericArray(builders, t))
                    {
                        generator
                            .AppendFixedSizeNumericArrayFactoryMethod(t, seenArrayTypes);
                    }
                }
            }
        }

        return generator;
    }

    private static CodeGenerator AppendSourceFields(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, bool forContext = false)
    {
        generator
            .AppendSeparatorLine()
            .ReserveNameIfNotReserved("_kind")
            .AppendLineIndent("private readonly Kind _kind;");

        CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

        bool hasSimpleTypeBacking = false;

        if (!forContext)
        {
            generator
                .ReserveNameIfNotReserved("_jsonElement")
                .AppendLineIndent("private readonly JsonElement _jsonElement;");

            bool hasUtf8Backing = false;

            if ((core & CoreTypes.String) != 0)
            {
                generator
                .ReserveNameIfNotReserved("_utf8Backing")
                .ReserveNameIfNotReserved("_utf16Backing")
                    .AppendLineIndent("private readonly ReadOnlySpan<byte> _utf8Backing;")
                    .AppendLineIndent("private readonly ReadOnlySpan<char> _utf16Backing;");

                if (typeDeclaration.Format() is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType)
                {
                    generator
                        .ReserveNameIfNotReserved("_simpleTypeBacking")
                        .AppendLineIndent("private readonly SimpleTypesBacking _simpleTypeBacking;");
                    hasSimpleTypeBacking = true;
                }

                hasUtf8Backing = true;
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                if (!hasUtf8Backing)
                {
                    generator
                        .ReserveNameIfNotReserved("_utf8Backing")
                        .AppendLineIndent("private readonly ReadOnlySpan<byte> _utf8Backing;");
                }

                if (!hasSimpleTypeBacking)
                {
                    generator
                        .ReserveNameIfNotReserved("_simpleTypeBacking")
                        .AppendLineIndent("private readonly SimpleTypesBacking _simpleTypeBacking;");
                    hasSimpleTypeBacking = true;
                }
            }
        }
        else
        {
            generator
                .AppendLineIndent("TContext _context;")
                .AppendLineIndent("Source _source;");
        }

        bool isObject = (core & CoreTypes.Object) != 0;
        bool isArray = (core & CoreTypes.Array) != 0;
        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.LocalAndAppliedEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;
        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        string contextBuildType = forContext ? "Build<TContext>" : "Build";
        if (isObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
        {
            generator
                .ReserveNameIfNotReserved("_objectBuilder")
                .AppendLineIndent("private readonly ", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ".", contextBuildType, "? _objectBuilder;");
        }

        HashSet<string> seenArrayValues = [];

        if (isArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
        {
            generator
                .ReserveNameIfNotReserved("_arrayBuilder")
                .AppendLineIndent("private readonly ", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ".", contextBuildType, "? _arrayBuilder;");

            if (!forContext)
            {
                generator
                    .AppendNumericArrayTypeFields(typeDeclaration, seenArrayValues);
            }
        }

        foreach (ComposedBuilder builder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (builder.TypeDeclaration.IsBuiltInJsonNotAnyType())
            {
                continue;
            }

            if (builder.ObjectInstanceName is string oin)
            {
                if (!(builder.IsObject && typeDeclaration.HasPropertyDeclarations))
                {
                    string fqdtn = builder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .ReserveNameIfNotReserved($"_{oin}")
                        .AppendLineIndent(
                        "private readonly ",
                        fqdtn,
                        ".",
                        builder.IsArray ? generator.ObjectBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                        ".", contextBuildType, "? _",
                        oin,
                        ";");
                }
            }

            if (builder.ArrayInstanceName is string ain)
            {
                string fqdtn = builder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                generator
                    .ReserveNameIfNotReserved($"_{ain}")
                    .AppendLineIndent(
                    "private readonly ",
                    fqdtn,
                    ".",
                    builder.IsObject ? generator.ArrayBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                    ".", contextBuildType, "? _",
                    ain,
                    ";")
                   .AppendNumericArrayTypeFields(builder.TypeDeclaration, seenArrayValues);
            }

            if (!forContext)
            {
                if (!hasSimpleTypeBacking &&
                    builder.StringFormat is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType)
                {
                    generator
                        .ReserveNameIfNotReserved("_simpleTypeBacking")
                        .AppendLineIndent("private readonly SimpleTypesBacking _simpleTypeBacking;");
                    hasSimpleTypeBacking = true;
                }
            }
        }

        generator
            .AppendSeparatorLine()
            .AppendLineIndent("/// <summary>")
            .AppendLineIndent("/// Gets a value indicating whether this Source is undefined (uninitialized).")
            .AppendLineIndent("/// </summary>")
            .AppendLineIndent("public bool IsUndefined => _kind == Kind.Unknown;");

        return generator;
    }

    private static MethodParameter[] BuildMethodParameters(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return [];
        }

        return
        [
                new MethodParameter("ref", "ComplexValueBuilder", generator.GetUniqueParameterNameInScope("builder", childScope: "Create")),
                .. typeDeclaration.PropertyDeclarations
                        .Where(p => p.RequiredOrOptional != RequiredOrOptional.Optional &&
                               p.ReducedPropertyType.SingleConstantValue().ValueKind == JsonValueKind.Undefined &&
                               !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                        .OrderBy(p => p.JsonPropertyName)
                        .Select(p => new MethodParameter("in", GetSource(generator, p.ReducedPropertyType.FullyQualifiedDotnetTypeName()), generator.GetUniqueParameterNameInScope(p.JsonPropertyName, childScope: "Create"))),
                .. typeDeclaration.PropertyDeclarations
                        .Where(p => p.RequiredOrOptional == RequiredOrOptional.Optional &&
                               !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                        .OrderBy(p => p.JsonPropertyName)
                        .Select(p =>
                            new MethodParameter(
                                "in",
                                GetSource(generator, p.ReducedPropertyType.FullyQualifiedDotnetTypeName()),
                                generator.GetUniqueParameterNameInScope(p.JsonPropertyName, childScope: "Create"),
                                typeIsNullable: false,
                                defaultValue: "default")),
            ];

        static string GetSource(CodeGenerator generator, string fqdtn)
        {
            return fqdtn + "." + generator.SourceClassName(fqdtn);
        }
    }

    private static MethodParameter[] BuildMethodParametersWithContext(CodeGenerator generator, TypeDeclaration typeDeclaration)
    {
        if (generator.IsCancellationRequested)
        {
            return [];
        }

        return
        [
                new MethodParameter("in", "TContext", generator.GetUniqueParameterNameInScope("context", childScope: "Create<TContext>")),
                new MethodParameter("ref", "ComplexValueBuilder", generator.GetUniqueParameterNameInScope("builder", childScope: "Create<TContext>")),
                .. typeDeclaration.PropertyDeclarations
                        .Where(p => p.RequiredOrOptional != RequiredOrOptional.Optional &&
                               p.ReducedPropertyType.SingleConstantValue().ValueKind == JsonValueKind.Undefined &&
                               !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                        .OrderBy(p => p.JsonPropertyName)
                        .Select(p => new MethodParameter("in", $"{GetSource(generator, p.ReducedPropertyType.FullyQualifiedDotnetTypeName())}{((p.ReducedPropertyType.ImpliedCoreTypesOrAny() & (CoreTypes.Array | CoreTypes.Object)) != 0 ? "<TContext>" : "")}", generator.GetUniqueParameterNameInScope(p.JsonPropertyName, childScope: "Create<TContext>"))),
                .. typeDeclaration.PropertyDeclarations
                        .Where(p => p.RequiredOrOptional == RequiredOrOptional.Optional &&
                               !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                        .OrderBy(p => p.JsonPropertyName)
                        .Select(p => new MethodParameter("in", $"{GetSource(generator, p.ReducedPropertyType.FullyQualifiedDotnetTypeName())}{((p.ReducedPropertyType.ImpliedCoreTypesOrAny() & (CoreTypes.Array | CoreTypes.Object)) != 0 ? "<TContext>" : "")}", generator.GetUniqueParameterNameInScope(p.JsonPropertyName, childScope: "Create<TContext>"), defaultValue: "default")),
            ];

        static string GetSource(CodeGenerator generator, string fqdtn)
        {
            return fqdtn + "." + generator.SourceClassName(fqdtn);
        }
    }

    private static PropertyDeclaration[] BuildOrderedProperties(TypeDeclaration typeDeclaration)
    {
        return
        [
            .. typeDeclaration.PropertyDeclarations
                                        .Where(p => p.RequiredOrOptional != RequiredOrOptional.Optional && !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                                        .OrderBy(p => p.JsonPropertyName),
                .. typeDeclaration.PropertyDeclarations
                                        .Where(p => p.RequiredOrOptional == RequiredOrOptional.Optional && !p.ReducedPropertyType.IsBuiltInJsonNotAnyType())
                                        .OrderBy(p => p.JsonPropertyName),
            ];
    }

    private static CodeGenerator CollectBuilderSourcesAndAppendKinds(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        HashSet<string> numericArrayKinds = [];
        bool hasStringSimpleType = false;

        if (typeDeclaration.Format() is string format &&
            FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
            requiresSimpleType)
        {
            generator
                .ReserveName("StringSimpleType")
                .AppendLineIndent("StringSimpleType,");
            hasStringSimpleType = true;
        }

        foreach (TypeDeclaration t in typeDeclaration.CompositionSources())
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            CoreTypes core = t.ImpliedCoreTypesOrAny();

            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool isString = (core & CoreTypes.String) != 0;
            bool isNumber = (core & CoreTypes.Number) != 0;

            string? arrayKindName = null;
            string? objectKindName = null;

            string? arrayInstanceName = null;
            string? objectInstanceName = null;

            string? arrayBuilderName = null;
            string? objectBuilderName = null;

            string? numericArrayKindName = null;
            NumericTypeName? numericArrayTypeName = null;

            string? stringFormat = null;
            string? numericFormat = null;

            if (isString)
            {
                stringFormat = t.Format();

                if (!hasStringSimpleType && stringFormat is string f &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(f, out bool r) &&
                    r)
                {
                    generator
                        .ReserveName("StringSimpleType")
                       .AppendLineIndent("StringSimpleType,");
                    hasStringSimpleType = true;
                }
            }

            if (isNumber)
            {
                numericFormat = t.Format();
            }

            bool shouldAdd = true;

            if (isArray)
            {
                if (t.ExplicitArrayItemsType() is not null)
                {
                    arrayKindName = generator.GetUniqueMethodNameInScope(t.DotnetTypeName(), suffix: isObject ? "ArrayBuilder" : "Builder");
                    arrayInstanceName = generator.GetUniqueFieldNameInScope(arrayKindName, suffix: "Instance");
                    arrayBuilderName = isObject ? generator.ArrayBuilderClassName(t.FullyQualifiedDotnetTypeName()) : generator.BuilderClassName(t.FullyQualifiedDotnetTypeName());

                    generator
                        .AppendLineIndent(arrayKindName, ",");
                    if (t.IsNumericArray() && !t.IsTuple())
                    {
                        NumericTypeName numericTypeName = t.PreferredDotnetNumericTypeName() ?? throw new InvalidOperationException("Expected numeric type name");
                        numericArrayKindName = GetNumericArrayKind(generator, numericTypeName, reserve: true);
                        numericArrayTypeName = numericTypeName;
                        if (numericArrayKinds.Add(numericArrayKindName))
                        {
                            if (numericTypeName.IsNetOnly)
                            {
                                generator
                                    .AppendLine("#if NET");
                            }

                            generator
                                .AppendLineIndent(numericArrayKindName, ",");

                            if (numericTypeName.IsNetOnly)
                            {
                                generator
                                    .AppendLine("#endif");
                            }
                        }
                    }
                }
                else
                {
                    shouldAdd = false;
                }
            }

            if (isObject)
            {
                if (t.LocalEvaluatedPropertyType() is not null ||
                    t.HasPropertyDeclarations)
                {

                    objectKindName = generator.GetUniqueMethodNameInScope(t.DotnetTypeName(), suffix: isArray ? "ObjectBuilder" : "Builder");
                    objectInstanceName = generator.GetUniqueFieldNameInScope(objectKindName, suffix: "Instance");
                    objectBuilderName = isArray ? generator.ObjectBuilderClassName(t.FullyQualifiedDotnetTypeName()) : generator.BuilderClassName(t.FullyQualifiedDotnetTypeName());

                    generator
                        .AppendLineIndent(objectKindName, ",");
                }
                else
                {
                    shouldAdd = false;
                }
            }

            if (shouldAdd)
            {
                builders.Add(new(t, arrayKindName, objectKindName, arrayInstanceName, objectInstanceName, objectBuilderName, arrayBuilderName, numericArrayKindName, numericArrayTypeName, stringFormat, numericFormat));
            }
        }

        // Now add the numeric array kind for the base type
        if (typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
        {
            NumericTypeName numericTypeName = typeDeclaration.PreferredDotnetNumericTypeName() ?? throw new InvalidOperationException("Expected numeric type name");
            string numericArrayKindName = GetNumericArrayKind(generator, numericTypeName, reserve: true);
            if (numericArrayKinds.Add(numericArrayKindName))
            {
                if (numericTypeName.IsNetOnly)
                {
                    generator
                        .AppendLine("#if NET");
                }

                generator
                    .AppendLineIndent(numericArrayKindName, ",");

                if (numericTypeName.IsNetOnly)
                {
                    generator
                        .AppendLine("#endif");
                }
            }
        }

        CoreTypes rootCore = typeDeclaration.ImpliedCoreTypesOrAny();

        if ((rootCore & CoreTypes.String) != 0)
        {
            generator
                .ReserveName("RawUtf8StringRequiresUnescaping")
                .ReserveName("RawUtf8StringNotRequiresUnescaping")
                .ReserveName("Utf8String")
                .ReserveName("Utf16String")
                .AppendLineIndent("RawUtf8StringRequiresUnescaping,")
                .AppendLineIndent("RawUtf8StringNotRequiresUnescaping,")
                .AppendLineIndent("Utf8String,")
                .AppendLineIndent("Utf16String,");
        }

        if ((rootCore & (CoreTypes.Number | CoreTypes.Integer)) != 0)
        {
            generator
                .ReserveName("NumericSimpleType")
                .ReserveName("FormattedNumber")
                .AppendLineIndent("NumericSimpleType,")
                .AppendLineIndent("FormattedNumber,");
        }

        if ((rootCore & CoreTypes.Boolean) != 0)
        {
            generator
                .ReserveName("True")
                .ReserveName("False")
                .AppendLineIndent("True,")
                .AppendLineIndent("False,");
        }

        if ((rootCore & CoreTypes.Null) != 0)
        {
            generator
                .ReserveName("Null")
                .AppendLineIndent("Null,");
        }

        bool isRootObject = (rootCore & CoreTypes.Object) != 0;
        bool isRootArray = (rootCore & CoreTypes.Array) != 0;
        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;
        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        if (isRootObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
        {
            string builderKindName = isRootArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
            generator
                .ReserveName(builderKindName)
                .AppendLineIndent(builderKindName, ",");
        }

        if (isRootArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
        {
            string builderKindName = isRootObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();
            generator
                .ReserveName(builderKindName)
                .AppendLineIndent(builderKindName, ",");
        }

        return generator;
    }

    private static CodeGenerator AppendKindsForBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        foreach (ComposedBuilder builder in builders)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            if (builder.ArrayKindName is not null)
            {
                generator
                    .AppendLineIndent(builder.ArrayKindName, ",");
            }

            if (builder.ObjectKindName is not null)
            {
                generator
                    .AppendLineIndent(builder.ObjectKindName, ",");
            }
        }


        CoreTypes rootCore = typeDeclaration.ImpliedCoreTypesOrAny();

        bool isRootObject = (rootCore & CoreTypes.Object) != 0;
        bool isRootArray = (rootCore & CoreTypes.Array) != 0;
        bool hasFallbackObjectType =
            typeDeclaration.LocalEvaluatedPropertyType() is not null ||
            typeDeclaration.HasPropertyDeclarations;
        bool hasFallbackArrayType =
            typeDeclaration.ExplicitArrayItemsType() is not null;

        if (isRootObject && (hasFallbackObjectType || !builders.Any(b => b.IsObject)))
        {
            string builderKindName = isRootArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
            generator
                .ReserveName(builderKindName)
                .AppendLineIndent(builderKindName, ",");
        }

        if (isRootArray && (hasFallbackArrayType || !builders.Any(b => b.IsArray)))
        {
            string builderKindName = isRootObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();
            generator
                .ReserveName(builderKindName)
                .AppendLineIndent(builderKindName, ",");
        }

        return generator;
    }

    private static CodeGenerator CollectBuilderSourcesAndAppendSourceKindEnum(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        return generator
            .AppendSeparatorLine()
            .BeginEnum(GeneratedTypeAccessibility.Private, "Kind")
                .ReserveName("Unknown")
                .ReserveName("JsonElement")
                .AppendLineIndent("Unknown,")
                .AppendLineIndent("JsonElement,")
                .CollectBuilderSourcesAndAppendKinds(typeDeclaration, builders)
            .EndClassStructOrEnumDeclaration();
    }

    private static CodeGenerator AppendKindEnumForBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
    {
        return generator
            .AppendSeparatorLine()
            .BeginEnum(GeneratedTypeAccessibility.Private, "Kind")
                .ReserveName("Unknown")
                .AppendLineIndent("Unknown,")
                .ReserveName("Source")
                .AppendLineIndent("Source,")
                .AppendKindsForBuilders(typeDeclaration, builders)
            .EndClassStructOrEnumDeclaration();
    }

    private static bool ComposedSchemaHasNonFixedSizeNumericArray(List<ComposedBuilder> builders, TypeDeclaration rootTypeDeclaration)
    {
        NumericTypeName? arrayType = rootTypeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName();
        if (arrayType is NumericTypeName at)
        {
            string name = at.Name;
            foreach (ComposedBuilder builder in builders)
            {
                if (rootTypeDeclaration == builder.TypeDeclaration)
                {
                    // Don't bother considering the current root type declaration
                    continue;
                }

                if (builder.TypeDeclaration.IsNumericArray() &&
                    !builder.TypeDeclaration.IsTuple() &&
                    builder.TypeDeclaration.ArrayItemsType()?.ReducedType.PreferredDotnetNumericTypeName()?.Name == name)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static string GetNumericArrayKind(CodeGenerator generator, NumericTypeName at, bool reserve = false)
    {
        Span<char> buffer = stackalloc char[at.Name.Length + 5];
        at.Name.AsSpan().CopyTo(buffer);
        int written = Formatting.ToPascalCase(buffer.Slice(0, at.Name.Length));
        "Array".AsSpan().CopyTo(buffer.Slice(written));
        return reserve
            ? generator.GetUniquePropertyNameInScope(buffer.Slice(0, written + 5).ToString())
            : generator.GetPropertyNameInScope(buffer.Slice(0, written + 5).ToString());
    }

    internal sealed class ComposedBuilder
    {
        public ComposedBuilder(
            TypeDeclaration typeDeclaration,
            string? arrayKindName,
            string? objectKindName,
            string? arrayInstanceName,
            string? objectInstanceName,
            string? objectBuilderName,
            string? arrayBuilderName,
            string? numericArrayKindName,
            NumericTypeName? numericArrayTypeName,
            string? stringFormat,
            string? numericFormat)
        {
            TypeDeclaration = typeDeclaration;
            ArrayKindName = arrayKindName;
            ObjectKindName = objectKindName;
            ArrayInstanceName = arrayInstanceName;
            ObjectInstanceName = objectInstanceName;
            ObjectBuilderName = objectBuilderName;
            ArrayBuilderName = arrayBuilderName;
            NumericArrayKindName = numericArrayKindName;
            NumericArrayTypeName = numericArrayTypeName;
            StringFormat = stringFormat;
            NumericFormat = numericFormat;
        }

        public string? ArrayBuilderName { get; }
        public string? ArrayInstanceName { get; }
        public string? ArrayKindName { get; }
        public bool IsArray => ArrayKindName is not null;
        public bool IsObject => ObjectKindName is not null;
        public string? NumericArrayKindName { get; }
        public NumericTypeName? NumericArrayTypeName { get; }
        public string? NumericFormat { get; }
        public string? ObjectBuilderName { get; }
        public string? ObjectInstanceName { get; }
        public string? ObjectKindName { get; }
        public string? StringFormat { get; }
        public TypeDeclaration TypeDeclaration { get; }
    }
}
