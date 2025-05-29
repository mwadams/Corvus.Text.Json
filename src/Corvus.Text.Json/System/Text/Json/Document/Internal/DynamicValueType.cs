// <copyright file="DynamicValueType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Text.Json.Internal
{
    internal enum DynamicValueType : uint
    {
        UnescapedUtf8String,
        QuotedUtf8String,
        Number,
        Boolean,
        Null
    }
}
