// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Benchmark.CorvusJsonSchema2;
using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance.Buffers;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkBuildAndWrite
{
    private Corvus.Text.Json.Utf8JsonWriter? _corvusWriter;
    private System.Text.Json.Utf8JsonWriter? _writer;

    [GlobalSetup]
    public void Setup()
    {
        _corvusWriter = new Corvus.Text.Json.Utf8JsonWriter(new ArrayPoolBufferWriter<byte>());
        _writer = new System.Text.Json.Utf8JsonWriter(new ArrayPoolBufferWriter<byte>());
    }

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

        jsonObject.WriteTo(_writer!);
        _writer!.Reset();
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

        person.WriteTo(_writer!);
        _writer!.Reset();
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

        person.WriteTo(_corvusWriter!);
        _corvusWriter!.Reset();
        return true;
    }
}
