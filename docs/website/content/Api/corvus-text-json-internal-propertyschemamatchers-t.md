---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PropertySchemaMatchers<T> — Corvus.Text.Json.Internal"
---
```csharp
public class PropertySchemaMatchers<T>
```

A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance.

## Remarks

This class uses a hash-based approach to enable O(1) average-case lookups of property matchers based on property names, while minimizing memory usage through array pooling and efficient data layout. The implementation includes a custom hash function, separate chaining for collision resolution, and optimized key comparison strategies to ensure fast lookups even in the presence of hash collisions.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **PropertySchemaMatchers<T>**

## Constructors

### PropertySchemaMatchers

```csharp
PropertySchemaMatchers(List<ValueTuple<PropertySchemaMatchers<T>.UnescapedNameProvider<T>, T>> matchers)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `matchers` | [`List<ValueTuple<PropertySchemaMatchers<T>.UnescapedNameProvider<T>, T>>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.list-1) |  |

## Methods

### TryGetNamedMatcher

```csharp
bool TryGetNamedMatcher(ReadOnlySpan<byte> unescapedUtf8Name, ref T matcher)
```

Attempts to find the matcher for the named property value in the property map using efficient hash-based lookup.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unescapedUtf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped UTF-8 property name to search for. |
| `matcher` | `ref T` | When this method returns, contains the matcher, otherwise null. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found; otherwise, `false`.

This method implements an efficient hash table lookup algorithm for property names in JSON objects. The lookup process follows these steps: 1. **Property Map Loading**: Reads the PropertyMap structure from the backing buffer to get metadata including bucket and entry offsets, counts, and sizes. 2. **Hash Calculation**: Computes a hash code for the target property name using an optimized algorithm that varies based on the property name length for maximum distribution. 3. **Bucket Selection**: Uses modulo operation to map the hash code to a specific bucket in the hash table, providing O(1) initial access. 4. **Chain Traversal**: Follows the linked chain of entries in the selected bucket: - Bucket values are 1-based, so the initial index is decremented - Each entry contains a Next field pointing to the next entry in the collision chain - Bounds checking prevents array access violations 5. **Hash and Key Comparison**: For each entry in the chain: - First compares hash codes for fast rejection of non-matches - For hash matches, performs optimized key comparison: * Short keys (< HashLength) with no hash collision bits can skip full comparison * Otherwise, retrieves the actual property name and performs byte-wise comparison 6. **Key Retrieval**: Property names are retrieved differently based on storage: - Simple properties: Read directly from the original JSON data - Escaped properties: Read from the dynamic value buffer after unescaping 7. **Collision Handling**: The algorithm includes safeguards against infinite loops by tracking collision count and ensuring it doesn't exceed the total entry count. This implementation provides O(1) average-case lookup performance with graceful handling of hash collisions through separate chaining, while minimizing memory allocations and cache misses through efficient data layout.


### PropertySchemaMatchers<T>.UnescapedNameProvider<T> (delegate)

```csharp
public delegate PropertySchemaMatchers<T>.UnescapedNameProvider<T> : MulticastDelegate, ICloneable, ISerializable
```

#### Implements

[`ICloneable`](https://learn.microsoft.com/dotnet/api/system.icloneable), [`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

#### Constructors

##### PropertySchemaMatchers

```csharp
PropertySchemaMatchers(object object, IntPtr method)
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

