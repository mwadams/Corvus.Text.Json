// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text;
using Xunit;
using Corvus.Text.Json.Internal;
using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace Corvus.Text.Json.Tests;

public class JsonSchemaMatchingStringTests
{
    private class DummyDocument : IJsonDocument
    {
        private readonly JsonTokenType _tokenType;

        public bool IsDisposable => false;
        public bool IsImmutable => true;

        public DummyDocument(JsonTokenType tokenType)
        {
            _tokenType = tokenType;
        }

        public void AppendElementToMetadataDb(int index, JsonWorkspace workspace, ref MetadataDb db) { }

        public int BuildRentedMetadataDb(int parentDocumentIndex, JsonWorkspace workspace, out byte[] rentedBacking) { rentedBacking = []; return 0; }
        public JsonElement CloneElement(int index) { return default; }
        public TElement CloneElement<TElement>(int index) where TElement : struct, IJsonElement<TElement> { return default; }
        public void Dispose() { }
        public void EnsurePropertyMap(int index) { }
        public JsonElement GetArrayIndexElement(int currentIndex, int arrayIndex) { return default; }
        public TElement GetArrayIndexElement<TElement>(int currentIndex, int arrayIndex) where TElement : struct, IJsonElement<TElement> { return default; }
        public int GetArrayLength(int index) { return 0; }
        public int GetDbSize(int index, bool includeEndElement) { return 0; }
        public JsonTokenType GetJsonTokenType(int index) { return _tokenType; }
        public string GetNameOfPropertyValue(int index) { return string.Empty; }
        public int GetPropertyCount(int index) { return 0; }
        public ReadOnlySpan<byte> GetPropertyNameRaw(int index) { return default; }
        public string GetPropertyRawValueAsString(int valueIndex) { return string.Empty; }
        public ReadOnlyMemory<byte> GetRawSimpleValue(int index, bool includeQuotes) { return default; }
        public RawUtf8JsonString GetRawValue(int index, bool includeQuotes) { return default; }
        public string GetRawValueAsString(int index) { return string.Empty; }
        public string GetString(int index, JsonTokenType expectedType) { return string.Empty; }
        public UnescapedUtf8JsonString GetUtf8JsonString(int index, JsonTokenType expectedType) { return default; }
        public bool TextEquals(int index, ReadOnlySpan<char> otherText, bool isPropertyName) { return false; }
        public bool TextEquals(int index, ReadOnlySpan<byte> otherUtf8Text, bool isPropertyName, bool shouldUnescape) { return false; }
        public bool TryGetNamedPropertyValue(int index, ReadOnlySpan<char> propertyName, out JsonElement value) { value = default; return false; }
        public bool TryGetNamedPropertyValue(int index, ReadOnlySpan<byte> propertyName, out JsonElement value) { value = default; return false; }
        public bool TryGetNamedPropertyValue<TElement>(int index, ReadOnlySpan<byte> propertyName, out TElement value) where TElement : struct, IJsonElement<TElement> { value = default; return false; }
        public bool TryGetValue(int index, [NotNullWhen(true)] out byte[] value) { value = default; return false; }
        public bool TryGetValue(int index, out sbyte value) { value = default; return false; }
        public bool TryGetValue(int index, out byte value) { value = default; return false; }
        public bool TryGetValue(int index, out short value) { value = default; return false; }
        public bool TryGetValue(int index, out ushort value) { value = default; return false; }
        public bool TryGetValue(int index, out int value) { value = default; return false; }
        public bool TryGetValue(int index, out uint value) { value = default; return false; }
        public bool TryGetValue(int index, out long value) { value = default; return false; }
        public bool TryGetValue(int index, out ulong value) { value = default; return false; }
        public bool TryGetValue(int index, out double value) { value = default; return false; }
        public bool TryGetValue(int index, out float value) { value = default; return false; }
        public bool TryGetValue(int index, out decimal value) { value = default; return false; }
        public bool TryGetValue(int index, out DateTime value) { value = default; return false; }
        public bool TryGetValue(int index, out DateTimeOffset value) { value = default; return false; }
        public bool TryGetValue(int index, out OffsetDateTime value) { value = default; return false; }
        public bool TryGetValue(int index, out OffsetDate value) { value = default; return false; }
        public bool TryGetValue(int index, out OffsetTime value) { value = default; return false; }
        public bool TryGetValue(int index, out LocalDate value) { value = default; return false; }
        public bool TryGetValue(int index, out Period value) { value = default; return false; }
        public bool TryGetValue(int index, out Guid value) { value = default; return false; }
#if NET
        public bool TryGetValue(int index, out Int128 value) { value = default; return false; }
        public bool TryGetValue(int index, out UInt128 value) { value = default; return false; }
        public bool TryGetValue(int index, out Half value) { value = default; return false; }
#endif
        public bool ValueIsEscaped(int index, bool isPropertyName) { return false; }
        public void WriteElementTo(int index, Utf8JsonWriter writer) { }
        public void WritePropertyName(int index, Utf8JsonWriter writer) { }
    }

    private class DummyResultsCollector : IJsonSchemaResultsCollector
    {
        int _childContextCount = 0;
        int _schemaLocationCount = 0;
        public void BeginChildContext(JsonSchemaPathProvider? schemaEvaluationPath = null, JsonSchemaPathProvider? documentEvaluationPath = null) { ++_childContextCount; }
        public void BeginChildContext(ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider? schemaEvaluationPath = null) { ++_childContextCount; }
        public void BeginChildContext<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath) { ++_childContextCount; }
        public void CommitChildContext(bool isMatch, JsonSchemaMessageProvider? messageProvider) => --_childContextCount;
        public void CommitChildContext<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider) => --_childContextCount;
        public void Matched(bool isMatch, JsonSchemaMessageProvider? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) { }
        public void Matched<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath) { }
        public void PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation) { ++_schemaLocationCount; }
        public void PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider) { ++_schemaLocationCount; }
        public void PopSchemaLocation() { --_schemaLocationCount; }
        public void Ignored(JsonSchemaMessageProvider? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) { }
        public void Ignored<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) { }

        public void PopChildContext() { --_childContextCount;  }

        public void AssertState()
        {
            Assert.Equal(1, _childContextCount);
            Assert.Equal(0, _schemaLocationCount);
        }

    }

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
