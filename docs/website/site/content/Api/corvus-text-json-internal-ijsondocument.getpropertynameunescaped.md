---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetPropertyNameUnescaped Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L466)

## GetPropertyNameUnescaped {#getpropertynameunescaped}

Gets the property name as a JSON element.

```csharp
public abstract UnescapedUtf8JsonString GetPropertyNameUnescaped(int index)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

### Returns

[`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html)

The unescaped property name.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

