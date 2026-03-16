---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.IgnoredKeyword Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte) | Records that a keyword was ignored during schema evaluation. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Records that a keyword was ignored during schema evaluation with a provider context. |

## IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;) {#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte}

```csharp
public void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Records that a keyword was ignored during schema evaluation.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The encoded keyword that was ignored. |

---

## IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;) {#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte}

```csharp
public void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> unescapedKeyword)
```

Records that a keyword was ignored during schema evaluation with a provider context.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TProviderContext` | The type of the provider context. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The provider context for the evaluation. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was ignored. |

---

