---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonDocumentBuilder<T>.RootElement Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## RootElement {#rootelement}

```csharp
T RootElement { get; }
```

Gets the root element of the JSON document.

### Returns

`T`

### Property Value

`T`

The mutable root element of the document.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | Thrown when the document has been disposed. |

