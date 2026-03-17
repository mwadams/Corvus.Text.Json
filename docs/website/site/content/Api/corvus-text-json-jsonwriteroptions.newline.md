---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonWriterOptions.NewLine Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonWriterOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/JsonWriterOptions.cs#L135)

## NewLine {#newline}

Gets or sets the new line string to use when [`Indented`](/api/corvus-text-json-jsonwriteroptions.html#indented) is `true`. The default is the value of [`NewLine`](https://learn.microsoft.com/dotnet/api/system.environment.newline#newline).

```csharp
public string NewLine { get; set; }
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the new line string is `null`. |
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when the new line string is not `\n` or `\r\n`. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

