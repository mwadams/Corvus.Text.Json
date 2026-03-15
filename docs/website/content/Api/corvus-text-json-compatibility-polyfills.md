---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Polyfills — Corvus.Text.Json.Compatibility"
---
```csharp
public static class Polyfills
```

Provides polyfills for Corvus.JsonSchema API compatibility.

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **Polyfills**

## Methods

### IsValid `static`

```csharp
bool IsValid<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### get_HasDotnetBacking `static`

```csharp
bool get_HasDotnetBacking<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### get_HasJsonElementBacking `static`

```csharp
bool get_HasJsonElementBacking<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

### get_Null `static`

```csharp
T get_Null<T>()
```

**Returns:** `T`

### get_Undefined `static`

```csharp
T get_Undefined<T>()
```

**Returns:** `T`

### get_AsJsonElement `static`

```csharp
JsonElement get_AsJsonElement<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

### get_AsAny `static`

```csharp
JsonElement get_AsAny<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** [`JsonElement`](/api/corvus-text-json-jsonelement.html)

### Parse `static`

```csharp
T Parse<T>(string value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `T`

### Parse `static`

```csharp
T Parse<T>(Stream value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `T`

### Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `T`

### Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `T`

### FromJson `static`

```csharp
T FromJson<T, TTarget>(ref TTarget value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref TTarget` |  |

**Returns:** `T`

### As `static`

```csharp
TTarget As<T, TTarget>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `TTarget`

### Validate `static`

```csharp
ValidationContext Validate<T>(T element, ref ValidationContext context, ValidationLevel validationLevel)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |
| `context` | [`ref ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html) |  |
| `validationLevel` | [`ValidationLevel`](/api/corvus-text-json-compatibility-validationlevel.html) |  *(optional)* |

**Returns:** [`ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html)


### Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0> (class)

```csharp
public sealed class Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>
```

#### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>**

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `HasDotnetBacking` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `HasJsonElementBacking` | [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean) |  |
| `Null` `static` | `$T0` |  |
| `Undefined` `static` | `$T0` |  |
| `AsJsonElement` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |
| `AsAny` | [`JsonElement`](/api/corvus-text-json-jsonelement.html) |  |

#### Methods

##### IsValid

```csharp
bool IsValid()
```

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

##### Parse `static`

```csharp
$T0 Parse(string value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`string`](https://learn.microsoft.com/dotnet/api/system.string) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(Stream value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`Stream`](https://learn.microsoft.com/dotnet/api/system.io.stream) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<byte>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | [`ReadOnlyMemory<char>`](https://learn.microsoft.com/dotnet/api/system.readonlymemory-1) |  |
| `options` | [`JsonDocumentOptions`](/api/corvus-text-json-jsondocumentoptions.html) |  *(optional)* |

**Returns:** `$T0`

##### FromJson `static`

```csharp
$T0 FromJson<TTarget>(ref TTarget value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref TTarget` |  |

**Returns:** `$T0`

##### As

```csharp
TTarget As<TTarget>()
```

**Returns:** `TTarget`

##### Validate

```csharp
ValidationContext Validate(ref ValidationContext context, ValidationLevel validationLevel)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `context` | [`ref ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html) |  |
| `validationLevel` | [`ValidationLevel`](/api/corvus-text-json-compatibility-validationlevel.html) |  *(optional)* |

**Returns:** [`ValidationContext`](/api/corvus-text-json-compatibility-validationcontext.html)

#### Nested Types

#### Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>.<M>$026871A96E52A2977B6D89079918ECE5<T> (class)

```csharp
public static class Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>.<M>$026871A96E52A2977B6D89079918ECE5<T>
```

##### Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>.<M>$026871A96E52A2977B6D89079918ECE5<T>**

---

---

