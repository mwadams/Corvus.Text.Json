---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RawUtf8JsonString.TakeOwnership Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TakeOwnership {#takeownership}

```csharp
public ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

Takes ownership of the underlying memory and any extra rented array pool bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | When this method returns, contains the extra rented array pool bytes, if any. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The underlying UTF-8 bytes memory.

