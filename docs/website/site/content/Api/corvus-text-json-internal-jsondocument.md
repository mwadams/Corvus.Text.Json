---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocument — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/JsonDocument.cs#L34)

Base class for JSON document implementations providing common functionality for parsing and accessing JSON data.

```csharp
public abstract class JsonDocument
```

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonDocument**

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsImmutable](/api/corvus-text-json-internal-jsondocument.isimmutable.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the document is immutable. |

## Methods

| Method | Description |
|--------|-------------|
| [Freeze()](/api/corvus-text-json-internal-jsondocument.freeze.html#freeze) | Makes the document immutable. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

