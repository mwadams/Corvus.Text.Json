---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Utf8JsonPointer — Corvus.Text.Json"
---
```csharp
public readonly struct Utf8JsonPointer
```

## Properties

| Property | Type | Description |
|----------|------|-------------|
| [IsValid](/api/corvus-text-json-utf8jsonpointer.isvalid.html) | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether this is a valid IRI. |

## Methods

| Method | Description |
|--------|-------------|
| [TryCreateJsonPointer(ReadOnlySpan&lt;byte&gt;, ref Utf8JsonPointer)](/api/corvus-text-json-utf8jsonpointer.trycreatejsonpointer.html#trycreatejsonpointer-readonlyspan-byte-ref-utf8jsonpointer) `static` | Tries to create a new UTF-8 JSON Pointer from the specified UTF-8 bytes. |
| [TryGetLineAndOffset(ref T, ref int, ref int, ref long)](/api/corvus-text-json-utf8jsonpointer.trygetlineandoffset.html#trygetlineandoffset-ref-t-ref-int-ref-int-ref-long) | Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the 1-based line number and character offset of the target element in the original source document. |
| [TryResolve(ref T, ref TResult)](/api/corvus-text-json-utf8jsonpointer.tryresolve.html#tryresolve-ref-t-ref-tresult) | Try to resolve the path specified by this JSON Pointer against the provided JSON element, returning the value at that path if it exists. |

