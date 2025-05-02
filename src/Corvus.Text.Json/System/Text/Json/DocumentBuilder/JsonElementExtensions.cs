// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    public static class JsonElementExtensions
    {
        [CLSCompliant(false)]
        public static JsonDocumentBuilder CreateBuilder<TElement>(this TElement sourceElement, JsonWorkspace workspace)
            where TElement : struct, IJsonElement<TElement>
        {
            return workspace.CreateBuilder(sourceElement);
        }
    }
}
