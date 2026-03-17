---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RawUtf8JsonString — Corvus.Text.Json"
---
```csharp
public readonly struct RawUtf8JsonString : IDisposable
```

Represents a raw UTF-8 JSON string.

## Remarks

This may use a rented buffer to back the string, so it is disposable.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [RawUtf8JsonString(ReadOnlyMemory&lt;byte&gt;, byte\[\])](/api/corvus-text-json-rawutf8jsonstring.ctor.html#rawutf8jsonstring-readonlymemory-byte-byte) | Initializes a new instance of the [`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Memory](/api/corvus-text-json-rawutf8jsonstring.memory.html) | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the underlying UTF-8 bytes as a [`ReadOnlyMemory`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1). |
| [Span](/api/corvus-text-json-rawutf8jsonstring.span.html) | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the underlying UTF-8 bytes as a [`ReadOnlySpan`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1). |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-rawutf8jsonstring.dispose.html#dispose) | Releases any rented array pool bytes and clears sensitive data. |
| [TakeOwnership(ref byte\[\])](/api/corvus-text-json-rawutf8jsonstring.takeownership.html#takeownership-ref-byte) | Takes ownership of the underlying memory and any extra rented array pool bytes. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

