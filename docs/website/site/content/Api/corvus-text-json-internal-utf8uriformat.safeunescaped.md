---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriFormat.SafeUnescaped Field — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8UriFormat.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Uri/Internal/Utf8UriFormat.cs#L14)

## SafeUnescaped {#safeunescaped}

The URI is canonically unescaped, allowing the same URI to be reconstructed from the output. If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence.

```csharp
Utf8UriFormat SafeUnescaped
```

### Returns

[`Utf8UriFormat`](/api/corvus-text-json-internal-utf8uriformat.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

