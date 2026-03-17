<#
.SYNOPSIS
    Builds the Corvus.Text.Json documentation website.
.DESCRIPTION
    End-to-end build pipeline:
      1. Build Corvus.Text.Json (generates XML doc + assembly)
      2. Generate API markdown, taxonomy & views
      3. Generate recipe content from ExampleRecipes source docs
      4. Generate docs content from source documentation
      5. Install Vellum SSG (if not present)
      6. Run Vellum to render the core site
      7. Compile SCSS to CSS
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
$siteDir = Join-Path $here "site"
$outputDir = Join-Path $here ".output"

# Paths used by multiple steps
$xmlPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.xml"
$assemblyPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.dll"
$ns20AssemblyPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\netstandard2.0\Corvus.Text.Json.dll"
$apiContentDir = Join-Path $siteDir "content\Api"
$apiTaxonomyDir = Join-Path $siteDir "taxonomy\api"
$toolProject = Join-Path $here "tools\XmlDocToMarkdown"

# ── Helper: PascalCase to kebab-case ────────────────────────────────────────
function ConvertTo-KebabCase([string]$text) {
    $result = $text -creplace '([a-z0-9])([A-Z])', '$1-$2'
    $result = $result -creplace '([A-Z]+)([A-Z][a-z])', '$1-$2'
    return $result.ToLower()
}

# ── Step 1: Build Corvus.Text.Json ──────────────────────────────────────────
Write-Host "`n[1/8] Building Corvus.Text.Json..." -ForegroundColor Cyan
$mainProject = Join-Path $repoRoot "src\Corvus.Text.Json\Corvus.Text.Json.csproj"
& dotnet build $mainProject -c Release -f net10.0 /p:GenerateDocumentationFile=true --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json (net10.0)" }
& dotnet build $mainProject -c Release -f netstandard2.0 --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json (netstandard2.0)" }
Write-Host "  XML documentation generated." -ForegroundColor Green

# ── Step 2: Generate API namespace markdown & taxonomy ──────────────────────
Write-Host "`n[2/8] Generating API markdown, taxonomy & views..." -ForegroundColor Cyan
$apiViewsDir = Join-Path $siteDir "theme\corvus\views\api"
$sharedViewsDir = Join-Path $siteDir "theme\corvus\views\Shared"
$nsDescriptionsDir = Join-Path $siteDir "content\Api\namespaces"
& dotnet run --project $toolProject -c Release -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --ns20-assembly $ns20AssemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir `
    --api-views-dir $apiViewsDir `
    --shared-views-dir $sharedViewsDir `
    --ns-descriptions $nsDescriptionsDir
if ($LASTEXITCODE -ne 0) { throw "API namespace generation failed" }
Write-Host "  API markdown, taxonomy & views generated." -ForegroundColor Green

# ── Step 3: Generate recipe content from ExampleRecipes ─────────────────────
Write-Host "`n[3/8] Generating recipe content from ExampleRecipes..." -ForegroundColor Cyan

$recipesSourceDir = Join-Path $repoRoot "docs\ExampleRecipes"
$recipesContentDir = Join-Path $siteDir "content\Examples"
$recipesTaxonomyDir = Join-Path $siteDir "taxonomy\examples"

# Clean old generated recipe files (preserve Overview.md and index.*)
Get-ChildItem $recipesContentDir -Filter "*.md" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "Overview.md" } | Remove-Item -Force
Get-ChildItem $recipesTaxonomyDir -Filter "*.yml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.yml" } | Remove-Item -Force

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

    # 2) Taxonomy YAML (with Template property for shared view)
    $rank = $recipeCount + 1
    $taxonomyYml = @"
ContentType: application/vnd.endjin.ssg.page+yaml
Title: "$title"
Template: examples/recipe-detail
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

    $recipeCount++
    Write-Host "  $number $title -> $slug" -ForegroundColor Gray
}
Write-Host "  $recipeCount recipe(s) generated." -ForegroundColor Green

# ── Step 4: Generate docs content from source documentation ─────────────────
Write-Host "`n[4/8] Generating docs content from source documentation..." -ForegroundColor Cyan

$docsSourceDir = Join-Path $repoRoot "docs"
$docsContentDir = Join-Path $siteDir "content\Docs"
$docsTaxonomyDir = Join-Path $siteDir "taxonomy\docs"
$descriptorsDir = Join-Path $here "doc-descriptors"

# Clean old generated doc files (preserve Overview.md and index.*)
Get-ChildItem $docsContentDir -Filter "*.md" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "Overview.md" } | Remove-Item -Force
Get-ChildItem $docsTaxonomyDir -Filter "*.yml" -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -ne "index.yml" } | Remove-Item -Force

$docCount = 0
$descriptorFiles = Get-ChildItem $descriptorsDir -Filter "*.yml" | Sort-Object Name

foreach ($descriptorFile in $descriptorFiles) {
    # Parse simple YAML descriptor (source, navTitle, description)
    $descriptorContent = Get-Content $descriptorFile.FullName -Raw -Encoding utf8
    $descriptor = @{}
    foreach ($line in ($descriptorContent -split "`n")) {
        $line = $line.Trim()
        if ($line -match '^(\w+):\s*"?(.+?)"?\s*$') {
            $descriptor[$Matches[1]] = $Matches[2]
        }
    }

    $docFile = $descriptor['source']
    if (!$docFile) {
        Write-Warning "  Descriptor $($descriptorFile.Name) missing 'source' — skipping"
        continue
    }

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

    # Use descriptor nav title, or fall back to doc title
    $navTitle = if ($descriptor['navTitle']) { $descriptor['navTitle'] } else {
        $t = $docTitle
        if ($t.Length -gt 30) { $t = $t.Substring(0, 27) + '...' }
        $t
    }

    # Use descriptor description, or extract first sentence
    if ($descriptor['description']) {
        $docDescription = $descriptor['description']
    } elseif ($docBody -match '^(.+?\.)\s') {
        $docDescription = $Matches[1] -replace '"', '\"'
    } else {
        $docDescription = $docTitle
    }

    # 1) Content markdown
    $contentPath = Join-Path $docsContentDir "$baseName.md"
    $frontmatter = "---`nContentType: `"application/vnd.endjin.ssg.content+md`"`nPublicationStatus: Published`nDate: 2026-03-15T00:00:00.0+00:00`nTitle: `"$($docTitle -replace '"', '\"')`"`n---`n"
    [System.IO.File]::WriteAllText($contentPath, ($frontmatter + $docBody), [System.Text.Encoding]::UTF8)

    # 2) Taxonomy YAML (with Template property for shared view)
    $docRank = $docCount + 1
    $docTaxonomyYml = @"
ContentType: application/vnd.endjin.ssg.page+yaml
Title: "$($docTitle -replace '"', '\"')"
Template: docs/doc-page
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

    $docCount++
    Write-Host "  $docTitle -> $slug" -ForegroundColor Gray
}
Write-Host "  $docCount doc page(s) generated." -ForegroundColor Green

# ── Step 5: Install Vellum ──────────────────────────────────────────────────
$vellumVersion = "2.0.9"
$vellumDir = Join-Path $here ".endjin"
$vellumCmd = Join-Path $vellumDir "vellum"

if (!(Test-Path $vellumCmd) -and !(Test-Path "$vellumCmd.exe")) {
    Write-Host "`n[5/8] Installing Vellum $vellumVersion..." -ForegroundColor Cyan
    if (!(Test-Path $vellumDir)) {
        New-Item -ItemType Directory -Path $vellumDir | Out-Null
    }
    & gh release download -R endjin/Endjin.StaticSiteGen $vellumVersion -p "vellum.$vellumVersion.nupkg" -D $vellumDir --clobber
    & dotnet tool install vellum --version $vellumVersion --tool-path $vellumDir --add-source $vellumDir
    if ($LASTEXITCODE -ne 0) { throw "Failed to install Vellum" }
    Write-Host "  Vellum installed." -ForegroundColor Green
} else {
    Write-Host "`n[5/8] Vellum already installed." -ForegroundColor DarkGray
}

# ── Step 6: Run Vellum ──────────────────────────────────────────────────────
Write-Host "`n[6/8] Running Vellum..." -ForegroundColor Cyan

# Prepare output directory
if (Test-Path $outputDir) { Remove-Item $outputDir -Recurse -Force }
$assetsSource = Join-Path $siteDir "theme\corvus\assets"
$assetsDest = Join-Path $outputDir "assets"
Copy-Item -Path $assetsSource -Destination $assetsDest -Recurse -Force

# Run Vellum from the site/ directory so it only sees site source files.
# This eliminates the need to clean up spurious copies of build.ps1, tools/, etc.
Push-Location $siteDir
try {
    $vellumArgs = @("content", "generate", "-t", (Join-Path $siteDir "site.yml"), "-o", $outputDir)
    if ($Watch) { $vellumArgs += "--watch" }
    & $vellumCmd $vellumArgs
    if ($LASTEXITCODE -ne 0) { throw "Vellum generation failed" }
} finally {
    Pop-Location
}

# Vellum copies the site/ source files into output — remove the lightweight copies
foreach ($dir in @("taxonomy", "content", "theme")) {
    $spurious = Join-Path $outputDir $dir
    if (Test-Path $spurious) { Remove-Item $spurious -Recurse -Force }
}
foreach ($file in @("site.yml")) {
    $spurious = Join-Path $outputDir $file
    if (Test-Path $spurious) { Remove-Item $spurious -Force }
}
Write-Host "  Site rendered." -ForegroundColor Green

# ── Step 7: Compile SCSS ────────────────────────────────────────────────────
Write-Host "`n[7/8] Compiling SCSS..." -ForegroundColor Cyan
$scssPath = Join-Path $assetsSource "css\scss\main.scss"
$cssOutputPath = Join-Path $outputDir "main.css"
& npx sass $scssPath $cssOutputPath --style=compressed --no-source-map
if ($LASTEXITCODE -ne 0) { throw "SCSS compilation failed" }
Write-Host "  CSS written to $cssOutputPath" -ForegroundColor Green

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

if ($Preview) {
    Write-Host "`nStarting preview server..." -ForegroundColor Cyan
    $previewArgs = @("content", "generate", "-t", (Join-Path $siteDir "site.yml"), "-o", $outputDir, "--preview")
    & $vellumCmd $previewArgs
}
