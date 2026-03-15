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
| [Equals(JsonEncodedText)](#bool-equals-jsonencodedtext-other) | Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value. |
| [Equals(object)](#bool-equals-object-obj) | Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value. |

## Equals

```csharp
bool Equals(JsonEncodedText other)
```

Determines whether this instance and another specified [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance have the same value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `other` | [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

Default instances of [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) are treated as equal.

---

## Equals `virtual`

```csharp
bool Equals(object obj)
```

Determines whether this instance and a specified object, which must also be a [`JsonEncodedText`](/api/corvus-text-json-jsonencodedtext.html) instance, have the same value.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `obj` | [`object`](https://learn.microsoft.com/dotnet/api/system.object) |  |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### Remarks

If `obj` is null, the method returns false.

---

