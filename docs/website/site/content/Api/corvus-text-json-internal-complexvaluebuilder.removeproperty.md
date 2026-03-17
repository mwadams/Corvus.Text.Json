---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.RemoveProperty Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [RemoveProperty(string)](#removeproperty-string) | Removes a property from the current object. |
| [RemoveProperty(ReadOnlySpan&lt;char&gt;)](#removeproperty-readonlyspan-char) | Removes a property from the current object. |
| [RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool)](#removeproperty-readonlyspan-byte-bool-bool) | Removes a property from the current object. |

## RemoveProperty(string) {#removeproperty-string}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3135)

Removes a property from the current object.

```csharp
public void RemoveProperty(string name)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## RemoveProperty(ReadOnlySpan&lt;char&gt;) {#removeproperty-readonlyspan-char}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3208)

Removes a property from the current object.

```csharp
public void RemoveProperty(ReadOnlySpan<char> name)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a character span. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool) {#removeproperty-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L3237)

Removes a property from the current object.

```csharp
public void RemoveProperty(ReadOnlySpan<byte> utf8Name, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 name of the property. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the name requires escaping. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If the name does not require escaping, indicates whether the name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

