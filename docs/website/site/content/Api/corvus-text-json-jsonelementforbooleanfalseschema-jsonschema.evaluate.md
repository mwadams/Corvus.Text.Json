---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.JsonSchema.Evaluate Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Evaluate(IJsonDocument, int, ref JsonSchemaContext)](#evaluate-ijsondocument-int-ref-jsonschemacontext) |  |
| [Evaluate(IJsonDocument, int, IJsonSchemaResultsCollector)](#evaluate-ijsondocument-int-ijsonschemaresultscollector) |  |

## Evaluate(IJsonDocument, int, ref JsonSchemaContext) {#evaluate-ijsondocument-int-ref-jsonschemacontext}

**Source:** [JsonElementForBooleanFalseSchema.JsonSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonElementForBooleanFalseSchema.JsonSchema.cs#L167)

```csharp
public static void Evaluate(IJsonDocument parentDocument, int parentIndex, ref JsonSchemaContext context)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Evaluate(IJsonDocument, int, IJsonSchemaResultsCollector) {#evaluate-ijsondocument-int-ijsonschemaresultscollector}

**Source:** [JsonElementForBooleanFalseSchema.JsonSchema.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonElementForBooleanFalseSchema.JsonSchema.cs#L173)

```csharp
public static bool Evaluate(IJsonDocument parentDocument, int parentIndex, IJsonSchemaResultsCollector resultsCollector)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `resultsCollector` | [`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

