---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMessageProvider<TContext> — Corvus.Text.Json"
---
```csharp
public delegate JsonSchemaMessageProvider<TContext> : MulticastDelegate, ICloneable, ISerializable
```

Provides a message for a JSON Schema validation result, using a context value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TContext` | The type of the context value. |

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

### JsonSchemaMessageProvider

```csharp
JsonSchemaMessageProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

## Methods

### Invoke `virtual`

```csharp
bool Invoke(TContext context, Span<byte> buffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(TContext context, Span<byte> buffer, ref int written, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | `TContext` |  |
| `buffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

### EndInvoke `virtual`

```csharp
bool EndInvoke(ref int written, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

