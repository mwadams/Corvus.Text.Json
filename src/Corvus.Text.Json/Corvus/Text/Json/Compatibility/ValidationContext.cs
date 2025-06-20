// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Corvus.Text.Json.Compatibility
{
    /// <summary>
    /// Represents the context for a JSON schema validation operation, including validity and results.
    /// </summary>
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
        }

        // This is the constructor for when the results collection has not changed
        internal ValidationContext(bool isMatch, JsonSchemaResultsCollector collector)
        {
            // Capture it at the moment we were given the collector
            IsValid = isMatch;
            Collector = collector;
        }

        public bool IsValid { get; }

        /// <summary>
        /// Gets the validation results.
        /// </summary>
        public IReadOnlyList<ValidationResult> Results => BuildResults(Collector);

        internal JsonSchemaResultsCollector? Collector { get; }

        private IReadOnlyList<ValidationResult> BuildResults(JsonSchemaResultsCollector? collector) => throw new NotImplementedException();

        internal static JsonSchemaResultsLevel MapLevel(ValidationLevel level)
        {
            return level switch
            {
                // Do not allow Flag
                ValidationLevel.Basic => JsonSchemaResultsLevel.Basic,
                ValidationLevel.Detailed => JsonSchemaResultsLevel.Detailed,
                ValidationLevel.Verbose => JsonSchemaResultsLevel.Verbose,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
        }
    }
}
