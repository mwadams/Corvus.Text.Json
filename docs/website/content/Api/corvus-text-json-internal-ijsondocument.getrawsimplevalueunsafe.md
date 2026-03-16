---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetRawSimpleValueUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## GetRawSimpleValueUnsafe {#getrawsimplevalueunsafe}

```csharp
ReadOnlyMemory<byte> GetRawSimpleValueUnsafe(int index)
```

Gets the raw simple value of the element at the specified index, without checking if the document has been disposed.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

