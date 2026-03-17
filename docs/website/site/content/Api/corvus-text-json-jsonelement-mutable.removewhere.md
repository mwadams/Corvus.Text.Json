---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Mutable.RemoveWhere Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [RemoveWhere(JsonPredicate&lt;T&gt;)](#removewhere-jsonpredicate-t) |  |
| [RemoveWhere(JsonPredicate&lt;JsonElement&gt;)](#removewhere-jsonpredicate-jsonelement) |  |

## RemoveWhere(JsonPredicate&lt;T&gt;) {#removewhere-jsonpredicate-t}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1738)

```csharp
public void RemoveWhere<T>(JsonPredicate<T> predicate)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `predicate` | [`JsonPredicate<T>`](/api/corvus-text-json-jsonpredicate-t.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## RemoveWhere(JsonPredicate&lt;JsonElement&gt;) {#removewhere-jsonpredicate-jsonelement}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L5909)

```csharp
public void RemoveWhere(JsonPredicate<JsonElement> predicate)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `predicate` | [`JsonPredicate<JsonElement>`](/api/corvus-text-json-jsonpredicate-t.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

