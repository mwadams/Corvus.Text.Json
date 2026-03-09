// Copyright (c) Matthew Adams. All rights reserved.
// Licensed under the Apache-2.0 license.

using System.Text.Json;
using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests;

/// <summary>
/// Tests that verify strongly-typed property getters return schema default values
/// when the property is not present in the JSON document.
/// </summary>
public class GeneratedDefaultPropertyTests
{
    [Fact]
    public void MissingStringPropertyWithDefault_ReturnsDefaultValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.StatusEntity? status = instance.Status;

        Assert.NotNull(status);
        Assert.Equal(JsonValueKind.String, status.Value.ValueKind);
        Assert.Equal("active", (string)status.Value);
    }

    [Fact]
    public void MissingIntegerPropertyWithDefault_ReturnsDefaultValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.CountEntity? count = instance.Count;

        Assert.NotNull(count);
        Assert.Equal(JsonValueKind.Number, count.Value.ValueKind);
        Assert.Equal(0, (int)count.Value);
    }

    [Fact]
    public void PresentStringPropertyWithDefault_ReturnsActualValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test","status":"inactive"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.StatusEntity? status = instance.Status;

        Assert.NotNull(status);
        Assert.Equal("inactive", (string)status.Value);
    }

    [Fact]
    public void PresentIntegerPropertyWithDefault_ReturnsActualValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test","count":42}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.CountEntity? count = instance.Count;

        Assert.NotNull(count);
        Assert.Equal(42, (int)count.Value);
    }

    [Fact]
    public void MissingPropertyWithoutDefault_ReturnsNull()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.LabelEntity? label = instance.Label;

        Assert.Null(label);
    }

    [Fact]
    public void PresentPropertyWithoutDefault_ReturnsActualValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test","label":"hello"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.LabelEntity? label = instance.Label;

        Assert.NotNull(label);
        Assert.Equal("hello", (string)label.Value);
    }

    [Fact]
    public void RequiredPropertyPresent_ReturnsActualValue()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"test"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;
        ObjectWithDefaultProperties.NameEntity name = instance.Name;

        Assert.Equal(JsonValueKind.String, name.ValueKind);
        Assert.Equal("test", (string)name);
    }

    [Fact]
    public void AllPropertiesPresent_ReturnsActualValues()
    {
        using ParsedJsonDocument<ObjectWithDefaultProperties> doc =
            ParsedJsonDocument<ObjectWithDefaultProperties>.Parse("""{"name":"Alice","status":"pending","count":5,"label":"important"}""");

        ObjectWithDefaultProperties instance = doc.RootElement;

        Assert.Equal("Alice", (string)instance.Name);
        Assert.Equal("pending", (string)instance.Status!.Value);
        Assert.Equal(5, (int)instance.Count!.Value);
        Assert.Equal("important", (string)instance.Label!.Value);
    }
}
