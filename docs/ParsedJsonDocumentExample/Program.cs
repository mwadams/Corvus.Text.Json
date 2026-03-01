using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Corvus.Numerics;
using Corvus.Text.Json;
using NodaTime;

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

        // Example 6: Get all numeric types
        Example6_NumericTypes();

        // Example 7: Get boolean values
        Example7_BooleanValues();

        // Example 8: Get string values
        Example8_StringValues();

        // Example 9: Get date and time values
        Example9_DateTimeValues();

        // Example 10: Get Guid values
        Example10_GuidValues();

        // Example 11: Get binary data (Base64)
        Example11_BinaryData();

        // Example 12: Extended numeric types (BigInteger, BigNumber)
        Example12_ExtendedNumericTypes();

        // Example 13: NodaTime types
        Example13_NodaTimeTypes();

        // Example 14: Type checking and safe conversion
        Example14_TypeCheckingAndSafeConversion();

        // Example 15: Write JSON (basic)
        Example15_WriteJsonBasic();

        // Example 16: Write JSON with options
        Example16_WriteJsonWithOptions();

        // Example 17: Write JSON to file
        Example17_WriteJsonToFile();

        // Example 18: Use static constants
        Example18_StaticConstants();

        // Example 19: Parse from stream
        Example19_ParseFromStream();

        // Example 20: Parse from stream asynchronously
        await Example20_ParseFromStreamAsync();

        // Example 21: Parse from file stream
        Example21_ParseFromFileStream();

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
        string name = root.GetProperty("name"u8).GetString()!;
        int age = root.GetProperty("age"u8).GetInt32();
        bool isActive = root.GetProperty("isActive"u8).GetBoolean();

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
        string message = root.GetProperty("message"u8).GetString()!;

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
        JsonElement person = root.GetProperty("person"u8);
        JsonElement contact = person.GetProperty("contact"u8);

        string name = person.GetProperty("name"u8).GetString()!;
        string email = contact.GetProperty("email"u8).GetString()!;
        string phone = contact.GetProperty("phone"u8).GetString()!;

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

    static void Example6_NumericTypes()
    {
        Console.WriteLine("--- Example 6: All Numeric Types ---");

        string json = """
            {
                "byteValue": 255,
                "sbyteValue": -128,
                "shortValue": -32768,
                "ushortValue": 65535,
                "intValue": -2147483648,
                "uintValue": 4294967295,
                "longValue": -9223372036854775808,
                "ulongValue": 18446744073709551615,
                "floatValue": 3.14159,
                "doubleValue": 2.718281828459045,
                "decimalValue": 123456.789
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        byte byteVal = root.GetProperty("byteValue"u8).GetByte();
        sbyte sbyteVal = root.GetProperty("sbyteValue"u8).GetSByte();
        short shortVal = root.GetProperty("shortValue"u8).GetInt16();
        ushort ushortVal = root.GetProperty("ushortValue"u8).GetUInt16();
        int intVal = root.GetProperty("intValue"u8).GetInt32();
        uint uintVal = root.GetProperty("uintValue"u8).GetUInt32();
        long longVal = root.GetProperty("longValue"u8).GetInt64();
        ulong ulongVal = root.GetProperty("ulongValue"u8).GetUInt64();
        float floatVal = root.GetProperty("floatValue"u8).GetSingle();
        double doubleVal = root.GetProperty("doubleValue"u8).GetDouble();
        decimal decimalVal = root.GetProperty("decimalValue"u8).GetDecimal();

        Console.WriteLine($"byte: {byteVal}");
        Console.WriteLine($"sbyte: {sbyteVal}");
        Console.WriteLine($"short: {shortVal}");
        Console.WriteLine($"ushort: {ushortVal}");
        Console.WriteLine($"int: {intVal}");
        Console.WriteLine($"uint: {uintVal}");
        Console.WriteLine($"long: {longVal}");
        Console.WriteLine($"ulong: {ulongVal}");
        Console.WriteLine($"float: {floatVal}");
        Console.WriteLine($"double: {doubleVal}");
        Console.WriteLine($"decimal: {decimalVal}");
        Console.WriteLine();
    }

    static void Example7_BooleanValues()
    {
        Console.WriteLine("--- Example 7: Boolean Values ---");

        string json = """
            {
                "isActive": true,
                "isDeleted": false,
                "isVerified": true
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        bool isActive = root.GetProperty("isActive"u8).GetBoolean();
        bool isDeleted = root.GetProperty("isDeleted"u8).GetBoolean();
        bool isVerified = root.GetProperty("isVerified"u8).GetBoolean();

        Console.WriteLine($"Is Active: {isActive}");
        Console.WriteLine($"Is Deleted: {isDeleted}");
        Console.WriteLine($"Is Verified: {isVerified}");
        Console.WriteLine();
    }

    static void Example8_StringValues()
    {
        Console.WriteLine("--- Example 8: String Values ---");

        string json = """
            {
                "name": "John Doe",
                "email": "john.doe@example.com",
                "description": null,
                "address": "123 Main St\nApt 4B"
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        string? name = root.GetProperty("name"u8).GetString();
        string? email = root.GetProperty("email"u8).GetString();
        string? description = root.GetProperty("description"u8).GetString(); // null
        string? address = root.GetProperty("address"u8).GetString();

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Description: {description ?? "(null)"}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine();
    }

    static void Example9_DateTimeValues()
    {
        Console.WriteLine("--- Example 9: Date and Time Values ---");

        string json = """
            {
                "createdAt": "2024-01-15T10:30:00Z",
                "updatedAt": "2024-02-28T14:45:30.123+05:00",
                "timestamp": "2024-03-01T00:00:00-08:00"
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        DateTime createdAt = root.GetProperty("createdAt"u8).GetDateTime();
        DateTimeOffset updatedAt = root.GetProperty("updatedAt"u8).GetDateTimeOffset();
        DateTimeOffset timestamp = root.GetProperty("timestamp"u8).GetDateTimeOffset();

        Console.WriteLine($"Created At: {createdAt}");
        Console.WriteLine($"Updated At: {updatedAt}");
        Console.WriteLine($"Timestamp: {timestamp}");
        Console.WriteLine();
    }

    static void Example10_GuidValues()
    {
        Console.WriteLine("--- Example 10: Guid Values ---");

        string json = """
            {
                "userId": "550e8400-e29b-41d4-a716-446655440000",
                "sessionId": "12345678-1234-1234-1234-123456789012",
                "correlationId": "00000000-0000-0000-0000-000000000000"
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        Guid userId = root.GetProperty("userId"u8).GetGuid();
        Guid sessionId = root.GetProperty("sessionId"u8).GetGuid();
        Guid correlationId = root.GetProperty("correlationId"u8).GetGuid();

        Console.WriteLine($"User ID: {userId}");
        Console.WriteLine($"Session ID: {sessionId}");
        Console.WriteLine($"Correlation ID: {correlationId}");
        Console.WriteLine();
    }

    static void Example11_BinaryData()
    {
        Console.WriteLine("--- Example 11: Binary Data (Base64) ---");

        string json = """
            {
                "data": "SGVsbG8gV29ybGQh",
                "signature": "AQIDBA==",
                "emptyBytes": ""
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        byte[] data = root.GetProperty("data"u8).GetBytesFromBase64();
        byte[] signature = root.GetProperty("signature"u8).GetBytesFromBase64();
        byte[] emptyBytes = root.GetProperty("emptyBytes"u8).GetBytesFromBase64();

        Console.WriteLine($"Data: {Encoding.UTF8.GetString(data)}"); // "Hello World!"
        Console.WriteLine($"Signature: [{string.Join(", ", signature)}]"); // [1, 2, 3, 4]
        Console.WriteLine($"Empty Bytes Length: {emptyBytes.Length}");
        Console.WriteLine();
    }

    static void Example12_ExtendedNumericTypes()
    {
        Console.WriteLine("--- Example 12: Extended Numeric Types (Beyond System.Text.Json) ---");

        string json = """
            {
                "largeInteger": 12345678901234567890,
                "preciseNumber": 1234567890123456789.1234567890123456789,
                "bigNumberWithScale": 123456789012345678901234567890123456789E-10
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        // BigInteger for large integers beyond long range
        BigInteger largeNum = root.GetProperty("largeInteger"u8).GetBigInteger();

        // BigNumber for high-precision arithmetic
        BigNumber preciseNum = root.GetProperty("preciseNumber"u8).GetBigNumber();
        BigNumber bigNumWithScale = root.GetProperty("bigNumberWithScale"u8).GetBigNumber();

        Console.WriteLine($"BigInteger: {largeNum}");
        Console.WriteLine($"BigNumber (precise): {preciseNum}");
        Console.WriteLine($"BigNumber (with scale): {bigNumWithScale}");
        Console.WriteLine();
    }

    static void Example13_NodaTimeTypes()
    {
        Console.WriteLine("--- Example 13: NodaTime Types (Beyond System.Text.Json) ---");

        string json = """
            {
                "localDate": "2024-02-28",
                "offsetTime": "14:30:00+05:00",
                "offsetDate": "2024-02-28+00:00",
                "offsetDateTime": "2024-02-28T14:30:00+05:00",
                "period": "P1Y2M3DT4H5M6S"
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        LocalDate localDate = root.GetProperty("localDate"u8).GetLocalDate();
        OffsetTime offsetTime = root.GetProperty("offsetTime"u8).GetOffsetTime();
        OffsetDate offsetDate = root.GetProperty("offsetDate"u8).GetOffsetDate();
        OffsetDateTime offsetDateTime = root.GetProperty("offsetDateTime"u8).GetOffsetDateTime();
        NodaTime.Period period = root.GetProperty("period"u8).GetPeriod();

        Console.WriteLine($"LocalDate: {localDate}");
        Console.WriteLine($"OffsetTime: {offsetTime}");
        Console.WriteLine($"OffsetDate: {offsetDate}");
        Console.WriteLine($"OffsetDateTime: {offsetDateTime}");
        Console.WriteLine($"Period: {period}");
        Console.WriteLine();
    }

    static void Example14_TypeCheckingAndSafeConversion()
    {
        Console.WriteLine("--- Example 14: Type Checking and Safe Conversion ---");

        string json = """
            {
                "maybeNumber": "not a number",
                "actualNumber": 42,
                "maybeGuid": "invalid-guid",
                "actualGuid": "550e8400-e29b-41d4-a716-446655440000"
            }
            """;

        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);
        JsonElement root = doc.RootElement;

        // Check ValueKind before conversion
        JsonElement maybeNumber = root.GetProperty("maybeNumber"u8);
        if (maybeNumber.ValueKind == JsonValueKind.Number)
        {
            int value = maybeNumber.GetInt32();
            Console.WriteLine($"maybeNumber is a number: {value}");
        }
        else
        {
            Console.WriteLine($"maybeNumber is not a number, it's a {maybeNumber.ValueKind}");
        }

        // Use TryGet methods for safe conversion
        if (root.GetProperty("actualNumber"u8).TryGetInt32(out int actualValue))
        {
            Console.WriteLine($"actualNumber successfully parsed: {actualValue}");
        }

        // TryGetGuid for safer GUID parsing
        if (root.GetProperty("maybeGuid"u8).TryGetGuid(out Guid guid1))
        {
            Console.WriteLine($"maybeGuid: {guid1}");
        }
        else
        {
            Console.WriteLine("maybeGuid is not a valid GUID");
        }

        if (root.GetProperty("actualGuid"u8).TryGetGuid(out Guid guid2))
        {
            Console.WriteLine($"actualGuid: {guid2}");
        }

        Console.WriteLine();
    }

    static void Example15_WriteJsonBasic()
    {
        Console.WriteLine("--- Example 15: Write JSON (Basic) ---");

        string json = """
            {
                "message": "Hello",
                "status": 200,
                "timestamp": "2024-02-28T10:30:00Z"
            }
            """;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        // Write to memory stream
        using var stream = new MemoryStream();
        using (var writer = new Corvus.Text.Json.Utf8JsonWriter(stream))
        {
            doc.WriteTo(writer);
        }

        string outputJson = Encoding.UTF8.GetString(stream.ToArray());
        Console.WriteLine("Output JSON:");
        Console.WriteLine(outputJson);
        Console.WriteLine();
    }

    static void Example16_WriteJsonWithOptions()
    {
        Console.WriteLine("--- Example 16: Write JSON with Options ---");

        string json = """{"name":"John","age":30,"active":true}""";
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        // Write with indentation for readability
        var options = new Corvus.Text.Json.JsonWriterOptions
        {
            Indented = true
        };

        using var stream = new MemoryStream();
        using (var writer = new Corvus.Text.Json.Utf8JsonWriter(stream, options))
        {
            doc.WriteTo(writer);
        }

        string formattedJson = Encoding.UTF8.GetString(stream.ToArray());
        Console.WriteLine("Formatted JSON:");
        Console.WriteLine(formattedJson);
        Console.WriteLine();
    }

    static void Example17_WriteJsonToFile()
    {
        Console.WriteLine("--- Example 17: Write JSON to File ---");

        string json = """
            {
                "application": "ParsedJsonDocument Example",
                "version": "1.0.0",
                "settings": {
                    "debug": false,
                    "timeout": 30
                }
            }
            """;
        using ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(json);

        // Create a temporary file
        string tempFile = Path.Combine(Path.GetTempPath(), "example-output.json");
        try
        {
            using FileStream fileStream = File.Create(tempFile);
            using var writer = new Corvus.Text.Json.Utf8JsonWriter(
                fileStream,
                new Corvus.Text.Json.JsonWriterOptions { Indented = true });

            doc.WriteTo(writer);

            Console.WriteLine($"JSON written to: {tempFile}");

            // Read it back to verify
            string writtenContent = File.ReadAllText(tempFile);
            Console.WriteLine("Content:");
            Console.WriteLine(writtenContent);
        }
        finally
        {
            // Clean up
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        Console.WriteLine();
    }

    static void Example18_StaticConstants()
    {
        Console.WriteLine("--- Example 18: Static Constants ---");

        JsonElement nullValue = ParsedJsonDocument<JsonElement>.Null;
        JsonElement trueValue = ParsedJsonDocument<JsonElement>.True;
        JsonElement falseValue = ParsedJsonDocument<JsonElement>.False;

        Console.WriteLine($"Null: {nullValue.GetRawText()}");
        Console.WriteLine($"True: {trueValue.GetRawText()}");
        Console.WriteLine($"False: {falseValue.GetRawText()}");
        Console.WriteLine();
    }

    static void Example19_ParseFromStream()
    {
        Console.WriteLine("--- Example 19: Parse from Stream (Synchronous) ---");

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
        string source = root.GetProperty("source"u8).GetString()!;
        int value = root.GetProperty("value"u8).GetInt32();

        Console.WriteLine($"Source: {source}");
        Console.WriteLine($"Value: {value}");
        Console.WriteLine();
    }

    static async Task Example20_ParseFromStreamAsync()
    {
        Console.WriteLine("--- Example 20: Parse from Stream (Asynchronous) ---");

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
        JsonElement users = root.GetProperty("users"u8);
        string timestamp = root.GetProperty("timestamp"u8).GetString()!;

        Console.WriteLine($"Timestamp: {timestamp}");
        Console.WriteLine("Users:");
        foreach (JsonElement user in users.EnumerateArray())
        {
            int id = user.GetProperty("id"u8).GetInt32();
            string name = user.GetProperty("name"u8).GetString()!;
            string email = user.GetProperty("email"u8).GetString()!;
            Console.WriteLine($"  [{id}] {name} - {email}");
        }
        Console.WriteLine();
    }

    static void Example21_ParseFromFileStream()
    {
        Console.WriteLine("--- Example 21: Parse from File Stream ---");

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
            string appName = root.GetProperty("application"u8).GetString()!;
            string version = root.GetProperty("version"u8).GetString()!;
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
