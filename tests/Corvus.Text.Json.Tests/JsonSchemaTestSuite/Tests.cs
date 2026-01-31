// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Threading.Tasks;
using Corvus.Json.CodeGeneration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Corvus.Text.Json.Tests.JsonSchemaTestSuite;

public class Tests
{
    [Theory]
    [MemberData(nameof(TestSuite.ProvideTestSchema), MemberType = typeof(TestSuite))]
    public static async Task RunTestSuite(TestSpecification testSpecification)
    {
        Assert.NotNull(testSpecification.TestCaseName);
    }
}

public static class TestSuite
{
    private static readonly IConfiguration s_config;

    static TestSuite()
    {
        s_config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
    }


    public static IEnumerable<object[]> ProvideTestSchema()
    {
        TestConfiguration jsonSchemaTestSuite = new();
        s_config.Bind("jsonSchemaTestSuite", jsonSchemaTestSuite);

        return [ [new TestSpecification("", "", "", Corvus.Json.CodeGeneration.Draft202012.VocabularyAnalyser.DefaultVocabulary)] ];
    }
}

public class TestConfiguration
{
    public string BaseDirectory { get; set; }
    public List<TestCollection> Collections { get; set; }
}

public class TestCollection
{
    public string Name { get; set; }
    public string DefaultVocabulary { get; set; }
    public string Directory { get; set; }
    public List<FileExclusions> Exclusions { get; set; }
}

public class FileExclusions
{
    public string File { get; set; }
    public List<SuiteExclusions> Suites { get; set; }
}

public class SuiteExclusions
{
    public string Name { get; set; }
    public List<TestExclusion> Tests { get; set; }
}

public class TestExclusion
{
    public string Name { get; set; }
    public string Reason { get; set; }
}

/// <summary>
/// A JSON Schema Test Suite test specification.
/// </summary>
/// <param name="filename">The filename containing the test suite.</param>
/// <param name="schemaPath">The path to the schema in the test suite.</param>
/// <param name="testCaseName">The name of the test case in the test suite.</param>
/// <param name="defaultVocabulary">The default vocabulary for the test suite.</param>
public readonly struct TestSpecification(string filename, string schemaPath, string testCaseName, IVocabulary defaultVocabulary)
{
    public string Filename { get; } = filename;
    public string SchemaPath { get; } = schemaPath;
    public string TestCaseName { get; } = testCaseName;
    public IVocabulary DefaultVocabulary { get; } = defaultVocabulary;
}
