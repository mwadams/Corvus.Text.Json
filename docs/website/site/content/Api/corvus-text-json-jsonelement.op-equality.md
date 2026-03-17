---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Equality Operator — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## operator == {#operator}

```csharp
public static bool operator ==(JsonElement left, JsonElement right)
```

Compares two JsonElement values for equality.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | The first JsonElement to compare. |
| `right` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) | The second JsonElement to compare. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the JsonElement values are equal; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

