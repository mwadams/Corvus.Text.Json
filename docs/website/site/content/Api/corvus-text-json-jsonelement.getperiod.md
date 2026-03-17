---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetPeriod Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L1783)

## GetPeriod {#getperiod}

Gets the value of the element as a [`Period`](/api/corvus-text-json-period.html).

```csharp
public Period GetPeriod()
```

### Returns

[`Period`](/api/corvus-text-json-period.html)

The value of the element as a [`Period`](/api/corvus-text-json-period.html).

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value cannot be represented as a [`DateTime`](https://learn.microsoft.com/dotnet/api/system.datetime). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a Period representation of values other than JSON strings.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

