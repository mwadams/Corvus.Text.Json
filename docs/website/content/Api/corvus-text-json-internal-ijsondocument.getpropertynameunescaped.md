---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetPropertyNameUnescaped Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## GetPropertyNameUnescaped {#getpropertynameunescaped}

```csharp
public abstract UnescapedUtf8JsonString GetPropertyNameUnescaped(int index)
```

Gets the property name as a JSON element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

### Returns

[`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The unescaped property name.

