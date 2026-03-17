---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.CreateDocument Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [CreateDocument(JsonWorkspace, int, int)](#createdocument-jsonworkspace-int-int) | Creates a JSON document containing the specified integer value. |
| [CreateDocument(JsonWorkspace)](#createdocument-jsonworkspace) | Creates a JSON document from the current instance. |

## CreateDocument(JsonWorkspace, int, int) {#createdocument-jsonworkspace-int-int}

**Source:** [JsonElementForBooleanFalseSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonElementForBooleanFalseSchema.cs#L298)

Creates a JSON document containing the specified integer value.

```csharp
public static JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The integer value to include in the document. |
| `initialCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial capacity for the document builder. *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the specified value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CreateDocument(JsonWorkspace) {#createdocument-jsonworkspace}

**Source:** [JsonElementForBooleanFalseSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonElementForBooleanFalseSchema.cs#L314)

Creates a JSON document from the current instance.

```csharp
public JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |

### Returns

[`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the current instance.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

