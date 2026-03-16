---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonPointer.TryGetLineAndOffset Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryGetLineAndOffset {#trygetlineandoffset}

```csharp
public bool TryGetLineAndOffset<T>(ref T jsonElement, ref int line, ref int charOffset, ref long lineByteOffset)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the 1-based line number and character offset of the target element in the original source document.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer was resolved and the line and offset were determined; otherwise, `false`.

