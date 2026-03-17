---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementTensorHelpers.TryCopyArrayOfRankTo Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;long&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-long-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;ulong&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-ulong-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;int&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-int-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;uint&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-uint-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;short&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-short-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;ushort&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-ushort-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;sbyte&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-sbyte-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;byte&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-byte-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;double&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-double-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;float&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-float-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;decimal&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-decimal-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;Int128&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-int128-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;UInt128&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-uint128-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |
| [TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;Half&gt;, int, ref int)](#trycopyarrayofrankto-ijsondocument-int-span-half-int-ref-int) | Tries to copy the higher-rank array data from the instance to the given array. |

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;long&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-long-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<long> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<long>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;ulong&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-ulong-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ulong> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<ulong>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;int&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-int-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<int> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<int>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;uint&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-uint-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<uint> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<uint>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;short&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-short-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<short> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<short>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;ushort&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-ushort-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<ushort> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<ushort>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;sbyte&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-sbyte-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<sbyte> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<sbyte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;byte&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-byte-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<byte> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<byte>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;double&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-double-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<double> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<double>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;float&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-float-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<float> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<float>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;decimal&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-decimal-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<decimal> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<decimal>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;Int128&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-int128-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Int128> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<Int128>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;UInt128&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-uint128-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<UInt128> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<UInt128>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## TryCopyArrayOfRankTo(IJsonDocument, int, Span&lt;Half&gt;, int, ref int) {#trycopyarrayofrankto-ijsondocument-int-span-half-int-ref-int}

```csharp
public static bool TryCopyArrayOfRankTo(IJsonDocument parentDocument, int parentDocumentIndex, Span<Half> array, int rank, ref int written)
```

Tries to copy the higher-rank array data from the instance to the given array.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IJsonDocument`](/api/corvus-text-json-internal-ijsondocument.html) | The parent document of the JSON array instance. |
| `parentDocumentIndex` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The parent document index of the JSON array instance. |
| `array` | [`Span<Half>`](https://learn.microsoft.com/dotnet/api/system.span-1) | The target array. |
| `rank` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The rank of the array (e.g. \[,\] == rank 2, \[,,,\] == rank 3 etc.) |
| `written` | [`ref int`](https://learn.microsoft.com/dotnet/api/system.int32) | The number of values written. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if it was able to copy the values to the target array, otherwise false.

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | The element was not a JSON array of the target type and rank. |
| [`FormatException`](https://learn.microsoft.com/dotnet/api/system.formatexception) | An item in the array was not of the target numeric format. |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

