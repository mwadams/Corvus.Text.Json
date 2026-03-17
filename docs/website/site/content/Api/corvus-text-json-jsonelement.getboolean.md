---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L550)

## GetBoolean {#getboolean}

Gets the value of the element as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean).

```csharp
public bool GetBoolean()
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

The value of the element as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is neither [`True`](/api/corvus-text-json-jsonvaluekind.html#true) or [`False`](/api/corvus-text-json-jsonvaluekind.html#false). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

