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
| [CreateDocument(JsonWorkspace, int, int)](#jsondocumentbuilder-jsonelementforbooleanfalseschema-mutable-createdocument-jsonworkspace-workspace-int-year-int-initialcapacity) | Creates a JSON document containing the specified integer value. |
| [CreateDocument(JsonWorkspace)](#jsondocumentbuilder-jsonelementforbooleanfalseschema-mutable-createdocument-jsonworkspace-workspace) | Creates a JSON document from the current instance. |

## CreateDocument `static`

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace, int year, int initialCapacity)
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

## CreateDocument

```csharp
JsonDocumentBuilder<JsonElementForBooleanFalseSchema.Mutable> CreateDocument(JsonWorkspace workspace)
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

