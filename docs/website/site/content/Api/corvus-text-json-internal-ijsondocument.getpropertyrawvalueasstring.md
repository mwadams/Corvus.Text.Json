---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetPropertyRawValueAsString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L480)

## GetPropertyRawValueAsString {#getpropertyrawvalueasstring}

Gets the raw value of the property at the specified index as a string.

```csharp
public abstract string GetPropertyRawValueAsString(int valueIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `valueIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property value. |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The raw value as a string.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

