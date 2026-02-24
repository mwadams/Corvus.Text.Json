using Corvus.Text.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParsedJsonDocumentExample;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== ParsedJsonDocument Examples ===\n");

        // Example 1: Parse simple JSON from string
        Example1_ParseFromString();

        // Example 2: Parse JSON from bytes
        Example2_ParseFromBytes();

        // Example 3: Work with arrays
        Example3_WorkWithArrays();

        // Example 4: Work with nested objects
        Example4_WorkWithNestedObjects();

        // Example 5: Enumerate properties
        Example5_EnumerateProperties();

        // Example 6: Write JSON
        Example6_WriteJson();

        // Example 7: Use static constants
        Example7_StaticConstants();

        // Example 8: Parse from stream
        Example8_ParseFromStream();

        // Example 9: Parse from stream asynchronously
        await Example9_ParseFromStreamAsync();

        // Example 10: Parse from file stream
        Example10_ParseFromFileStream();

        Console.WriteLine("\nAll examples completed!");
    }

    static void Example1_ParseFromString()
    {
        Console.WriteLine("--- Example 1: Parse from String ---");

        string json = """
            {
                "name": "John Smith",
                "age": 30,
                "isActive": true
            }
            """;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        JsonElement root = doc.RootElement;
        string name = root.GetProperty("name").GetString()!;
        int age = root.GetProperty("age").GetInt32();
        bool isActive = root.GetProperty("isActive").GetBoolean();

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Active: {isActive}");
        Console.WriteLine();
    }

    static void Example2_ParseFromBytes()
    {
        Console.WriteLine("--- Example 2: Parse from Bytes ---");

        ReadOnlySpan<byte> utf8Json = """
            {
                "message": "Hello, World!"
            }
            """u8;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(utf8Json.ToArray().AsMemory());

        JsonElement root = doc.RootElement;
        string message = root.GetProperty("message").GetString()!;

        Console.WriteLine($"Message: {message}");
        Console.WriteLine();
    }

    static void Example3_WorkWithArrays()
    {
        Console.WriteLine("--- Example 3: Work with Arrays ---");

        string json = """
            [
                10,
                20,
                30,
                40,
                50
            ]
            """;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        JsonElement root = doc.RootElement;
        int length = root.GetArrayLength();
        Console.WriteLine($"Array length: {length}");

        Console.Write("Values using foreach: ");
        foreach (JsonElement element in root.EnumerateArray())
        {
            int value = element.GetInt32();
            Console.Write($"{value} ");
        }
        Console.WriteLine();

        // You can also use indexed access
        Console.Write("Values using indexer: ");
        for (int i = 0; i < length; i++)
        {
            int value = root[i].GetInt32();
            Console.Write($"{value} ");
        }
        Console.WriteLine("\n");
    }

    static void Example4_WorkWithNestedObjects()
    {
        Console.WriteLine("--- Example 4: Work with Nested Objects ---");

        string json = """
            {
                "person": {
                    "name": "Alice Johnson",
                    "contact": {
                        "email": "alice@example.com",
                        "phone": "555-1234"
                    }
                }
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        JsonElement root = doc.RootElement;
        JsonElement person = root.GetProperty("person");
        JsonElement contact = person.GetProperty("contact");

        string name = person.GetProperty("name").GetString()!;
        string email = contact.GetProperty("email").GetString()!;
        string phone = contact.GetProperty("phone").GetString()!;

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Phone: {phone}");
        Console.WriteLine();
    }

    static void Example5_EnumerateProperties()
    {
        Console.WriteLine("--- Example 5: Enumerate Properties ---");

        string json = """
            {
                "first": "John",
                "last": "Doe",
                "age": 25,
                "city": "Seattle"
            }
            """;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        JsonElement root = doc.RootElement;
        Console.WriteLine("Properties:");
        foreach (JsonProperty<JsonElement> property in root.EnumerateObject())
        {
            Console.WriteLine($"  {property.Name}: {property.Value}");
        }
        Console.WriteLine();
    }

    static void Example6_WriteJson()
    {
        Console.WriteLine("--- Example 6: Write JSON ---");

        ReadOnlySpan<byte> utf8Json = """
            {
                "status": "success",
                "code": 200
            }
            """u8;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(utf8Json.ToArray().AsMemory());

        using var stream = new MemoryStream();
        using (var writer = new Corvus.Text.Json.Utf8JsonWriter(stream, new Corvus.Text.Json.JsonWriterOptions { Indented = true }))
        {
            doc.WriteTo(writer);
        }

        string formattedJson = Encoding.UTF8.GetString(stream.ToArray());
        Console.WriteLine("Formatted JSON:");
        Console.WriteLine(formattedJson);
        Console.WriteLine();
    }

    static void Example7_StaticConstants()
    {
        Console.WriteLine("--- Example 7: Static Constants ---");

        JsonElement nullValue = ParsedJsonDocument<JsonElement>.Null;
        JsonElement trueValue = ParsedJsonDocument<JsonElement>.True;
        JsonElement falseValue = ParsedJsonDocument<JsonElement>.False;

        Console.WriteLine($"Null: {nullValue.GetRawText()}");
        Console.WriteLine($"True: {trueValue.GetRawText()}");
        Console.WriteLine($"False: {falseValue.GetRawText()}");
        Console.WriteLine();
    }

    static void Example8_ParseFromStream()
    {
        Console.WriteLine("--- Example 8: Parse from Stream (Synchronous) ---");

        // Create a sample JSON in a memory stream
        ReadOnlySpan<byte> utf8Json = """
            {
                "source": "stream",
                "value": 42
            }
            """u8;
        using var stream = new MemoryStream(utf8Json.ToArray());

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(stream);

        JsonElement root = doc.RootElement;
        string source = root.GetProperty("source").GetString()!;
        int value = root.GetProperty("value").GetInt32();

        Console.WriteLine($"Source: {source}");
        Console.WriteLine($"Value: {value}");
        Console.WriteLine();
    }

    static async Task Example9_ParseFromStreamAsync()
    {
        Console.WriteLine("--- Example 9: Parse from Stream (Asynchronous) ---");

        // Create a larger JSON document to demonstrate async parsing
        ReadOnlySpan<byte> utf8Json = """
            {
                "users": [
                    {
                        "id": 1,
                        "name": "Alice",
                        "email": "alice@example.com"
                    },
                    {
                        "id": 2,
                        "name": "Bob",
                        "email": "bob@example.com"
                    },
                    {
                        "id": 3,
                        "name": "Charlie",
                        "email": "charlie@example.com"
                    }
                ],
                "timestamp": "2026-02-24T11:00:00Z"
            }
            """u8;
        using var stream = new MemoryStream(utf8Json.ToArray());

        // ParseAsync is ideal for large files or network streams
        using ParsedJsonDocument<JsonElement> doc = await ParsedJsonDocument<JsonElement>.ParseAsync(stream);

        JsonElement root = doc.RootElement;
        JsonElement users = root.GetProperty("users");
        string timestamp = root.GetProperty("timestamp").GetString()!;

        Console.WriteLine($"Timestamp: {timestamp}");
        Console.WriteLine("Users:");
        foreach (JsonElement user in users.EnumerateArray())
        {
            int id = user.GetProperty("id").GetInt32();
            string name = user.GetProperty("name").GetString()!;
            string email = user.GetProperty("email").GetString()!;
            Console.WriteLine($"  [{id}] {name} - {email}");
        }
        Console.WriteLine();
    }

    static void Example10_ParseFromFileStream()
    {
        Console.WriteLine("--- Example 10: Parse from File Stream ---");

        // Create a temporary JSON file
        string tempFile = Path.Combine(Path.GetTempPath(), "example.json");
        try
        {
            // Write JSON to file
            ReadOnlySpan<byte> utf8Json = """
                {
                    "application": "ParsedJsonDocument Example",
                    "version": "1.0.0",
                    "features": [
                        "Memory efficient",
                        "Pooled allocations",
                        "Fast parsing"
                    ]
                }
                """u8;
            File.WriteAllBytes(tempFile, utf8Json.ToArray());

            // Parse from file stream
            using FileStream fileStream = File.OpenRead(tempFile);
            using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(fileStream);

            JsonElement root = doc.RootElement;
            string appName = root.GetProperty("application").GetString()!;
            string version = root.GetProperty("version").GetString()!;
            JsonElement features = root.GetProperty("features");

            Console.WriteLine($"Application: {appName}");
            Console.WriteLine($"Version: {version}");
            Console.WriteLine("Features:");
            foreach (JsonElement feature in features.EnumerateArray())
            {
                Console.WriteLine($"  - {feature.GetString()}");
            }
        }
        finally
        {
            // Clean up temporary file
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        Console.WriteLine();
    }
}
