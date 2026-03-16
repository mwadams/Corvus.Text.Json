---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.IndentCharacter Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## IndentCharacter {#indentcharacter}

```csharp
public char IndentCharacter { get; set; }
```

Defines the indentation character used by [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is enabled. Defaults to the space character.

### Returns

[`char`](https://learn.microsoft.com/dotnet/api/system.char)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | `value` contains an invalid character. |

### Remarks

Allowed characters are space and horizontal tab.

