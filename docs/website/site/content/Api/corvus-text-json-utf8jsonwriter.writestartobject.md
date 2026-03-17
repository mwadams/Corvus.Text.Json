---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteStartObject Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [WriteStartObject()](#writestartobject) | Writes the beginning of a JSON object. |
| [WriteStartObject(JsonEncodedText)](#writestartobject-jsonencodedtext) | Writes the beginning of a JSON object with a pre-encoded property name as the key. |
| [WriteStartObject(ReadOnlySpan&lt;byte&gt;)](#writestartobject-readonlyspan-byte) | Writes the beginning of a JSON object with a property name as the key. |
| [WriteStartObject(string)](#writestartobject-string) | Writes the beginning of a JSON object with a property name as the key. |
| [WriteStartObject(ReadOnlySpan&lt;char&gt;)](#writestartobject-readonlyspan-char) | Writes the beginning of a JSON object with a property name as the key. |

## WriteStartObject() {#writestartobject}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L586)

Writes the beginning of a JSON object.

```csharp
public void WriteStartObject()
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

## WriteStartObject(JsonEncodedText) {#writestartobject-jsonencodedtext}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L739)

Writes the beginning of a JSON object with a pre-encoded property name as the key.

```csharp
public void WriteStartObject(JsonEncodedText propertyName)
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

## WriteStartObject(ReadOnlySpan&lt;byte&gt;) {#writestartobject-readonlyspan-byte}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L796)

Writes the beginning of a JSON object with a property name as the key.

```csharp
public void WriteStartObject(ReadOnlySpan<byte> utf8PropertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8PropertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded property name of the JSON object to be written. |

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

## WriteStartObject(string) {#writestartobject-string}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L900)

Writes the beginning of a JSON object with a property name as the key.

```csharp
public void WriteStartObject(string propertyName)
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

## WriteStartObject(ReadOnlySpan&lt;char&gt;) {#writestartobject-readonlyspan-char}

**Source:** [Utf8JsonWriter.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.cs#L945)

Writes the beginning of a JSON object with a property name as the key.

```csharp
public void WriteStartObject(ReadOnlySpan<char> propertyName)
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

