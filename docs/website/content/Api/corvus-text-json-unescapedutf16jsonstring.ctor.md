---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf16JsonString Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## UnescapedUtf16JsonString

```csharp
UnescapedUtf16JsonString(ReadOnlyMemory<char> chars, char[] extraRentedArrayPoolChars)
```

Initializes a new instance of the [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) struct.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `chars` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-16 characters representing the JSON string. |
| `extraRentedArrayPoolChars` | [`char[]`](https://learn.microsoft.com/dotnet/api/system.char) | Optional rented array pool characters. *(optional)* |

