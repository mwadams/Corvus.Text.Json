---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryGetMinimumFormatBufferLength Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L939)

## TryGetMinimumFormatBufferLength {#trygetminimumformatbufferlength}

Gets the minimum format buffer length.

```csharp
public bool TryGetMinimumFormatBufferLength(ref int minimumLength)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `minimumLength` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minimum length for a text buffer to format the number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the buffer length required for the number can be safely allocated.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

