---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "FixedStringJsonDocument<T> — Corvus.Text.Json.Internal"
---
```csharp
public sealed class FixedStringJsonDocument<T> : IJsonDocument, IDisposable
```

Represents a JSON document based on a fixed string value.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the root element in the document. |

## Remarks

This type uses an internal cache to avoid allocations for evaluatoin of string values that have not originated in a regular JSON document (e.g. property names, or external strings.)

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **FixedStringJsonDocument<T>**

## Implements

[`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `RootElement` | `T` |  |

## Methods

### Parse `static`

```csharp
FixedStringJsonDocument<T> Parse(ReadOnlyMemory<byte> rawJsonStringValue, bool requiresUnescaping)
```

Parse an instance of the fixed string to a document, using caching.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `rawJsonStringValue` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) | The raw JSON string value, including quotes. |
| `requiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

**Returns:** [`FixedStringJsonDocument<T>`](/api/corvus-text-json-internal-fixedstringjsondocument-t.html)

A fixed string document representing the value, from the cache.

### TryFormat

```csharp
bool TryFormat(int index, Span<char> destination, ref int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `destination` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `charsWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### TryFormat

```csharp
bool TryFormat(int index, Span<byte> destination, ref int bytesWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `destination` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `bytesWritten` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### ToString

```csharp
string ToString(int index, string format, IFormatProvider formatProvider)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

