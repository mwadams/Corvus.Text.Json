// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        public static CodeGenerator AppendSourceAndBuilder(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            return generator
                .AppendSourceRefStruct(typeDeclaration)
                .AppendBuilderRefStruct(typeDeclaration, forArray: true)
                .AppendBuilderRefStruct(typeDeclaration, forArray: false);
        }

        private static CodeGenerator AppendBuilderRefStruct(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool forArray)
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

            if (typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf())
            {
                // Nothing to do if we are not an array or an object.
                // Or we are just a reduction to anyOf/oneOf
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
                    .AppendObjectBuilders(typeDeclaration, isArray);
            }

            generator
                .ReserveName("BuildValue")
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



            return generator
                .EndClassStructOrEnumDeclaration();

        }

        private static CodeGenerator AppendObjectBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isAlsoArray)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            return generator
                .AppendObjectCreateMethods(typeDeclaration, isAlsoArray)
                .AppendAddPropertyMethod(typeDeclaration, isAlsoArray);
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

        private static CodeGenerator AppendObjectCreateMethods(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isAlsoArray)
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
                .PopIndent()
                .AppendLineIndent("}");

            MethodParameter[] nonStaticMethodParameters = [.. staticMethodParameters.Skip(1)];

            return generator
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
                .PopIndent()
                .AppendLineIndent("}");
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


        private static CodeGenerator AppendCreateAddProperties(this CodeGenerator generator, MethodParameter[] parameters, PropertyDeclaration[] properties)
        {
            if (generator.IsCancellationRequested)
            {
                return generator;
            }

            // The first parameter is the builder, so we grab the builder name
            // then start the parameter index at 1 
            string builderName = parameters[0].GetName(generator);
            int parameterIndex = 1;

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
                                   p.ReducedPropertyType.SingleConstantValue().ValueKind == JsonValueKind.Undefined)
                            .OrderBy(p => p.JsonPropertyName)
                            .Select(p => new MethodParameter("in", GetSource(generator, p.ReducedPropertyType.FullyQualifiedDotnetTypeName()), generator.GetUniqueParameterNameInScope(p.JsonPropertyName, childScope: "Create"))),
                    .. typeDeclaration.PropertyDeclarations
                            .Where(p => p.RequiredOrOptional == RequiredOrOptional.Optional)
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

        private static PropertyDeclaration[] BuildOrderedProperties(TypeDeclaration typeDeclaration)
        {
            return
            [
                .. typeDeclaration.PropertyDeclarations
                                            .Where(p => p.RequiredOrOptional != RequiredOrOptional.Optional)
                                            .OrderBy(p => p.JsonPropertyName),
                    .. typeDeclaration.PropertyDeclarations
                                            .Where(p => p.RequiredOrOptional == RequiredOrOptional.Optional)
                                            .OrderBy(p => p.JsonPropertyName),
                ];
        }


        private static CodeGenerator AppendArrayBuilders(this CodeGenerator generator, TypeDeclaration typeDeclaration, bool isObject)
        {
            bool allowsNonPrefixItems = !typeDeclaration.IsTuple();
            bool hasTuple = false;

            generator
                .AppendFixedSizeNumericArray(typeDeclaration, isObject);

            if (typeDeclaration.ImplicitTupleType() is TupleTypeDeclaration tupleType)
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

            if (allowsNonPrefixItems)
            {
                string arrayItemsType =
                   typeDeclaration.ArrayItemsType()?.ReducedType.FullyQualifiedDotnetTypeName()
                   ?? WellKnownTypeDeclarations.JsonAny.FullyQualifiedDotnetTypeName();

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
                        .AppendLineIndent("/// <returns>The number of items consumed.</returns>")
                        .AppendLineIndent("/// <exception cref=\"ArgumentException\">The tensor did not contain the correct number of values for the array rank and dimension.</exception>")
                        .AppendLineIndent("public int CreateTensor(ReadOnlySpan<", numericTypeName.Name, "> tensor)")
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
                            .AppendLineIndent("while (index < tensor.Length)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent(arrayItemsTypeName, ".", builderClassName, " inner = new(_builder);")
                                .AppendLineIndent("index += inner.CreateTensor(tensor.Slice(index, ", arrayItemsTypeName, ".ValueBufferSize));")
                                .AppendLineIndent("_builder = inner._builder;")
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
                        .AppendLineIndent("/// <returns>The number of items consumed.</returns>")
                        .AppendLineIndent("/// <exception cref=\"ArgumentException\">The tensor did not contain the correct number of values for the array rank and dimension.</exception>")
                        .AppendLineIndent("public int CreateTensor(ReadOnlySpan<", numericTypeName.Name, "> tensor)")
                        .AppendLineIndent("{")
                        .PushIndent()
                            .AppendLineIndent("if (tensor.Length != ValueBufferSize)")
                            .AppendLineIndent("{")
                            .PushIndent()
                                .AppendLineIndent("CodeGenThrowHelper.ThrowArgumentException_ArrayBufferLength(nameof(tensor), ValueBufferSize);")
                            .PopIndent()
                            .AppendLineIndent("}")
                            .AppendSeparatorLine()
                            .AppendLineIndent("_builder.AddItemArrayValue(tensor);")
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
        private static CodeGenerator AppendCreateTuple(this CodeGenerator generator, TypeDeclaration typeDeclaration, TupleTypeDeclaration tupleType, bool allowsNonPrefixItems)
        {
            generator
                .AppendSeparatorLine()
                .AppendIndent("public void CreateTuple(in ");

            int index = 0;
            foreach (var item in tupleType.ItemsTypes)
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
                .AppendLine()
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
                    .AppendLineIndent("_addedPrefixItems = true");
            }

            generator
                .PopIndent()
                .AppendLineIndent("}");

            return generator;
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

            if ((core & CoreTypes.Number) != 0)
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

            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            bool hasNumericBuilder = builders.Any(b => (b.TypeDeclaration.ImpliedCoreTypesOrAny() & (CoreTypes.Number | CoreTypes.Integer)) != 0);

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0 && !canReduce && !hasNumericBuilder)
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
                    string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent(
                            "public static implicit operator Source(",
                            fqdtn,
                            ".",
                            composedBuilder.IsArray ? generator.ObjectBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                            ".Build value) => new(value);");
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent("[MethodImpl(MethodImplOptions.AggressiveInlining)]")
                        .AppendLineIndent("public static implicit operator Source(",
                            fqdtn,
                            ".",
                            composedBuilder.IsObject ? generator.ArrayBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
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
                        .AppendLineIndent("_utf8Backing = value;")
                        .AppendLineIndent("_kind = Kind.Utf8String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(ReadOnlySpan<char> value)")
                    .AppendLineIndent("{")
                    .PushIndent()
                        .AppendLineIndent("_utf16Backing = value;")
                        .AppendLineIndent("_kind = Kind.Utf16String;")
                    .PopIndent()
                    .AppendLineIndent("}");

                generator
                    .AppendSeparatorLine()
                    .AppendLineIndent("private Source(ReadOnlySpan<byte> value, bool requiresUnescaping)")
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
                    .AppendLineIndent("private Source(ReadOnlySpan<byte> value, Kind kind)")
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
                                .AppendLineIndent("private Source(double value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (isAlsoArray, buffer, out written) => Utf8Formatter.TryFormat(isAlsoArray, buffer, out written)); _kind = Kind.NumericSimpleType; }");
                        }
                    }
                    else
                    {
                        if (seenConstructorParameters.Add("long"))
                        {
                            generator
                                .AppendSeparatorLine()
                                .AppendLineIndent("private Source(long value) { SimpleTypesBacking.Initialize(ref _simpleTypeBacking, value, static (isAlsoArray, buffer, out written) => Utf8Formatter.TryFormat(isAlsoArray, buffer, out written)); _kind = Kind.NumericSimpleType; }");
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

            HashSet<string> seenNumericArrayTypes = [];

            generator
                .AppendNumericArrayConstructors(typeDeclaration, seenNumericArrayTypes);

            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();

            // This is the "has builder" case
            if ((core & (CoreTypes.Array | CoreTypes.Object)) != 0 &&
                !canReduce)
            {
                bool isArray = (core & CoreTypes.Array) != 0;
                bool isObject = (core & CoreTypes.Object) != 0;

                if (isObject)
                {
                    string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            fqdtn,
                            ".",
                            isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(),
                            ".Build value) { _objectBuilder = value; _kind = Kind.",
                            isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(),
                            "; }");
                }

                if (isArray)
                {
                    string fqdtn = typeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            fqdtn,
                            ".",
                            isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(),
                            ".Build value) { _arrayBuilder = value; _kind = Kind.",
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
                    string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            fqdtn,
                            ".",
                            composedBuilder.IsArray ? generator.ObjectBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                            ".Build value) { _",
                            composedBuilder.ObjectInstanceName,
                            " = value; _kind = Kind.",
                            composedBuilder.ObjectKindName,
                            "; }");
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null)
                {
                    string fqdtn = composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .AppendSeparatorLine()
                        .AppendLineIndent(
                            "public Source(",
                            fqdtn,
                            ".",
                            composedBuilder.IsObject ? generator.ArrayBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                            ".Build value) { _",
                            composedBuilder.ArrayInstanceName,
                            " = value; _kind = Kind.",
                            composedBuilder.ArrayKindName,
                            "; }");
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
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();

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
                    hasSimpleTypeBacking = true;                }
            }

            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            if (isObject && !canReduce)
            {
                generator
                    .ReserveNameIfNotReserved("_objectBuilder")
                    .AppendLineIndent("private readonly ", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ".Build? _objectBuilder;");
            }

            HashSet<string> seenArrayValues = [];

            if (isArray && !canReduce)
            {
                generator
                    .ReserveNameIfNotReserved("_arrayBuilder")
                    .AppendLineIndent("private readonly ", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ".Build? _arrayBuilder;")
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
                    string fqdtn = builder.TypeDeclaration.FullyQualifiedDotnetTypeName();
                    generator
                        .ReserveNameIfNotReserved($"_{oin}")
                        .AppendLineIndent(
                        "private readonly ",
                        fqdtn,
                        ".",
                        builder.IsArray ? generator.ObjectBuilderClassName(fqdtn) : generator.BuilderClassName(fqdtn),
                        ".Build? _",
                        oin,
                        ";");
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
                        ".Build? _",
                        ain,
                        ";")
                       .AppendNumericArrayTypeFields(builder.TypeDeclaration, seenArrayValues);

                }

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

        private static CodeGenerator AppendNumericArrayConstructors(this CodeGenerator generator, TypeDeclaration typeDeclaration, HashSet<string> seenArrayValues)
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
                            .AppendLineIndent("private ", generator.SourceClassName(),"(ReadOnlySpan<", at.Name, "> value)")
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

            return generator;
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
                            .AppendLineIndent("}");
                    }
                }
            }
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
                    .AppendKindsForCoreTypes(typeDeclaration)
                    .CollectBuilderSourcesAndAppendKinds(typeDeclaration, builders)
                .EndClassStructOrEnumDeclaration();
        }

        private static CodeGenerator AppendAddAsProperty(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders, string nameType, string nameName, bool includeEscaping)
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
                        .PopIndent()
                        .AppendLineIndent("case Kind.JsonElement:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _jsonElement", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
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

            if ((core & CoreTypes.Number) != 0)
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

            bool canReduceToOneOrAny = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                string builderName = isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
                generator
                    .AppendLineIndent("case Kind.", builderName, ":")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _objectBuilder!, static (b, ref o) => ", builderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }

            HashSet<string> numericArrayKinds = [];

            if (isArray && !canReduce)
            {
                string builderName = isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();

                generator
                    .AppendLineIndent("case Kind.", builderName, ":")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _arrayBuilder!, static (b, ref o) => ", builderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                        .AppendLineIndent("break;")
                    .PopIndent();

                if (typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
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

                if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null && composedBuilder.ObjectBuilderName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _", composedBuilder.ObjectInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ObjectBuilderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }

                if (composedBuilder.ArrayInstanceName is not null && composedBuilder.ArrayKindName is not null && composedBuilder.ArrayBuilderName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ArrayKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ArrayKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddProperty(", nameName, ", _", composedBuilder.ArrayInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".", composedBuilder.ArrayBuilderName, ".BuildValue(b, ref o)", includeEscaping ? ", escapeName, nameRequiresUnescaping" : "", ");")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }

                if (composedBuilder.NumericArrayKindName is not null && composedBuilder.NumericArrayTypeName is not null)
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

                if (composedBuilder.StringFormat is string format &&
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

        private static CodeGenerator AppendAddAsItem(this CodeGenerator generator, TypeDeclaration typeDeclaration, List<ComposedBuilder> builders)
        {
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
                        .PopIndent()
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

                if (typeDeclaration.Format() is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType &&
                    seenKinds.Add("StringSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.StringSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_simpleTypeBacking.Span());")
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
                    .AppendLineIndent("case Kind.", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ":")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddItem(_objectBuilder!, static (b, ref o) => ", isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b, ref o));")
                        .AppendLineIndent("break;")
                    .PopIndent();
            }

            HashSet<string> numericArrayKinds = [];

            if (isArray && !canReduce)
            {
                generator
                    .AppendLineIndent("case Kind.", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ":")
                    .PushIndent()
                        .AppendLineIndent("valueBuilder.AddItem(_arrayBuilder!, static (b, ref o) => ", isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName(), ".BuildValue(b, ref o));")
                        .AppendLineIndent("break;")
                    .PopIndent();

                if (typeDeclaration.IsNumericArray() && !typeDeclaration.IsTuple())
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

                if (composedBuilder.ObjectInstanceName is not null && composedBuilder.ObjectKindName is not null)
                {
                    if (seenKinds.Add(composedBuilder.ObjectKindName))
                    {
                        generator
                            .AppendLineIndent("case Kind.", composedBuilder.ObjectKindName, ":")
                            .PushIndent()
                                .AppendLineIndent("valueBuilder.AddItem(_", composedBuilder.ObjectInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".Builder.BuildValue(b, ref o));")
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
                                .AppendLineIndent("valueBuilder.AddItem(_", composedBuilder.ArrayInstanceName, "!, static (b, ref o) => ", composedBuilder.TypeDeclaration.FullyQualifiedDotnetTypeName(), ".Builder.BuildValue(b, ref o));")
                                .AppendLineIndent("break;")
                            .PopIndent();
                    }
                }

                if (composedBuilder.StringFormat is string format &&
                    FormatHandlerRegistry.Instance.StringFormatHandlers.RequiresSimpleTypesBacking(format, out bool requiresSimpleType) &&
                    requiresSimpleType &&
                    seenKinds.Add("StringSimpleType"))
                {
                    generator
                        .AppendLineIndent("case Kind.StringSimpleType:")
                        .PushIndent()
                            .AppendLineIndent("valueBuilder.AddItem(_simpleTypeBacking.Span());")
                            .AppendLineIndent("break;")
                        .PopIndent();
                }

                if (composedBuilder.NumericArrayKindName is not null && composedBuilder.NumericArrayTypeName is not null)
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


        private static CodeGenerator AppendKindsForCoreTypes(this CodeGenerator generator, TypeDeclaration typeDeclaration)
        {
            CoreTypes core = typeDeclaration.ImpliedCoreTypesOrAny();
            if ((core & CoreTypes.String) != 0)
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

            if ((core & (CoreTypes.Number | CoreTypes.Integer)) != 0)
            {
                generator
                    .ReserveName("NumericSimpleType")
                    .ReserveName("FormattedNumber")
                    .AppendLineIndent("NumericSimpleType,")
                    .AppendLineIndent("FormattedNumber,");
            }

            if ((core & CoreTypes.Boolean) != 0)
            {
                generator
                    .ReserveName("True")
                    .ReserveName("False")
                    .AppendLineIndent("True,")
                    .AppendLineIndent("False,");
            }

            if ((core & CoreTypes.Null) != 0)
            {
                generator
                    .ReserveName("Null")
                    .AppendLineIndent("Null,");
            }

            bool isObject = (core & CoreTypes.Object) != 0;
            bool isArray = (core & CoreTypes.Array) != 0;
            bool canReduce = typeDeclaration.CanReduceToAnyOf() || typeDeclaration.CanReduceToOneOf();
            if (isObject && !canReduce)
            {
                string builderKindName = isArray ? generator.ObjectBuilderClassName() : generator.BuilderClassName();
                generator
                    .ReserveName(builderKindName)
                    .AppendLineIndent(builderKindName, ",");
            }

            if (isArray && !canReduce)
            {
                string builderKindName = isObject ? generator.ArrayBuilderClassName() : generator.BuilderClassName();
                generator
                    .ReserveName(builderKindName)
                    .AppendLineIndent(builderKindName, ",");
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

            public TypeDeclaration TypeDeclaration { get; }

            public string? ArrayKindName { get; }
            public string? ObjectKindName { get; }
            public string? ArrayInstanceName { get; }
            public string? ObjectInstanceName { get; }
            public string? ObjectBuilderName { get; }
            public string? ArrayBuilderName { get; }
            public string? NumericArrayKindName { get; }
            public NumericTypeName? NumericArrayTypeName { get; }
            public string? StringFormat { get; }
            public string? NumericFormat { get; }

            public bool IsObject => ObjectKindName is not null;
            public bool IsArray => ArrayKindName is not null;
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


            foreach (TypeDeclaration t in typeDeclaration.BuilderSources())
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

                if (isArray)
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

                if (isObject)
                {
                    objectKindName = generator.GetUniqueMethodNameInScope(t.DotnetTypeName(), suffix: isArray ? "ObjectBuilder" : "Builder");
                    objectInstanceName = generator.GetUniqueFieldNameInScope(objectKindName, suffix: "Instance");
                    objectBuilderName = isArray ? generator.ObjectBuilderClassName(t.FullyQualifiedDotnetTypeName()) : generator.BuilderClassName(t.FullyQualifiedDotnetTypeName());

                    generator
                        .AppendLineIndent(objectKindName, ",");
                }

                // Always add the builder that we have found
                builders.Add(new(t, arrayKindName, objectKindName, arrayInstanceName, objectInstanceName, objectBuilderName, arrayBuilderName, numericArrayKindName, numericArrayTypeName, stringFormat, numericFormat));
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

            return generator;
        }
    }
}
