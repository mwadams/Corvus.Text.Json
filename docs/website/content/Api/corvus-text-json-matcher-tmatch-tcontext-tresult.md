---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Matcher<TMatch, TContext, TResult> — Corvus.Text.Json"
---
```csharp
public delegate Matcher<TMatch, TContext, TResult> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TContext` | The context of the match. |
| `TResult` | The result of the match operation. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [Matcher(object, IntPtr)](/api/corvus-text-json-matcher-tmatch-tcontext-tresult.ctor.html#matcher-object-intptr) |  |

## Methods

| Method | Description |
|--------|-------------|
| [BeginInvoke(ref TMatch, ref TContext, AsyncCallback, object)](/api/corvus-text-json-matcher-tmatch-tcontext-tresult.begininvoke.html#begininvoke-ref-tmatch-ref-tcontext-asynccallback-object) |  |
| [EndInvoke(ref TMatch, ref TContext, IAsyncResult)](/api/corvus-text-json-matcher-tmatch-tcontext-tresult.endinvoke.html#endinvoke-ref-tmatch-ref-tcontext-iasyncresult) |  |
| [Invoke(ref TMatch, ref TContext)](/api/corvus-text-json-matcher-tmatch-tcontext-tresult.invoke.html#invoke-ref-tmatch-ref-tcontext) |  |

