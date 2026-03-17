---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UniqueItemsHashSet.AddItemIfNotExists Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [UniqueItemsHashSet.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/UniqueItemsHashSet.cs#L272)

## AddItemIfNotExists {#additemifnotexists}

Adds the item identified by the parent document index to the map if it does not already exist, returning true if it was added and false if it already existed.

```csharp
public bool AddItemIfNotExists(int parentDocumentIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value in the document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

