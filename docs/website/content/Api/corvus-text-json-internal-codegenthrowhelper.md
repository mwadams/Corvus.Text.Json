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

| Method | Description |
|--------|-------------|
| [ThrowArgumentException_ArrayBufferLength(string, int)](/api/corvus-text-json-internal-codegenthrowhelper.throwargumentexception-arraybufferlength.html#throwargumentexception-arraybufferlength-string-int) `static` | Throws an [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) when an array buffer has an incorrect length. |
| [ThrowFormatException()](/api/corvus-text-json-internal-codegenthrowhelper.throwformatexception.html#throwformatexception) `static` | Throws a generic [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for format-related errors. |
| [ThrowFormatException(CodeGenNumericType)](/api/corvus-text-json-internal-codegenthrowhelper.throwformatexception.html#throwformatexception-codegennumerictype) `static` | Throws a [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) for numeric type formatting errors. |
| [ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst()](/api/corvus-text-json-internal-codegenthrowhelper.throwinvalidoperationexception-prefixtuplemustbecreatedfirst.html#throwinvalidoperationexception-prefixtuplemustbecreatedfirst) `static` | Throws an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) when attempting to set a required property to an undefined value. |
| [ThrowInvalidOperationException_SetRequiredPropertyToUndefined(string)](/api/corvus-text-json-internal-codegenthrowhelper.throwinvalidoperationexception-setrequiredpropertytoundefined.html#throwinvalidoperationexception-setrequiredpropertytoundefined-string) `static` | Throws an [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) when attempting to set a required property to an undefined value. |

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [ExceptionSourceValueToRethrowAsJsonException](/api/corvus-text-json-internal-codegenthrowhelper.exceptionsourcevaluetorethrowasjsonexception.html) `static` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

