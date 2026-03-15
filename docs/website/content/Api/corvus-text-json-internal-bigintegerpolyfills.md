---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigIntegerPolyfills — Corvus.Text.Json.Internal"
---
```csharp
public static class BigIntegerPolyfills
```

Polyfills for `BigInteger` methods that are not available in all target frameworks.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **BigIntegerPolyfills**

## Methods

### TryGetMinimumFormatBufferLength `static`

```csharp
bool TryGetMinimumFormatBufferLength(ref BigInteger bigInteger, ref int minimumLength)
```

Gets the minimum format buffer length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `bigInteger` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The value for which to get the format buffer length. |
| `minimumLength` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The minimum length for a text buffer to format the number. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the buffer length required for the number can be safely allocated.

### TryFormat `static`

```csharp
bool TryFormat(ref BigInteger value, Span<byte> destination, ref int bytesWritten)
```

Tries to format the value of the current `BigInteger` instance into the provided span of bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) | The value to format. |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The span in which to write the formatted value as UTF-8. |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the number of bytes that were written to the destination. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the operation was successful; otherwise, `false`.

### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> segment, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `segment` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)


### BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A (class)

```csharp
public sealed class BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A
```

#### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A**

#### Methods

##### TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> segment, ref BigInteger value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `segment` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `value` | [`ref BigInteger`](https://learn.microsoft.com/dotnet/api/system.numerics.biginteger) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

#### Nested Types

#### BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A.<M>$AF85D49F289E4CC5D0A674052B53552E (class)

```csharp
public static class BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A.<M>$AF85D49F289E4CC5D0A674052B53552E
```

##### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **BigIntegerPolyfills.<G>$9CFAEDA43E3429DBE35978030E0B8E1A.<M>$AF85D49F289E4CC5D0A674052B53552E**

---

---

