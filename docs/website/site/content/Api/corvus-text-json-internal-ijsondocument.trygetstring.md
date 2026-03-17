---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Document/Internal/IJsonDocument.cs#L185)

## TryGetString {#trygetstring}

Tries to get the string value of the element at the specified index.

```csharp
public abstract bool TryGetString(int index, JsonTokenType expectedType, ref string result)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | The string value, or `null` if the value was not retrieved. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

