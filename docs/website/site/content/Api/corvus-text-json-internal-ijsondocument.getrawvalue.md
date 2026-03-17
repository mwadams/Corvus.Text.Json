---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetRawValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L488)

## GetRawValue {#getrawvalue}

Gets the raw value of the element at the specified index.

```csharp
public abstract RawUtf8JsonString GetRawValue(int index, bool includeQuotes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw value. |

### Returns

[`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html)

The raw value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

