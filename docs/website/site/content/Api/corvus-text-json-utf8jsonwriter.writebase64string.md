---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteBase64String Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [WriteBase64String(JsonEncodedText, ReadOnlySpan&lt;byte&gt;)](#writebase64string-jsonencodedtext-readonlyspan-byte) | Writes the pre-encoded property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object. |
| [WriteBase64String(string, ReadOnlySpan&lt;byte&gt;)](#writebase64string-string-readonlyspan-byte) | Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object. |
| [WriteBase64String(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#writebase64string-readonlyspan-char-readonlyspan-byte) | Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object. |
| [WriteBase64String(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](#writebase64string-readonlyspan-byte-readonlyspan-byte) | Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object. |

## WriteBase64String(JsonEncodedText, ReadOnlySpan&lt;byte&gt;) {#writebase64string-jsonencodedtext-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteProperties.Bytes.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Bytes.cs#L28)

Writes the pre-encoded property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

```csharp
public void WriteBase64String(JsonEncodedText propertyName, ReadOnlySpan<byte> bytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

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

## WriteBase64String(string, ReadOnlySpan&lt;byte&gt;) {#writebase64string-string-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteProperties.Bytes.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Bytes.cs#L56)

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

```csharp
public void WriteBase64String(string propertyName, ReadOnlySpan<byte> bytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `propertyName` parameter is `null`. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteBase64String(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#writebase64string-readonlyspan-char-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteProperties.Bytes.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Bytes.cs#L76)

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

```csharp
public void WriteBase64String(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> bytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteBase64String(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;) {#writebase64string-readonlyspan-byte-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteProperties.Bytes.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteProperties.Bytes.cs#L100)

Writes the property name and raw bytes value (as a Base64 encoded JSON string) as part of a name/value pair of a JSON object.

```csharp
public void WriteBase64String(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> bytes)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded name of the property to write. |
| `bytes` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The binary data to write as Base64 encoded text. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified property name is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

The property name is escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

