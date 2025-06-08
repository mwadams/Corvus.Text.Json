// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace Corvus.Text.Json.Tests;

internal class DummyResultsCollector : IJsonSchemaResultsCollector
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

    public void PopChildContext() { --_childContextCount; }

    public void AssertState()
    {
        Assert.Equal(1, _childContextCount);
        Assert.Equal(0, _schemaLocationCount);
    }

}
