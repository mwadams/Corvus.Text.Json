// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public delegate ReadOnlySpan<byte> PathProvider();

    public interface IJsonValidationResultsCollector
    {
        /// <summary>
        /// Begin a child context.
        /// </summary>
        /// <param name="relativeOrAbsoluteSchemaLocation">The relative or absolute schema location to push onto the location path</param>
        /// <param name="relativeSchemaPath">The relative schema evaluation path.</param>
        /// <param name="relativeDocumentPath">The relative document path.</param>
        void BeginChildContext(PathProvider relativeOrAbsoluteSchemaLocation, PathProvider relativeSchemaPath, PathProvider relativeDocumentPath);


        void CommitChildContext();
        void PopChildContext();
    }
}
