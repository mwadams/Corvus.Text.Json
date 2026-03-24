// <copyright file="AnnotationTestHelper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Corvus.Text.Json;
using Xunit;
using STJ = System.Text.Json;

namespace TestUtilities;

/// <summary>
/// Helpers for annotation test assertions.
/// </summary>
public static class AnnotationTestHelper
{
    /// <summary>
    /// Evaluates an instance against a compiled standalone evaluator and asserts
    /// that the expected annotations are produced at the given location and keyword.
    /// </summary>
    /// <param name="evaluator">The compiled evaluator.</param>
    /// <param name="instanceJson">The JSON instance to evaluate.</param>
    /// <param name="location">The instance location (JSON pointer, e.g. "", "/foo", "/0").</param>
    /// <param name="keyword">The annotation keyword name (e.g. "title").</param>
    /// <param name="expectedJson">
    /// The expected annotations as a JSON object mapping schema location to annotation value,
    /// e.g. <c>{"#": "Foo"}</c> or <c>{"#/$defs/foo": "Foo"}</c>.
    /// An empty object <c>{}</c> means no annotations are expected.
    /// </param>
    public static void AssertAnnotations(
        CompiledEvaluator evaluator,
        string instanceJson,
        string location,
        string keyword,
        string expectedJson)
    {
        using ParsedJsonDocument<Corvus.Text.Json.JsonElement> doc =
            ParsedJsonDocument<Corvus.Text.Json.JsonElement>.Parse(instanceJson);
        Corvus.Text.Json.JsonElement instance = doc.RootElement;

        using JsonSchemaResultsCollector collector =
            JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.Verbose);
        evaluator.Evaluate(instance, collector);

        Dictionary<(string InstanceLocation, string Keyword), Dictionary<string, string>> annotations =
            JsonSchemaAnnotationProducer.CollectAnnotations(collector);

        // Parse expected JSON to get the expected schema location → value map.
        using STJ.JsonDocument expectedDoc = STJ.JsonDocument.Parse(expectedJson);
        STJ.JsonElement expectedElement = expectedDoc.RootElement;

        if (expectedElement.ValueKind != STJ.JsonValueKind.Object)
        {
            Assert.Fail($"Expected JSON must be an object, but was {expectedElement.ValueKind}.");
            return;
        }

        // Build the expected map.
        Dictionary<string, string> expectedMap = [];
        foreach (STJ.JsonProperty prop in expectedElement.EnumerateObject())
        {
            expectedMap[prop.Name] = prop.Value.GetRawText();
        }

        if (expectedMap.Count == 0)
        {
            // Empty expected = no annotations at this location/keyword.
            if (annotations.TryGetValue((location, keyword), out Dictionary<string, string>? unexpectedValues))
            {
                Assert.Fail(
                    $"Expected no annotations at location={location}, keyword={keyword}, " +
                    $"but found {unexpectedValues.Count} annotation(s): " +
                    string.Join(", ", unexpectedValues.Select(kv => $"{kv.Key}={kv.Value}")));
            }

            return;
        }

        // Non-empty expected — annotations should exist.
        if (!annotations.TryGetValue((location, keyword), out Dictionary<string, string>? actualValues))
        {
            // Dump all results from collector for diagnostics.
            var allResults = new System.Text.StringBuilder();
            allResults.AppendLine($"Expected annotations at location={location}, keyword={keyword}, but none were found.");
            allResults.AppendLine($"Available annotation keys: [{string.Join(", ", annotations.Keys.Select(k => $"({k.InstanceLocation}, {k.Keyword})"))}]");
            allResults.AppendLine("All collector results:");
            int resultIdx = 0;
            foreach (JsonSchemaResultsCollector.Result r in collector.EnumerateResults())
            {
                allResults.AppendLine($"  [{resultIdx}] IsMatch={r.IsMatch}, EvalLoc={r.GetEvaluationLocationText()}, SchemaLoc={r.GetSchemaEvaluationLocationText()}, DocLoc={r.GetDocumentEvaluationLocationText()}, Msg={r.GetMessageText()}");
                resultIdx++;
            }

            if (evaluator.GeneratedCode is not null)
            {
                allResults.AppendLine("Generated evaluator code:");
                allResults.AppendLine(evaluator.GeneratedCode);
            }

            Assert.Fail(allResults.ToString());
        }

        // Assert each expected entry exists and matches.
        foreach (KeyValuePair<string, string> expected in expectedMap)
        {
            Assert.True(
                actualValues!.TryGetValue(expected.Key, out string? actualValue),
                $"Expected annotation at schema location {expected.Key} for location={location}, keyword={keyword}, " +
                $"but it was not found. Available schema locations: [{string.Join(", ", actualValues.Keys)}]");

            // Compare as JSON values to handle formatting differences.
            AssertJsonEqual(expected.Value, actualValue!, $"location={location}, keyword={keyword}, schemaLocation={expected.Key}");
        }

        // Assert no unexpected annotations.
        if (expectedMap.Count != actualValues!.Count)
        {
            var diag = new System.Text.StringBuilder();
            diag.AppendLine($"Annotation count mismatch at location={location}, keyword={keyword}. Expected {expectedMap.Count}, Actual {actualValues.Count}.");
            diag.AppendLine("Expected schema locations:");
            foreach (var kv in expectedMap)
            {
                diag.AppendLine($"  {kv.Key} => {kv.Value}");
            }

            diag.AppendLine("Actual schema locations:");
            foreach (var kv in actualValues)
            {
                diag.AppendLine($"  {kv.Key} => {kv.Value}");
            }

            diag.AppendLine("All collector results:");
            int ridx = 0;
            foreach (JsonSchemaResultsCollector.Result r in collector.EnumerateResults())
            {
                diag.AppendLine($"  [{ridx}] IsMatch={r.IsMatch}, EvalLoc={r.GetEvaluationLocationText()}, SchemaLoc={r.GetSchemaEvaluationLocationText()}, DocLoc={r.GetDocumentEvaluationLocationText()}, Msg={r.GetMessageText()}");
                ridx++;
            }

            if (evaluator.GeneratedCode is not null)
            {
                diag.AppendLine("Generated evaluator code:");
                diag.AppendLine(evaluator.GeneratedCode);
            }

            Assert.Fail(diag.ToString());
        }
    }

    private static void AssertJsonEqual(string expectedRawJson, string actualRawJson, string context)
    {
        using STJ.JsonDocument expectedDoc = STJ.JsonDocument.Parse(expectedRawJson);
        using STJ.JsonDocument actualDoc = STJ.JsonDocument.Parse(actualRawJson);

        if (!JsonElementDeepEquals(expectedDoc.RootElement, actualDoc.RootElement))
        {
            Assert.Fail($"JSON mismatch at {context}. Expected: {expectedRawJson}, Actual: {actualRawJson}");
        }
    }

    private static bool JsonElementDeepEquals(STJ.JsonElement a, STJ.JsonElement b)
    {
        if (a.ValueKind != b.ValueKind)
        {
            return false;
        }

        switch (a.ValueKind)
        {
            case STJ.JsonValueKind.Object:
                int aCount = 0;
                foreach (STJ.JsonProperty prop in a.EnumerateObject())
                {
                    aCount++;
                    if (!b.TryGetProperty(prop.Name, out STJ.JsonElement bVal))
                    {
                        return false;
                    }

                    if (!JsonElementDeepEquals(prop.Value, bVal))
                    {
                        return false;
                    }
                }

                int bCount = 0;
                foreach (STJ.JsonProperty _ in b.EnumerateObject())
                {
                    bCount++;
                }

                return aCount == bCount;

            case STJ.JsonValueKind.Array:
                int aLen = a.GetArrayLength();
                int bLen = b.GetArrayLength();
                if (aLen != bLen)
                {
                    return false;
                }

                STJ.JsonElement.ArrayEnumerator aEnum = a.EnumerateArray();
                STJ.JsonElement.ArrayEnumerator bEnum = b.EnumerateArray();
                while (aEnum.MoveNext() && bEnum.MoveNext())
                {
                    if (!JsonElementDeepEquals(aEnum.Current, bEnum.Current))
                    {
                        return false;
                    }
                }

                return true;

            case STJ.JsonValueKind.String:
                return a.GetString() == b.GetString();

            case STJ.JsonValueKind.Number:
                return a.GetRawText() == b.GetRawText();

            case STJ.JsonValueKind.True:
            case STJ.JsonValueKind.False:
            case STJ.JsonValueKind.Null:
                return true;

            default:
                return a.GetRawText() == b.GetRawText();
        }
    }
}