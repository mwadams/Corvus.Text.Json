// <copyright file="ValidatorBenchmarks.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using BenchmarkDotNet.Attributes;

namespace Corvus.Text.Json.Validator.Benchmarks;

public abstract class ValidatorBenchmarksBase
{
    protected static readonly Dictionary<string, string> ValidJsonBySchema = new()
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

    protected static readonly Dictionary<string, string> InvalidJsonBySchema = new()
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

    protected Text.Json.Validator.JsonSchema v5Schema;
    protected Corvus.Json.Validator.JsonSchema v4Schema;

    [Params("Person", "ProductCatalog")]
    public string Schema { get; set; } = null!;

    protected void SetupSchemas()
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
    }
}

[MemoryDiagnoser]
public class ValidDocumentBenchmarks : ValidatorBenchmarksBase
{
    private System.Text.Json.JsonElement v4Element;
    private string json = null!;

    [GlobalSetup]
    public void Setup()
    {
        this.SetupSchemas();
        this.json = ValidJsonBySchema[this.Schema];
        this.v4Element = System.Text.Json.JsonDocument.Parse(this.json).RootElement;
    }

    [Benchmark(Baseline = true)]
    public bool V4() => this.v4Schema.Validate(this.v4Element).IsValid;

    [Benchmark]
    public bool V5() => this.v5Schema.Validate(this.json);
}

[MemoryDiagnoser]
public class InvalidDocumentBenchmarks : ValidatorBenchmarksBase
{
    private System.Text.Json.JsonElement v4Element;
    private string json = null!;

    [GlobalSetup]
    public void Setup()
    {
        this.SetupSchemas();
        this.json = InvalidJsonBySchema[this.Schema];
        this.v4Element = System.Text.Json.JsonDocument.Parse(this.json).RootElement;
    }

    [Benchmark(Baseline = true)]
    public bool V4() => this.v4Schema.Validate(this.v4Element).IsValid;

    [Benchmark]
    public bool V5() => this.v5Schema.Validate(this.json);
}
