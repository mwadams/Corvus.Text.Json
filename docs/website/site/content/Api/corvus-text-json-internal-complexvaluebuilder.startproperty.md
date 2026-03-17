---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.StartProperty Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [StartProperty(ReadOnlySpan&lt;byte&gt;, bool, bool)](#startproperty-readonlyspan-byte-bool-bool) | Add a property name to the current object. |
| [StartProperty(ReadOnlySpan&lt;char&gt;)](#startproperty-readonlyspan-char) | Add a property name to the current object. |
| [StartProperty(string)](#startproperty-string) | Add a property name to the current object. |

## StartProperty(ReadOnlySpan&lt;byte&gt;, bool, bool) {#startproperty-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3358)

Add a property name to the current object.

```csharp
public ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<byte> stringValue, bool escape, bool ifNotEscapeRequiresUenscaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `stringValue` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escape` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether to escape the property name. |
| `ifNotEscapeRequiresUenscaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the property name needs unescaping if it is not to be escaped. |

### Returns

[`ComplexValueBuilder.ComplexValueHandle`](/api/corvus-text-json-internal-complexvaluebuilder-complexvaluehandle.html)

The handle for the property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StartProperty(ReadOnlySpan&lt;char&gt;) {#startproperty-readonlyspan-char}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3372)

Add a property name to the current object.

```csharp
public ComplexValueBuilder.ComplexValueHandle StartProperty(ReadOnlySpan<char> propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |

### Returns

[`ComplexValueBuilder.ComplexValueHandle`](/api/corvus-text-json-internal-complexvaluebuilder-complexvaluehandle.html)

The handle for the property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## StartProperty(string) {#startproperty-string}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3386)

Add a property name to the current object.

```csharp
public ComplexValueBuilder.ComplexValueHandle StartProperty(string propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |

### Returns

[`ComplexValueBuilder.ComplexValueHandle`](/api/corvus-text-json-internal-complexvaluebuilder-complexvaluehandle.html)

The handle for the property.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

