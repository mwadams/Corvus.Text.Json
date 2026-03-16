---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.OverwriteAndDispose Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## OverwriteAndDispose {#overwriteanddispose}

```csharp
public abstract void OverwriteAndDispose(int complexObjectStartIndex, int startIndex, int endIndex, int membersToOverwrite, ref ComplexValueBuilder cvb)
```

Overwrites values in the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the range to overwrite. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The end index of the range to overwrite. |
| `membersToOverwrite` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of members to overwrite. |
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to overwrite and dispose. |

