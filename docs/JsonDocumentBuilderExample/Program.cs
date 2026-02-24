using Corvus.Text.Json;
using System;
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

        // Example 14: Write to file
        await Example14_WriteToFileAsync();

        Console.WriteLine("\nAll examples completed!");
    }

    static void Example1_CreateFromPrimitives()
    {
        Console.WriteLine("--- Example 1: Create from Primitives ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Integer
        using var intDoc = JsonElement.CreateDocumentBuilder(workspace, 42);
        Console.WriteLine($"Integer: {intDoc.RootElement.GetInt32()}");

        // Double
        using var doubleDoc = JsonElement.CreateDocumentBuilder(workspace, 3.14159);
        Console.WriteLine($"Double: {doubleDoc.RootElement.GetDouble():F5}");

        // String
        using var stringDoc = JsonElement.CreateDocumentBuilder(workspace, "Hello, World!");
        Console.WriteLine($"String: {stringDoc.RootElement.GetString()}");

        // UTF-8
        using var utf8Doc = JsonElement.CreateDocumentBuilder(workspace, "Hello"u8);
        Console.WriteLine($"UTF-8: {utf8Doc.RootElement.GetString()}");

        // Boolean
        using var boolDoc = JsonElement.CreateDocumentBuilder(workspace, true);
        Console.WriteLine($"Boolean: {boolDoc.RootElement.GetBoolean()}");

        // Null
        using var nullDoc = JsonElement.CreateDocumentBuilder(workspace, JsonElement.Source.Null());
        Console.WriteLine($"Null: {nullDoc.RootElement.ValueKind}");

        Console.WriteLine();
    }

    static void Example2_CreateObjectDocument()
    {
        Console.WriteLine("--- Example 2: Create Object Document ---");

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
        Console.WriteLine();
    }

    static void Example3_CreateNestedObjects()
    {
        Console.WriteLine("--- Example 3: Create Nested Objects ---");

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
                        profileBuilder.Add("contact"u8, static (ref contactBuilder) =>
                        {
                            contactBuilder.Add("email"u8, "jane.doe@example.com"u8);
                            contactBuilder.Add("phone"u8, "555-0123"u8);
                        });
                    });
                });
                
                objectBuilder.Add("timestamp"u8, "2026-02-24T11:00:00Z"u8);
                objectBuilder.Add("active"u8, true);
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
        using var numbersDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.Add(10);
                arrayBuilder.Add(20);
                arrayBuilder.Add(30);
                arrayBuilder.Add(40);
                arrayBuilder.Add(50);
            }));

        Console.WriteLine("Numbers:");
        Console.WriteLine(numbersDoc.RootElement.ToString());

        // Array of strings
        using var namesDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.Add("Alice"u8);
                arrayBuilder.Add("Bob"u8);
                arrayBuilder.Add("Charlie"u8);
                arrayBuilder.Add("Diana"u8);
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

        using var usersDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.Add(static (ref userBuilder) =>
                {
                    userBuilder.Add("id"u8, 1);
                    userBuilder.Add("name"u8, "Alice"u8);
                    userBuilder.Add("role"u8, "Admin"u8);
                });
                
                arrayBuilder.Add(static (ref userBuilder) =>
                {
                    userBuilder.Add("id"u8, 2);
                    userBuilder.Add("name"u8, "Bob"u8);
                    userBuilder.Add("role"u8, "User"u8);
                });
                
                arrayBuilder.Add(static (ref userBuilder) =>
                {
                    userBuilder.Add("id"u8, 3);
                    userBuilder.Add("name"u8, "Charlie"u8);
                    userBuilder.Add("role"u8, "Moderator"u8);
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
            sourceDoc.RootElement.CreateDocumentBuilder(workspace);

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

        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("counter"u8, 0);
                objectBuilder.Add("status"u8, "initialized"u8);
                objectBuilder.Add("items"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.Add("item1"u8);
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

        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("id"u8, "12345"u8);
                objectBuilder.Add("created"u8, "2026-02-24T11:00:00Z"u8);
                
                objectBuilder.Add("profile"u8, static (ref profileBuilder) =>
                {
                    profileBuilder.Add("username"u8, "john.doe"u8);
                    profileBuilder.Add("displayName"u8, "John Doe"u8);
                });
                
                objectBuilder.Add("tags"u8, static (ref tagsBuilder) =>
                {
                    tagsBuilder.Add("admin"u8);
                    tagsBuilder.Add("user"u8);
                    tagsBuilder.Add("verified"u8);
                });
                
                objectBuilder.Add("metadata"u8, static (ref metaBuilder) =>
                {
                    metaBuilder.Add("version"u8, "1.0.0"u8);
                    metaBuilder.Add("revision"u8, 42);
                    metaBuilder.Add("published"u8, true);
                });
            }));

        Console.WriteLine(doc.RootElement.ToString());
        Console.WriteLine();
    }

    static void Example9_BuildComplexStructure()
    {
        Console.WriteLine("--- Example 9: Build Complex Structure ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("company"u8, static (ref companyBuilder) =>
                {
                    companyBuilder.Add("name"u8, "Tech Corp"u8);
                    companyBuilder.Add("founded"u8, 2010);
                    
                    companyBuilder.Add("departments"u8, static (ref deptsBuilder) =>
                    {
                        // Engineering department
                        deptsBuilder.Add(static (ref deptBuilder) =>
                        {
                            deptBuilder.Add("name"u8, "Engineering"u8);
                            deptBuilder.Add("headCount"u8, 150);
                            deptBuilder.Add("teams"u8, static (ref teamsBuilder) =>
                            {
                                teamsBuilder.Add("Backend"u8);
                                teamsBuilder.Add("Frontend"u8);
                                teamsBuilder.Add("DevOps"u8);
                            });
                        });
                        
                        // Sales department
                        deptsBuilder.Add(static (ref deptBuilder) =>
                        {
                            deptBuilder.Add("name"u8, "Sales"u8);
                            deptBuilder.Add("headCount"u8, 75);
                            deptBuilder.Add("teams"u8, static (ref teamsBuilder) =>
                            {
                                teamsBuilder.Add("Inside Sales"u8);
                                teamsBuilder.Add("Field Sales"u8);
                            });
                        });
                    });
                    
                    companyBuilder.Add("locations"u8, static (ref locationsBuilder) =>
                    {
                        // San Francisco location
                        locationsBuilder.Add(static (ref locationBuilder) =>
                        {
                            locationBuilder.Add("city"u8, "San Francisco"u8);
                            locationBuilder.Add("country"u8, "USA"u8);
                            locationBuilder.Add("headquarters"u8, true);
                        });
                        
                        // London location
                        locationsBuilder.Add(static (ref locationBuilder) =>
                        {
                            locationBuilder.Add("city"u8, "London"u8);
                            locationBuilder.Add("country"u8, "UK"u8);
                            locationBuilder.Add("headquarters"u8, false);
                        });
                    });
                });
            }));

        Console.WriteLine(doc.RootElement.ToString());
        Console.WriteLine();
    }

    static async Task Example14_WriteToFileAsync()
    {
        Console.WriteLine("--- Example 14: Write to File ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        using var config = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("appName"u8, "JsonDocumentBuilder Demo"u8);
                objectBuilder.Add("version"u8, "1.0.0"u8);
                objectBuilder.Add("environment"u8, "development"u8);
                
                objectBuilder.Add("database"u8, static (ref dbBuilder) =>
                {
                    dbBuilder.Add("host"u8, "localhost"u8);
                    dbBuilder.Add("port"u8, 5432);
                    dbBuilder.Add("name"u8, "demo_db"u8);
                    dbBuilder.Add("ssl"u8, false);
                });
                
                objectBuilder.Add("features"u8, static (ref featuresBuilder) =>
                {
                    featuresBuilder.Add("logging"u8, true);
                    featuresBuilder.Add("caching"u8, true);
                    featuresBuilder.Add("compression"u8, false);
                    featuresBuilder.Add("authentication"u8, true);
                });
                
                objectBuilder.Add("logging"u8, static (ref loggingBuilder) =>
                {
                    loggingBuilder.Add("level"u8, "Debug"u8);
                    loggingBuilder.Add("console"u8, true);
                    loggingBuilder.Add("file"u8, "logs/app.log"u8);
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

    static void Example10_ArrayItemOperations()
    {
        Console.WriteLine("--- Example 10: Array Item Operations (SetItem) ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Create an array document
        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref arrayBuilder) =>
            {
                arrayBuilder.Add(10);
                arrayBuilder.Add(20);
                arrayBuilder.Add(30);
                arrayBuilder.Add(40);
                arrayBuilder.Add(50);
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
        using var doc2 = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("tags"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.Add("alpha"u8);
                    arrayBuilder.Add("beta"u8);
                    arrayBuilder.Add("gamma"u8);
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
        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                // Add initial properties
                objectBuilder.Add("id"u8, 12345);
                objectBuilder.Add("name"u8, "John Doe"u8);
                objectBuilder.Add("email"u8, "john@example.com"u8);
                objectBuilder.Add("phone"u8, "555-1234"u8);
                objectBuilder.Add("address"u8, "123 Main St"u8);
                objectBuilder.Add("temp"u8, "temporary data"u8);
                objectBuilder.Add("debug"u8, true);
                
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
        using var doc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source(static (ref objectBuilder) =>
            {
                objectBuilder.Add("numbers"u8, static (ref arrayBuilder) =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        arrayBuilder.Add(i * 10);
                    }
                });

                objectBuilder.Add("colors"u8, static (ref arrayBuilder) =>
                {
                    arrayBuilder.Add("red"u8);
                    arrayBuilder.Add("orange"u8);
                    arrayBuilder.Add("yellow"u8);
                    arrayBuilder.Add("green"u8);
                    arrayBuilder.Add("blue"u8);
                    arrayBuilder.Add("indigo"u8);
                    arrayBuilder.Add("violet"u8);
                });
            }));

        JsonElement.Mutable root = doc.RootElement;
        
        Console.WriteLine("Initial document:");
        Console.WriteLine(root.ToString());

        // Remove single item from numbers array
        JsonElement.Mutable numbers = root.GetProperty("numbers");
        Console.WriteLine($"\nNumbers array length before: {numbers.GetArrayLength()}");
        
        numbers.Remove(5);  // Remove item at index 5 (value 50)
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
        numbers.Remove(0);  // Remove first item
        numbers.Remove(numbers.GetArrayLength() - 1);  // Remove last item
        
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
        using var enrichedDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // Data from API - use AddRawString and AddFormattedNumber with native properties
                JsonElement idEl = apiRoot.GetProperty("id");
                objectBuilder.Add("userId"u8, idEl);

                JsonElement usernameEl = apiRoot.GetProperty("username");
                objectBuilder.Add("username"u8, usernameEl);

                JsonElement emailEl = apiRoot.GetProperty("email");
                objectBuilder.Add("email"u8, emailEl);

                JsonElement createdEl = apiRoot.GetProperty("created");
                objectBuilder.Add("accountCreated"u8, createdEl);

                // Augmented data from other sources
                objectBuilder.Add("profile"u8, static (ref profileBuilder) =>
                {
                    profileBuilder.Add("displayName"u8, "John Doe"u8);
                    profileBuilder.Add("bio"u8, "Software developer and coffee enthusiast"u8);
                    profileBuilder.Add("avatar"u8, "https://example.com/avatars/johndoe.jpg"u8);
                    profileBuilder.Add("verified"u8, true);
                });

                // Permissions array from database
                objectBuilder.Add("permissions"u8, (ref permBuilder) =>
                {
                    foreach (string permission in permissions)
                    {
                        permBuilder.Add(permission);  // ArrayBuilder has string overload
                    }
                });

                // User preferences
                objectBuilder.Add("preferences"u8, (ref JsonElement.ObjectBuilder prefBuilder) =>
                {
                    prefBuilder.Add("theme"u8, preferences.theme);  // string overload
                    prefBuilder.Add("language"u8, preferences.language);
                    prefBuilder.Add("notifications"u8, preferences.notifications);
                });

                // Activity tracking
                objectBuilder.Add("activity"u8, (ref activityBuilder) =>
                {
                    activityBuilder.Add("lastLogin"u8, lastLogin);  // DateTime overload
                    activityBuilder.Add("loginCount"u8, loginCount);
                    activityBuilder.Add("status"u8, "active"u8);
                });

                // Metadata
                objectBuilder.Add("metadata"u8, static (ref metaBuilder) =>
                {
                    metaBuilder.Add("enrichedAt"u8, DateTime.UtcNow);  // DateTime overload
                    metaBuilder.Add("version"u8, "2.0"u8);
                    metaBuilder.Add("source"u8, "user-service"u8);
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
        using var mergedDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // User summary from first API
                objectBuilder.Add("user", (ref userBuilder) =>
                {
                    userBuilder.Add("id", apiRoot.GetProperty("id"));
                    userBuilder.Add("username", apiRoot.GetProperty("username"));
                    userBuilder.Add("email", apiRoot.GetProperty("email"));
                });

                // Posts from second API - iterate and use native JsonElement values
                objectBuilder.Add("posts", (ref postsBuilder) =>
                {
                    foreach (JsonElement post in postsArray.EnumerateArray())
                    {
                        postsBuilder.Add((ref postBuilder) =>
                        {
                            // Use native JsonElement directly
                            postBuilder.Add("id", post.GetProperty("id"));
                            postBuilder.Add("title", post.GetProperty("title"));
                            postBuilder.Add("likes", post.GetProperty("likes"));
                            
                            // Augment with computed data
                            int likes = post.GetProperty("likes").GetInt32();
                            postBuilder.Add("popular", likes > 100);
                        });
                    }
                });

                // Summary statistics
                objectBuilder.Add("stats"u8, (ref statsBuilder) =>
                {
                    statsBuilder.Add("totalPosts"u8, totalPosts);
                    statsBuilder.Add("totalLikes"u8, 170);  // Could be computed
                    statsBuilder.Add("avgLikesPerPost"u8, 85.0);
                });

                // Add timestamp
                objectBuilder.Add("generatedAt"u8, DateTime.UtcNow);
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
        using var transformedDoc = JsonElement.CreateDocumentBuilder(
            workspace,
            new JsonElement.Source((ref objectBuilder) =>
            {
                // Map old field names to new structure using native JsonElement
                objectBuilder.Add("id", legacyRoot.GetProperty("user_id"));
                
                objectBuilder.Add("account", (ref accountBuilder) =>
                {
                    accountBuilder.Add("username", legacyRoot.GetProperty("user_name"));
                    accountBuilder.Add("email", legacyRoot.GetProperty("user_email"));
                });

                objectBuilder.Add("authorization", (ref authBuilder) =>
                {
                    JsonElement roleElement = legacyRoot.GetProperty("user_role");
                    authBuilder.Add("role", roleElement);
                    authBuilder.Add("isAdmin", roleElement.GetString() == "admin");
                });

                objectBuilder.Add("lastLogin", legacyRoot.GetProperty("last_login_date"));

                // Add modern fields
                objectBuilder.Add("apiVersion", "v2");
                objectBuilder.Add("transformed", true);
            }));

        Console.WriteLine("\nTransformed from Legacy Format:");
        Console.WriteLine("Original:");
        Console.WriteLine(legacyApiResponse);
        Console.WriteLine("\nTransformed:");
        Console.WriteLine(transformedDoc.RootElement.ToString());

        Console.WriteLine();
    }
}
