# Analyzers

The `Corvus.Text.Json` NuGet package ships with built-in Roslyn analyzers and code fixes that help you write correct, high-performance code. These are production analyzers — they run continuously and are not related to the separate V4-to-V5 migration analyzers.

## Installation

The analyzers are included in the main package. No additional installation is required:

```xml
<PackageReference Include="Corvus.Text.Json" Version="5.0.0" />
```

They activate automatically at build time and in Visual Studio's live analysis.

## Diagnostics

| ID | Title | Severity | Code Fix |
|----|-------|----------|----------|
| [CTJ001](#ctj001--prefer-utf-8-string-literal) | Prefer UTF-8 string literal | Warning | ✅ Yes |
| [CTJ002](#ctj002--unnecessary-conversion-to-net-type) | Unnecessary conversion to .NET type | Warning | ✅ Yes |
| [CTJ003](#ctj003--match-lambda-should-be-static) | Match lambda should be static | Info | ✅ Yes |

## Refactorings

| Name | Description |
|------|-------------|
| [CTJ-NAV](#ctj-nav--go-to-schema-definition) | Navigate from a schema-generated type to its JSON Schema source |

---

## CTJ001 — Prefer UTF-8 string literal

**Severity:** Warning · **Code fix:** ✅ Yes · **Category:** Performance

Many `Corvus.Text.Json` APIs offer overloads that accept `ReadOnlySpan<byte>` (a UTF-8 byte span) in addition to `string`. The UTF-8 overload avoids the cost of transcoding from UTF-16 to UTF-8 at runtime and allows the compiler to embed the bytes directly in the assembly.

This analyzer fires when you pass a `string` literal to a method or indexer that also has a `ReadOnlySpan<byte>` overload.

```csharp
// Before — CTJ001 fires
JsonElement name = element["name"];

// After — code fix applied
JsonElement name = element["name"u8];
```

The code fix appends the `u8` suffix to the string literal.

---

## CTJ002 — Unnecessary conversion to .NET type

**Severity:** Warning · **Code fix:** ✅ Yes · **Category:** Performance

Schema-generated types provide implicit conversions to and from common .NET types. When an explicit cast to an intermediate .NET type is used in an argument position where the original type already converts implicitly to the target parameter type, the intermediate cast is redundant and may force an unnecessary allocation or copy.

This analyzer fires when a cast expression like `(int)element` is passed to a parameter that would accept the original type via an implicit conversion.

```csharp
// Before — CTJ002 fires
// Source has an implicit conversion from JsonElement, so the (int) cast is unnecessary.
mutable.SetProperty("age", (int)element);

// After — code fix applied
mutable.SetProperty("age", element);
```

The code fix removes the unnecessary cast, letting the implicit conversion handle the transformation directly.

---

## CTJ003 — Match lambda should be static

**Severity:** Info · **Code fix:** ✅ Yes (non-capturing) · **Category:** Usage

The `Match<TOut>` method on schema-generated union/oneOf types accepts lambda callbacks for each variant. If a lambda does not capture any local variables, it should be marked `static` to avoid allocating a delegate instance on every call.

This analyzer inspects each lambda argument to `Match<TOut>` and reports:

- **Non-capturing lambdas** — suggests adding the `static` modifier.
- **Capturing lambdas** — suggests switching to `Match<TContext, TResult>` to pass captured state as an explicit context parameter, avoiding closure allocation.

```csharp
// Before — CTJ003 fires (non-capturing)
string result = value.Match(
    (JsonString s) => s.ToString(),
    (JsonNumber n) => n.ToString());

// After — code fix applied
string result = value.Match(
    static (JsonString s) => s.ToString(),
    static (JsonNumber n) => n.ToString());
```

For capturing lambdas, consider the `Match<TContext, TResult>` overload:

```csharp
// Before — CTJ003 fires (capturing)
string prefix = GetPrefix();
string result = value.Match(
    (JsonString s) => prefix + s.ToString(),    // captures 'prefix'
    (JsonNumber n) => prefix + n.ToString());

// After — manual refactoring
string prefix = GetPrefix();
string result = value.Match(
    prefix,
    static (string ctx, JsonString s) => ctx + s.ToString(),
    static (string ctx, JsonNumber n) => ctx + n.ToString());
```

> **Note:** The code fix only applies the `static` modifier for non-capturing lambdas. Capturing-lambda refactoring to `Match<TContext, TResult>` requires manual changes.

---

## CTJ-NAV — Go to Schema Definition

**Type:** Code Refactoring (lightbulb action) · **Category:** Navigation

When you place the cursor on a type, variable, property, parameter, or field that is backed by a JSON Schema, this refactoring offers to open the schema file and navigate to the exact position of the type or property definition within the schema.

### Trigger positions

The refactoring activates on:

| Code construct | Example |
|----------------|---------|
| Type name | `Order order = ...` (cursor on `Order`) |
| Variable declaration | `Order order = ...` (cursor on `order`) |
| Parameter name | `void Process(Order order)` (cursor on `order`) |
| Field usage | `_order.Total` (cursor on `_order` or `Total`) |
| Property access | `order.Customer` (cursor on `Customer`) |
| Generic type argument | `List<Order>` (cursor on `Order`) |
| Method invocation | `GetOrder()` (cursor on `GetOrder`, navigates via return type) |
| Interface wrapper | `IJsonElement<Order>` (cursor on `Order`) |

### Actions offered

Depending on context, one or two lightbulb actions are offered:

| Action | When |
|--------|------|
| **Go to schema type** | Always, when the type has a schema definition |
| **Go to property declaration** | Additionally, when the cursor is on a property whose type is itself schema-generated — navigates to the property declaration on the parent type's schema |

For example, given `order.Customer` where `CustomerEntity` has its own schema, you get both:
1. **Go to schema type** — opens the schema at `CustomerEntity`'s definition
2. **Go to property declaration** — opens the parent schema at `/properties/customer`

### Schema resolution

The refactoring resolves schema files using three strategies (in order):

1. **Attribute-based** — Finds `[JsonSchemaTypeGenerator("path/to/schema.json")]` on the type or its containing types, then matches the path to an `AdditionalFiles` entry.
2. **`$id`-based** — Reads the type's `SchemaLocation` constant (e.g., `"https://example.com/order#/properties/total"`), extracts the base URL, and searches `AdditionalFiles` for a schema whose `$id` matches.
3. **Property fallback** — If a property's type is a project-global type (e.g., `JsonString`) with no schema of its own, falls back to the containing type's schema and appends `/properties/{jsonPropertyName}`.

### Cursor positioning

The refactoring resolves the JSON Pointer from the `SchemaLocation` to a precise line and column within the schema file. In Visual Studio, it uses the DTE automation model to open the file and position the cursor directly on the target property or type definition — including in single-line schema files.

> **Note:** If DTE is not available (e.g., in a non-VS IDE), the action title includes the line number as a fallback hint: `Go to schema: order.json#/properties/total (line 28)`.
