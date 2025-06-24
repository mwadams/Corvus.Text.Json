// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Determines if the value in the builder has been set as an array, object, or simple type.
    /// </summary>
    public enum ArrayOrObject
    {
        /// <summary>
        /// The value has not yet been set
        /// </summary>
        Unset,
        /// <summary>
        /// The value is set to an array.
        /// </summary>
        Array,
        /// <summary>
        /// The value has been set to an object.
        /// </summary>
        Object,
    }
}
