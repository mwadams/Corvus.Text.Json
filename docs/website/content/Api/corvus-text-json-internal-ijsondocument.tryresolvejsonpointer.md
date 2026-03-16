---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryResolveJsonPointer Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryResolveJsonPointer {#tryresolvejsonpointer}

```csharp
public abstract bool TryResolveJsonPointer<TValue>(ReadOnlySpan<byte> jsonPointer, int index, ref TValue value)
```

Try to resolve the given JSON pointer.

### Type Parameters

| Parameter | Description |
|-----------|-------------|
| `TValue` | The type of the target value. |

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `jsonPointer` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) | The JSON pointer to resolve. |
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `value` | `ref TValue` | Providers the resolved value, if the pointer could be resolved. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the pointer could be resolved, otherwise `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

