---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetInt128 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetInt128 {#getint128}

```csharp
public Int128 GetInt128()
```

Gets the current JSON number as a [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128).

### Returns

[`Int128`](https://learn.microsoft.com/dotnet/api/system.int128)

The current JSON number as a [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Number`](/api/corvus-text-json-jsonvaluekind.html#number). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not parse the contents of a JSON string value.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

