---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonPointer — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8JsonPointer
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsValid` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid IRI. |

## Methods

### TryCreateJsonPointer `static`

```csharp
bool TryCreateJsonPointer(ReadOnlySpan<byte> jsonPointer, ref Utf8JsonPointer utf8JsonPointer)
```

Tries to create a new UTF-8 JSON Pointer from the specified UTF-8 bytes.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 bytes from which to create the UTF-8 JSON Pointer. |
| `utf8JsonPointer` | [`ref Utf8JsonPointer`](/api/corvus-text-json-utf8jsonpointer.html) | When this method returns, contains the created UTF-8 JSON Pointer if successful; otherwise, the default value. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the UTF-8 JSON Pointer was created successfully; otherwise, `false`.

### TryResolve

```csharp
bool TryResolve<T, TResult>(ref T jsonElement, ref TResult value)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the value at that path if it exists.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |
| `TResult` | The type of the element at the target. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `value` | `ref TResult` | The value at the target path if it exists. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was resolved successfully; otherwise, `false`.

### TryGetLineAndOffset

```csharp
bool TryGetLineAndOffset<T>(ref T jsonElement, ref int line, ref int charOffset, ref long lineByteOffset)
```

Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the 1-based line number and character offset of the target element in the original source document.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the element at the root of the path. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `jsonElement` | `ref T` | The element at the root of the path. |
| `line` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based line number if successful. |
| `charOffset` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | When this method returns, contains the 1-based character offset within the line if successful. |
| `lineByteOffset` | [`ref long`](https://learn.microsoft.com/dotnet/api/system.int64) | When this method returns, contains the byte offset of the start of the line if successful. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer was resolved and the line and offset were determined; otherwise, `false`.

