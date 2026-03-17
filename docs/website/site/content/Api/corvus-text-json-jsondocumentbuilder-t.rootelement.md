---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentBuilder<T>.RootElement Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonDocumentBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonDocumentBuilder.cs#L65)

## RootElement {#rootelement}

Gets the root element of the JSON document.

```csharp
public T RootElement { get; }
```

### Returns

`T`

### Property Value

`T`

The mutable root element of the document.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | Thrown when the document has been disposed. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

