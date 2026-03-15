---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.ToString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ToString(int)](#string-tostring-int-index) | Converts the element at the specified index to a string. |
| [ToString(int, string, IFormatProvider)](#string-tostring-int-index-string-format-iformatprovider-formatprovider) | Gets the display string representation of the element at the specified index according to the specified format and format provider. |

## ToString `abstract`

```csharp
string ToString(int index)
```

Converts the element at the specified index to a string.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The string representation of the element.

---

## ToString `abstract`

```csharp
string ToString(int index, string format, IFormatProvider formatProvider)
```

Gets the display string representation of the element at the specified index according to the specified format and format provider.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `format` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The format string. |
| `formatProvider` | [`IFormatProvider`](https://learn.microsoft.com/dotnet/api/system.iformatprovider) | The format provider. |

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

The display string representation of the element.

---

