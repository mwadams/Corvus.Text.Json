---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.ValueIsEscaped Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L160)

## ValueIsEscaped {#valueisescaped}

Lets the caller know whether the current [`ValueSpan`](/api/corvus-text-json-utf8jsonreader.html#valuespan) or [`ValueSequence`](/api/corvus-text-json-utf8jsonreader.html#valuesequence) properties contain escape sequences per RFC 8259 section 7, and therefore require unescaping before being consumed.

```csharp
public bool ValueIsEscaped { get; set; }
```

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

