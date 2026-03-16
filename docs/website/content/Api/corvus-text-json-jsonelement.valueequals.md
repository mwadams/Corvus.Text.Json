---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ValueEquals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [ValueEquals(string)](#valueequals-string) | Compares `text` to the string value of this element. |
| [ValueEquals(ReadOnlySpan&lt;byte&gt;)](#valueequals-readonlyspan-byte) | Compares the text represented by `utf8Text` to the string value of this element. |
| [ValueEquals(ReadOnlySpan&lt;char&gt;)](#valueequals-readonlyspan-char) | Compares `text` to the string value of this element. |

## ValueEquals(string) {#valueequals-string}

```csharp
bool ValueEquals(string text)
```

Compares `text` to the string value of this element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element matches `text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |

### Remarks

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html#getstring), but avoids creating the string instance.

---

## ValueEquals(ReadOnlySpan&lt;byte&gt;) {#valueequals-readonlyspan-byte}

```csharp
bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the string value of this element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |

### Remarks

This method is functionally equal to doing an ordinal comparison of the string produced by UTF-8 decoding `utf8Text` with the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html#getstring), but avoids creating the string instances.

---

## ValueEquals(ReadOnlySpan&lt;char&gt;) {#valueequals-readonlyspan-char}

```csharp
bool ValueEquals(ReadOnlySpan<char> text)
```

Compares `text` to the string value of this element.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the string value of this element matches `text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`ValueKind`](/api/corvus-text-json-jsonelement.html#valuekind) is not [`String`](/api/corvus-text-json-jsonvaluekind.html#string). |

### Remarks

This method is functionally equal to doing an ordinal comparison of `text` and the result of calling [`GetString`](/api/corvus-text-json-jsonelement.html#getstring), but avoids creating the string instance.

---

