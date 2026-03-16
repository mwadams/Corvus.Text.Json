---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetUtf16String Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetUtf16String {#getutf16string}

```csharp
public UnescapedUtf16JsonString GetUtf16String()
```

Gets the value of the element as a [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html).

### Returns

[`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

The value of the element as an [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is neither [`String`](/api/corvus-text-json-jsonvaluekind.html#string) nor [`Null`](/api/corvus-text-json-jsonvaluekind.html#null). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

The [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) should be disposed when it is finished with, as it may have rented storage to provide the unescaped value. It is only valid for as long as the source [`JsonElement`](/api/corvus-text-json-jsonelement.html) is valid.

