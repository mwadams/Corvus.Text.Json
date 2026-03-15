---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ValidationResult — Corvus.Text.Json.Compatibility"
---
```csharp
public readonly struct ValidationResult
```

Represents the result of a single JSON schema validation, including validity, message, and locations.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Location` | `ValidationResult.LocationTuple` | Gets the location information for this validation result. |
| `Message` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) | Gets the validation message for this result, if any. |
| `Valid` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the validation result is valid. |


### ValidationResult.LocationTuple (struct)

```csharp
public readonly struct ValidationResult.LocationTuple
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `DocumentLocation` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `SchemaLocation` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |
| `ValidationLocation` | [`Utf8IriReference`](/api/corvus-text-json-utf8irireference.html) |  |

---

