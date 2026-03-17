---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.IsIntegerNormalizedJsonNumber Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.Numeric.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.Numeric.cs#L166)

## IsIntegerNormalizedJsonNumber {#isintegernormalizedjsonnumber}

Determines if a JSON number is an integer.

```csharp
public static bool IsIntegerNormalizedJsonNumber(int exponent)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `exponent` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The exponent. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the normalized JSON number represents an integer.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

