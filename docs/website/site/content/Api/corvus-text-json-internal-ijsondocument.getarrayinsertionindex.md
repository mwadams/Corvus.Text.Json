---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetArrayInsertionIndex Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L94)

## GetArrayInsertionIndex {#getarrayinsertionindex}

Gets DB index of the item at the array index within the array that starts at `currentIndex`.

```csharp
public abstract int GetArrayInsertionIndex(int currentIndex, int arrayIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `currentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The current index. |
| `arrayIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The array index. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Remarks

Note that this is the DB index in the current document. Contrast with [`GetArrayIndexElement`](/api/corvus-text-json-internal-ijsondocument.html#getarrayindexelement) overloads which return the document and index of the actual element value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

