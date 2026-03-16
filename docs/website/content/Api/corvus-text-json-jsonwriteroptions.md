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
| [Encoder](/api/corvus-text-json-jsonwriteroptions.encoder.html) | [`JavaScriptEncoder`](https://learn.microsoft.com/dotnet/api/system.text.encodings.web.javascriptencoder) | The encoder to use when escaping strings, or `null` to use the default encoder. |
| [IndentCharacter](/api/corvus-text-json-jsonwriteroptions.indentcharacter.html) | [`char`](https://learn.microsoft.com/dotnet/api/system.char) | Defines the indentation character used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is enabled. Defaults... |
| [Indented](/api/corvus-text-json-jsonwriteroptions.indented.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should pretty print the JSON which includes: indenting nested JSON tokens, adding new lines, and adding white space... |
| [IndentSize](/api/corvus-text-json-jsonwriteroptions.indentsize.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Defines the indentation size used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is enabled. Defaults to two. |
| [MaxDepth](/api/corvus-text-json-jsonwriteroptions.maxdepth.html) | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | Gets or sets the maximum depth allowed when writing JSON, with the default (i.e. 0) indicating a max depth of 1000. |
| [NewLine](/api/corvus-text-json-jsonwriteroptions.newline.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets or sets the new line string to use when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is `true`. The default is the value of \[`NewLine`\](https://learn.microsoft.com/dotne... |
| [SkipValidation](/api/corvus-text-json-jsonwriteroptions.skipvalidation.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Defines whether the [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) should skip structural validation and allow the user to write invalid JSON, when set to true. If set to false, any ... |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

