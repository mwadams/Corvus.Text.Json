---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.ValueIsEscaped Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ValueIsEscaped `abstract`

```csharp
bool ValueIsEscaped(int index, bool isPropertyName)
```

Determines whether the value at the specified index is escaped.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value. |
| `isPropertyName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value is a property name. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value is escaped; otherwise, `false`.

