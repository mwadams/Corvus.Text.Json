---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.InsertAndDispose Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## InsertAndDispose {#insertanddispose}

```csharp
public abstract void InsertAndDispose(int complexObjectStartIndex, int index, ref ComplexValueBuilder cvb)
```

Inserts a value into the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `complexObjectStartIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The start index of the complex object. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index at which to insert. |
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to insert and dispose. |

