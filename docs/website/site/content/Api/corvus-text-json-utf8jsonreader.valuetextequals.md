---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonReader.ValueTextEquals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [ValueTextEquals(ReadOnlySpan&lt;byte&gt;)](#valuetextequals-readonlyspan-byte) | Compares the UTF-8 encoded text to the unescaped JSON token value in the source and returns true if they match. |
| [ValueTextEquals(string)](#valuetextequals-string) | Compares the string text to the unescaped JSON token value in the source and returns true if they match. |
| [ValueTextEquals(ReadOnlySpan&lt;char&gt;)](#valuetextequals-readonlyspan-char) | Compares the text to the unescaped JSON token value in the source and returns true if they match. |

## ValueTextEquals(ReadOnlySpan&lt;byte&gt;) {#valuetextequals-readonlyspan-byte}

**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L480)

Compares the UTF-8 encoded text to the unescaped JSON token value in the source and returns true if they match.

```csharp
public bool ValueTextEquals(ReadOnlySpan<byte> utf8Text)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the UTF-8 encoded look up text.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname)). |

### Remarks

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ValueTextEquals(string) {#valuetextequals-string}

**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L510)

Compares the string text to the unescaped JSON token value in the source and returns true if they match.

```csharp
public bool ValueTextEquals(string text)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the look up text.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname)). |

### Remarks

If the look up text is invalid UTF-8 text, the method will return false since you cannot have invalid UTF-8 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## ValueTextEquals(ReadOnlySpan&lt;char&gt;) {#valuetextequals-readonlyspan-char}

**Source:** [Utf8JsonReader.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Reader/Utf8JsonReader.cs#L551)

Compares the text to the unescaped JSON token value in the source and returns true if they match.

```csharp
public bool ValueTextEquals(ReadOnlySpan<char> text)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if the JSON token value in the source matches the look up text.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if trying to find a text match on a JSON token that is not a string (i.e. other than [`String`](/api/corvus-text-json-internal-jsontokentype.html#string) or [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname)). |

### Remarks

If the look up text is invalid or incomplete UTF-16 text (i.e. unpaired surrogates), the method will return false since you cannot have invalid UTF-16 within the JSON payload. The comparison of the JSON token value in the source and the look up text is done by first unescaping the JSON value in source, if required. The look up text is matched as is, without any modifications to it.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

