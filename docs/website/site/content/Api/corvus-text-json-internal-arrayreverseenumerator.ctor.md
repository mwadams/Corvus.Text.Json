---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayReverseEnumerator Constructors — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ArrayReverseEnumerator.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/ArrayReverseEnumerator.cs#L37)

## ArrayReverseEnumerator {#arrayreverseenumerator}

Initializes a new instance of the [`ArrayReverseEnumerator`](/api/corvus-text-json-internal-arrayreverseenumerator.html) struct.

```csharp
public ArrayReverseEnumerator(IJsonDocument targetDocument, int arrayDocumentIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The document containing the array to enumerate. |
| `arrayDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial index of the array element in the document. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

