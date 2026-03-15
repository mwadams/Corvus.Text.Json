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
| [AddArrayValue(string, ReadOnlySpan&lt;long&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-long-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;int&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-int-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;short&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-short-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;sbyte&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-sbyte-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;ulong&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-ulong-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;uint&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-uint-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;ushort&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-ushort-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;byte&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-byte-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;decimal&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-decimal-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;double&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-double-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;float&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-float-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;Int128&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-int128-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;UInt128&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-uint128-array) |  |
| [AddArrayValue(string, ReadOnlySpan&lt;Half&gt;)](#void-addarrayvalue-string-propertyname-readonlyspan-half-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;long&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-long-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;int&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-int-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;short&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-short-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;sbyte&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-sbyte-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ulong&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-ulong-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;uint&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-uint-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;ushort&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-ushort-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;byte&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-byte-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;decimal&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-decimal-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;double&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-double-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;float&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-float-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Int128&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-int128-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;UInt128&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-uint128-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;char&gt;, ReadOnlySpan&lt;Half&gt;)](#void-addarrayvalue-readonlyspan-char-propertyname-readonlyspan-half-array) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;long&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-long-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;int&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-int-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;short&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-short-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;sbyte&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-sbyte-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ulong&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-ulong-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;uint&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-uint-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;ushort&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-ushort-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-byte-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;decimal&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-decimal-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;double&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-double-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;float&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-float-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Int128&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-int128-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;UInt128&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-uint128-array-bool-escapename-bool-namerequiresunescaping) |  |
| [AddArrayValue(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;Half&gt;, bool, bool)](#void-addarrayvalue-readonlyspan-byte-propertyname-readonlyspan-half-array-bool-escapename-bool-namerequiresunescaping) |  |

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(string propertyName, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<long> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<int> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<short> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<sbyte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ulong> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<uint> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<ushort> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<byte> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<decimal> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<double> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<float> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Int128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<UInt128> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<char> propertyName, ReadOnlySpan<Half> array)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<long> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<long>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<int> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<int>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<short> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<short>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<sbyte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<sbyte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ulong> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ulong>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<uint> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<uint>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<ushort> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<ushort>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<decimal> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<decimal>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<double> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<double>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<float> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<float>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Int128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Int128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<UInt128> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<UInt128>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddArrayValue

```csharp
void AddArrayValue(ReadOnlySpan<byte> propertyName, ReadOnlySpan<Half> array, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `array` | [`ReadOnlySpan<Half>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

