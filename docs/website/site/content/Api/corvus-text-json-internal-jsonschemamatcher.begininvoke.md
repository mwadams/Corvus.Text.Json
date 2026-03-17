---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMatcher.BeginInvoke Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonSchemaMatcher.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/JsonSchemaMatcher.cs#L28)

## BeginInvoke {#begininvoke}

```csharp
public virtual IAsyncResult BeginInvoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, AsyncCallback callback, object object)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

