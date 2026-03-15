---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocument.Freeze Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Freeze

```csharp
void Freeze()
```

Makes the document immutable.

### Remarks

You can only create a new document from this document once it is frozen. Immutable documents (like [`ParsedJsonDocument`](/api/corvus-text-json-parsedjsondocument-t.html) are frozen once they are created, and there is no need to call freeze on them. Mutable documents (like [`JsonDocumentBuilder`](/api/corvus-text-json-jsondocumentbuilder-t.html) must be frozen before you can create a child document from one of its elements. Once a mutable document is frozen, any methods that would modify the document will throw.

