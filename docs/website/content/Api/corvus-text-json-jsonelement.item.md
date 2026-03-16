---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Item Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Property | Description |
|----------|-------------|
| [this\[int\]](#this-int) | Get the value at a specified index when the current value is a [`Array`](/api/corvus-text-json-jsonvaluekind.html#array). |
| [this\[ReadOnlySpan&lt;byte&gt;\]](#this-readonlyspan-byte) | Gets the value of the property with the given UTF-8 encoded name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [this\[ReadOnlySpan&lt;char&gt;\]](#this-readonlyspan-char) | Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [this\[string\]](#this-string) | Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |

## this[int] {#this-int}

```csharp
public JsonElement this[int index] { get; }
```

Get the value at a specified index when the current value is a [`Array`](/api/corvus-text-json-jsonvaluekind.html#array).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html#array). |
| [`IndexOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.indexoutofrangeexception) | `index` is not in the range \[0, [`GetArrayLength`](/api/corvus-text-json-jsonelement.html#getarraylength)()). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

---

## this[ReadOnlySpan&lt;byte&gt;] {#this-readonlyspan-byte}

```csharp
public JsonElement this[ReadOnlySpan<byte> propertyName] { get; }
```

Gets the value of the property with the given UTF-8 encoded name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 (with no Byte-Order-Mark (BOM)) representation of the name of the property. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The value of the property with the given name, or a default [`JsonElement`](/api/corvus-text-json-jsonelement.html) if no such property exists.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

---

## this[ReadOnlySpan&lt;char&gt;] {#this-readonlyspan-char}

```csharp
public JsonElement this[ReadOnlySpan<char> propertyName] { get; }
```

Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The value of the property with the given name, or a default [`JsonElement`](/api/corvus-text-json-jsonelement.html) if no such property exists.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

---

## this[string] {#this-string}

```csharp
public JsonElement this[string propertyName] { get; }
```

Gets the value of the property with the given name when the current value is an [`Object`](/api/corvus-text-json-jsonvaluekind.html#object).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property. |

### Returns

[`JsonElement`](/api/corvus-text-json-jsonelement.html)

The value of the property with the given name, or a default [`JsonElement`](/api/corvus-text-json-jsonelement.html) if no such property exists.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | `propertyName` is `null`. |

---

