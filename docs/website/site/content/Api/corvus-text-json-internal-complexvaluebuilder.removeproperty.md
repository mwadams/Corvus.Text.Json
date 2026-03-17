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

```csharp
public void RemoveProperty(string name)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## RemoveProperty(ReadOnlySpan&lt;char&gt;) {#removeproperty-readonlyspan-char}

```csharp
public void RemoveProperty(ReadOnlySpan<char> name)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a character span. |

---

## RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool) {#removeproperty-readonlyspan-byte-bool-bool}

```csharp
public void RemoveProperty(ReadOnlySpan<byte> utf8Name, bool escapeName, bool nameRequiresUnescaping)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 name of the property. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the name requires escaping. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If the name does not require escaping, indicates whether the name requires unescaping. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

