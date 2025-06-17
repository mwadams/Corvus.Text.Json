// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace Corvus.Text.Json.Tests;

internal class DummyResultsCollector : IJsonSchemaResultsCollector
{
    int _childContextCount = 0;
    int _schemaLocationCount = 0;

    public void AssertState()
    {
        Assert.Equal(1, _childContextCount);
        Assert.Equal(0, _schemaLocationCount);
    }

    public int BeginChildContext(JsonSchemaPathProvider reducedEvaluationPath = null, JsonSchemaPathProvider documentEvaluationPath = null) => _childContextCount++;
    public int BeginChildContext(ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider reducedEvaluationPath = null) => _childContextCount++;
    public int BeginChildContext<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> reducedEvaluationPath, JsonSchemaPathProvider<TProviderContext> documentEvaluationPath) => _childContextCount++;
    public int BeginChildContextUnescaped(ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider reducedEvaluationPath = null) => _childContextCount++;
    public void CommitChildContext(int sequenceNumber, bool isMatch, JsonSchemaMessageProvider messageProvider) => _childContextCount--;
    public void CommitChildContext<TProviderContext>(int sequenceNumber, bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider) => _childContextCount--;
    public void Dispose() {}
    public void EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider messageProvider) { }
    public void EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider) { }
    public void EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword) { }
    public void EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword) { }
    public void EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword) { }
    public void EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> encodedKeyword) { }
    public void EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider encodedKeywordPath) { }
    public void EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext? providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> encodedKeywordPath) { }
    public void IgnoredKeyword(JsonSchemaMessageProvider messageProvider, ReadOnlySpan<byte> encodedKeyword) { }
    public void IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, ReadOnlySpan<byte> encodedKeyword) { }
    public void PopChildContext(int sequenceNUmber) => _childContextCount--;
    public void PopSchemaLocation() => _schemaLocationCount--;
    public void PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation) => _schemaLocationCount++;
    public void PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider) => _schemaLocationCount++;
}
