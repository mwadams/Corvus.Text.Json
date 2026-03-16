---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetLine Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetLine(int, ref ReadOnlyMemory&lt;byte&gt;)](#trygetline-int-ref-readonlymemory-byte) | Tries to get the specified line from the original source document as UTF-8 bytes. |
| [TryGetLine(int, ref string)](#trygetline-int-ref-string) | Tries to get the specified line from the original source document as a string. |

## TryGetLine(int, ref ReadOnlyMemory&lt;byte&gt;) {#trygetline-int-ref-readonlymemory-byte}

```csharp
bool TryGetLine(int lineNumber, ref ReadOnlyMemory<byte> line)
```

Tries to get the specified line from the original source document as UTF-8 bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The 1-based line number to retrieve. |
| `line` | [`ref ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | When this method returns, contains the UTF-8 bytes of the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line was successfully retrieved; otherwise, `false`.

### Remarks

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.

---

## TryGetLine(int, ref string) {#trygetline-int-ref-string}

```csharp
bool TryGetLine(int lineNumber, ref string line)
```

Tries to get the specified line from the original source document as a string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `lineNumber` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The 1-based line number to retrieve. |
| `line` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | When this method returns, contains the line text if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line was successfully retrieved; otherwise, `false`.

### Remarks

This method returns `false` when the backing document does not retain the original source bytes, or when `lineNumber` is out of range.

---

