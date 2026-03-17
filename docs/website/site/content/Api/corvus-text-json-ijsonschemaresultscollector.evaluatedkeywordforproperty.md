---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.EvaluatedKeywordForProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte) | Updates the match state for the given keyword evaluated against the given property. |
| [EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte) | Updates the match state for the given keyword evaluated against the given property. |

## EvaluatedKeywordForProperty(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeywordforproperty-bool-jsonschemamessageprovider-readonlyspan-byte-readonlyspan-byte}

**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L273)

Updates the match state for the given keyword evaluated against the given property.

```csharp
public abstract void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## EvaluatedKeywordForProperty(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeywordforproperty-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte-readonlyspan-byte}

**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L74)

Updates the match state for the given keyword evaluated against the given property.

```csharp
public abstract void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property for which to begin a child context. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

