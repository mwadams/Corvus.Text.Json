---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.RemoveRange Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## RemoveRange `abstract`

```csharp
void RemoveRange(int complexObjectStartIndex, int startIndex, int endIndex, int membersToRemove)
```

Removes a range of values from the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to remove. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to remove. |
| `membersToRemove` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to remove. |

### Remarks

This is similar to [`OverwriteAndDispose`](/api/corvus-text-json-internal-imutablejsondocument.html#overwriteanddispose), but it does not replace the values that are removed. Instead, it simply removes the specified range of members from the document, effectively shifting subsequent members up.

