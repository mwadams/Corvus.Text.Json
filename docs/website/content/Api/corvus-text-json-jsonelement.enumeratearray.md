---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.EnumerateArray Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## EnumerateArray {#enumeratearray}

```csharp
public ArrayEnumerator<JsonElement> EnumerateArray()
```

Get an enumerator to enumerate the values in the JSON array represented by this JsonElement.

### Returns

[`ArrayEnumerator<JsonElement>`](/api/corvus-text-json-arrayenumerator-titem.html)

An enumerator to enumerate the values in the JSON array represented by this JsonElement.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Array`](/api/corvus-text-json-jsonvaluekind.html#array). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

