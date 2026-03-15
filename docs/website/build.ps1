<#
.SYNOPSIS
    Builds the Corvus.Text.Json documentation website.
.DESCRIPTION
    End-to-end build pipeline:
      1. Build Corvus.Text.Json (generates XML doc + assembly)
      2. Generate API namespace markdown & taxonomy from XML docs
      3. Generate recipe content from ExampleRecipes source docs
      4. Install Vellum SSG (if not present)
      5. Run Vellum to render the core site
      6. Compile SCSS to CSS
      7. Generate standalone per-type API HTML pages
      8. Build Lunr search index
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
$apiContentDir = Join-Path $here "content\Api"
$apiTaxonomyDir = Join-Path $here "taxonomy\api"
$toolProject = Join-Path $here "tools\XmlDocToMarkdown"

# ── Helper: PascalCase to kebab-case ────────────────────────────────────────
function ConvertTo-KebabCase([string]$text) {
    $result = $text -creplace '([a-z])([A-Z])', '$1-$2'
    $result = $result -creplace '([A-Z]+)([A-Z][a-z])', '$1-$2'
    return $result.ToLower()
}

# ── Step 1: Build Corvus.Text.Json ──────────────────────────────────────────
Write-Host "`n[1/8] Building Corvus.Text.Json..." -ForegroundColor Cyan
$mainProject = Join-Path $repoRoot "src\Corvus.Text.Json\Corvus.Text.Json.csproj"
& dotnet build $mainProject -c Release -f net10.0 /p:GenerateDocumentationFile=true --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json" }
Write-Host "  XML documentation generated." -ForegroundColor Green

# ── Step 2: Generate API namespace markdown & taxonomy ──────────────────────
Write-Host "`n[2/8] Generating API namespace pages & taxonomy..." -ForegroundColor Cyan
& dotnet run --project $toolProject -c Release -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir
if ($LASTEXITCODE -ne 0) { throw "API namespace generation failed" }
Write-Host "  Namespace markdown & taxonomy generated." -ForegroundColor Green

# ── Step 3: Generate recipe content from ExampleRecipes ─────────────────────
Write-Host "`n[3/8] Generating recipe content from ExampleRecipes..." -ForegroundColor Cyan

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
    var recipesParent = Model.SiteContext.Navigation?.Children?
        .FirstOrDefault(x => x.Url?.ToString()?.Contains("/examples/") == true);
    var recipes = recipesParent?.Children?.OrderBy(x => x.Rank).ToList();
    var currentUrl = Model.PageContext.Navigation?.Url;
}
<div class="layout-docs container">
    <aside class="sidebar">
        <div class="sidebar__section">
            <button class="sidebar__heading">Examples</button>
            <div class="sidebar__body">
                <ul class="sidebar__list">
                    @if (recipes != null)
                    {
                        @foreach (var recipe in recipes)
                        {
                            var isActive = currentUrl != null && Vellum.Cli.Domain.Url.AreEquivalent(recipe.Url, currentUrl);
                            <li class="sidebar__item">
                                <a class="sidebar__link @(isActive ? "is-active" : "")" href="@recipe.Url">@recipe.Title</a>
                            </li>
                        }
                    }
                </ul>
            </div>
        </div>
    </aside>
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

    # Extract FAQ questions from ### headings inside the FAQ section
    $faqQuestions = @()
    if ($raw -match '(?s)## Frequently Asked Questions(.+?)(?=\n## |\z)') {
        $faqSection = $Matches[1]
        $faqQuestions = [regex]::Matches($faqSection, '###\s+(.+)') |
            ForEach-Object { $_.Groups[1].Value.Trim() -replace '"', '\"' -replace '`', '' }
    }

    # Build Keywords array: base keywords + FAQ questions
    $keywordItems = @('recipe', 'JSON Schema', 'C#')
    $keywordItems += $faqQuestions
    $keywordsYaml = ($keywordItems | ForEach-Object { "`"$_`"" }) -join ', '

    # 1) Content markdown with Vellum frontmatter
    $contentPath = Join-Path $recipesContentDir "$pascalName.md"
    $frontmatter = "---`nContentType: `"application/vnd.endjin.ssg.content+md`"`nPublicationStatus: Published`nDate: 2026-03-15T00:00:00.0+00:00`nTitle: `"$title`"`n---`n"
    $contentMd = $frontmatter + $body
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

# ── Step 4: Install Vellum ──────────────────────────────────────────────────
$vellumVersion = "2.0.9"
$vellumDir = Join-Path $here ".endjin"
$vellumCmd = Join-Path $vellumDir "vellum"

if (!(Test-Path $vellumCmd) -and !(Test-Path "$vellumCmd.exe")) {
    Write-Host "`n[4/8] Installing Vellum $vellumVersion..." -ForegroundColor Cyan
    if (!(Test-Path $vellumDir)) {
        New-Item -ItemType Directory -Path $vellumDir | Out-Null
    }
    & gh release download -R endjin/Endjin.StaticSiteGen $vellumVersion -p "vellum.$vellumVersion.nupkg" -D $vellumDir --clobber
    & dotnet tool install vellum --version $vellumVersion --tool-path $vellumDir --add-source $vellumDir
    if ($LASTEXITCODE -ne 0) { throw "Failed to install Vellum" }
    Write-Host "  Vellum installed." -ForegroundColor Green
} else {
    Write-Host "`n[4/8] Vellum already installed." -ForegroundColor DarkGray
}

# ── Step 5: Run Vellum ──────────────────────────────────────────────────────
Write-Host "`n[5/8] Running Vellum..." -ForegroundColor Cyan

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
Write-Host "  Site rendered." -ForegroundColor Green

# ── Step 6: Compile SCSS ────────────────────────────────────────────────────
Write-Host "`n[6/8] Compiling SCSS..." -ForegroundColor Cyan
$scssPath = Join-Path $assetsSource "css\scss\main.scss"
$cssOutputPath = Join-Path $outputDir "main.css"
& npx sass $scssPath $cssOutputPath --style=compressed --no-source-map
if ($LASTEXITCODE -ne 0) { throw "SCSS compilation failed" }
Write-Host "  CSS written to $cssOutputPath" -ForegroundColor Green

# ── Step 7: Generate per-type API HTML pages ────────────────────────────────
Write-Host "`n[7/8] Generating per-type API pages..." -ForegroundColor Cyan
$apiHtmlDir = Join-Path $outputDir "api"
& dotnet run --project $toolProject -c Release --no-build -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir `
    --html-output $apiHtmlDir `
    --site-title "Corvus.Text.Json"
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Per-type HTML generation failed — namespace summary pages still available."
} else {
    $count = (Get-ChildItem $apiHtmlDir -Filter "*.html" | Where-Object { $_.Name -match '-.*-' }).Count
    Write-Host "  $count per-type API pages generated." -ForegroundColor Green
}

# ── Step 8: Build search index ──────────────────────────────────────────────
Write-Host "`n[8/8] Building search index..." -ForegroundColor Cyan
$searchIndexOutput = Join-Path $outputDir "search-index.json"
& node (Join-Path $here "tools\build-search-index.js") --output $searchIndexOutput
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Search index generation failed — site will build without search."
} else {
    Write-Host "  Search index written." -ForegroundColor Green
}

Write-Host "`nBuild complete! Output: $outputDir" -ForegroundColor Green
