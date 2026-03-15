---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonPointer.TryCreateJsonPointer Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryCreateJsonPointer `static`

```csharp
bool TryCreateJsonPointer(ReadOnlySpan<byte> jsonPointer, ref Utf8JsonPointer utf8JsonPointer)
```

Tries to create a new UTF-8 JSON Pointer from the specified UTF-8 bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes from which to create the UTF-8 JSON Pointer. |
| `utf8JsonPointer` | [`ref Utf8JsonPointer`](/api/corvus-text-json-utf8jsonpointer.html) | When this method returns, contains the created UTF-8 JSON Pointer if successful; otherwise, the default value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 JSON Pointer was created successfully; otherwise, `false`.

