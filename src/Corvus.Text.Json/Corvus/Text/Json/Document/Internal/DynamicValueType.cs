// <copyright file="DynamicValueType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Represents the type of a dynamic JSON value.
    /// </summary>
    internal enum DynamicValueType : uint
    {
        /// <summary>
        /// An unescaped UTF-8 string value.
        /// </summary>
        UnescapedUtf8String,

        /// <summary>
        /// A quoted UTF-8 string value.
        /// </summary>
        QuotedUtf8String,

        /// <summary>
        /// A numeric value.
        /// </summary>
        Number,

        /// <summary>
        /// A boolean value.
        /// </summary>
        Boolean,

        /// <summary>
        /// A null value.
        /// </summary>
        Null
    }
}
