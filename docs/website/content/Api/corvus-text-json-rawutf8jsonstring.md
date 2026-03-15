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

### RawUtf8JsonString

```csharp
RawUtf8JsonString(ReadOnlyMemory<byte> utf8Bytes, byte[] extraRentedArrayPoolBytes)
```

Initializes a new instance of the [`RawUtf8JsonString`](/api/corvus-text-json-rawutf8jsonstring.html) struct.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Bytes` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The UTF-8 bytes representing the JSON string. |
| `extraRentedArrayPoolBytes` | [`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | Additional rented bytes from the array pool, if any. *(optional)* |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Memory` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | Gets the underlying UTF-8 bytes as a `ReadOnlyMemory`. |
| `Span` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | Gets the underlying UTF-8 bytes as a `ReadOnlySpan`. |

## Methods

### TakeOwnership

```csharp
ReadOnlyMemory<byte> TakeOwnership(ref byte[] extraRentedArrayPoolBytes)
```

Takes ownership of the underlying memory and any extra rented array pool bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `extraRentedArrayPoolBytes` | [`ref byte[]`](https://learn.microsoft.com/dotnet/api/system.byte) | When this method returns, contains the extra rented array pool bytes, if any. |

**Returns:** [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The underlying UTF-8 bytes memory.

### Dispose

```csharp
void Dispose()
```

Releases any rented array pool bytes and clears sensitive data.

