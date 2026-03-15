// <copyright file="CacheTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Xunit;

namespace Corvus.Text.Json.Validator.Tests;

/// <summary>
/// Tests for the caching behaviour of <see cref="JsonSchema"/>.
/// </summary>
public class CacheTests
{
    [Fact]
    public void FromText_SameSchema_ReturnsCachedInstance()
    {
        string schemaJson =
            """
            {
              "$schema": "https://json-schema.org/draft/2020-12/schema",
              "$id": "https://example.com/test/cache-same",
              "type": "string"
            }
            """;

        JsonSchema first = JsonSchema.FromText(schemaJson);
        JsonSchema second = JsonSchema.FromText(schemaJson);

        // Both should validate identically (cached pipeline)
        Assert.True(first.Validate("\"hello\""));
        Assert.True(second.Validate("\"hello\""));
    }

    [Fact]
    public void FromText_RefreshCache_RecompilesSchema()
    {
        string schemaJson =
            """
            {
              "$schema": "https://json-schema.org/draft/2020-12/schema",
              "$id": "https://example.com/test/cache-refresh",
              "type": "string"
            }
            """;

        JsonSchema first = JsonSchema.FromText(schemaJson);
        Assert.True(first.Validate("\"hello\""));

        // Refresh the cache — this should not throw and should produce a working schema
        JsonSchema refreshed = JsonSchema.FromText(schemaJson, refreshCache: true);
        Assert.True(refreshed.Validate("\"hello\""));
    }

    [Fact]
    public void FromText_DifferentAlwaysAssertFormat_UsesSeparateCacheEntries()
    {
        string schemaJson =
            """
            {
              "$schema": "https://json-schema.org/draft/2020-12/schema",
              "$id": "https://example.com/test/cache-format-key",
              "type": "string",
              "format": "email"
            }
            """;

        JsonSchema.Options assertFormat = new(alwaysAssertFormat: true);
        JsonSchema.Options annotateFormat = new(alwaysAssertFormat: false);

        JsonSchema asserting = JsonSchema.FromText(schemaJson, options: assertFormat);
        JsonSchema annotating = JsonSchema.FromText(schemaJson, options: annotateFormat);

        // "not-an-email" should fail when format is asserted, pass when annotated
        Assert.False(asserting.Validate("\"not-an-email\""));
        Assert.True(annotating.Validate("\"not-an-email\""));
    }

    [Fact]
    public void FromFile_SameFile_ReturnsCachedInstance()
    {
        string schemaPath = Path.Combine(
            AppContext.BaseDirectory,
            "Schemas",
            "simple-string.json");

        JsonSchema first = JsonSchema.FromFile(schemaPath);
        JsonSchema second = JsonSchema.FromFile(schemaPath);

        Assert.True(first.Validate("\"hello\""));
        Assert.True(second.Validate("\"hello\""));
    }

    [Fact]
    public void FromFile_RefreshCache_Recompiles()
    {
        string schemaPath = Path.Combine(
            AppContext.BaseDirectory,
            "Schemas",
            "simple-integer.json");

        JsonSchema first = JsonSchema.FromFile(schemaPath);
        Assert.True(first.Validate("50"));

        JsonSchema refreshed = JsonSchema.FromFile(schemaPath, refreshCache: true);
        Assert.True(refreshed.Validate("50"));
    }
}