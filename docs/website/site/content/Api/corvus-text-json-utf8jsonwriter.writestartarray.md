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
| [WriteStartArray()](#writestartarray) | Writes the beginning of a JSON array. |
| [WriteStartArray(JsonEncodedText)](#writestartarray-jsonencodedtext) | Writes the beginning of a JSON array with a pre-encoded property name as the key. |
| [WriteStartArray(ReadOnlySpan&lt;byte&gt;)](#writestartarray-readonlyspan-byte) | Writes the beginning of a JSON array with a property name as the key. |
| [WriteStartArray(string)](#writestartarray-string) | Writes the beginning of a JSON array with a property name as the key. |
| [WriteStartArray(ReadOnlySpan&lt;char&gt;)](#writestartarray-readonlyspan-char) | Writes the beginning of a JSON array with a property name as the key. |

## WriteStartArray() {#writestartarray}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L573)

Writes the beginning of a JSON array.

```csharp
public void WriteStartArray()
```

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStartArray(JsonEncodedText) {#writestartarray-jsonencodedtext}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L725)

Writes the beginning of a JSON array with a pre-encoded property name as the key.

```csharp
public void WriteStartArray(JsonEncodedText propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) | The JSON-encoded name of the property to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when the depth of the JSON has exceeded the maximum depth of 1000 OR if this would result in invalid JSON being written (while validation is enabled). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStartArray(ReadOnlySpan&lt;byte&gt;) {#writestartarray-readonlyspan-byte}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L771)

Writes the beginning of a JSON array with a property name as the key.

```csharp
public void WriteStartArray(ReadOnlySpan<byte> utf8PropertyName)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStartArray(string) {#writestartarray-string}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L877)

Writes the beginning of a JSON array with a property name as the key.

```csharp
public void WriteStartArray(string propertyName)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStartArray(ReadOnlySpan&lt;char&gt;) {#writestartarray-readonlyspan-char}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L920)

Writes the beginning of a JSON array with a property name as the key.

```csharp
public void WriteStartArray(ReadOnlySpan<char> propertyName)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

