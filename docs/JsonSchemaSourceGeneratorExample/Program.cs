using Corvus.Text.Json;
using JsonSchemaSourceGeneratorExample.Models;

namespace JsonSchemaSourceGeneratorExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== JSON Schema Source Generator Examples ===\n");

        // Example 1: Parse and access properties
        Example1_ParseAndAccessProperties();

        // Example 2: Validate JSON against schema
        Example2_ValidateAgainstSchema();

        // Example 3: Access nested objects
        Example3_AccessNestedObjects();

        // Example 4: Build documents programmatically
        Example4_BuildDocuments();

        // Example 5: Modify existing documents
        Example5_ModifyDocuments();

        // Example 6: Serialize to JSON
        Example6_SerializeToJson();

        Console.WriteLine("\nAll examples completed!");
    }

    static void Example1_ParseAndAccessProperties()
    {
        Console.WriteLine("--- Example 1: Parse and Access Properties ---");

        string json = """
            {
                "name": "Alice Johnson",
                "age": 30,
                "email": "alice@example.com",
                "isActive": true
            }
            """;

        // Parse JSON into strongly-typed Person using ParsedJsonDocument
        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        Person person = doc.RootElement;

        // Access properties directly - they're nullable value types
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Email: {person.Email}");
        Console.WriteLine($"Active: {person.IsActive}");
        Console.WriteLine();
    }

    static void Example2_ValidateAgainstSchema()
    {
        Console.WriteLine("--- Example 2: Validate Against Schema ---");

        // Valid person
        string validJson = """
            {
                "name": "Bob Smith",
                "age": 30
            }
            """;

        using ParsedJsonDocument<Person> validDoc = ParsedJsonDocument<Person>.Parse(validJson);
        Person validPerson = validDoc.RootElement;
        
        bool isValid = validPerson.EvaluateSchema();
        Console.WriteLine($"Valid person - Schema evaluation: {isValid}");

        // Invalid person (age out of range)
        string invalidJson = """
            {
                "name": "Charlie Brown",
                "age": 150
            }
            """;

        using ParsedJsonDocument<Person> invalidDoc = ParsedJsonDocument<Person>.Parse(invalidJson);
        Person invalidPerson = invalidDoc.RootElement;
        
        bool isInvalid = invalidPerson.EvaluateSchema();
        Console.WriteLine($"Invalid person (age > 130) - Schema evaluation: {isInvalid}");
        Console.WriteLine();
    }

    static void Example3_AccessNestedObjects()
    {
        Console.WriteLine("--- Example 3: Working with Properties ---");

        string json = """
            {
                "name": "Diana Prince",
                "age": 28,
                "email": "diana@example.com",
                "phoneNumber": "+12025551234"
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        Person person = doc.RootElement;

        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Email: {person.Email}");
        Console.WriteLine($"Phone: {person.PhoneNumber}");
        Console.WriteLine();
    }

    static void Example4_BuildDocuments()
    {
        Console.WriteLine("--- Example 4: Build Documents Programmatically ---");

        // Create a workspace for building documents
        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Build a person document from scratch
        using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
            workspace,
            (ref b) => b.Create(
                name: "Katherine Johnson",
                age: 101,
                email: "katherine@nasa.gov",
                isActive: true));

        Person.Mutable mutablePerson = docBuilder.RootElement;
        Console.WriteLine("Built person:");
        Console.WriteLine(mutablePerson.ToString());

        // Convert to immutable
        Person immutablePerson = mutablePerson;
        Console.WriteLine($"Name: {immutablePerson.Name}, Age: {immutablePerson.Age}");
        Console.WriteLine();
    }

    static void Example5_ModifyDocuments()
    {
        Console.WriteLine("--- Example 5: Modify Existing Documents ---");

        string json = """
            {
                "name": "Eve Wilson",
                "age": 35,
                "email": "eve@example.com"
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        
        // Create a workspace and make the document mutable
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<Person.Mutable> builder = doc.RootElement.BuildDocument(workspace);

        Person.Mutable mutablePerson = builder.RootElement;
        
        Console.WriteLine("Before modification:");
        Console.WriteLine(mutablePerson.ToString());

        // Modify properties
        mutablePerson.SetAge(36);
        mutablePerson.SetEmail("eve.wilson@example.com");

        Console.WriteLine("\nAfter modification:");
        Console.WriteLine(mutablePerson.ToString());
        Console.WriteLine();
    }

    static void Example6_SerializeToJson()
    {
        Console.WriteLine("--- Example 6: Serialize to JSON ---");

        string json = """
            {
                "name": "Frank Miller",
                "age": 42,
                "email": "frank@example.com",
                "phoneNumber": "+14155559999",
                "isActive": false
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        Person person = doc.RootElement;

        // Serialize back to JSON string
        string serialized = person.ToString();
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(serialized);
        Console.WriteLine();
    }
}
