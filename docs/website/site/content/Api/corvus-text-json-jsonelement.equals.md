---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Equals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Equals(object)](#equals-object) | Determines whether the specified object is equal to the current JsonElement. |
| [Equals(T)](#equals-t) | Determines whether the current JsonElement is equal to another JsonElement-like value through deep comparison. |

## Equals(object) {#equals-object}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L209)

Determines whether the specified object is equal to the current JsonElement.

```csharp
public override bool Equals(object obj)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) | The object to compare with the current JsonElement. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the specified object is equal to the current JsonElement; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Equals(T) {#equals-t}

**Source:** [JsonElement.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/JsonElement.cs#L24)

Determines whether the current JsonElement is equal to another JsonElement-like value through deep comparison.

```csharp
public bool Equals<T>(T other)
```

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the other JSON element that implements IJsonElement. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | `T` | The JSON element to compare with this JsonElement. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the current JsonElement is equal to the other parameter; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

