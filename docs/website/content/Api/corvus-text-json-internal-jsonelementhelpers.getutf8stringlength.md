---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.GetUtf8StringLength Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## GetUtf8StringLength {#getutf8stringlength}

```csharp
public static int GetUtf8StringLength(ReadOnlySpan<byte> span)
```

Gets the length of a UTF-8 encoded string in characters (not bytes).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded byte span. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of Unicode characters in the string.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the span contains invalid UTF-8 sequences. |

