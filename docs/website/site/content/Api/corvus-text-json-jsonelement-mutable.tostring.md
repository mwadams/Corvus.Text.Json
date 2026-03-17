---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.ToString Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [ToString()](#tostring) |  |
| [ToString(string, IFormatProvider)](#tostring-string-iformatprovider) |  |

## ToString() {#tostring}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4259)

```csharp
public override string ToString()
```

### Returns

[`string`](https://learn.microsoft.com/dotnet/api/system.string)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ToString(string, IFormatProvider) {#tostring-string-iformatprovider}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L4281)

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

