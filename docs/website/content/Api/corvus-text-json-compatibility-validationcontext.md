---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ValidationContext — Corvus.Text.Json.Compatibility"
---
```csharp
public readonly struct ValidationContext
```

Represents the context for a JSON schema validation operation, including validity and results.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsValid](/api/corvus-text-json-compatibility-validationcontext.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this context represents a valid result. |
| [Results](/api/corvus-text-json-compatibility-validationcontext.results.html) | [`IReadOnlyList<ValidationResult>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ireadonlylist-1) | Gets the validation results. |

## Fields

| Field | Type | Description |
|-------|------|-------------|
| [InvalidContext](/api/corvus-text-json-compatibility-validationcontext.invalidcontext.html) `static` | [`ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html) | Gets an invalid context. |
| [ValidContext](/api/corvus-text-json-compatibility-validationcontext.validcontext.html) `static` | [`ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html) | Gets a valid context. |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

