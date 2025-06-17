// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json.Compatibility
{
    public readonly struct ValidationResult
    {
        private readonly CompatibilityResultsCollector _collector;
        private readonly uint _messageIdxAndIsValid;
        private readonly int _validationLocationIdx;
        private readonly int _schemaLocationIdx;
        private readonly int _documentLocationIdx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> struct.
        /// </summary>
        /// <param name="valid">A value indicating whether this is a valid result.</param>
        /// <param name="messageRange">The error message.</param>
        /// <param name="location">The location of the result.</param>
        internal ValidationResult(CompatibilityResultsCollector collector, bool valid, int messageIdx, int validationLocationIdx, int schemaLocationIdx, int documentLocationIdx)
        {
            Debug.Assert((uint)messageIdx < 0x8000_0000);

            _collector = collector;
            _messageIdxAndIsValid = (uint)messageIdx | 0x8000_0000U;
            _validationLocationIdx = validationLocationIdx;
            _schemaLocationIdx = schemaLocationIdx;
            _documentLocationIdx = documentLocationIdx;
        }

        public bool Valid => (_messageIdxAndIsValid & 0x8000_0000U) != 0;

        public LocationTuple Location => new(_collector.GetUtf8String(_validationLocationIdx), _collector.GetUtf8String(_schemaLocationIdx), _collector.GetUtf8String(_documentLocationIdx));

        public string? Message => MessageIdx >= 0 ? JsonReaderHelper.GetTextFromUtf8(_collector.GetUtf8String(_validationLocationIdx)) : null;

        private int MessageIdx => (int)(_messageIdxAndIsValid & int.MaxValue);

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
