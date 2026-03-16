---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.EnumerateObject Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## EnumerateObject {#enumerateobject}

```csharp
public ObjectEnumerator<JsonElement> EnumerateObject()
```

Get an enumerator to enumerate the properties in the JSON object represented by this JsonElement.

### Returns

[`ObjectEnumerator<JsonElement>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An enumerator to enumerate the properties in the JSON object represented by this JsonElement.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`Object`](/api/corvus-text-json-jsonvaluekind.html#object). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

