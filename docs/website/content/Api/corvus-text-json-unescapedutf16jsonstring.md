---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UnescapedUtf16JsonString — Corvus.Text.Json"
---
```csharp
public readonly struct UnescapedUtf16JsonString : IDisposable
```

Represents an Unescaped UTF-16 JSON string.

## Remarks

This uses a rented buffer to back the string, so it is disposable.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Constructors

### UnescapedUtf16JsonString

```csharp
UnescapedUtf16JsonString(ReadOnlyMemory<char> chars, char[] extraRentedArrayPoolChars)
```

Initializes a new instance of the [`UnescapedUtf16JsonString`](/api/corvus-text-json-unescapedutf16jsonstring.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `chars` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-16 characters representing the JSON string. |
| `extraRentedArrayPoolChars` | [`char[]`](https://learn.microsoft.com/dotnet/api/system.char) | Optional rented array pool characters. *(optional)* |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the UTF-16 characters as a read-only memory. |
| `Span` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the UTF-16 characters as a read-only span. |

## Methods

### TakeOwnership

```csharp
ReadOnlyMemory<char> TakeOwnership(ref char[] extraRentedArrayPoolChars)
```

Take ownership of the `Shared` characters, if any.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolChars` | [`ref char[]`](https://learn.microsoft.com/dotnet/api/system.char) | The rented characters, or null if there are no rented characters. |

**Returns:** [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The UTF-16 memory representing the rented characters.

### Dispose

```csharp
void Dispose()
```

Disposes the unescaped UTF-16 JSON string, returning any rented array pool characters.

