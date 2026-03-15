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

| Constructor | Description |
|-------------|-------------|
| [UniqueItemsHashSet(IJsonDocument, int, Span&lt;int&gt;, Span&lt;byte&gt;)](/api/corvus-text-json-internal-uniqueitemshashset.ctor.html#uniqueitemshashset-ijsondocument-parentdocument-int-itemscount-span-int-buckets-span-byte-entries) | Creates a validator map for efficient property lookup based on the provided matchers. |

## Methods

| Method | Description |
|--------|-------------|
| [AddItemIfNotExists(int)](/api/corvus-text-json-internal-uniqueitemshashset.additemifnotexists.html#bool-additemifnotexists-int-parentdocumentindex) | Adds the item identified by the parent document index to the map if it does not already exist, returning true if it was added and false if it already existed. |
| [Dispose()](/api/corvus-text-json-internal-uniqueitemshashset.dispose.html#void-dispose) |  |
| [GetHashCode(int)](/api/corvus-text-json-internal-uniqueitemshashset.gethashcode.html#int-gethashcode-int-documentindex) |  |
| [ValueEquals(int, int)](/api/corvus-text-json-internal-uniqueitemshashset.valueequals.html#bool-valueequals-int-leftindex-int-rightindex) |  |

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [StackAllocBucketSize](/api/corvus-text-json-internal-uniqueitemshashset.stackallocbucketsize.html) `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The recommended size for a stack allocated bucket buffer. |
| [StackAllocEntrySize](/api/corvus-text-json-internal-uniqueitemshashset.stackallocentrysize.html) `static` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The recommended size for a stack allocated entries buffer. |

