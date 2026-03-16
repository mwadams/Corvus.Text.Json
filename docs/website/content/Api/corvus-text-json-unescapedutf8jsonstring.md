---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf8JsonString — Corvus.Text.Json"
---
```csharp
public readonly struct UnescapedUtf8JsonString : IDisposable
```

Represents an Unescaped UTF-8 JSON string.

## Remarks

This may use a rented buffer to back the string, so it is disposable.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [UnescapedUtf8JsonString(ReadOnlyMemory&lt;byte&gt;, byte\[\])](/api/corvus-text-json-unescapedutf8jsonstring.ctor.html#unescapedutf8jsonstring-readonlymemory-byte-byte) | Initializes a new instance of the [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Memory](/api/corvus-text-json-unescapedutf8jsonstring.memory.html) | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the UTF-8 bytes as a read-only memory. |
| [Span](/api/corvus-text-json-unescapedutf8jsonstring.span.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the UTF-8 bytes as a read-only span. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-unescapedutf8jsonstring.dispose.html#dispose) | Disposes the unescaped UTF-8 JSON string, returning any rented array pool bytes. |
| [TakeOwnership(ref byte\[\])](/api/corvus-text-json-unescapedutf8jsonstring.takeownership.html#takeownership-ref-byte) | Take ownership of the [`ArrayPool`](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1.shared#arraypool) bytes, if any. |

