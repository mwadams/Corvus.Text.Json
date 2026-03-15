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
| [Scheme](/api/corvus-text-json-internal-utf8uricomponents.scheme.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The scheme part of the URI. |
| [UserInfo](/api/corvus-text-json-internal-utf8uricomponents.userinfo.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The user information part of the URI. |
| [Host](/api/corvus-text-json-internal-utf8uricomponents.host.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The host part of the URI. |
| [Port](/api/corvus-text-json-internal-utf8uricomponents.port.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The port part of the URI. |
| [Path](/api/corvus-text-json-internal-utf8uricomponents.path.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The path part of the URI. |
| [Query](/api/corvus-text-json-internal-utf8uricomponents.query.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The query part of the URI. |
| [Fragment](/api/corvus-text-json-internal-utf8uricomponents.fragment.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The fragment part of the URI. |
| [StrongPort](/api/corvus-text-json-internal-utf8uricomponents.strongport.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The port part of the URI, including default ports. |
| [NormalizedHost](/api/corvus-text-json-internal-utf8uricomponents.normalizedhost.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The normalized host part of the URI. |
| [KeepDelimiter](/api/corvus-text-json-internal-utf8uricomponents.keepdelimiter.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | This will also return respective delimiters for scheme, userinfo or port. Valid only for a single component requests. |
| [SerializationInfoString](/api/corvus-text-json-internal-utf8uricomponents.serializationinfostring.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | This is used by GetObjectData and can also be used directly. Works for both absolute and relative URIs. |
| [AbsoluteUri](/api/corvus-text-json-internal-utf8uricomponents.absoluteuri.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | All components of an absolute URI. |
| [HostAndPort](/api/corvus-text-json-internal-utf8uricomponents.hostandport.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The host and port components, including default ports. |
| [StrongAuthority](/api/corvus-text-json-internal-utf8uricomponents.strongauthority.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The user info, host, and port components, including default ports. |
| [SchemeAndServer](/api/corvus-text-json-internal-utf8uricomponents.schemeandserver.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The scheme, host, and port components. |
| [HttpRequestUrl](/api/corvus-text-json-internal-utf8uricomponents.httprequesturl.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The components typically used in HTTP request URLs. |
| [PathAndQuery](/api/corvus-text-json-internal-utf8uricomponents.pathandquery.html) `static` | [`Utf8UriComponents`](/api/corvus-text-json-internal-utf8uricomponents.html) | The path and query components. |

