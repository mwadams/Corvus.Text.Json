---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8Uri.TryCreateUri Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryCreateUri {#trycreateuri}

```csharp
public static bool TryCreateUri(ReadOnlySpan<byte> uri, ref Utf8Uri utf8Uri)
```

Tries to create a new UTF-8 URI from the specified URI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes from which to create the UTF-8 URI. |
| `utf8Uri` | [`ref Utf8Uri`](/api/corvus-text-json-utf8uri.html) | When this method returns, contains the created UTF-8 URI if successful; otherwise, the default value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 URI was created successfully; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

