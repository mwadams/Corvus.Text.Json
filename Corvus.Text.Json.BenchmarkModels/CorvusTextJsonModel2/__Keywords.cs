// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json;
using Corvus.Text.Json.Internal;

namespace Benchmark.CorvusTextJson2
{
    internal static class __Keywords
    {
        public static readonly JsonSchemaPathProvider Format = (buffer, out written) => JsonSchemaMatching.TryCopyPath("format"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider Items = (buffer, out written) => JsonSchemaMatching.TryCopyPath("items"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider PrefixItems = (buffer, out written) => JsonSchemaMatching.TryCopyPath("prefixItems"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider<int> PrefixItemsWithIndex = (index, buffer, out written) => JsonSchemaMatching.SchemaLocationForIndexedKeyword("prefixItems"u8, index, buffer, out written);
        public static readonly JsonSchemaPathProvider Properties = (buffer, out written) => JsonSchemaMatching.TryCopyPath("properties"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider Required = (buffer, out written) => JsonSchemaMatching.TryCopyPath("required"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider Type = (buffer, out written) => JsonSchemaMatching.TryCopyPath("type"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider UnevaluatedItems = (buffer, out written) => JsonSchemaMatching.TryCopyPath("unevaluatedItems"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider UnevaluatedProperties = (buffer, out written) => JsonSchemaMatching.TryCopyPath("unevaluatedProperties"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider OneOf = (buffer, out written) => JsonSchemaMatching.TryCopyPath("oneOf"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider MinLength = (buffer, out written) => JsonSchemaMatching.TryCopyPath("minLength"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider MaxLength = (buffer, out written) => JsonSchemaMatching.TryCopyPath("maxLength"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider Minimum = (buffer, out written) => JsonSchemaMatching.TryCopyPath("minimum"u8, buffer, out written);
        public static readonly JsonSchemaPathProvider Maximum = (buffer, out written) => JsonSchemaMatching.TryCopyPath("maximum"u8, buffer, out written);
    }
}
