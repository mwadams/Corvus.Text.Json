---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReference.TryCreateUriReference Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## TryCreateUriReference `static`

```csharp
bool TryCreateUriReference(ReadOnlySpan<byte> uri, ref Utf8UriReference utf8UriReference)
```

Tries to create a new UTF-8 URI Reference from the specified URI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes from which to create the UTF-8 URI from. |
| `utf8UriReference` | [`ref Utf8UriReference`](/api/corvus-text-json-utf8urireference.html) | When this method returns, contains the created UTF-8 URI reference if successful; otherwise, the default value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 URI Reference was created successfully; otherwise, `false`.

