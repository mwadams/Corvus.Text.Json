---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ComplexValueBuilder.Create Method — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll

## Create {#create}

```csharp
public static ComplexValueBuilder Create(IMutableJsonDocument parentDocument, int initialElementCount)
```

Creates a new [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) for the specified parent document, pre-allocating space for the given number of elements.

### Parameters

| Name | Type | Description |
|------|------|-------------|
| `parentDocument` | [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) | The parent [`IMutableJsonDocument`](/api/corvus-text-json-internal-imutablejsondocument.html) to build into. |
| `initialElementCount` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) | The estimated number of elements to allocate space for. |

### Returns

[`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html)

A new [`ComplexValueBuilder`](/api/corvus-text-json-internal-complexvaluebuilder.html) instance.

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

