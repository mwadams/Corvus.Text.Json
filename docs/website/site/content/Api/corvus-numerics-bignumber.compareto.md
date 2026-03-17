---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.CompareTo Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [CompareTo(BigNumber)](#compareto-bignumber) | Compares this instance with another [`BigNumber`](/api/corvus-numerics-bignumber.html) value. |
| [CompareTo(object)](#compareto-object) | Compares this instance with a specified object. |

## CompareTo(BigNumber) {#compareto-bignumber}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L305)

Compares this instance with another [`BigNumber`](/api/corvus-numerics-bignumber.html) value.

```csharp
public int CompareTo(BigNumber other)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) to compare with this instance. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

A value that indicates the relative order of the values being compared.

### Implements

[`IComparable&lt;BigNumber&gt;.CompareTo`](https://learn.microsoft.com/dotnet/api/system.icomparable.compareto)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## CompareTo(object) {#compareto-object}

**Source:** [BigNumber.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Numerics/BigNumber.cs#L364)

Compares this instance with a specified object.

```csharp
public int CompareTo(object obj)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with this instance. |

### Returns

[`int`](https://learn.microsoft.com/dotnet/api/system.int32)

A value that indicates the relative order of the values being compared.

### Implements

[`IComparable.CompareTo`](https://learn.microsoft.com/dotnet/api/system.icomparable.compareto)

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

