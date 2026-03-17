---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementForBooleanFalseSchema.Equals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [Equals(object)](#equals-object) | Determines whether the specified object is equal to the current instance. |
| [Equals(T)](#equals-t) | Determines whether the specified JSON element is equal to the current instance. |

## Equals(object) {#equals-object}

```csharp
public override bool Equals(object obj)
```

Determines whether the specified object is equal to the current instance.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with the current instance. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified object is equal to the current instance; otherwise, `false`.

---

## Equals(T) {#equals-t}

```csharp
public bool Equals<T>(T other)
```

Determines whether the specified JSON element is equal to the current instance.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the JSON element to compare. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` | The JSON element to compare with the current instance. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified JSON element is equal to the current instance; otherwise, `false`.

---

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

