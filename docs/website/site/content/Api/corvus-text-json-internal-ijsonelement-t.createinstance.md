---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonElement<T>.CreateInstance Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonElement{T}.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonElement{T}.cs#L28)

## CreateInstance {#createinstance}

Creates an instance of the element from the parent document and the handle of the element in the parent document.

```csharp
public static T CreateInstance(IJsonDocument parentDocument, int parentDocumentIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The handle of the element in the parent document. |

### Returns

`T`

An instance of the implementing element type.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

