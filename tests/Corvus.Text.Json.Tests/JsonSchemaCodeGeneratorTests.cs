// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;
using TestUtilities;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public static class JsonSchemaCodeGeneratorTests
    {
        private const string SimpleType =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "{0}"
            }}           
            """;

        [Theory]
        [InlineData("object")]
        [InlineData("array")]
        [InlineData("string")]
        [InlineData("number")]
        [InlineData("boolean")]
        [InlineData("null")]
        public static async Task GenerateCode_Emits(string type)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"simple_{type}.json", string.Format(SimpleType, type));
        }
    }
}
