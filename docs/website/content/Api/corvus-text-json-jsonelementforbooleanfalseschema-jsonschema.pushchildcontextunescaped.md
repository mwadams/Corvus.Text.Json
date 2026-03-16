---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.JsonSchema.PushChildContextUnescaped Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## PushChildContextUnescaped {#pushchildcontextunescaped}

```csharp
JsonSchemaContext PushChildContextUnescaped(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider evaluationPath)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `evaluationPath` | [`JsonSchemaPathProvider`](/api/corvus-text-json-jsonschemapathprovider.html) |  *(optional)* |

### Returns

[`JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html)

