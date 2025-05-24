// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text.Json.Nodes;
using BenchmarkDotNet.Attributes;

namespace JsonPropertySettingBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkToMutableAndSetProperty
{
    // Create a JSON document to work with.
    const string json = """
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

    [Benchmark(Baseline = true)]
    public string SetPropertyJsonObjectDirect()
    {
        System.Text.Json.Nodes.JsonNode node = System.Text.Json.Nodes.JsonNode.Parse(json);
        JsonObject nameValue = node["name"]?.AsObject() ?? throw new InvalidOperationException();
        nameValue["firstName"] = "Matthew";
        return nameValue.ToJsonString();
    }

    [Benchmark]
    public string SetPropertyJsonObjectFromJsonElement()
    {
        using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(json);
        System.Text.Json.Nodes.JsonObject nameValue = System.Text.Json.JsonSerializer.SerializeToNode(document.RootElement.GetProperty("name"))?.AsObject() ?? throw new InvalidOperationException();
        nameValue["firstName"] = "Matthew";
        return nameValue.ToJsonString();
    }


    [Benchmark]
    public string SetPropertyCorvusJsonSchema()
    {
        using Corvus.Json.ParsedValue<Corvus.Json.JsonObject> corvusParsedValue = Corvus.Json.ParsedValue<Corvus.Json.JsonObject>.Parse(json);
        if (!corvusParsedValue.Instance.TryGetProperty("name", out Corvus.Json.JsonAny nameValue))
        {
            throw new InvalidOperationException();
        }

        var result = nameValue.AsObject.SetProperty("firstName", (Corvus.Json.JsonString)"Matthew");
        return result.ToString();
    }

    [Benchmark]
    public string SetPropertyCorvusTextJson()
    {
        using Corvus.Text.Json.ParsedJsonDocument<Corvus.Text.Json.JsonElement> corvusDocument = Corvus.Text.Json.ParsedJsonDocument<Corvus.Text.Json.JsonElement>.Parse(json);
        using Corvus.Text.Json.JsonWorkspace workspace = new(1);
        using Corvus.Text.Json.JsonDocumentBuilder<Corvus.Text.Json.JsonElement.Mutable> nameValueDoc = corvusDocument!.RootElement.GetProperty("name").CreateDocument(workspace);
        nameValueDoc.RootElement.SetProperty("firstName"u8, "Matthew"u8);
        return nameValueDoc.RootElement.ToString();
    }
}
