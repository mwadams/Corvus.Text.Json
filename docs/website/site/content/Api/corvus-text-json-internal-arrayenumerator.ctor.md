---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayEnumerator Constructors — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ArrayEnumerator.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/ArrayEnumerator.cs#L35)

## ArrayEnumerator {#arrayenumerator}

Initializes a new instance of the [`ArrayEnumerator`](/api/corvus-text-json-internal-arrayenumerator.html) struct.

```csharp
public ArrayEnumerator(IJsonDocument targetDocument, int initialIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `targetDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The document containing the array to enumerate. |
| `initialIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The initial index of the array element in the document. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

