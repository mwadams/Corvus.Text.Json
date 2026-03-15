---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper.ThrowArgumentException_ArrayBufferLength Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ThrowArgumentException_ArrayBufferLength `static`

```csharp
void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
```

Throws an [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) when an array buffer has an incorrect length.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `paramName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the parameter that caused the exception. |
| `expectedLength` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The expected length of the array buffer. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Always thrown. |

