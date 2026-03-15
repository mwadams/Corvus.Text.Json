---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UniqueItemsHashSet — Corvus.Text.Json.Internal"
---
```csharp
public readonly struct UniqueItemsHashSet : IDisposable
```

A map that can be built

## Remarks

This class uses a hash-based approach to enable O(1) average-case lookups of property matchers based on property names, while minimizing memory usage through array pooling and efficient data layout. The implementation includes a custom hash function, separate chaining for collision resolution, and optimized key comparison strategies to ensure fast lookups even in the presence of hash collisions.

## Implements

[`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Constructors

### UniqueItemsHashSet

```csharp
UniqueItemsHashSet(IJsonDocument parentDocument, int itemsCount, Span<int> buckets, Span<byte> entries)
```

Creates a validator map for efficient property lookup based on the provided matchers.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document for the unique items map. |
| `itemsCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of items to be added to the map. |
| `buckets` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `entries` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A working buffer for the buckets. |

## Methods

### AddItemIfNotExists

```csharp
bool AddItemIfNotExists(int parentDocumentIndex)
```

Adds the item identified by the parent document index to the map if it does not already exist, returning true if it was added and false if it already existed.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value in the document. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetHashCode

```csharp
int GetHashCode(int documentIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `documentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### ValueEquals

```csharp
bool ValueEquals(int leftIndex, int rightIndex)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `leftIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `rightIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Dispose

```csharp
void Dispose()
```

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `StackAllocBucketSize` `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The recommended size for a stack allocated bucket buffer. |
| `StackAllocEntrySize` `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The recommended size for a stack allocated entries buffer. |


### UniqueItemsHashSet.UnescapedNameProvider (delegate)

```csharp
public delegate UniqueItemsHashSet.UnescapedNameProvider : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### UniqueItemsHashSet.UnescapedNameProvider

```csharp
UniqueItemsHashSet.UnescapedNameProvider(object object, IntPtr method)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |
| `method` | [`IntPtr`](https://learn.microsoft.com/dotnet/api/system.intptr) |  |

#### Methods

##### Invoke `virtual`

```csharp
ReadOnlySpan<byte> Invoke()
```

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

##### BeginInvoke `virtual`

```csharp
IAsyncResult BeginInvoke(AsyncCallback callback, object object)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `callback` | [`AsyncCallback`](https://learn.microsoft.com/dotnet/api/system.asynccallback) |  |
| `object` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult)

##### EndInvoke `virtual`

```csharp
ReadOnlySpan<byte> EndInvoke(IAsyncResult result)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `result` | [`IAsyncResult`](https://learn.microsoft.com/dotnet/api/system.iasyncresult) |  |

**Returns:** [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

---

