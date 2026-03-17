---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf8JsonString Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [UnescapedUtf8JsonString.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/UnescapedUtf8JsonString.cs#L46)

## UnescapedUtf8JsonString {#unescapedutf8jsonstring}

Initializes a new instance of the [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) struct.

```csharp
public UnescapedUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | Optional rented array pool bytes. *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

