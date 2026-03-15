---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ToString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ToString()](#string-tostring) | Gets a string representation for the current value appropriate to the value type. |
| [ToString(string, IFormatProvider)](#string-tostring-string-format-iformatprovider-formatprovider) |  |

## ToString `virtual`

```csharp
string ToString()
```

Gets a string representation for the current value appropriate to the value type.

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation for the current value appropriate to the value type.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

For JsonElement built from [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html): For [`Null`](/api/corvus-text-json-jsonvaluekind.html#null), [`Empty`](https://learn.microsoft.com/dotnet/api/system.string.empty#empty) is returned. For [`True`](/api/corvus-text-json-jsonvaluekind.html#true), [`TrueString`](https://learn.microsoft.com/dotnet/api/system.boolean.truestring#truestring) is returned. For [`False`](/api/corvus-text-json-jsonvaluekind.html#false), [`FalseString`](https://learn.microsoft.com/dotnet/api/system.boolean.falsestring#falsestring) is returned. For [`String`](/api/corvus-text-json-jsonvaluekind.html#string), the value of [`GetString`](/api/corvus-text-json-jsonelement.html#getstring)() is returned. For other types, the value of [`GetRawText`](/api/corvus-text-json-jsonelement.html#getrawtext)() is returned.

---

## ToString

```csharp
string ToString(string format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

---

