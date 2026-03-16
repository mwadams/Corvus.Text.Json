---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.ToString Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ToString()](#tostring) | Returns the string representation of this [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| [ToString(string, IFormatProvider)](#tostring-string-iformatprovider) | Formats this [`BigNumber`](/api/corvus-numerics-bignumber.html) value using the specified format string and format provider. |

## ToString() {#tostring}

```csharp
string ToString()
```

Returns the string representation of this [`BigNumber`](/api/corvus-numerics-bignumber.html) value.

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The string representation of this instance.

---

## ToString(string, IFormatProvider) {#tostring-string-iformatprovider}

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

Formats this [`BigNumber`](/api/corvus-numerics-bignumber.html) value using the specified format string and format provider.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The formatted string representation of this instance.

---

