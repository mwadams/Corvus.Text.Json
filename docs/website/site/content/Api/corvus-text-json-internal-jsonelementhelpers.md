---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementHelpers — Corvus.Text.Json.Internal"
---
## Definition

**Namespace:** Corvus.Text.Json.Internal  
**Assembly:** Corvus.Text.Json.dll  
**Source:** [JsonElementHelpers.cs](https://github.com/mwadams/Corvus.Text.Json/blob/main/src/Corvus.Text.Json/Corvus/Text/Json/Internal/JsonElementHelpers.cs#L29)

Core helper methods for parsing and processing JSON numeric values into their component parts.

```csharp
public static class JsonElementHelpers
```

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElementHelpers**

## Methods

| Method | Description |
|--------|-------------|
| [ApplyUnsafe(TTarget, ref TSource)](/api/corvus-text-json-internal-jsonelementhelpers.applyunsafe.html#applyunsafe-ttarget-ref-tsource) `static` | Applies all properties from a source JSON object element to a target JSON object element. |
| [AreEqualJsonNumbers(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.areequaljsonnumbers.html#areequaljsonnumbers-readonlyspan-byte-readonlyspan-byte) `static` | Compares two valid UTF-8 encoded JSON numbers for decimal equality. |
| [AreEqualNormalizedJsonNumbers(bool, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, bool, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int)](/api/corvus-text-json-internal-jsonelementhelpers.areequalnormalizedjsonnumbers.html#areequalnormalizedjsonnumbers-bool-readonlyspan-byte-readonlyspan-byte-int-bool-readonlyspan-byte-readonlyspan-byte-int) `static` | Compares two valid normalized JSON numbers for decimal equality. |
| [CompareNormalizedJsonNumbers(bool, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int, bool, ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;byte&gt;, int)](/api/corvus-text-json-internal-jsonelementhelpers.comparenormalizedjsonnumbers.html#comparenormalizedjsonnumbers-bool-readonlyspan-byte-readonlyspan-byte-int-bool-readonlyspan-byte-readonlyspan-byte-int) `static` | Compares two normalized JSON numbers for equality. |
| [CountRunes(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.countrunes.html#countrunes-readonlyspan-byte) `static` | Count the runes in a UTF-8 string. |
| [CreateOffsetDateTimeCore](/api/corvus-text-json-internal-jsonelementhelpers.createoffsetdatetimecore.html) `static` | Creates an offset date time from its individual components including nanosecond precision. |
| [CreateOffsetTimeCore](/api/corvus-text-json-internal-jsonelementhelpers.createoffsettimecore.html) `static` | Creates an offset time from its individual components including nanosecond precision. |
| [DeepEquals(ref TLeft, ref TRight)](/api/corvus-text-json-internal-jsonelementhelpers.deepequals.html#deepequals-ref-tleft-ref-tright) `static` | Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements. |
| [DeepEqualsNoParentDocumentCheck](/api/corvus-text-json-internal-jsonelementhelpers.deepequalsnoparentdocumentcheck.html) `static` | Compares the values of two [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html) values for equality, including the values of all descendant elements. |
| [GetParentDocumentAndIndex(TElement)](/api/corvus-text-json-internal-jsonelementhelpers.getparentdocumentandindex.html#getparentdocumentandindex-telement) `static` | Gets the parent document and document index for a JSON element. |
| [GetUtf8StringLength(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.getutf8stringlength.html#getutf8stringlength-readonlyspan-byte) `static` | Gets the length of a UTF-8 encoded string in characters (not bytes). |
| [IsIntegerNormalizedJsonNumber(int)](/api/corvus-text-json-internal-jsonelementhelpers.isintegernormalizedjsonnumber.html#isintegernormalizedjsonnumber-int) `static` | Determines if a JSON number is an integer. |
| [IsMultipleOf](/api/corvus-text-json-internal-jsonelementhelpers.ismultipleof.html) `static` | Determines whether the normalized JSON number is an exact multiple of the given integer divisor. |
| [ParseDateCore(ReadOnlySpan&lt;byte&gt;, ref int, ref int, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.parsedatecore.html#parsedatecore-readonlyspan-byte-ref-int-ref-int-ref-int) `static` | Parses a date string in ISO 8601 format (YYYY-MM-DD) and extracts the year, month, and day components. |
| [ParseLocalDate(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.parselocaldate.html#parselocaldate-readonlyspan-byte) `static` | Parse a local date from a UTF-8 encoded string for the `date` format. |
| [ParseNumber(ReadOnlySpan&lt;byte&gt;, ref bool, ref ReadOnlySpan&lt;byte&gt;, ref ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.parsenumber.html#parsenumber-readonlyspan-byte-ref-bool-ref-readonlyspan-byte-ref-readonlyspan-byte-ref-int) `static` | Parses a JSON number into its component parts using normal-form decimal representation. |
| [ParseOffsetCore(ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.parseoffsetcore.html#parseoffsetcore-readonlyspan-byte-ref-int) `static` | Parses a timezone offset string in ISO 8601 format (±HH:MM or Z) and extracts the offset in seconds. |
| [ParseOffsetDate(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.parseoffsetdate.html#parseoffsetdate-readonlyspan-byte) `static` | Parse an offset date from a UTF-8 encoded string for the `date` format. |
| [ParseOffsetDateTime(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.parseoffsetdatetime.html#parseoffsetdatetime-readonlyspan-byte) `static` | Parse an offset date time from a UTF-8 encoded string for the `date-time` format. |
| [ParseOffsetTime(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.parseoffsettime.html#parseoffsettime-readonlyspan-byte) `static` | Parse an offset time from a UTF-8 encoded string for the `time` format. |
| [ParseOffsetTimeCore(ReadOnlySpan&lt;byte&gt;, ref int, ref int, ref int, ref int, ref int, ref int, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.parseoffsettimecore.html#parseoffsettimecore-readonlyspan-byte-ref-int-ref-int-ref-int-ref-int-ref-int-ref-int-ref-int) `static` | Parses a time string with optional offset in ISO 8601 format and extracts the time and offset components. |
| [ParsePeriod(ReadOnlySpan&lt;byte&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.parseperiod.html#parseperiod-readonlyspan-byte) `static` | Parse a period from a UTF-8 encoded string for the `duration` format. |
| [ParseTimeCore(ReadOnlySpan&lt;byte&gt;, ref int, ref int, ref int, ref int, ref int, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.parsetimecore.html#parsetimecore-readonlyspan-byte-ref-int-ref-int-ref-int-ref-int-ref-int-ref-int) `static` | Parses a time string in ISO 8601 format (HH:MM:SS\[.nnnnnnnnn\]) and extracts the time components. |
| [ParseValue](/api/corvus-text-json-internal-jsonelementhelpers.parsevalue.html) `static` | Parses one JSON value (including objects or arrays) from the provided span. |
| [RemoveFirstUnsafe(TArray, ref T)](/api/corvus-text-json-internal-jsonelementhelpers.removefirstunsafe.html#removefirstunsafe-tarray-ref-t) `static` | Removes the first array element that equals the specified item. |
| [RemovePropertyUnsafe](/api/corvus-text-json-internal-jsonelementhelpers.removepropertyunsafe.html) `static` | Removes a property value from a target element. |
| [RemoveRangeUnsafe(TArray, int, int)](/api/corvus-text-json-internal-jsonelementhelpers.removerangeunsafe.html#removerangeunsafe-tarray-int-int) `static` | Removes a range of items from an array element. |
| [RemoveWhereUnsafe(TArray, JsonPredicate&lt;T&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.removewhereunsafe.html#removewhereunsafe-tarray-jsonpredicate-t) `static` | Removes a items from an array element which match a predicate. |
| [SetPropertyUnsafe(TTarget, JsonProperty&lt;TValue&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.setpropertyunsafe.html#setpropertyunsafe-ttarget-jsonproperty-tvalue) `static` | Sets a property value on a target element. |
| [ToValueKind(JsonTokenType)](/api/corvus-text-json-internal-jsonelementhelpers.tovaluekind.html#tovaluekind-jsontokentype) `static` | Converts a [`JsonTokenType`](/api/corvus-text-json-internal-jsontokentype.html) to its corresponding [`JsonValueKind`](/api/corvus-text-json-jsonvaluekind.html). |
| [TryFormatIri](/api/corvus-text-json-internal-jsonelementhelpers.tryformatiri.html) `static` |  |
| [TryFormatIriReference](/api/corvus-text-json-internal-jsonelementhelpers.tryformatirireference.html) `static` |  |
| [TryFormatLocalDate(ref LocalDate, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatlocaldate.html#tryformatlocaldate-ref-localdate-span-byte-ref-int) `static` | Format a date as a UTF-8 string. |
| [TryFormatNumber](/api/corvus-text-json-internal-jsonelementhelpers.tryformatnumber.html) `static` |  |
| [TryFormatNumberAsString(ReadOnlySpan&lt;byte&gt;, ReadOnlySpan&lt;char&gt;, IFormatProvider, ref string)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatnumberasstring.html#tryformatnumberasstring-readonlyspan-byte-readonlyspan-char-iformatprovider-ref-string) `static` | Format the number as a string. |
| [TryFormatOffsetDate(ref OffsetDate, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatoffsetdate.html#tryformatoffsetdate-ref-offsetdate-span-byte-ref-int) `static` | Format a date as a UTF-8 string. |
| [TryFormatOffsetDateTime(ref OffsetDateTime, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatoffsetdatetime.html#tryformatoffsetdatetime-ref-offsetdatetime-span-byte-ref-int) `static` | Format an offset date time as a UTF-8 string. |
| [TryFormatOffsetTime(ref OffsetTime, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatoffsettime.html#tryformatoffsettime-ref-offsettime-span-byte-ref-int) `static` | Format a time as a UTF-8 string. |
| [TryFormatPeriod(ref Period, Span&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryformatperiod.html#tryformatperiod-ref-period-span-byte-ref-int) `static` | Format a period as a UTF-8 string for the `duration` format. |
| [TryFormatUri](/api/corvus-text-json-internal-jsonelementhelpers.tryformaturi.html) `static` |  |
| [TryFormatUriReference](/api/corvus-text-json-internal-jsonelementhelpers.tryformaturireference.html) `static` |  |
| [TryParseLocalDate(ReadOnlySpan&lt;byte&gt;, ref LocalDate)](/api/corvus-text-json-internal-jsonelementhelpers.tryparselocaldate.html#tryparselocaldate-readonlyspan-byte-ref-localdate) `static` | Parse a date from a string for the `date` format. |
| [TryParseNumber(ReadOnlySpan&lt;byte&gt;, ref bool, ref ReadOnlySpan&lt;byte&gt;, ref ReadOnlySpan&lt;byte&gt;, ref int)](/api/corvus-text-json-internal-jsonelementhelpers.tryparsenumber.html#tryparsenumber-readonlyspan-byte-ref-bool-ref-readonlyspan-byte-ref-readonlyspan-byte-ref-int) `static` | Parses a JSON number into its component parts using normal-form decimal representation. |
| [TryParseOffsetDate(ReadOnlySpan&lt;byte&gt;, ref OffsetDate)](/api/corvus-text-json-internal-jsonelementhelpers.tryparseoffsetdate.html#tryparseoffsetdate-readonlyspan-byte-ref-offsetdate) `static` | Parse a date time from a string for the `date-time` format. |
| [TryParseOffsetDateTime(ReadOnlySpan&lt;byte&gt;, ref OffsetDateTime)](/api/corvus-text-json-internal-jsonelementhelpers.tryparseoffsetdatetime.html#tryparseoffsetdatetime-readonlyspan-byte-ref-offsetdatetime) `static` | Parse a date time from a string for the `date-time` format. |
| [TryParseOffsetTime(ReadOnlySpan&lt;byte&gt;, ref OffsetTime)](/api/corvus-text-json-internal-jsonelementhelpers.tryparseoffsettime.html#tryparseoffsettime-readonlyspan-byte-ref-offsettime) `static` | Parse a time from a string for the `time` format. |
| [TryParsePeriod(ReadOnlySpan&lt;byte&gt;, ref Period)](/api/corvus-text-json-internal-jsonelementhelpers.tryparseperiod.html#tryparseperiod-readonlyspan-byte-ref-period) `static` | Parse a period from a string for the `duration` format. |
| [TryParseValue(ref Utf8JsonReader, ref Nullable&lt;T&gt;)](/api/corvus-text-json-internal-jsonelementhelpers.tryparsevalue.html#tryparsevalue-ref-utf8jsonreader-ref-nullable-t) `static` |  |

## Applies To

| Product | Versions |
|---------|----------|
| .NET | 8, 9, 10 |
| .NET Standard | 2.0 |

