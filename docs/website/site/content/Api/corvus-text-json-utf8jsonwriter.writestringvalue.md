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
| [WriteStringValue(DateTime)](#writestringvalue-datetime) | Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(DateTimeOffset)](#writestringvalue-datetimeoffset) | Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(Guid)](#writestringvalue-guid) | Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(JsonEncodedText)](#writestringvalue-jsonencodedtext) | Writes the pre-encoded text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(string)](#writestringvalue-string) | Writes the string text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(ReadOnlySpan&lt;char&gt;)](#writestringvalue-readonlyspan-char) | Writes the text value (as a JSON string) as an element of a JSON array. |
| [WriteStringValue(ReadOnlySpan&lt;byte&gt;)](#writestringvalue-readonlyspan-byte) | Writes the UTF-8 text value (as a JSON string) as an element of a JSON array. |

## WriteStringValue(DateTime) {#writestringvalue-datetime}

**Source:** [Utf8JsonWriter.WriteValues.DateTime.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.DateTime.cs#L29)

Writes the [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime) value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(DateTime value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(DateTimeOffset) {#writestringvalue-datetimeoffset}

**Source:** [Utf8JsonWriter.WriteValues.DateTimeOffset.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.DateTimeOffset.cs#L29)

Writes the [`DateTimeOffset`](https://learn.microsoft.com/dotnet/api/system.datetimeoffset) value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(DateTimeOffset value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(Guid) {#writestringvalue-guid}

**Source:** [Utf8JsonWriter.WriteValues.Guid.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Guid.cs#L30)

Writes the [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid) value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(Guid value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(JsonEncodedText) {#writestringvalue-jsonencodedtext}

**Source:** [Utf8JsonWriter.WriteValues.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.String.cs#L26)

Writes the pre-encoded text value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(JsonEncodedText value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(string) {#writestringvalue-string}

**Source:** [Utf8JsonWriter.WriteValues.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.String.cs#L55)

Writes the string text value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(string value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(ReadOnlySpan&lt;char&gt;) {#writestringvalue-readonlyspan-char}

**Source:** [Utf8JsonWriter.WriteValues.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.String.cs#L80)

Writes the text value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(ReadOnlySpan<char> value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValue(ReadOnlySpan&lt;byte&gt;) {#writestringvalue-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteValues.String.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.String.cs#L103)

Writes the UTF-8 text value (as a JSON string) as an element of a JSON array.

```csharp
public void WriteStringValue(ReadOnlySpan<byte> utf8Value)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

