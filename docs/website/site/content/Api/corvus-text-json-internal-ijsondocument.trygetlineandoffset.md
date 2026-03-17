---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetLineAndOffset Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L653)

## TryGetLineAndOffset {#trygetlineandoffset}

Tries to get the line number and character offset in the original source document for the element at the specified index.

```csharp
public abstract bool TryGetLineAndOffset(int index, ref int line, ref int charOffset, ref long lineByteOffset)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the line and offset were successfully determined; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

