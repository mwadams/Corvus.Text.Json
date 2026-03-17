---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMessageProvider — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonSchemaResultsCollector.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/IJsonSchemaResultsCollector.cs#L23)

Provides a message for a JSON Schema validation result.

```csharp
public delegate JsonSchemaMessageProvider : MulticastDelegate, ICloneable, ISerializable
```

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonSchemaMessageProvider(object, IntPtr)](/api/corvus-text-json-jsonschemamessageprovider.ctor.html#jsonschemamessageprovider-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(Span&lt;byte&gt;, ref int, AsyncCallback, object)](/api/corvus-text-json-jsonschemamessageprovider.begininvoke.html#begininvoke-span-byte-ref-int-asynccallback-object) |  |
| [EndInvoke(ref int, IAsyncResult)](/api/corvus-text-json-jsonschemamessageprovider.endinvoke.html#endinvoke-ref-int-iasyncresult) |  |
| [Invoke(Span&lt;byte&gt;, ref int)](/api/corvus-text-json-jsonschemamessageprovider.invoke.html#invoke-span-byte-ref-int) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

