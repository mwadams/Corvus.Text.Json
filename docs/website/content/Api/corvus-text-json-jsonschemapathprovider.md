---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaPathProvider — Corvus.Text.Json"
---
```csharp
public delegate JsonSchemaPathProvider : MulticastDelegate, ICloneable, ISerializable
```

Provides a path segment for a JSON Schema location or instance path.

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaPathProvider(object, IntPtr)](/api/corvus-text-json-jsonschemapathprovider.ctor.html#jsonschemapathprovider-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(Span&lt;byte&gt;, ref int, AsyncCallback, object)](/api/corvus-text-json-jsonschemapathprovider.begininvoke.html#begininvoke-span-byte-ref-int-asynccallback-object) |  |
| [EndInvoke(ref int, IAsyncResult)](/api/corvus-text-json-jsonschemapathprovider.endinvoke.html#endinvoke-ref-int-iasyncresult) |  |
| [Invoke(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-jsonschemapathprovider.invoke.html#invoke-span-byte-ref-int) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

