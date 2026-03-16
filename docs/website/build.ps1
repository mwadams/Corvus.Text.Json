<#
.SYNOPSIS
    Builds the Corvus.Text.Json documentation website.
.DESCRIPTION
    End-to-end build pipeline:
      1. Build Corvus.Text.Json (generates XML doc + assembly)
      2. Generate API namespace markdown & taxonomy from XML docs
      3. Generate recipe content from ExampleRecipes source docs
      4. Generate docs content from source documentation
      5. Install Vellum SSG (if not present)
      6. Run Vellum to render the core site
      7. Compile SCSS to CSS
      8. Generate standalone per-type API HTML pages
      9. Build Lunr search index
.PARAMETER Preview
    Launches a local preview server after building.
.PARAMETER Watch
    Monitors for file changes and auto-regenerates.
#>
[CmdletBinding()]
param (
    [Parameter()]
    [switch] $Preview,

    [Parameter()]
    [switch] $Watch
)

$ErrorActionPreference = 'Stop'
$InformationPreference = 'Continue'

$here = Split-Path -Parent $PSCommandPath
$repoRoot = Resolve-Path (Join-Path $here "..\..")
$outputDir = Join-Path $here ".output"

# Paths used by multiple steps
$xmlPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.xml"
$assemblyPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.dll"
$ns20AssemblyPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\netstandard2.0\Corvus.Text.Json.dll"
$apiContentDir = Join-Path $here "content\Api"
$apiTaxonomyDir = Join-Path $here "taxonomy\api"
$toolProject = Join-Path $here "tools\XmlDocToMarkdown"

# ── Helper: PascalCase to kebab-case ────────────────────────────────────────
function ConvertTo-KebabCase([string]$text) {
    $result = $text -creplace '([a-z0-9])([A-Z])', '$1-$2'
    $result = $result -creplace '([A-Z]+)([A-Z][a-z])', '$1-$2'
    return $result.ToLower()
}

# ── Step 1: Build Corvus.Text.Json ──────────────────────────────────────────
Write-Host "`n[1/9] Building Corvus.Text.Json..." -ForegroundColor Cyan
$mainProject = Join-Path $repoRoot "src\Corvus.Text.Json\Corvus.Text.Json.csproj"
& dotnet build $mainProject -c Release -f net10.0 /p:GenerateDocumentationFile=true --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json (net10.0)" }
& dotnet build $mainProject -c Release -f netstandard2.0 --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json (netstandard2.0)" }
Write-Host "  XML documentation generated." -ForegroundColor Green

# ── Step 2: Generate API namespace markdown & taxonomy ──────────────────────
Write-Host "`n[2/9] Generating API namespace pages & taxonomy..." -ForegroundColor Cyan
$apiViewsDir = Join-Path $here "theme\corvus\views\api"
$nsDescriptionsDir = Join-Path $here "content\Api\namespaces"
& dotnet run --project $toolProject -c Release -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --ns20-assembly $ns20AssemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir `
    --api-views-dir $apiViewsDir `
    --ns-descriptions $nsDescriptionsDir
if ($LASTEXITCODE -ne 0) { throw "API namespace generation failed" }
Write-Host "  Namespace markdown, taxonomy & API views generated." -ForegroundColor Green

# ── Step 3: Generate recipe content from ExampleRecipes ─────────────────────
Write-Host "`n[3/9] Generating recipe content from ExampleRecipes..." -ForegroundColor Cyan

$recipesSourceDir = Join-Path $repoRoot "docs\ExampleRecipes"
$recipesContentDir = Join-Path $here "content\Examples"
$recipesTaxonomyDir = Join-Path $here "taxonomy\examples"
$recipesViewDir = Join-Path $here "theme\corvus\views\examples"

# Clean old generated recipe files (preserve Overview.md and index.*)
Get-ChildItem $recipesContentDir -Filter "*.md" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "Overview.md" } | Remove-Item -Force
Get-ChildItem $recipesTaxonomyDir -Filter "*.yml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.yml" } | Remove-Item -Force
Get-ChildItem $recipesViewDir -Filter "*.cshtml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.cshtml" } | Remove-Item -Force

# Shared Razor view template for all recipe pages (dynamic sidebar from Vellum nav)
$recipeViewTemplate = @'
@model SiteViewModel
@{
    Layout = "../Shared/_Layout.cshtml";
}
<div class="layout-docs container">
    @await Html.PartialAsync("_Sidebar").ConfigureAwait(false)
    <main id="main-content" class="layout-docs__main">
        <div class="doc__content">
            <h1>@Model.PageContext.Title</h1>
            @if (Model.PageContext.MetaData.Keywords.Any())
            {
                <div class="card__tags" style="margin-bottom:1.5rem">
                    @foreach (var keyword in Model.PageContext.MetaData.Keywords)
                    {
                        <span class="card__tag">@keyword</span>
                    }
                </div>
            }
            @foreach (var contentFragment in Model.PageContext.GetAllMarkdownContent())
            {
                @Html.Raw(contentFragment.Body)
            }
        </div>
    </main>
</div>
'@

$recipeDirs = Get-ChildItem $recipesSourceDir -Directory | Sort-Object Name
$recipeCount = 0

foreach ($dir in $recipeDirs) {
    if ($dir.Name -notmatch '^(\d+)-(.+)$') { continue }
    $number = $Matches[1]
    $pascalName = $Matches[2]
    $slug = ConvertTo-KebabCase $pascalName

    $readmePath = Join-Path $dir.FullName "README.md"
    if (!(Test-Path $readmePath)) { continue }

    $raw = Get-Content $readmePath -Raw -Encoding utf8

    # Extract title from "# JSON Schema Patterns in .NET - <title>"
    if ($raw -match '^# JSON Schema Patterns in \.NET\s*[-–—]\s*(.+?)[\r\n]') {
        $title = $Matches[1].Trim()
    } else {
        $title = ($pascalName -creplace '([a-z])([A-Z])', '$1 $2')
    }

    # Strip the # heading line and any leading blank lines after it
    $body = ($raw -replace '^#[^\n]+\n\s*', '').TrimStart()

    # Extract first sentence as description
    if ($body -match '^(.+?\.)\s') {
        $description = $Matches[1] -replace '"', '\"'
    } else {
        $description = $title
    }

    # Extract FAQ Q&A pairs from the FAQ section
    $faqQuestions = @()
    $faqPairs = @()
    if ($raw -match '(?s)## Frequently Asked Questions(.+?)(?=\n## |\z)') {
        $faqSection = $Matches[1]
        # Split on ### headings to get Q&A pairs
        $parts = $faqSection -split '(?=### )'
        foreach ($part in $parts) {
            $part = $part.Trim()
            if ($part -match '^###\s+(.+?)[\r\n]+(.+)') {
                $question = $Matches[1].Trim()
                $answer = ($Matches[2].Trim() -replace '[\r\n]+', ' ').Trim()
                $faqQuestions += ($question -replace '`', '')
                # Escape for JSON
                $qJson = $question -replace '\\', '\\' -replace '"', '\"'
                $aJson = $answer -replace '\\', '\\' -replace '"', '\"' -replace '`', ''
                $faqPairs += @{ q = $qJson; a = $aJson }
            }
        }
    }

    # Build Keywords array: title words + JSON Schema keywords + Corvus API terms
    # Start with the recipe title split into words (skip short ones)
    $titleWords = $title -split '\s+' | Where-Object { $_.Length -ge 3 } |
        ForEach-Object { $_.ToLower() -replace '[^a-z0-9]', '' } | Where-Object { $_ -and $_ -notin @('and', 'the', 'for', 'with', 'from') }

    # Extract JSON Schema keywords used in the content
    $schemaKeywords = [regex]::Matches($raw, '"(type|properties|required|additionalProperties|unevaluatedProperties|format|enum|const|oneOf|anyOf|allOf|if|then|else|prefixItems|items|unevaluatedItems|patternProperties|\$ref|\$defs|minimum|maximum|minLength|maxLength|pattern|not|contains|minItems|maxItems|uniqueItems)"') |
        ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique

    # Extract Corvus API method/type names from backtick spans
    $apiMethods = [regex]::Matches($raw, '`(IsUndefined|IsNull|IsValid|TryGetValue|ValueEquals|EvaluateSchema|GetRawText|ToString|Parse|From|Match|SetProperty|RemoveProperty|TryGetProperty|AddProperty|CreateBuilder|BuildDocument|Build|Clone|AsArray|AsObject|RootElement|TryGetNumericValues|CreateTuple|ConstInstance)\b') |
        ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique

    $keywordItems = @('recipe', 'JSON Schema', 'C#') + $titleWords + $schemaKeywords + $apiMethods |
        Select-Object -Unique
    $keywordsYaml = ($keywordItems | ForEach-Object { "`"$($_ -replace '"', '\"')`"" }) -join ', '

    # Build FAQPage JSON-LD structured data
    $faqJsonLd = ''
    if ($faqPairs.Count -gt 0) {
        $mainEntity = ($faqPairs | ForEach-Object {
            "    {`n      `"@type`": `"Question`",`n      `"name`": `"$($_.q)`",`n      `"acceptedAnswer`": {`n        `"@type`": `"Answer`",`n        `"text`": `"$($_.a)`"`n      }`n    }"
        }) -join ",`n"
        $faqJsonLd = @"

<script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "FAQPage",
  "mainEntity": [
$mainEntity
  ]
}
</script>
"@
    }

    # 1) Content markdown with Vellum frontmatter + FAQ JSON-LD
    $contentPath = Join-Path $recipesContentDir "$pascalName.md"
    $frontmatter = "---`nContentType: `"application/vnd.endjin.ssg.content+md`"`nPublicationStatus: Published`nDate: 2026-03-15T00:00:00.0+00:00`nTitle: `"$title`"`n---`n"
    $contentMd = $frontmatter + $body + $faqJsonLd
    [System.IO.File]::WriteAllText($contentPath, $contentMd, [System.Text.Encoding]::UTF8)

    # 2) Taxonomy YAML
    $rank = $recipeCount + 1
    $taxonomyYml = @"
ContentType: application/vnd.endjin.ssg.page+yaml
Title: "$title"
Navigation:
  Title: $title
  Description: "$description"
  Parent: /examples/index.html
  Url: /examples/$slug.html
  Rank: $rank
  Header:
    Visible: False
    Link: False
  Footer:
    Visible: False
    Link: False
MetaData:
  Title: "$title — Corvus.Text.Json Examples"
  Description: "$description"
  Keywords: [$keywordsYaml]
OpenGraph:
  Title: "$title — Corvus.Text.Json Examples"
  Description: "$description"
  Image:
ContentBlocks:
  - ContentType: application/vnd.endjin.ssg.content+md
    Id: $pascalName
    Spec:
      Path: ../../content/Examples/$pascalName.md
"@
    $taxonomyPath = Join-Path $recipesTaxonomyDir "$slug.yml"
    [System.IO.File]::WriteAllText($taxonomyPath, $taxonomyYml, [System.Text.Encoding]::UTF8)

    # 3) View cshtml (shared template)
    $viewPath = Join-Path $recipesViewDir "$slug.cshtml"
    [System.IO.File]::WriteAllText($viewPath, $recipeViewTemplate, [System.Text.Encoding]::UTF8)

    $recipeCount++
    Write-Host "  $number $title -> $slug" -ForegroundColor Gray
}
Write-Host "  $recipeCount recipe(s) generated." -ForegroundColor Green

# ── Step 4: Generate docs content from source docs ──────────────────────────
Write-Host "`n[4/9] Generating docs content from source documentation..." -ForegroundColor Cyan

$docsSourceDir = Join-Path $repoRoot "docs"
$docsContentDir = Join-Path $here "content\Docs"
$docsTaxonomyDir = Join-Path $here "taxonomy\docs"
$docsViewDir = Join-Path $here "theme\corvus\views\docs"

# Docs to include (order matters — defines sidebar Rank)
$docsToInclude = @(
    'ParsedJsonDocument.md',
    'JsonDocumentBuilder.md',
    'SourceGenerator.md',
    'CodeGenerator.md',
    'Validator.md',
    'MigratingFromV4ToV5.md',
    'UsingCopilotForMigration.md'
)

# Clean old generated doc files (preserve index.*)
Get-ChildItem $docsContentDir -Filter "*.md" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "Overview.md" } | Remove-Item -Force
Get-ChildItem $docsTaxonomyDir -Filter "*.yml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.yml" } | Remove-Item -Force
Get-ChildItem $docsViewDir -Filter "*.cshtml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.cshtml" } | Remove-Item -Force

# Shared Razor view template for docs (dynamic sidebar with all sections)
$docViewTemplate = @'
@model SiteViewModel
@{
    Layout = "../Shared/_Layout.cshtml";
}
<div class="layout-docs container">
    @await Html.PartialAsync("_Sidebar").ConfigureAwait(false)
    <main id="main-content" class="layout-docs__main">
        <div class="doc__content">
            <h1>@Model.PageContext.Title</h1>
            @foreach (var contentFragment in Model.PageContext.GetAllMarkdownContent())
            {
                @Html.Raw(contentFragment.Body)
            }
        </div>
    </main>
</div>
'@

$docCount = 0
foreach ($docFile in $docsToInclude) {
    $sourcePath = Join-Path $docsSourceDir $docFile
    if (!(Test-Path $sourcePath)) {
        Write-Warning "  Source doc not found: $docFile — skipping"
        continue
    }

    $raw = Get-Content $sourcePath -Raw -Encoding utf8
    $baseName = [System.IO.Path]::GetFileNameWithoutExtension($docFile)
    $slug = ConvertTo-KebabCase $baseName

    # Extract title from # heading
    if ($raw -match '^# (.+?)[\r\n]') {
        $docTitle = $Matches[1].Trim() -replace '`', ''
    } else {
        $docTitle = ($baseName -creplace '([a-z])([A-Z])', '$1 $2')
    }

    # Strip the # heading line
    $docBody = ($raw -replace '^#[^\n]+\n\s*', '').TrimStart()

    # Strip markdown "## Table of Contents" section (the TOC through the next --- or ## heading)
    $docBody = $docBody -replace '(?ms)^## Table of Contents\s*\n(- \[.*?\]\(#.*?\)\s*\n)+\s*---\s*\n?', ''

    # Extract first sentence as description
    if ($docBody -match '^(.+?\.)\s') {
        $docDescription = $Matches[1] -replace '"', '\"'
    } else {
        $docDescription = $docTitle
    }

    # Friendly nav titles and card descriptions (goal-oriented, referencing STJ counterparts)
    $navTitle = switch -Wildcard ($baseName) {
        'ParsedJsonDocument'       { 'Parsing & Reading JSON' }
        'JsonDocumentBuilder'      { 'Building & Mutating JSON' }
        'SourceGenerator'          { 'Source Generator' }
        'CodeGenerator'            { 'CLI Code Generation' }
        'Validator'                { 'Dynamic Schema Validation' }
        'MigratingFromV4ToV5'      { 'Migrating from V4' }
        'UsingCopilotForMigration' { 'Copilot Migration' }
        default {
            $t = $docTitle
            if ($t.Length -gt 30) { $t = $t.Substring(0, 27) + '...' }
            $t
        }
    }

    # Custom card descriptions for key pages (others fall through to first-sentence extraction)
    $customDescription = switch -Wildcard ($baseName) {
        'ParsedJsonDocument'  { 'Parse JSON into read-only, strongly-typed models backed by pooled memory. A high-performance alternative to System.Text.Json''s JsonDocument with generic type support and zero-copy element access.' }
        'JsonDocumentBuilder' { 'Create and modify JSON documents in-place with workspace-managed pooled memory. A builder-pattern alternative to System.Text.Json''s JsonNode, designed for request/response cycles and data pipelines.' }
        'SourceGenerator'     { 'Generate strongly-typed C# from JSON Schema at build time with the Roslyn incremental source generator. Annotate a partial struct, register your schema, and get full IntelliSense immediately.' }
        'CodeGenerator'       { 'Generate strongly-typed C# models from JSON Schema files using the generatejsonschematypes CLI tool. Same output as the source generator, for CI pipelines and pre-generation workflows.' }
        'Validator'           { 'Dynamically load, compile, and validate JSON documents against JSON Schema at runtime using Roslyn. Ideal for schema registries, configuration validation, and user-supplied schemas.' }
        default               { $null }
    }

    if ($customDescription) {
        $docDescription = $customDescription
    }

    # 1) Content markdown
    $contentPath = Join-Path $docsContentDir "$baseName.md"
    $frontmatter = "---`nContentType: `"application/vnd.endjin.ssg.content+md`"`nPublicationStatus: Published`nDate: 2026-03-15T00:00:00.0+00:00`nTitle: `"$($docTitle -replace '"', '\"')`"`n---`n"
    [System.IO.File]::WriteAllText($contentPath, ($frontmatter + $docBody), [System.Text.Encoding]::UTF8)

    # 2) Taxonomy YAML
    $docRank = $docCount + 1
    $docTaxonomyYml = @"
ContentType: application/vnd.endjin.ssg.page+yaml
Title: "$($docTitle -replace '"', '\"')"
Navigation:
  Title: $navTitle
  Description: "$docDescription"
  Parent: /docs/index.html
  Url: /docs/$slug.html
  Rank: $docRank
  Header:
    Visible: False
    Link: False
  Footer:
    Visible: False
    Link: False
MetaData:
  Title: "$($docTitle -replace '"', '\"') — Corvus.Text.Json"
  Description: "$docDescription"
  Keywords: [documentation, Corvus.Text.Json]
OpenGraph:
  Title: "$($docTitle -replace '"', '\"') — Corvus.Text.Json"
  Description: "$docDescription"
  Image:
ContentBlocks:
  - ContentType: application/vnd.endjin.ssg.content+md
    Id: $baseName
    Spec:
      Path: ../../content/Docs/$baseName.md
"@
    $docTaxonomyPath = Join-Path $docsTaxonomyDir "$slug.yml"
    [System.IO.File]::WriteAllText($docTaxonomyPath, $docTaxonomyYml, [System.Text.Encoding]::UTF8)

    # 3) View cshtml
    $docViewPath = Join-Path $docsViewDir "$slug.cshtml"
    [System.IO.File]::WriteAllText($docViewPath, $docViewTemplate, [System.Text.Encoding]::UTF8)

    $docCount++
    Write-Host "  $docTitle -> $slug" -ForegroundColor Gray
}
Write-Host "  $docCount doc page(s) generated." -ForegroundColor Green

# ── Step 5: Install Vellum ──────────────────────────────────────────────────
$vellumVersion = "2.0.9"
$vellumDir = Join-Path $here ".endjin"
$vellumCmd = Join-Path $vellumDir "vellum"

if (!(Test-Path $vellumCmd) -and !(Test-Path "$vellumCmd.exe")) {
    Write-Host "`n[5/9] Installing Vellum $vellumVersion..." -ForegroundColor Cyan
    if (!(Test-Path $vellumDir)) {
        New-Item -ItemType Directory -Path $vellumDir | Out-Null
    }
    & gh release download -R endjin/Endjin.StaticSiteGen $vellumVersion -p "vellum.$vellumVersion.nupkg" -D $vellumDir --clobber
    & dotnet tool install vellum --version $vellumVersion --tool-path $vellumDir --add-source $vellumDir
    if ($LASTEXITCODE -ne 0) { throw "Failed to install Vellum" }
    Write-Host "  Vellum installed." -ForegroundColor Green
} else {
    Write-Host "`n[5/9] Vellum already installed." -ForegroundColor DarkGray
}

# ── Step 6: Run Vellum ──────────────────────────────────────────────────────
Write-Host "`n[6/9] Running Vellum..." -ForegroundColor Cyan

# Prepare output directory
if (Test-Path $outputDir) { Remove-Item $outputDir -Recurse -Force }
$assetsSource = Join-Path $here "theme\corvus\assets"
$assetsDest = Join-Path $outputDir "assets"
Copy-Item -Path $assetsSource -Destination $assetsDest -Recurse -Force

$vellumArgs = @("content", "generate", "-t", (Join-Path $here "site.yml"), "-o", $outputDir)
if ($Preview) { $vellumArgs += "--preview" }
if ($Watch)   { $vellumArgs += "--watch" }
& $vellumCmd $vellumArgs
if ($LASTEXITCODE -ne 0) { throw "Vellum generation failed" }

# Vellum copies the entire working directory into .output alongside the rendered
# pages. Remove the spurious copies so they don't bloat the output or cause
# recursive nesting on repeat runs.
foreach ($dir in @(".output", "node_modules", "tools", "taxonomy", "content", "theme", ".endjin")) {
    $spurious = Join-Path $outputDir $dir
    if (Test-Path $spurious) { Remove-Item $spurious -Recurse -Force }
}
foreach ($file in @("build.ps1", "preview.ps1", "package.json", "package-lock.json", "site.yml", ".gitignore", "DEVELOPMENT.md")) {
    $spurious = Join-Path $outputDir $file
    if (Test-Path $spurious) { Remove-Item $spurious -Force }
}
Write-Host "  Site rendered." -ForegroundColor Green

# ── Step 7: Compile SCSS ────────────────────────────────────────────────────
Write-Host "`n[7/9] Compiling SCSS..." -ForegroundColor Cyan
$scssPath = Join-Path $assetsSource "css\scss\main.scss"
$cssOutputPath = Join-Path $outputDir "main.css"
& npx sass $scssPath $cssOutputPath --style=compressed --no-source-map
if ($LASTEXITCODE -ne 0) { throw "SCSS compilation failed" }
Write-Host "  CSS written to $cssOutputPath" -ForegroundColor Green

# ── Step 8: Generate per-type API HTML pages ────────────────────────────────
Write-Host "`n[8/9] Generating per-type API pages..." -ForegroundColor Cyan
$apiHtmlDir = Join-Path $outputDir "api"
& dotnet run --project $toolProject -c Release --no-build -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --ns20-assembly $ns20AssemblyPath `
    --html-output $apiHtmlDir `
    --site-title "Corvus.Text.Json" `
    --ns-descriptions $nsDescriptionsDir
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Per-type HTML generation failed — namespace summary pages still available."
} else {
    $count = (Get-ChildItem $apiHtmlDir -Filter "*.html" | Where-Object { $_.Name -match '-.*-' }).Count
    Write-Host "  $count per-type API pages generated." -ForegroundColor Green
}

# ── Step 9: Build search index ──────────────────────────────────────────────
Write-Host "`n[9/9] Building search index..." -ForegroundColor Cyan
$searchIndexOutput = Join-Path $outputDir "search-index.json"
& node (Join-Path $here "tools\build-search-index.js") --output $searchIndexOutput
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Search index generation failed — site will build without search."
} else {
    Write-Host "  Search index written." -ForegroundColor Green
}

Write-Host "`nBuild complete! Output: $outputDir" -ForegroundColor Green
