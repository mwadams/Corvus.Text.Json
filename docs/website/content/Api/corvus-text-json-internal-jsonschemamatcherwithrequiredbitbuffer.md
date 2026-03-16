---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMatcherWithRequiredBitBuffer — Corvus.Text.Json.Internal"
---
```csharp
public delegate JsonSchemaMatcherWithRequiredBitBuffer : MulticastDelegate, ICloneable, ISerializable
```

A matcher for a JSON schema that requires a bit buffer for tracking required properties.

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaMatcherWithRequiredBitBuffer(object, IntPtr)](/api/corvus-text-json-internal-jsonschemamatcherwithrequiredbitbuffer.ctor.html#jsonschemamatcherwithrequiredbitbuffer-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(IJsonDocument, int, ref JsonSchemaContext, Span&lt;int&gt;, AsyncCallback, object)](/api/corvus-text-json-internal-jsonschemamatcherwithrequiredbitbuffer.begininvoke.html#begininvoke-ijsondocument-int-ref-jsonschemacontext-span-int-asynccallback-object) |  |
| [EndInvoke(ref JsonSchemaContext, IAsyncResult)](/api/corvus-text-json-internal-jsonschemamatcherwithrequiredbitbuffer.endinvoke.html#endinvoke-ref-jsonschemacontext-iasyncresult) |  |
| [Invoke(IJsonDocument, int, ref JsonSchemaContext, Span&lt;int&gt;)](/api/corvus-text-json-internal-jsonschemamatcherwithrequiredbitbuffer.invoke.html#invoke-ijsondocument-int-ref-jsonschemacontext-span-int) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

