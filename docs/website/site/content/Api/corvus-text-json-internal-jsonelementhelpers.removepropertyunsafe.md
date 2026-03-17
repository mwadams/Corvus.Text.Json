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
| [RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;char&gt;)](#removepropertyunsafe-imutablejsondocument-int-readonlyspan-char) | Removes a property value from a target element. |
| [RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;byte&gt;)](#removepropertyunsafe-imutablejsondocument-int-readonlyspan-byte) | Removes a property value from a target element. |

## RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;char&gt;) {#removepropertyunsafe-imutablejsondocument-int-readonlyspan-char}

**Source:** [JsonElementHelpers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.cs#L74)

Removes a property value from a target element.

```csharp
public static bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<char> propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## RemovePropertyUnsafe(IMutableJsonDocument, int, ReadOnlySpan&lt;byte&gt;) {#removepropertyunsafe-imutablejsondocument-int-readonlyspan-byte}

**Source:** [JsonElementHelpers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.cs#L98)

Removes a property value from a target element.

```csharp
public static bool RemovePropertyUnsafe(IMutableJsonDocument parentDocument, int parentDocumentIndex, ReadOnlySpan<byte> propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to remove. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found and removed; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

