---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ObjectEnumerator<TValue>.GetEnumerator Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ObjectEnumerator{T}.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ObjectEnumerator{T}.cs#L76)

## GetEnumerator {#getenumerator}

Returns an enumerator that iterates the properties of an object.

```csharp
public ObjectEnumerator<TValue> GetEnumerator()
```

### Returns

[`ObjectEnumerator<TValue>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An [`ObjectEnumerator`](/api/corvus-text-json-internal-objectenumerator.html) value that can be used to iterate through the object.

### Implements

[`IEnumerable&lt;JsonProperty&lt;TValue&gt;&gt;.GetEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable.getenumerator)

[`IEnumerable.GetEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable.getenumerator)

### Remarks

The enumerator will enumerate the properties in the order they are declared, and when an object has multiple definitions of a single property they will all individually be returned (each in the order they appear in the content).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

