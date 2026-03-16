---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteBooleanValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## WriteBooleanValue {#writebooleanvalue}

```csharp
public void WriteBooleanValue(bool value)
```

Writes the [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

