---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.TryGetGuid Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L1912)

## TryGetGuid {#trygetguid}

Attempts to represent the current JSON string as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid).

```csharp
public bool TryGetGuid(ref Guid value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ref Guid`](https://learn.microsoft.com/dotnet/api/system.guid) | Receives the value. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string can be represented as a [`Guid`](https://learn.microsoft.com/dotnet/api/system.guid), `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a Guid representation of values other than JSON strings.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

