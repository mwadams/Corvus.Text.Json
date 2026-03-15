---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteBoolean Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteBoolean(JsonEncodedText, bool)](#void-writeboolean-jsonencodedtext-propertyname-bool-value) | Writes the pre-encoded property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object. |
| [WriteBoolean(string, bool)](#void-writeboolean-string-propertyname-bool-value) | Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object. |
| [WriteBoolean(ReadOnlySpan&lt;char&gt;, bool)](#void-writeboolean-readonlyspan-char-propertyname-bool-value) | Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object. |
| [WriteBoolean(ReadOnlySpan&lt;byte&gt;, bool)](#void-writeboolean-readonlyspan-byte-utf8propertyname-bool-value) | Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object. |

## WriteBoolean

```csharp
void WriteBoolean(JsonEncodedText propertyName, bool value)
```

Writes the pre-encoded property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

---

## WriteBoolean

```csharp
void WriteBoolean(string propertyName, bool value)
```

Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<char> propertyName, bool value)
```

Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteBoolean

```csharp
void WriteBoolean(ReadOnlySpan<byte> utf8PropertyName, bool value)
```

Writes the property name and [`Boolean`](https://learn.microsoft.com/dotnet/api/system.boolean) value (as a JSON literal "true" or "false") as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

