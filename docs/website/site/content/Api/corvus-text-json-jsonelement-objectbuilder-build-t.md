---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.Build<T> — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.ObjectBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.ObjectBuilder.cs#L49)

```csharp
public delegate JsonElement.ObjectBuilder.Build<T> : MulticastDelegate, ICloneable, ISerializable
```

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [JsonElement.ObjectBuilder.Build(object, IntPtr)](/api/corvus-text-json-jsonelement-objectbuilder-build-t.ctor.html#jsonelement-objectbuilder-build-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(ref T, ref JsonElement.ObjectBuilder, AsyncCallback, object)](/api/corvus-text-json-jsonelement-objectbuilder-build-t.begininvoke.html#begininvoke-ref-t-ref-jsonelement-objectbuilder-asynccallback-object) |  |
| [EndInvoke(ref T, ref JsonElement.ObjectBuilder, IAsyncResult)](/api/corvus-text-json-jsonelement-objectbuilder-build-t.endinvoke.html#endinvoke-ref-t-ref-jsonelement-objectbuilder-iasyncresult) |  |
| [Invoke(ref T, ref JsonElement.ObjectBuilder)](/api/corvus-text-json-jsonelement-objectbuilder-build-t.invoke.html#invoke-ref-t-ref-jsonelement-objectbuilder) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

