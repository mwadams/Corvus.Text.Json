// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json;

// Parse a document in the usual way
using ParsedJsonDocument documentB1 = ParsedJsonDocument.Parse(
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

// Create a workspace for manipulating documents
using JsonWorkspace workspace = new();

// Create a builder for our root element
using JsonDocumentBuilder builder = documentB1.RootElement.CreateBuilder(workspace);

// Validate that we can write the document back out again
Console.WriteLine(builder.RootElement.ToString());
