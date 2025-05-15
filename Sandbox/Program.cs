// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json;
using Sandbox;

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

JsonElementHelpers.DeepEquals(documentB1.RootElement, documentB2.RootElement);

////// Create a workspace for manipulating documents
////using JsonWorkspace workspace = new();

////using JsonDocumentBuilder<JsonElement.Mutable> initializedBuilder = documentB1.RootElement.CreateDocument(workspace);

////Console.WriteLine(initializedBuilder.RootElement.ToString());

////// Create a builder for our root element
////using JsonDocumentBuilder<JsonElement.Mutable> builder = JsonElement.CreateDocument(
////    workspace,
////    static (ref JsonObjectBuilder o) =>
////    {
////        o.Add(
////            "name"u8,
////            static (ref JsonObjectBuilder o) =>
////            {
////                o.Add("firstName"u8, "Michael"u8);
////                o.Add("lastName"u8, "Adams"u8);
////                o.Add(
////                    "otherNames"u8,
////                    static (ref JsonArrayBuilder a) =>
////                    {
////                        a.Add("Francis"u8);
////                        a.Add("James"u8);
////                    });
////            });
////        o.Add("age"u8, 52);
////        o.Add("competedInYears"u8,
////            static (ref JsonArrayBuilder a) =>
////            {
////                a.Add(2012);
////                a.Add(2016);
////                a.Add(2024);
////            });
////    });

////// Validate that we can write the document back out again
////Console.WriteLine(builder.RootElement.ToString());

////int[] years = [2012, 2016, 2024];

////using JsonDocumentBuilder<Person.Mutable> docBuilder = Person.CreateDocument(
////    workspace,
////    age: 51,
////    name: new(static (ref PersonName.Builder personName) =>
////    {
////        personName.Create(
////            firstName: "Michael"u8,
////            lastName: "Adams"u8,
////            otherNames: new(static (ref NameComponentArray.Builder otherNames) =>
////            {
////                otherNames.Add("Francis"u8);
////                otherNames.Add("James"u8);
////            }));
////    }),
////    competedInYears: new((ref CompetedInYears.Builder competedInYears) =>
////    {
////        foreach (int year in years)
////        {
////            competedInYears.Add(year);
////        }
////    }));


////Person.Mutable mutablePerson = docBuilder.RootElement;
////// Implicit conversion from mutable to immutable.
////Person person = docBuilder.RootElement;
////Person.Mutable isItOK = (Person.Mutable)person; // This will throw if `person` wasn't created in a mutable document.

////using JsonDocumentBuilder<Person.Mutable> docBuilder2 = Person.CreateDocument(
////    workspace,
////    age: person.Age, // Happily assign an existing instance, will not copy
////    name: person.Name, // Happily assign an existing instance - it will copy the object structure into the metadataDB but not the backing values
////    competedInYears: new((ref CompetedInYears.Builder competedInYears) =>
////    {
////        competedInYears.Add(2012);
////    }));

////Console.WriteLine(docBuilder.RootElement.ToString());
