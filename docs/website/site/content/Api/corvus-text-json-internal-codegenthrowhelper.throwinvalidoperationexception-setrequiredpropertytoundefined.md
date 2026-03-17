---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper.ThrowInvalidOperationException_SetRequiredPropertyToUndefined Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [CodeGenThrowHelper.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/CodeGenThrowHelper.cs#L195)

## ThrowInvalidOperationException_SetRequiredPropertyToUndefined {#throwinvalidoperationexception-setrequiredpropertytoundefined}

Throws an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) when attempting to set a required property to an undefined value.

```csharp
public static void ThrowInvalidOperationException_SetRequiredPropertyToUndefined(string propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the required property. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Always thrown. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

