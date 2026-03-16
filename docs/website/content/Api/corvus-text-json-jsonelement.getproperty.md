---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetProperty(string)](#getproperty-string) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`. |
| [GetProperty(ReadOnlySpan&lt;char&gt;)](#getproperty-readonlyspan-char) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`. |
| [GetProperty(ReadOnlySpan&lt;byte&gt;)](#getproperty-readonlyspan-byte) | Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `utf8PropertyName`. |

## GetProperty(string) {#getproperty-string}

```csharp
JsonElement GetProperty(string propertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Name of the property whose value to return. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `propertyName` is `null`. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

## GetProperty(ReadOnlySpan&lt;char&gt;) {#getproperty-readonlyspan-char}

```csharp
JsonElement GetProperty(ReadOnlySpan<char> propertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `propertyName`.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Name of the property whose value to return. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

## GetProperty(ReadOnlySpan&lt;byte&gt;) {#getproperty-readonlyspan-byte}

```csharp
JsonElement GetProperty(ReadOnlySpan<byte> utf8PropertyName)
```

Gets a [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of a required property identified by `utf8PropertyName`.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property to return. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

A [`JsonElement`](/api/corvus-text-json-jsonelement.html) representing the value of the requested property.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`KeyNotFoundException`](https://learn.microsoft.com/dotnet/api/system.collections.generic.keynotfoundexception) | No property was found with the requested name. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

Property name matching is performed as an ordinal, case-sensitive, comparison. If a property is defined multiple times for the same object, the last such definition is what is matched.

---

