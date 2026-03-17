---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.GetBytesFromBase64 Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L675)

## GetBytesFromBase64 {#getbytesfrombase64}

Gets the value of the element as bytes.

```csharp
public byte[] GetBytesFromBase64()
```

### Returns

[`byte[]`](https://learn.microsoft.com/dotnet/api/system.byte)

The value decode to bytes.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | The value is not encoded as Base64 text and hence cannot be decoded to bytes. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

### Remarks

This method does not create a byte[] representation of values other than Base64 encoded JSON strings.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

