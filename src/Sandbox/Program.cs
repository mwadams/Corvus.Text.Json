using Benchmark.CorvusTextJson;
using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Utf8IriReference reference = Utf8IriReference.CreateIriReference("note:example%20Schemas/Person.json?foo=bar#/$defs/Person"u8);

// Parse a document in the usual way
using ParsedJsonDocument<JsonElement> documentB1 = ParsedJsonDocument<JsonElement>.Parse(
        """
        {
            "name": "John",
            "age": 30,
            "city": "New York",
            "slightlyLonger": true,
            "1": 1,
            "2": 1,
            "3": 1,
            "4": 1,
            "5": 1,
            "6": 1,
            "7": 1,
            "8": 1,
            "9": 1,
            "10": 1,
            "11": 1,
            "12": 1,
            "13": 1,
            "14": 1,
            "15": 1,
            "16": 1,
            "17": 1,
            "18": 1,
            "19": 1
        }
        """);

Console.WriteLine(documentB1.RootElement.GetProperty("age"));

using ParsedJsonDocument<JsonElement> documentB2 = ParsedJsonDocument<JsonElement>.Parse(
        """
        {
            "name": "John",
            "age": 30,
            "city": "New York",
            "slightlyLonger": true,
            "1": 1,
            "2": 1,
            "3": 1,
            "4": 1,
            "5": 1,
            "6": 1,
            "7": 1,
            "8": 1,
            "9": 1,
            "10": 1,
            "11": 1,
            "12": 1,
            "13": 1,
            "14": 1,
            "15": 1,
            "16": 1,
            "17": 1,
            "18": 1,
            "19": 1
        }
        """);

using ParsedJsonDocument<Person> documentB3 = ParsedJsonDocument<Person>.Parse(
        """
        {
            "name": { "firstName": "Michael", "lastName": "Adams", "otherNames": ["Francis", "James"] },
            "age": 51,
            "competedInYears": [2012, 2016, 2024]
        }
        """);

using ParsedJsonDocument<Person> documentB4 = ParsedJsonDocument<Person>.Parse(
        """
        {
            "name": { "firstName": "Michael", "lastName": "Adams", "otherNames": "Francis James" },
            "age": 51,
            "competedInYears": [2012, 2016, 2024]
        }
        """);

using ParsedJsonDocument<Person> documentB5 = ParsedJsonDocument<Person>.Parse(
        """
        {
            "age": 51,
            "competedInYears": [2012, 2016, 2024]
        }
        """);

using ParsedJsonDocument<Person> documentB6 = ParsedJsonDocument<Person>.Parse(
        """
        {
            "name": { "firstName": "Michael", "lastName": "Adams", "otherNames": "Francis James" },
            "age": -7,
            "competedInYears": [2012, 2016, 2024]
        }
        """);

using ParsedJsonDocument<Person> documentB7 = ParsedJsonDocument<Person>.Parse(
        """
        {
            "name": { "lastName": "Adams", "otherNames": "Francis James" },
            "age": -7,
            "competedInYears": [2012, 2016, 2024]
        }
        """);

Console.WriteLine(documentB3.RootElement.EvaluateSchema() ? "Person B3 is a match" : "Person B3 is not a match");
Console.WriteLine(documentB4.RootElement.EvaluateSchema() ? "Person B4 is a match" : "Person B4 is not a match");
Console.WriteLine(documentB5.RootElement.EvaluateSchema() ? "Person B5 is a match" : "Person B5 is not a match");
Console.WriteLine(documentB6.RootElement.EvaluateSchema() ? "Person B6 is a match" : "Person B6 is not a match");
Console.WriteLine(documentB7.RootElement.EvaluateSchema() ? "Person B7 is a match" : "Person B7 is not a match");

Console.WriteLine(documentB1.RootElement.Equals(documentB2.RootElement) ? "The documents are equal" : "The documents are not equal");

documentB1.RootElement.EnsurePropertyMap();
documentB2.RootElement.EnsurePropertyMap();

Console.WriteLine(documentB1.RootElement.Equals(documentB2.RootElement) ? "The documents are equal" : "The documents are not equal");

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Console.WriteLine(documentB3.RootElement);

Console.WriteLine();
Console.WriteLine("**************");
Console.WriteLine("*** BEFORE ***");
Console.WriteLine("**************");
Console.WriteLine();

// Create a workspace for manipulating documents
using JsonWorkspace workspace = JsonWorkspace.Create();

using JsonDocumentBuilder<JsonElement.Mutable> initializedBuilder = documentB1.RootElement.CreateDocumentBuilder(workspace);

Console.WriteLine(initializedBuilder.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("*************");
Console.WriteLine("*** AFTER ***");
Console.WriteLine("*************");
Console.WriteLine();

initializedBuilder.RootElement.SetProperty("age"u8, 51);

Console.WriteLine(initializedBuilder.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("**************");
Console.WriteLine("*** BEFORE ***");
Console.WriteLine("**************");
Console.WriteLine();

using ParsedJsonDocument<JsonElement> documentB8 = ParsedJsonDocument<JsonElement>.Parse(
        """
        {
            "name": "John",
            "age": 30,
            "city": "New York",
            "slightlyLonger": true,
            "complex" : {"first": 13, "second": "foo", "third": [4,5,{"bar": "baz"}] }
        }
        """);

using JsonDocumentBuilder<JsonElement.Mutable> b8Builder = documentB8.RootElement.CreateDocumentBuilder(workspace);

Console.WriteLine(b8Builder.RootElement.ToString());

b8Builder.RootElement.SetProperty("complex"u8, 42);

Console.WriteLine();
Console.WriteLine("*************");
Console.WriteLine("*** AFTER ***");
Console.WriteLine("*************");
Console.WriteLine();

Console.WriteLine(b8Builder.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("**************");
Console.WriteLine("*** BEFORE ***");
Console.WriteLine("**************");
Console.WriteLine();

using JsonDocumentBuilder<JsonElement.Mutable> b8Builder2 = documentB8.RootElement.CreateDocumentBuilder(workspace);

Console.WriteLine(b8Builder2.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("*************");
Console.WriteLine("*** AFTER ***");
Console.WriteLine("*************");
Console.WriteLine();

b8Builder2.RootElement.GetProperty("complex"u8).GetProperty("third")[2].SetProperty("aNumber"u8, 42);
b8Builder2.RootElement.GetProperty("complex"u8).GetProperty("third").SetItemNull(1);
b8Builder2.RootElement.GetProperty("complex"u8).GetProperty("third").SetItemNull(2);

Console.WriteLine(b8Builder2.RootElement.ToString());

#if NET

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Utf8JsonWriter writer = workspace.RentWriterAndBuffer(defaultBufferSize: 1024, out IByteBufferWriter bufferWriter);
initializedBuilder.RootElement.WriteTo(writer);
writer.Flush();

Console.WriteLine(System.Text.Encoding.UTF8.GetString(bufferWriter.WrittenSpan));
workspace.ReturnWriterAndBuffer(writer, bufferWriter);

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

writer = workspace.RentWriterAndBuffer(defaultBufferSize: 1024, out bufferWriter);
initializedBuilder.RootElement.WriteTo(writer);
writer.Flush();

Console.WriteLine(System.Text.Encoding.UTF8.GetString(bufferWriter.WrittenSpan));
workspace.ReturnWriterAndBuffer(writer, bufferWriter);

#endif

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Console.WriteLine(initializedBuilder.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine("************");
Console.WriteLine();


#if NET9_0_OR_GREATER
ReadOnlySpan<int> years = [2012, 2016, 2024];
#else
int[] years = [2012, 2016, 2024];
#endif


// Create a builder for our root element
using JsonDocumentBuilder<JsonElement.Mutable> builder = JsonElement.CreateDocumentBuilder(
    workspace,
    years,
    static (in years, ref o) =>
    {
        o.Add(
            "name"u8,
            static (ref objectBuilder) =>
            {
                objectBuilder.Add("firstName"u8, "Michael"u8);
                objectBuilder.Add("lastName"u8, "Adams"u8);
                objectBuilder.Add(
                    "otherNames"u8,
                    static (ref arrayBuilder) =>
                    {
                        arrayBuilder.Add("Francis"u8);
                        arrayBuilder.Add("James"u8);
                    });
            });
        o.Add("age"u8, 51);
        o.Add("competedInYears"u8,
            years,
            static (in years, ref arrayBuilder) =>
            {
                arrayBuilder.AddRange(years);
            });
    });

// Validate that we can write the document back out again
Console.WriteLine(builder.RootElement.ToString());

using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.CreateDocumentBuilder(
    workspace,
    years,
    static (in years, ref b) => b.Create(
        years,
        age: 51,
        name: PersonName.Build(static (ref personName) =>
        {
            personName.Create(
                firstName: "Michael"u8,
                lastName: "Adams"u8,
                otherNames: OtherNames.Build(static (ref otherNames) =>
                {
                    otherNames.Add("Francis"u8);
                    otherNames.Add("James"u8);
                }));
        }),
        competedInYears: CompetedInYears.Build(years, static (in years, ref competedInYears) =>
        {
            foreach (int year in years)
            {
                competedInYears.Add(year);
            }
        })));

docBuilder.RootElement.Name.SetOtherNames(OtherNames.Build((ref b) => b.Add("Leo"u8)));
docBuilder.RootElement.Name.SetOtherNames("William"u8);

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Console.WriteLine(docBuilder.RootElement.ToString());

using JsonDocumentBuilder<Person.Mutable> docBuilder2 = Person.CreateDocumentBuilder(
    workspace,
    (ref b) => b.Create(
        age: 51,
        name: PersonName.Build((ref personName) =>
        {
            personName.Create(
                firstName: "Michael"u8,
                lastName: "Adams"u8,
                otherNames: "Francis James"u8);
        }),
        competedInYears: CompetedInYears.Build((ref competedInYears) =>
        {
            competedInYears.Add(2012);
            competedInYears.Add(2016);
            competedInYears.Add(2024);
        })));

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine();

Console.WriteLine(docBuilder2.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine("************");
Console.WriteLine();

Person.Mutable mutablePerson = docBuilder.RootElement;
// Implicit conversion from mutable to immutable.
Person person = docBuilder.RootElement;
Person.Mutable isItOK = (Person.Mutable)person; // This will throw if `person` wasn't created in a mutable document.

using JsonDocumentBuilder<Person.Mutable> docBuilder3 = Person.CreateDocumentBuilder(
    workspace,
    (ref b) => b.Create(
        age: person.Age ?? default, // Happily assign an existing instance, will not copy
        name: person.Name, // Happily assign an existing instance - it will copy the object structure into the metadataDB but not the backing values
        competedInYears: CompetedInYears.Build((ref competedInYears) =>
        {
            competedInYears.Add(2012);
        })));

Console.WriteLine(docBuilder3.RootElement.ToString());

Console.WriteLine();
Console.WriteLine("************");
Console.WriteLine("************");
Console.WriteLine();

string json =
    """
    {
        "age": 51,
        "name": {
            "firstName": "Michael",
            "lastName": "Adams",
            "otherNames": ["Francis", "James"]
        },
        "competedInYears": [2012, 2016, 2024]
    }
    """;

var personDoc = ParsedJsonDocument<JsonElement>.Parse(json);

using JsonDocumentBuilder<JsonElement.Mutable> nameValueDoc = personDoc.RootElement.GetProperty("name").CreateDocumentBuilder(workspace);

// Get the name element
JsonElement.Mutable nameValue = nameValueDoc.RootElement;
Console.WriteLine(nameValue.ToString());

// Stash away the lastName element to check it *doesn't* work past modification
JsonElement.Mutable lastName = nameValue.GetProperty("lastName"u8);

// Modify the doc
nameValue.SetProperty("firstName"u8, "Matthew"u8);

// And the modified element continues to work fine
Console.WriteLine(nameValue.ToString());

try
{
    // But the stashed element throws an InvalidOperationException
    Console.WriteLine(lastName.GetString());
    Console.WriteLine($"Expected exception was not thrown.");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught expected exception: {ex.Message}");
}

bool result = person == lastName;

JsonDocumentBuilder<NameComponent.Mutable> nameComponentBuilder = NameComponent.CreateDocumentBuilder(workspace, "foo"u8);

EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Basic);
EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Detailed);
EvaluateAndWriteResults(person, JsonSchemaResultsLevel.Verbose);

string brokenJson =
    """
    {
        "age": 51,
        "name": {
            "firstName": "Michael",
            "lastName": 123,
            "otherNames": ["Francis", "James"]
        },
        "competedInYears": [2012, 2016, 2024]
    }
    """;



using var brokenPersonDoc = ParsedJsonDocument<Person>.Parse(brokenJson);
Person brokenPerson = brokenPersonDoc.RootElement;

EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Basic);
EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Detailed);
EvaluateAndWriteResults(brokenPerson, JsonSchemaResultsLevel.Verbose);

static void EvaluateAndWriteResults(Person person, JsonSchemaResultsLevel level)
{
    JsonSchemaResultsCollector collector = JsonSchemaResultsCollector.Create(level);
    bool personEvaluationResult = person.EvaluateSchema(collector);

    JsonSchemaResultsCollector.ResultsEnumerator enumerator = collector.EnumerateResults();

    Console.WriteLine();
    Console.WriteLine("************");
    Console.WriteLine($"Evaluated {level}: {personEvaluationResult}\r\n{person}");
    Console.WriteLine();
    Console.WriteLine("== Results ==");
    Console.WriteLine();

    while (enumerator.MoveNext())
    {
        JsonSchemaResultsCollector.Result resultItem = enumerator.Current;
        Console.WriteLine($"Evaluated: {resultItem.IsMatch}\r\n\tMessage: \"{resultItem.GetMessageText()}\"\r\n\tat ({resultItem.GetEvaluationLocationText()}, {resultItem.GetSchemaEvaluationLocationText()}, {resultItem.GetDocumentEvaluationLocationText()})");
    }

    Console.WriteLine("************");
}

using JsonDocumentBuilder<Person.Mutable> testPersonDocBuilder = Person.CreateDocumentBuilder(
        workspace,
        static (ref b) => b.Create(
            age: 51,
            name: PersonName.Build(static (ref personName) =>
            {
                personName.Create(
                    firstName: "Michael"u8,
                    lastName: "Adams"u8,
                    otherNames: "Francis James"u8);
            }),
            competedInYears: CompetedInYears.Source.FromArray([2012, 2020, 2024])));

Console.WriteLine(testPersonDocBuilder.RootElement);

ParsedJsonDocument<JsonElement> doc = ParsedJsonDocument<JsonElement>.Parse(
    """
    {
        "name": "John",
        "age": 30,
        "city": "New York",
        "slightlyLonger": true,
        "1": 1,
        "2": 1
    }
    """);

using UniqueItemsHashSet hashSet = new UniqueItemsHashSet(doc, 2, stackalloc int[UniqueItemsHashSet.StackAllocBucketSize], stackalloc byte[UniqueItemsHashSet.StackAllocEntrySize]);
bool addedFirst = hashSet.AddItemIfNotExists(((IJsonElement)doc.RootElement.GetProperty("1")).ParentDocumentIndex);
Console.WriteLine($"Added first: {addedFirst}");
bool addedSecond = hashSet.AddItemIfNotExists(((IJsonElement)doc.RootElement.GetProperty("2")).ParentDocumentIndex);
Console.WriteLine($"Added second: {addedSecond}");

Year year = testPersonDocBuilder.RootElement.CompetedInYears!.Value[0];
int yearAsInt = year;
long yearAsLong = year;
byte yearAsByte = (byte)year;

string? firstName = testPersonDocBuilder.RootElement.Name.FirstName.GetString();
