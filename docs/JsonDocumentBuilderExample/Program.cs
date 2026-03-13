using Corvus.Text.Json;
using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JsonDocumentBuilderExample;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== JsonDocumentBuilder Examples ===\n");

        // Example 1: Create simple documents from primitives
        Example1_CreateFromPrimitives();

        // Example 2: Create an object document
        Example2_CreateObjectDocument();

        // Example 3: Create a document with nested objects
        Example3_CreateNestedObjects();

        // Example 4: Create an array document
        Example4_CreateArrayDocument();

        // Example 5: Create an array of objects
        Example5_CreateArrayOfObjects();

        // Example 6: Create from existing document
        Example6_CreateFromExistingDocument();

        // Example 7: Modify a document
        Example7_ModifyDocument();

        // Example 8: Build dynamic data
        Example8_BuildDynamicData();

        // Example 9: Build complex nested structure
        Example9_BuildComplexStructure();

        // Example 10: Array item operations
        Example10_ArrayItemOperations();

        // Example 11: Remove properties
        Example11_RemoveProperties();

        // Example 12: Remove array items and ranges
        Example12_RemoveArrayItems();

        // Example 13: Build document from external API data
        await Example13_BuildFromApiDataAsync();

        // Example 14: Write to file with async boundary handling
        await Example14_WriteToFileAsync();

        // Example 15: Serialize with rented writer and buffer
        Example15_SerializeWithRentedWriter();

        // Example 16: Serialize to stream (file)
        await Example16_SerializeToStreamAsync();

        // Example 17: Simulate ASP.NET Core response writing
        await Example17_SimulateAspNetCoreResponseAsync();

        // Example 18: Compose documents from multiple async API calls
        await Example18_ComposeFromMultipleApisAsync();

        // Example 19: Build document across async boundaries with CreateUnrented
        await Example19_BuildAcrossAsyncBoundariesAsync();

        Console.WriteLine("\nAll examples completed!");
    }

    static void Example1_CreateFromPrimitives()
    {
        Console.WriteLine("--- Example 1: Create from Primitives ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Integer
        using var intDoc = JsonElement.CreateBuilder(workspace, 42);
        Console.WriteLine($"Integer: {intDoc.RootElement.GetInt32()}");

        // Double
        using var doubleDoc = JsonElement.CreateBuilder(workspace, 3.14159);
        Console.WriteLine($"Double: {doubleDoc.RootElement.GetDouble():F5}");

        // String
        using var stringDoc = JsonElement.CreateBuilder(workspace, "Hello, World!");
        Console.WriteLine($"String: {stringDoc.RootElement.GetString()}");

        // UTF-8
        using var utf8Doc = JsonElement.CreateBuilder(workspace, "Hello"u8);
        Console.WriteLine($"UTF-8: {utf8Doc.RootElement.GetString()}");

        // Boolean
        using var boolDoc = JsonElement.CreateBuilder(workspace, true);
        Console.WriteLine($"Boolean: {boolDoc.RootElement.GetBoolean()}");

        // Null
        using var nullDoc = JsonElement.CreateBuilder(workspace, JsonElement.Source.Null());
        Console.WriteLine($"Null: {nullDoc.RootElement.ValueKind}");

        Console.WriteLine();
    }

    static void Example2_CreateObjectDocument()
    {
        Console.WriteLine("--- Example 2: Create Object Document ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var personDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("name"u8, "John Smith"u8);
                objectBuilder.AddProperty("age"u8, 30);
                objectBuilder.AddProperty("isActive"u8, true);
                objectBuilder.AddProperty("email"u8, "john@example.com"u8);
            }));

        Console.WriteLine(personDoc.RootElement.ToString());
        Console.WriteLine();
    }

    static void Example3_CreateNestedObjects()
    {
        Console.WriteLine("--- Example 3: Create Nested Objects ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("user"u8, static (ref userBuilder) =>
                {
                    userBuilder.AddProperty("id"u8, 1);
                    userBuilder.AddProperty("profile"u8, static (ref profileBuilder) =>
                    {
                        profileBuilder.AddProperty("firstName"u8, "Jane"u8);
                        profileBuilder.AddProperty("lastName"u8, "Doe"u8);
                        profileBuilder.AddProperty("age"u8, 28);
                        profileBuilder.AddProperty("contact"u8, static (ref contactBuilder) =>
                        {
                            contactBuilder.AddProperty("email"u8, "jane.doe@example.com"u8);
                            contactBuilder.AddProperty("phone"u8, "555-0123"u8);
                        });
                    });
                });

                objectBuilder.AddProperty("timestamp"u8, "2026-02-24T11:00:00Z"u8);
                objectBuilder.AddProperty("active"u8, true);
            }));

        // Access nested values
        JsonElement.Mutable root = doc.RootElement;
        JsonElement.Mutable user = root.GetProperty("user");
        JsonElement.Mutable profile = user.GetProperty("profile");
        JsonElement.Mutable contact = profile.GetProperty("contact");

        string firstName = profile.GetProperty("firstName").GetString()!;
        string email = contact.GetProperty("email").GetString()!;

        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine();
        Console.WriteLine("Full JSON:");
        Console.WriteLine(root.ToString());
        Console.WriteLine();
    }

    static void Example4_CreateArrayDocument()
    {
        Console.WriteLine("--- Example 4: Create Array Document ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Array of numbers
        using var numbersDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.AddItem(10);
                arrayBuilder.AddItem(20);
                arrayBuilder.AddItem(30);
                arrayBuilder.AddItem(40);
                arrayBuilder.AddItem(50);
            }));

        Console.WriteLine("Numbers:");
        Console.WriteLine(numbersDoc.RootElement.ToString());

        // Array of strings
        using var namesDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.AddItem("Alice"u8);
                arrayBuilder.AddItem("Bob"u8);
                arrayBuilder.AddItem("Charlie"u8);
                arrayBuilder.AddItem("Diana"u8);
            }));

        Console.WriteLine("\nNames:");
        foreach (JsonElement.Mutable name in namesDoc.RootElement.EnumerateArray())
        {
            Console.WriteLine($"  - {name.GetString()}");
        }

        Console.WriteLine();
    }

    static void Example5_CreateArrayOfObjects()
    {
        Console.WriteLine("--- Example 5: Create Array of Objects ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var usersDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.AddItem(static (ref userBuilder) =>
                {
                    userBuilder.AddProperty("id"u8, 1);
                    userBuilder.AddProperty("name"u8, "Alice"u8);
                    userBuilder.AddProperty("role"u8, "Admin"u8);
                });

                arrayBuilder.AddItem(static (ref userBuilder) =>
                {
                    userBuilder.AddProperty("id"u8, 2);
                    userBuilder.AddProperty("name"u8, "Bob"u8);
                    userBuilder.AddProperty("role"u8, "User"u8);
                });

                arrayBuilder.AddItem(static (ref userBuilder) =>
                {
                    userBuilder.AddProperty("id"u8, 3);
                    userBuilder.AddProperty("name"u8, "Charlie"u8);
                    userBuilder.AddProperty("role"u8, "Moderator"u8);
                });
            }));

        Console.WriteLine("Users:");
        foreach (JsonElement.Mutable user in usersDoc.RootElement.EnumerateArray())
        {
            int id = user.GetProperty("id").GetInt32();
            string name = user.GetProperty("name").GetString()!;
            string role = user.GetProperty("role").GetString()!;
            Console.WriteLine($"  [{id}] {name} - {role}");
        }

        Console.WriteLine();
    }

    static void Example6_CreateFromExistingDocument()
    {
        Console.WriteLine("--- Example 6: Create from Existing Document ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        string json = """
            {
                "name": "Original Document",
                "value": 100,
                "active": true
            }
            """;

        using ParsedJsonDocument<JsonElement> sourceDoc =
            ParsedJsonDocument<JsonElement>.Parse(json);

        // Create a mutable builder from the parsed document
        using JsonDocumentBuilder<JsonElement.Mutable> builder =
            sourceDoc.RootElement.CreateBuilder(workspace);

        JsonElement.Mutable root = builder.RootElement;

        Console.WriteLine("Original:");
        Console.WriteLine(root.ToString());
        Console.WriteLine();

        // Modify it
        root.SetProperty("name", "Modified Document");
        root.SetProperty("value", 200);
        root.SetProperty("modified", "2026-02-24T11:00:00Z");

        Console.WriteLine("Modified:");
        Console.WriteLine(root.ToString());
        Console.WriteLine();
    }

    static void Example7_ModifyDocument()
    {
        Console.WriteLine("--- Example 7: Modify Document ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("counter"u8, 0);
                objectBuilder.AddProperty("status"u8, "initialized"u8);
                objectBuilder.AddProperty("items"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.AddItem("item1"u8);
                });
            }));

        JsonElement.Mutable root = doc.RootElement;

        Console.WriteLine("Initial:");
        Console.WriteLine(root.ToString());

        // Update properties
        root.SetProperty("counter", 42);
        root.SetProperty("status", "updated");
        root.SetProperty("timestamp", "2026-02-24T11:00:00Z");

        // Note: Array modification is more complex - we'll show adding new elements
        // by creating a new array builder
        Console.WriteLine("\nAfter modifications:");
        Console.WriteLine(root.ToString());
        Console.WriteLine();
    }

    static void Example8_BuildDynamicData()
    {
        Console.WriteLine("--- Example 8: Build Dynamic Data ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Dynamic data to include
        int[] years = [2020, 2021, 2022, 2023, 2024];

        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("id"u8, "12345"u8);
                objectBuilder.AddProperty("created"u8, "2026-02-24T11:00:00Z"u8);

                objectBuilder.AddProperty("profile"u8, static (ref profileBuilder) =>
                {
                    profileBuilder.AddProperty("username"u8, "john.doe"u8);
                    profileBuilder.AddProperty("displayName"u8, "John Doe"u8);
                });

                objectBuilder.AddProperty("tags"u8, static (ref tagsBuilder) =>
                {
                    tagsBuilder.AddItem("admin"u8);
                    tagsBuilder.AddItem("user"u8);
                    tagsBuilder.AddItem("verified"u8);
                });

                objectBuilder.AddProperty("metadata"u8, static (ref metaBuilder) =>
                {
                    metaBuilder.AddProperty("version"u8, "1.0.0"u8);
                    metaBuilder.AddProperty("revision"u8, 42);
                    metaBuilder.AddProperty("published"u8, true);
                });
            }));

        Console.WriteLine(doc.RootElement.ToString());
        Console.WriteLine();
    }

    static void Example9_BuildComplexStructure()
    {
        Console.WriteLine("--- Example 9: Build Complex Structure ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("company"u8, static (ref companyBuilder) =>
                {
                    companyBuilder.AddProperty("name"u8, "Tech Corp"u8);
                    companyBuilder.AddProperty("founded"u8, 2010);

                    companyBuilder.AddProperty("departments"u8, static (ref deptsBuilder) =>
                    {
                        // Engineering department
                        deptsBuilder.AddItem(static (ref deptBuilder) =>
                        {
                            deptBuilder.AddProperty("name"u8, "Engineering"u8);
                            deptBuilder.AddProperty("headCount"u8, 150);
                            deptBuilder.AddProperty("teams"u8, static (ref teamsBuilder) =>
                            {
                                teamsBuilder.AddItem("Backend"u8);
                                teamsBuilder.AddItem("Frontend"u8);
                                teamsBuilder.AddItem("DevOps"u8);
                            });
                        });

                        // Sales department
                        deptsBuilder.AddItem(static (ref deptBuilder) =>
                        {
                            deptBuilder.AddProperty("name"u8, "Sales"u8);
                            deptBuilder.AddProperty("headCount"u8, 75);
                            deptBuilder.AddProperty("teams"u8, static (ref teamsBuilder) =>
                            {
                                teamsBuilder.AddItem("Inside Sales"u8);
                                teamsBuilder.AddItem("Field Sales"u8);
                            });
                        });
                    });

                    companyBuilder.AddProperty("locations"u8, static (ref locationsBuilder) =>
                    {
                        // San Francisco location
                        locationsBuilder.AddItem(static (ref locationBuilder) =>
                        {
                            locationBuilder.AddProperty("city"u8, "San Francisco"u8);
                            locationBuilder.AddProperty("country"u8, "USA"u8);
                            locationBuilder.AddProperty("headquarters"u8, true);
                        });

                        // London location
                        locationsBuilder.AddItem(static (ref locationBuilder) =>
                        {
                            locationBuilder.AddProperty("city"u8, "London"u8);
                            locationBuilder.AddProperty("country"u8, "UK"u8);
                            locationBuilder.AddProperty("headquarters"u8, false);
                        });
                    });
                });
            }));

        Console.WriteLine(doc.RootElement.ToString());
        Console.WriteLine();
    }


    static void Example10_ArrayItemOperations()
    {
        Console.WriteLine("--- Example 10: Array Item Operations (SetItem) ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Create an array document
        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.AddItem(10);
                arrayBuilder.AddItem(20);
                arrayBuilder.AddItem(30);
                arrayBuilder.AddItem(40);
                arrayBuilder.AddItem(50);
            }));

        JsonElement.Mutable root = doc.RootElement;

        Console.WriteLine("Initial array:");
        Console.WriteLine(root.ToString());

        // Modify array items using SetItem
        root.SetItem(1, 200);  // Change 20 to 200
        root.SetItem(3, 400);  // Change 40 to 400

        Console.WriteLine("\nAfter SetItem modifications:");
        Console.WriteLine(root.ToString());

        // Create an object with arrays to show nested modification
        using var doc2 = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("tags"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.AddItem("alpha"u8);
                    arrayBuilder.AddItem("beta"u8);
                    arrayBuilder.AddItem("gamma"u8);
                });
            }));

        JsonElement.Mutable root2 = doc2.RootElement;
        Console.WriteLine("\nInitial document with tags:");
        Console.WriteLine(root2.ToString());

        // Get the tags array and modify it
        JsonElement.Mutable tags = root2.GetProperty("tags");
        tags.SetItem(1, "BETA");  // Change "beta" to "BETA"

        // IMPORTANT: Version tracking - after modifying the document, we need to
        // re-get the root element to see the changes. The modification incremented
        // the document's internal version, so our old 'root2' reference is now invalid.
        root2 = doc2.RootElement;
        Console.WriteLine("\nAfter modifying tags array:");
        Console.WriteLine(root2.ToString());
        Console.WriteLine();
    }

    static void Example11_RemoveProperties()
    {
        Console.WriteLine("--- Example 11: Remove Properties During Building ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // RemoveProperty is available during document construction via ObjectBuilder
        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                // Add initial properties
                objectBuilder.AddProperty("id"u8, 12345);
                objectBuilder.AddProperty("name"u8, "John Doe"u8);
                objectBuilder.AddProperty("email"u8, "john@example.com"u8);
                objectBuilder.AddProperty("phone"u8, "555-1234"u8);
                objectBuilder.AddProperty("address"u8, "123 Main St"u8);
                objectBuilder.AddProperty("temp"u8, "temporary data"u8);
                objectBuilder.AddProperty("debug"u8, true);

                // Remove properties before finalizing
                objectBuilder.RemoveProperty("temp"u8);
                objectBuilder.RemoveProperty("debug"u8);
                objectBuilder.RemoveProperty("address"u8);
            }));

        JsonElement.Mutable root = doc.RootElement;

        Console.WriteLine("Document after building (temp, debug, and address removed):");
        Console.WriteLine(root.ToString());
        Console.WriteLine();
    }

    static void Example12_RemoveArrayItems()
    {
        Console.WriteLine("--- Example 12: Remove Array Items (Remove, RemoveRange) ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Create document with arrays
        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("numbers"u8, static (ref arrayBuilder) =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        arrayBuilder.AddItem(i * 10);
                    }
                });

                objectBuilder.AddProperty("colors"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.AddItem("red"u8);
                    arrayBuilder.AddItem("orange"u8);
                    arrayBuilder.AddItem("yellow"u8);
                    arrayBuilder.AddItem("green"u8);
                    arrayBuilder.AddItem("blue"u8);
                    arrayBuilder.AddItem("indigo"u8);
                    arrayBuilder.AddItem("violet"u8);
                });
            }));

        JsonElement.Mutable root = doc.RootElement;

        Console.WriteLine("Initial document:");
        Console.WriteLine(root.ToString());

        // Remove single item from numbers array
        JsonElement.Mutable numbers = root.GetProperty("numbers");
        Console.WriteLine($"\nNumbers array length before: {numbers.GetArrayLength()}");

        numbers.RemoveAt(5);  // Remove item at index 5 (value 50)
        Console.WriteLine($"Removed item at index 5");
        Console.WriteLine($"Numbers array length after: {numbers.GetArrayLength()}");
        Console.WriteLine($"Numbers: {numbers.ToString()}");

        // IMPORTANT: Version tracking - after modifying 'numbers', our 'root' reference
        // becomes invalid. We must re-get it from doc.RootElement before accessing
        // other properties like 'colors'. This prevents accessing stale data.
        root = doc.RootElement;

        // Remove a range from colors array
        JsonElement.Mutable colors = root.GetProperty("colors");
        Console.WriteLine($"\nColors array length before: {colors.GetArrayLength()}");

        colors.RemoveRange(2, 3);  // Remove 3 items starting at index 2 (yellow, green, blue)
        Console.WriteLine($"Removed range starting at index 2, count 3");
        Console.WriteLine($"Colors array length after: {colors.GetArrayLength()}");
        Console.WriteLine($"Colors: {colors.ToString()}");

        // Version tracking: After modifying 'colors', we need fresh references again
        numbers = doc.RootElement.GetProperty("numbers");

        // Remove multiple single items
        numbers.RemoveAt(0);  // Remove first item
        numbers.RemoveAt(numbers.GetArrayLength() - 1);  // Remove last item

        Console.WriteLine($"\nAfter removing first and last from numbers:");
        Console.WriteLine($"Numbers: {numbers.ToString()}");

        // Version tracking: Get fresh reference for RemoveWhere operation
        colors = doc.RootElement.GetProperty("colors");

        // Demonstrate RemoveWhere with predicate
        Console.WriteLine($"\nColors before RemoveWhere: {colors.ToString()}");
        colors.RemoveWhere((in JsonElement element) =>
        {
            string? color = element.GetString();
            return color != null && color.StartsWith("r");  // Remove colors starting with 'r'
        });
        Console.WriteLine($"Colors after removing items starting with 'r': {colors.ToString()}");

        Console.WriteLine("\nFinal document:");
        Console.WriteLine(doc.RootElement.ToString());
        Console.WriteLine();
    }

    static async Task Example13_BuildFromApiDataAsync()
    {
        Console.WriteLine("--- Example 13: Build Document from External API Data ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Simulate fetching user data from an external API
        string apiResponse = """
            {
                "id": 12345,
                "username": "johndoe",
                "email": "john@example.com",
                "created": "2024-01-15T10:30:00Z"
            }
            """;

        Console.WriteLine("API Response:");
        Console.WriteLine(apiResponse);

        // Parse the API response - explicitly use Corvus.Text.Json.JsonElement
        using ParsedJsonDocument<JsonElement> apiDoc =
            ParsedJsonDocument<JsonElement>.Parse(apiResponse);
        JsonElement apiRoot = apiDoc.RootElement;

        // Simulate additional data from database or other sources
        string[] permissions = ["read", "write", "admin"];
        var preferences = new { theme = "dark", language = "en", notifications = true };
        DateTime lastLogin = DateTime.UtcNow.AddHours(-2);
        int loginCount = 42;

        // Build an enriched document combining API data with additional information
        using var enrichedDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // Data from API - use AddRawString and AddFormattedNumber with native properties
                JsonElement idEl = apiRoot.GetProperty("id");
                objectBuilder.AddProperty("userId"u8, idEl);

                JsonElement usernameEl = apiRoot.GetProperty("username");
                objectBuilder.AddProperty("username"u8, usernameEl);

                JsonElement emailEl = apiRoot.GetProperty("email");
                objectBuilder.AddProperty("email"u8, emailEl);

                JsonElement createdEl = apiRoot.GetProperty("created");
                objectBuilder.AddProperty("accountCreated"u8, createdEl);

                // Augmented data from other sources
                objectBuilder.AddProperty("profile"u8, static (ref profileBuilder) =>
                {
                    profileBuilder.AddProperty("displayName"u8, "John Doe"u8);
                    profileBuilder.AddProperty("bio"u8, "Software developer and coffee enthusiast"u8);
                    profileBuilder.AddProperty("avatar"u8, "https://example.com/avatars/johndoe.jpg"u8);
                    profileBuilder.AddProperty("verified"u8, true);
                });

                // Permissions array from database
                objectBuilder.AddProperty("permissions"u8, (ref permBuilder) =>
                {
                    foreach (string permission in permissions)
                    {
                        permBuilder.AddItem(permission);  // ArrayBuilder has string overload
                    }
                });

                // User preferences
                objectBuilder.AddProperty("preferences"u8, (ref JsonElement.ObjectBuilder prefBuilder) =>
                {
                    prefBuilder.AddProperty("theme"u8, preferences.theme);  // string overload
                    prefBuilder.AddProperty("language"u8, preferences.language);
                    prefBuilder.AddProperty("notifications"u8, preferences.notifications);
                });

                // Activity tracking
                objectBuilder.AddProperty("activity"u8, (ref activityBuilder) =>
                {
                    activityBuilder.AddProperty("lastLogin"u8, lastLogin);  // DateTime overload
                    activityBuilder.AddProperty("loginCount"u8, loginCount);
                    activityBuilder.AddProperty("status"u8, "active"u8);
                });

                // Metadata
                objectBuilder.AddProperty("metadata"u8, static (ref metaBuilder) =>
                {
                    metaBuilder.AddProperty("enrichedAt"u8, DateTime.UtcNow);  // DateTime overload
                    metaBuilder.AddProperty("version"u8, "2.0"u8);
                    metaBuilder.AddProperty("source"u8, "user-service"u8);
                });
            }));

        Console.WriteLine("\nEnriched Document:");
        Console.WriteLine(enrichedDoc.RootElement.ToString());

        // Example: Modify based on business logic
        JsonElement.Mutable root = enrichedDoc.RootElement;

        // If login count is high, add a badge
        if (loginCount > 40)
        {
            // Get current root to add new property
            root = enrichedDoc.RootElement;

            // Note: We'd need to rebuild to add properties after initial construction
            // This demonstrates that you might parse, transform, and rebuild
        }

        Console.WriteLine("\n--- Scenario: Merging Multiple API Responses ---");

        // Simulate fetching related data from another API
        string postsApiResponse = """
            {
                "posts": [
                    {"id": 1, "title": "Hello World", "likes": 42},
                    {"id": 2, "title": "JSON Tips", "likes": 128}
                ],
                "totalPosts": 2
            }
            """;

        using ParsedJsonDocument<JsonElement> postsDoc = ParsedJsonDocument<JsonElement>.Parse(postsApiResponse);
        JsonElement postsRoot = postsDoc.RootElement;
        JsonElement postsArray = postsRoot.GetProperty("posts");
        int totalPosts = postsRoot.GetProperty("totalPosts").GetInt32();

        // Create a comprehensive document merging user and posts data
        using var mergedDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // User summary from first API
                objectBuilder.AddProperty("user", (ref userBuilder) =>
                {
                    userBuilder.AddProperty("id", apiRoot.GetProperty("id"));
                    userBuilder.AddProperty("username", apiRoot.GetProperty("username"));
                    userBuilder.AddProperty("email", apiRoot.GetProperty("email"));
                });

                // Posts from second API - iterate and use native JsonElement values
                objectBuilder.AddProperty("posts", (ref postsBuilder) =>
                {
                    foreach (JsonElement post in postsArray.EnumerateArray())
                    {
                        postsBuilder.AddItem((ref postBuilder) =>
                        {
                            // Use native JsonElement directly
                            postBuilder.AddProperty("id", post.GetProperty("id"));
                            postBuilder.AddProperty("title", post.GetProperty("title"));
                            postBuilder.AddProperty("likes", post.GetProperty("likes"));

                            // Augment with computed data
                            int likes = post.GetProperty("likes").GetInt32();
                            postBuilder.AddProperty("popular", likes > 100);
                        });
                    }
                });

                // Summary statistics
                objectBuilder.AddProperty("stats"u8, (ref statsBuilder) =>
                {
                    statsBuilder.AddProperty("totalPosts"u8, totalPosts);
                    statsBuilder.AddProperty("totalLikes"u8, 170);  // Could be computed
                    statsBuilder.AddProperty("avgLikesPerPost"u8, 85.0);
                });

                // Add timestamp
                objectBuilder.AddProperty("generatedAt"u8, DateTime.UtcNow);
            }));

        Console.WriteLine("\nMerged Document from Multiple APIs:");
        Console.WriteLine(mergedDoc.RootElement.ToString());

        Console.WriteLine("\n--- Use Case: Transform API Response Format ---");

        // Simulate an API response in one format that needs transformation
        string legacyApiResponse = """
            {
                "user_id": 999,
                "user_name": "alice",
                "user_email": "alice@example.com",
                "user_role": "admin",
                "last_login_date": "2024-02-24"
            }
            """;

        using ParsedJsonDocument<JsonElement> legacyDoc = ParsedJsonDocument<JsonElement>.Parse(legacyApiResponse);
        JsonElement legacyRoot = legacyDoc.RootElement;

        // Transform to modern format
        using var transformedDoc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // Map old field names to new structure using native JsonElement
                objectBuilder.AddProperty("id", legacyRoot.GetProperty("user_id"));

                objectBuilder.AddProperty("account", (ref accountBuilder) =>
                {
                    accountBuilder.AddProperty("username", legacyRoot.GetProperty("user_name"));
                    accountBuilder.AddProperty("email", legacyRoot.GetProperty("user_email"));
                });

                objectBuilder.AddProperty("authorization", (ref authBuilder) =>
                {
                    JsonElement roleElement = legacyRoot.GetProperty("user_role");
                    authBuilder.AddProperty("role", roleElement);
                    authBuilder.AddProperty("isAdmin", roleElement.GetString() == "admin");
                });

                objectBuilder.AddProperty("lastLogin", legacyRoot.GetProperty("last_login_date"));

                // Add modern fields
                objectBuilder.AddProperty("apiVersion", "v2");
                objectBuilder.AddProperty("transformed", true);
            }));

        Console.WriteLine("\nTransformed from Legacy Format:");
        Console.WriteLine("Original:");
        Console.WriteLine(legacyApiResponse);
        Console.WriteLine("\nTransformed:");
        Console.WriteLine(transformedDoc.RootElement.ToString());

        Console.WriteLine();
    }

    static async Task Example14_WriteToFileAsync()
    {
        Console.WriteLine("--- Example 14: Write to File ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var config = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("appName"u8, "JsonDocumentBuilder Demo"u8);
                objectBuilder.AddProperty("version"u8, "1.0.0"u8);
                objectBuilder.AddProperty("environment"u8, "development"u8);

                objectBuilder.AddProperty("database"u8, static (ref dbBuilder) =>
                {
                    dbBuilder.AddProperty("host"u8, "localhost"u8);
                    dbBuilder.AddProperty("port"u8, 5432);
                    dbBuilder.AddProperty("name"u8, "demo_db"u8);
                    dbBuilder.AddProperty("ssl"u8, false);
                });

                objectBuilder.AddProperty("features"u8, static (ref featuresBuilder) =>
                {
                    featuresBuilder.AddProperty("logging"u8, true);
                    featuresBuilder.AddProperty("caching"u8, true);
                    featuresBuilder.AddProperty("compression"u8, false);
                    featuresBuilder.AddProperty("authentication"u8, true);
                });

                objectBuilder.AddProperty("logging"u8, static (ref loggingBuilder) =>
                {
                    loggingBuilder.AddProperty("level"u8, "Debug"u8);
                    loggingBuilder.AddProperty("console"u8, true);
                    loggingBuilder.AddProperty("file"u8, "logs/app.log"u8);
                });
            }));

        string tempFile = Path.Combine(Path.GetTempPath(), "example-config.json");

        try
        {
            // Write to file with formatting
            using (var stream = File.OpenWrite(tempFile))
            using (var writer = new Utf8JsonWriter(
                stream,
                new JsonWriterOptions { Indented = true }))
            {
                config.WriteTo(writer);
            }

            string json = File.ReadAllText(tempFile);
            Console.WriteLine($"Configuration written to: {tempFile}");
            Console.WriteLine("\nContent:");
            Console.WriteLine(json);
        }
        finally
        {
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
                Console.WriteLine($"\nCleaned up temporary file: {tempFile}");
            }
        }

        Console.WriteLine();
    }

    static void Example15_SerializeWithRentedWriter()
    {
        Console.WriteLine("--- Example 15: Serialize with Rented Writer and Buffer ---");

        // Configure writer options - applies to all rented writers
        var writerOptions = new JsonWriterOptions { Indented = true };
        using JsonWorkspace workspace = JsonWorkspace.Create(options: writerOptions);

        // Build a document
        using var doc = JsonElement.CreateBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.AddProperty("message"u8, "Hello from rented writer!"u8);
                objectBuilder.AddProperty("timestamp"u8, DateTime.UtcNow);
                objectBuilder.AddProperty("success"u8, true);

                objectBuilder.AddProperty("items"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.AddItem(1);
                    arrayBuilder.AddItem(2);
                    arrayBuilder.AddItem(3);
                });
            }));

        // Rent writer + buffer for serialization
        Utf8JsonWriter writer = workspace.RentWriterAndBuffer(
            defaultBufferSize: 1024,
            out IByteBufferWriter bufferWriter);

        try
        {
            // Write the document to the rented writer
            doc.WriteTo(writer);
            writer.Flush();

            // Get the serialized result
            ReadOnlySpan<byte> jsonBytes = bufferWriter.WrittenSpan;
            string json = Encoding.UTF8.GetString(jsonBytes);

            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);
        }
        finally
        {
            // Always return rented resources
            workspace.ReturnWriterAndBuffer(writer, bufferWriter);
        }

        Console.WriteLine();
    }

    static async Task Example16_SerializeToStreamAsync()
    {
        Console.WriteLine("--- Example 16: Serialize to Stream (File) ---");

        string tempFile = Path.Combine(Path.GetTempPath(), "document-builder-output.json");

        try
        {
            // Build document and serialize to buffer within workspace scope
            ReadOnlyMemory<byte> jsonBytes;

            using (JsonWorkspace workspace = JsonWorkspace.Create(
                options: new JsonWriterOptions { Indented = true }))
            {
                // Build the document
                using var doc = JsonElement.CreateBuilder(
                    workspace,
                    new JsonElement.Source(static (ref objectBuilder) =>
                    {
                        objectBuilder.AddProperty("configName"u8, "Production Settings"u8);
                        objectBuilder.AddProperty("version"u8, "2.0"u8);
                        objectBuilder.AddProperty("lastModified"u8, DateTime.UtcNow);

                        objectBuilder.AddProperty("database"u8, static (ref dbBuilder) =>
                        {
                            dbBuilder.AddProperty("host"u8, "db.example.com"u8);
                            dbBuilder.AddProperty("port"u8, 5432);
                            dbBuilder.AddProperty("name"u8, "production_db"u8);
                        });

                        objectBuilder.AddProperty("features"u8, static (ref featuresBuilder) =>
                        {
                            featuresBuilder.AddProperty("logging"u8, true);
                            featuresBuilder.AddProperty("caching"u8, true);
                            featuresBuilder.AddProperty("debug"u8, false);
                        });
                    }));

                // Rent writer and buffer for serialization
                Utf8JsonWriter writer = workspace.RentWriterAndBuffer(
                    defaultBufferSize: 2048,
                    out IByteBufferWriter bufferWriter);

                try
                {
                    // Write document to buffer
                    doc.WriteTo(writer);
                    writer.Flush();

                    // Get the bytes before returning the buffer
                    jsonBytes = bufferWriter.WrittenMemory.ToArray();
                }
                finally
                {
                    workspace.ReturnWriterAndBuffer(writer, bufferWriter);
                }
            } // Workspace disposed before async operations

            // Write to file asynchronously (after workspace disposal)
            await File.WriteAllBytesAsync(tempFile, jsonBytes.ToArray());

            // Read back and display (async operation after workspace disposal)
            string json = await File.ReadAllTextAsync(tempFile);
            Console.WriteLine($"Written to: {tempFile}");
            Console.WriteLine("\nContent:");
            Console.WriteLine(json);
        }
        finally
        {
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
                Console.WriteLine($"\nCleaned up: {tempFile}");
            }
        }

        Console.WriteLine();
    }

    static async Task Example17_SimulateAspNetCoreResponseAsync()
    {
        Console.WriteLine("--- Example 17: Simulate ASP.NET Core Response Writing ---");
        Console.WriteLine("(Demonstrates the pattern: fetch async -> build sync -> flush async)\n");

        // Simulate fetching user data from an API (async)
        string userData = await SimulateFetchUserDataAsync();
        Console.WriteLine($"Fetched user data: {userData}");

        // Simulate ASP.NET Core PipeWriter with ArrayBufferWriter
        var responseBuffer = new ArrayBufferWriter<byte>();

        // Build and write response (synchronous, within workspace scope)
        using (JsonWorkspace workspace = JsonWorkspace.Create(
            options: new JsonWriterOptions { Indented = false }))
        {
            // Build the response document
            using var doc = JsonElement.CreateBuilder(
                workspace,
                new JsonElement.Source((ref objectBuilder) =>
                {
                    objectBuilder.AddProperty("success"u8, true);
                    objectBuilder.AddProperty("timestamp"u8, DateTime.UtcNow);
                    objectBuilder.AddProperty("requestId"u8, Guid.NewGuid().ToString());

                    objectBuilder.AddProperty("data"u8, (ref dataBuilder) =>
                    {
                        dataBuilder.AddProperty("username"u8, Encoding.UTF8.GetBytes(userData));
                        dataBuilder.AddProperty("lastLogin"u8, DateTime.UtcNow.AddDays(-2));
                        dataBuilder.AddProperty("isActive"u8, true);
                    });
                }));

            // Rent writer for the response buffer (in real ASP.NET Core, this would be context.Response.BodyWriter)
            Utf8JsonWriter writer = workspace.RentWriter(responseBuffer);

            try
            {
                // Write document directly to response pipe - zero copies!
                doc.WriteTo(writer);
                writer.Flush();
            }
            finally
            {
                workspace.ReturnWriter(writer);
            }
        } // Workspace disposed before any awaits

        // Simulate flushing the response (async operation happens AFTER workspace disposal)
        await SimulateFlushResponseAsync(responseBuffer);

        Console.WriteLine("\nSimulated API response:");
        Console.WriteLine(Encoding.UTF8.GetString(responseBuffer.WrittenSpan));
        Console.WriteLine("\nKey pattern: Async fetch -> Sync build+write -> Async flush");
        Console.WriteLine();
    }

    // Helper methods for Example 17
    static async Task<string> SimulateFetchUserDataAsync()
    {
        await Task.Delay(50); // Simulate API call
        return "john.doe";
    }

    static async Task SimulateFlushResponseAsync(ArrayBufferWriter<byte> buffer)
    {
        await Task.Delay(10); // Simulate flushing to network
    }

    static async Task Example18_ComposeFromMultipleApisAsync()
    {
        Console.WriteLine("--- Example 18: Compose Documents from Multiple Async API Calls ---");

        // Simulate fetching data from multiple APIs concurrently
        // This demonstrates that ParsedJsonDocument is safe across async boundaries
        Console.WriteLine("Fetching data from multiple APIs in parallel...");

        Task<ParsedJsonDocument<JsonElement>> userTask = FetchUserDataAsync(123);
        Task<ParsedJsonDocument<JsonElement>> postsTask = FetchUserPostsAsync(123);
        Task<ParsedJsonDocument<JsonElement>> analyticsTask = FetchUserAnalyticsAsync(123);

        // Wait for all APIs to complete
        await Task.WhenAll(userTask, postsTask, analyticsTask);

        using ParsedJsonDocument<JsonElement> userDoc = await userTask;
        using ParsedJsonDocument<JsonElement> postsDoc = await postsTask;
        using ParsedJsonDocument<JsonElement> analyticsDoc = await analyticsTask;

        Console.WriteLine("All API calls completed. Composing profile document...");

        // All async work is done, use regular workspace
        using (JsonWorkspace workspace = JsonWorkspace.Create())
        {
            using var profileDoc = JsonElement.CreateBuilder(
                workspace,
                new JsonElement.Source((ref objectBuilder) =>
                {
                    // User info from first API
                    JsonElement user = userDoc.RootElement;
                    objectBuilder.AddProperty("userId"u8, user.GetProperty("id"));
                    objectBuilder.AddProperty("username"u8, user.GetProperty("username"));
                    objectBuilder.AddProperty("email"u8, user.GetProperty("email"));

                    // Posts from second API
                    objectBuilder.AddProperty("recentPosts"u8, (ref postsBuilder) =>
                    {
                        JsonElement posts = postsDoc.RootElement.GetProperty("posts");
                        foreach (JsonElement post in posts.EnumerateArray())
                        {
                            postsBuilder.AddItem((ref postBuilder) =>
                            {
                                postBuilder.AddProperty("id"u8, post.GetProperty("id"));
                                postBuilder.AddProperty("title"u8, post.GetProperty("title"));
                                postBuilder.AddProperty("publishedAt"u8, post.GetProperty("publishedAt"));
                            });
                        }
                    });

                    // Analytics from third API
                    objectBuilder.AddProperty("stats"u8, (ref statsBuilder) =>
                    {
                        JsonElement analytics = analyticsDoc.RootElement;
                        statsBuilder.AddProperty("totalViews"u8, analytics.GetProperty("totalViews"));
                        statsBuilder.AddProperty("totalLikes"u8, analytics.GetProperty("totalLikes"));
                        statsBuilder.AddProperty("followerCount"u8, analytics.GetProperty("followerCount"));
                    });

                    // Computed fields
                    DateTime lastLogin = userDoc.RootElement.GetProperty("lastLoginAt").GetDateTime();
                    objectBuilder.AddProperty("isActive"u8, lastLogin > DateTime.UtcNow.AddDays(-30));
                }));

            Console.WriteLine("\nComposed User Profile:");
            Console.WriteLine(profileDoc.RootElement.ToString());
        }

        Console.WriteLine();
    }

    // Helper methods to simulate API calls
    static async Task<ParsedJsonDocument<JsonElement>> FetchUserDataAsync(int userId)
    {
        await Task.Delay(50); // Simulate network delay

        string json = """
            {
                "id": 123,
                "username": "johndoe",
                "email": "john@example.com",
                "lastLoginAt": "2024-02-20T10:30:00Z"
            }
            """;

        return ParsedJsonDocument<JsonElement>.Parse(json);
    }

    static async Task<ParsedJsonDocument<JsonElement>> FetchUserPostsAsync(int userId)
    {
        await Task.Delay(75); // Simulate network delay

        string json = """
            {
                "posts": [
                    {
                        "id": 1,
                        "title": "Getting Started with JSON",
                        "publishedAt": "2024-02-15T08:00:00Z"
                    },
                    {
                        "id": 2,
                        "title": "Advanced JSON Patterns",
                        "publishedAt": "2024-02-18T14:30:00Z"
                    }
                ]
            }
            """;

        return ParsedJsonDocument<JsonElement>.Parse(json);
    }

    static async Task<ParsedJsonDocument<JsonElement>> FetchUserAnalyticsAsync(int userId)
    {
        await Task.Delay(60); // Simulate network delay

        string json = """
            {
                "totalViews": 15420,
                "totalLikes": 892,
                "followerCount": 347
            }
            """;

        return ParsedJsonDocument<JsonElement>.Parse(json);
    }

    static async Task Example19_BuildAcrossAsyncBoundariesAsync()
    {
        Console.WriteLine("--- Example 19: Building Document Across Async Boundaries with CreateUnrented ---");

        // Sometimes you need to partially build a document, make an async call,
        // then continue building. The regular JsonWorkspace.Create() uses thread-static
        // storage and will fail across async boundaries. Use CreateUnrented() instead.

        Console.WriteLine("Fetching initial data...");
        string initialData = await FetchInitialDataAsync();
        using ParsedJsonDocument<JsonElement> initialDoc = ParsedJsonDocument<JsonElement>.Parse(initialData);

        Console.WriteLine("Building document with CreateUnrented to safely cross async boundaries...");

        // Use CreateUnrented() - this workspace can cross async boundaries
        using (JsonWorkspace workspace = JsonWorkspace.CreateUnrented())
        {
            // Start building the document
            using var doc = JsonElement.CreateBuilder(
                workspace,
                new JsonElement.Source((ref objectBuilder) =>
                {
                    objectBuilder.AddProperty("initialData"u8, initialDoc.RootElement.GetProperty("value"));
                    objectBuilder.AddProperty("timestamp"u8, DateTime.UtcNow);
                }));

            Console.WriteLine("Making async call in the middle of document building...");
            
            // Make an async call - workspace survives the await because it's unrented
            string additionalData = await FetchAdditionalDataAsync();
            using ParsedJsonDocument<JsonElement> additionalDoc = ParsedJsonDocument<JsonElement>.Parse(additionalData);

            Console.WriteLine("Continuing to build document after async operation...");

            // Continue modifying the document after the await
            JsonElement.Mutable mutableRoot = doc.RootElement;
            mutableRoot.SetProperty("additionalData", additionalDoc.RootElement.GetProperty("extra"));
            mutableRoot.SetProperty("completedAt", DateTime.UtcNow);

            Console.WriteLine("\nCompleted Document:");
            Console.WriteLine(doc.RootElement.ToString());

            // Important: The workspace will dispose all mutable documents it created (doc),
            // but NOT the immutable ParsedJsonDocuments (initialDoc, additionalDoc) -
            // those are managed separately with their own using statements
        }

        Console.WriteLine();
    }

    static async Task<string> FetchInitialDataAsync()
    {
        await Task.Delay(30);
        return """{"value": "initial-123"}""";
    }

    static async Task<string> FetchAdditionalDataAsync()
    {
        await Task.Delay(40);
        return """{"extra": "additional-456"}""";
    }
}
