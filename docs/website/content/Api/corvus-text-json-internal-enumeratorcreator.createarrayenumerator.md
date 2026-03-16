---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "EnumeratorCreator.CreateArrayEnumerator Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## CreateArrayEnumerator {#createarrayenumerator}

```csharp
public static ArrayEnumerator<T> CreateArrayEnumerator<T>(IJsonDocument parent, int index)
```

Creates an enumerator for the items of a JSON array.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parent` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent JSON document. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the array in the document. |

### Returns

[`ArrayEnumerator<T>`](/api/corvus-text-json-arrayenumerator-titem.html)

An [`ArrayEnumerator`](/api/corvus-text-json-arrayenumerator-titem.html) for the array.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

