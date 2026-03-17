---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ParsedJsonDocument<T>.StringConstant Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ParsedJsonDocument.Parse.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/ParsedJsonDocument.Parse.cs#L53)

## StringConstant {#stringconstant}

Creates a constant string instance that does not require disposal.

```csharp
public static T StringConstant(byte[] quotedUtf8String)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `quotedUtf8String` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The quoted UTF-8 string constant value. |

### Returns

`T`

The instance.

### Remarks

This is used for fast initialization for a static value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

