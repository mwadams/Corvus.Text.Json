---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetString {#getstring}

```csharp
public string GetString()
```

Gets the value of the element as a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The value of the element as a [`String`](https://learn.microsoft.com/dotnet/api/system.string).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is neither [`String`](/api/corvus-text-json-jsonvaluekind.html#string) nor [`Null`](/api/corvus-text-json-jsonvaluekind.html#null). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a string representation of values other than JSON strings.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

