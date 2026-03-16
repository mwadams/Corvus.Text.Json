---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper.ThrowInvalidOperationException_SetRequiredPropertyToUndefined Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## ThrowInvalidOperationException_SetRequiredPropertyToUndefined {#throwinvalidoperationexception-setrequiredpropertytoundefined}

```csharp
void ThrowInvalidOperationException_SetRequiredPropertyToUndefined(string propertyName)
```

Throws an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) when attempting to set a required property to an undefined value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the required property. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Always thrown. |

