---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue>.NameSpan Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## NameSpan {#namespan}

```csharp
UnescapedUtf8JsonString NameSpan { get; }
```

Gets the name as an unescaped UTF-8 JSON string.

### Returns

[`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

### Remarks

Note that this does not allocate. The result should be disposed when it is no longer needed, as it may use a rented buffer to back the string. It is only valid for the lifetime of the document that contains this property.

