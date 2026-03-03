using Corvus.Text.Json;
using JsonSchemaSourceGeneratorExample.Models;

namespace JsonSchemaSourceGeneratorExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== JSON Schema Source Generator Examples ===\n");

        // Example 1: Parse and access nested objects
        Example1_ParseNestedObjects();

        // Example 2: Parse and access arrays
        Example2_ParseArrays();

        // Example 3: Validate JSON against schema
        Example3_ValidateAgainstSchema();

        // Example 4: Build documents with nested objects
        Example4_BuildNestedObjects();

        // Example 5: Build documents with arrays
        Example5_BuildWithArrays();

        // Example 6: Build complex documents with callbacks
        Example6_BuildComplexDocuments();

        // Example 7: Modify existing documents
        Example7_ModifyDocuments();

        // Example 8: Modify nested properties
        Example8_ModifyNestedProperties();

        Console.WriteLine("\nAll examples completed!");
    }

    static void Example1_ParseNestedObjects()
    {
        Console.WriteLine("--- Example 1: Parse and Access Nested Objects ---");

        string json = """
            {
                "name": {
                    "firstName": "Alice",
                    "lastName": "Johnson",
                    "middleName": "Marie"
                },
                "age": 30,
                "email": "alice.johnson@example.com"
            }
            """;

        // Parse JSON into strongly-typed Person with nested PersonName
        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        Person person = doc.RootElement;

        // Access nested object properties
        if (person.Name.IsNotUndefined())
        {
            var name = person.Name;
            Console.WriteLine($"First Name: {name.FirstName}");
            Console.WriteLine($"Last Name: {name.LastName}");
            
            if (name.MiddleName != null)
            {
                Console.WriteLine($"Middle Name: {name.MiddleName}");
            }
        }

        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Email: {person.Email}");
        Console.WriteLine();
    }

    static void Example2_ParseArrays()
    {
        Console.WriteLine("--- Example 2: Parse and Access Arrays ---");

        string json = """
            {
                "name": {
                    "firstName": "Bob",
                    "lastName": "Smith"
                },
                "age": 35,
                "hobbies": ["reading", "hiking", "photography", "cooking"]
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        Person person = doc.RootElement;

        Console.WriteLine($"Name: {person.Name.FirstName} {person.Name.LastName}");
        
        // Access array elements using EnumerateArray()
        if (person.Hobbies is not null)
        {
            var hobbies = person.Hobbies.Value;
            Console.WriteLine($"Hobbies:");
            
            int index = 1;
            foreach (var hobby in hobbies.EnumerateArray())
            {
                Console.WriteLine($"  {index}. {hobby}");
                index++;
            }
            
            // Can also access by index
            Console.WriteLine($"First hobby: {hobbies[0]}");
        }
        Console.WriteLine();
    }

    static void Example3_ValidateAgainstSchema()
    {
        Console.WriteLine("--- Example 3: Validate Against Schema ---");

        // Valid person
        string validJson = """
            {
                "name": {
                    "firstName": "Charlie",
                    "lastName": "Brown"
                },
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
                "name": {
                    "firstName": "Diana",
                    "lastName": "Prince"
                },
                "age": 150
            }
            """;

        using ParsedJsonDocument<Person> invalidDoc = ParsedJsonDocument<Person>.Parse(invalidJson);
        Person invalidPerson = invalidDoc.RootElement;
        
        bool isInvalid = invalidPerson.EvaluateSchema();
        Console.WriteLine($"Invalid person (age > 130) - Schema evaluation: {isInvalid}");
        Console.WriteLine();
    }

    static void Example4_BuildNestedObjects()
    {
        Console.WriteLine("--- Example 4: Build Documents with Nested Objects ---");

        // Create a workspace for building documents
        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Build a person with nested name object
        using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
            workspace,
            (ref b) => b.Create(
                age: 45,
                email: "eve.martinez@example.com",
                // Use Person.PersonName.Build to create nested object
                name: Person.PersonName.Build((ref nameBuilder) =>
                {
                    nameBuilder.Create(
                        firstName: "Eve",
                        lastName: "Martinez",
                        middleName: "Sofia");
                })));

        Person.Mutable mutablePerson = docBuilder.RootElement;
        Console.WriteLine("Built person with nested name:");
        Console.WriteLine(mutablePerson.ToString());
        Console.WriteLine();
    }

    static void Example5_BuildWithArrays()
    {
        Console.WriteLine("--- Example 5: Build Documents with Arrays ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Build a person with hobbies array
        using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
            workspace,
            (ref b) => b.Create(
                age: 28,
                name: Person.PersonName.Build((ref nameBuilder) =>
                {
                    nameBuilder.Create(
                        firstName: "Frank",
                        lastName: "Wilson");
                }),
                // Build array using callback - HobbiesEntityArray is nested within Person
                hobbies: Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
                {
                    hobbiesBuilder.Add("guitar");
                    hobbiesBuilder.Add("gaming");
                    hobbiesBuilder.Add("travel");
                })));

        Console.WriteLine("Built person with hobbies array:");
        Console.WriteLine(docBuilder.RootElement.ToString());
        Console.WriteLine();
    }

    static void Example6_BuildComplexDocuments()
    {
        Console.WriteLine("--- Example 6: Build Complex Documents with Callbacks ---");

        using JsonWorkspace workspace = JsonWorkspace.Create();

        // Build a complete person with all properties - without capturing
        using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.BuildDocument(
            workspace,
            (ref b) => b.Create(
                age: 42,
                email: "grace.hopper@navy.mil",
                phoneNumber: "+15555551234",
                isActive: true,
                // Build nested name
                name: Person.PersonName.Build((ref nameBuilder) =>
                {
                    nameBuilder.Create(
                        firstName: "Grace",
                        lastName: "Hopper",
                        middleName: "Brewster");
                }),
                // Build nested address
                address: Person.Address.Build((ref addressBuilder) =>
                {
                    addressBuilder.Create(
                        street: "123 Navy Yard",
                        city: "Washington",
                        state: "DC",
                        zipCode: "20001",
                        country: "USA");
                }),
                // Build hobbies array inline
                hobbies: Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
                {
                    hobbiesBuilder.Add("reading");
                    hobbiesBuilder.Add("writing");
                    hobbiesBuilder.Add("coding");
                    hobbiesBuilder.Add("teaching");
                })));

        Console.WriteLine("Built complete person:");
        Console.WriteLine(docBuilder.RootElement.ToString());
        Console.WriteLine();
    }

    static void Example7_ModifyDocuments()
    {
        Console.WriteLine("--- Example 7: Modify Existing Documents ---");

        string json = """
            {
                "name": {
                    "firstName": "Henry",
                    "lastName": "Ford"
                },
                "age": 83,
                "email": "henry@ford.com"
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        
        // Create a workspace and make the document mutable
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<Person.Mutable> builder = doc.RootElement.BuildDocument(workspace);

        Person.Mutable mutablePerson = builder.RootElement;
        
        Console.WriteLine("Before modification:");
        Console.WriteLine(mutablePerson.ToString());

        // Modify simple properties
        mutablePerson.SetAge(84);
        mutablePerson.SetEmail("henry.ford@example.com");

        Console.WriteLine("\nAfter modification:");
        Console.WriteLine(mutablePerson.ToString());
        Console.WriteLine();
    }

    static void Example8_ModifyNestedProperties()
    {
        Console.WriteLine("--- Example 8: Modify Nested Properties ---");

        string json = """
            {
                "name": {
                    "firstName": "Ida",
                    "lastName": "Wells"
                },
                "age": 68,
                "hobbies": ["journalism", "activism"]
            }
            """;

        using ParsedJsonDocument<Person> doc = ParsedJsonDocument<Person>.Parse(json);
        using JsonWorkspace workspace = JsonWorkspace.Create();
        using JsonDocumentBuilder<Person.Mutable> builder = doc.RootElement.BuildDocument(workspace);

        Person.Mutable mutablePerson = builder.RootElement;
        
        Console.WriteLine("Before modification:");
        Console.WriteLine(mutablePerson.ToString());

        // Modify nested name object
        mutablePerson.SetName(Person.PersonName.Build((ref nameBuilder) =>
        {
            nameBuilder.Create(
                firstName: "Ida",
                lastName: "Wells-Barnett",  // Changed last name
                middleName: "Bell");  // Added middle name
        }));

        // Replace hobbies array
        mutablePerson.SetHobbies(Person.HobbiesEntityArray.Build((ref hobbiesBuilder) =>
        {
            hobbiesBuilder.Add("journalism");
            hobbiesBuilder.Add("activism");
            hobbiesBuilder.Add("writing");  // Added new hobby
        }));

        Console.WriteLine("\nAfter modification:");
        Console.WriteLine(mutablePerson.ToString());
        Console.WriteLine();
    }
}
