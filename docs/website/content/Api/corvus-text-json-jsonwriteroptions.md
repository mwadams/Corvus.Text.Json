---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions — Corvus.Text.Json"
---
```csharp
public readonly struct JsonWriterOptions
```

Provides the ability for the user to define custom behavior when writing JSON using the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html). By default, the JSON is written without any indentation or extra white space. Also, the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) will throw an exception if the user attempts to write structurally invalid JSON.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Encoder` | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping strings, or `null` to use the default encoder. |
| `IndentCharacter` | [`char`](https://learn.microsoft.com/dotnet/api/system.char) | Defines the indentation character used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) is enabled. Defaults to the s... |
| `Indented` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should pretty print the JSON which includes: indenting nested JSON tokens, adding new lines, and adding white space... |
| `IndentSize` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Defines the indentation size used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) is enabled. Defaults to two. |
| `MaxDepth` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the maximum depth allowed when writing JSON, with the default (i.e. 0) indicating a max depth of 1000. |
| `NewLine` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets or sets the new line string to use when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) is `true`. The default is the value of `NewLine`. |
| `SkipValidation` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any ... |

### IndentCharacter

```csharp
char IndentCharacter { get; set; }
```

Defines the indentation character used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) is enabled. Defaults to the space character.

Allowed characters are space and horizontal tab.

### IndentSize

```csharp
int IndentSize { get; set; }
```

Defines the indentation size used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html) is enabled. Defaults to two.

Allowed values are integers between 0 and 127, included.

### MaxDepth

```csharp
int MaxDepth { get; set; }
```

Gets or sets the maximum depth allowed when writing JSON, with the default (i.e. 0) indicating a max depth of 1000.

Reading past this depth will throw a .

### SkipValidation

```csharp
bool SkipValidation { get; set; }
```

Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any attempts to write invalid JSON will result in a to be thrown.

If the JSON being written is known to be correct, then skipping validation (by setting it to true) could improve performance. An example of invalid JSON where the writer will throw (when SkipValidation is set to false) is when you write a value within a JSON object without a property name.

