---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PropertySchemaMatchers<T>.TryGetNamedMatcher Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryGetNamedMatcher {#trygetnamedmatcher}

```csharp
public bool TryGetNamedMatcher(ReadOnlySpan<byte> unescapedUtf8Name, ref T matcher)
```

Attempts to find the matcher for the named property value in the property map using efficient hash-based lookup.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `unescapedUtf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped UTF-8 property name to search for. |
| `matcher` | `ref T` | When this method returns, contains the matcher, otherwise null. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property was found; otherwise, `false`.

### Remarks

This method implements an efficient hash table lookup algorithm for property names in JSON objects. The lookup process follows these steps: 1. **Property Map Loading**: Reads the PropertyMap structure from the backing buffer to get metadata including bucket and entry offsets, counts, and sizes. 2. **Hash Calculation**: Computes a hash code for the target property name using an optimized algorithm that varies based on the property name length for maximum distribution. 3. **Bucket Selection**: Uses modulo operation to map the hash code to a specific bucket in the hash table, providing O(1) initial access. 4. **Chain Traversal**: Follows the linked chain of entries in the selected bucket: - Bucket values are 1-based, so the initial index is decremented - Each entry contains a Next field pointing to the next entry in the collision chain - Bounds checking prevents array access violations 5. **Hash and Key Comparison**: For each entry in the chain: - First compares hash codes for fast rejection of non-matches - For hash matches, performs optimized key comparison: * Short keys (< HashLength) with no hash collision bits can skip full comparison * Otherwise, retrieves the actual property name and performs byte-wise comparison 6. **Key Retrieval**: Property names are retrieved differently based on storage: - Simple properties: Read directly from the original JSON data - Escaped properties: Read from the dynamic value buffer after unescaping 7. **Collision Handling**: The algorithm includes safeguards against infinite loops by tracking collision count and ensuring it doesn't exceed the total entry count. This implementation provides O(1) average-case lookup performance with graceful handling of hash collisions through separate chaining, while minimizing memory allocations and cache misses through efficient data layout.

