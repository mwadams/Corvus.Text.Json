---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.Source<TContext>.AddAsProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool)](#void-addasproperty-readonlyspan-byte-utf8name-ref-complexvaluebuilder-valuebuilder-bool-escapename-bool-namerequiresunescaping) |  |
| [AddAsProperty(string, ref ComplexValueBuilder)](#void-addasproperty-string-name-ref-complexvaluebuilder-valuebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder)](#void-addasproperty-readonlyspan-char-name-ref-complexvaluebuilder-valuebuilder) |  |

## AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## AddAsProperty

```csharp
void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

## AddAsProperty

```csharp
void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

---

