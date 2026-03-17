---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.StoreBooleanValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L118)

## StoreBooleanValue {#storebooleanvalue}

Stores a boolean value in the document.

```csharp
public abstract int StoreBooleanValue(bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The boolean value. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

