// <copyright file="ValidatorBenchmarks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using BenchmarkDotNet.Attributes;

namespace Corvus.Text.Json.Validator.Benchmarks;

[MemoryDiagnoser]
public class ValidatorBenchmarks
{
    private static readonly Dictionary<string, string> ValidJsonBySchema = new()
    {
        ["Person"] =
            """
            {
              "firstName": "Alice",
              "lastName": "Smith",
              "age": 30,
              "email": "alice@example.com",
              "address": {
                "street": "123 Main St",
                "city": "Springfield",
                "state": "IL",
                "zipCode": "62704"
              },
              "phoneNumbers": [
                { "type": "home", "number": "+1-555-1234" },
                { "type": "mobile", "number": "+1-555-5678" }
              ]
            }
            """,
        ["ProductCatalog"] =
            """
            {
              "catalogId": "550e8400-e29b-41d4-a716-446655440000",
              "catalogName": "Summer 2024",
              "lastUpdated": "2024-06-15T10:30:00Z",
              "products": [
                {
                  "sku": "AB-123456",
                  "name": "Widget",
                  "description": "A fine widget",
                  "price": 19.99,
                  "currency": "USD",
                  "inStock": true,
                  "categories": ["electronics", "gadgets"],
                  "dimensions": { "width": 10.0, "height": 5.0, "depth": 2.0, "unit": "cm" }
                },
                {
                  "sku": "CD-654321",
                  "name": "Gadget",
                  "price": 49.99,
                  "currency": "EUR",
                  "inStock": false,
                  "categories": ["electronics"]
                }
              ]
            }
            """,
    };

    private static readonly Dictionary<string, string> InvalidJsonBySchema = new()
    {
        ["Person"] =
            """
            {
              "firstName": "Alice",
              "lastName": "Smith",
              "age": -5,
              "email": "not-an-email"
            }
            """,
        ["ProductCatalog"] =
            """
            {
              "catalogId": "not-a-uuid",
              "products": [
                {
                  "sku": "bad-sku",
                  "name": "",
                  "price": -1
                }
              ]
            }
            """,
    };

    private Text.Json.Validator.JsonSchema v5Schema;
    private Corvus.Json.Validator.JsonSchema v4Schema;
    private System.Text.Json.JsonElement v4ValidElement;
    private System.Text.Json.JsonElement v4InvalidElement;
    private string validJson = null!;
    private string invalidJson = null!;

    [Params("Person", "ProductCatalog")]
    public string Schema { get; set; } = null!;

    [GlobalSetup]
    public void Setup()
    {
        string schemaFile = this.Schema switch
        {
            "Person" => "person.json",
            "ProductCatalog" => "product-catalog.json",
            _ => throw new InvalidOperationException($"Unknown schema: {this.Schema}"),
        };

        string schemaPath = Path.Combine(AppContext.BaseDirectory, "Schemas", schemaFile);

        this.v5Schema = Text.Json.Validator.JsonSchema.FromFile(schemaPath);
        this.v4Schema = Corvus.Json.Validator.JsonSchema.FromFile(schemaPath);

        this.validJson = ValidJsonBySchema[this.Schema];
        this.invalidJson = InvalidJsonBySchema[this.Schema];

        this.v4ValidElement = System.Text.Json.JsonDocument.Parse(this.validJson).RootElement;
        this.v4InvalidElement = System.Text.Json.JsonDocument.Parse(this.invalidJson).RootElement;
    }

    [Benchmark(Baseline = true, Description = "V4 Valid")]
    public bool V4_Valid() => this.v4Schema.Validate(this.v4ValidElement).IsValid;

    [Benchmark(Description = "V5 Valid")]
    public bool V5_Valid() => this.v5Schema.Validate(this.validJson);

    [Benchmark(Description = "V4 Invalid")]
    public bool V4_Invalid() => this.v4Schema.Validate(this.v4InvalidElement).IsValid;

    [Benchmark(Description = "V5 Invalid")]
    public bool V5_Invalid() => this.v5Schema.Validate(this.invalidJson);
}
