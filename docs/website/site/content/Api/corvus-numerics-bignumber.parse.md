---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Parse Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Parse(string, IFormatProvider)](#parse-string-iformatprovider) | Parses a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Parse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider)](#parse-readonlyspan-char-numberstyles-iformatprovider) | Parses a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |
| [Parse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider)](#parse-readonlyspan-byte-numberstyles-iformatprovider) | Parses UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html). |

## Parse(string, IFormatProvider) {#parse-string-iformatprovider}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L1025)

Parses a string into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

```csharp
public static BigNumber Parse(string s, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The string to parse. |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(ReadOnlySpan&lt;char&gt;, NumberStyles, IFormatProvider) {#parse-readonlyspan-char-numberstyles-iformatprovider}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L1046)

Parses a span of characters into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

```csharp
public static BigNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `s` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The span to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. *(optional)* |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Parse(ReadOnlySpan&lt;byte&gt;, NumberStyles, IFormatProvider) {#parse-readonlyspan-byte-numberstyles-iformatprovider}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L1479)

Parses UTF-8 bytes into a [`BigNumber`](/api/corvus-numerics-bignumber.html).

```csharp
public static BigNumber Parse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider provider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes to parse. |
| `style` | [`NumberStyles`](https://learn.microsoft.com/dotnet/api/system.globalization.numberstyles) | Number styles. *(optional)* |
| `provider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | Format provider. *(optional)* |

### Returns

[`BigNumber`](/api/corvus-numerics-bignumber.html)

The parsed number.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

