---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "UniqueItemsHashSet Constructors — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## UniqueItemsHashSet {#uniqueitemshashset}

```csharp
UniqueItemsHashSet(IJsonDocument parentDocument, int itemsCount, Span<int> buckets, Span<byte> entries)
```

Creates a validator map for efficient property lookup based on the provided matchers.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document for the unique items map. |
| `itemsCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of items to be added to the map. |
| `buckets` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `entries` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | A working buffer for the buckets. |

