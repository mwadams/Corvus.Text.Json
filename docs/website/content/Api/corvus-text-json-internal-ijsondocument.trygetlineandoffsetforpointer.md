---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetLineAndOffsetForPointer Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryGetLineAndOffsetForPointer `abstract`

```csharp
bool TryGetLineAndOffsetForPointer(ReadOnlySpan<byte> jsonPointer, int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

Resolves a JSON pointer against the element at the specified index and gets the line number and character offset of the target element in the original source document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON pointer to resolve. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element at the root of the pointer resolution. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer was resolved and the line and offset were successfully determined; otherwise, `false`.

