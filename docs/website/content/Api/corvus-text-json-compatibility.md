---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Corvus.Text.Json.Compatibility Namespace"
---
# Corvus.Text.Json.Compatibility Namespace

| Type | Kind | Description |
|------|------|-------------|
| [Polyfills](#polyfills) | class | Provides polyfills for Corvus.JsonSchema API compatibility. |
| [ValidationContext](#validationcontext) | struct | Represents the context for a JSON schema validation operation, including validity and results. |
| [ValidationLevel](#validationlevel) | enum | The validation level. |
| [ValidationResult](#validationresult) | struct | Represents the result of a single JSON schema validation, including validity, message, and locations. |

## Polyfills (class)

```csharp
public static class Polyfills
```

Provides polyfills for Corvus.JsonSchema API compatibility.

### Methods

#### IsValid `static`

```csharp
bool IsValid<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `bool`

#### get_HasDotnetBacking `static`

```csharp
bool get_HasDotnetBacking<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `bool`

#### get_HasJsonElementBacking `static`

```csharp
bool get_HasJsonElementBacking<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `bool`

#### get_Null `static`

```csharp
T get_Null<T>()
```

**Returns:** `T`

#### get_Undefined `static`

```csharp
T get_Undefined<T>()
```

**Returns:** `T`

#### get_AsJsonElement `static`

```csharp
JsonElement get_AsJsonElement<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `JsonElement`

#### get_AsAny `static`

```csharp
JsonElement get_AsAny<T>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `JsonElement`

#### Parse `static`

```csharp
T Parse<T>(string value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `T`

#### Parse `static`

```csharp
T Parse<T>(Stream value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Stream` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `T`

#### Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlyMemory<byte>` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `T`

#### Parse `static`

```csharp
T Parse<T>(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlyMemory<char>` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `T`

#### FromJson `static`

```csharp
T FromJson<T, TTarget>(ref TTarget value)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ref TTarget` |  |

**Returns:** `T`

#### As `static`

```csharp
TTarget As<T, TTarget>(T element)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |

**Returns:** `TTarget`

#### Validate `static`

```csharp
ValidationContext Validate<T>(T element, ref ValidationContext context, ValidationLevel validationLevel)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `element` | `T` |  |
| `context` | `ref ValidationContext` |  |
| `validationLevel` | `ValidationLevel` |  *(optional)* |

**Returns:** `ValidationContext`

### Nested Types

### Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0> (class)

```csharp
public sealed class Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `HasDotnetBacking` | `bool` |  |
| `HasJsonElementBacking` | `bool` |  |
| `Null` `static` | `$T0` |  |
| `Undefined` `static` | `$T0` |  |
| `AsJsonElement` | `JsonElement` |  |
| `AsAny` | `JsonElement` |  |

#### Methods

##### IsValid

```csharp
bool IsValid()
```

**Returns:** `bool`

##### Parse `static`

```csharp
$T0 Parse(string value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `string` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(Stream value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `Stream` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(ReadOnlyMemory<byte> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlyMemory<byte>` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

**Returns:** `$T0`

##### Parse `static`

```csharp
$T0 Parse(ReadOnlyMemory<char> value, JsonDocumentOptions options)
```

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `ReadOnlyMemory<char>` |  |
| `options` | `JsonDocumentOptions` |  *(optional)* |

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
| `context` | `ref ValidationContext` |  |
| `validationLevel` | `ValidationLevel` |  *(optional)* |

**Returns:** `ValidationContext`

#### Nested Types

#### Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>.<M>$026871A96E52A2977B6D89079918ECE5<T> (class)

```csharp
public static class Polyfills.<G>$DC6137C8821356B03EBBAE3CBE9F710E<$T0>.<M>$026871A96E52A2977B6D89079918ECE5<T>
```

---

---

---

## ValidationContext (struct)

```csharp
public readonly struct ValidationContext
```

Represents the context for a JSON schema validation operation, including validity and results.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsValid` | `bool` | Gets a value indicating whether this context represents a valid result. |
| `Results` | `IReadOnlyList<ValidationResult>` | Gets the validation results. |

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `InvalidContext` `static` | `ValidationContext` | Gets an invalid context. |
| `ValidContext` `static` | `ValidationContext` | Gets a valid context. |

---

## ValidationLevel (enum)

```csharp
public enum ValidationLevel : IComparable, ISpanFormattable, IFormattable, IConvertible
```

The validation level.

### Inheritance

- Implements: `IComparable`
- Implements: `ISpanFormattable`
- Implements: `IFormattable`
- Implements: `IConvertible`

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `Flag` `static` | `ValidationLevel` | 10.4.1. Flag. |
| `Basic` `static` | `ValidationLevel` | 10.4.2. Basic. |
| `Detailed` `static` | `ValidationLevel` | 10.4.3. Detailed. |
| `Verbose` `static` | `ValidationLevel` | 10.4.4. Verbose. |

---

## ValidationResult (struct)

```csharp
public readonly struct ValidationResult
```

Represents the result of a single JSON schema validation, including validity, message, and locations.

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Location` | `ValidationResult.LocationTuple` | Gets the location information for this validation result. |
| `Message` | `string` | Gets the validation message for this result, if any. |
| `Valid` | `bool` | Gets a value indicating whether the validation result is valid. |

### Nested Types

### ValidationResult.LocationTuple (struct)

```csharp
public readonly struct ValidationResult.LocationTuple
```

#### Properties

| Property | Type | Description |
|----------|------|-------------|
| `DocumentLocation` | `Utf8IriReference` |  |
| `SchemaLocation` | `Utf8IriReference` |  |
| `ValidationLocation` | `Utf8IriReference` |  |

---

---

