---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaMatcherWithRequiredBitBuffer — Corvus.Text.Json.Internal"
---
```csharp
public delegate JsonSchemaMatcherWithRequiredBitBuffer : MulticastDelegate, ICloneable, ISerializable
```

A matcher for a JSON schema that requires a bit buffer for tracking required properties.

## Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

### JsonSchemaMatcherWithRequiredBitBuffer

```csharp
JsonSchemaMatcherWithRequiredBitBuffer(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

## Methods

### Invoke `virtual`

```csharp
void Invoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `requiredBitBuffer` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |

### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(IJsonDocument parentDocument, int parentDocumentIndex, ref JsonSchemaContext context, Span<int> requiredBitBuffer, AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) |  |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `requiredBitBuffer` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

### EndInvoke `virtual`

```csharp
void EndInvoke(ref JsonSchemaContext context, IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | [`ref JsonSchemaContext`](/api/corvus-text-json-internal-jsonschemacontext.html) |  |
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

