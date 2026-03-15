---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.AddPropertyArrayValue Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;long&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-long-array) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;int&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-int-array) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;short&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-short-array) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;sbyte&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-sbyte-array) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;ulong&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-ulong-array) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;uint&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-uint-array) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;ushort&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-ushort-array) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;byte&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-byte-array) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;decimal&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-decimal-array) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;double&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-double-array) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;float&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-float-array) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;Int128&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-int128-array) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;UInt128&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-uint128-array) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;Half&gt;)](#void-addpropertyarrayvalue-string-name-readonlyspan-half-array) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-long-array) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-int-array) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-short-array) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-sbyte-array) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-ulong-array) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-uint-array) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-ushort-array) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-byte-array) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-decimal-array) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-double-array) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-float-array) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-int128-array) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-uint128-array) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;)](#void-addpropertyarrayvalue-readonlyspan-char-name-readonlyspan-half-array) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-long-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-int-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-short-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-sbyte-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-ulong-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-uint-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-ushort-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-byte-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-decimal-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-double-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-float-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-int128-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-uint128-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool)](#void-addpropertyarrayvalue-readonlyspan-byte-utf8name-readonlyspan-half-array-bool-escapename-bool-namerequiresunescaping) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object, with control over escaping. |

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<long> array)
```

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<int> array)
```

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<short> array)
```

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<uint> array)
```

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<byte> array)
```

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<double> array)
```

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<float> array)
```

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(string name, ReadOnlySpan<Half> array)
```

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<long> array)
```

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<int> array)
```

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<short> array)
```

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<sbyte> array)
```

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ulong> array)
```

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<uint> array)
```

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ushort> array)
```

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<byte> array)
```

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<decimal> array)
```

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<double> array)
```

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<float> array)
```

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Int128> array)
```

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<UInt128> array)
```

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Half> array)
```

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

## AddPropertyArrayValue

```csharp
void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object, with control over escaping.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

---

