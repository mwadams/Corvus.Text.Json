---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Uri.CreateUri Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateUri {#createuri}

```csharp
public static Utf8Uri CreateUri(ReadOnlySpan<byte> uri)
```

Creates a new UTF-8 URI from the specified URI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes from which to create the UTF-8 URI. |

### Returns

[`Utf8Uri`](/api/corvus-text-json-utf8uri.html)

A new UTF-8 URI.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the URI is invalid. |

