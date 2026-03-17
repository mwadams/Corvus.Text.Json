---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaEvaluation.SchemaLocationForIndexedKeywordWithDependency Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## SchemaLocationForIndexedKeywordWithDependency {#schemalocationforindexedkeywordwithdependency}

```csharp
public static bool SchemaLocationForIndexedKeywordWithDependency(ReadOnlySpan<byte> keywordSchemaLocation, ReadOnlySpan<byte> dependencyName, int index, Span<byte> buffer, ref int written)
```

Creates a schema location for an indexed keyword by appending the index to the base location and dependency.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `keywordSchemaLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The base schema location for the keyword. |
| `dependencyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the dependency. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index to append to the location. |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The buffer to write the resulting location to. |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of bytes written to the buffer. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation succeeded; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

