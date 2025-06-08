// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.Tests;

public class JsonSchemaMatchingStringTests
{
    private JsonSchemaContext CreateContext(DummyResultsCollector collector, JsonTokenType tokenType)
    {
        return JsonSchemaContext.BeginContext(new DummyDocument(tokenType), 0, false, false, collector);
    }

    [Theory]
    [InlineData(JsonTokenType.String, true)]
    [InlineData(JsonTokenType.Number, false)]
    public void MatchTypeString_ValidatesTokenType(JsonTokenType tokenType, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchTypeString(tokenType, DummyPathProvider, ref context);
        Assert.Equal(expected, result);        
        collector.AssertState();
        context.Dispose();
    }

    private bool DummyPathProvider(Span<byte> buffer, out int written) { written = 0; return true; }

    [Theory]
    [InlineData("2023-06-01", true)]
    [InlineData("not-a-date", false)]
    public void MatchDate_ValidatesDate(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDate(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("2023-06-01T12:34:56+00:00", true)]
    [InlineData("not-a-datetime", false)]
    public void MatchDateTime_ValidatesDateTime(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDateTime(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("12:34:56+00:00", true)]
    [InlineData("not-a-time", false)]
    public void MatchTime_ValidatesTime(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchTime(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("P1D", true)] // ISO 8601 duration
    [InlineData("not-a-duration", false)]
    public void MatchDuration_ValidatesDuration(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchDuration(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("user@example.com", true)]
    [InlineData("invalid-email", false)]
    public void MatchEmail_ValidatesEmail(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchEmail(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }

    [Theory]
    [InlineData("user@example.com", true)] // Standard ASCII email
    [InlineData("user@xn--bcher-kva.ch", true)] // Punycode domain
    [InlineData("user@bücher.ch", true)] // Unicode domain (IDN)
    [InlineData("用户@例子.公司", true)] // Unicode local and domain
    [InlineData("user@sub.例子.公司", true)] // Unicode subdomain
    [InlineData("user@", false)] // Missing domain
    [InlineData("@example.com", false)] // Missing local part
    [InlineData("userexample.com", false)] // Missing '@'
    [InlineData("user@.com", false)] // Invalid domain
    [InlineData("user@com", false)] // No dot in domain
    [InlineData("user@例子", false)] // No dot in Unicode domain
    [InlineData("", false)] // Empty string
    public void MatchIdnEmail_ValidatesIdnEmail(string value, bool expected)
    {
        var collector = new DummyResultsCollector();
        JsonSchemaContext context = CreateContext(collector, JsonTokenType.String);
        bool result = JsonSchemaMatching.MatchIdnEmail(Encoding.UTF8.GetBytes(value), DummyPathProvider, ref context);
        Assert.Equal(expected, result);
        collector.AssertState();
        context.Dispose();
    }
}
