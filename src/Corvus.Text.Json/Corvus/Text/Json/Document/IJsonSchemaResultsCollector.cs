// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public delegate ReadOnlySpan<byte> JsonSchemaPathProvider();
    public delegate bool JsonSchemaPathProvider<TContext>(TContext context, Span<byte> buffer, out int written);
    public delegate ReadOnlySpan<byte> JsonSchemaMessageProvider();
    public delegate bool JsonSchemaMessageProvider<TContext>(TContext context, Span<byte> buffer, out int written);

    /// <summary>
    /// Implemented by types that accumulate the results of a JSON Schema evaluation.
    /// </summary>
    public interface IJsonSchemaResultsCollector
    {
        /// <summary>
        /// Begin a child context.
        /// </summary>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s).</param>
        /// <param name="documentEvaluationPath">The path in the JSON document instance.</param>
        /// <remarks>
        /// Begins evaluation of a schema in a child context. The context may later be committed with <see cref="CommitChildContext"/>
        /// or abandoned with <see cref="PopChildContext"/>.
        /// </remarks>
        void BeginChildContext(
            JsonSchemaPathProvider? schemaEvaluationPath = null,
            JsonSchemaPathProvider? documentEvaluationPath = null);

        /// <summary>
        /// Begin a child context.
        /// </summary>
        /// <param name="providerContext">The context to be passed to the path provider.</param>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s) at which the child context is being evaluated.</param>
        /// <param name="documentEvaluationPath">The path in the JSON document instance at which the child context is being evaluated.</param>
        /// <remarks>
        /// Begins evaluation of a schema in a child context. The context may later be committed with <see cref="CommitChildContext"/>
        /// or abandoned with <see cref="PopChildContext"/>.
        /// </remarks>
        void BeginChildContext<TProviderContext>(
            TProviderContext providerContext,
            JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath,
            JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath);

        /// <summary>
        /// Commits the last child context.
        /// </summary>
        /// <param name="isMatch">If <see langword="true"/> then the commit indicates that the child produced a successful match.</param>
        /// <param name="messageProvider">The (optional) provider for a JSON validation message.</param>
        /// <remarks>
        /// This allows the collector to update the match state, and commit any resources associated with the child context.
        /// </remarks>
        void CommitChildContext(bool isMatch, JsonSchemaMessageProvider? messageProvider);

        /// <summary>
        /// Commits the last child context.
        /// </summary>
        /// <param name="providerContext">The context to provide to the message provider.</param>
        /// <param name="isMatch">If <see langword="true"/> then the commit indicates that the child produced a successful match.</param>
        /// <param name="messageProvider">The (optional) provider for a JSON schema evaluation message.</param>
        /// <remarks>
        /// This allows the collector to update the match state, and commit any resources associated with the child context.
        /// </remarks>
        void CommitChildContext<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider);

        /// <summary>
        /// Abandons the last child context.
        /// </summary>
        /// <remarks>
        /// This will not update the match state, and allows the collector to release any resources associated with the child context.
        /// </remarks>
        void PopChildContext();

        /// <summary>
        /// Updates the match state for the current context.
        /// </summary>
        /// <param name="isMatch">If <see langword="true"/> then this indicates that the current context produced a successful match.</param>
        /// <param name="messageProvider">The (optional) provider for a JSON schema evaluation message.</param>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s) at which the context is being evaluated.</param>
        void Matched(
            bool isMatch,
            JsonSchemaMessageProvider? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);

        /// <summary>
        /// Pushes the relative or absolute schema location when evaluating a subschema.
        /// </summary>
        /// <param name="relativeOrAbsoluteSchemaLocation">The provider for the relative or absolute schema location of the subschema.</param>
        void PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation);


        /// <summary>
        /// Pushes the relative or absolute schema location when evaluating a subschema.
        /// </summary>
        /// <param name="providerContext">Context to be provided to the provider.</param>
        /// <param name="relativeOrAbsoluteSchemaLocation">The provider for the relative or absolute schema location of the subschema.</param>
        void PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider);

        /// <summary>
        /// Pops the relative or absolute schema location when concluding the evaluation of a subschema.
        /// </summary>
        void PopSchemaLocation();

        /// <summary>
        /// Indicates that a schema keyword was ignored.
        /// </summary>
        /// <param name="messageProvider">The (optional) provider for a JSON schema evaluation message.</param>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s) at which the keyword is ignored.</param>
        void Ignored(
            JsonSchemaMessageProvider? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);

        /// <summary>
        /// Indicates that a schema keyword was ignored.
        /// </summary>
        /// <param name="providerContext">The context to provide to the message provider.</param>
        /// <param name="messageProvider">The (optional) provider for a JSON schema evaluation message.</param>
        /// <param name="schemaEvaluationPath">The path taken through the schema(s) at which the keyword is ignored.</param>
        void Ignored<TProviderContext>(
            TProviderContext providerContext,
            JsonSchemaMessageProvider<TProviderContext>? messageProvider,
            JsonSchemaPathProvider? schemaEvaluationPath);
    }
}
