---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Constructor | Description |
|-------------|-------------|
| [Utf8JsonReader(ReadOnlySpan&lt;byte&gt;, bool, JsonReaderState)](#utf8jsonreader-readonlyspan-byte-bool-jsonreaderstate) | Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance. |
| [Utf8JsonReader(ReadOnlySpan&lt;byte&gt;, JsonReaderOptions)](#utf8jsonreader-readonlyspan-byte-jsonreaderoptions) | Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance. |
| [Utf8JsonReader(ReadOnlySequence&lt;byte&gt;, bool, JsonReaderState)](#utf8jsonreader-readonlysequence-byte-bool-jsonreaderstate) | Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance. |
| [Utf8JsonReader(ReadOnlySequence&lt;byte&gt;, JsonReaderOptions)](#utf8jsonreader-readonlysequence-byte-jsonreaderoptions) | Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance. |

## Utf8JsonReader(ReadOnlySpan&lt;byte&gt;, bool, JsonReaderState) {#utf8jsonreader-readonlyspan-byte-bool-jsonreaderstate}

**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L236)

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

```csharp
public Utf8JsonReader(ReadOnlySpan<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) and pass that back. |

### Remarks

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Utf8JsonReader(ReadOnlySpan&lt;byte&gt;, JsonReaderOptions) {#utf8jsonreader-readonlyspan-byte-jsonreaderoptions}

**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L288)

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

```csharp
public Utf8JsonReader(ReadOnlySpan<byte> jsonData, JsonReaderOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The ReadOnlySpan<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Defines the customized behavior of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

### Remarks

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](/api/corvus-text-json-utf8jsonreader.html#isfinalblock)= true)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Utf8JsonReader(ReadOnlySequence&lt;byte&gt;, bool, JsonReaderState) {#utf8jsonreader-readonlysequence-byte-bool-jsonreaderstate}

**Source:** [Utf8JsonReader.MultiSegment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.MultiSegment.cs#L32)

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

```csharp
public Utf8JsonReader(ReadOnlySequence<byte> jsonData, bool isFinalBlock, JsonReaderState state)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `isFinalBlock` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | True when the input span contains the entire data to process. Set to false only if it is known that the input span contains partial data with more data to follow. |
| `state` | [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) | If this is the first call to the ctor, pass in a default state. Otherwise, capture the state from the previous instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) and pass that back. |

### Remarks

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This is the reason why the ctor accepts a [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Utf8JsonReader(ReadOnlySequence&lt;byte&gt;, JsonReaderOptions) {#utf8jsonreader-readonlysequence-byte-jsonreaderoptions}

**Source:** [Utf8JsonReader.MultiSegment.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.MultiSegment.cs#L124)

Constructs a new [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) instance.

```csharp
public Utf8JsonReader(ReadOnlySequence<byte> jsonData, JsonReaderOptions options)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonData` | [`ReadOnlySequence<byte>`](https://learn.microsoft.com/dotnet/api/system.buffers.readonlysequence-1) | The ReadOnlySequence<byte> containing the UTF-8 encoded JSON text to process. |
| `options` | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Defines the customized behavior of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

### Remarks

Since this type is a ref struct, it is a stack-only type and all the limitations of ref structs apply to it. This assumes that the entire JSON payload is passed in (equivalent to [`IsFinalBlock`](/api/corvus-text-json-utf8jsonreader.html#isfinalblock)= true)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

