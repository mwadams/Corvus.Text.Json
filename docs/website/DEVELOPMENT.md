# Website Development Guide

This document explains how the Corvus.Text.Json documentation website is built, how to make changes, and how the build pipeline works.

## Prerequisites

- .NET 10+ SDK
- Node.js (for SCSS compilation and search index)
- Vellum SSG (installed automatically by `build.ps1`)

Install Node dependencies once:

```powershell
cd docs/website
npm install
```

## Quick Start

### Full build (from scratch)

```powershell
cd docs/website
./build.ps1
```

This runs all 9 pipeline steps (see [Build Pipeline](#build-pipeline) below) and produces a complete site in `.output/`.

### Preview with local server

```powershell
./preview.ps1
```

This runs `build.ps1 -Preview`, which builds everything then starts a local server.

### Incremental rebuilds (during development)

For day-to-day iteration you usually don't need to re-run the full pipeline. Run only the steps affected by your change:

| What you changed | What to re-run |
|---|---|
| SCSS styles | [Step 7](#step-7-compile-scss) only |
| JavaScript files | Copy JS to `.output/` (see [Step 7 note](#step-7-compile-scss)) |
| API page layout/templates | [Steps 8](#step-8-generate-per-type-api-html-pages) |
| XmlDocToMarkdown tool code | Rebuild tool + [Step 8](#step-8-generate-per-type-api-html-pages) |
| Library source code | [Steps 1, 2, 8](#step-1-build-corvustextjson) |
| Content markdown (non-API) | [Steps 3–6](#step-3-generate-recipe-content) as applicable |
| Recipe source docs | [Steps 3, 6](#step-3-generate-recipe-content) |
| Taxonomy YAML | [Step 6](#step-6-run-vellum) |
| Razor views | [Step 6](#step-6-run-vellum) |

#### Common incremental commands

**Rebuild API docs only** (after changing XmlDocToMarkdown tool or wanting fresh API pages):

```powershell
cd docs/website
$xml = "..\..\src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.xml"
$dll = "..\..\src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.dll"

# Rebuild the tool
dotnet build tools\XmlDocToMarkdown\XmlDocToMarkdown.csproj -c Debug

# Regenerate HTML pages (this also regenerates namespace markdown, taxonomy, and views)
dotnet run --project tools\XmlDocToMarkdown -- `
    --xml $xml --assembly $dll `
    --output content\Api `
    --taxonomy-output taxonomy\api `
    --api-views-dir theme\corvus\views\api `
    --html-output .output\api `
    --site-title "Corvus.Text.Json"
```

**Rebuild CSS only** (after SCSS changes):

```powershell
npx sass theme\corvus\assets\css\scss\main.scss .output\main.css --style=compressed --no-source-map
```

**Copy JS only** (after JavaScript changes):

```powershell
Copy-Item theme\corvus\assets\js\*.js .output\
```

**Rebuild the library** (after source code changes — needed before API doc regeneration):

```powershell
dotnet build ..\..\src\Corvus.Text.Json\Corvus.Text.Json.csproj -c Release -f net10.0
```

## Build Pipeline

`build.ps1` runs these steps in order:

### Step 1: Build Corvus.Text.Json

```powershell
dotnet build src/Corvus.Text.Json/Corvus.Text.Json.csproj -c Release -f net10.0
```

Compiles the library, generating:
- `bin/Release/net10.0/Corvus.Text.Json.xml` — XML documentation comments
- `bin/Release/net10.0/Corvus.Text.Json.dll` — assembly (with embedded PDB + source via SourceLink)

The library has `<EmbedAllSources>true</EmbedAllSources>` and `Microsoft.SourceLink.GitHub`, so the PDB contains full source code for declaration-line resolution.

### Step 2: Generate API namespace markdown & taxonomy

Runs `XmlDocToMarkdown` in namespace-generation mode (no `--html-output`):
- Parses XML doc comments and assembly metadata
- Generates namespace-level markdown in `content/Api/`
- Generates taxonomy YAML in `taxonomy/api/`
- Generates Razor views in `theme/corvus/views/api/`

### Step 3: Generate recipe content

Scans `docs/ExampleRecipes/` for numbered recipe directories (e.g. `01-AllOf/`). For each:
- Extracts the README.md content
- Generates content markdown with Vellum frontmatter in `content/Examples/`
- Generates taxonomy YAML in `taxonomy/examples/`
- Generates Razor views in `theme/corvus/views/examples/`
- Extracts FAQ sections as JSON-LD structured data
- Builds keyword lists from JSON Schema terms and API method names

### Step 4: Generate docs content

Processes selected markdown files from `docs/` (the list is hardcoded in `build.ps1`):
- Strips headings and TOC sections
- Generates content, taxonomy, and views for each doc page
- Applies custom navigation titles and card descriptions

### Step 5: Install Vellum

Downloads and installs Vellum SSG if not already present in `.endjin/`.

### Step 6: Run Vellum

Renders the site from content + taxonomy + views → `.output/`. Then cleans spurious copies of source directories that Vellum copies into `.output/`.

### Step 7: Compile SCSS

```powershell
npx sass theme/corvus/assets/css/scss/main.scss .output/main.css --style=compressed --no-source-map
```

JavaScript files are copied from `theme/corvus/assets/js/` to `.output/` as part of the Vellum asset copy in Step 6.

### Step 8: Generate per-type API HTML pages

Runs `XmlDocToMarkdown` again with `--html-output` to generate standalone per-type HTML pages:
- One HTML page per type (class, struct, interface, enum, delegate)
- Includes source links resolved from PDB metadata (SourceLink + TypeDefinitionDocuments + EmbeddedSource)
- Per-overload source links for methods and indexers with full signature matching
- Sidebar navigation tree
- Search integration

### Step 9: Build search index

```powershell
node tools/build-search-index.js --output .output/search-index.json
```

Builds a Lunr search index from the generated API markdown files.

## Directory Structure

```
docs/website/
├── build.ps1              # Full build pipeline script
├── preview.ps1            # Runs build.ps1 -Preview
├── site.yml               # Vellum site configuration
├── package.json           # Node dependencies (sass, vellum, js-yaml)
│
├── content/               # Markdown content (input to Vellum)
│   ├── Api/               # Generated — namespace index pages + search-index.json
│   ├── Docs/              # Generated — from docs/*.md
│   ├── Examples/          # Generated — from docs/ExampleRecipes/
│   ├── GettingStarted/    # Hand-authored getting started guide
│   └── Home/              # Hand-authored homepage content
│
├── taxonomy/              # Vellum taxonomy (navigation, metadata, content blocks)
│   ├── api/               # Generated — per-namespace and per-type entries
│   ├── docs/              # Generated — per-doc entries
│   └── examples/          # Generated — per-recipe entries
│
├── theme/corvus/          # Site theme
│   ├── assets/
│   │   ├── css/scss/      # SCSS source (main.scss entry point)
│   │   └── js/            # JavaScript (search, sidebar, mobile nav)
│   └── views/             # Razor views (.cshtml templates)
│       ├── Shared/        # Layout, partials (_Layout.cshtml, _Sidebar.cshtml)
│       ├── api/           # Generated — per-namespace views
│       ├── docs/          # Generated — per-doc views
│       └── examples/      # Generated — per-recipe views
│
├── tools/
│   ├── XmlDocToMarkdown/  # .NET tool: XML docs + assembly → markdown + HTML
│   │   ├── Program.cs             # CLI entry point & argument parsing
│   │   ├── XmlDocParser.cs        # Parses XML documentation comments
│   │   ├── AssemblyInspector.cs   # Reads assembly metadata via reflection
│   │   ├── MarkdownGenerator.cs   # Generates markdown for namespace pages + member details
│   │   ├── HtmlPageGenerator.cs   # Generates standalone per-type HTML pages
│   │   ├── SourceLinkResolver.cs  # PDB-based source link resolution (3 features)
│   │   ├── XmlDocIdTypeProvider.cs # PE signature → XmlDocKey format conversion
│   │   ├── SidebarBuilder.cs      # Hierarchical sidebar navigation
│   │   ├── TaxonomyGenerator.cs   # Vellum taxonomy YAML generation
│   │   ├── ViewGenerator.cs       # Razor view generation
│   │   ├── ApiViewGenerator.cs    # API-specific view generation
│   │   └── SearchIndexGenerator.cs # Search index JSON generation
│   ├── build-search-index.js       # Node script for Lunr search index
│   └── PdbDiag.csx                 # Diagnostic script for PDB inspection
│
├── .endjin/               # Vellum SSG binary (gitignored)
├── .output/               # Build output (gitignored)
└── node_modules/          # Node dependencies (gitignored)
```

## XmlDocToMarkdown Tool

The core tool that generates API documentation. It has two operating modes controlled by CLI arguments:

### Mode 1: Namespace generation (no `--html-output`)

Generates namespace-level markdown, taxonomy YAML, and Razor views. Run in Step 2 of the pipeline.

### Mode 2: Full generation (with `--html-output`)

Does everything in Mode 1 plus generates standalone per-type HTML pages. Run in Step 8.

### Key CLI arguments

| Argument | Purpose |
|---|---|
| `--xml <path>` | Path to XML documentation file |
| `--assembly <path>` | Path to compiled assembly DLL |
| `--output <dir>` | Output directory for namespace markdown |
| `--taxonomy-output <dir>` | Output directory for taxonomy YAML |
| `--api-views-dir <dir>` | Output directory for Razor views |
| `--html-output <dir>` | Output directory for per-type HTML pages (enables full mode) |
| `--site-title <text>` | Site title for HTML pages |
| `--repo-url <url>` | Override repository URL for source links (auto-detected from git) |

### Source Link Resolution

`SourceLinkResolver` uses three portable PDB features to resolve source code links:

1. **SourceLink JSON** (GUID `CC110556`) — maps local build paths to GitHub URLs
2. **TypeDefinitionDocuments** (GUID `932E74BC`) — maps interfaces, enums, and delegates (which have no method bodies) to their source documents
3. **EmbeddedSource** (GUID `0E8A571B`) — contains the actual source code, enabling scanning for precise declaration line numbers

The resolver produces GitHub `/blob/main/` URLs with line anchors (e.g. `#L42`).

For overloaded members, full parameter signatures are used to disambiguate (via `XmlDocIdTypeProvider` which decodes PE method signatures into XmlDocKey format).

## Making Changes

### Adding a new content section

1. Create markdown files in `content/YourSection/`
2. Create taxonomy YAML in `taxonomy/yoursection/`
3. Create Razor views in `theme/corvus/views/yoursection/`
4. Add navigation entries to the taxonomy index
5. Run Steps 6–7 to rebuild

### Modifying API page layout

1. Edit files in `tools/XmlDocToMarkdown/` (usually `HtmlPageGenerator.cs` or `MarkdownGenerator.cs`)
2. Rebuild the tool: `dotnet build tools\XmlDocToMarkdown\XmlDocToMarkdown.csproj -c Debug`
3. Regenerate API pages (the incremental command from [above](#common-incremental-commands))

### Changing styles

1. Edit SCSS files in `theme/corvus/assets/css/scss/`
2. The entry point is `main.scss`; API-specific styles are in `pages/_api.scss`
3. Recompile: `npx sass theme\corvus\assets\css\scss\main.scss .output\main.css --style=compressed --no-source-map`
4. Refresh browser

### Adding a new recipe

1. Create a numbered directory in `docs/ExampleRecipes/` (e.g. `10-MyRecipe/`)
2. Add a `README.md` with a `# JSON Schema Patterns in .NET - My Recipe Title` heading
3. Run `build.ps1` or Steps 3 + 6 + 7

### Modifying source link resolution

1. Edit `tools/XmlDocToMarkdown/SourceLinkResolver.cs`
2. Use `tools/PdbDiag.csx` to inspect PDB metadata during debugging
3. Rebuild and regenerate API pages
