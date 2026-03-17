---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ValidationResult — Corvus.Text.Json.Compatibility"
---
## Definition

**Namespace:** Corvus.Text.Json.Compatibility  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [ValidationResult.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Compatibility/ValidationResult.cs#L16)

Represents the result of a single JSON schema validation, including validity, message, and locations.

```csharp
public readonly struct ValidationResult
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [Location](/api/corvus-text-json-compatibility-validationresult.location.html) | [`ValidationResult.LocationTuple`](/api/corvus-text-json-compatibility-validationresult-locationtuple.html) | Gets the location information for this validation result. |
| [Message](/api/corvus-text-json-compatibility-validationresult.message.html) | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets the validation message for this result, if any. |
| [Valid](/api/corvus-text-json-compatibility-validationresult.valid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the validation result is valid. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

