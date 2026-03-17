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
| [AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool)](#addasproperty-readonlyspan-byte-ref-complexvaluebuilder-bool-bool) |  |
| [AddAsProperty(string, ref ComplexValueBuilder)](#addasproperty-string-ref-complexvaluebuilder) |  |
| [AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder)](#addasproperty-readonlyspan-char-ref-complexvaluebuilder) |  |

## AddAsProperty(ReadOnlySpan&lt;byte&gt;, ref ComplexValueBuilder, bool, bool) {#addasproperty-readonlyspan-byte-ref-complexvaluebuilder-bool-bool}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1343)

```csharp
public void AddAsProperty(ReadOnlySpan<byte> utf8Name, ref ComplexValueBuilder valueBuilder, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `utf8Name` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddAsProperty(string, ref ComplexValueBuilder) {#addasproperty-string-ref-complexvaluebuilder}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1370)

```csharp
public void AddAsProperty(string name, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

## AddAsProperty(ReadOnlySpan&lt;char&gt;, ref ComplexValueBuilder) {#addasproperty-readonlyspan-char-ref-complexvaluebuilder}

**Source:** [JsonElement.Mutable.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/JsonElement.Mutable.cs#L1380)

```csharp
public void AddAsProperty(ReadOnlySpan<char> name, ref ComplexValueBuilder valueBuilder)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `name` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `valueBuilder` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

---

