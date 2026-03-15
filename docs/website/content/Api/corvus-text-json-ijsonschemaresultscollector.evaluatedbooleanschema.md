---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.EvaluatedBooleanSchema Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedBooleanSchema(bool, JsonSchemaMessageProvider)](#void-evaluatedbooleanschema-bool-ismatch-jsonschemamessageprovider-messageprovider) | Indicates that a boolean schema was evaluated. |
| [EvaluatedBooleanSchema(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](#void-evaluatedbooleanschema-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider) | Indicates that a boolean schema was evaluated. |

## EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider messageProvider)
```

Indicates that a boolean schema was evaluated.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

### Remarks

This is used when evaluating a schema of the form `true` or `false`.

---

## EvaluatedBooleanSchema `abstract`

```csharp
void EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Indicates that a boolean schema was evaluated.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

### Remarks

This is used when evaluating a schema of the form `true` or `false`.

---

