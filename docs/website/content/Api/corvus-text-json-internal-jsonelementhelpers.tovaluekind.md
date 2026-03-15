---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.ToValueKind Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ToValueKind `static`

```csharp
JsonValueKind ToValueKind(JsonTokenType tokenType)
```

Converts a [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) to its corresponding [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `tokenType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The token type to convert. |

### Returns

[`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html)

The corresponding value kind.

