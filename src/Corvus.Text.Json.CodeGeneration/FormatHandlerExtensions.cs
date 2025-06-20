// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Corvus.Json.CodeGeneration;

namespace Corvus.Text.Json.CodeGeneration
{
    internal static class FormatHandlerExtensions
    {
        /// <summary>
        /// Append format-specific expressions in the body of an <c>Equals&lt;T&gt;</c> method where the comparison values are <c>this</c> and <c>other</c>.
        /// </summary>
        /// <typeparam name="T">The type of the format handler.</typeparam>
        /// <param name="handlers">The handlers which may append expressions.</param>
        /// <param name="generator">The generator to which to append the format expressions.</param>
        /// <param name="typeDeclaration">The type declaration for which to append expressions.</param>
        /// <param name="format">The format for which to append expressions.</param>
        /// <returns><see langword="true"/> if the instance handled this format.</returns>
        public static bool AppendFormatEqualsTBody<T>(this IEnumerable<T> handlers, CodeGenerator generator, TypeDeclaration typeDeclaration, string format)
            where T : notnull, IFormatHandler
        {
            foreach (T handler in handlers)
            {
                if (generator.IsCancellationRequested)
                {
                    return false;
                }

                if (handler.AppendFormatEqualsTBody(generator, typeDeclaration, format))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
