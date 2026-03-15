---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonPredicate<T> — Corvus.Text.Json"
---
```csharp
public delegate JsonPredicate<T> : MulticastDelegate, ICloneable, ISerializable
```

A predicate for a JSON value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON value. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

### JsonPredicate

```csharp
JsonPredicate(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

## Methods

### Invoke `virtual`

```csharp
bool Invoke(ref T item)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref T item, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

### EndInvoke `virtual`

```csharp
bool EndInvoke(ref T item, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `item` | `ref T` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

