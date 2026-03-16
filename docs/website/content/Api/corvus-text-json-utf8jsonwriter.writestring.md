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
| [WriteString(JsonEncodedText, DateTime)](#writestring-jsonencodedtext-datetime) | Writes the pre-encoded property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, DateTime)](#writestring-string-datetime) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, DateTime)](#writestring-readonlyspan-char-datetime) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, DateTime)](#writestring-readonlyspan-byte-datetime) | Writes the property name and [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, DateTimeOffset)](#writestring-jsonencodedtext-datetimeoffset) | Writes the pre-encoded property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, DateTimeOffset)](#writestring-string-datetimeoffset) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, DateTimeOffset)](#writestring-readonlyspan-char-datetimeoffset) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, DateTimeOffset)](#writestring-readonlyspan-byte-datetimeoffset) | Writes the property name and [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, Guid)](#writestring-jsonencodedtext-guid) | Writes the pre-encoded property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, Guid)](#writestring-string-guid) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, Guid)](#writestring-readonlyspan-char-guid) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, Guid)](#writestring-readonlyspan-byte-guid) | Writes the property name and [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, JsonEncodedText)](#writestring-jsonencodedtext-jsonencodedtext) | Writes the pre-encoded property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, JsonEncodedText)](#writestring-string-jsonencodedtext) | Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, string)](#writestring-string-string) | Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;)](#writestring-readonlyspan-char-readonlyspan-char) | Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#writestring-readonlyspan-byte-readonlyspan-byte) | Writes the UTF-8 property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, string)](#writestring-jsonencodedtext-string) | Writes the pre-encoded property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, ReadOnlySpan&lt;char&gt;)](#writestring-jsonencodedtext-readonlyspan-char) | Writes the pre-encoded property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, ReadOnlySpan&lt;char&gt;)](#writestring-string-readonlyspan-char) | Writes the property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;)](#writestring-readonlyspan-byte-readonlyspan-char) | Writes the UTF-8 property name and text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(JsonEncodedText, ReadOnlySpan&lt;byte&gt;)](#writestring-jsonencodedtext-readonlyspan-byte) | Writes the pre-encoded property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(string, ReadOnlySpan&lt;byte&gt;)](#writestring-string-readonlyspan-byte) | Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#writestring-readonlyspan-char-readonlyspan-byte) | Writes the property name and UTF-8 text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, JsonEncodedText)](#writestring-readonlyspan-char-jsonencodedtext) | Writes the property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;char&gt;, string)](#writestring-readonlyspan-char-string) | Writes the property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, JsonEncodedText)](#writestring-readonlyspan-byte-jsonencodedtext) | Writes the UTF-8 property name and pre-encoded value (as a JSON string) as part of a name/value pair of a JSON object. |
| [WriteString(ReadOnlySpan&lt;byte&gt;, string)](#writestring-readonlyspan-byte-string) | Writes the UTF-8 property name and string text value (as a JSON string) as part of a name/value pair of a JSON object. |

## WriteString(JsonEncodedText, DateTime) {#writestring-jsonencodedtext-datetime}

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

## WriteString(string, DateTime) {#writestring-string-datetime}

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

## WriteString(ReadOnlySpan&lt;char&gt;, DateTime) {#writestring-readonlyspan-char-datetime}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, DateTime) {#writestring-readonlyspan-byte-datetime}

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

## WriteString(JsonEncodedText, DateTimeOffset) {#writestring-jsonencodedtext-datetimeoffset}

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

## WriteString(string, DateTimeOffset) {#writestring-string-datetimeoffset}

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

## WriteString(ReadOnlySpan&lt;char&gt;, DateTimeOffset) {#writestring-readonlyspan-char-datetimeoffset}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, DateTimeOffset) {#writestring-readonlyspan-byte-datetimeoffset}

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

## WriteString(JsonEncodedText, Guid) {#writestring-jsonencodedtext-guid}

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

## WriteString(string, Guid) {#writestring-string-guid}

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

## WriteString(ReadOnlySpan&lt;char&gt;, Guid) {#writestring-readonlyspan-char-guid}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, Guid) {#writestring-readonlyspan-byte-guid}

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

## WriteString(JsonEncodedText, JsonEncodedText) {#writestring-jsonencodedtext-jsonencodedtext}

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

## WriteString(string, JsonEncodedText) {#writestring-string-jsonencodedtext}

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

## WriteString(string, string) {#writestring-string-string}

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

## WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;char&gt;) {#writestring-readonlyspan-char-readonlyspan-char}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#writestring-readonlyspan-byte-readonlyspan-byte}

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

## WriteString(JsonEncodedText, string) {#writestring-jsonencodedtext-string}

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

## WriteString(JsonEncodedText, ReadOnlySpan&lt;char&gt;) {#writestring-jsonencodedtext-readonlyspan-char}

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

## WriteString(string, ReadOnlySpan&lt;char&gt;) {#writestring-string-readonlyspan-char}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;) {#writestring-readonlyspan-byte-readonlyspan-char}

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

## WriteString(JsonEncodedText, ReadOnlySpan&lt;byte&gt;) {#writestring-jsonencodedtext-readonlyspan-byte}

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

## WriteString(string, ReadOnlySpan&lt;byte&gt;) {#writestring-string-readonlyspan-byte}

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

## WriteString(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#writestring-readonlyspan-char-readonlyspan-byte}

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

## WriteString(ReadOnlySpan&lt;char&gt;, JsonEncodedText) {#writestring-readonlyspan-char-jsonencodedtext}

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

## WriteString(ReadOnlySpan&lt;char&gt;, string) {#writestring-readonlyspan-char-string}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, JsonEncodedText) {#writestring-readonlyspan-byte-jsonencodedtext}

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

## WriteString(ReadOnlySpan&lt;byte&gt;, string) {#writestring-readonlyspan-byte-string}

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

