---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.GetRawSimpleValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [GetRawSimpleValue(int, bool)](#getrawsimplevalue-int-bool) | Gets the raw simple value of the element at the specified index. |
| [GetRawSimpleValue(int)](#getrawsimplevalue-int) | Gets the raw simple value of the element at the specified index. |

## GetRawSimpleValue(int, bool) {#getrawsimplevalue-int-bool}

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes)
```

Gets the raw simple value of the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `includeQuotes` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to include quotes in the raw value. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

---

## GetRawSimpleValue(int) {#getrawsimplevalue-int}

```csharp
ReadOnlyMemory<byte> GetRawSimpleValue(int index)
```

Gets the raw simple value of the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

[`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1)

The raw simple value.

---

