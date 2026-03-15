---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "RentedBacking — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct RentedBacking : IDisposable
```

Provides a fixed-size, rented backing structure for storing longer string values that will not fit in a [`SimpleTypesBacking`](/api/corvus-text-json-internal-simpletypesbacking.html).

## Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Methods

### Initialize `static`

```csharp
void Initialize<T>(ref RentedBacking backing, int minimumLength, ref T value, RentedBacking.Writer<T> writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `backing` | [`ref RentedBacking`](/api/corvus-text-json-internal-rentedbacking.html) |  |
| `minimumLength` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `value` | `ref T` |  |
| `writer` | `RentedBacking.Writer<T>` |  |

### Dispose

```csharp
void Dispose()
```

### Span

```csharp
ReadOnlySpan<byte> Span()
```

Gets the written value as a span

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The written value.


### RentedBacking.Writer<T> (delegate)

```csharp
public delegate RentedBacking.Writer<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### RentedBacking.Writer

```csharp
RentedBacking.Writer(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

#### Methods

##### Invoke `virtual`

```csharp
void Invoke(T value, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(T value, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

##### EndInvoke `virtual`

```csharp
void EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

---

