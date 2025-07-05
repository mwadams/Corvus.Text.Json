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
        public static async Task GenerateCode_Emits_SimpleTypes(string type)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"type_{type}.json", string.Format(SimpleType, type));
        }


        private const string ArrayType =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": {0}
            }}           
            """;


        [Theory]
        [InlineData("[\"object\", \"array\"]")]
        [InlineData("[\"object\", \"string\"]")]
        [InlineData("[\"object\", \"number\"]")]
        [InlineData("[\"object\", \"boolean\"]")]
        [InlineData("[\"object\", \"null\"]")]
        [InlineData("[\"array\", \"string\"]")]
        [InlineData("[\"array\", \"number\"]")]
        [InlineData("[\"array\", \"boolean\"]")]
        [InlineData("[\"array\", \"null\"]")]
        public static async Task GenerateCode_Emits_ArrayTypes(string type)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"types_{GetNameFor(type)}.json", string.Format(ArrayType, type));
        }

        private static object GetNameFor(string type)
        {
            StringBuilder s = new(type);
            s.Replace("\"", "");
            s.Replace(" ", "");
            s.Replace(",", "");
            s.Replace("[", "");
            s.Replace("]", "");
            return s.ToString();
        }
    }
}
