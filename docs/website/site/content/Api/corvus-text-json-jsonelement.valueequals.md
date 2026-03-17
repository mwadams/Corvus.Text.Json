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

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2029)

Compares `text` to the string value of this element.

```csharp
public bool ValueEquals(string text)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ValueEquals(ReadOnlySpan&lt;byte&gt;) {#valueequals-readonlyspan-byte}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2056)

Compares the text represented by `utf8Text` to the string value of this element.

```csharp
public bool ValueEquals(ReadOnlySpan<byte> utf8Text)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ValueEquals(ReadOnlySpan&lt;char&gt;) {#valueequals-readonlyspan-char}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L2085)

Compares `text` to the string value of this element.

```csharp
public bool ValueEquals(ReadOnlySpan<char> text)
```

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

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

