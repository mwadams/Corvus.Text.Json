---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf8JsonString.TakeOwnership Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [UnescapedUtf8JsonString.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/UnescapedUtf8JsonString.cs#L57)

## TakeOwnership {#takeownership}

Take ownership of the [`ArrayPool`](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1.shared#arraypool) bytes, if any.

```csharp
public ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The rented bytes, or null if there are no rented bytes. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The UTF-8 memory representing the rented bytes.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

