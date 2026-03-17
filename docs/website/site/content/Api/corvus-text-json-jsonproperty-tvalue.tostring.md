---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue>.ToString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonProperty.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonProperty.cs#L151)

## ToString {#tostring}

Provides a [`String`](https://learn.microsoft.com/dotnet/api/system.string) representation of the property for debugging purposes.

```csharp
public override string ToString()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string containing the un-interpreted value of the property, beginning at the declaring open-quote and ending at the last character that is part of the value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

