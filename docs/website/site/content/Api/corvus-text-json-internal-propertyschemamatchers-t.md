---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "PropertySchemaMatchers<T> — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [PropertySchemaMatchers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonSchema/Internal/PropertySchemaMatchers.cs#L28)

A dictionary lookup of matchers for properties in a JSON object, optimized for low allocations and high performance.

```csharp
public class PropertySchemaMatchers<T>
```

## Remarks

This class uses a hash-based approach to enable O(1) average-case lookups of property matchers based on property names, while minimizing memory usage through array pooling and efficient data layout. The implementation includes a custom hash function, separate chaining for collision resolution, and optimized key comparison strategies to ensure fast lookups even in the presence of hash collisions.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **PropertySchemaMatchers<T>**

## Constructors

| Constructor | Description |
|-------------|-------------|
| [PropertySchemaMatchers(List&lt;ValueTuple&lt;PropertySchemaMatchers&lt;T&gt;.UnescapedNameProvider&lt;T&gt;, T&gt;&gt;)](/api/corvus-text-json-internal-propertyschemamatchers-t.ctor.html#propertyschemamatchers-list-valuetuple-propertyschemamatchers-t-unescapednameprovider-t-t) |  |

## Methods

| Method | Description |
|--------|-------------|
| [TryGetNamedMatcher(ReadOnlySpan&lt;byte&gt;, ref T)](/api/corvus-text-json-internal-propertyschemamatchers-t.trygetnamedmatcher.html#trygetnamedmatcher-readonlyspan-byte-ref-t) | Attempts to find the matcher for the named property value in the property map using efficient hash-based lookup. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

