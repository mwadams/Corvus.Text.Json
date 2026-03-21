using System.Reflection;
using System.Text.Json;
using Corvus.Json;

namespace Corvus.Text.Json.Playground.Services;

/// <summary>
/// Loads JSON Schema metaschema documents from embedded resources into a document resolver.
/// This is WASM-safe (no file I/O) — all metaschemas are embedded in the assembly.
/// </summary>
internal static class Metaschema
{
    internal static IDocumentResolver AddMetaschema(this IDocumentResolver documentResolver)
    {
        Assembly assembly = typeof(Metaschema).Assembly;

        documentResolver.AddDocument(
            "http://json-schema.org/draft-04/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft4.schema.json")));

        documentResolver.AddDocument(
            "http://json-schema.org/draft-06/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft6.schema.json")));

        documentResolver.AddDocument(
            "http://json-schema.org/draft-07/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft7.schema.json")));

        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.schema.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/applicator",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.applicator.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/content",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.content.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/core",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.core.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/format",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.format.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/hyper-schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.hyper-schema.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/meta-data",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.meta-data.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2019-09/meta/validation",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2019-09.meta.validation.json")));

        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.schema.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/applicator",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.applicator.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/content",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.content.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/core",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.core.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/format-annotation",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.format-annotation.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/format-assertion",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.format-assertion.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/hyper-schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.hyper-schema.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/meta-data",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.meta-data.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/unevaluated",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.unevaluated.json")));
        documentResolver.AddDocument(
            "https://json-schema.org/draft/2020-12/meta/validation",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.draft2020-12.meta.validation.json")));

        documentResolver.AddDocument(
            "https://corvus-oss.org/json-schema/2020-12/schema",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.corvus.schema.json")));
        documentResolver.AddDocument(
            "https://corvus-oss.org/json-schema/2020-12/meta/corvus-extensions",
            JsonDocument.Parse(ReadResource(assembly, "metaschema.corvus.meta.corvus-extensions.json")));

        return documentResolver;
    }

    private static string ReadResource(Assembly assembly, string name)
    {
        using Stream? resourceStream = assembly.GetManifestResourceStream(name);
        if (resourceStream is null)
        {
            throw new InvalidOperationException($"Embedded resource '{name}' not found. Available: {string.Join(", ", assembly.GetManifestResourceNames())}");
        }

        using var reader = new StreamReader(resourceStream);
        return reader.ReadToEnd();
    }
}
