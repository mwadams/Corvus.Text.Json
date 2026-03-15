---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteStartArray Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteStartArray()](#void-writestartarray) | Writes the beginning of a JSON array. |
| [WriteStartArray(JsonEncodedText)](#void-writestartarray-jsonencodedtext-propertyname) | Writes the beginning of a JSON array with a pre-encoded property name as the key. |
| [WriteStartArray(ReadOnlySpan&lt;byte&gt;)](#void-writestartarray-readonlyspan-byte-utf8propertyname) | Writes the beginning of a JSON array with a property name as the key. |
| [WriteStartArray(string)](#void-writestartarray-string-propertyname) | Writes the beginning of a JSON array with a property name as the key. |
| [WriteStartArray(ReadOnlySpan&lt;char&gt;)](#void-writestartarray-readonlyspan-char-propertyname) | Writes the beginning of a JSON array with a property name as the key. |

## WriteStartArray

```csharp
void WriteStartArray()
```

Writes the beginning of a JSON array.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

---

## WriteStartArray

```csharp
void WriteStartArray(JsonEncodedText propertyName)
```

Writes the beginning of a JSON array with a pre-encoded property name as the key.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

---

## WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<byte> utf8PropertyName)
```

Writes the beginning of a JSON array with a property name as the key.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON array to be written. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteStartArray

```csharp
void WriteStartArray(string propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteStartArray

```csharp
void WriteStartArray(ReadOnlySpan<char> propertyName)
```

Writes the beginning of a JSON array with a property name as the key.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

