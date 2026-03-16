---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMessageProvider<TContext> — Corvus.Text.Json"
---
```csharp
public delegate JsonSchemaMessageProvider<TContext> : MulticastDelegate, ICloneable, ISerializable
```

Provides a message for a JSON Schema validation result, using a context value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TContext` | The type of the context value. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaMessageProvider(object, IntPtr)](/api/corvus-text-json-jsonschemamessageprovider-tcontext.ctor.html#jsonschemamessageprovider-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(TContext, Span&lt;byte&gt;, ref int, AsyncCallback, object)](/api/corvus-text-json-jsonschemamessageprovider-tcontext.begininvoke.html#begininvoke-tcontext-span-byte-ref-int-asynccallback-object) |  |
| [EndInvoke(ref int, IAsyncResult)](/api/corvus-text-json-jsonschemamessageprovider-tcontext.endinvoke.html#endinvoke-ref-int-iasyncresult) |  |
| [Invoke(TContext, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-jsonschemamessageprovider-tcontext.invoke.html#invoke-tcontext-span-byte-ref-int) |  |

