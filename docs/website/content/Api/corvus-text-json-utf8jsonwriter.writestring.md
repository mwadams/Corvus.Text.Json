---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteString(JsonEncodedText, DateTime)](#void-writestring-jsonencodedtext-propertyname-datetime-value) | Writes the pre-encoded property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, DateTime)](#void-writestring-string-propertyname-datetime-value) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, DateTime)](#void-writestring-readonlyspan-char-propertyname-datetime-value) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, DateTime)](#void-writestring-readonlyspan-byte-utf8propertyname-datetime-value) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, DateTimeOffset)](#void-writestring-jsonencodedtext-propertyname-datetimeoffset-value) | Writes the pre-encoded property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, DateTimeOffset)](#void-writestring-string-propertyname-datetimeoffset-value) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, DateTimeOffset)](#void-writestring-readonlyspan-char-propertyname-datetimeoffset-value) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, DateTimeOffset)](#void-writestring-readonlyspan-byte-utf8propertyname-datetimeoffset-value) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, Guid)](#void-writestring-jsonencodedtext-propertyname-guid-value) | Writes the pre-encoded property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, Guid)](#void-writestring-string-propertyname-guid-value) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, Guid)](#void-writestring-readonlyspan-char-propertyname-guid-value) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, Guid)](#void-writestring-readonlyspan-byte-utf8propertyname-guid-value) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, JsonEncodedText)](#void-writestring-jsonencodedtext-propertyname-jsonencodedtext-value) | Writes the pre-encoded property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, JsonEncodedText)](#void-writestring-string-propertyname-jsonencodedtext-value) | Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, string)](#void-writestring-string-propertyname-string-value) | Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#void-writestring-readonlyspan-char-propertyname-readonlyspan-char-value) | Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#void-writestring-readonlyspan-byte-utf8propertyname-readonlyspan-byte-utf8value) | Writes the UTF-8 property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, string)](#void-writestring-jsonencodedtext-propertyname-string-value) | Writes the pre-encoded property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, ReadOnlySpan&lt;char&gt;)](#void-writestring-jsonencodedtext-propertyname-readonlyspan-char-value) | Writes the pre-encoded property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, ReadOnlySpan&lt;char&gt;)](#void-writestring-string-propertyname-readonlyspan-char-value) | Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;)](#void-writestring-readonlyspan-byte-utf8propertyname-readonlyspan-char-value) | Writes the UTF-8 property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, ReadOnlySpan&lt;byte&gt;)](#void-writestring-jsonencodedtext-propertyname-readonlyspan-byte-utf8value) | Writes the pre-encoded property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, ReadOnlySpan&lt;byte&gt;)](#void-writestring-string-propertyname-readonlyspan-byte-utf8value) | Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#void-writestring-readonlyspan-char-propertyname-readonlyspan-byte-utf8value) | Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, JsonEncodedText)](#void-writestring-readonlyspan-char-propertyname-jsonencodedtext-value) | Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, string)](#void-writestring-readonlyspan-char-propertyname-string-value) | Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, JsonEncodedText)](#void-writestring-readonlyspan-byte-utf8propertyname-jsonencodedtext-value) | Writes the UTF-8 property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, string)](#void-writestring-readonlyspan-byte-utf8propertyname-string-value) | Writes the UTF-8 property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTime value)
```

Writes the pre-encoded property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) using the round-trip ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000. The property name should already be escaped when the instance of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) was created.

---

## WriteString

```csharp
void WriteString(string propertyName, DateTime value)
```

Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) using the round-trip ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTime value)
```

Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) using the round-trip ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTime value)
```

Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) using the round-trip ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, DateTimeOffset value)
```

Writes the pre-encoded property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000-07:00.

---

## WriteString

```csharp
void WriteString(string propertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, DateTimeOffset value)
```

Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON object to be written. |
| `value` | [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) using the round-trippable ('O') [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat), for example: 2017-06-12T05:30:45.7680000-07:00. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, Guid value)
```

Writes the pre-encoded property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn.

---

## WriteString

```csharp
void WriteString(string propertyName, Guid value)
```

Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, Guid value)
```

Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, Guid value)
```

Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'D'), as the form: nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn. The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, JsonEncodedText value)
```

Writes the pre-encoded property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

---

## WriteString

```csharp
void WriteString(string propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The JSON-encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(string propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html#writenull) were called.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the UTF-8 property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, string value)
```

Writes the pre-encoded property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html#writenull) was called.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<char> value)
```

Writes the pre-encoded property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing.

---

## WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<char> value)
```

Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
```

Writes the UTF-8 property name and text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(JsonEncodedText propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the pre-encoded property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The value is escaped before writing.

---

## WriteString

```csharp
void WriteString(string propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> utf8Value)
```

Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, JsonEncodedText value)
```

Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<char> propertyName, string value)
```

Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html#writenull) was called.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, JsonEncodedText value)
```

Writes the UTF-8 property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

---

## WriteString

```csharp
void WriteString(ReadOnlySpan<byte> utf8PropertyName, string value)
```

Writes the UTF-8 property name and string text value (as a JSON string) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name or value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name and value are escaped before writing. If `value` is `null` the JSON null value is written, as if [`WriteNull`](/api/corvus-text-json-utf8jsonwriter.html#writenull) was called.

---

