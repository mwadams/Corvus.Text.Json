---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "NuGet Packages"
---
### Corvus.Text.Json

Core runtime library. Required by all generated types.

```bash
dotnet add package Corvus.Text.Json
```

### Corvus.Text.Json.SourceGenerator

Roslyn incremental source generator. Generates C# from JSON Schema at build time. Add as an analyzer reference.

```xml
<PackageReference Include="Corvus.Text.Json.SourceGenerator" Version="5.0.0">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
</PackageReference>
```

### Corvus.Text.Json.CodeGenerator

CLI tool for ahead-of-time code generation. Produces the same output as the source generator.

```bash
dotnet tool install --global Corvus.Text.Json.CodeGenerator
```

### Corvus.Text.Json.Validator

Standalone schema validation tool. Validate JSON documents against JSON Schema from the command line.

```bash
dotnet tool install --global Corvus.Text.Json.Validator
```
