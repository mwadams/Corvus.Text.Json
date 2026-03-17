---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.EvaluatedKeywordForProperty Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte) | Records the evaluation of a schema keyword for a specific property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte) | Records the evaluation of a schema keyword for a specific property with a provider context. |

## EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L658)

Records the evaluation of a schema keyword for a specific property.

```csharp
public void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the keyword evaluation matched. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | An optional message provider for generating evaluation messages. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property being evaluated. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte}

**Source:** [JsonSchemaContext.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaContext.cs#L34)

Records the evaluation of a schema keyword for a specific property with a provider context.

```csharp
public void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword)
```

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
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property being evaluated. |
| `unescapedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

