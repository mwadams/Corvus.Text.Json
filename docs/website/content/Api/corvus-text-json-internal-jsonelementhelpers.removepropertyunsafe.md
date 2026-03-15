---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers.RemovePropertyUnsafe Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;char&gt;)](#bool-removepropertyunsafe-imutablejsondocument-parentdocument-int-parentdocumentindex-readonlyspan-char-propertyname) | Removes a property value from a target element. |
| [RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;byte&gt;)](#bool-removepropertyunsafe-imutablejsondocument-parentdocument-int-parentdocumentindex-readonlyspan-byte-propertyname) | Removes a property value from a target element. |

## RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<char> propertyName)
```

Removes a property value from a target element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

---

## RemovePropertyUnsafe `static`

```csharp
bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<byte> propertyName)
```

Removes a property value from a target element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

---

