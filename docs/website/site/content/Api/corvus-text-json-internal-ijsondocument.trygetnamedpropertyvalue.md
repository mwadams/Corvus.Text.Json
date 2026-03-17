---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetNamedPropertyValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement)](#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement)](#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref TElement)](#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-telement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref TElement)](#trygetnamedpropertyvalue-int-readonlyspan-char-ref-telement) | Tries to get the value of a named property as a JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref IJsonDocument, ref int)](#trygetnamedpropertyvalue-int-readonlyspan-char-ref-ijsondocument-ref-int) | Tries to get the value of a named property as a mutable JSON element. |
| [TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref IJsonDocument, ref int)](#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-ijsondocument-ref-int) | Tries to get the value of a named property as a mutable JSON element. |

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref JsonElement) {#trygetnamedpropertyvalue-int-readonlyspan-char-ref-jsonelement}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L117)

Tries to get the value of a named property as a JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref JsonElement value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | The value of the property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref JsonElement) {#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-jsonelement}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L117)

Tries to get the value of a named property as a JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref JsonElement value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | [`ref JsonElement`](/api/corvus-text-json-jsonelement.html) | The value of the property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref TElement) {#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-telement}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L21)

Tries to get the value of a named property as a JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, ref TElement value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref TElement) {#trygetnamedpropertyvalue-int-readonlyspan-char-ref-telement}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L21)

Tries to get the value of a named property as a JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<char> propertyName, ref TElement value)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TElement` | The type of the JSON element. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `value` | `ref TElement` | The value of the property. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;char&gt;, ref IJsonDocument, ref int) {#trygetnamedpropertyvalue-int-readonlyspan-char-ref-ijsondocument-ref-int}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L117)

Tries to get the value of a named property as a mutable JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `elementParent` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the retrieved value. |
| `elementIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the retrieved value in the parent document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## TryGetNamedPropertyValue(int, ReadOnlySpan&lt;byte&gt;, ref IJsonDocument, ref int) {#trygetnamedpropertyvalue-int-readonlyspan-byte-ref-ijsondocument-ref-int}

**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L117)

Tries to get the value of a named property as a mutable JSON element.

```csharp
public abstract bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, ref IJsonDocument elementParent, ref int elementIndex)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The name of the property. |
| `elementParent` | [`ref IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the retrieved value. |
| `elementIndex` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the retrieved value in the parent document. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the property value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

