using System.Reflection;

namespace XmlDocToMarkdown;

/// <summary>
/// Information about a namespace and all its public types.
/// </summary>
public sealed class NamespaceInfo
{
    public string Name { get; set; } = string.Empty;
    public List<TypeInfo> Types { get; set; } = [];
}

/// <summary>
/// Information about a public type.
/// </summary>
public sealed class TypeInfo
{
    public string FullName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Namespace { get; set; } = string.Empty;
    public string Kind { get; set; } = string.Empty; // class, struct, interface, enum, delegate
    public string? BaseType { get; set; }
    public string? BaseTypeFullName { get; set; }
    public List<string> Interfaces { get; set; } = [];
    public List<(string DisplayName, string? FullName)> InterfacesWithFullNames { get; set; } = [];
    public List<(string DisplayName, string? FullName)> ImplementedBy { get; set; } = [];
    public List<string> GenericParameters { get; set; } = [];
    public DocMember? Documentation { get; set; }
    public List<MemberInfo> Constructors { get; set; } = [];
    public List<MemberInfo> Properties { get; set; } = [];
    public List<MemberInfo> Methods { get; set; } = [];
    public List<MemberInfo> Fields { get; set; } = [];
    public List<MemberInfo> Events { get; set; } = [];
    public List<TypeInfo> NestedTypes { get; set; } = [];
    public bool IsStatic { get; set; }
    public bool IsAbstract { get; set; }
    public bool IsSealed { get; set; }
}

/// <summary>
/// Information about a type member (method, property, field, event, or constructor).
/// </summary>
public sealed class MemberInfo
{
    public string Name { get; set; } = string.Empty;
    public string Signature { get; set; } = string.Empty;
    public string ReturnType { get; set; } = string.Empty;
    public string? ReturnTypeFullName { get; set; }
    public List<ParameterInfo> Parameters { get; set; } = [];
    public DocMember? Documentation { get; set; }
    public bool IsStatic { get; set; }
    public bool IsVirtual { get; set; }
    public bool IsAbstract { get; set; }
    public bool IsOverride { get; set; }
    public string XmlDocKey { get; set; } = string.Empty;
}

public sealed class ParameterInfo
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? TypeFullName { get; set; }
    public bool IsOptional { get; set; }
    public string? DefaultValue { get; set; }
}

/// <summary>
/// Uses <see cref="MetadataLoadContext"/> to inspect public types from a compiled assembly
/// without loading it into the execution context.
/// </summary>
public sealed class AssemblyInspector(string assemblyPath)
{
    /// <summary>
    /// Quick pre-scan: returns a map of type FullName → per-type page URL slug.
    /// Used to populate <see cref="XmlDocParser.TypeUrlMap"/> before XML parsing.
    /// </summary>
    public Dictionary<string, string> PreScanTypeUrls()
    {
        Dictionary<string, string> map = new(StringComparer.Ordinal);

        string runtimeDir = Path.GetDirectoryName(typeof(object).Assembly.Location)!;
        string assemblyDir = Path.GetDirectoryName(Path.GetFullPath(assemblyPath))!;

        PathAssemblyResolver resolver = new(GetAssemblyPaths(runtimeDir, assemblyDir));
        using MetadataLoadContext mlc = new(resolver, coreAssemblyName: "System.Runtime");
        Assembly assembly = mlc.LoadFromAssemblyPath(Path.GetFullPath(assemblyPath));

        foreach (Type type in assembly.GetExportedTypes())
        {
            if (type.Name.StartsWith('<') || type.FullName is null || type.IsNested)
            {
                continue;
            }

            string ns = type.Namespace ?? "(global)";
            string nsSlug = MarkdownGenerator.NamespaceToFileName(ns);
            string typeName = FormatTypeName(type);
            string typeSlug = MarkdownGenerator.TypeToSlug(typeName);
            string url = $"/api/{nsSlug}-{typeSlug}.html";
            map[type.FullName] = url;
        }

        return map;
    }

    public Dictionary<string, NamespaceInfo> Inspect(Dictionary<string, DocMember> xmlDocs)
    {
        Dictionary<string, NamespaceInfo> namespaces = new(StringComparer.Ordinal);

        string runtimeDir = Path.GetDirectoryName(typeof(object).Assembly.Location)!;
        string assemblyDir = Path.GetDirectoryName(Path.GetFullPath(assemblyPath))!;

        PathAssemblyResolver resolver = new(GetAssemblyPaths(runtimeDir, assemblyDir));
        using MetadataLoadContext mlc = new(resolver, coreAssemblyName: "System.Runtime");
        Assembly assembly = mlc.LoadFromAssemblyPath(Path.GetFullPath(assemblyPath));

        foreach (Type type in assembly.GetExportedTypes())
        {
            // Skip compiler-generated types
            if (type.Name.StartsWith('<') || type.FullName is null)
            {
                continue;
            }

            string ns = type.Namespace ?? "(global)";

            // For nested types, we attach them to the parent type later
            if (type.IsNested)
            {
                continue;
            }

            if (!namespaces.TryGetValue(ns, out NamespaceInfo? nsInfo))
            {
                nsInfo = new NamespaceInfo { Name = ns };
                namespaces[ns] = nsInfo;
            }

            TypeInfo typeInfo;
            try
            {
                typeInfo = BuildTypeInfo(type, xmlDocs, mlc);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"  Warning: Skipping type {type.FullName}: {ex.Message}");
                continue;
            }

            nsInfo.Types.Add(typeInfo);
        }

        // Sort types within each namespace
        foreach (NamespaceInfo ns in namespaces.Values)
        {
            ns.Types.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        }

        return namespaces;
    }

    private static TypeInfo BuildTypeInfo(Type type, Dictionary<string, DocMember> xmlDocs, MetadataLoadContext mlc)
    {
        string fullName = type.FullName ?? type.Name;
        string xmlKey = $"T:{fullName}";

        TypeInfo typeInfo = new()
        {
            FullName = fullName,
            Name = FormatTypeName(type),
            Namespace = type.Namespace ?? "(global)",
            Kind = GetTypeKind(type),
            BaseType = GetBaseTypeName(type),
            BaseTypeFullName = GetBaseTypeFullName(type),
            IsStatic = type.IsAbstract && type.IsSealed,
            IsAbstract = type.IsAbstract && !type.IsSealed && !type.IsInterface,
            IsSealed = type.IsSealed && !type.IsAbstract,
        };

        xmlDocs.TryGetValue(xmlKey, out DocMember? typeDocs);
        typeInfo.Documentation = typeDocs;

        // Generic parameters
        if (type.IsGenericType)
        {
            foreach (Type gp in type.GetGenericArguments())
            {
                typeInfo.GenericParameters.Add(gp.Name);
            }
        }

        // Interfaces
        foreach (Type iface in type.GetInterfaces())
        {
            if (iface.IsPublic || iface.IsNestedPublic)
            {
                typeInfo.Interfaces.Add(FormatTypeName(iface));
                typeInfo.InterfacesWithFullNames.Add((FormatTypeName(iface), GetTypeFullName(iface)));
            }
        }

        // Constructors
        foreach (System.Reflection.ConstructorInfo ctor in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
        {
            string ctorXmlKey = BuildConstructorXmlKey(type, ctor);
            xmlDocs.TryGetValue(ctorXmlKey, out DocMember? ctorDocs);
            typeInfo.Constructors.Add(BuildConstructorMemberInfo(type, ctor, ctorDocs, ctorXmlKey));
        }

        // Properties
        foreach (System.Reflection.PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            string propXmlKey = $"P:{fullName}.{prop.Name}";
            xmlDocs.TryGetValue(propXmlKey, out DocMember? propDocs);
            typeInfo.Properties.Add(BuildPropertyMemberInfo(prop, propDocs, propXmlKey));
        }

        // Methods (excluding property accessors, event accessors, and operator overloads for readability)
        foreach (System.Reflection.MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            if (method.IsSpecialName)
            {
                continue;
            }

            string methodXmlKey = BuildMethodXmlKey(type, method);
            xmlDocs.TryGetValue(methodXmlKey, out DocMember? methodDocs);
            typeInfo.Methods.Add(BuildMethodMemberInfo(method, methodDocs, methodXmlKey));
        }

        // Fields (for enums and public fields)
        foreach (System.Reflection.FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            if (field.IsSpecialName)
            {
                continue;
            }

            string fieldXmlKey = $"F:{fullName}.{field.Name}";
            xmlDocs.TryGetValue(fieldXmlKey, out DocMember? fieldDocs);
            typeInfo.Fields.Add(new MemberInfo
            {
                Name = field.Name,
                Signature = $"{FormatTypeName(field.FieldType)} {field.Name}",
                ReturnType = FormatTypeName(field.FieldType),
                ReturnTypeFullName = GetTypeFullName(field.FieldType),
                Documentation = fieldDocs,
                IsStatic = field.IsStatic,
                XmlDocKey = fieldXmlKey,
            });
        }

        // Events
        foreach (System.Reflection.EventInfo evt in type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            string evtXmlKey = $"E:{fullName}.{evt.Name}";
            xmlDocs.TryGetValue(evtXmlKey, out DocMember? evtDocs);
            typeInfo.Events.Add(new MemberInfo
            {
                Name = evt.Name ?? string.Empty,
                Signature = $"event {FormatTypeName(evt.EventHandlerType!)} {evt.Name}",
                ReturnType = FormatTypeName(evt.EventHandlerType!),
                ReturnTypeFullName = GetTypeFullName(evt.EventHandlerType!),
                Documentation = evtDocs,
                XmlDocKey = evtXmlKey,
            });
        }

        // Nested types
        foreach (Type nested in type.GetNestedTypes(BindingFlags.Public))
        {
            typeInfo.NestedTypes.Add(BuildTypeInfo(nested, xmlDocs, mlc));
        }

        typeInfo.NestedTypes.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));

        return typeInfo;
    }

    private static MemberInfo BuildConstructorMemberInfo(Type type, System.Reflection.ConstructorInfo ctor, DocMember? docs, string xmlKey)
    {
        System.Reflection.ParameterInfo[] parameters = ctor.GetParameters();
        string paramList = string.Join(", ", parameters.Select(p => $"{FormatTypeName(p.ParameterType)} {p.Name}"));
        string shortName = FormatTypeName(type);
        // Remove generic suffix for constructor name
        int backtick = shortName.IndexOf('<');
        if (backtick >= 0)
        {
            shortName = shortName[..backtick];
        }

        return new MemberInfo
        {
            Name = shortName,
            Signature = $"{shortName}({paramList})",
            Parameters = parameters.Select(p => new ParameterInfo
            {
                Name = p.Name ?? string.Empty,
                Type = FormatTypeName(p.ParameterType),
                TypeFullName = GetTypeFullName(p.ParameterType),
                IsOptional = p.IsOptional,
                DefaultValue = p.HasDefaultValue ? p.RawDefaultValue?.ToString() : null,
            }).ToList(),
            Documentation = docs,
            XmlDocKey = xmlKey,
        };
    }

    private static MemberInfo BuildPropertyMemberInfo(System.Reflection.PropertyInfo prop, DocMember? docs, string xmlKey)
    {
        string accessors = "";
        if (prop.CanRead && prop.CanWrite)
        {
            accessors = " { get; set; }";
        }
        else if (prop.CanRead)
        {
            accessors = " { get; }";
        }
        else if (prop.CanWrite)
        {
            accessors = " { set; }";
        }

        System.Reflection.MethodInfo? getter = prop.GetGetMethod();
        return new MemberInfo
        {
            Name = prop.Name,
            Signature = $"{FormatTypeName(prop.PropertyType)} {prop.Name}{accessors}",
            ReturnType = FormatTypeName(prop.PropertyType),
            ReturnTypeFullName = GetTypeFullName(prop.PropertyType),
            Documentation = docs,
            IsStatic = getter?.IsStatic ?? false,
            XmlDocKey = xmlKey,
        };
    }

    private static MemberInfo BuildMethodMemberInfo(System.Reflection.MethodInfo method, DocMember? docs, string xmlKey)
    {
        System.Reflection.ParameterInfo[] parameters = method.GetParameters();
        string paramList = string.Join(", ", parameters.Select(p => $"{FormatTypeName(p.ParameterType)} {p.Name}"));

        string genericSuffix = "";
        if (method.IsGenericMethod)
        {
            Type[] genericArgs = method.GetGenericArguments();
            genericSuffix = $"<{string.Join(", ", genericArgs.Select(g => g.Name))}>";
        }

        // GetBaseDefinition() is not supported by MetadataLoadContext, so we
        // approximate "override" by checking for IsVirtual + !IsAbstract on a
        // non-interface declaring type that itself did not introduce the slot.
        bool isOverride = false;
        try
        {
            isOverride = method.GetBaseDefinition().DeclaringType != method.DeclaringType;
        }
        catch (NotSupportedException)
        {
            // MetadataLoadContext does not support GetBaseDefinition; skip override detection.
        }

        return new MemberInfo
        {
            Name = method.Name,
            Signature = $"{FormatTypeName(method.ReturnType)} {method.Name}{genericSuffix}({paramList})",
            ReturnType = FormatTypeName(method.ReturnType),
            ReturnTypeFullName = GetTypeFullName(method.ReturnType),
            Parameters = parameters.Select(p => new ParameterInfo
            {
                Name = p.Name ?? string.Empty,
                Type = FormatTypeName(p.ParameterType),
                TypeFullName = GetTypeFullName(p.ParameterType),
                IsOptional = p.IsOptional,
                DefaultValue = p.HasDefaultValue ? p.RawDefaultValue?.ToString() : null,
            }).ToList(),
            Documentation = docs,
            IsStatic = method.IsStatic,
            IsVirtual = method.IsVirtual && !method.IsFinal,
            IsAbstract = method.IsAbstract,
            IsOverride = isOverride,
            XmlDocKey = xmlKey,
        };
    }

    private static string BuildConstructorXmlKey(Type type, System.Reflection.ConstructorInfo ctor)
    {
        string fullName = type.FullName ?? type.Name;
        System.Reflection.ParameterInfo[] parameters = ctor.GetParameters();
        if (parameters.Length == 0)
        {
            return $"M:{fullName}.#ctor";
        }

        string paramTypes = string.Join(",", parameters.Select(p => GetXmlDocTypeName(p.ParameterType)));
        return $"M:{fullName}.#ctor({paramTypes})";
    }

    private static string BuildMethodXmlKey(Type type, System.Reflection.MethodInfo method)
    {
        string fullName = type.FullName ?? type.Name;
        string methodName = method.Name;

        if (method.IsGenericMethod)
        {
            methodName += $"``{method.GetGenericArguments().Length}";
        }

        System.Reflection.ParameterInfo[] parameters = method.GetParameters();
        if (parameters.Length == 0)
        {
            return $"M:{fullName}.{methodName}";
        }

        string paramTypes = string.Join(",", parameters.Select(p => GetXmlDocTypeName(p.ParameterType)));
        return $"M:{fullName}.{methodName}({paramTypes})";
    }

    private static string GetXmlDocTypeName(Type type)
    {
        if (type.IsGenericParameter)
        {
            // Method-level generic parameters use ``N, type-level use `N
            if (type.DeclaringMethod is not null)
            {
                return $"``{type.GenericParameterPosition}";
            }

            return $"`{type.GenericParameterPosition}";
        }

        if (type.IsArray)
        {
            return GetXmlDocTypeName(type.GetElementType()!) + "[]";
        }

        if (type.IsByRef)
        {
            return GetXmlDocTypeName(type.GetElementType()!) + "@";
        }

        if (type.IsGenericType)
        {
            string baseName = type.GetGenericTypeDefinition().FullName ?? type.Name;
            int backtick = baseName.IndexOf('`');
            if (backtick >= 0)
            {
                baseName = baseName[..backtick];
            }

            Type[] args = type.GetGenericArguments();
            return $"{baseName}{{{string.Join(",", args.Select(GetXmlDocTypeName))}}}";
        }

        return type.FullName ?? type.Name;
    }

    internal static string FormatTypeName(Type type)
    {
        if (type.IsGenericParameter)
        {
            return type.Name;
        }

        if (type.IsArray)
        {
            return FormatTypeName(type.GetElementType()!) + "[]";
        }

        if (type.IsByRef)
        {
            return "ref " + FormatTypeName(type.GetElementType()!);
        }

        // Handle Nullable<T>
        if (type.IsGenericType)
        {
            Type genericDef = type.GetGenericTypeDefinition();
            string baseName = genericDef.Name;
            int backtick = baseName.IndexOf('`');
            if (backtick >= 0)
            {
                baseName = baseName[..backtick];
            }

            // Use the declaring type for nested types
            if (type.IsNested && type.DeclaringType is not null)
            {
                baseName = FormatTypeName(type.DeclaringType) + "." + baseName;
            }

            Type[] args = type.GetGenericArguments();
            return $"{baseName}<{string.Join(", ", args.Select(FormatTypeName))}>";
        }

        if (type.IsNested && type.DeclaringType is not null)
        {
            return FormatTypeName(type.DeclaringType) + "." + type.Name;
        }

        // Use C# keyword aliases for common types
        return type.FullName switch
        {
            "System.Void" => "void",
            "System.Boolean" => "bool",
            "System.Byte" => "byte",
            "System.SByte" => "sbyte",
            "System.Char" => "char",
            "System.Int16" => "short",
            "System.UInt16" => "ushort",
            "System.Int32" => "int",
            "System.UInt32" => "uint",
            "System.Int64" => "long",
            "System.UInt64" => "ulong",
            "System.Single" => "float",
            "System.Double" => "double",
            "System.Decimal" => "decimal",
            "System.String" => "string",
            "System.Object" => "object",
            _ => type.Name,
        };
    }

    private static string? GetBaseTypeName(Type type)
    {
        if (type.BaseType is null || type.BaseType.FullName == "System.Object" ||
            type.BaseType.FullName == "System.ValueType" || type.BaseType.FullName == "System.Enum")
        {
            return null;
        }

        return FormatTypeName(type.BaseType);
    }

    /// <summary>
    /// Gets the full type name suitable for URL resolution (e.g., System.String, System.Collections.Generic.List`1).
    /// Returns null for generic parameter types.
    /// </summary>
    internal static string? GetTypeFullName(Type type)
    {
        if (type.IsGenericParameter)
        {
            return null;
        }

        if (type.IsArray)
        {
            return GetTypeFullName(type.GetElementType()!);
        }

        if (type.IsByRef)
        {
            return GetTypeFullName(type.GetElementType()!);
        }

        if (type.IsGenericType)
        {
            Type genericDef = type.GetGenericTypeDefinition();
            return genericDef.FullName;
        }

        return type.FullName;
    }

    private static string? GetBaseTypeFullName(Type type)
    {
        if (type.BaseType is null || type.BaseType.FullName == "System.Object" ||
            type.BaseType.FullName == "System.ValueType" || type.BaseType.FullName == "System.Enum")
        {
            return null;
        }

        return GetTypeFullName(type.BaseType);
    }

    private static string GetTypeKind(Type type)
    {
        if (type.IsEnum)
        {
            return "enum";
        }

        if (type.IsInterface)
        {
            return "interface";
        }

        if (type.IsValueType)
        {
            return "struct";
        }

        if (type.BaseType?.FullName == "System.MulticastDelegate")
        {
            return "delegate";
        }

        return "class";
    }

    private static IEnumerable<string> GetAssemblyPaths(string runtimeDir, string assemblyDir)
    {
        HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);

        foreach (string dll in Directory.GetFiles(runtimeDir, "*.dll"))
        {
            string name = Path.GetFileName(dll);
            if (seen.Add(name))
            {
                yield return dll;
            }
        }

        // Also include DLLs from the assembly directory (for dependencies)
        foreach (string dll in Directory.GetFiles(assemblyDir, "*.dll"))
        {
            string name = Path.GetFileName(dll);
            if (seen.Add(name))
            {
                yield return dll;
            }
        }

        // Resolve NuGet package assemblies from the .deps.json file
        string depsJsonPath = Path.Combine(assemblyDir, Path.GetFileNameWithoutExtension(
            Directory.GetFiles(assemblyDir, "*.deps.json").FirstOrDefault() ?? string.Empty));
        string[] depsFiles = Directory.GetFiles(assemblyDir, "*.deps.json");
        if (depsFiles.Length > 0)
        {
            foreach (string nugetDll in ResolveNuGetAssemblies(depsFiles[0]))
            {
                string name = Path.GetFileName(nugetDll);
                if (seen.Add(name))
                {
                    yield return nugetDll;
                }
            }
        }
    }

    private static IEnumerable<string> ResolveNuGetAssemblies(string depsJsonPath)
    {
        // Parse the deps.json to find NuGet package references and resolve them
        // from the global NuGet packages cache.
        string nugetCache = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".nuget", "packages");

        if (!File.Exists(depsJsonPath) || !Directory.Exists(nugetCache))
        {
            yield break;
        }

        string json = File.ReadAllText(depsJsonPath);
        using System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(json);

        // Get the target framework from runtimeTarget
        string? targetFramework = null;
        if (doc.RootElement.TryGetProperty("runtimeTarget", out System.Text.Json.JsonElement runtimeTarget))
        {
            targetFramework = runtimeTarget.GetProperty("name").GetString();
        }

        if (targetFramework is null)
        {
            yield break;
        }

        // Iterate over the libraries to find NuGet packages (type == "package")
        if (!doc.RootElement.TryGetProperty("libraries", out System.Text.Json.JsonElement libraries))
        {
            yield break;
        }

        foreach (System.Text.Json.JsonProperty lib in libraries.EnumerateObject())
        {
            if (!lib.Value.TryGetProperty("type", out System.Text.Json.JsonElement typeElement) ||
                typeElement.GetString() != "package")
            {
                continue;
            }

            // Library key is "PackageName/Version"
            string[] parts = lib.Name.Split('/');
            if (parts.Length != 2)
            {
                continue;
            }

            string packageId = parts[0].ToLowerInvariant();
            string version = parts[1];

            // Look for DLLs in the package directory, preferring net10.0 > net9.0 > net8.0 > netstandard2.1 > netstandard2.0
            string packageDir = Path.Combine(nugetCache, packageId, version, "lib");
            if (!Directory.Exists(packageDir))
            {
                continue;
            }

            string[] preferredTfms = ["net10.0", "net9.0", "net8.0", "net7.0", "net6.0", "netstandard2.1", "netstandard2.0"];
            foreach (string tfm in preferredTfms)
            {
                string tfmDir = Path.Combine(packageDir, tfm);
                if (Directory.Exists(tfmDir))
                {
                    foreach (string dll in Directory.GetFiles(tfmDir, "*.dll"))
                    {
                        yield return dll;
                    }

                    break;
                }
            }
        }
    }
}
