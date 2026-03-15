using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Corvus.Text.Json.Validator;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Corvus.Text.Json.CodeGenerator;

/// <summary>
/// Spectre.Console.Cli command for code generation.
/// </summary>
internal class ValidateDocumentCommand : Command<ValidateDocumentCommand.Settings>
{
    /// <summary>
    /// Settings for the generate command.
    /// </summary>
    public sealed class Settings : CommandSettings
    {
        [Description("The path to the schema file to use.")]
        [CommandArgument(0, "<schemaFile>")]
        [NotNull] // <> => NotNull
        public string? SchemaFile { get; init; }

        [Description("The path to the document file to process.")]
        [CommandArgument(1, "<documentFile>")]
        [NotNull] // <> => NotNull
        public string? DocumentFile { get; init; }
    }


    /// <inheritdoc/>
    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(settings.SchemaFile); // We will never see this exception if the framework is doing its job; it should have blown up inside the CLI command handling
        ArgumentNullException.ThrowIfNullOrEmpty(settings.DocumentFile); // We will never see this exception if the framework is doing its job; it should have blown up inside the CLI command handling

        JsonSchema schema = JsonSchema.FromFile(settings.SchemaFile);

        // Read as bytes so we can parse into a ParsedJsonDocument for line resolution
        byte[] sourceBytes = File.ReadAllBytes(settings.DocumentFile);

        using JsonSchemaResultsCollector collector = JsonSchemaResultsCollector.Create(JsonSchemaResultsLevel.Detailed);
        bool isValid = schema.Validate(new ReadOnlyMemory<byte>(sourceBytes), collector);

        if (isValid)
        {
            AnsiConsole.MarkupLine("[green]Document is valid[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Document is invalid[/]");

            // Parse the document to get line/offset resolution for error locations
            using ParsedJsonDocument<JsonElement> parsedDoc = ParsedJsonDocument<JsonElement>.Parse(new ReadOnlyMemory<byte>(sourceBytes));
            JsonElement rootElement = parsedDoc.RootElement;

            foreach (JsonSchemaResultsCollector.Result result in collector.EnumerateResults())
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    AnsiConsole.MarkupLine("[red]Operation cancelled.[/]");
                    return -1;
                }

                string locationInfo = FormatLocationInfo(settings.DocumentFile, result.DocumentEvaluationLocation, rootElement);
                string matchTag = result.IsMatch ? "[green]pass[/]" : "[red]fail[/]";
                AnsiConsole.MarkupLine(
                    $"{Markup.Escape(locationInfo)}: {matchTag} {Markup.Escape(result.GetMessageText())} ({Markup.Escape(result.GetSchemaEvaluationLocationText())})");
            }
        }

        return 0;
    }

    private static string FormatLocationInfo(string filePath, ReadOnlySpan<byte> documentPointer, in JsonElement rootElement)
    {
        if (documentPointer.Length > 0 &&
            Utf8JsonPointer.TryCreateJsonPointer(documentPointer, out Utf8JsonPointer pointer) &&
            pointer.TryGetLineAndOffset(in rootElement, out int line, out int charOffset, out _))
        {
            return $"{filePath}({line},{charOffset})";
        }

        // Root pointer or unable to resolve — just show the file path
        if (documentPointer.Length == 0)
        {
            return $"{filePath}(1,1)";
        }

        return filePath;
    }
}