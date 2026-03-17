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
| [ToString()](#tostring) | Gets a string representation for the current value appropriate to the value type. |
| [ToString(string, IFormatProvider)](#tostring-string-iformatprovider) |  |

## ToString() {#tostring}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2222)

Gets a string representation for the current value appropriate to the value type.

```csharp
public override string ToString()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string representation for the current value appropriate to the value type.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

For JsonElement built from [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html): For [`Null`](/api/corvus-text-json-jsonvaluekind.html#null), [`Empty`](https://learn.microsoft.com/dotnet/api/system.string.empty#empty) is returned. For [`True`](/api/corvus-text-json-jsonvaluekind.html#true), [`TrueString`](https://learn.microsoft.com/dotnet/api/system.boolean.truestring#truestring) is returned. For [`False`](/api/corvus-text-json-jsonvaluekind.html#false), [`FalseString`](https://learn.microsoft.com/dotnet/api/system.boolean.falsestring#falsestring) is returned. For [`String`](/api/corvus-text-json-jsonvaluekind.html#string), the value of [`GetString`](/api/corvus-text-json-jsonelement.html#getstring)() is returned. For other types, the value of [`GetRawText`](/api/corvus-text-json-jsonelement.html#getrawtext)() is returned.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ToString(string, IFormatProvider) {#tostring-string-iformatprovider}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2288)

```csharp
public string ToString(string format, IFormatProvider formatProvider)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) |  |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

### Implements

[`IFormattable.ToString`](https://learn.microsoft.com/dotnet/api/system.iformattable.tostring)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

