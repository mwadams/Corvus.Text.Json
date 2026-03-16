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
| [JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;, Exception)](/api/corvus-text-json-jsonexception.ctor.html#jsonexception-string-string-nullable-long-nullable-long-exception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, byte position, and a reference to the inner ex... |
| [JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;)](/api/corvus-text-json-jsonexception.ctor.html#jsonexception-string-string-nullable-long-nullable-long) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, and byte position. |
| [JsonException(string, Exception)](/api/corvus-text-json-jsonexception.ctor.html#jsonexception-string-exception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message and a reference to the inner exception that is the cause of this e... |
| [JsonException(string)](/api/corvus-text-json-jsonexception.ctor.html#jsonexception-string) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message. |
| [JsonException()](/api/corvus-text-json-jsonexception.ctor.html#jsonexception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [BytePositionInLine](/api/corvus-text-json-jsonexception.bytepositioninline.html) | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of bytes read within the current line before the exception (starting at 0). |
| [LineNumber](/api/corvus-text-json-jsonexception.linenumber.html) | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | Gets the number of lines read so far before the exception (starting at 0). |
| [Message](/api/corvus-text-json-jsonexception.message.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets a message that describes the current exception. |
| [Path](/api/corvus-text-json-jsonexception.path.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets the path within the JSON where the exception was encountered. |

