---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonEncodedText.Equals Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll  

## Overloads

| Method | Description |
|--------|-------------|
| [Equals(JsonEncodedText)](#equals-jsonencodedtext) | Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value. |
| [Equals(object)](#equals-object) | Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value. |

## Equals(JsonEncodedText) {#equals-jsonencodedtext}

**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L109)

Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value.

```csharp
public bool Equals(JsonEncodedText other)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Implements

[`IEquatable&lt;JsonEncodedText&gt;.Equals`](https://learn.microsoft.com/dotnet/api/system.iequatable.equals)

### Remarks

Default instances of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) are treated as equal.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## Equals(object) {#equals-object}

**Source:** [JsonEncodedText.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/JsonEncodedText.cs#L127)

Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value.

```csharp
public override bool Equals(object obj)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

If `obj` is null, the method returns false.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

