---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonSchemaResultsCollector — Corvus.Text.Json"
---
```csharp
public sealed class JsonSchemaResultsCollector : IJsonSchemaResultsCollector, IDisposable
```

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonSchemaResultsCollector**

## Implements

[`IJsonSchemaResultsCollector`](/api/corvus-text-json-ijsonschemaresultscollector.html), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

## Methods

### Create `static`

```csharp
JsonSchemaResultsCollector Create(JsonSchemaResultsLevel level, int estimatedCapacity)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `level` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) |  |
| `estimatedCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

**Returns:** [`JsonSchemaResultsCollector`](/api/corvus-text-json-jsonschemaresultscollector.html)

### CreateUnrented `static`

```csharp
JsonSchemaResultsCollector CreateUnrented(JsonSchemaResultsLevel level, int estimatedCapacity)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `level` | [`JsonSchemaResultsLevel`](/api/corvus-text-json-jsonschemaresultslevel.html) |  |
| `estimatedCapacity` | [`int`](https://learn.microsoft.com/dotnet/api/system.int32) |  *(optional)* |

**Returns:** [`JsonSchemaResultsCollector`](/api/corvus-text-json-jsonschemaresultscollector.html)

### EnumerateResults

```csharp
JsonSchemaResultsCollector.ResultsEnumerator EnumerateResults()
```

**Returns:** `JsonSchemaResultsCollector.ResultsEnumerator`

### GetResultCount

```csharp
int GetResultCount()
```

**Returns:** [`int`](https://learn.microsoft.com/dotnet/api/system.int32)

### Dispose

```csharp
void Dispose()
```


### JsonSchemaResultsCollector.Result (struct)

```csharp
public readonly struct JsonSchemaResultsCollector.Result
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsMatch` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `Message` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `EvaluationLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `SchemaEvaluationLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |
| `DocumentEvaluationLocation` | [`ReadOnlySpan<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlyspan-1) |  |

#### Methods

##### GetMessageText

```csharp
string GetMessageText()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetEvaluationLocationText

```csharp
string GetEvaluationLocationText()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetSchemaEvaluationLocationText

```csharp
string GetSchemaEvaluationLocationText()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

##### GetDocumentEvaluationLocationText

```csharp
string GetDocumentEvaluationLocationText()
```

**Returns:** [`string`](https://learn.microsoft.com/dotnet/api/system.string)

---

### JsonSchemaResultsCollector.ResultsEnumerator (struct)

```csharp
public readonly struct JsonSchemaResultsCollector.ResultsEnumerator : IEnumerable<JsonSchemaResultsCollector.Result>, IEnumerable, IEnumerator<JsonSchemaResultsCollector.Result>, IEnumerator, IDisposable
```

#### Implements

[`IEnumerable<JsonSchemaResultsCollector.Result>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1), [`IEnumerable`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerable), [`IEnumerator<JsonSchemaResultsCollector.Result>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1), [`IEnumerator`](https://learn.microsoft.com/dotnet/api/system.collections.ienumerator), [`IDisposable`](https://learn.microsoft.com/dotnet/api/system.idisposable)

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Current` | `JsonSchemaResultsCollector.Result` |  |

#### Methods

##### Dispose

```csharp
void Dispose()
```

##### Reset

```csharp
void Reset()
```

##### MoveNext

```csharp
bool MoveNext()
```

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### GetEnumerator

```csharp
IEnumerator<JsonSchemaResultsCollector.Result> GetEnumerator()
```

**Returns:** [`IEnumerator<JsonSchemaResultsCollector.Result>`](https://learn.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1)

---

