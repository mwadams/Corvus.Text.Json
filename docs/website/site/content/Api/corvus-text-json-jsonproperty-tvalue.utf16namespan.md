---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue>.Utf16NameSpan Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonProperty.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonProperty.cs#L70)

## Utf16NameSpan {#utf16namespan}

Gets the name as an unescaped UTF-16 JSON string.

```csharp
public UnescapedUtf16JsonString Utf16NameSpan { get; }
```

### Returns

[`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html)

### Remarks

Note that this does not allocate. The result should be disposed when it is no longer needed, as it may use a rented buffer to back the string. It is only valid for the lifetime of the document that contains this property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

