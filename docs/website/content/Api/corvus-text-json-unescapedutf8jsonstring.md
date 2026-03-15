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

### UnescapedUtf8JsonString

```csharp
UnescapedUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

Initializes a new instance of the [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | Optional rented array pool bytes. *(optional)* |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the UTF-8 bytes as a read-only memory. |
| `Span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the UTF-8 bytes as a read-only span. |

## Methods

### TakeOwnership

```csharp
ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

Take ownership of the `Shared` bytes, if any.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | The rented bytes, or null if there are no rented bytes. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The UTF-8 memory representing the rented bytes.

### Dispose

```csharp
void Dispose()
```

Disposes the unescaped UTF-8 JSON string, returning any rented array pool bytes.

