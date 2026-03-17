---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteStringValueSegment Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [WriteStringValueSegment(ReadOnlySpan&lt;char&gt;, bool)](#writestringvaluesegment-readonlyspan-char-bool) | Writes the text value segment as a partial JSON string. |
| [WriteStringValueSegment(ReadOnlySpan&lt;byte&gt;, bool)](#writestringvaluesegment-readonlyspan-byte-bool) | Writes the UTF-8 text value segment as a partial JSON string. |

## WriteStringValueSegment(ReadOnlySpan&lt;char&gt;, bool) {#writestringvaluesegment-readonlyspan-char-bool}

**Source:** [Utf8JsonWriter.WriteValues.StringSegment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.StringSegment.cs#L87)

Writes the text value segment as a partial JSON string.

```csharp
public void WriteStringValueSegment(ReadOnlySpan<char> value, bool isFinalSegment)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The value to write. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

### Remarks

The value is escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteStringValueSegment(ReadOnlySpan&lt;byte&gt;, bool) {#writestringvaluesegment-readonlyspan-byte-bool}

**Source:** [Utf8JsonWriter.WriteValues.StringSegment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.StringSegment.cs#L139)

Writes the UTF-8 text value segment as a partial JSON string.

```csharp
public void WriteStringValueSegment(ReadOnlySpan<byte> value, bool isFinalSegment)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded value to be written as a JSON string element of a JSON array. |
| `isFinalSegment` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Indicates that this is the final segment of the string. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the specified value is too large. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when validation is enabled if this would result in invalid JSON being written or if the previously written segment (if any) was not written with this same overload. |

### Remarks

The value is escaped before writing.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

