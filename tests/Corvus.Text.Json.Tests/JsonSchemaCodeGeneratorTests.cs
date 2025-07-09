// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;
using TestUtilities;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public static class JsonSchemaCodeGeneratorTests
    {
        private const string Person =
            """
            {
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "title": "JSON Schema for a Person entity coming back from a 3rd party API (e.g. a storage format in a database)",
                "type": "object",
            
                "required": [ "name" ],
                "properties": {
                    "name": { "$ref": "#/$defs/PersonName" },
                    "age": { "$ref": "#/$defs/Age" },
                    "competedInYears": { "$ref": "#/$defs/CompetedInYears" }
                },
                "$defs": {
                    "PersonArray": {
                        "type": "array",
                        "items": {
                            "$ref": "#/$defs/Person"
                        }
                    },
                    "HeightRangeDouble": {
                        "type": "number",
                        "minimum": 0,
                        "maximum": 3.0
                    },
                    "PersonName": {
                        "type": "object",
                        "description": "A name of a person.",
                        "required": [ "firstName" ],
                        "properties": {
                            "firstName": {
                                "$ref": "#/$defs/NameComponent",
                                "description": "The person's first name."
                            },
                            "lastName": {
                                "$ref": "#/$defs/NameComponent",
                                "description": "The person's last name."
                            },
                            "otherNames": {
                                "$ref": "#/$defs/OtherNames",
                                "description": "Other (middle) names for the person"
                            }
                        }
                    },
                    "OtherNames": {
                        "oneOf": [
                            { "$ref": "#/$defs/NameComponent" },
                            { "$ref": "#/$defs/NameComponentArray" }
                        ]
                    },
                    "NameComponentArray": {
                        "type": "array",
                        "items": {
                            "$ref": "#/$defs/NameComponent"
                        }
                    },
                    "NameComponent": {
                        "type": "string",
                        "minLength": 1,
                        "maxLength": 256
                    },
                    "CompetedInYears": {
                        "type": "array",
                        "items": { "$ref": "#/$defs/Year" }
                    },
                    "Year": {
                        "type": "number",
                        "format": "int32"
                    },
                    "Age": {
                        "type": "number",
                        "minimum": 0,
                        "maximum": 130
                    }
                }
            }            
            """;

        private const string SimpleType =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "{0}"
            }}           
            """;

        private const string ArrayTypeWithItemsConstraint =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "array",
                "{0}": {{ "type": "{1}" }}
            }}
            """;

        private const string ArrayTypeWithItemsConstraintAndFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "array",
                "{0}": {{ "type": "{1}", "format": "{2}" }}
            }}
            """;

        private const string NumericFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "number",
                "format": "{0}"
            }}           
            """;

        private const string NumericArrayFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "array",
                "items": {{
                    "type": "number",
                    "format": "{0}"           
                }}
            }}           
            """;

        private const string FixedSizeNumericArrayFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "array",
                "items": {{
                    "type": "number",
                    "format": "{0}"           
                }},
                "minItems": 10,
                "maxItems": 10
            }}           
            """;

        private const string MultiDimensionFixedSizeNumericArrayFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "array",
                "items": {{
                    "type": "array",
                    "items": {{
                        "type": "number",
                        "format": "{0}"           
                    }},
                    "minItems": 5,
                    "maxItems": 5
                }},
                "minItems": 2,
                "maxItems": 2
            }}           
            """;
        private const string StringFormat =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "string",
                "format": "{0}"
            }}           
            """;

        private const string ArrayType =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": {0}
            }}           
            """;


        private const string ComposedMultiFormatType =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "anyOf": [
                        {{"type": "{0}", "format": "{1}"}},
                        {{"type": "{2}", "format": "{3}"}}
                    ]
            }}           
            """;

        private const string ComposedMultiFormatNumericWithAdditionalConstraint =
            """
            {{
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "anyOf": [
                        {{"type": "{0}", "format": "{1}"}},
                        {{"type": "{2}", "format": "{3}"}}
                    ],
                "minimum": 30
            }}           
            """;

        private const string SimpleObjectWithProperties =
            """
            {
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "type": "object",
                "properties": {
                    "name": {
                        "type": "string"
                    },
                    "otherName": {
                        "type": "number"
                    }
                }
            }
            """;

        private const string ComposedObjectWithProperties =
            """
            {
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "allOf": [
                    {
                        "type": "object",
                        "properties": {
                            "name": {
                                "type": "string"
                            }
                        }           
                    },
                    {
                        "type": "object",
                        "properties": {
                            "otherName": {
                                "type": "number"
                            }
                        }           
                    }         
                ]
            }
            """;

        private const string ComposedObjectWithRequiredProperties =
            """
            {
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "allOf": [
                    {
                        "required": ["name"]
                    },
                    {
                        "type": "object",
                        "properties": {
                            "name": {
                                "type": "string"
                            },
                            "otherName": {
                                "type": "number"
                            }
                        }           
                    }         
                ]
            }
            """;

        [Fact]
        public static async Task GenerateCode_Emits_Person()
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"person.json", Person);
        }

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

            static string GetNameFor(string type)
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

        [Theory]
        [InlineData("sbyte")]
        [InlineData("int16")]
        [InlineData("int32")]
        [InlineData("int64")]
        [InlineData("int128")]
        [InlineData("byte")]
        [InlineData("uint16")]
        [InlineData("uint32")]
        [InlineData("uint64")]
        [InlineData("uint128")]
        [InlineData("decimal")]
        [InlineData("double")]
        [InlineData("single")]
        [InlineData("half")]
        public static async Task GenerateCode_Emits_NumericFormatTypes(string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"numericFormat_{format}.json", string.Format(NumericFormat, format));
        }

        [Theory]
        [InlineData("sbyte")]
        [InlineData("int16")]
        [InlineData("int32")]
        [InlineData("int64")]
        [InlineData("int128")]
        [InlineData("byte")]
        [InlineData("uint16")]
        [InlineData("uint32")]
        [InlineData("uint64")]
        [InlineData("uint128")]
        [InlineData("decimal")]
        [InlineData("double")]
        [InlineData("single")]
        [InlineData("half")]
        public static async Task GenerateCode_Emits_NumericArrayTypes(string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"numericArray_{format}.json", string.Format(NumericArrayFormat, format));
        }

        [Theory]
        [InlineData("sbyte")]
        [InlineData("int16")]
        [InlineData("int32")]
        [InlineData("int64")]
        [InlineData("int128")]
        [InlineData("byte")]
        [InlineData("uint16")]
        [InlineData("uint32")]
        [InlineData("uint64")]
        [InlineData("uint128")]
        [InlineData("decimal")]
        [InlineData("double")]
        [InlineData("single")]
        [InlineData("half")]
        public static async Task GenerateCode_Emits_FixedSizeNumericArrayTypes(string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"fixedSizeNumericArray_{format}.json", string.Format(FixedSizeNumericArrayFormat, format));
        }

        [Theory]
        [InlineData("sbyte")]
        [InlineData("int16")]
        [InlineData("int32")]
        [InlineData("int64")]
        [InlineData("int128")]
        [InlineData("byte")]
        [InlineData("uint16")]
        [InlineData("uint32")]
        [InlineData("uint64")]
        [InlineData("uint128")]
        [InlineData("decimal")]
        [InlineData("double")]
        [InlineData("single")]
        [InlineData("half")]
        public static async Task GenerateCode_Emits_MultiDimensionFixedSizeNumericArrayTypes(string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"multiDimensionFixedSizeNumericArray_{format}.json", string.Format(MultiDimensionFixedSizeNumericArrayFormat, format));
        }

        [Theory]
        [InlineData("date")]
        [InlineData("date-time")]
        [InlineData("time")]
        [InlineData("duration")]
        [InlineData("ipv4")]
        [InlineData("ipv6")]
        [InlineData("uuid")]
        [InlineData("uri")]
        [InlineData("uri-reference")]
        [InlineData("iri")]
        [InlineData("iri-reference")]
        [InlineData("regex")]
        public static async Task GenerateCode_Emits_StringFormatTypes(string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"stringFormat_{format}.json", string.Format(StringFormat, format));
        }

        [Theory]
        [InlineData("string", "date", "string", "date-time")]
        [InlineData("string", "date", "string", "date")]
        [InlineData("string", "date", "number", "int32")]
        [InlineData("string", "uuid", "string", "iri")]
        [InlineData("number", "int64", "number", "int128")]
        public static async Task GenerateCode_Emits_ComposedFormatTypes(string type1, string format1, string type2, string format2)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"composedFormat_{type1}_{format1}_{type2}_{format2}.json", string.Format(ComposedMultiFormatType, type1, format1, type2, format2));
        }

        [Theory]
        [InlineData("number", "int64", "number", "int128")]
        [InlineData("number", "int64", "string", "date")]
        public static async Task GenerateCode_Emits_ComposedMultiFormatNumericWithAdditionalConstraint(string type1, string format1, string type2, string format2)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"composedNumericFormatWithConstraint_{type1}_{format1}_{type2}_{format2}.json", string.Format(ComposedMultiFormatNumericWithAdditionalConstraint, type1, format1, type2, format2));
        }


        [Fact]
        public static async Task GenerateCode_Emits_SimpleObjectWithProperties()
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"simpleObjectWithProperties.json", SimpleObjectWithProperties);
        }


        [Fact]
        public static async Task GenerateCode_Emits_ComposedObjectWithProperties()
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"composedObjectWithProperties.json", ComposedObjectWithProperties);
        }

        [Fact]
        public static async Task GenerateCode_Emits_ComposedObjectWithRequiredProperties()
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"composedObjectWithRequiredProperties.json", ComposedObjectWithRequiredProperties);
        }

        [Theory]
        [InlineData("items", "number", "int128")]
        [InlineData("items", "number", "int64")]
        [InlineData("items", "number", "int32")]
        [InlineData("items", "number", "int16")]
        [InlineData("items", "number", "sbyte")]
        [InlineData("items", "number", "uint128")]
        [InlineData("items", "number", "uint64")]
        [InlineData("items", "number", "uint32")]
        [InlineData("items", "number", "uint16")]
        [InlineData("items", "number", "byte")]
        [InlineData("items", "number", "double")]
        [InlineData("items", "number", "single")]
        [InlineData("items", "number", "decimal")]
        [InlineData("items", "string", "date")]
        [InlineData("items", "string", "date-time")]
        [InlineData("items", "string", "time")]
        [InlineData("items", "string", "duration")]
        [InlineData("items", "string", "ipv4")]
        [InlineData("items", "string", "ipv6")]
        [InlineData("items", "string", "uuid")]
        [InlineData("items", "string", "uri")]
        [InlineData("items", "string", "uri-reference")]
        [InlineData("items", "string", "iri")]
        [InlineData("items", "string", "iri-reference")]
        [InlineData("items", "string", "regex")]
        [InlineData("unevaluatedItems", "number", "int128")]
        [InlineData("unevaluatedItems", "number", "int64")]
        [InlineData("unevaluatedItems", "number", "int32")]
        [InlineData("unevaluatedItems", "number", "int16")]
        [InlineData("unevaluatedItems", "number", "sbyte")]
        [InlineData("unevaluatedItems", "number", "uint128")]
        [InlineData("unevaluatedItems", "number", "uint64")]
        [InlineData("unevaluatedItems", "number", "uint32")]
        [InlineData("unevaluatedItems", "number", "uint16")]
        [InlineData("unevaluatedItems", "number", "byte")]
        [InlineData("unevaluatedItems", "number", "double")]
        [InlineData("unevaluatedItems", "number", "single")]
        [InlineData("unevaluatedItems", "number", "decimal")]
        [InlineData("unevaluatedItems", "string", "date")]
        [InlineData("unevaluatedItems", "string", "date-time")]
        [InlineData("unevaluatedItems", "string", "time")]
        [InlineData("unevaluatedItems", "string", "duration")]
        [InlineData("unevaluatedItems", "string", "ipv4")]
        [InlineData("unevaluatedItems", "string", "ipv6")]
        [InlineData("unevaluatedItems", "string", "uuid")]
        [InlineData("unevaluatedItems", "string", "uri")]
        [InlineData("unevaluatedItems", "string", "uri-reference")]
        [InlineData("unevaluatedItems", "string", "iri")]
        [InlineData("unevaluatedItems", "string", "iri-reference")]
        [InlineData("unevaluatedItems", "string", "regex")]
        public static async Task GenerateCode_Emits_ArrayTypeWithItemsConstraintAndFormat(string keyword, string type, string format)
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode($"arrayTypeWithItemsAndFormat_{keyword}_{type}_{format}.json", string.Format(ArrayTypeWithItemsConstraintAndFormat, keyword, type, format));
        }
    }
}
