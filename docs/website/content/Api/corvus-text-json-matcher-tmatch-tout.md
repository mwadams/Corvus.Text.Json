---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Matcher<TMatch, TOut> — Corvus.Text.Json"
---
```csharp
public delegate Matcher<TMatch, TOut> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TOut` | The result of the match operation. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [Matcher(object, IntPtr)](/api/corvus-text-json-matcher-tmatch-tout.ctor.html#matcher-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(ref TMatch, AsyncCallback, object)](/api/corvus-text-json-matcher-tmatch-tout.begininvoke.html#begininvoke-ref-tmatch-asynccallback-object) |  |
| [EndInvoke(ref TMatch, IAsyncResult)](/api/corvus-text-json-matcher-tmatch-tout.endinvoke.html#endinvoke-ref-tmatch-iasyncresult) |  |
| [Invoke(ref TMatch)](/api/corvus-text-json-matcher-tmatch-tout.invoke.html#invoke-ref-tmatch) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

