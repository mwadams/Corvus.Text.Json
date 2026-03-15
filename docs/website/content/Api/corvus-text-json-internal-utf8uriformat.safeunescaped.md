---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriFormat.SafeUnescaped Field — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## SafeUnescaped `static`

```csharp
Utf8UriFormat SafeUnescaped
```

The URI is canonically unescaped, allowing the same URI to be reconstructed from the output. If the unescaped sequence results in a new escaped sequence, it will revert to the original sequence.

### Returns

[`Utf8UriFormat`](/api/corvus-text-json-internal-utf8uriformat.html)

