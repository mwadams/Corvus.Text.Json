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
| [ThrowFormatException()](#throwformatexception) | Throws a generic [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for format-related errors. |
| [ThrowFormatException(CodeGenNumericType)](#throwformatexception-codegennumerictype) | Throws a [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for numeric type formatting errors. |

## ThrowFormatException() {#throwformatexception}

**Source:** [CodeGenThrowHelper.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/CodeGenThrowHelper.cs#L89)

Throws a generic [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for format-related errors.

```csharp
public static void ThrowFormatException()
```

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ThrowFormatException(CodeGenNumericType) {#throwformatexception-codegennumerictype}

**Source:** [CodeGenThrowHelper.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/CodeGenThrowHelper.cs#L100)

Throws a [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for numeric type formatting errors.

```csharp
public static void ThrowFormatException(CodeGenNumericType numericType)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `numericType` | [`CodeGenNumericType`](/api/corvus-text-json-internal-codegennumerictype.html) | The numeric type that failed to format. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

