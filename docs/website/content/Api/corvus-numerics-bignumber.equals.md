---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "BigNumber.Equals Method — Corvus.Numerics"
---
## Definition

**Namespace:** Corvus.Numerics  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Equals(BigNumber)](#equals-bignumber) | Determines whether the specified [`BigNumber`](/api/corvus-numerics-bignumber.html) is equal to this instance. |
| [Equals(object)](#equals-object) | Determines whether the specified object is equal to this instance. |

## Equals(BigNumber) {#equals-bignumber}

```csharp
public bool Equals(BigNumber other)
```

Determines whether the specified [`BigNumber`](/api/corvus-numerics-bignumber.html) is equal to this instance.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`BigNumber`](/api/corvus-numerics-bignumber.html) | The [`BigNumber`](/api/corvus-numerics-bignumber.html) to compare with this instance. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified value is equal to this instance; otherwise, `false`.

### Implements

[`IEquatable&lt;BigNumber&gt;.Equals`](https://learn.microsoft.com/dotnet/api/system.iequatable.equals)

---

## Equals(object) {#equals-object}

```csharp
public override bool Equals(object obj)
```

Determines whether the specified object is equal to this instance.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with this instance. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified object is a [`BigNumber`](/api/corvus-numerics-bignumber.html) equal to this instance; otherwise, `false`.

---

