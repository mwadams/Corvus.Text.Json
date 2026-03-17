---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReferenceValue.TryGetValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8UriReferenceValue.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Utf8UriReferenceValue.cs#L20)

## TryGetValue {#trygetvalue}

Tries to get the value of the element at the specified index as a [`Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html).

```csharp
public static bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriReferenceValue value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html) | The [`Utf8UriReferenceValue`](/api/corvus-text-json-utf8urireferencevalue.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

