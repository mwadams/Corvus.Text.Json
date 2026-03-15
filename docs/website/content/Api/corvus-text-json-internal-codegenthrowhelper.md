---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "CodeGenThrowHelper — Corvus.Text.Json.Internal"
---
```csharp
public static class CodeGenThrowHelper
```

Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json. This class centralizes exception creation and throwing logic to ensure consistent error handling and messaging.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **CodeGenThrowHelper**

## Methods

### ThrowArgumentException_ArrayBufferLength `static`

```csharp
void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
```

Throws an `ArgumentException` when an array buffer has an incorrect length.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `paramName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the parameter that caused the exception. |
| `expectedLength` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The expected length of the array buffer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | Always thrown. |

### ThrowFormatException `static`

```csharp
void ThrowFormatException()
```

Throws a generic `FormatException` for format-related errors.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

### ThrowFormatException `static`

```csharp
void ThrowFormatException(CodeGenNumericType numericType)
```

Throws a `FormatException` for numeric type formatting errors.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `numericType` | [`CodeGenNumericType`](/api/corvus-text-json-internal-codegennumerictype.html) | The numeric type that failed to format. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | Always thrown. |

### ThrowInvalidOperationException_SetRequiredPropertyToUndefined `static`

```csharp
void ThrowInvalidOperationException_SetRequiredPropertyToUndefined(string propertyName)
```

Throws an `InvalidOperationException` when attempting to set a required property to an undefined value.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of the required property. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Always thrown. |

### ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst `static`

```csharp
void ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst()
```

Throws an `InvalidOperationException` when attempting to set a required property to an undefined value.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Always thrown. |

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `ExceptionSourceValueToRethrowAsJsonException` `static` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

