---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonException Constructors — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Constructor | Description |
|-------------|-------------|
| [JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;, Exception)](#jsonexception-string-string-nullable-long-nullable-long-exception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, byte position, and a reference to the inner ex... |
| [JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;)](#jsonexception-string-string-nullable-long-nullable-long) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, and byte position. |
| [JsonException(string, Exception)](#jsonexception-string-exception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message and a reference to the inner exception that is the cause of this e... |
| [JsonException(string)](#jsonexception-string) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message. |
| [JsonException()](#jsonexception) | Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class. |

## JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;, Exception) {#jsonexception-string-string-nullable-long-nullable-long-exception}

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine, Exception innerException)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, byte position, and a reference to the inner exception that is the cause of this exception.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `path` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The path where the invalid JSON was encountered. |
| `lineNumber` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The byte count within the current line where the invalid JSON was encountered (starting at 0). |
| `innerException` | [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) | The exception that caused the current exception. |

### Remarks

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

---

## JsonException(string, string, Nullable&lt;long&gt;, Nullable&lt;long&gt;) {#jsonexception-string-string-nullable-long-nullable-long}

```csharp
JsonException(string message, string path, Nullable<long> lineNumber, Nullable<long> bytePositionInLine)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message, path, line number, and byte position.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `path` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The path where the invalid JSON was encountered. |
| `lineNumber` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The line number at which the invalid JSON was encountered (starting at 0) when deserializing. |
| `bytePositionInLine` | [`Nullable<long>`](https://learn.microsoft.com/dotnet/api/system.nullable-1) | The byte count within the current line where the invalid JSON was encountered (starting at 0). |

### Remarks

Note that the `bytePositionInLine` counts the number of bytes (i.e. UTF-8 code units) and not characters or scalars.

---

## JsonException(string, Exception) {#jsonexception-string-exception}

```csharp
JsonException(string message, Exception innerException)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message and a reference to the inner exception that is the cause of this exception.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |
| `innerException` | [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) | The exception that caused the current exception. |

---

## JsonException(string) {#jsonexception-string}

```csharp
JsonException(string message)
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class with a specified error message.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The context specific error message. |

---

## JsonException() {#jsonexception}

```csharp
JsonException()
```

Initializes a new instance of the [`JsonException`](/api/corvus-text-json-jsonexception.html) class.

---

