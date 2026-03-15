---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "SimpleTypesBacking — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct SimpleTypesBacking
```

Provides a fixed-size backing structure for storing simple numeric, null and boolean values. for [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) creation.

## Remarks

This is typically used as a backing field in a `[MyJsonElementType].Builder.Source` struct.

## Methods

### Initialize `static`

```csharp
void Initialize<T>(ref SimpleTypesBacking backing, ref T value, SimpleTypesBacking.Writer<T> writer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `backing` | [`ref SimpleTypesBacking`](/api/corvus-text-json-internal-simpletypesbacking.html) |  |
| `value` | `ref T` |  |
| `writer` | `SimpleTypesBacking.Writer<T>` |  |

### Span

```csharp
ReadOnlySpan<byte> Span()
```

Gets the written value as a span

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The written value.


### SimpleTypesBacking.Writer<T> (delegate)

```csharp
public delegate SimpleTypesBacking.Writer<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### SimpleTypesBacking.Writer

```csharp
SimpleTypesBacking.Writer(object object, IntPtr method)
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

