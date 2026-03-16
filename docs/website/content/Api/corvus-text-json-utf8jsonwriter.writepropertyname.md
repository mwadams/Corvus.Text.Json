---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WritePropertyName Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WritePropertyName(JsonEncodedText)](#writepropertyname-jsonencodedtext) | Writes the pre-encoded property name (as a JSON string) as the first part of a name/value pair of a JSON object. |
| [WritePropertyName(string)](#writepropertyname-string) | Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object. |
| [WritePropertyName(ReadOnlySpan&lt;char&gt;)](#writepropertyname-readonlyspan-char) | Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object. |
| [WritePropertyName(ReadOnlySpan&lt;byte&gt;)](#writepropertyname-readonlyspan-byte) | Writes the UTF-8 property name (as a JSON string) as the first part of a name/value pair of a JSON object. |

## WritePropertyName(JsonEncodedText) {#writepropertyname-jsonencodedtext}

```csharp
void WritePropertyName(JsonEncodedText propertyName)
```

Writes the pre-encoded property name (as a JSON string) as the first part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

---

## WritePropertyName(string) {#writepropertyname-string}

```csharp
void WritePropertyName(string propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WritePropertyName(ReadOnlySpan&lt;char&gt;) {#writepropertyname-readonlyspan-char}

```csharp
void WritePropertyName(ReadOnlySpan<char> propertyName)
```

Writes the property name (as a JSON string) as the first part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WritePropertyName(ReadOnlySpan&lt;byte&gt;) {#writepropertyname-readonlyspan-byte}

```csharp
void WritePropertyName(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the UTF-8 property name (as a JSON string) as the first part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

