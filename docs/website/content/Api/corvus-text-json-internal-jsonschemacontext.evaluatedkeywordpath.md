---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.EvaluatedKeywordPath Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider) | Records the evaluation of a schema keyword using a path-based approach. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Records the evaluation of a schema keyword using a path-based approach with a provider context. |

## EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider) {#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider}

```csharp
public void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The message provider for generating evaluation messages. |
| `keywordPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The path provider for the keyword being evaluated. |

---

## EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;) {#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext}

```csharp
public void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> keywordPath)
```

Records the evaluation of a schema keyword using a path-based approach with a provider context.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The message provider for generating evaluation messages. |
| `keywordPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The path provider for the keyword being evaluated. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

