// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static partial class CodeGeneratorExtensions
    {
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

            return generator
                .AppendSourceRefStruct(typeDeclaration)
                .AppendBuilderRefStruct(typeDeclaration);
        }

        private static CodeGenerator AppendBuilderRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            if ((core & (CoreTypes.Array | CoreTypes.Object)) == 0 ||
                typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf())
            {
                // Nothing to do if we are not an array or an object.
                // Or we are just a reduction to anyOf/oneOf
                return generator;
            }

            generator
                .AppendSeparatorLine()
                .BeginRefStruct(GeneratedTypeAccessibility.Public, "Builder", isReadOnly: false)
                    .ReserveName("Build")
                    .ReserveName("_builder")
                    .AppendLineIndent("public delegate void Build(ref Builder builder);")
                    .AppendSeparatorLine()
                    .AppendLineIndent("private ComplexValueBuilder _builder;");

            // TODO: I'M WORKING ON THE BUILDER GENERATION

            if ((core & CoreTypes.Array) != 0)
            {
                if (!typeDeclaration.IsTuple())
                {
                }

            }

            if ((core & CoreTypes.Object) != 0)
            {
                // THERE WILL BE OBJECT CREATION AND PROPERTY ADD METHODS HERE
            }

            return generator
                .EndClassStructOrEnumDeclaration();

        }

        private static CodeGenerator AppendSourceRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            List<ComposedBuilder> builders = [];

            return generator
                .AppendSeparatorLine()
                .BeginRefStruct(GeneratedTypeAccessibility.Public, "Source", isReadOnly: false)
                    .CollectBuilderSourcesAndAppendSourceKindEnum(typeDeclaration, builders)
                    .AppendSourceFields(typeDeclaration, builders)
                    .AppendSourceConstructors(typeDeclaration, builders)
                    .AppendSourceConversionOperators(typeDeclaration, builders)
                    .AppendSourceFactoryMethods(typeDeclaration, builders)
                    .AppendAddAsProperty(typeDeclaration, builders)
                    .AppendAddAsItem(typeDeclaration, builders)
                .EndClassStructOrEnumDeclaration();
        }

        private static CodeGenerator AppendSourceFactoryMethods(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            if ((core & CoreTypes.String) != 0)
            {
                generator
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static Source RawString(ReadOnlySpan<byte> value, bool requiresUnescaping) => new(value, requiresUnescaping);");
            }

            if ((core & CoreTypes.Number) != 0)
            {
                generator
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static Source FormattedNumber(ReadOnlySpan<byte> value) => new(value, Kind.FormattedNumber);");
            }

            if ((core & CoreTypes.Null) != 0)
            {
                generator
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static Source Null() => new(Kind.Null);");
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

        private static CodeGenerator AppendSourceConversionOperators(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            HashSet<string> seenConversionOperators = [];

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("public static implicit operator Source(", typeDeclaration.DotnetTypeName(), " instance) => new(JsonElement.From(instance));");

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            if ((core & CoreTypes.String) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(ReadOnlySpan<byte> value) => new (value);")
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(ReadOnlySpan<char> value) => new (value);")
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                    .AppendLineIndent("public static implicit operator Source(string value) => new (value.AsSpan());");

                if (typeDeclaration.Format() is string format)
                {
                    FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConversionOperators(generator, typeDeclaration, format, seenConversionOperators);
                }
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                if (typeDeclaration.Format() is not string format ||
                    !FormatHandlerRegistry.Instance.StringFormatHandlers.AppendFormatSourceConversionOperators(generator, typeDeclaration, format, seenConversionOperators))
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
                                .AppendLineIndent("public static implicit operator Source(double value) => new (value);");
                        }
                    }
                    else
                    {
                        if (seenConversionOperators.Add("long"))
                        {
                            generator
                                .AppendSeparatorLine()
                                .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                                .AppendLineIndent("public static implicit operator Source(long value) => new (value);");
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
                        .AppendLineIndent("public static implicit operator Source(bool value) => new (value);");
                }
            }

            foreach (ComposedBuilder composedBuilder in builders)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
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

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent(
                            "public static implicit operator Source(",
                            composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                            " instance) => new(JsonElement.From(instance));");

                if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent(
                            "public static implicit operator Source(",
                            composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                            composedBuilder.IsArray ? ".ObjectBuilder" : ".Builder",
                            ".Build value) => new(value);");
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(",
                            composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                            composedBuilder.IsObject ? ".ArrayBuilder" : ".Builder",
                            ".Build value) => new(value);");
                }
            }

            return generator;
        }

        private static CodeGenerator AppendSourceConstructors(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            HashSet<string> seenConstructorParameters = [];

            generator
                .AppendSeparatorLine()
                .AppendLineIndent("private Source(JsonElement jsonElement)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("_jsonElement = jsonElement;")
                    .AppendLineIndent("_kind = Kind.JsonElement;")
                .PopIndent()
                .AppendLineIndent("}");

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            if ((core & CoreTypes.String) != 0)
            {
                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(ReadOnlySpan<byte> value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf8String = value;")
                        .AppendLineIndent("_kind = Kind.Utf8String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(ReadOnlySpan<char> value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf16String = value;")
                        .AppendLineIndent("_kind = Kind.Utf16String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(ReadOnlySpan<byte> value, bool requiresUnescaping)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf8String = value;")
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
                    .AppendLineIndent("private Source(ReadOnlySpan<byte> value, Kind kind)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("Debug.Assert(kind is Kind.FormattedNumber);")
                        .AppendLineIndent("_utf8String = value;")
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
                                .AppendLineIndent("private Source(double value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                        }
                    }
                    else
                    {
                        if (seenConstructorParameters.Add("long"))
                        {
                            generator
                                .AppendSeparatorLine()
                                .AppendLineIndent("private Source(long value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (v, buffer, out written) => Utf8Formatter.TryFormat(v, buffer, out written)); _kind = Kind.NumericSimpleType; }");
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
                        .AppendLineIndent("private Source(bool value) { _kind = value ? Kind.True : Kind.False; }");
                }
            }

            if ((core & CoreTypes.Null) != 0)
            {
                if (seenConstructorParameters.Add("null"))
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("private Source(Kind kind) { Debug.Assert(kind == Kind.Null); _kind = Kind.Null; }");
                }
            }

            foreach (ComposedBuilder composedBuilder in builders)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

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
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                            composedBuilder.IsArray ? ".ObjectBuilder" : ".Builder",
                            ".Build value) => { ",
                            composedBuilder.ObjectInstanceName,
                            " = value; _kind = Kind.",
                            composedBuilder.ObjectKindName,
                            "; };");
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                            composedBuilder.IsObject ? ".ArrayBuilder" : ".Builder",
                            ".Build value) => { ",
                            composedBuilder.ArrayInstanceName,
                            " = value; _kind = Kind.",
                            composedBuilder.ArrayKindName,
                            "; };");
                }
            }

            return generator;
        }

        private static CodeGenerator AppendSourceFields(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            generator
                .AppendSeparatorLine()
                .ReserveNameIfNotReserved("_kind")
                .ReserveNameIfNotReserved("_jsonElement")
                .AppendLineIndent("private readonly Kind _kind;")
                .AppendLineIndent("private readonly JsonElement _jsonElement;");

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            bool hasUtf8Backing = false;
            bool hasSimpleTypeBacking = false;

            if ((core & CoreTypes.String) != 0)
            {
                generator
                .ReserveNameIfNotReserved("_utf8String")
                .ReserveNameIfNotReserved("_utf16String")
                    .AppendLineIndent("private readonly Utf8String _utf8String;")
                    .AppendLineIndent("private readonly Utf16String _utf16String;");
                hasUtf8Backing = true;
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                if (!hasUtf8Backing)
                {
                    generator
                        .ReserveNameIfNotReserved("_utf8String")
                        .AppendLineIndent("private readonly Utf8String _utf8String;");
                }

                if (!hasSimpleTypeBacking)
                {
                    generator
                        .ReserveNameIfNotReserved("_simpleTypeBacking")
                        .AppendLineIndent("private readonly SimpleTypesBacking _simpleTypeBacking;");
                }
            }

            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                generator
                    .ReserveNameIfNotReserved("_objectBuilder")
                    .AppendLineIndent("private readonly ", isArray ? "ObjectBuilder" : "Builder", ".Build? _objectBuilder;");
            }

            HashSet<string> seenArrayValues = [];

            if (isArray && !canReduce)
            {
                generator
                    .ReserveNameIfNotReserved("_arrayBuilder")
                    .AppendLineIndent("private readonly ", isObject ? "ArrayBuilder" : "Builder", ".Build? _arrayBuilder;")
                    .AppendNumericArrayTypeFields(typeDeclaration, seenArrayValues);
            }

            foreach (ComposedBuilder builder in builders)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (builder.ObjectInstanceName is string oin)
                {
                    generator
                        .ReserveNameIfNotReserved($"_{oin}")
                        .AppendLineIndent(
                        "private readonly ",
                        builder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                        builder.IsArray ? ".ObjectBuilder" : ".Builder",
                        ".Build? _",
                        oin,
                        ";");
                }

                if (builder.ArrayInstanceName is string ain)
                {
                    generator
                        .ReserveNameIfNotReserved($"_{ain}")
                        .AppendLineIndent(
                        "private readonly ",
                        builder.TypeDeclaration.FullyQualifiedDotnetTypeName(),
                        builder.IsObject ? ".ArrayBuilder" : ".Builder",
                        ".Build? _",
                        ain,
                        ";")
                       .AppendNumericArrayTypeFields(builder.TypeDeclaration, seenArrayValues);

                }
            }

            return generator;
        }

        private static void AppendNumericArrayTypeFields(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
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
                            .AppendLineIndent("public static Source FromArray(ReadOnlySpan<", at.Name, "> value) => new(value);")
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
                            .AppendLineIndent("public static Source FromArray(ReadOnlySpan<", at.Name, "> value) => new(value);");
                    }
                }
            }
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
                            .AppendLineIndent("public static Source FromArray(ReadOnlySpan<", at.Name, "> value)")
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
                            .AppendLineIndent("public static Source FromArray(ReadOnlySpan<", at.Name, "> value)")
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
                            .PopIndent();
                    }
                }
            }
        }

        private static CodeGenerator CollectBuilderSourcesAndAppendSourceKindEnum(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            return generator
                .AppendSeparatorLine()
                .BeginEnum(GeneratedTypeAccessibility.Private, "Kind")
                    .AppendLineIndent("Unknown,")
                    .AppendLineIndent("JsonElement,")
                    .AppendKindsForCoreTypes(typeDeclaration)
                    .CollectBuilderSourcesAndAppendKinds(typeDeclaration, builders)
                .EndClassStructOrEnumDeclaration();
        }

        private static CodeGenerator AppendAddAsProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            generator
                .ReserveNameIfNotReserved("AddAsProperty")
                .AppendLineIndent("internal void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName = true, bool nameRequiresUnescaping = false)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("switch(_kind)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("case Kind.JsonElement:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _jsonElement, escapeName, nameRequiresUnescaping);")
                            .AppendLineIndent("break;")
                        .PopIndent();


            HashSet<string> seenKinds = [];

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

            if ((core & CoreTypes.Null) != 0)
            {
                if (seenKinds.Add("Null"))
                {
                    generator
                        .AppendLineIndent("case Kind.Null:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyNull(utf8Name, escapeName, nameRequiresUnescaping);")
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
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, true, escapeName, nameRequiresUnescaping);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("False"))
                {
                    generator
                        .AppendLineIndent("case Kind.False:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, false, escapeName, nameRequiresUnescaping);")
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
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: true);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("RawUtf8StringNotRequiresUnescaping"))
                {
                    generator
                        .AppendLineIndent("case Kind.RawUtf8StringNotRequiresUnescaping:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: false, nameRequiresUnescaping, valueRequiresUnescaping: false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf8String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf8String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _utf8Backing, escapeName, escapeValue: true, nameRequiresUnescaping, valueRequiresUnescaping: false);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("Utf16String"))
                {
                    generator
                        .AppendLineIndent("case Kind.Utf16String:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _utf16Backing, escapeName, nameRequiresUnescaping);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            if ((core & CoreTypes.Number) != 0)
            {
                if (seenKinds.Add("NumericSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.NumericSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyFormattedNumber(utf8Name, _simpleTypeBacking.Span(), escapeName, nameRequiresUnescaping);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (seenKinds.Add("FormattedNumber"))
                {
                    generator.AppendLineIndent("case Kind.FormattedNumber:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddPropertyFormattedNumber(utf8Name, _utf8Backing, escapeName, nameRequiresUnescaping);")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }
            }

            bool canReduceToOneOrAny = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                generator
                    .AppendLineIndent("case Kind.", isArray ? "ObjectBuilder:" : "Builder:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _objectBuilder!, static (b, ref o) => ", "Builder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }

            if (isArray && !canReduce)
            {
                generator
                    .AppendLineIndent("case Kind.", isObject ? "ArrayBuilder:" : "Builder:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(utf8Name, _arrayBuilder!, static (b, ref o) => ", "Builder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }


            foreach (ComposedBuilder composedBuilder in builders)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddProperty(utf8Name, ", composedBuilder.ObjectInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(),".Builder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ArrayKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ArrayKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddProperty(utf8Name, ", composedBuilder.ArrayInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".Builder.BuildValue(b, ref o), escapeName, nameRequiresUnescaping);")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }
            }

            return generator
                        .AppendLineIndent("default:")
                        .PushIndent()
                            .AppendLineIndent("Debug.Fail(\"Unexpected Kind\");")
                            .AppendLineIndent("break;")
                    .PopIndent()
                    .AppendLineIndent("}")
                .PopIndent()
                .AppendLineIndent("}");
        }

        private static CodeGenerator AppendAddAsItem(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            generator
                .ReserveNameIfNotReserved("AddAsAsItem")
                .AppendLineIndent("internal void AddAsAsItem(ref ComplexValueBuilder valueBuilder)")
                .AppendLineIndent("{")
                .PushIndent()
                    .AppendLineIndent("switch(_kind)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("case Kind.JsonElement:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_jsonElement);")
                            .AppendLineIndent("break;")
                        .PopIndent();


            HashSet<string> seenKinds = [];

            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();

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
            }

            if ((core & CoreTypes.Number) != 0)
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

            bool canReduceToOneOrAny = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                generator
                    .AppendLineIndent("case Kind.", isArray ? "ObjectBuilder:" : "Builder:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddItem(_objectBuilder!, static (b, ref o) => ", "Builder.BuildValue(b, ref o));")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }

            if (isArray && !canReduce)
            {
                generator
                    .AppendLineIndent("case Kind.", isObject ? "ArrayBuilder:" : "Builder:")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddItem(_arrayBuilder!, static (b, ref o) => ", "Builder.BuildValue(b, ref o));")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }


            foreach (ComposedBuilder composedBuilder in builders)
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddItem(", composedBuilder.ObjectInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".Builder.BuildValue(b, ref o));")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ArrayKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ArrayKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddItem(", composedBuilder.ArrayInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".Builder.BuildValue(b, ref o));")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }
            }

            return generator
                        .AppendLineIndent("default:")
                        .PushIndent()
                            .AppendLineIndent("Debug.Fail(\"Unexpected Kind\");")
                            .AppendLineIndent("break;")
                    .PopIndent()
                    .AppendLineIndent("}")
                .PopIndent()
                .AppendLineIndent("}");
        }


        private static CodeGenerator AppendKindsForCoreTypes(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();
            if ((core & CoreTypes.String) != 0)
            {
                generator
                    .AppendLineIndent("RawUtf8StringRequiresUnescaping,")
                    .AppendLineIndent("RawUtf8StringNotRequiresUnescaping,")
                    .AppendLine("Utf8String,")
                    .AppendLine("Utf16String,");
            }

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                generator
                    .AppendLineIndent("NumericSimpleType,")
                    .AppendLineIndent("FormattedNumber,");
            }

            if ((core & CoreTypes.Boolean) != 0)
            {
                generator
                    .AppendLineIndent("True,")
                    .AppendLineIndent("False,");
            }

            if ((core & CoreTypes.Null) != 0)
            {
                generator
                    .AppendLineIndent("Null,");
            }

            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                generator
                    .AppendLineIndent(isArray ? "ObjectBuilder," : "Builder,");
            }

            if (isArray && !canReduce)
            {
                generator
                    .AppendLineIndent(isObject ? "ArrayBuilder," : "Builder,");
            }

            return generator;
        }

        internal sealed class ComposedBuilder
        {
            public ComposedBuilder(
                TypeDeclaration typeDeclaration,
                string? arrayKindName,
                string? objectKindName,
                string? arrayInstanceName,
                string? objectInstanceName)
            {
                TypeDeclaration = typeDeclaration;
                ArrayKindName = arrayKindName;
                ObjectKindName = objectKindName;
                ArrayInstanceName = arrayInstanceName;
                ObjectInstanceName = objectInstanceName;
            }

            public TypeDeclaration TypeDeclaration { get; }

            public string? ArrayKindName { get; }
            public string? ObjectKindName { get; }
            public string? ArrayInstanceName { get; }
            public string? ObjectInstanceName { get; }

            public bool IsObject => ObjectKindName is not null;
            public bool IsArray => ArrayKindName is not null;
        }

        private static CodeGenerator CollectBuilderSourcesAndAppendKinds(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
            foreach (TypeDeclaration t in typeDeclaration.BuilderSources())
            {
                if (generator.IsCancellationRequested)
                {
                    return generator;
                }

                CoreTypes core = t.ImpliedCoreTypesOrAny();

                bool isObject = (core & CoreTypes.Object) != 0;
                bool isArray = (core & CoreTypes.Array) != 0;

                string? arrayKindName = null;
                string? objectKindName = null;

                string? arrayInstanceName = null;
                string? objectInstanceName = null;

                if (isArray)
                {
                    arrayKindName = generator.GetUniqueMethodNameInScope(t.DotnetTypeName(), suffix: isArray ? "ArrayBuilder" : "Builder");
                    arrayInstanceName = generator.GetUniqueFieldNameInScope(arrayKindName, suffix: "Instance");
                    generator
                        .AppendLineIndent(arrayKindName, ",");
                }

                if (isObject)
                {
                    objectKindName = generator.GetUniqueMethodNameInScope(t.DotnetTypeName(), suffix: isArray ? "ObjectBuilder" : "Builder");
                    objectInstanceName = generator.GetUniqueFieldNameInScope(objectKindName, suffix: "Instance");
                    generator
                        .AppendLineIndent(objectKindName, ",");
                }

                // Always add the builder that we have found
                builders.Add(new(t, arrayKindName, objectKindName, arrayInstanceName, objectInstanceName));
            }

            return generator;
        }
    }
}
