// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;

namespace Corvus.Text.Json.Compatibility
{
    internal struct CompatibilityResultsCollector : IJsonSchemaResultsCollector
    {
        private readonly ValidationLevel _level;

        public CompatibilityResultsCollector(ValidationLevel level)
        {
            //  We should not be constructing a collector for the level "flag"
            Debug.Assert(level != ValidationLevel.Flag);
            _level = level;
        }



        // Gets the version of the results, so we can avoid a copy if it is not updated
        public int ResultsVersion => throw new NotImplementedException();

        internal bool IsValid => throw new NotImplementedException();

        internal IReadOnlyList<ValidationResult> CloneResults() => throw new NotImplementedException();
        internal ReadOnlySpan<byte> GetUtf8String(int validationLocationIdx) => throw new NotImplementedException();

        void IDisposable.Dispose() => throw new NotImplementedException();
        int IJsonSchemaResultsCollector.BeginChildContext(JsonSchemaPathProvider? schemaEvaluationPath, JsonSchemaPathProvider? documentEvaluationPath) => throw new NotImplementedException();
        int IJsonSchemaResultsCollector.BeginChildContext(ReadOnlySpan<byte> escapedPropertyName, JsonSchemaPathProvider? reducedEvaluationPath) => throw new NotImplementedException();
        int IJsonSchemaResultsCollector.BeginChildContextUnescaped(ReadOnlySpan<byte> unescapedPropertyName, JsonSchemaPathProvider? reducedEvaluationPath) => throw new NotImplementedException();
        int IJsonSchemaResultsCollector.BeginChildContext<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.CommitChildContext(int sequenceNumber, bool isMatch, JsonSchemaMessageProvider? messageProvider) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.CommitChildContext<TProviderContext>(int sequenceNumber, bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.PopChildContext(int sequenceNUmber) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.IgnoredKeyword(JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.IgnoredKeyword<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeyword(bool isMatch, JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeyword<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeywordPath(bool isMatch, JsonSchemaMessageProvider messageProvider, JsonSchemaPathProvider keywordPath) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeywordPath<TProviderContext>(bool isMatch, TProviderContext? providerContext, JsonSchemaMessageProvider<TProviderContext> messageProvider, JsonSchemaPathProvider<TProviderContext> keywordPath) where TProviderContext : default => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeywordForProperty(bool isMatch, JsonSchemaMessageProvider? messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedKeywordForProperty<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, ReadOnlySpan<byte> propertyName, ReadOnlySpan<byte> unescapedKeyword) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedBooleanSchema(bool isMatch, JsonSchemaMessageProvider? messageProvider) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.EvaluatedBooleanSchema<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider) => throw new NotImplementedException();
        void IJsonSchemaResultsCollector.PopSchemaLocation() => throw new NotImplementedException();
    }
}
