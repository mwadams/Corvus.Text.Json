---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderState — Corvus.Text.Json"
---
```csharp
public readonly struct JsonReaderState
```

Defines an opaque type that holds and saves all the relevant state information which must be provided to the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) to continue reading after processing incomplete data. This type is required to support reentrancy when reading incomplete data, and to continue reading once more data is available. Unlike the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html), which is a ref struct, this type can survive across async/await boundaries and hence this type is required to provide support for reading in more data asynchronously before continuing with a new instance of the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html).

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonReaderState(JsonReaderOptions)](/api/corvus-text-json-jsonreaderstate.ctor.html#jsonreaderstate-jsonreaderoptions-options) | Constructs a new [`JsonReaderState`](/api/corvus-text-json-jsonreaderstate.html) instance. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Options](/api/corvus-text-json-jsonreaderstate.options.html) | [`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html) | Gets the custom behavior when reading JSON using the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that may deviate from strict adherence to the JSON specification, which is the def... |

