---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetDbSize Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## GetDbSize `abstract`

```csharp
int GetDbSize(int index, bool includeEndElement)
```

Gets the size of the database for the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeEndElement` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include the end element in the size. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The size of the database.

