// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    internal sealed class JsonReaderException : JsonException
    {
        public JsonReaderException(string message, long lineNumber, long bytePositionInLine) : base(message, path: null, lineNumber, bytePositionInLine)
        {
        }
    }
}
