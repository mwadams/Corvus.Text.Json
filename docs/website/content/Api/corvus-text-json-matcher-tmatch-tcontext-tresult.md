---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Matcher<TMatch, TContext, TResult> — Corvus.Text.Json"
---
```csharp
public delegate Matcher<TMatch, TContext, TResult> : MulticastDelegate, ICloneable, ISerializable
```

A callback for a pattern match method.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TMatch` | The type that was matched. |
| `TContext` | The context of the match. |
| `TResult` | The result of the match operation. |

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
TResult Invoke(ref TMatch match, ref TContext context)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |

**Returns:** `TResult`

### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(ref TMatch match, ref TContext context, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

### EndInvoke `virtual`

```csharp
TResult EndInvoke(ref TMatch match, ref TContext context, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `match` | `ref TMatch` |  |
| `context` | `ref TContext` |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

**Returns:** `TResult`

