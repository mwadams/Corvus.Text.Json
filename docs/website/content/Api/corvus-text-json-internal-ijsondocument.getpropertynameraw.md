---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetPropertyNameRaw Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetPropertyNameRaw(int)](#getpropertynameraw-int) | Gets the raw property name as a byte span for the specified index. |
| [GetPropertyNameRaw(int, bool)](#getpropertynameraw-int-bool) | Gets the raw property name as a byte span for the specified index. |

## GetPropertyNameRaw(int) {#getpropertynameraw-int}

```csharp
ReadOnlySpan<byte> GetPropertyNameRaw(int index)
```

Gets the raw property name as a byte span for the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |

### Returns

[`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1)

The raw property name as a byte span.

---

## GetPropertyNameRaw(int, bool) {#getpropertynameraw-int-bool}

```csharp
ReadOnlyMemory<byte> GetPropertyNameRaw(int index, bool includeQuotes)
```

Gets the raw property name as a byte span for the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the property. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw property name. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw property name as a byte span.

---

