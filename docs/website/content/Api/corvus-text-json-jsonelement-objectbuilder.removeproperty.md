---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElement.ObjectBuilder.RemoveProperty Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## Overloads

| Method | Description |
|--------|-------------|
| [RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool)](#removeproperty-readonlyspan-byte-bool-bool) |  |
| [RemoveProperty(ReadOnlySpan&lt;char&gt;)](#removeproperty-readonlyspan-char) |  |
| [RemoveProperty(string)](#removeproperty-string) |  |

## RemoveProperty(ReadOnlySpan&lt;byte&gt;, bool, bool) {#removeproperty-readonlyspan-byte-bool-bool}

```csharp
public void RemoveProperty(ReadOnlySpan<byte> propertyName, bool escapeName, bool nameRequiresUnescaping)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `escapeName` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |
| `nameRequiresUnescaping` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  *(optional)* |

---

## RemoveProperty(ReadOnlySpan&lt;char&gt;) {#removeproperty-readonlyspan-char}

```csharp
public void RemoveProperty(ReadOnlySpan<char> propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`ReadOnlySpan<char>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

---

## RemoveProperty(string) {#removeproperty-string}

```csharp
public void RemoveProperty(string propertyName)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `propertyName` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |

---

