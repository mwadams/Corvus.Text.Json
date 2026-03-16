---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderState Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## JsonReaderState {#jsonreaderstate}

```csharp
JsonReaderState(JsonReaderOptions options)
```

Constructs a new [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) instance.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `options` | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Defines the customized behavior of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that is different from the JSON RFC (for example how to handle comments or maximum depth allowed when reading). By default, the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) follows the JSON RFC strictly (i.e. comments within the JSON are invalid) and reads up to a maximum depth of 64. *(optional)* |

### Remarks

An instance of this state must be passed to the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) ctor with the JSON data. Unlike the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html), which is a ref struct, the state can survive across async/await boundaries and hence this type is required to provide support for reading in more data asynchronously before continuing with a new instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html).

