---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaContext.CommitChildContext Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CommitChildContext(bool, ref JsonSchemaContext, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;)](#commitchildcontext-bool-ref-jsonschemacontext-tprovidercontext-jsonschemamessageprovider-tprovidercontext) |  |
| [CommitChildContext(bool, ref JsonSchemaContext, JsonSchemaMessageProvider)](#commitchildcontext-bool-ref-jsonschemacontext-jsonschemamessageprovider) | Commits a child context back to its parent, merging validation results and cleaning up resources. |

## CommitChildContext(bool, ref JsonSchemaContext, TProviderContext, JsonSchemaMessageProvider&lt;TProviderContext&gt;) {#commitchildcontext-bool-ref-jsonschemacontext-tprovidercontext-jsonschemamessageprovider-tprovidercontext}

```csharp
public void CommitChildContext<TProviderContext>(bool isMatch, ref JsonSchemaContext childContext, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `providerContext` | `TProviderContext` |  |
| `messageProvider` | [`JsonSchemaMessageProvider<TProviderContext>`](/api/corvus-text-json-jsonschemamessageprovider.html) |  *(optional)* |

---

## CommitChildContext(bool, ref JsonSchemaContext, JsonSchemaMessageProvider) {#commitchildcontext-bool-ref-jsonschemacontext-jsonschemamessageprovider}

```csharp
public void CommitChildContext(bool isMatch, ref JsonSchemaContext childContext, JsonSchemaMessageProvider messageProvider)
```

Commits a child context back to its parent, merging validation results and cleaning up resources.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `isMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the parent validation succeeded. |
| `childContext` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) | The child context to commit (passed by readonly reference for performance). |
| `messageProvider` | [`JsonSchemaMessageProvider`](/api/corvus-text-json-jsonschemamessageprovider.html) | Optional provider for generating validation messages. *(optional)* |

### Remarks

This is the non-generic overload of [`CommitChildContext`](/api/corvus-text-json-internal-jsonschemacontext.html#commitchildcontext). Use this method when you don't need typed provider context for message generation. The lifecycle management behavior is identical to the generic overload: - Validation results are merged into the results collector - Buffer ownership is transferred from child to parent - Parent match status is updated based on the provided `isMatch` value Typical Usage: Use this overload for simple validation scenarios where error messages don't require additional context beyond the standard validation paths.

---

