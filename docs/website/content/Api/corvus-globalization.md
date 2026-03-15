---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Globalization Namespace"
---
# Corvus.Globalization Namespace

| Type | Kind | Description |
|------|------|-------------|
| [CharUnicodeInfo](#charunicodeinfo) | class | This class implements a set of methods for retrieving character type information. Character type information is independent of culture and region. |
| [IdnMapping](#idnmapping) | class |  |

## CharUnicodeInfo (class)

```csharp
public static class CharUnicodeInfo
```

This class implements a set of methods for retrieving character type information. Character type information is independent of culture and region.

---

## IdnMapping (class)

```csharp
public sealed class IdnMapping
```

### Constructors

#### IdnMapping

```csharp
IdnMapping()
```

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Default` `static` | `IdnMapping` |  |
| `AllowUnassigned` | `bool` |  |
| `UseStd3AsciiRules` | `bool` |  |

### Methods

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<byte>` |  |
| `outputBuffer` | `Span<byte>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<byte>` |  |
| `outputBuffer` | `Span<byte>` |  |
| `index` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<byte> ascii, Span<byte> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<byte>` |  |
| `outputBuffer` | `Span<byte>` |  |
| `index` | `int` |  |
| `count` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `index` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetUnicode

```csharp
bool GetUnicode(ReadOnlySpan<char> ascii, Span<char> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `ascii` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `index` | `int` |  |
| `count` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `index` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### GetAscii

```csharp
bool GetAscii(ReadOnlySpan<char> unicode, Span<char> outputBuffer, int index, int count, ref int written)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `unicode` | `ReadOnlySpan<char>` |  |
| `outputBuffer` | `Span<char>` |  |
| `index` | `int` |  |
| `count` | `int` |  |
| `written` | `ref int` |  |

**Returns:** `bool`

#### Equals `virtual`

```csharp
bool Equals(object obj)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `obj` | `object` |  |

**Returns:** `bool`

#### GetHashCode `virtual`

```csharp
int GetHashCode()
```

**Returns:** `int`

---

