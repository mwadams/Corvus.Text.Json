---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderState.Options Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonReaderState.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/JsonReaderState.cs#L101)

## Options {#options}

Gets the custom behavior when reading JSON using the [`Utf8JsonReader`](/api/corvus-text-json-utf8jsonreader.html) that may deviate from strict adherence to the JSON specification, which is the default behavior.

```csharp
public JsonReaderOptions Options { get; }
```

### Returns

[`JsonReaderOptions`](/api/corvus-text-json-jsonreaderoptions.html)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

