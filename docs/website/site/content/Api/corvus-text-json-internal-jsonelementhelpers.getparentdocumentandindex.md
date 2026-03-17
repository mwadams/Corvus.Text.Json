---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.GetParentDocumentAndIndex Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.cs#L29)

## GetParentDocumentAndIndex {#getparentdocumentandindex}

Gets the parent document and document index for a JSON element.

```csharp
public static ValueTuple<IJsonDocument, int> GetParentDocumentAndIndex<TElement>(TElement value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | `TElement` | The JSON element value. |

### Returns

[`ValueTuple<IJsonDocument, int>`](https://learn.microsoft.com/dotnet/api/system.valuetuple-2)

A tuple containing the parent document and the document index.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

