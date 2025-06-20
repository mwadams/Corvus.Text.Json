// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json.Compatibility
{
    /// <summary>
    /// Represents the result of a single JSON schema validation, including validity, message, and locations.
    /// </summary>
    public readonly struct ValidationResult
    {
        private readonly JsonSchemaResultsCollector _collector;
        private readonly int _resultIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> struct.
        /// </summary>
        /// <param name="valid">A value indicating whether this is a valid result.</param>
        /// <param name="messageRange">The error message.</param>
        /// <param name="location">The location of the result.</param>
        internal ValidationResult(JsonSchemaResultsCollector collector, int resultIndex)
        {
            Debug.Assert(resultIndex >= 0);

            _collector = collector;
            _resultIndex = resultIndex;
        }

        public bool Valid
        {
            get
            {
                var result = _collector.ReadResult(_resultIndex);
                return result.IsMatch;
            }
        }

        public LocationTuple Location
        {
            get
            {
                var result = _collector.ReadResult(_resultIndex);
                return new LocationTuple(result.EvaluationLocation, result.SchemaEvaluationLocation, result.DocumentEvaluationLocation);
            }
        }

        public string? Message
        {
            get
            {
                var result = _collector.ReadResult(_resultIndex);
                return result.GetMessageText();
            }
        }

        /// <summary>
        /// Represents the locations associated with a validation result, including validation, schema, and document locations.
        /// </summary>
        public readonly ref struct LocationTuple
        {
            private readonly ReadOnlySpan<byte> _validationLocation;
            private readonly ReadOnlySpan<byte> _schemaLocation;
            private readonly ReadOnlySpan<byte> _documentLocation;

            internal LocationTuple(ReadOnlySpan<byte> validationLocation, ReadOnlySpan<byte> schemaLocation, ReadOnlySpan<byte> documentLocation)
            {
                _validationLocation = validationLocation;
                _schemaLocation = schemaLocation;
                _documentLocation = documentLocation;
            }

            public JsonReference ValidationLocation => JsonReference.Create(_validationLocation);
            public JsonReference SchemaLocation => JsonReference.Create(_schemaLocation);
            public JsonReference DocumentLocation => JsonReference.Create(_documentLocation);
        }
    }
}
