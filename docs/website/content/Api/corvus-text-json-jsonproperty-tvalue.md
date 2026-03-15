---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue> — Corvus.Text.Json"
---
```csharp
public readonly struct JsonProperty<TValue>
```

Represents a single property for a JSON object.

## Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the value. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The name of this property. |
| `NameSpan` | [`UnescapedUtf8JsonString`](/api/corvus-text-json-unescapedutf8jsonstring.html) | Gets the name as an unescaped UTF-8 JSON string. |
| `Value` | `TValue` | The value of this property. |

### Name

```csharp
string Name { get; }
```

The name of this property.

Note that this allocates.

### NameSpan

```csharp
UnescapedUtf8JsonString NameSpan { get; }
```

Gets the name as an unescaped UTF-8 JSON string.

Note that this does not allocate. The result should be disposed when it is no longer needed, as it may use a rented buffer to back the string. It is only valid for the lifetime of the document that contains this property.

## Methods

### NameEquals

```csharp
bool NameEquals(string text)
```

Compares `text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's `Type` is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html). |

This method is functionally equal to doing an ordinal comparison of `text` and [`Name`](/api/corvus-text-json-jsonproperty-tvalue.html), but can avoid creating the string instance.

### NameEquals

```csharp
bool NameEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's `Type` is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html). |

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`NameSpan`](/api/corvus-text-json-jsonproperty-tvalue.html), but can avoid creating the UTF8 string instance.

### NameEquals

```csharp
bool NameEquals(ReadOnlySpan<char> text)
```

Compares `text` to the name of this property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property matches `text`, `false` otherwise.

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's `Type` is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html). |

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`NameSpan`](/api/corvus-text-json-jsonproperty-tvalue.html), but can avoid creating the UTF-8 string instance.

### ToString `virtual`

```csharp
string ToString()
```

Provides a `String` representation of the property for debugging purposes.

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

A string containing the un-interpreted value of the property, beginning at the declaring open-quote and ending at the last character that is part of the value.

### WriteTo

```csharp
void WriteTo(Utf8JsonWriter writer)
```

Write the property into the provided writer as a named JSON object property.

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `writer` | [`Utf8JsonWriter`](/api/corvus-text-json-utf8jsonwriter.html) | The writer. |

**Exceptions:**

| Exception | Description |
|-----------|-------------|
| [`ArgumentNullException`](https://learn.microsoft.com/dotnet/api/system.argumentnullexception) | The `writer` parameter is `null`. |
| [`ArgumentException`](https://learn.microsoft.com/dotnet/api/system.argumentexception) | This [`Name`](/api/corvus-text-json-jsonproperty-tvalue.html)'s length is too large to be a JSON object property. |
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This [`Value`](/api/corvus-text-json-jsonproperty-tvalue.html)'s [`ValueKind`](/api/corvus-text-json-jsonelement.html) would result in an invalid JSON. |
| [`ObjectDisposedException`](https://learn.microsoft.com/dotnet/api/system.objectdisposedexception) | The parent [`JsonDocument`](/api/corvus-text-json-internal-jsondocument.html) has been disposed. |

