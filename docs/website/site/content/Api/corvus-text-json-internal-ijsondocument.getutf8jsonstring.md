---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetUtf8JsonString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L198)

## GetUtf8JsonString {#getutf8jsonstring}

Gets the UTF-8 JSON string value of the element at the specified index.

```csharp
public abstract UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |

### Returns

[`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The UTF-8 JSON string value.

### Remarks

You are permitted to pass [`None`](/api/corvus-text-json-internal-jsontokentype.html#none) as the `expectedType` which will check both String and PropertyName as valid types.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

