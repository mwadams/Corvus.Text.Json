---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteNullValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [Utf8JsonWriter.WriteValues.Literal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Literal.cs#L47)

## WriteNullValue {#writenullvalue}

Writes the JSON literal "null" as an element of a JSON array.

```csharp
public void WriteNullValue()
```

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

