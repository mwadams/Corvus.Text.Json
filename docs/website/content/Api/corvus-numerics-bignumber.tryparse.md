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
| [TryParse(string, ref BigNumber)](#tryparse-string-ref-bignumber) | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(string, IFormatProvider, ref BigNumber)](#tryparse-string-iformatprovider-ref-bignumber) | Attempts to parse a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, IFormatProvider, ref BigNumber)](#tryparse-readonlyspan-char-iformatprovider-ref-bignumber) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, ref BigNumber)](#tryparse-readonlyspan-char-ref-bignumber) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, IFormatProvider, ref BigNumber)](#tryparse-readonlyspan-byte-iformatprovider-ref-bignumber) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, ref BigNumber)](#tryparse-readonlyspan-byte-ref-bignumber) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider, ref BigNumber)](#tryparse-readonlyspan-char-numberstyles-iformatprovider-ref-bignumber) | Attempts to parse a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [TryParse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider, ref BigNumber)](#tryparse-readonlyspan-byte-numberstyles-iformatprovider-ref-bignumber) | Attempts to parse UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |

## TryParse(string, ref BigNumber) {#tryparse-string-ref-bignumber}

```csharp
public static bool TryParse(string s, ref BigNumber result)
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

## TryParse(string, IFormatProvider, ref BigNumber) {#tryparse-string-iformatprovider-ref-bignumber}

```csharp
public static bool TryParse(string s, IFormatProvider provider, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;char&gt;, IFormatProvider, ref BigNumber) {#tryparse-readonlyspan-char-iformatprovider-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;char&gt;, ref BigNumber) {#tryparse-readonlyspan-char-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<char> s, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;byte&gt;, IFormatProvider, ref BigNumber) {#tryparse-readonlyspan-byte-iformatprovider-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<byte> s, IFormatProvider provider, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;byte&gt;, ref BigNumber) {#tryparse-readonlyspan-byte-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<byte> s, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider, ref BigNumber) {#tryparse-readonlyspan-char-numberstyles-iformatprovider-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, ref BigNumber result)
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

## TryParse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider, ref BigNumber) {#tryparse-readonlyspan-byte-numberstyles-iformatprovider-ref-bignumber}

```csharp
public static bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider, ref BigNumber result)
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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

