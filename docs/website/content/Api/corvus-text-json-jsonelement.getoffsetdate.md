---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetOffsetDate Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetOffsetDate {#getoffsetdate}

```csharp
public OffsetDate GetOffsetDate()
```

Gets the value of the element as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html).

### Returns

[`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html)

The value of the element as a [`OffsetDate`](https://www.nodatime.org/3.3.x/api/NodaTime.OffsetDate.html).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a OffsetDate representation of values other than JSON strings.

