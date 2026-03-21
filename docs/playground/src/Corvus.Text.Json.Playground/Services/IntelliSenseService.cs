using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;

namespace Corvus.Text.Json.Playground.Services;

/// <summary>
/// Provides Roslyn-backed IntelliSense (completions) for the user code editor.
/// Maintains an AdhocWorkspace with a Document that includes global usings,
/// generated code, and user code — then delegates to Roslyn's CompletionService.
/// </summary>
public class IntelliSenseService
{
    private static readonly MefHostServices HostServices = MefHostServices.Create(
        MefHostServices.DefaultAssemblies.Concat(
        [
            Assembly.Load("Microsoft.CodeAnalysis.Features"),
            Assembly.Load("Microsoft.CodeAnalysis.CSharp.Features"),
        ]).Distinct().ToList());

    private readonly WorkspaceService workspaceService;
    private AdhocWorkspace? workspace;
    private ProjectId? projectId;
    private DocumentId? userDocId;
    private IReadOnlyCollection<Corvus.Json.CodeGeneration.GeneratedCodeFile>? generatedFiles;

    // Track the prefix length (global usings + generated code) so we can map
    // the user's cursor position to the correct offset in the combined document.
    private int prefixLength;

    public IntelliSenseService(WorkspaceService workspaceService)
    {
        this.workspaceService = workspaceService;
    }

    /// <summary>
    /// Update the workspace with newly generated code files.
    /// Called after each successful code generation.
    /// </summary>
    public void UpdateGeneratedCode(IReadOnlyCollection<Corvus.Json.CodeGeneration.GeneratedCodeFile> files)
    {
        this.generatedFiles = files;
        this.workspace?.Dispose();
        this.workspace = null;
        this.projectId = null;
        this.userDocId = null;
    }

    /// <summary>
    /// Get completion items at the given position in the user code.
    /// </summary>
    private const int MaxCompletionItems = 100;

    public async Task<IReadOnlyList<CompletionItemInfo>> GetCompletionsAsync(
        string userCode,
        int lineNumber,
        int column)
    {
        try
        {
            await this.workspaceService.EnsureInitializedAsync();
            Document document = this.EnsureDocument(userCode);

            CompletionService? completionService = CompletionService.GetService(document);
            if (completionService is null)
            {
                return [];
            }

            SourceText sourceText = await document.GetTextAsync();
            int userCodeStartLine = this.GetUserCodeStartLine(sourceText);

            // Map the user's editor line/column to absolute position in the document
            int absoluteLine = userCodeStartLine + lineNumber - 1;
            if (absoluteLine < 0 || absoluteLine >= sourceText.Lines.Count)
            {
                return [];
            }

            int position = sourceText.Lines[absoluteLine].Start + column - 1;
            if (position < 0 || position > sourceText.Length)
            {
                return [];
            }

            CompletionList? completions = await completionService.GetCompletionsAsync(
                document,
                position);

            if (completions is null)
            {
                return [];
            }

            return completions.ItemsList
                .Take(MaxCompletionItems)
                .Select(item => new CompletionItemInfo(
                    item.DisplayText,
                    item.InlineDescription ?? string.Empty,
                    item.SortText,
                    item.FilterText,
                    MapKind(item.Tags)))
                .ToList();
        }
        catch (Exception)
        {
            return [];
        }
    }

    private Document EnsureDocument(string userCode)
    {
        if (this.workspace is null || this.projectId is null || this.userDocId is null)
        {
            this.BuildWorkspace(userCode);
        }
        else
        {
            // Update just the user code document text
            Solution solution = this.workspace.CurrentSolution;
            string userSource = WorkspaceService.GlobalUsings + "\n" + userCode;
            SourceText newText = SourceText.From(userSource);
            solution = solution.WithDocumentText(this.userDocId, newText);
            this.workspace.TryApplyChanges(solution);
        }

        return this.workspace!.CurrentSolution.GetDocument(this.userDocId!)!;
    }

    private void BuildWorkspace(string userCode)
    {
        this.workspace?.Dispose();

        this.workspace = new AdhocWorkspace(HostServices);

        this.projectId = ProjectId.CreateNewId();
        var projectInfo = ProjectInfo.Create(
            this.projectId,
            VersionStamp.Default,
            "PlaygroundProject",
            "PlaygroundProject",
            LanguageNames.CSharp,
            parseOptions: new CSharpParseOptions(LanguageVersion.Latest)
                .WithPreprocessorSymbols("NET", "NET10_0", "NET10_0_OR_GREATER",
                    "NET9_0_OR_GREATER", "NET8_0_OR_GREATER", "NET7_0_OR_GREATER"),
            compilationOptions: new CSharpCompilationOptions(OutputKind.ConsoleApplication),
            metadataReferences: this.workspaceService.References);

        Solution solution = this.workspace.CurrentSolution.AddProject(projectInfo);

        // Add each generated file as a separate document
        if (this.generatedFiles is not null)
        {
            int i = 0;
            foreach (var file in this.generatedFiles)
            {
                var docId = DocumentId.CreateNewId(this.projectId);
                solution = solution.AddDocument(
                    docId,
                    $"Generated_{i}.cs",
                    SourceText.From(file.FileContent));
                i++;
            }
        }

        // Add user code as its own document (with global usings prepended)
        this.userDocId = DocumentId.CreateNewId(this.projectId);
        string userSource = WorkspaceService.GlobalUsings + "\n" + userCode;

        // Track the prefix (global usings) so we can map cursor positions
        this.prefixLength = WorkspaceService.GlobalUsings.Length + 1; // +1 for newline

        solution = solution.AddDocument(
            this.userDocId,
            "Program.cs",
            SourceText.From(userSource));

        this.workspace.TryApplyChanges(solution);
    }

    private int GetUserCodeStartLine(SourceText sourceText)
    {
        // Find which line the user code starts at (after prefix)
        if (this.prefixLength <= 0)
        {
            return 0;
        }

        for (int i = 0; i < sourceText.Lines.Count; i++)
        {
            if (sourceText.Lines[i].Start >= this.prefixLength)
            {
                return i;
            }
        }

        return sourceText.Lines.Count;
    }

    private static string MapKind(System.Collections.Immutable.ImmutableArray<string> tags)
    {
        // Map Roslyn tags to Monaco CompletionItemKind names
        if (tags.IsDefaultOrEmpty)
        {
            return "Text";
        }

        string first = tags[0];
        return first switch
        {
            "Class" or "Structure" or "Struct" => "Class",
            "Interface" => "Interface",
            "Enum" => "Enum",
            "EnumMember" => "EnumMember",
            "Method" or "ExtensionMethod" => "Method",
            "Property" => "Property",
            "Field" => "Field",
            "Event" => "Event",
            "Local" or "Parameter" => "Variable",
            "Namespace" => "Module",
            "Keyword" => "Keyword",
            "Snippet" => "Snippet",
            "Constant" => "Constant",
            "Delegate" => "Function",
            "TypeParameter" => "TypeParameter",
            _ => "Text",
        };
    }
}

/// <summary>
/// A completion item to be sent to the Monaco editor.
/// </summary>
public record CompletionItemInfo(
    string Label,
    string Detail,
    string SortText,
    string FilterText,
    string Kind);
