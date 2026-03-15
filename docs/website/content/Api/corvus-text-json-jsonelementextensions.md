---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "JsonElementExtensions — Corvus.Text.Json"
---
```csharp
public static class JsonElementExtensions
```

Extension methods for [`IJsonElement`](/api/corvus-text-json-internal-ijsonelement.html).

## Inheritance

[`Object`](https://learn.microsoft.com/dotnet/api/system.object) → **JsonElementExtensions**

## Methods

### IsNotNull `static`

```csharp
bool IsNotNull<T>(T value)
```

Gets a value indicating whether this value is not null.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is not null.

### IsNotNullOrUndefined `static`

```csharp
bool IsNotNullOrUndefined<T>(T value)
```

Gets a value indicating whether this value is neither null nor undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is neither null nor undefined.

### IsNotUndefined `static`

```csharp
bool IsNotUndefined<T>(T value)
```

Gets a value indicating whether this value is not undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is not undefined.

### IsNull `static`

```csharp
bool IsNull<T>(T value)
```

Gets a value indicating whether this value is null.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is null.

### IsNullOrUndefined `static`

```csharp
bool IsNullOrUndefined<T>(T value)
```

Gets a value indicating whether this value is null or undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is undefined.

### IsUndefined `static`

```csharp
bool IsUndefined<T>(T value)
```

Gets a value indicating whether this value is undefined.

**Type Parameters:**

| Parameter | Description |
|-----------|-------------|
| `T` | The type of the value to check. |

**Parameters:**

| Name | Type | Description |
|------|------|-------------|
| `value` | `T` | The value to check. |

**Returns:** [`bool`](https://learn.microsoft.com/dotnet/api/system.boolean)

`True` if the value is undefined.

