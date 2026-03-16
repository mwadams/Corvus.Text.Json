---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetUtf16JsonString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## GetUtf16JsonString {#getutf16jsonstring}

```csharp
UnescapedUtf16JsonString GetUtf16JsonString(int index, JsonTokenType expectedType)
```

Gets the UTF-16 JSON string value of the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |

### Returns

[`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

The UTF-16 JSON string value.

### Remarks

You are permitted to pass [`None`](/api/corvus-text-json-internal-jsontokentype.html#none) as the `expectedType` which will check both String and PropertyName as valid types.

