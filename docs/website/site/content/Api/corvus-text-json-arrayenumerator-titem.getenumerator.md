---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ArrayEnumerator<TItem>.GetEnumerator Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ArrayEnumerator{T}.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ArrayEnumerator{T}.cs#L68)

## GetEnumerator {#getenumerator}

Returns an enumerator that iterates through the JSON array.

```csharp
public ArrayEnumerator<TItem> GetEnumerator()
```

### Returns

[`ArrayEnumerator<TItem>`](/api/corvus-text-json-arrayenumerator-titem.html)

An [`ArrayEnumerator`](/api/corvus-text-json-arrayenumerator-titem.html) value that can be used to iterate through the array.

### Implements

[`IEnumerable&lt;TItem&gt;.GetEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable.getenumerator)

[`IEnumerable.GetEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable.getenumerator)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

