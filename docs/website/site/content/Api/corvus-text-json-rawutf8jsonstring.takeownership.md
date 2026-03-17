---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RawUtf8JsonString.TakeOwnership Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [RawUtf8JsonString.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/RawUtf8JsonString.cs#L57)

## TakeOwnership {#takeownership}

Takes ownership of the underlying memory and any extra rented array pool bytes.

```csharp
public ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | When this method returns, contains the extra rented array pool bytes, if any. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The underlying UTF-8 bytes memory.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

