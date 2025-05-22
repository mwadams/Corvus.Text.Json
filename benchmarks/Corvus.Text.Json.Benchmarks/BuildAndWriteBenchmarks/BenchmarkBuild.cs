// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Benchmark.CorvusJsonSchema2;
using BenchmarkDotNet.Attributes;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkBuild
{
    [Benchmark(Baseline = true)]
    public bool BuildJsonObject()
    {
        System.Text.Json.Nodes.JsonObject jsonObject =
        [
            new ("age", 51),
            new ("name",
            new System.Text.Json.Nodes.JsonObject([
                new ("firstName", "Michael"),
                new ("lastName", "Adams"),
                new ("otherNames", new System.Text.Json.Nodes.JsonArray("Francis", "James")),
            new ("competedInYears", new System.Text.Json.Nodes.JsonArray(2012, 2016, 2024))])),
        ];

        ////jsonObject.WriteTo(_writer!);
        return true;
    }

    [Benchmark]
    public bool BuildCorvusJsonSchema()
    {
        Person person = Person.Create(
            age: 51,
            name: PersonName.Create(
                firstName: "Michael",
                lastName: "Adams",
                otherNames: ["Francis", "James"]),
            competedInYears: [2012, 2016, 2024]);

        ////person.WriteTo(_writer!);
        return true;
    }

    [Benchmark]
    public bool BuildCorvusTextJson()
    {
        using Corvus.Text.Json.JsonWorkspace workspace = new();

        using Corvus.Text.Json.JsonDocumentBuilder<Benchmark.CorvusTextJson.Person.Mutable> person = Benchmark.CorvusTextJson.Person.CreateDocument(
            workspace,
            age: 51,
            name: new(static (ref Benchmark.CorvusTextJson.PersonName.Builder personName) =>
            {
                personName.Create(
                    firstName: "Michael"u8,
                    lastName: "Adams"u8,
                    otherNames: new(static (ref Benchmark.CorvusTextJson.NameComponentArray.Builder otherNames) =>
                    {
                        otherNames.Add("Francis"u8);
                        otherNames.Add("James"u8);
                    }));
            }),
            competedInYears: new(static (ref Benchmark.CorvusTextJson.CompetedInYears.Builder competedInYears) =>
            {
                competedInYears.Add(2012);
                competedInYears.Add(2016);
                competedInYears.Add(2024);
            }));

        ////person.WriteTo(_corvusWriter!);
        return true;
    }
}
