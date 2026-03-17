---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonReaderOptions.MaxDepth Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonReaderOptions.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/JsonReaderOptions.cs#L77)

## MaxDepth {#maxdepth}

Gets or sets the maximum depth allowed when reading JSON, with the default (i.e. 0) indicating a max depth of 64.

```csharp
public int MaxDepth { get; set; }
```

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentOutOfRangeException`](https://learn.microsoft.com/dotnet/api/system.argumentoutofrangeexception) | Thrown when the max depth is set to a negative value. |

### Remarks

Reading past this depth will throw a [`JsonException`](/api/corvus-text-json-jsonexception.html).

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

