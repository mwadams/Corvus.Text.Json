---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IJsonDocument.TryGetString Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## TryGetString {#trygetstring}

```csharp
bool TryGetString(int index, JsonTokenType expectedType, ref string result)
```

Tries to get the string value of the element at the specified index.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `index` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The index of the element. |
| `expectedType` | [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) | The expected JSON token type. |
| `result` | [`ref string`](https://learn.microsoft.com/dotnet/api/system.string) | The string value, or `null` if the value was not retrieved. |

### Returns

[`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`true` if the value was retrieved; otherwise, `false`.

