// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.Compatibility
{
    /// <summary>
    /// Provides polyfills for Corvus.JsonSchema API compatibility.
    /// </summary>
    [CLSCompliant(false)]
    public static class Polyfills
    {
        private static class Instances<T>
            where T : struct, IJsonElement<T>
        {
            public static readonly T NullInstance = ParsedJsonDocument<T>.ParseValue("null", default).RootElement;
        }

        extension<T>(T element)
            where T : struct, IJsonElement<T>
        {
            public bool IsValid()
            {
                return element.IsSchemaMatch();
            }

            public bool HasDotnetBacking => false;
            public bool HasJsonElementBacking => true;

            public static T Null => Instances<T>.NullInstance;
            public static T Undefined => default;

            public JsonElement AsJsonElement => new(element.ParentDocument, element.ParentDocumentIndex);

            // JsonElement is the equivalent of JsonAny in Corvus.JsonSchema
            public JsonElement AsAny => new(element.ParentDocument, element.ParentDocumentIndex);

            public static T Parse(string value, JsonDocumentOptions options = default)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, options);
                return document.RootElement;
            }

            public static T Parse(Stream value, JsonDocumentOptions options = default)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, options);
                return document.RootElement;
            }

            public static T Parse(ReadOnlyMemory<byte> value, JsonDocumentOptions options = default)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value.Span, options);
                return document.RootElement;
            }

            public static T Parse(ReadOnlyMemory<char> value, JsonDocumentOptions options = default)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, options);
                return document.RootElement;
            }

            public static T ParseValue(string value)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, default);
                return document.RootElement;
            }

            public static T ParseValue(ReadOnlySpan<char> value)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value.ToArray(), default);
                return document.RootElement;
            }

            public static T ParseValue(ReadOnlySpan<byte> value)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, default);
                return document.RootElement;
            }

            public static T ParseValue(ref Utf8JsonReader value)
            {
                // This is the unrented path/
                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(ref value);
                return document.RootElement;
            }

            public static T FromJson<TTarget>(in TTarget value)
                where TTarget : struct, IJsonElement<TTarget>
            {
#if NET
                return T.CreateInstance(value.ParentDocument, value.ParentDocumentIndex);
#else
                return JsonElementHelpers.CreateInstance<T>(value.ParentDocument, value.ParentDocumentIndex);
#endif
            }

            public TTarget As<TTarget>()
                where TTarget : struct, IJsonElement<TTarget>
            {
#if NET
                return TTarget.CreateInstance(element.ParentDocument, element.ParentDocumentIndex);
#else
                return JsonElementHelpers.CreateInstance<TTarget>(element.ParentDocument, element.ParentDocumentIndex);
#endif
            }

            /// <summary>
            /// Validates the instance against its own schema.
            /// </summary>
            /// <param name="context">The current validation context.</param>
            /// <param name="validationLevel">The validation level. (Defaults to <see cref="ValidationLevel.Flag"/>).</param>
            /// <returns>The <see cref="ValidationContext"/> updated with the results from this validation operation.</returns>
            public ValidationContext Validate(in ValidationContext context, ValidationLevel validationLevel = ValidationLevel.Flag)
            {
                if (validationLevel == ValidationLevel.Flag)
                {
                    return new(element.IsSchemaMatch());
                }
                
                CompatibilityResultsCollector collector = context.Collector;
                element.IsSchemaMatch(collector);
                return new(collector, context.Results);
            }
        }
    }

    internal struct CompatibilityResultsCollector : IJsonSchemaResultsCollector
    {
        private readonly ValidationLevel _level;

        public CompatibilityResultsCollector(ValidationLevel level)
        {
            //  We should not be constructing a collector for the level "flag"
            Debug.Assert(level != ValidationLevel.Flag);
            _level = level;
        }

        public void BeginChildContext(JsonSchemaPathProvider? schemaEvaluationPath = null, JsonSchemaPathProvider? documentEvaluationPath = null) => throw new NotImplementedException();
        public void BeginChildContext(ReadOnlySpan<byte> propertyName, JsonSchemaPathProvider? schemaEvaluationPath = null) => throw new NotImplementedException();
        public void BeginChildContext<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath, JsonSchemaPathProvider<TProviderContext>? documentEvaluationPath) => throw new NotImplementedException();
        public void CommitChildContext(bool isMatch, JsonSchemaMessageProvider? messageProvider) => throw new NotImplementedException();
        public void CommitChildContext<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider) => throw new NotImplementedException();
        public void Ignored(JsonSchemaMessageProvider? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) => throw new NotImplementedException();
        public void Ignored<TProviderContext>(TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) => throw new NotImplementedException();
        public void Matched(bool isMatch, JsonSchemaMessageProvider? messageProvider, JsonSchemaPathProvider? schemaEvaluationPath) => throw new NotImplementedException();
        public void Matched<TProviderContext>(bool isMatch, TProviderContext providerContext, JsonSchemaMessageProvider<TProviderContext>? messageProvider, JsonSchemaPathProvider<TProviderContext>? schemaEvaluationPath) => throw new NotImplementedException();
        public void PopChildContext() => throw new NotImplementedException();
        public void PopSchemaLocation() => throw new NotImplementedException();
        public void PushSchemaLocation(JsonSchemaPathProvider relativeOrAbsoluteSchemaLocation) => throw new NotImplementedException();
        public void PushSchemaLocation<TProviderContext>(TProviderContext providerContext, JsonSchemaPathProvider<TProviderContext> relativeOrAbsoluteSchemaLocationProvider) => throw new NotImplementedException();


        // Gets the version of the results, so we can avoid a copy if it is not updated
        public int ResultsVersion => throw new NotImplementedException();

        internal bool IsValid => throw new NotImplementedException();

        internal IReadOnlyList<ValidationResult> CloneResults() => throw new NotImplementedException();
    }

    public readonly struct ValidationContext
    {
        /// <summary>
        /// Gets a valid context.
        /// </summary>
        public static readonly ValidationContext ValidContext = new(true);

        /// <summary>
        /// Gets an invalid context.
        /// </summary>
        public static readonly ValidationContext InvalidContext = new(false);

        internal ValidationContext(bool isValid)
        {
            IsValid = isValid;
            Results = [];
        }

        internal ValidationContext(CompatibilityResultsCollector collector)
        {
            // Capture it at the moment we were given the collector
            IsValid = collector.IsValid;
            Results = collector.CloneResults();
            Collector = collector;
        }

        // This is the constructor for when the results collection has not changed
        internal ValidationContext(CompatibilityResultsCollector collector, IReadOnlyList<ValidationResult> results)
        {
            // Capture it at the moment we were given the collector
            IsValid = collector.IsValid;
            Results = results;
            Collector = collector;
        }

        public bool IsValid { get; }

        /// <summary>
        /// Gets the validation results.
        /// </summary>
        public IReadOnlyList<ValidationResult> Results { get; }

        internal CompatibilityResultsCollector Collector { get; }
    }

    public class ValidationResult
    {
    }

    /// <summary>
    /// The validation level.
    /// </summary>
    public enum ValidationLevel
    {
        /// <summary>
        /// 10.4.1. Flag.
        /// </summary>
        Flag,

        /// <summary>
        /// 10.4.2. Basic.
        /// </summary>
        Basic,

        /// <summary>
        /// 10.4.3. Detailed.
        /// </summary>
        Detailed,

        /// <summary>
        /// 10.4.4. Verbose.
        /// </summary>
        Verbose,
    }
}
