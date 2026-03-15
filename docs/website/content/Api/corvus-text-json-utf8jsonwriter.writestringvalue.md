---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteStringValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteStringValue(DateTime)](#void-writestringvalue-datetime-value) | Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(DateTimeOffset)](#void-writestringvalue-datetimeoffset-value) | Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(Guid)](#void-writestringvalue-guid-value) | Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(JsonEncodedText)](#void-writestringvalue-jsonencodedtext-value) | Writes the pre-encoded text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(string)](#void-writestringvalue-string-value) | Writes the string text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(ReadOnlySpan&lt;char&gt;)](#void-writestringvalue-readonlyspan-char-value) | Writes the text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(ReadOnlySpan&lt;byte&gt;)](#void-writestringvalue-readonlyspan-byte-utf8value) | Writes the UTF-8 text value (as a JSON string) as an element of a JSON array. |

## WriteStringValue

```csharp
void WriteStringValue(DateTime value)
```

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000.

---

## WriteStringValue

```csharp
void WriteStringValue(DateTimeOffset value)
```

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000-07:00.

---

## WriteStringValue

```csharp
void WriteStringValue(Guid value)
```

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

---

## WriteStringValue

```csharp
void WriteStringValue(JsonEncodedText value)
```

Writes the pre-encoded text value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

---

## WriteStringValue

```csharp
void WriteStringValue(string value)
```

Writes the string text value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNullValue`](/api/corvus-text-json-utf8jsonwriter.html#writenullvalue) was called.

---

## WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<char> value)
```

Writes the text value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing.

---

## WriteStringValue

```csharp
void WriteStringValue(ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 text value (as a JSON string) as an element of a JSON array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing.

---

