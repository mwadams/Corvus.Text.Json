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
    public System.Text.Json.Nodes.JsonObject BuildJsonObject()
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

        return jsonObject;
    }

    [Benchmark]
    public Person BuildCorvusJsonSchema()
    {
        Person person = Person.Create(
            age: 51,
            name: PersonName.Create(
                firstName: "Michael",
                lastName: "Adams",
                otherNames: ["Francis", "James"]),
            competedInYears: [2012, 2016, 2024]);

        return person;
    }

    [Benchmark]
    public Benchmark.CorvusTextJson.Person.Mutable BuildCorvusTextJson()
    {
        using Corvus.Text.Json.JsonWorkspace workspace = Corvus.Text.Json.JsonWorkspace.Create();

        using Corvus.Text.Json.JsonDocumentBuilder<Benchmark.CorvusTextJson.Person.Mutable> person = Benchmark.CorvusTextJson.Person.CreateDocumentBuilder(
            workspace,
            age: 51,
            name: new(static (ref personName) =>
            {
                personName.Create(
                    firstName: "Michael"u8,
                    lastName: "Adams"u8,
                    otherNames: new(static (ref otherNames) =>
                    {
                        otherNames.Add("Francis"u8);
                        otherNames.Add("James"u8);
                    }));
            }),
            competedInYears: new(static (ref competedInYears) =>
            {
                competedInYears.Add(2012);
                competedInYears.Add(2016);
                competedInYears.Add(2024);
            }));

        return person.RootElement;
    }
}
