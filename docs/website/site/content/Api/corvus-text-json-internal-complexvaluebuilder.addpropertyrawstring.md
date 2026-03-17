---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddPropertyRawString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddPropertyRawString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool)](#addpropertyrawstring-readonlyspan-byte-readonlyspan-byte-bool-bool-bool) | Adds a property with a raw string value to the current object, with control over escaping and unescaping. |
| [AddPropertyRawString(string, ReadOnlySpan&lt;byte&gt;, bool)](#addpropertyrawstring-string-readonlyspan-byte-bool) | Adds a property with a raw string value. |
| [AddPropertyRawString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool)](#addpropertyrawstring-readonlyspan-char-readonlyspan-byte-bool) | Adds a property with a raw string value. |

## AddPropertyRawString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool, bool) {#addpropertyrawstring-readonlyspan-byte-readonlyspan-byte-bool-bool-bool}

```csharp
public void AddPropertyRawString(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping, bool valueRequiresUnescaping)
```

Adds a property with a raw string value to the current object, with control over escaping and unescaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the value requires unescaping. |

---

## AddPropertyRawString(string, ReadOnlySpan&lt;byte&gt;, bool) {#addpropertyrawstring-string-readonlyspan-byte-bool}

```csharp
public void AddPropertyRawString(string propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## AddPropertyRawString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;, bool) {#addpropertyrawstring-readonlyspan-char-readonlyspan-byte-bool}

```csharp
public void AddPropertyRawString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value, bool valueRequiresUnescaping)
```

Adds a property with a raw string value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value as a UTF-8 byte span. |
| `valueRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

