---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8IriValue.TryGetValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8IriValue.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Utf8IriValue.cs#L20)

## TryGetValue {#trygetvalue}

Tries to get the value of the element at the specified index as a [`Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html).

```csharp
public static bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8IriValue value)
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
| `value` | [`ref Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html) | The [`Utf8IriValue`](/api/corvus-text-json-utf8irivalue.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

