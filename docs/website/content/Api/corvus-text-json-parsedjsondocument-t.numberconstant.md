---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.NumberConstant Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## NumberConstant {#numberconstant}

```csharp
T NumberConstant(byte[] utf8Number)
```

Creates a constant number instance that does not require disposal.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Number` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The UTF-8 number constant value. |

### Returns

`T`

The instance.

### Remarks

This is used for fast initialization for a static value.

