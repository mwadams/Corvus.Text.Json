---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.CopyString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [CopyString(Span&lt;byte&gt;)](#copystring-span-byte) | Copies the current JSON token value from the source, unescaped as a UTF-8 string to the destination buffer. |
| [CopyString(Span&lt;char&gt;)](#copystring-span-char) | Copies the current JSON token value from the source, unescaped, and transcoded as a UTF-16 char buffer. |

## CopyString(Span&lt;byte&gt;) {#copystring-span-byte}

```csharp
public int CopyString(Span<byte> utf8Destination)
```

Copies the current JSON token value from the source, unescaped as a UTF-8 string to the destination buffer.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A buffer to write the unescaped UTF-8 bytes into. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of bytes written to `utf8Destination`.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The destination buffer is too small to hold the unescaped value. |

### Remarks

Unlike [`GetString`](/api/corvus-text-json-utf8jsonreader.html#getstring), this method does not support [`Null`](/api/corvus-text-json-internal-jsontokentype.html#null). This method will throw [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html#valuespan) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html#valuesequence), since the unescaped result is always less than or equal to the length of the encoded strings.

---

## CopyString(Span&lt;char&gt;) {#copystring-span-char}

```csharp
public int CopyString(Span<char> destination)
```

Copies the current JSON token value from the source, unescaped, and transcoded as a UTF-16 char buffer.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A buffer to write the transcoded UTF-16 characters into. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

The number of characters written to `destination`.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to get the value of the JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname). It will also throw when the JSON string contains invalid UTF-8 bytes, or invalid UTF-16 surrogates. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | The destination buffer is too small to hold the unescaped value. |

### Remarks

Unlike [`GetString`](/api/corvus-text-json-utf8jsonreader.html#getstring), this method does not support [`Null`](/api/corvus-text-json-internal-jsontokentype.html#null). This method will throw [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) if the destination buffer is too small to hold the unescaped value. An appropriately sized buffer can be determined by consulting the length of either [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html#valuespan) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html#valuesequence), since the unescaped result is always less than or equal to the length of the encoded strings.

---

