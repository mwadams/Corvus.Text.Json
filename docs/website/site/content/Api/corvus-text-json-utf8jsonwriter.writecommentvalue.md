---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteCommentValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [WriteCommentValue(string)](#writecommentvalue-string) | Writes the string text value (as a JSON comment). |
| [WriteCommentValue(ReadOnlySpan&lt;char&gt;)](#writecommentvalue-readonlyspan-char) | Writes the text value (as a JSON comment). |
| [WriteCommentValue(ReadOnlySpan&lt;byte&gt;)](#writecommentvalue-readonlyspan-byte) | Writes the UTF-8 text value (as a JSON comment). |

## WriteCommentValue(string) {#writecommentvalue-string}

**Source:** [Utf8JsonWriter.WriteValues.Comment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Comment.cs#L36)

Writes the string text value (as a JSON comment).

```csharp
public void WriteCommentValue(string value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The value to write as a JSON comment within /*..*/. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given string text value contains a comment delimiter (that is, */). |
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `value` parameter is `null`. |

### Remarks

The comment value is not escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteCommentValue(ReadOnlySpan&lt;char&gt;) {#writecommentvalue-readonlyspan-char}

**Source:** [Utf8JsonWriter.WriteValues.Comment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Comment.cs#L52)

Writes the text value (as a JSON comment).

```csharp
public void WriteCommentValue(ReadOnlySpan<char> value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write as a JSON comment within /*..*/. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given text value contains a comment delimiter (that is, */). |

### Remarks

The comment value is not escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteCommentValue(ReadOnlySpan&lt;byte&gt;) {#writecommentvalue-readonlyspan-byte}

**Source:** [Utf8JsonWriter.WriteValues.Comment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Comment.cs#L78)

Writes the UTF-8 text value (as a JSON comment).

```csharp
public void WriteCommentValue(ReadOnlySpan<byte> utf8Value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON comment within /*..*/. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large OR if the given UTF-8 text value contains a comment delimiter (that is, */). |

### Remarks

The comment value is not escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

