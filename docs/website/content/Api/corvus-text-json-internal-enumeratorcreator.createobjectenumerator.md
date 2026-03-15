---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "EnumeratorCreator.CreateObjectEnumerator Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## CreateObjectEnumerator `static`

```csharp
ObjectEnumerator<T> CreateObjectEnumerator<T>(IJsonDocument parent, int index)
```

Creates an enumerator for the properties of a JSON object.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parent` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent JSON document. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the object in the document. |

### Returns

[`ObjectEnumerator<T>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An [`ObjectEnumerator`](/api/corvus-text-json-objectenumerator-tvalue.html) for the object.

