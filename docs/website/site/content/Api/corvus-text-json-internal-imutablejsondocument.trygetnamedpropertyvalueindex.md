---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.TryGetNamedPropertyValueIndex Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetNamedPropertyValueIndex(ref MetadataDb, int, int, ReadOnlySpan&lt;byte&gt;, ref int)](#trygetnamedpropertyvalueindex-ref-metadatadb-int-int-readonlyspan-byte-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;char&gt;, ref int)](#trygetnamedpropertyvalueindex-int-readonlyspan-char-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |
| [TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;byte&gt;, ref int)](#trygetnamedpropertyvalueindex-int-readonlyspan-byte-ref-int) | Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html). |

## TryGetNamedPropertyValueIndex(ref MetadataDb, int, int, ReadOnlySpan&lt;byte&gt;, ref int) {#trygetnamedpropertyvalueindex-ref-metadatadb-int-int-readonlyspan-byte-ref-int}

```csharp
public abstract bool TryGetNamedPropertyValueIndex(ref MetadataDb parsedData, int startIndex, int endIndex, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parsedData` | [`ref MetadataDb`](/api/corvus-text-json-internal-metadatadb.html) | The parsed data. This is used in place of the document's own MetadataDb. |
| `startIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the first property name. |
| `endIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the last property value. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name to look up. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

---

## TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;char&gt;, ref int) {#trygetnamedpropertyvalueindex-int-readonlyspan-char-ref-int}

```csharp
public abstract bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<char> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The unescaped property name to look up. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

---

## TryGetNamedPropertyValueIndex(int, ReadOnlySpan&lt;byte&gt;, ref int) {#trygetnamedpropertyvalueindex-int-readonlyspan-byte-ref-int}

```csharp
public abstract bool TryGetNamedPropertyValueIndex(int index, ReadOnlySpan<byte> propertyName, ref int valueIndex)
```

Gets the named property value from a specific [`MetadataDb`](/api/corvus-text-json-internal-metadatadb.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property as a UTF-8 byte span. |
| `valueIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the value corresponding to the given property name. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property with the given name is found.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

