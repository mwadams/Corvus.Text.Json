// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json;

namespace Benchmark.CorvusTextJson;

[JsonSchemaTypeGenerator("../person-schema.json#/$defs/PersonArray")]
public readonly partial struct PersonArray;
