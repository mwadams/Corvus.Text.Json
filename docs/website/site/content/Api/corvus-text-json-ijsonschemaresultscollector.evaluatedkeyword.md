---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.EvaluatedKeyword Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeyword-bool-jsonschemamessageprovider-readonlyspan-byte) | Updates the match state for the given evaluated keyword. |
| [EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](#evaluatedkeyword-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Updates the match state for the given evaluated keyword. |

## EvaluatedKeyword(bool, JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeyword-bool-jsonschemamessageprovider-readonlyspan-byte}

**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L248)

Updates the match state for the given evaluated keyword.

```csharp
public abstract void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## EvaluatedKeyword(bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;) {#evaluatedkeyword-bool-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte}

**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L74)

Updates the match state for the given evaluated keyword.

```csharp
public abstract void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then this indicates that the current context produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provider to the providers. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that was evaluated. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

