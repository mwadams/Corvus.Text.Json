// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

Corvus.Text.Json.ParsedJsonDocument? documentB1;
Corvus.Text.Json.ParsedJsonDocument? documentB2;

documentB1 = Corvus.Text.Json.ParsedJsonDocument.Parse(
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

documentB2 = Corvus.Text.Json.ParsedJsonDocument.Parse(
        """
        {
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
            "19": 1,
            "name": "John"
        }
        """);

try
{
    bool de = Corvus.Text.Json.JsonElement.DeepEquals(documentB1!.RootElement, documentB2!.RootElement);
    bool gde = Corvus.Text.Json.JsonElementHelpers.DeepEquals(documentB1!.RootElement, documentB2!.RootElement);

    Console.WriteLine($"DeepEquals: {de}");
    Console.WriteLine($"GenericDeepEquals: {gde}");
}
finally
{
    documentB1?.Dispose();
    documentB2?.Dispose();
}
