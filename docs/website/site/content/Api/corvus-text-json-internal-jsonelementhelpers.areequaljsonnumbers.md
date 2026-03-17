---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.AreEqualJsonNumbers Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.Numeric.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.Numeric.cs#L64)

## AreEqualJsonNumbers {#areequaljsonnumbers}

Compares two valid UTF-8 encoded JSON numbers for decimal equality.

```csharp
public static bool AreEqualJsonNumbers(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `left` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded bytes representing the left JSON number. |
| `right` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded bytes representing the right JSON number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the two JSON numbers are equal; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

