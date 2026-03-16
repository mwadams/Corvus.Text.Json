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

| Constructor | Description |
|-------------|-------------|
| [JsonException(...)](/api/corvus-text-json-jsonexception.ctor.html) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, byte position, and a reference to the inner ex... |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [BytePositionInLine](/api/corvus-text-json-jsonexception.bytepositioninline.html) | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of bytes read within the current line before the exception (starting at 0). |
| [LineNumber](/api/corvus-text-json-jsonexception.linenumber.html) | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of lines read so far before the exception (starting at 0). |
| [Message](/api/corvus-text-json-jsonexception.message.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets a message that describes the current exception. |
| [Path](/api/corvus-text-json-jsonexception.path.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets the path within the JSON where the exception was encountered. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

