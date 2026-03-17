---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L516)

## TryGetBoolean {#trygetboolean}

Tries to get the value as a boolean

```csharp
public bool TryGetBoolean(ref bool value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Provides the boolean value if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was a boolean, otherwise false.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

