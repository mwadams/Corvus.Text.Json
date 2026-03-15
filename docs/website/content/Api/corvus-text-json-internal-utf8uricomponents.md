---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8UriComponents — Corvus.Text.Json.Internal"
---
```csharp
public enum Utf8UriComponents : IComparable, ISpanFormattable, IFormattable, IConvertible
```

Specifies the parts of a URI that should be included when retrieving URI components.

## Implements

[`IComparable`](https://learn.microsoft.com/dotnet/api/system.icomparable), [`ISpanFormattable`](https://learn.microsoft.com/dotnet/api/system.ispanformattable), [`IFormattable`](https://learn.microsoft.com/dotnet/api/system.iformattable), [`IConvertible`](https://learn.microsoft.com/dotnet/api/system.iconvertible)

## Fields

| Field | Type | Description |
|-------|------|-------------|
| `Scheme` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The scheme part of the URI. |
| `UserInfo` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The user information part of the URI. |
| `Host` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The host part of the URI. |
| `Port` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The port part of the URI. |
| `Path` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The path part of the URI. |
| `Query` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The query part of the URI. |
| `Fragment` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The fragment part of the URI. |
| `StrongPort` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The port part of the URI, including default ports. |
| `NormalizedHost` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The normalized host part of the URI. |
| `KeepDelimiter` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | This will also return respective delimiters for scheme, userinfo or port. Valid only for a single component requests. |
| `SerializationInfoString` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | This is used by GetObjectData and can also be used directly. Works for both absolute and relative URIs. |
| `AbsoluteUri` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | All components of an absolute URI. |
| `HostAndPort` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The host and port components, including default ports. |
| `StrongAuthority` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The user info, host, and port components, including default ports. |
| `SchemeAndServer` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The scheme, host, and port components. |
| `HttpRequestUrl` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The components typically used in HTTP request URLs. |
| `PathAndQuery` `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The path and query components. |

