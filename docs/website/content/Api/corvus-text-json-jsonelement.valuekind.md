---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ValueKind Property — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## ValueKind {#valuekind}

```csharp
public JsonValueKind ValueKind { get; }
```

The [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html) that the value is.

### Returns

[`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html)

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Implements

[`IJsonElement.ValueKind`](/api/corvus-text-json-internal-ijsonelement.valuekind.html)

