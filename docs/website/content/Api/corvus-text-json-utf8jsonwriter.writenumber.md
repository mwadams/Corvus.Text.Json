---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteNumber Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [WriteNumber(JsonEncodedText, decimal)](#void-writenumber-jsonencodedtext-propertyname-decimal-value) | Writes the pre-encoded property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, decimal)](#void-writenumber-string-propertyname-decimal-value) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, decimal)](#void-writenumber-readonlyspan-char-propertyname-decimal-value) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, decimal)](#void-writenumber-readonlyspan-byte-utf8propertyname-decimal-value) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, double)](#void-writenumber-jsonencodedtext-propertyname-double-value) | Writes the pre-encoded property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, double)](#void-writenumber-string-propertyname-double-value) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, double)](#void-writenumber-readonlyspan-char-propertyname-double-value) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, double)](#void-writenumber-readonlyspan-byte-utf8propertyname-double-value) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, float)](#void-writenumber-jsonencodedtext-propertyname-float-value) | Writes the pre-encoded property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, float)](#void-writenumber-string-propertyname-float-value) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, float)](#void-writenumber-readonlyspan-char-propertyname-float-value) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, float)](#void-writenumber-readonlyspan-byte-utf8propertyname-float-value) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, long)](#void-writenumber-jsonencodedtext-propertyname-long-value) | Writes the pre-encoded property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, long)](#void-writenumber-string-propertyname-long-value) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, long)](#void-writenumber-readonlyspan-char-propertyname-long-value) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, long)](#void-writenumber-readonlyspan-byte-utf8propertyname-long-value) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, int)](#void-writenumber-jsonencodedtext-propertyname-int-value) | Writes the pre-encoded property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, int)](#void-writenumber-string-propertyname-int-value) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, int)](#void-writenumber-readonlyspan-char-propertyname-int-value) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, int)](#void-writenumber-readonlyspan-byte-utf8propertyname-int-value) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, ulong)](#void-writenumber-jsonencodedtext-propertyname-ulong-value) | Writes the pre-encoded property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, ulong)](#void-writenumber-string-propertyname-ulong-value) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, ulong)](#void-writenumber-readonlyspan-char-propertyname-ulong-value) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, ulong)](#void-writenumber-readonlyspan-byte-utf8propertyname-ulong-value) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, uint)](#void-writenumber-jsonencodedtext-propertyname-uint-value) | Writes the pre-encoded property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, uint)](#void-writenumber-string-propertyname-uint-value) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, uint)](#void-writenumber-readonlyspan-char-propertyname-uint-value) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, uint)](#void-writenumber-readonlyspan-byte-utf8propertyname-uint-value) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, decimal value)
```

Writes the pre-encoded property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G').

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, decimal value)
```

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, decimal value)
```

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, decimal value)
```

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, double value)
```

Writes the pre-encoded property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G').

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, double value)
```

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, double value)
```

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, double value)
```

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, float value)
```

Writes the pre-encoded property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G').

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, float value)
```

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, float value)
```

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write.. |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, float value)
```

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write |
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'). The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, long value)
```

Writes the pre-encoded property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, long value)
```

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, long value)
```

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, long value)
```

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, int value)
```

Writes the pre-encoded property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, int value)
```

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, int value)
```

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, int value)
```

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, ulong value)
```

Writes the pre-encoded property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, ulong value)
```

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, ulong value)
```

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ulong value)
```

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(JsonEncodedText propertyName, uint value)
```

Writes the pre-encoded property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

---

## WriteNumber

```csharp
void WriteNumber(string propertyName, uint value)
```

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<char> propertyName, uint value)
```

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

## WriteNumber

```csharp
void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, uint value)
```

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767. The property name is escaped before writing.

---

