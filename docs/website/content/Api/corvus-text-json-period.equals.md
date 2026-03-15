---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Period.Equals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Equals(object)](#bool-equals-object-other) | Compares the given object for equality with this one, as per [`Equals`](/api/corvus-text-json-period.html#equals). See the type documentation for a description of equality semantics. |
| [Equals(Period)](#bool-equals-period-other) | Compares the given period for equality with this one. See the type documentation for a description of equality semantics. |
| [Equals(Period)](#bool-equals-period-other) | Compares the given period for equality with this one. See the type documentation for a description of equality semantics. |

## Equals `virtual`

```csharp
bool Equals(object other)
```

Compares the given object for equality with this one, as per [`Equals`](/api/corvus-text-json-period.html#equals). See the type documentation for a description of equality semantics.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The value to compare this one with. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

true if the other object is a period equal to this one, consistent with [`Equals`](/api/corvus-text-json-period.html#equals).

---

## Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`Period`](/api/corvus-text-json-period.html) | The period to compare this one with. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if this period has the same values for the same properties as the one specified.

---

## Equals

```csharp
bool Equals(Period other)
```

Compares the given period for equality with this one. See the type documentation for a description of equality semantics.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`Period`](https://www.nodatime.org/3.3.x/api/NodaTime.Period.html) | The period to compare this one with. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

True if this period has the same values for the same properties as the one specified.

---

