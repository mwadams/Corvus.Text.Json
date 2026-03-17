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
| [WriteNumber(JsonEncodedText, decimal)](#writenumber-jsonencodedtext-decimal) | Writes the pre-encoded property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, decimal)](#writenumber-string-decimal) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, decimal)](#writenumber-readonlyspan-char-decimal) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, decimal)](#writenumber-readonlyspan-byte-decimal) | Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, double)](#writenumber-jsonencodedtext-double) | Writes the pre-encoded property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, double)](#writenumber-string-double) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, double)](#writenumber-readonlyspan-char-double) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, double)](#writenumber-readonlyspan-byte-double) | Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, float)](#writenumber-jsonencodedtext-float) | Writes the pre-encoded property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, float)](#writenumber-string-float) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, float)](#writenumber-readonlyspan-char-float) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, float)](#writenumber-readonlyspan-byte-float) | Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, long)](#writenumber-jsonencodedtext-long) | Writes the pre-encoded property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, long)](#writenumber-string-long) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, long)](#writenumber-readonlyspan-char-long) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, long)](#writenumber-readonlyspan-byte-long) | Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, int)](#writenumber-jsonencodedtext-int) | Writes the pre-encoded property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, int)](#writenumber-string-int) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, int)](#writenumber-readonlyspan-char-int) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, int)](#writenumber-readonlyspan-byte-int) | Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, ulong)](#writenumber-jsonencodedtext-ulong) | Writes the pre-encoded property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, ulong)](#writenumber-string-ulong) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, ulong)](#writenumber-readonlyspan-char-ulong) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, ulong)](#writenumber-readonlyspan-byte-ulong) | Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(JsonEncodedText, uint)](#writenumber-jsonencodedtext-uint) | Writes the pre-encoded property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(string, uint)](#writenumber-string-uint) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;char&gt;, uint)](#writenumber-readonlyspan-char-uint) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |
| [WriteNumber(ReadOnlySpan&lt;byte&gt;, uint)](#writenumber-readonlyspan-byte-uint) | Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object. |

## WriteNumber(JsonEncodedText, decimal) {#writenumber-jsonencodedtext-decimal}

**Source:** [Utf8JsonWriter.WriteProperties.Decimal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Decimal.cs#L31)

Writes the pre-encoded property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, decimal value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, decimal) {#writenumber-string-decimal}

**Source:** [Utf8JsonWriter.WriteProperties.Decimal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Decimal.cs#L60)

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, decimal value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, decimal) {#writenumber-readonlyspan-char-decimal}

**Source:** [Utf8JsonWriter.WriteProperties.Decimal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Decimal.cs#L81)

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, decimal value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, decimal) {#writenumber-readonlyspan-byte-decimal}

**Source:** [Utf8JsonWriter.WriteProperties.Decimal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Decimal.cs#L106)

Writes the property name and [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, decimal value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, double) {#writenumber-jsonencodedtext-double}

**Source:** [Utf8JsonWriter.WriteProperties.Double.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Double.cs#L30)

Writes the pre-encoded property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, double value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, double) {#writenumber-string-double}

**Source:** [Utf8JsonWriter.WriteProperties.Double.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Double.cs#L61)

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, double value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, double) {#writenumber-readonlyspan-char-double}

**Source:** [Utf8JsonWriter.WriteProperties.Double.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Double.cs#L82)

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, double value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, double) {#writenumber-readonlyspan-byte-double}

**Source:** [Utf8JsonWriter.WriteProperties.Double.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Double.cs#L108)

Writes the property name and [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, double value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, float) {#writenumber-jsonencodedtext-float}

**Source:** [Utf8JsonWriter.WriteProperties.Float.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Float.cs#L30)

Writes the pre-encoded property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, float value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, float) {#writenumber-string-float}

**Source:** [Utf8JsonWriter.WriteProperties.Float.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Float.cs#L61)

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, float value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, float) {#writenumber-readonlyspan-char-float}

**Source:** [Utf8JsonWriter.WriteProperties.Float.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Float.cs#L82)

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, float value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, float) {#writenumber-readonlyspan-byte-float}

**Source:** [Utf8JsonWriter.WriteProperties.Float.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Float.cs#L108)

Writes the property name and [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, float value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, long) {#writenumber-jsonencodedtext-long}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L31)

Writes the pre-encoded property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, long value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, long) {#writenumber-string-long}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L60)

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, long value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, long) {#writenumber-readonlyspan-char-long}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L81)

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, long value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, long) {#writenumber-readonlyspan-byte-long}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L106)

Writes the property name and [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, long value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, int) {#writenumber-jsonencodedtext-int}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L126)

Writes the pre-encoded property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, int value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, int) {#writenumber-string-int}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L148)

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, int value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, int) {#writenumber-readonlyspan-char-int}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L167)

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, int value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, int) {#writenumber-readonlyspan-byte-int}

**Source:** [Utf8JsonWriter.WriteProperties.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.SignedNumber.cs#L185)

Writes the property name and [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, int value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, ulong) {#writenumber-jsonencodedtext-ulong}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L32)

Writes the pre-encoded property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, ulong value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, ulong) {#writenumber-string-ulong}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L62)

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, ulong value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, ulong) {#writenumber-readonlyspan-char-ulong}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L84)

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, ulong value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, ulong) {#writenumber-readonlyspan-byte-ulong}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L110)

Writes the property name and [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, ulong value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(JsonEncodedText, uint) {#writenumber-jsonencodedtext-uint}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L131)

Writes the pre-encoded property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(JsonEncodedText propertyName, uint value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(string, uint) {#writenumber-string-uint}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L154)

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(string propertyName, uint value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;char&gt;, uint) {#writenumber-readonlyspan-char-uint}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L175)

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<char> propertyName, uint value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumber(ReadOnlySpan&lt;byte&gt;, uint) {#writenumber-readonlyspan-byte-uint}

**Source:** [Utf8JsonWriter.WriteProperties.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.UnsignedNumber.cs#L194)

Writes the property name and [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as part of a name/value pair of a JSON object.

```csharp
public void WriteNumber(ReadOnlySpan<byte> utf8PropertyName, uint value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

