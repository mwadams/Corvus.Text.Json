---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RawUtf8JsonString Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## RawUtf8JsonString {#rawutf8jsonstring}

```csharp
public RawUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

Initializes a new instance of the [`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html) struct.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | Additional rented bytes from the array pool, if any. *(optional)* |

