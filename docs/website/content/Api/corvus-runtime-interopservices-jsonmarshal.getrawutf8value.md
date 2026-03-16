---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonMarshal.GetRawUtf8Value Method — Corvus.Runtime.InteropServices"
---
## Definition

**Namespace:** Corvus.Runtime.InteropServices  
**Assembly:** Corvus.Text.Json.dll

## GetRawUtf8Value {#getrawutf8value}

```csharp
public static RawUtf8JsonString GetRawUtf8Value<T>(T element)
```

Gets a [`ReadOnlySpan`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) view over the raw JSON data of the given JSON element.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html). |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` | The JSON element from which to extract the span. |

### Returns

[`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html)

The span containing the raw JSON data of`element`.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

While the method itself does check for disposal of the underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html), it is possible that it could be disposed after the method returns, which would result in the span pointing to a buffer that has been returned to the shared pool. Callers should take extra care to make sure that such a scenario isn't possible to avoid potential data corruption.

