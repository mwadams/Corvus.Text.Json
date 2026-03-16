---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaPathProvider<TContext> — Corvus.Text.Json"
---
```csharp
public delegate JsonSchemaPathProvider<TContext> : MulticastDelegate, ICloneable, ISerializable
```

Provides a path segment for a JSON Schema location or instance path, using a context value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TContext` | The type of the context value. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaPathProvider(object, IntPtr)](/api/corvus-text-json-jsonschemapathprovider-tcontext.ctor.html#jsonschemapathprovider-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(TContext, Span&lt;byte&gt;, ref int, AsyncCallback, object)](/api/corvus-text-json-jsonschemapathprovider-tcontext.begininvoke.html#begininvoke-tcontext-span-byte-ref-int-asynccallback-object) |  |
| [EndInvoke(ref int, IAsyncResult)](/api/corvus-text-json-jsonschemapathprovider-tcontext.endinvoke.html#endinvoke-ref-int-iasyncresult) |  |
| [Invoke(TContext, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-jsonschemapathprovider-tcontext.invoke.html#invoke-tcontext-span-byte-ref-int) |  |

