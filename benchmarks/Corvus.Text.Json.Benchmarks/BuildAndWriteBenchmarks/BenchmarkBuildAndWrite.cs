// <copyright file="BenchmarkEqualsInOrderProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Benchmark.CorvusTextJson2;
using BenchmarkDotNet.Attributes;
using CommunityToolkit.HighPerformance.Buffers;
using Corvus.Text.Json;

namespace ValidationBenchmarks;

/// <summary>
/// Construct elements from a JSON element.
/// </summary>
[MemoryDiagnoser]
public class BenchmarkBuildAndWrite
{
    [Benchmark(Baseline = true)]
    public bool BuildJsonObject()
    {
        var bufferWriter = new ArrayPoolBufferWriter<byte>();
        System.Text.Json.Utf8JsonWriter writer = new System.Text.Json.Utf8JsonWriter(bufferWriter);
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

        jsonObject.WriteTo(writer);
        writer.Flush();
        writer.Dispose();
        bufferWriter.Dispose();
        return true;
    }

    [Benchmark]
    public bool BuildCorvusJsonSchema()
    {
        var bufferWriter = new ArrayPoolBufferWriter<byte>();
        System.Text.Json.Utf8JsonWriter writer = new System.Text.Json.Utf8JsonWriter(bufferWriter);
        Benchmark.CorvusJsonSchema2.Person person = Benchmark.CorvusJsonSchema2.Person.Create(
            age: 51,
            name: Benchmark.CorvusJsonSchema2.PersonName.Create(
                firstName: "Michael",
                lastName: "Adams",
                otherNames: ["Francis", "James"]),
            competedInYears: [2012, 2016, 2024]);

        person.WriteTo(writer);
        writer.Flush();
        writer.Dispose();
        bufferWriter.Dispose();
        return true;
    }

    [Benchmark]
    public bool BuildCorvusTextJson()
    {
        using JsonWorkspace workspace = new();

        using JsonDocumentBuilder<Person.Mutable> person = Person.CreateDocument(
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

        var writer = workspace.RentWriterAndBuffer(defaultBufferSize: 1024, out IByteBufferWriter bufferWriter);
        person.WriteTo(writer);
        writer.Flush();
        workspace.ReturnWriterAndBuffer(writer, bufferWriter);
        return true;
    }
}
