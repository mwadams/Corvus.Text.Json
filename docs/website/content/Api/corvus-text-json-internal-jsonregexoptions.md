---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonRegexOptions — Corvus.Text.Json.Internal"
---
```csharp
public enum JsonRegexOptions : IComparable, ISpanFormattable, IFormattable, IConvertible
```

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `None` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Use default behavior. |
| `IgnoreCase` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Use case-insensitive matching. |
| `Multiline` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Use multiline mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string). |
| `ExplicitCapture` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Do not capture unnamed groups. The only valid captures are explicitly named or numbered groups of the form (?<name> subexpression). |
| `Compiled` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Compile the regular expression to Microsoft intermediate language (MSIL). |
| `Singleline` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Use single-line mode, where the period (.) matches every character (instead of every character except \n). |
| `IgnorePatternWhitespace` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Exclude unescaped white space from the pattern, and enable comments after a number sign (#). |
| `RightToLeft` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Change the search direction. Search moves from right to left instead of from left to right. |
| `ECMAScript` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Enable ECMAScript-compliant behavior for the expression. |
| `CultureInvariant` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Ignore cultural differences in language. |
| `NonBacktracking` `static` | [`JsonRegexOptions`](/api/corvus-text-json-internal-jsonregexoptions.html) | Enable matching using an approach that avoids backtracking and guarantees linear-time processing in the length of the input. |

