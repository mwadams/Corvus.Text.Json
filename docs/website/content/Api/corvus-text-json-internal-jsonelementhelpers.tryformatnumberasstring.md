---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.TryFormatNumberAsString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryFormatNumberAsString {#tryformatnumberasstring}

```csharp
bool TryFormatNumberAsString(ReadOnlySpan<byte> span, ReadOnlySpan<char> format, IFormatProvider provider, ref string value)
```

Format the number as a string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 representation of the number. |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The format to apply. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The (optional) format provider. |
| `value` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | The result if formatting succeeds, otherwise `null`. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if formatting succeeds, otherwise `false`.

### Remarks

This will always return `false` if the formatted result exceeds 2048 characters in size.

