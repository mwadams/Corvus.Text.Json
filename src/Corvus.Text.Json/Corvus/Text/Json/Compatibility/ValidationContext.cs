// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Corvus.Text.Json.Compatibility
{
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
}
