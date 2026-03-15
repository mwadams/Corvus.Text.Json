---
ContentType: "application/vnd.endjin.ssg.content+md"
PublicationStatus: Published
Date: 2026-03-15T00:00:00.0+00:00
Title: "Creating and Mutating Objects"
---
## Creating objects from scratch

Use the convenience `CreateBuilder()` overload with named property parameters:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var builder = Person.CreateBuilder(
    workspace,
    name: Person.PersonNameEntity.Build(
        (ref nb) => nb.Create(familyName: "Oldroyd"u8, givenName: "Michael"u8)),
    age: 30,
    email: "michael@example.com"u8);

Console.WriteLine(builder.RootElement.ToString());
// {"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30,"email":"michael@example.com"}
```

Required parameters must be provided; optional ones can be omitted. Always use named parameters for clarity and resilience to schema evolution.

### Nested objects

Use `NestedType.Build()` to compose nested values as parameters:

```csharp
using var builder = Person.CreateBuilder(
    workspace,
    name: Person.PersonNameEntity.Build(
        (ref nb) => nb.Create(familyName: "Oldroyd"u8, givenName: "Michael"u8)),
    age: 30,
    address: Person.AddressEntity.Build((ref ab) => ab.Create(
        street: "123 Main St"u8,
        city: "Springfield"u8)));
```

### Array properties

```csharp
hobbies: Person.HobbiesEntity.Build((ref hb) =>
{
    hb.Add("reading"u8);
    hb.Add("hiking"u8);
})
```

### Advanced: delegate pattern

For scenarios that require logic inside the builder (e.g., conditional properties, `From()` conversions), use the delegate overload:

```csharp
using var builder = TargetType.CreateBuilder(workspace, (ref TargetType.Builder b) =>
{
    b.Create(
        fullName: TargetType.FullNameEntity.From(source.Name),
        identifier: TargetType.IdentifierEntity.From(source.Id));
});
```

## Mutating properties

Generated types are immutable by default. To mutate, create a `JsonDocumentBuilder` via a `JsonWorkspace`:

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using ParsedJsonDocument<Person> doc =
    ParsedJsonDocument<Person>.Parse(
        """{"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":30}""");
using var builder = doc.RootElement.CreateBuilder(workspace);

Person.Mutable root = builder.RootElement;
root.SetAge(31);
root.SetEmail("michael@example.com"u8);

Console.WriteLine(root.ToString());
// {"name":{"familyName":"Oldroyd","givenName":"Michael"},"age":31,"email":"michael@example.com"}
```

### Version tracking

The builder tracks a version number, and every `Mutable` element reference records the version at which it was obtained. If the document structure changes after you captured a reference, attempting to use that stale reference throws an `InvalidOperationException`.

You can make multiple modifications to the *same* entity without re-obtaining it:

```csharp
Person.Mutable root = builder.RootElement;
root.SetAge(31);
root.SetEmail("michael@example.com"u8);
root.Address.SetCity("London"u8);
```

If a structural change invalidates your reference, re-obtain it from `builder.RootElement`:

```csharp
Person.Mutable root = builder.RootElement;
root.RemoveEmail();              // structural change
root = builder.RootElement;      // re-obtain root after structural change
```

## Removing properties

Optional properties can be removed from mutable instances:

```csharp
root.RemoveEmail();
```

The standard mutation workflow is:

1. Parse JSON into a `ParsedJsonDocument<T>`
2. Create a `JsonDocumentBuilder<T.Mutable>` via `.CreateBuilder(workspace)`
3. Get the `Mutable` root element from the builder
4. Call `Set*()` / `Remove*()` methods on the mutable element
5. Serialize via `root.WriteTo(writer)`, `root.ToString()`, or convert to immutable via `.Clone()`
