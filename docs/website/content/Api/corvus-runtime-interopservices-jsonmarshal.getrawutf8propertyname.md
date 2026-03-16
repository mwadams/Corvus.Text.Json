---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonMarshal.GetRawUtf8PropertyName Method — Corvus.Runtime.InteropServices"
---
## Definition

**Namespace:** Corvus.Runtime.InteropServices  
**Assembly:** Corvus.Text.Json.dll

## GetRawUtf8PropertyName {#getrawutf8propertyname}

```csharp
public static ReadOnlySpan<byte> GetRawUtf8PropertyName<T>(JsonProperty<T> property)
```

Gets a [`ReadOnlySpan`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) view over the raw JSON data of the given `JsonProperty` name.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `property` | [`JsonProperty<T>`](/api/corvus-text-json-jsonproperty-tvalue.html) | The JSON property from which to extract the span. |

### Returns

[`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The span containing the raw JSON data of the `property` name. This will not include the enclosing quotes.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

While the method itself does check for disposal of the underlying [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html), it is possible that it could be disposed after the method returns, which would result in the span pointing to a buffer that has been returned to the shared pool. Callers should take extra care to make sure that such a scenario isn't possible to avoid potential data corruption.

