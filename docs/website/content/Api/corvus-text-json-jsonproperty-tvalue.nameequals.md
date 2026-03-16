---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonProperty<TValue>.NameEquals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [NameEquals(string)](#nameequals-string) | Compares `text` to the name of this property. |
| [NameEquals(ReadOnlySpan&lt;byte&gt;)](#nameequals-readonlyspan-byte) | Compares the text represented by `utf8Text` to the name of this property. |
| [NameEquals(ReadOnlySpan&lt;char&gt;)](#nameequals-readonlyspan-char) | Compares `text` to the name of this property. |

## NameEquals(string) {#nameequals-string}

```csharp
public bool NameEquals(string text)
```

Compares `text` to the name of this property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property matches `text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`Type`](https://learn.microsoft.com/dotnet/api/system.type) is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname). |

### Remarks

This method is functionally equal to doing an ordinal comparison of `text` and [`JsonProperty`](/api/corvus-text-json-jsonproperty-tvalue.html#jsonproperty), but can avoid creating the string instance.

---

## NameEquals(ReadOnlySpan&lt;byte&gt;) {#nameequals-readonlyspan-byte}

```csharp
public bool NameEquals(ReadOnlySpan<byte> utf8Text)
```

Compares the text represented by `utf8Text` to the name of this property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Text` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The UTF-8 encoded text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property has the same UTF-8 encoding as `utf8Text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`Type`](https://learn.microsoft.com/dotnet/api/system.type) is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname). |

### Remarks

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`JsonProperty`](/api/corvus-text-json-jsonproperty-tvalue.html#jsonproperty), but can avoid creating the UTF8 string instance.

---

## NameEquals(ReadOnlySpan&lt;char&gt;) {#nameequals-readonlyspan-char}

```csharp
public bool NameEquals(ReadOnlySpan<char> text)
```

Compares `text` to the name of this property.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `text` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The text to compare against. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the name of this property matches `text`, `false` otherwise.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | This value's [`Type`](https://learn.microsoft.com/dotnet/api/system.type) is not [`PropertyName`](/api/corvus-text-json-internal-jsontokentype.html#propertyname). |

### Remarks

This method is functionally equal to doing an ordinal comparison of `utf8Text` and [`JsonProperty`](/api/corvus-text-json-jsonproperty-tvalue.html#jsonproperty), but can avoid creating the UTF-8 string instance.

---

