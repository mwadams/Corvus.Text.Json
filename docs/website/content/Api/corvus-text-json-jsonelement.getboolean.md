---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetBoolean {#getboolean}

```csharp
bool GetBoolean()
```

Gets the value of the element as a [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean).

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

