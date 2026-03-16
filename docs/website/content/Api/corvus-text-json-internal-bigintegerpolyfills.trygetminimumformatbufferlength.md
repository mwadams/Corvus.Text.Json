---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigIntegerPolyfills.TryGetMinimumFormatBufferLength Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryGetMinimumFormatBufferLength {#trygetminimumformatbufferlength}

```csharp
public static bool TryGetMinimumFormatBufferLength(ref BigInteger bigInteger, ref int minimumLength)
```

Gets the minimum format buffer length.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `bigInteger` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The value for which to get the format buffer length. |
| `minimumLength` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minimum length for a text buffer to format the number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the buffer length required for the number can be safely allocated.

