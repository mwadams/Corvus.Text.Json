---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf16JsonString Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [UnescapedUtf16JsonString.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/UnescapedUtf16JsonString.cs#L46)

## UnescapedUtf16JsonString {#unescapedutf16jsonstring}

Initializes a new instance of the [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) struct.

```csharp
public UnescapedUtf16JsonString(ReadOnlyMemory<char> chars, char[] extraRentedArrayPoolChars)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `chars` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-16 characters representing the JSON string. |
| `extraRentedArrayPoolChars` | [`char[]`](https://learn.microsoft.com/dotnet/api/system.char) | Optional rented array pool characters. *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

