---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.EvaluatedKeywordPath Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider)](#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;)](#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext) | Updates the match state for the given evaluated keyword. |

## EvaluatedKeywordPath(bool, JsonSchemaMessageProvider, JsonSchemaPathProvider) {#evaluatedkeywordpath-bool-jsonschemamessageprovider-jsonschemapathprovider}

```csharp
public abstract void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) | The keyword and its sub-path that was evaluated. |

### Remarks

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

---

## EvaluatedKeywordPath(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, JsonSchemaPathProvider&lt;TProviderContext&gt;) {#evaluatedkeywordpath-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-jsonschemapathprovider-tprovidercontext}

```csharp
public abstract void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> encodedKeywordPath)
```

Updates the match state for the given evaluated keyword.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeywordPath` | [`JsonSchemaPathProvider<TProviderContext>`](/api/corvus-text-json-jsonschemapathprovider.html) | The keyword and its sub-path that was evaluated. |

### Remarks

This is used when the entity evaluated was a sub-element of the keyword (e.g. the index of the first name in the array for the `required` keyword, would produce `required/0` as the `encodedKeywordPath`).

---

