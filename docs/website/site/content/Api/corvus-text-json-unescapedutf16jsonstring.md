---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf16JsonString — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [UnescapedUtf16JsonString.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/UnescapedUtf16JsonString.cs#L20)

Represents an Unescaped UTF-16 JSON string.

```csharp
public readonly struct UnescapedUtf16JsonString : IDisposable
```

## Remarks

This uses a rented buffer to back the string, so it is disposable.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Constructors

| Constructor | Description |
|-------------|-------------|
| [UnescapedUtf16JsonString(ReadOnlyMemory&lt;char&gt;, char\[\])](/api/corvus-text-json-unescapedutf16jsonstring.ctor.html#unescapedutf16jsonstring-readonlymemory-char-char) | Initializes a new instance of the [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) struct. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Memory](/api/corvus-text-json-unescapedutf16jsonstring.memory.html) | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the UTF-16 characters as a read-only memory. |
| [Span](/api/corvus-text-json-unescapedutf16jsonstring.span.html) | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the UTF-16 characters as a read-only span. |

## Methods

| Method | Description |
|--------|-------------|
| [Dispose()](/api/corvus-text-json-unescapedutf16jsonstring.dispose.html#dispose) | Disposes the unescaped UTF-16 JSON string, returning any rented array pool characters. |
| [TakeOwnership(ref char\[\])](/api/corvus-text-json-unescapedutf16jsonstring.takeownership.html#takeownership-ref-char) | Take ownership of the [`ArrayPool`](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1.shared#arraypool) characters, if any. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

