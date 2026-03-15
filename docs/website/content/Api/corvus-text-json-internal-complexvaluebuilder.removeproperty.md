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
| [RemoveProperty(string)](#void-removeproperty-string-name) | Removes a property from the current object. |
| [RemoveProperty(ReadOnlySpan&lt;char&gt;)](#void-removeproperty-readonlyspan-char-name) | Removes a property from the current object. |
| [RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-removeproperty-readonlyspan-byte-utf8name-bool-escapename-bool-namerequiresunescaping) | Removes a property from the current object. |

## RemoveProperty

```csharp
void RemoveProperty(string name)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

## RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<char> name)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a character span. |

---

## RemoveProperty

```csharp
void RemoveProperty(ReadOnlySpan<byte> utf8Name, bool escapeName, bool nameRequiresUnescaping)
```

Removes a property from the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 name of the property. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates whether the name requires escaping. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | If the name does not require escaping, indicates whether the name requires unescaping. |

---

