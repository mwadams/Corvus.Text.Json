---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMessageProvider — Corvus.Text.Json"
---
```csharp
public delegate JsonSchemaMessageProvider : MulticastDelegate, ICloneable, ISerializable
```

Provides a message for a JSON Schema validation result.

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaMessageProvider(object, IntPtr)](/api/corvus-text-json-jsonschemamessageprovider.ctor.html#jsonschemamessageprovider-object-object-intptr-method) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(Span&lt;byte&gt;, ref int, AsyncCallback, object)](/api/corvus-text-json-jsonschemamessageprovider.begininvoke.html#iasyncresult-begininvoke-span-byte-buffer-ref-int-written-asynccallback-callback-object-object) |  |
| [EndInvoke(ref int, IAsyncResult)](/api/corvus-text-json-jsonschemamessageprovider.endinvoke.html#bool-endinvoke-ref-int-written-iasyncresult-result) |  |
| [Invoke(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-jsonschemamessageprovider.invoke.html#bool-invoke-span-byte-buffer-ref-int-written) |  |

