---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementTensorHelpers.TryCopyTo Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryCopyTo(IJsonDocument, int, Span&lt;long&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-long-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;ulong&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-ulong-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;int&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-int-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;uint&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-uint-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;short&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-short-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;ushort&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-ushort-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;sbyte&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-sbyte-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;byte&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-byte-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;double&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-double-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;float&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-float-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;decimal&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-decimal-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;Int128&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-int128-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;UInt128&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-uint128-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |
| [TryCopyTo(IJsonDocument, int, Span&lt;Half&gt;, ref int)](#bool-trycopyto-ijsondocument-parentdocument-int-parentdocumentindex-span-half-array-ref-int-written) | Tries to copy the array data from the instance to the given array. |

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<long> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<long>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ulong> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<ulong>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<int> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<uint> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<uint>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<short> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<short>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ushort> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<ushort>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<sbyte> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<sbyte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<byte> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<double> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<double>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<float> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<float>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<decimal> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<decimal>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Int128> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<Int128>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<UInt128> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<UInt128>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyTo `static`

```csharp
bool TryCopyTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Half> array, ref int written)
```

Tries to copy the array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<Half>`](https://learn.microsoft.com/dotnet/api/system.span-1) |  |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

