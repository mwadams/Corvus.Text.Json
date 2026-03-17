---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.IgnoredKeyword Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;)](#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte) | Indicates that a schema keyword was ignored. |
| [IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;)](#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte) | Indicates that a schema keyword was ignored. |

## IgnoredKeyword(JsonSchemaMessageProvider, ReadOnlySpan&lt;byte&gt;) {#ignoredkeyword-jsonschemamessageprovider-readonlyspan-byte}

```csharp
public abstract void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that is ignored. |

---

## IgnoredKeyword(TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;, ReadOnlySpan&lt;byte&gt;) {#ignoredkeyword-tprovidercontext-jsonschemamessageprovider-tprovidercontext-readonlyspan-byte}

```csharp
public abstract void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword)
```

Indicates that a schema keyword was ignored.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |
| `encodedKeyword` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The keyword that is ignored. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

