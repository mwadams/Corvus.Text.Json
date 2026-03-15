---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonPredicate<T> — Corvus.Text.Json"
---
```csharp
public delegate JsonPredicate<T> : MulticastDelegate, ICloneable, ISerializable
```

A predicate for a JSON value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON value. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonPredicate(object, IntPtr)](/api/corvus-text-json-jsonpredicate-t.ctor.html#jsonpredicate-object-object-intptr-method) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(ref T, AsyncCallback, object)](/api/corvus-text-json-jsonpredicate-t.begininvoke.html#iasyncresult-begininvoke-ref-t-item-asynccallback-callback-object-object) |  |
| [EndInvoke(ref T, IAsyncResult)](/api/corvus-text-json-jsonpredicate-t.endinvoke.html#bool-endinvoke-ref-t-item-iasyncresult-result) |  |
| [Invoke(ref T)](/api/corvus-text-json-jsonpredicate-t.invoke.html#bool-invoke-ref-t-item) |  |

