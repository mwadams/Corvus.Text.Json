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
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;long&gt;)](#addpropertyarrayvalue-string-readonlyspan-long) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;int&gt;)](#addpropertyarrayvalue-string-readonlyspan-int) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;short&gt;)](#addpropertyarrayvalue-string-readonlyspan-short) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;sbyte&gt;)](#addpropertyarrayvalue-string-readonlyspan-sbyte) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;ulong&gt;)](#addpropertyarrayvalue-string-readonlyspan-ulong) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;uint&gt;)](#addpropertyarrayvalue-string-readonlyspan-uint) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;ushort&gt;)](#addpropertyarrayvalue-string-readonlyspan-ushort) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;byte&gt;)](#addpropertyarrayvalue-string-readonlyspan-byte) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;decimal&gt;)](#addpropertyarrayvalue-string-readonlyspan-decimal) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;double&gt;)](#addpropertyarrayvalue-string-readonlyspan-double) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;float&gt;)](#addpropertyarrayvalue-string-readonlyspan-float) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;Int128&gt;)](#addpropertyarrayvalue-string-readonlyspan-int128) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;UInt128&gt;)](#addpropertyarrayvalue-string-readonlyspan-uint128) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object. |
| [AddPropertyArrayValue(string, ReadOnlySpan&lt;Half&gt;)](#addpropertyarrayvalue-string-readonlyspan-half) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-long) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-int) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-short) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-sbyte) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-ulong) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-uint) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-ushort) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-byte) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-decimal) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-double) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-float) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-int128) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-uint128) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;)](#addpropertyarrayvalue-readonlyspan-char-readonlyspan-half) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-long-bool-bool) | Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-int-bool-bool) | Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-short-bool-bool) | Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-sbyte-bool-bool) | Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-ulong-bool-bool) | Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-uint-bool-bool) | Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-ushort-bool-bool) | Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-byte-bool-bool) | Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-decimal-bool-bool) | Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-double-bool-bool) | Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-float-bool-bool) | Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-int128-bool-bool) | Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-uint128-bool-bool) | Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object, with control over escaping. |
| [AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool)](#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-half-bool-bool) | Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object, with control over escaping. |

## AddPropertyArrayValue(string, ReadOnlySpan&lt;long&gt;) {#addpropertyarrayvalue-string-readonlyspan-long}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1464)

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;int&gt;) {#addpropertyarrayvalue-string-readonlyspan-int}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1474)

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;short&gt;) {#addpropertyarrayvalue-string-readonlyspan-short}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1484)

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;sbyte&gt;) {#addpropertyarrayvalue-string-readonlyspan-sbyte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1495)

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;ulong&gt;) {#addpropertyarrayvalue-string-readonlyspan-ulong}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1506)

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;uint&gt;) {#addpropertyarrayvalue-string-readonlyspan-uint}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1517)

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;ushort&gt;) {#addpropertyarrayvalue-string-readonlyspan-ushort}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1528)

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;byte&gt;) {#addpropertyarrayvalue-string-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1538)

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;decimal&gt;) {#addpropertyarrayvalue-string-readonlyspan-decimal}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1548)

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;double&gt;) {#addpropertyarrayvalue-string-readonlyspan-double}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1558)

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;float&gt;) {#addpropertyarrayvalue-string-readonlyspan-float}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1568)

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;Int128&gt;) {#addpropertyarrayvalue-string-readonlyspan-int128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1581)

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;UInt128&gt;) {#addpropertyarrayvalue-string-readonlyspan-uint128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1592)

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(string, ReadOnlySpan&lt;Half&gt;) {#addpropertyarrayvalue-string-readonlyspan-half}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1603)

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object.

```csharp
public void AddPropertyArrayValue(string name, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | The property name. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-long}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1615)

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-int}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1639)

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-short}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1663)

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-sbyte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1688)

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-ulong}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1713)

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-uint}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1738)

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-ushort}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1763)

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-byte}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1787)

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-decimal}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1811)

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-double}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1835)

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-float}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1859)

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-int128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1886)

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-uint128}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1911)

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;) {#addpropertyarrayvalue-readonlyspan-char-readonlyspan-half}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1936)

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<char> name, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a character span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-long-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1964)

Adds a property with an array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-int-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L1990)

Adds a property with an array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-short-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2016)

Adds a property with an array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int16`](https://learn.microsoft.com/dotnet/api/system.int16) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-sbyte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2043)

Adds a property with an array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`SByte`](https://learn.microsoft.com/dotnet/api/system.sbyte) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-ulong-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2070)

Adds a property with an array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-uint-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2097)

Adds a property with an array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-ushort-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2124)

Adds a property with an array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt16`](https://learn.microsoft.com/dotnet/api/system.uint16) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-byte-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2150)

Adds a property with an array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Byte`](https://learn.microsoft.com/dotnet/api/system.byte) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-decimal-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2176)

Adds a property with an array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-double-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2202)

Adds a property with an array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Double`](https://learn.microsoft.com/dotnet/api/system.double) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-float-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2228)

Adds a property with an array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Single`](https://learn.microsoft.com/dotnet/api/system.single) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-int128-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2257)

Adds a property with an array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Int128`](https://learn.microsoft.com/dotnet/api/system.int128) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-uint128-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2284)

Adds a property with an array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`UInt128`](https://learn.microsoft.com/dotnet/api/system.uint128) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

## AddPropertyArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool) {#addpropertyarrayvalue-readonlyspan-byte-readonlyspan-half-bool-bool}

**Source:** [ComplexValueBuilder.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/ComplexValueBuilder.cs#L2311)

Adds a property with an array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values to the current object, with control over escaping.

```csharp
public void AddPropertyArrayValue(ReadOnlySpan<byte> utf8Name, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The property name as a UTF-8 byte span. |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The array of [`Half`](https://learn.microsoft.com/dotnet/api/system.half) values. |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether to escape the property name. |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Whether the property name requires unescaping. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

---

