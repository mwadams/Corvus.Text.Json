# JsonDocumentBuilder and JsonWorkspace Usage Guide

## Overview

`JsonDocumentBuilder<T>` provides a powerful way to create and modify JSON documents in-memory with high performance. It works in conjunction with `JsonWorkspace`, which manages pooled resources for efficient memory usage.

## Key Concepts

### JsonWorkspace

A workspace manages pooled resources for JSON document manipulation:
- **Memory pooling**: Reuses memory buffers to minimize allocations
- **Writer pooling**: Reuses `Utf8JsonWriter` instances
- **Document management**: Tracks multiple documents within a single workspace
- **IDisposable**: Must be disposed to return resources to pools

### JsonDocumentBuilder

A mutable document builder that allows construction and modification of JSON:
- **Type-safe**: Works with strongly-typed mutable elements
- **Efficient**: Uses pooled memory from the workspace
- **Fluent API**: Supports builder patterns for constructing complex documents
- **IDisposable**: Must be disposed to release resources

## Creating a JsonWorkspace

Always create a workspace before creating document builders:

```csharp
using Corvus.Text.Json;

// Create a workspace for building documents
using JsonWorkspace workspace = JsonWorkspace.Create();

// Use the workspace to create one or more documents
// ...
```

### Workspace Options

```csharp
// Create with custom writer options
var writerOptions = new JsonWriterOptions
{
    Indented = true,
    SkipValidation = false
};

using JsonWorkspace workspace = JsonWorkspace.Create(
    initialDocumentCapacity: 10,
    options: writerOptions);
```

## Creating Simple Documents

### From Primitive Values

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

// Create from integers
using var intDoc = JsonElement.CreateDocumentBuilder(workspace, 42);
Console.WriteLine(intDoc.RootElement.GetInt32()); // 42

// Create from doubles
using var doubleDoc = JsonElement.CreateDocumentBuilder(workspace, 3.14159);
Console.WriteLine(doubleDoc.RootElement.GetDouble()); // 3.14159

// Create from strings
using var stringDoc = JsonElement.CreateDocumentBuilder(workspace, "Hello, World!");
Console.WriteLine(stringDoc.RootElement.GetString()); // Hello, World!

// Create from UTF-8 byte spans
using var utf8Doc = JsonElement.CreateDocumentBuilder(workspace, "Hello"u8);
Console.WriteLine(utf8Doc.RootElement.GetString()); // Hello

// Create from booleans
using var boolDoc = JsonElement.CreateDocumentBuilder(workspace, true);
Console.WriteLine(boolDoc.RootElement.GetBoolean()); // True

// Create null value
using var nullDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    JsonElement.Source.Null());
Console.WriteLine(nullDoc.RootElement.ValueKind); // Null
```

## Creating Object Documents

### Using Builder Delegates

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var personDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("name"u8, "John Smith"u8);
        objectBuilder.Add("age"u8, 30);
        objectBuilder.Add("isActive"u8, true);
        objectBuilder.Add("email"u8, "john@example.com"u8);
    }));

Console.WriteLine(personDoc.RootElement.ToString());
// Output: {"name":"John Smith","age":30,"isActive":true,"email":"john@example.com"}
```

### Nested Objects

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("user"u8, static (ref userBuilder) =>
        {
            userBuilder.Add("id"u8, 1);
            userBuilder.Add("profile"u8, static (ref profileBuilder) =>
            {
                profileBuilder.Add("firstName"u8, "Jane"u8);
                profileBuilder.Add("lastName"u8, "Doe"u8);
                profileBuilder.Add("age"u8, 28);
            });
        });

        objectBuilder.Add("timestamp"u8, "2026-02-24T11:00:00Z"u8);
    }));

// Access nested values
JsonElement.Mutable root = doc.RootElement;
JsonElement.Mutable user = root.GetProperty("user");
JsonElement.Mutable profile = user.GetProperty("profile");

string firstName = profile.GetProperty("firstName").GetString();
Console.WriteLine($"First Name: {firstName}"); // Jane
```

## Creating Array Documents

### Simple Arrays

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var arrayDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref arrayBuilder) =>
    {
        arrayBuilder.Add(1);
        arrayBuilder.Add(2);
        arrayBuilder.Add(3);
        arrayBuilder.Add(4);
        arrayBuilder.Add(5);
    }));

Console.WriteLine(arrayDoc.RootElement.ToString());
// Output: [1,2,3,4,5]
```

### Arrays of Strings

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var namesDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref arrayBuilder) =>
    {
        arrayBuilder.Add("Alice"u8);
        arrayBuilder.Add("Bob"u8);
        arrayBuilder.Add("Charlie"u8);
    }));

// Iterate through the array
foreach (JsonElement.Mutable name in namesDoc.RootElement.EnumerateArray())
{
    Console.WriteLine(name.GetString());
}
```

### Arrays of Objects

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var usersDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref arrayBuilder) =>
    {
        arrayBuilder.Add(static (ref userBuilder) =>
        {
            userBuilder.Add("id"u8, 1);
            userBuilder.Add("name"u8, "Alice"u8);
        });

        arrayBuilder.Add(static (ref userBuilder) =>
        {
            userBuilder.Add("id"u8, 2);
            userBuilder.Add("name"u8, "Bob"u8);
        });

        arrayBuilder.Add(static (ref userBuilder) =>
        {
            userBuilder.Add("id"u8, 3);
            userBuilder.Add("name"u8, "Charlie"u8);
        });
    }));

Console.WriteLine(usersDoc.RootElement.ToString());
```

## Creating from Existing Documents

### From ParsedJsonDocument

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

string json = """
    {
        "name": "Original",
        "value": 100
    }
    """;

using ParsedJsonDocument<JsonElement> sourceDoc =
    ParsedJsonDocument<JsonElement>.Parse(json);

// Create a mutable builder from the parsed document
using JsonDocumentBuilder<JsonElement.Mutable> builder =
    sourceDoc.RootElement.CreateDocumentBuilder(workspace);

// Now you can modify it
JsonElement.Mutable root = builder.RootElement;
Console.WriteLine(root.ToString());
```

### Cloning and Modifying

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

string originalJson = """
    {
        "status": "pending",
        "count": 5
    }
    """;

using ParsedJsonDocument<JsonElement> original =
    ParsedJsonDocument<JsonElement>.Parse(originalJson);

using JsonDocumentBuilder<JsonElement.Mutable> modified =
    original.RootElement.CreateDocumentBuilder(workspace);

// Modify the cloned document
JsonElement.Mutable root = modified.RootElement;
root.SetProperty("status", "completed"u8);
root.SetProperty("count", 10);

Console.WriteLine(modified.RootElement.ToString());
// Output: {"status":"completed","count":10}
```

## Complex Example: Building Dynamic Data

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

// Dynamic data to include
string[] tags = ["admin", "user", "active"];
int[] years = [2020, 2021, 2022, 2023, 2024];

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source((ref objectBuilder) =>
    {
        objectBuilder.Add("id"u8, Guid.NewGuid());

        objectBuilder.Add("profile"u8, static (ref profileBuilder) =>
        {
            profileBuilder.Add("username"u8, "john.doe"u8);
            profileBuilder.Add("created"u8, DateTime.UtcNow);
        });

        // Add array of tags from variable
        objectBuilder.Add("tags"u8, (ref tagsBuilder) =>
        {
            foreach (string tag in tags)
            {
                tagsBuilder.Add(tag);
            }
        });

        // Add array of years
        objectBuilder.Add("activeYears"u8, (ref yearsBuilder) =>
        {
            foreach (int year in years)
            {
                yearsBuilder.Add(year);
            }
        });

        objectBuilder.Add("metadata"u8, static (ref metaBuilder) =>
        {
            metaBuilder.Add("version"u8, "1.0"u8);
            metaBuilder.Add("revision"u8, 42);
        });
    }));

Console.WriteLine(doc.RootElement.ToString());
```

## Modifying Documents

### Setting Properties

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("name"u8, "Initial"u8);
        objectBuilder.Add("count"u8, 0);
    }));

JsonElement.Mutable root = doc.RootElement;

// Update existing properties
root.SetProperty("name"u8, "Updated"u8);
root.SetProperty("count"u8, 100);

// Add new properties
root.SetProperty("timestamp"u8, DateTime.UtcNow);

Console.WriteLine(root.ToString());
```

### Adding Array Elements

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("items"u8, static (ref arrayBuilder) =>
        {
            arrayBuilder.Add("item1"u8);
            arrayBuilder.Add("item2"u8);
        });
    }));

JsonElement.Mutable root = doc.RootElement;
JsonElement.Mutable items = root.GetProperty("items");

// Add more items to the array
items.SetProperty(2, "item3"u8);
items.SetProperty(3, "item4"u8);

Console.WriteLine(root.ToString());
```

## Writing Documents with Utf8JsonWriter

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("message"u8, "Hello"u8);
    }));

using var stream = new MemoryStream();
using (var writer = new Corvus.Text.Json.Utf8JsonWriter(
    stream,
    new Corvus.Text.Json.JsonWriterOptions { Indented = true }))
{
    doc.WriteTo(writer);
}

string json = Encoding.UTF8.GetString(stream.ToArray());
Console.WriteLine(json);
```

## Memory Management Best Practices

### Always Dispose Resources

```csharp
// ✅ Good - using statements ensure disposal
using JsonWorkspace workspace = JsonWorkspace.Create();
using var doc = JsonElement.CreateDocumentBuilder(workspace, 42);
// Automatically disposed at end of scope

// ❌ Bad - resource leak
var workspace = JsonWorkspace.Create();
var doc = JsonElement.CreateDocumentBuilder(workspace, 42);
// Missing dispose!
```

### Reuse Workspaces

```csharp
// ✅ Good - single workspace for multiple documents
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc1 = JsonElement.CreateDocumentBuilder(workspace, 1);
using var doc2 = JsonElement.CreateDocumentBuilder(workspace, 2);
using var doc3 = JsonElement.CreateDocumentBuilder(workspace, 3);

// All documents share the workspace's pooled resources
```

### Workspace Lifetime

```csharp
// The workspace must outlive all documents created from it
using JsonWorkspace workspace = JsonWorkspace.Create();

JsonDocumentBuilder<JsonElement.Mutable>? doc = null;
try
{
    doc = JsonElement.CreateDocumentBuilder(workspace, 42);
    // Use doc...
}
finally
{
    doc?.Dispose();
}
// Workspace disposed after all documents
```

### Thread Affinity and Async Boundaries

**CRITICAL**: `JsonWorkspace` uses thread-local storage and **must not cross async boundaries** where the continuation may resume on a different thread.

The workspace is tied to the thread that created it via the `[ThreadStatic]` attribute. When an async method hits an `await`, the continuation after the await may execute on a different thread pool thread. If the workspace is accessed from a different thread, it will result in a runtime error.

**✅ Safe Pattern** - Complete all workspace operations before awaiting:

```csharp
static async Task ProcessDataAsync()
{
    // Safe to await before we create the workspace
    await DoSomeAsyncProcessing();

    // Scoped using ensures workspace is disposed before async operation
    using (JsonWorkspace workspace = JsonWorkspace.Create())
    {
        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("name"u8, "Example"u8);
                objectBuilder.Add("value"u8, 42);
            }));

        // Process the JSON here (e.g. write to a Utf8JsonWriter)
    }

    // Safe to await again - workspace has been disposed
    await DoSomeMoreAsyncProcessing();
}

```

**❌ Unsafe Pattern** - Using workspace after await:

```csharp
static async Task ProcessDataAsync()
{
    using JsonWorkspace workspace = JsonWorkspace.Create();

    // Await may cause continuation on different thread
    string apiData = await FetchDataAsync();

    // ERROR: workspace may be accessed from wrong thread!
    using var doc = JsonElement.CreateDocumentBuilder(workspace, apiData);
}
```

**Key Rules**:
1. Perform async operations to build your working context.
2. Create the workspace
3. Perform all document building and modifications
4. Extract the final data (WriteTo() etc.)
5. Dispose workspace and documents
6. Perform further async operations to complete the operation.

Alternatively, create the workspace **after** all async operations complete, ensuring it's only used on a single thread.

## Performance Tips

1. **Reuse workspaces**: Create one workspace and use it for multiple documents
2. **Pre-allocate capacity**: If you know the document size, specify `estimatedMemberCount`
3. **Use UTF-8 directly**: Pass `ReadOnlySpan<byte>` with `u8` suffix to avoid string encoding
4. **Avoid unnecessary conversions**: Work with `JsonElement.Mutable` directly when possible
5. **Dispose promptly**: Don't hold documents longer than necessary

## Common Patterns

### Building API Responses

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var response = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("success"u8, true);
        objectBuilder.Add("timestamp"u8, DateTime.UtcNow);
        objectBuilder.Add("data"u8, static (ref dataBuilder) =>
        {
            dataBuilder.Add("id"u8, 12345);
            dataBuilder.Add("status"u8, "completed"u8);
        });
    }));

return response.RootElement.ToString();
```

### Enriching External API Data

A common use case is fetching data from an external API and augmenting it with additional information:

```csharp
// Parse API response
string apiResponse = """
    {
        "id": 12345,
        "username": "johndoe",
        "email": "john@example.com"
    }
    """;

using ParsedJsonDocument<JsonElement> apiDoc = ParsedJsonDocument<JsonElement>.Parse(apiResponse);
JsonElement apiRoot = apiDoc.RootElement;

// Get additional data from database/other sources
string[] permissions = GetUserPermissions(userId);
var preferences = GetUserPreferences(userId);

// Build enriched document
using JsonWorkspace workspace = JsonWorkspace.Create();
using var enrichedDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source((ref objectBuilder) =>
    {
        // Original API data
        objectBuilder.Add("userId"u8, apiRoot.GetProperty("id"));
        objectBuilder.Add("username"u8, apiRoot.GetProperty("username"));

        // Augmented data
        objectBuilder.Add("permissions"u8, (ref permBuilder) =>
        {
            foreach (string perm in permissions)
            {
                permBuilder.Add(perm);
            }
        });

        objectBuilder.Add("preferences"u8, (ref prefBuilder) =>
        {
            prefBuilder.Add("theme"u8, preferences.Theme);
            prefBuilder.Add("notifications"u8, preferences.NotificationsEnabled);
        });
    }));
```

### Merging Multiple API Responses

Combine data from multiple API calls into a single document:

```csharp
// Fetch user data
using ParsedJsonDocument<JsonElement> userDoc =
    ParsedJsonDocument<JsonElement>.Parse(await FetchUserDataAsync(userId));

// Fetch posts data
using ParsedJsonDocument<JsonElement> postsDoc =
    ParsedJsonDocument<JsonElement>.Parse(await FetchUserPostsAsync(userId));

// Merge into single document
using JsonWorkspace workspace = JsonWorkspace.Create();
using var mergedDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source((ref objectBuilder) =>
    {
        // User summary
        objectBuilder.Add("user"u8, (ref userBuilder) =>
        {
            userBuilder.Add("id"u8, userDoc.RootElement.GetProperty("id").GetInt32());
            userBuilder.Add("name"u8,
                Encoding.UTF8.GetBytes(userDoc.RootElement.GetProperty("name").GetString()!));
        });

        // Posts from second API
        objectBuilder.Add("posts"u8, (ref postsBuilder) =>
        {
            foreach (JsonElement post in postsDoc.RootElement.GetProperty("posts").EnumerateArray())
            {
                postsBuilder.Add((ref postBuilder) =>
                {
                    postBuilder.Add("id"u8, post.GetProperty("id").GetInt32());
                    postBuilder.Add("title"u8,
                        Encoding.UTF8.GetBytes(post.GetProperty("title").GetString()!));
                    // Add computed fields
                    int likes = post.GetProperty("likes").GetInt32();
                    postBuilder.Add("likes"u8, likes);
                    postBuilder.Add("popular"u8, likes > 100);
                });
            }
        });
    }));
```

### Transforming API Response Format

Convert between different API formats:

```csharp
// Legacy API format
string legacyResponse = """
    {
        "user_id": 999,
        "user_name": "alice",
        "user_role": "admin"
    }
    """;

using ParsedJsonDocument<JsonElement> legacyDoc =
    ParsedJsonDocument<JsonElement>.Parse(legacyResponse);
JsonElement legacyRoot = legacyDoc.RootElement;

// Transform to modern format
using JsonWorkspace workspace = JsonWorkspace.Create();
using var transformedDoc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source((ref objectBuilder) =>
    {
        // Map old fields to new structure
        objectBuilder.Add("id"u8, legacyRoot.GetProperty("user_id").GetInt32());

        objectBuilder.Add("account"u8, (ref accountBuilder) =>
        {
            accountBuilder.Add("username"u8,
                Encoding.UTF8.GetBytes(legacyRoot.GetProperty("user_name").GetString()!));
        });

        objectBuilder.Add("authorization"u8, (ref authBuilder) =>
        {
            string role = legacyRoot.GetProperty("user_role").GetString()!;
            authBuilder.Add("role"u8, Encoding.UTF8.GetBytes(role));
            authBuilder.Add("isAdmin"u8, role == "admin");
        });

        // Add modern metadata
        objectBuilder.Add("apiVersion"u8, "v2"u8);
    }));
```

### Building Configuration

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var config = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("appName"u8, "MyApp"u8);
        objectBuilder.Add("version"u8, "1.0.0"u8);

        objectBuilder.Add("database"u8, static (ref dbBuilder) =>
        {
            dbBuilder.Add("host"u8, "localhost"u8);
            dbBuilder.Add("port"u8, 5432);
            dbBuilder.Add("name"u8, "mydb"u8);
        });

        objectBuilder.Add("features"u8, static (ref featuresBuilder) =>
        {
            featuresBuilder.Add("logging"u8, true);
            featuresBuilder.Add("caching"u8, true);
            featuresBuilder.Add("compression"u8, false);
        });
    }));

File.WriteAllText("config.json", config.RootElement.ToString());
```

## Version Tracking and Element Invalidation

The `JsonElement.Mutable` type includes **version tracking** to detect when references become invalid after modifications. This is a safety feature that prevents accessing stale data.

### Understanding Version Tracking

When you modify a mutable JSON document (by adding, removing, or changing elements), the document's internal version is incremented. Any `JsonElement.Mutable` references you obtained **before** the modification will detect this version change and throw an `InvalidOperationException` if you try to use them.

### Example of Version Tracking

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();

using var doc = JsonElement.CreateDocumentBuilder(
    workspace,
    new JsonElement.Source(static (ref objectBuilder) =>
    {
        objectBuilder.Add("numbers"u8, static (ref arrayBuilder) =>
        {
            arrayBuilder.Add(10);
            arrayBuilder.Add(20);
            arrayBuilder.Add(30);
        });

        objectBuilder.Add("tags"u8, static (ref arrayBuilder) =>
        {
            arrayBuilder.Add("alpha"u8);
            arrayBuilder.Add("beta"u8);
        });
    }));

JsonElement.Mutable root = doc.RootElement;
JsonElement.Mutable numbers = root.GetProperty("numbers");
JsonElement.Mutable tags = root.GetProperty("tags");

// Modify the numbers array
numbers.SetItem(0, 100);

// ❌ BAD: Trying to use 'tags' reference after modifying 'numbers'
// This will throw InvalidOperationException because the version changed
try
{
    tags.SetItem(0, "MODIFIED");  // Throws!
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Reference became invalid after modification");
}

// ✅ GOOD: Re-get the reference after modification
root = doc.RootElement;  // Refresh root
tags = root.GetProperty("tags");  // Get fresh reference
tags.SetItem(0, "MODIFIED");  // Now it works
```

### Best Practices for Version Tracking

1. **Re-get references after modifications**
   ```csharp
   numbers.Remove(0);

   // Re-get root and other references
   root = doc.RootElement;
   colors = root.GetProperty("colors");
   ```

2. **Perform all operations on one element before moving to another**
   ```csharp
   // ✅ Good - finish with numbers before getting colors
   JsonElement.Mutable numbers = root.GetProperty("numbers");
   numbers.Remove(0);
   numbers.Remove(numbers.GetArrayLength() - 1);

   // Now refresh and get colors
   root = doc.RootElement;
   JsonElement.Mutable colors = root.GetProperty("colors");
   colors.RemoveRange(0, 2);
   ```

3. **Use the root element as your source of truth**
   ```csharp
   // Always access through doc.RootElement for fresh references
   doc.RootElement.GetProperty("field1").SetItem(0, value1);
   doc.RootElement.GetProperty("field2").SetItem(0, value2);
   ```

4. **Minimize reference lifetime**
   ```csharp
   // ✅ Good - get, use, discard
   {
       JsonElement.Mutable temp = root.GetProperty("temp");
       temp.Remove(0);
   }  // 'temp' goes out of scope

   // Get fresh reference for next operation
   root = doc.RootElement;
   ```

### Why Version Tracking Exists

Version tracking is a **safety feature** that prevents bugs caused by:
- Using stale references to data that may have been relocated in memory
- Accessing elements at incorrect indices after array modifications
- Reading properties that may have been removed or reordered

Without version tracking, you could silently access incorrect data or crash with memory corruption. The `InvalidOperationException` is intentional and helps you write correct code.

### Working with Version Tracking

The key principle is: **after any modification, assume all previously obtained references are invalid**.

```csharp
using JsonWorkspace workspace = JsonWorkspace.Create();
using var doc = JsonElement.CreateDocumentBuilder(workspace, /* ... */);

JsonElement.Mutable root = doc.RootElement;

// Pattern 1: Single modification
JsonElement.Mutable array1 = root.GetProperty("array1");
array1.Remove(0);
// array1 is now invalid, root is invalid

root = doc.RootElement;  // Refresh
// Continue working...

// Pattern 2: Multiple modifications on same element
JsonElement.Mutable array2 = root.GetProperty("array2");
array2.Remove(0);
array2.Remove(0);  // OK - same element, hasn't been refreshed yet
array2.SetItem(0, newValue);  // OK - still the same element

// Pattern 3: Access different properties
JsonElement.Mutable prop1 = root.GetProperty("prop1");
prop1.SetItem(0, value1);

// Must refresh root before accessing another property
root = doc.RootElement;
JsonElement.Mutable prop2 = root.GetProperty("prop2");
prop2.SetItem(0, value2);
```

## Important Notes

- **Thread Safety**: `JsonWorkspace` and `JsonDocumentBuilder` are not thread-safe
- **Document Lifetime**: Documents must be disposed before their workspace
- **Memory Pooling**: Proper disposal is critical for returning memory to pools
- **Static Delegates**: Use `static` delegates when possible for better performance
- **Version Tracking**: Element references become invalid after any document modification; always re-get references from `doc.RootElement`

## Comparison with System.Text.Json.Nodes

### Similar Capabilities

Both `JsonDocumentBuilder` and `System.Text.Json.Nodes` (JsonNode, JsonObject, JsonArray) provide mutable JSON document manipulation:

- **Mutable Documents**: Both allow in-place modification of JSON structures
- **Dynamic Construction**: Both support building JSON from code
- **Property Access**: Both provide ways to get/set properties and array elements
- **Type Conversions**: Both can convert between JSON and .NET types

### Key Differences

#### 1. **Memory Model**

**JsonNode (System.Text.Json.Nodes)**:
- Allocates individual objects for each JSON value (JsonObject, JsonArray, JsonValue)
- Each node is a separate heap allocation
- Can lead to significant GC pressure with large documents
- Suitable for small to medium documents or infrequent operations

**JsonDocumentBuilder**:
- Uses a flat, array-based representation in pooled memory
- All values stored in contiguous metadata arrays
- Minimal allocations through workspace pooling
- Optimized for high-throughput scenarios and large documents

#### 2. **Performance Characteristics**

**JsonNode**:
```csharp
// Parse and modify with JsonNode - creates many objects
JsonNode? node = JsonNode.Parse(json);
JsonObject nameObj = node!["name"]?.AsObject() ?? throw new InvalidOperationException();
nameObj["firstName"] = "Matthew";  // Simple property set
string result = nameObj.ToJsonString();
```

**JsonDocumentBuilder**:
```csharp
// Parse and modify with JsonDocumentBuilder - pooled resources
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
using JsonWorkspace workspace = JsonWorkspace.Create();
using JsonDocumentBuilder<JsonElement.Mutable> builder = doc.RootElement.GetProperty("name").CreateDocumentBuilder(workspace);
builder.RootElement.SetProperty("firstName", "Matthew");
string result = builder.RootElement.ToString();
```

Benchmark results show `JsonDocumentBuilder` with significantly lower allocations, especially for repeated operations or large documents.

#### 3. **API Design**

**JsonNode**:
- Object-oriented, hierarchical tree structure
- Dictionary-like syntax: `node["property"]`
- Implicit type conversions
- More intuitive for simple scenarios

**JsonDocumentBuilder**:
- Struct-based, with mutable wrappers over flat arrays
- Explicit method calls: `GetProperty()`, `SetProperty()`
- UTF-8 byte-oriented APIs alongside string APIs
- Builder patterns for construction
- More control over memory and encoding

#### 4. **Interoperability**

We can interoperate with `System.Text.Json` using the `Corvus.Text.Json.Compatibility` library.

**From JsonElement to JsonNode**:
```csharp
using Corvus.Text.Json.Compatibility;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
JsonNode? node = doc.RootElement.AsJsonNode();
```

**From Corvus.Text.Json.JsonElement to System.Text.Json.JsonElement**:
```csharp
using Corvus.Text.Json.Compatibility;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
System.Text.Json.JsonElement element = doc.RootElement.AsSTJsonElement();
```

**From System.Text.Json.JsonElement to Corvus.Text.Json.JsonElement**:
```csharp
using Corvus.Text.Json.Compatibility;
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
System.Text.Json.JsonElement element = doc.RootElement.FromSTJsonElement();
```

#### 5. **Use Case Recommendations**

**Choose JsonNode when**:
- Working with small JSON documents
- Prioritizing code simplicity and readability
- Performance is not critical
- Making occasional modifications
- Integrating with APIs that expect JsonNode

**Choose JsonDocumentBuilder when**:
- High-throughput scenarios (web services, message processing)
- Memory efficiency is critical
- Building or transforming JSON from external APIs
- Performing repeated operations where allocation costs matter
- Processing large JSON documents in memory

### Example Comparison

**Task**: Parse JSON, modify a nested property, serialize back

**With System.Text.Json.Nodes**:
```csharp
JsonNode? root = JsonNode.Parse(json);
JsonObject person = root!["person"]?.AsObject() ?? throw new InvalidOperationException();
person["age"] = 31;
string result = root.ToJsonString();
```
✅ Simple and intuitive
❌ Multiple allocations (JsonNode, JsonObject, JsonValue)
❌ GC pressure with large or frequent operations

**With JsonDocumentBuilder**:
```csharp
using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
using JsonWorkspace workspace = JsonWorkspace.Create();
using var builder = JsonElement.CreateDocumentBuilder(workspace, doc.RootElement);
builder.RootElement.GetProperty("person"u8).SetProperty("age"u8, 31);
string result = builder.RootElement.ToString();
```
✅ Minimal allocations (pooled resources)
✅ High performance
❌ Requires workspace management
