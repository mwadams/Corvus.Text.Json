---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.JsonSchema.Evaluate Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Evaluate(IJsonDocument, int, ref JsonSchemaContext)](#void-evaluate-ijsondocument-parentdocument-int-parentindex-ref-jsonschemacontext-context) |  |
| [Evaluate(IJsonDocument, int, IJsonSchemaResultsCollector)](#bool-evaluate-ijsondocument-parentdocument-int-parentindex-ijsonschemaresultscollector-resultscollector) |  |

## Evaluate `static`

```csharp
void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |

---

## Evaluate `static`

```csharp
bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

---

