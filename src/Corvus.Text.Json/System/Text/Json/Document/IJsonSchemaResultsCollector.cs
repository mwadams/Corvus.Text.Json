// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public delegate ReadOnlySpan<byte> JsonSchemaPathProvider();
    public delegate bool JsonSchemaPathProvider<TContext>(TContext context, Span<byte> buffer, out int written);
    public delegate ReadOnlySpan<byte> JsonValidationMessageProvider();
    public delegate bool JsonValidationMessageProvider<TContext>(TContext context, Span<byte> buffer, out int written);

    public interface IJsonSchemaResultsCollector
    {
        /// <summary>
        /// Begin a child context.
        /// </summary>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s).</param>
        /// <param name="documentEvaluationPath">The path in the JSON document instance.</param>
        void BeginChildContext(
            JsonSchemaPathProvider? schemaEvaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null);
        void BeginChildContext<TProviderContext>(
            TProviderContext providerContext,
            JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath,
            JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath);
        void CommitChildContext(bool isMatch, JsonValidationMessageProvider? messageProvider);
        void CommitChildContext<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonValidationMessageProvider<TProviderContext>? messageProvider);
        void PopChildContext();
        void Matched(
            bool isMatch,
            JsonValidationMessageProvider? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);
        
        void PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation);
        void PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider);
        void PopSchemaLocation();
        void Ignored(
            JsonValidationMessageProvider? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);
        void Ignored<TProviderContext>(
            TProviderContext providerContext,
            JsonValidationMessageProvider<TProviderContext>? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);
    }
}
