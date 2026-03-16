---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.CountRunes Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## CountRunes {#countrunes}

```csharp
int CountRunes(ReadOnlySpan<byte> utf8String)
```

Count the runes in a UTF-8 string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8String` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 string for which to count the runes. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of runes in the UTF-8 string.

