---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonSchemaResultsCollector.CommitChildContext Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CommitChildContext(int, bool, bool, JsonSchemaMessageProvider)](#void-commitchildcontext-int-sequencenumber-bool-parentismatch-bool-childismatch-jsonschemamessageprovider-messageprovider) | Commits the last child context. |
| [CommitChildContext(int, bool, bool, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](#void-commitchildcontext-tprovidercontext-int-sequencenumber-bool-parentismatch-bool-childismatch-tprovidercontext-providercontext-jsonschemamessageprovider-tprovidercontext-messageprovider) | Commits the last child context. |

## CommitChildContext `abstract`

```csharp
void CommitChildContext(int sequenceNumber, bool parentIsMatch, bool childIsMatch, JsonSchemaMessageProvider messageProvider)
```

Commits the last child context.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |
| `parentIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the commit indicates that the child produced a successful match. |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON validation message. |

### Remarks

This allows the collector to update the match state, and commit any resources associated with the child context.

---

## CommitChildContext `abstract`

```csharp
void CommitChildContext<TProviderContext>(int sequenceNumber, bool parentIsMatch, bool childIsMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

Commits the last child context.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `sequenceNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The sequence number of the child context to commit. |
| `parentIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the parent commit indicates a successful match. |
| `childIsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If `true` then the commit indicates that the child produced a successful match. |
| `providerContext` | `TProviderContext` | The context to provide to the message provider. |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) | The (optional) provider for a JSON schema evaluation message. |

### Remarks

This allows the collector to update the match state, and commit any resources associated with the child context.

---

