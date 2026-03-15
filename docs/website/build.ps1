<#
.SYNOPSIS
    Builds the Corvus.Text.Json documentation website.
.DESCRIPTION
    End-to-end build pipeline:
      1. Build Corvus.Text.Json (generates XML doc + assembly)
      2. Generate API namespace markdown & taxonomy from XML docs
      3. Install Vellum SSG (if not present)
      4. Run Vellum to render the core site (32 pages)
      5. Compile SCSS to CSS
      6. Generate standalone per-type API HTML pages (87 pages)
      7. Build Lunr search index
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

# ── Step 1: Build Corvus.Text.Json ──────────────────────────────────────────
Write-Host "`n[1/7] Building Corvus.Text.Json..." -ForegroundColor Cyan
$mainProject = Join-Path $repoRoot "src\Corvus.Text.Json\Corvus.Text.Json.csproj"
& dotnet build $mainProject -c Release -f net10.0 /p:GenerateDocumentationFile=true --no-incremental -v q
if ($LASTEXITCODE -ne 0) { throw "Failed to build Corvus.Text.Json" }
Write-Host "  XML documentation generated." -ForegroundColor Green

# ── Step 2: Generate API namespace markdown & taxonomy ──────────────────────
Write-Host "`n[2/7] Generating API namespace pages & taxonomy..." -ForegroundColor Cyan
& dotnet run --project $toolProject -c Release -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir
if ($LASTEXITCODE -ne 0) { throw "API namespace generation failed" }
Write-Host "  Namespace markdown & taxonomy generated." -ForegroundColor Green

# ── Step 3: Install Vellum ──────────────────────────────────────────────────
$vellumVersion = "2.0.9"
$vellumDir = Join-Path $here ".endjin"
$vellumCmd = Join-Path $vellumDir "vellum"

if (!(Test-Path $vellumCmd) -and !(Test-Path "$vellumCmd.exe")) {
    Write-Host "`n[3/7] Installing Vellum $vellumVersion..." -ForegroundColor Cyan
    if (!(Test-Path $vellumDir)) {
        New-Item -ItemType Directory -Path $vellumDir | Out-Null
    }
    & gh release download -R endjin/Endjin.StaticSiteGen $vellumVersion -p "vellum.$vellumVersion.nupkg" -D $vellumDir --clobber
    & dotnet tool install vellum --version $vellumVersion --tool-path $vellumDir --add-source $vellumDir
    if ($LASTEXITCODE -ne 0) { throw "Failed to install Vellum" }
    Write-Host "  Vellum installed." -ForegroundColor Green
} else {
    Write-Host "`n[3/7] Vellum already installed." -ForegroundColor DarkGray
}

# ── Step 4: Run Vellum ──────────────────────────────────────────────────────
Write-Host "`n[4/7] Running Vellum..." -ForegroundColor Cyan

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

# ── Step 5: Compile SCSS ────────────────────────────────────────────────────
Write-Host "`n[5/7] Compiling SCSS..." -ForegroundColor Cyan
$scssPath = Join-Path $assetsSource "css\scss\main.scss"
$cssOutputPath = Join-Path $outputDir "main.css"
& npx sass $scssPath $cssOutputPath --style=compressed --no-source-map
if ($LASTEXITCODE -ne 0) { throw "SCSS compilation failed" }
Write-Host "  CSS written to $cssOutputPath" -ForegroundColor Green

# ── Step 6: Generate per-type API HTML pages ────────────────────────────────
Write-Host "`n[6/7] Generating per-type API pages..." -ForegroundColor Cyan
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

# ── Step 7: Build search index ──────────────────────────────────────────────
Write-Host "`n[7/7] Building search index..." -ForegroundColor Cyan
$searchIndexOutput = Join-Path $outputDir "search-index.json"
& node (Join-Path $here "tools\build-search-index.js") --output $searchIndexOutput
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Search index generation failed — site will build without search."
} else {
    Write-Host "  Search index written." -ForegroundColor Green
}

Write-Host "`nBuild complete! Output: $outputDir" -ForegroundColor Green
