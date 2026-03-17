---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json.Compatibility Namespace"
---
Backward-compatibility shims for migrating from Corvus.Json V4 (based on `System.Text.Json`). These types map V4's [`ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html), [`ValidationResult`](/api/corvus-text-json-compatibility-validationresult.html), and [`ValidationLevel`](/api/corvus-text-json-compatibility-validationlevel.html) to V5 equivalents, allowing existing code to compile with minimal changes during migration.

| Type | Kind | Description |
|------|------|-------------|
| [Polyfills](/api/corvus-text-json-compatibility-polyfills.html) | class | Provides polyfills for Corvus.JsonSchema API compatibility. |
| [ValidationContext](/api/corvus-text-json-compatibility-validationcontext.html) | struct | Represents the context for a JSON schema validation operation, including validity and results. |
| [ValidationLevel](/api/corvus-text-json-compatibility-validationlevel.html) | enum | The validation level. |
| [ValidationResult](/api/corvus-text-json-compatibility-validationresult.html) | struct | Represents the result of a single JSON schema validation, including validity, message, and locations. |
| [ValidationResult.LocationTuple](/api/corvus-text-json-compatibility-validationresult-locationtuple.html) | struct |  |

