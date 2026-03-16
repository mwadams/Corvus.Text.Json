---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.Reset Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Reset()](#reset) | Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used. |
| [Reset(Stream)](#reset-stream) | Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of \[`Stream`\](https://learn.microsoft.com/dotnet/api/system.i... |
| [Reset(IBufferWriter&lt;byte&gt;)](#reset-ibufferwriter-byte) | Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of \[`IBufferWriter`\](https://learn.microsoft.com/dotnet/api/s... |

## Reset() {#reset}

```csharp
public void Reset()
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

### Remarks

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options and the original output as the destination (either [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) or [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream)).

---

## Reset(Stream) {#reset-stream}

```csharp
public void Reset(Stream utf8Json)
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Json` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) | An instance of [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) used as a destination for writing JSON text into. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) that is passed in is null. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

### Remarks

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options but now write to the passed in [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) as the new destination.

---

## Reset(IBufferWriter&lt;byte&gt;) {#reset-ibufferwriter-byte}

```csharp
public void Reset(IBufferWriter<byte> bufferWriter)
```

Resets the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) internal state so that it can be re-used with the new instance of [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `bufferWriter` | [`IBufferWriter<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) | An instance of [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) used as a destination for writing JSON text into. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the instance of [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) that is passed in is null. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The instance of [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) has been disposed. |

### Remarks

The [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will continue to use the original writer options but now write to the passed in [`IBufferWriter`](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1) as the new destination.

---

