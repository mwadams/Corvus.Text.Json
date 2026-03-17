---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.IndentCharacter Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWriterOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/JsonWriterOptions.cs#L53)

## IndentCharacter {#indentcharacter}

Defines the indentation character used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is enabled. Defaults to the space character.

```csharp
public char IndentCharacter { get; set; }
```

### Returns

[`char`](https://learn.microsoft.com/dotnet/api/system.char)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `value` contains an invalid character. |

### Remarks

Allowed characters are space and horizontal tab.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

