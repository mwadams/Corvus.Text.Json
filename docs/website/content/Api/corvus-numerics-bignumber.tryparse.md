---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.TryParse Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryParse(string, ref BigNumber)](#bool-tryparse-string-s-ref-bignumber-result) | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(string, IFormatProvider, ref BigNumber)](#bool-tryparse-string-s-iformatprovider-provider-ref-bignumber-result) | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, IFormatProvider, ref BigNumber)](#bool-tryparse-readonlyspan-char-s-iformatprovider-provider-ref-bignumber-result) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#bool-tryparse-readonlyspan-char-s-ref-bignumber-result) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, IFormatProvider, ref BigNumber)](#bool-tryparse-readonlyspan-byte-s-iformatprovider-provider-ref-bignumber-result) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](#bool-tryparse-readonlyspan-byte-s-ref-bignumber-result) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider, ref BigNumber)](#bool-tryparse-readonlyspan-char-s-numberstyles-style-iformatprovider-provider-ref-bignumber-result) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider, ref BigNumber)](#bool-tryparse-readonlyspan-byte-utf8text-numberstyles-style-iformatprovider-provider-ref-bignumber-result) | Attempts to parse UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |

## TryParse `static`

```csharp
bool TryParse(string s, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(string s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> s, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

## TryParse `static`

```csharp
bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider, ref BigNumber result)
```

Attempts to parse UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. |
| `result` | [`ref BigNumber`](/api/corvus-numerics-bignumber.html) | The parsed number. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if parsing succeeded; otherwise, `false`.

---

