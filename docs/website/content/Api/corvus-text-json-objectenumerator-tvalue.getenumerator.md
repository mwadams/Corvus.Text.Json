---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "ObjectEnumerator<TValue>.GetEnumerator Method — Corvus.Text.Json"
---
## Definition

**Namespace:** Corvus.Text.Json  
**Assembly:** Corvus.Text.Json.dll

## GetEnumerator {#getenumerator}

```csharp
public ObjectEnumerator<TValue> GetEnumerator()
```

Returns an enumerator that iterates the properties of an object.

### Returns

[`ObjectEnumerator<TValue>`](/api/corvus-text-json-objectenumerator-tvalue.html)

An [`ObjectEnumerator`](/api/corvus-text-json-internal-objectenumerator.html) value that can be used to iterate through the object.

### Remarks

The enumerator will enumerate the properties in the order they are declared, and when an object has multiple definitions of a single property they will all individually be returned (each in the order they appear in the content).

