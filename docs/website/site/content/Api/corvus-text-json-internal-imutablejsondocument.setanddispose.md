---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "IMutableJsonDocument.SetAndDispose Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [IMutableJsonDocument.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/DocumentBuilder/Internal/IMutableJsonDocument.cs#L333)

## SetAndDispose {#setanddispose}

Sets the value of the document and disposes the provided [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html).

```csharp
public abstract void SetAndDispose(ref ComplexValueBuilder cvb)
```

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `cvb` | [`ref ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) | The [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) to set and dispose. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

