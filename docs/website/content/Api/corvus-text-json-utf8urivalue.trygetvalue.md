---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriValue.TryGetValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetValue {#trygetvalue}

```csharp
public static bool TryGetValue<T>(ref T jsonDocument, int index, ref Utf8UriValue value)
```

Tries to get the value of the element at the specified index as a [`Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html).

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the document. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonDocument` | `ref T` |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | [`ref Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html) | The [`Utf8UriValue`](/api/corvus-text-json-utf8urivalue.html) value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

