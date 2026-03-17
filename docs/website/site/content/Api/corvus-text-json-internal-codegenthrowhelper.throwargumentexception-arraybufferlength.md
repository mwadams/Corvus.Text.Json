---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper.ThrowArgumentException_ArrayBufferLength Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [CodeGenThrowHelper.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/CodeGenThrowHelper.cs#L79)

## ThrowArgumentException_ArrayBufferLength {#throwargumentexception-arraybufferlength}

Throws an [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) when an array buffer has an incorrect length.

```csharp
public static void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `paramName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the parameter that caused the exception. |
| `expectedLength` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The expected length of the array buffer. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Always thrown. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

