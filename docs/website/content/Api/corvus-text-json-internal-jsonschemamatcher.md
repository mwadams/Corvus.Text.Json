---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMatcher — Corvus.Text.Json.Internal"
---
```csharp
public delegate JsonSchemaMatcher : MulticastDelegate, ICloneable, ISerializable
```

A matcher for a JSON schema.

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaMatcher(object, IntPtr)](/api/corvus-text-json-internal-jsonschemamatcher.ctor.html#jsonschemamatcher-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(IJsonDocument, int, ref JsonSchemaContext, AsyncCallback, object)](/api/corvus-text-json-internal-jsonschemamatcher.begininvoke.html#begininvoke-ijsondocument-int-ref-jsonschemacontext-asynccallback-object) |  |
| [EndInvoke(ref JsonSchemaContext, IAsyncResult)](/api/corvus-text-json-internal-jsonschemamatcher.endinvoke.html#endinvoke-ref-jsonschemacontext-iasyncresult) |  |
| [Invoke(IJsonDocument, int, ref JsonSchemaContext)](/api/corvus-text-json-internal-jsonschemamatcher.invoke.html#invoke-ijsondocument-int-ref-jsonschemacontext) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

