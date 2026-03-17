---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.AddArrayValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddArrayValue(string, ReadOnlySpan&lt;long&gt;)](#addarrayvalue-string-readonlyspan-long) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;int&gt;)](#addarrayvalue-string-readonlyspan-int) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;short&gt;)](#addarrayvalue-string-readonlyspan-short) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;sbyte&gt;)](#addarrayvalue-string-readonlyspan-sbyte) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;ulong&gt;)](#addarrayvalue-string-readonlyspan-ulong) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;uint&gt;)](#addarrayvalue-string-readonlyspan-uint) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;ushort&gt;)](#addarrayvalue-string-readonlyspan-ushort) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;byte&gt;)](#addarrayvalue-string-readonlyspan-byte) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;decimal&gt;)](#addarrayvalue-string-readonlyspan-decimal) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;double&gt;)](#addarrayvalue-string-readonlyspan-double) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;float&gt;)](#addarrayvalue-string-readonlyspan-float) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;Int128&gt;)](#addarrayvalue-string-readonlyspan-int128) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;UInt128&gt;)](#addarrayvalue-string-readonlyspan-uint128) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;Half&gt;)](#addarrayvalue-string-readonlyspan-half) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-long) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-int) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-short) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-sbyte) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-ulong) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-uint) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-ushort) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-byte) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-decimal) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-double) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-float) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-int128) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-uint128) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;)](#addarrayvalue-readonlyspan-char-readonlyspan-half) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-long-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-int-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-short-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-sbyte-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-ulong-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-uint-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-ushort-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-byte-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-decimal-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-double-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-float-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-int128-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-uint128-bool-bool) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool)](#addarrayvalue-readonlyspan-byte-readonlyspan-half-bool-bool) |  |

## AddArrayValue(string, ReadOnlySpan&lt;long&gt;) {#addarrayvalue-string-readonlyspan-long}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;int&gt;) {#addarrayvalue-string-readonlyspan-int}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;short&gt;) {#addarrayvalue-string-readonlyspan-short}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;sbyte&gt;) {#addarrayvalue-string-readonlyspan-sbyte}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;ulong&gt;) {#addarrayvalue-string-readonlyspan-ulong}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;uint&gt;) {#addarrayvalue-string-readonlyspan-uint}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;ushort&gt;) {#addarrayvalue-string-readonlyspan-ushort}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;byte&gt;) {#addarrayvalue-string-readonlyspan-byte}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;decimal&gt;) {#addarrayvalue-string-readonlyspan-decimal}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;double&gt;) {#addarrayvalue-string-readonlyspan-double}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;float&gt;) {#addarrayvalue-string-readonlyspan-float}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;Int128&gt;) {#addarrayvalue-string-readonlyspan-int128}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;UInt128&gt;) {#addarrayvalue-string-readonlyspan-uint128}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(string, ReadOnlySpan&lt;Half&gt;) {#addarrayvalue-string-readonlyspan-half}

```csharp
public void AddArrayValue(string propertyName, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-long}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-int}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-short}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-sbyte}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-ulong}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-uint}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-ushort}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-byte}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-decimal}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-double}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-float}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-int128}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-uint128}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;) {#addarrayvalue-readonlyspan-char-readonlyspan-half}

```csharp
public void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-long-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-int-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-short-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-sbyte-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-ulong-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-uint-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-ushort-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-byte-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-decimal-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-double-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-float-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-int128-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-uint128-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool) {#addarrayvalue-readonlyspan-byte-readonlyspan-half-bool-bool}

```csharp
public void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |

