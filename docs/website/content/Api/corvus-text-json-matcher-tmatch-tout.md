---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Matcher<TMatch, TOut> — Corvus.Text.Json"
---
```csharp
public delegate Matcher<TMatch, TOut> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TOut` | The result of the match operation. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

### Matcher

```csharp
Matcher(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

## Methods

### Invoke `virtual`

```csharp
TOut Invoke(ref TMatch match)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |

**Returns:** `TOut`

### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TMatch match, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

### EndInvoke `virtual`

```csharp
TOut EndInvoke(ref TMatch match, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

**Returns:** `TOut`

