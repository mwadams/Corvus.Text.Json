---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper.ThrowFormatException Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ThrowFormatException()](#void-throwformatexception) | Throws a generic [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for format-related errors. |
| [ThrowFormatException(CodeGenNumericType)](#void-throwformatexception-codegennumerictype-numerictype) | Throws a [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for numeric type formatting errors. |

## ThrowFormatException `static`

```csharp
void ThrowFormatException()
```

Throws a generic [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for format-related errors.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

---

## ThrowFormatException `static`

```csharp
void ThrowFormatException(CodeGenNumericType numericType)
```

Throws a [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for numeric type formatting errors.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `numericType` | [`CodeGenNumericType`](/api/corvus-text-json-internal-codegennumerictype.html) | The numeric type that failed to format. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

---

