---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf16JsonString.TakeOwnership Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TakeOwnership {#takeownership}

```csharp
public ReadOnlyMemory<char> TakeOwnership(ref char[] extraRentedArrayPoolChars)
```

Take ownership of the [`ArrayPool`](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1.shared#arraypool) characters, if any.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolChars` | [`ref char[]`](https://learn.microsoft.com/dotnet/api/system.char) | The rented characters, or null if there are no rented characters. |

### Returns

[`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The UTF-16 memory representing the rented characters.

