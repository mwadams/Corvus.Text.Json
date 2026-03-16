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

```csharp
public static JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity)
```

Creates a JSON document containing the specified integer value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |
| `year` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The integer value to include in the document. |
| `initialCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial capacity for the document builder. *(optional)* |

### Returns

[`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the specified value.

---

## CreateDocument(JsonWorkspace) {#createdocument-jsonworkspace}

```csharp
public JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace)
```

Creates a JSON document from the current instance.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `workspace` | [`JsonWorkspace`](/api/corvus-text-json-jsonworkspace.html) | The JSON workspace to use for document creation. |

### Returns

[`JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable>`](/api/corvus-text-json-jsondocumentbuilder-t.html)

A JSON document builder containing the current instance.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

