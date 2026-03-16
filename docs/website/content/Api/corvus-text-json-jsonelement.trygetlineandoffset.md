---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetLineAndOffset Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetLineAndOffset(ref int, ref int)](#trygetlineandoffset-ref-int-ref-int) | Tries to get the 1-based line number and character offset of this element in the original source document. |
| [TryGetLineAndOffset(ref int, ref int, ref long)](#trygetlineandoffset-ref-int-ref-int-ref-long) | Tries to get the 1-based line number, character offset, and byte offset of this element in the original source document. |

## TryGetLineAndOffset(ref int, ref int) {#trygetlineandoffset-ref-int-ref-int}

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset)
```

Tries to get the 1-based line number and character offset of this element in the original source document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

### Remarks

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

---

## TryGetLineAndOffset(ref int, ref int, ref long) {#trygetlineandoffset-ref-int-ref-int-ref-long}

```csharp
bool TryGetLineAndOffset(ref int line, ref int charOffset, ref long lineByteOffset)
```

Tries to get the 1-based line number, character offset, and byte offset of this element in the original source document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

### Remarks

This method returns `false` when the backing document does not retain the original source bytes (for example, mutable builder documents or fixed-string documents).

---

