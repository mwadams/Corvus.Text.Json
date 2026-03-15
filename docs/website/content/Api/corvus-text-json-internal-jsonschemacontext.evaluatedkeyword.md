---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.EvaluatedKeyword Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](#void-evaluatedkeyword-bool-ismatch-jsonschemamessageprovider-messageprovider-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](#void-evaluatedkeyword-tprovidercontext-bool-ismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider-readonlyspan-byte-unescapedkeyword) | Records the evaluation of a schema keyword with a provider context. |

## EvaluatedKeyword

```csharp
void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

---

## EvaluatedKeyword

```csharp
void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records the evaluation of a schema keyword with a provider context.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

---

