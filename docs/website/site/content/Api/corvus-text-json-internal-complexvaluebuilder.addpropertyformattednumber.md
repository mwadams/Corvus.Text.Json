---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddPropertyFormattedNumber Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [AddPropertyFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#addpropertyformattednumber-readonlyspan-byte-readonlyspan-byte) | Adds a property with a formatted number value to the current object. |
| [AddPropertyFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addpropertyformattednumber-readonlyspan-byte-readonlyspan-byte-bool-bool) | Adds a property with a formatted number value to the current object. |
| [AddPropertyFormattedNumber(string, ReadOnlySpan&lt;byte&gt;)](#addpropertyformattednumber-string-readonlyspan-byte) | Adds a property with a formatted number value to the current object. |
| [AddPropertyFormattedNumber(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#addpropertyformattednumber-readonlyspan-char-readonlyspan-byte) | Adds a property with a formatted number value to the current object. |

## AddPropertyFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#addpropertyformattednumber-readonlyspan-byte-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L287)

Adds a property with a formatted number value to the current object.

```csharp
public void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyFormattedNumber(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addpropertyformattednumber-readonlyspan-byte-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L297)

Adds a property with a formatted number value to the current object.

```csharp
public void AddPropertyFormattedNumber(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> value, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyFormattedNumber(string, ReadOnlySpan&lt;byte&gt;) {#addpropertyformattednumber-string-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L310)

Adds a property with a formatted number value to the current object.

```csharp
public void AddPropertyFormattedNumber(string propertyName, ReadOnlySpan<byte> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name as a string. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyFormattedNumber(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#addpropertyformattednumber-readonlyspan-char-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L320)

Adds a property with a formatted number value to the current object.

```csharp
public void AddPropertyFormattedNumber(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-16 span. |
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The number value as a UTF-8 byte span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

