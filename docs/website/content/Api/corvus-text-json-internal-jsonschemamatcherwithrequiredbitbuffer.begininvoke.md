---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMatcherWithRequiredBitBuffer.BeginInvoke Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## BeginInvoke {#begininvoke}

```csharp
IAsyncResult BeginInvoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer, AsyncCallback callback, object object)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `requiredBitBuffer` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

