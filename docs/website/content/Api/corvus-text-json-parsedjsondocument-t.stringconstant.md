---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.StringConstant Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## StringConstant `static`

```csharp
T StringConstant(byte[] quotedUtf8String)
```

Creates a constant string instance that does not require disposal.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `quotedUtf8String` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The quoted UTF-8 string constant value. |

### Returns

`T`

The instance.

### Remarks

This is used for fast initialization for a static value.

