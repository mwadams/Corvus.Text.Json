---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.StoreRawNumberValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## StoreRawNumberValue {#storerawnumbervalue}

```csharp
int StoreRawNumberValue(ReadOnlySpan<byte> value)
```

Stores a raw number value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The raw number value as a UTF-8 byte span. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

