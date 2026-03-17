---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonWriter.WriteNumberValue Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [WriteNumberValue(decimal)](#writenumbervalue-decimal) | Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(double)](#writenumbervalue-double) | Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(float)](#writenumbervalue-float) | Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(int)](#writenumbervalue-int) | Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(long)](#writenumbervalue-long) | Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(uint)](#writenumbervalue-uint) | Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as an element of a JSON array. |
| [WriteNumberValue(ulong)](#writenumbervalue-ulong) | Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as an element of a JSON array. |

## WriteNumberValue(decimal) {#writenumbervalue-decimal}

**Source:** [Utf8JsonWriter.WriteValues.Decimal.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Decimal.cs#L30)

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(decimal value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Decimal`](https://learn.microsoft.com/dotnet/api/system.decimal) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G').

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(double) {#writenumbervalue-double}

**Source:** [Utf8JsonWriter.WriteValues.Double.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Double.cs#L32)

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(double value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`double`](https://learn.microsoft.com/dotnet/api/system.double) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Double`](https://learn.microsoft.com/dotnet/api/system.double) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) on .NET Core 3 or higher and 'G17' on any other framework.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(float) {#writenumbervalue-float}

**Source:** [Utf8JsonWriter.WriteValues.Float.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.Float.cs#L32)

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(float value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`float`](https://learn.microsoft.com/dotnet/api/system.single) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Single`](https://learn.microsoft.com/dotnet/api/system.single) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) on .NET Core 3 or higher and 'G9' on any other framework.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(int) {#writenumbervalue-int}

**Source:** [Utf8JsonWriter.WriteValues.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.SignedNumber.cs#L29)

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(int value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int32`](https://learn.microsoft.com/dotnet/api/system.int32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(long) {#writenumbervalue-long}

**Source:** [Utf8JsonWriter.WriteValues.SignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.SignedNumber.cs#L43)

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(long value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`long`](https://learn.microsoft.com/dotnet/api/system.int64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`Int64`](https://learn.microsoft.com/dotnet/api/system.int64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(uint) {#writenumbervalue-uint}

**Source:** [Utf8JsonWriter.WriteValues.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.UnsignedNumber.cs#L30)

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(uint value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`uint`](https://learn.microsoft.com/dotnet/api/system.uint32) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt32`](https://learn.microsoft.com/dotnet/api/system.uint32) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## WriteNumberValue(ulong) {#writenumbervalue-ulong}

**Source:** [Utf8JsonWriter.WriteValues.UnsignedNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Writer/Utf8JsonWriter.WriteValues.UnsignedNumber.cs#L45)

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) value (as a JSON number) as an element of a JSON array.

```csharp
public void WriteNumberValue(ulong value)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ulong`](https://learn.microsoft.com/dotnet/api/system.uint64) | The value to write. |

### Exceptions

| Exception | Description |
|-----------|-------------|
| [`InvalidOperationException`](https://learn.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown if this would result in invalid JSON being written (while validation is enabled). |

### Remarks

Writes the [`UInt64`](https://learn.microsoft.com/dotnet/api/system.uint64) using the default [`StandardFormat`](https://learn.microsoft.com/dotnet/api/system.buffers.standardformat) (that is, 'G'), for example: 32767.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

