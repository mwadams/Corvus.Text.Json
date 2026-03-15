<#
.SYNOPSIS
    Runs the build process for generating the Corvus.Text.Json documentation website.
.DESCRIPTION
    This script generates the static documentation site using the Vellum static site generator.
.PARAMETER Preview
    Generates the site and allows you to view it locally via http://localhost:5000.
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

# Step 1: Build Corvus.Text.Json to generate XML documentation
Write-Host "Building Corvus.Text.Json to generate XML documentation..." -ForegroundColor Cyan
$mainProject = Join-Path $repoRoot "src\Corvus.Text.Json\Corvus.Text.Json.csproj"
& dotnet build $mainProject -c Release -f net10.0 /p:GenerateDocumentationFile=true --no-incremental -v q
if ($LASTEXITCODE -ne 0) {
    throw "Failed to build Corvus.Text.Json"
}
Write-Host "XML documentation generated." -ForegroundColor Green

# Step 2: Copy assets to output
$outputDir = Join-Path $here ".output"
if (!(Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir | Out-Null
}

Write-Host "Copying theme assets..." -ForegroundColor Cyan
$assetsSource = Join-Path $here "theme\corvus\assets"
$assetsDest = Join-Path $outputDir "assets"
if (Test-Path $assetsDest) {
    Remove-Item $assetsDest -Recurse -Force
}
Copy-Item -Path $assetsSource -Destination $assetsDest -Recurse -Force

# Step 2b: Generate API documentation
Write-Host "Generating API documentation..." -ForegroundColor Cyan
$xmlPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.xml"
$assemblyPath = Join-Path $repoRoot "src\Corvus.Text.Json\bin\Release\net10.0\Corvus.Text.Json.dll"
$apiContentDir = Join-Path $here "content\Api"
$apiTaxonomyDir = Join-Path $here "taxonomy\api"
$apiHtmlDir = Join-Path $outputDir "api"

& dotnet run --project (Join-Path $here "tools\XmlDocToMarkdown") -c Release -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir `
    --html-output $apiHtmlDir `
    --site-title "Corvus.Text.Json"
if ($LASTEXITCODE -ne 0) {
    Write-Warning "API doc generation failed — site will build without per-type API pages."
} else {
    Write-Host "API documentation generated." -ForegroundColor Green
}

# Step 2c: Build Lunr search index
Write-Host "Building search index..." -ForegroundColor Cyan
$searchIndexOutput = Join-Path $outputDir "search-index.json"
& node (Join-Path $here "tools\build-search-index.js") --output $searchIndexOutput
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Search index generation failed — site will build without search."
} else {
    Write-Host "Search index written to $searchIndexOutput" -ForegroundColor Green
}

# Step 3: Install Vellum (from endjin/Endjin.StaticSiteGen GitHub releases)
$vellumVersion = "2.0.9"
$vellumDir = Join-Path $here ".endjin"
$vellumCmd = Join-Path $vellumDir "vellum"

if (!(Test-Path $vellumCmd) -and !(Test-Path "$vellumCmd.exe")) {
    Write-Host "Installing Vellum $vellumVersion..." -ForegroundColor Cyan
    if (!(Test-Path $vellumDir)) {
        New-Item -ItemType Directory -Path $vellumDir | Out-Null
    }
    & gh release download -R endjin/Endjin.StaticSiteGen $vellumVersion -p "vellum.$vellumVersion.nupkg" -D $vellumDir --clobber
    & dotnet tool install vellum --version $vellumVersion --tool-path $vellumDir --add-source $vellumDir
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to install Vellum"
    }
    Write-Host "Vellum installed." -ForegroundColor Green
}

# Step 4: Run Vellum
$vellumArgs = @(
    "content"
    "generate"
    "-t"
    (Join-Path $here "site.yml")
    "-o"
    $outputDir
)

if ($Preview) {
    $vellumArgs += "--preview"
}

if ($Watch) {
    $vellumArgs += "--watch"
}

Write-Host "Running Vellum..." -ForegroundColor Cyan
Write-Host "  $vellumCmd $($vellumArgs -join ' ')" -ForegroundColor Gray
& $vellumCmd $vellumArgs

# Step 5: Generate standalone per-type HTML pages (after Vellum, since Vellum may clean output)
if (!(Test-Path $apiHtmlDir)) {
    New-Item -ItemType Directory -Path $apiHtmlDir | Out-Null
}
Write-Host "Generating per-type API HTML pages..." -ForegroundColor Cyan
& dotnet run --project (Join-Path $here "tools\XmlDocToMarkdown") -c Release --no-build -- `
    --xml $xmlPath `
    --assembly $assemblyPath `
    --output $apiContentDir `
    --taxonomy-output $apiTaxonomyDir `
    --html-output $apiHtmlDir `
    --site-title "Corvus.Text.Json"
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Per-type HTML generation failed."
} else {
    Write-Host "Per-type API pages generated." -ForegroundColor Green
}
