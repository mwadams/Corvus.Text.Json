---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonException — Corvus.Text.Json"
---
```csharp
public class JsonException : Exception, ISerializable
```

Represents errors that occur during JSON parsing, reading, or writing operations. This exception is thrown when invalid JSON text is encountered, when the defined maximum depth is exceeded, or when the JSON text is not compatible with the type of a property on an object.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) → **JsonException**

## Implements

[`ISerializable`](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)

## Constructors

### JsonException

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine, Exception innerException)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, byte position, and a reference to the inner exception that is the cause of this exception.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `path` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The path where the invalid JSON was encountered. |
| `lineNumber` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The byte count within the current line where the invalid JSON was encountered (starting at 0). |
| `innerException` | [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) | The exception that caused the current exception. |

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

### JsonException

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, and byte position.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `path` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The path where the invalid JSON was encountered. |
| `lineNumber` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The byte count within the current line where the invalid JSON was encountered (starting at 0). |

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

### JsonException

```csharp
JsonException(string message, Exception innerException)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message and a reference to the inner exception that is the cause of this exception.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `innerException` | [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) | The exception that caused the current exception. |

### JsonException

```csharp
JsonException(string message)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |

### JsonException

```csharp
JsonException()
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `BytePositionInLine` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of bytes read within the current line before the exception (starting at 0). |
| `LineNumber` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of lines read so far before the exception (starting at 0). |
| `Message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets a message that describes the current exception. |
| `Path` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets the path within the JSON where the exception was encountered. |

