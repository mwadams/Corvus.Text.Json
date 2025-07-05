// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Threading.Tasks;
using TestUtilities;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    public static class JsonSchemaCodeGeneratorTests
    {
        private const string ExampleSchema =
            """
            {
                "$schema": "https://json-schema.org/draft/2020-12/schema",
                "title": "JSON Schema for a Person entity coming back from a 3rd party API (e.g. a storage format in a database)",
                "type": "object",
                "unevaluatedProperties": false,
                "required": [ "name" ],
                "properties": {
                    "name": { "$ref": "#/$defs/PersonName" },
                    "age": { "$ref": "#/$defs/AgeInYears" },
                    "competedInYears": { "$ref": "#/$defs/YearArray" }
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
                    "YearArray": {
                        "type": "array",
                        "items": { "$ref": "#/$defs/Year" }
                    },
                    "Year": {
                        "type": "number",
                        "format": "int32"
                    },
                    "AgeInYears": {
                        "type": "number",
                        "minimum": 0,
                        "maximum": 130
                    }
                }
            }            
            """;

        [Fact]
        public static async Task GenerateCode_Emits()
        {
            TestJsonSchemaCodeGenerator generator = new("./someFakePath");
            await generator.GenerateCode("person.json", ExampleSchema);
        }
    }
}
