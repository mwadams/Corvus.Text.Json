---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetProperty(string, ref JsonElement)](#trygetproperty-string-ref-jsonelement) | Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement)](#trygetproperty-readonlyspan-char-ref-jsonelement) | Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |
| [TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement)](#trygetproperty-readonlyspan-byte-ref-jsonelement) | Looks for a property named `utf8PropertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property. |

## TryGetProperty(string, ref JsonElement) {#trygetproperty-string-ref-jsonelement}

```csharp
public bool TryGetProperty(string propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Name of the property to find. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `propertyName` is `null`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

## TryGetProperty(ReadOnlySpan&lt;char&gt;, ref JsonElement) {#trygetproperty-readonlyspan-char-ref-jsonelement}

```csharp
public bool TryGetProperty(ReadOnlySpan<char> propertyName, ref JsonElement value)
```

Looks for a property named `propertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Name of the property to find. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

## TryGetProperty(ReadOnlySpan&lt;byte&gt;, ref JsonElement) {#trygetproperty-readonlyspan-byte-ref-jsonelement}

```csharp
public bool TryGetProperty(ReadOnlySpan<byte> utf8PropertyName, ref JsonElement value)
```

Looks for a property named `utf8PropertyName` in the current object, returning whether or not such a property existed. When the property exists `value` is assigned to the value of that property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | Receives the value of the located property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

