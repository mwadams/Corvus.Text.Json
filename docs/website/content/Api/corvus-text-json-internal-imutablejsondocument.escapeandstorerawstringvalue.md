---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.EscapeAndStoreRawStringValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;char&gt;, ref bool)](#escapeandstorerawstringvalue-readonlyspan-char-ref-bool) | Escapes and stores a raw string value in the document. |
| [EscapeAndStoreRawStringValue(ReadOnlySpan&lt;byte&gt;, ref bool)](#escapeandstorerawstringvalue-readonlyspan-byte-ref-bool) | Escapes and stores a raw string value in the document. |

## EscapeAndStoreRawStringValue(ReadOnlySpan&lt;char&gt;, ref bool) {#escapeandstorerawstringvalue-readonlyspan-char-ref-bool}

```csharp
public abstract int EscapeAndStoreRawStringValue(ReadOnlySpan<char> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The string value to escape and store. |
| `requiredEscaping` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Set to `true` if escaping was required. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## EscapeAndStoreRawStringValue(ReadOnlySpan&lt;byte&gt;, ref bool) {#escapeandstorerawstringvalue-readonlyspan-byte-ref-bool}

```csharp
public abstract int EscapeAndStoreRawStringValue(ReadOnlySpan<byte> value, ref bool requiredEscaping)
```

Escapes and stores a raw string value in the document.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 string value to escape and store. |
| `requiredEscaping` | [`ref bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Set to `true` if escaping was required. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The index of the stored value.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

