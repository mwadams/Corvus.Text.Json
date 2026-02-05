// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Json;

namespace TestUtilities.JsonSchemaTestSuite;

/// <summary>
/// Represents the schema for the json-schema-test-suite.
/// </summary>
[JsonSchemaTypeGenerator("./test-schema.json")]
public readonly partial struct TestFileModel;
