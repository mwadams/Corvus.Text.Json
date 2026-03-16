---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetDateTimeOffset Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetDateTimeOffset {#getdatetimeoffset}

```csharp
public DateTimeOffset GetDateTimeOffset()
```

Gets the value of the element as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset).

### Returns

[`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset)

The value of the element as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a DateTimeOffset representation of values other than JSON strings.

