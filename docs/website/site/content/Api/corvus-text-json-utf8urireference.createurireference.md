---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriReference.CreateUriReference Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## CreateUriReference {#createurireference}

```csharp
public static Utf8UriReference CreateUriReference(ReadOnlySpan<byte> uri)
```

Creates a new UTF-8 URI Reference from the specified URI bytes.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `uri` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The URI bytes to create the reference from. |

### Returns

[`Utf8UriReference`](/api/corvus-text-json-utf8urireference.html)

A new UTF-8 URI Reference.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the URI is invalid. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

