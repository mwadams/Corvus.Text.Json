---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddPropertyNull Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddPropertyNull(ReadOnlySpan&lt;byte&gt;)](#addpropertynull-readonlyspan-byte) | Adds a property with a null value to the current object. |
| [AddPropertyNull(ReadOnlySpan&lt;byte&gt;, bool, bool)](#addpropertynull-readonlyspan-byte-bool-bool) | Adds a property with a null value to the current object, with control over escaping. |
| [AddPropertyNull(ReadOnlySpan&lt;char&gt;)](#addpropertynull-readonlyspan-char) | Adds a property with a null value to the current object. |

## AddPropertyNull(ReadOnlySpan&lt;byte&gt;) {#addpropertynull-readonlyspan-byte}

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName)
```

Adds a property with a null value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |

---

## AddPropertyNull(ReadOnlySpan&lt;byte&gt;, bool, bool) {#addpropertynull-readonlyspan-byte-bool-bool}

```csharp
void AddPropertyNull(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with a null value to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyNull(ReadOnlySpan&lt;char&gt;) {#addpropertynull-readonlyspan-char}

```csharp
void AddPropertyNull(ReadOnlySpan<char> propertyName)
```

Adds a property with a null value to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |

---

