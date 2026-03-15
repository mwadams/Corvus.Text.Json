---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Constructor | Description |
|-------------|-------------|
| [Utf8JsonWriter(IBufferWriter&lt;byte&gt;, JsonWriterOptions)](#utf8jsonwriter-ibufferwriter-byte-bufferwriter-jsonwriteroptions-options) | Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `bufferWriter`. |
| [Utf8JsonWriter(Stream, JsonWriterOptions)](#utf8jsonwriter-stream-utf8json-jsonwriteroptions-options) | Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `utf8Json`. |

## Utf8JsonWriter

```csharp
Utf8JsonWriter(IBufferWriter<byte> bufferWriter, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `bufferWriter`.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | An instance of [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) used as a destination for writing JSON text into. |
| `options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Defines the customized behavior of the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) By default, the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) that is passed in is null. |

---

## Utf8JsonWriter

```csharp
Utf8JsonWriter(Stream utf8Json, JsonWriterOptions options)
```

Constructs a new [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) instance with a specified `utf8Json`.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | An instance of [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) used as a destination for writing JSON text into. |
| `options` | [`JsonWriterOptions`](/api/corvus-text-json-jsonwriteroptions.html) | Defines the customized behavior of the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) By default, the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) writes JSON minimized (that is, with no extra whitespace) and validates that the JSON being written is structurally valid according to JSON RFC. *(optional)* |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) that is passed in is null. |

---

