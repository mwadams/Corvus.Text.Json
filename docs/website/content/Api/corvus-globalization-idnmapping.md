---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IdnMapping — Corvus.Globalization"
---
```csharp
public sealed class IdnMapping
```

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **IdnMapping**

## Constructors

### IdnMapping

```csharp
IdnMapping()
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Default` `static` | [`IdnMapping`](/api/corvus-globalization-idnmapping.html) |  |
| `AllowUnassigned` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `UseStd3AsciiRules` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |

## Methods

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `outputBuffer` | [`Span<char>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `count` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

