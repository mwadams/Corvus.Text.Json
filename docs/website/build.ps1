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

# Step 2b: Build Lunr search index
Write-Host "Building search index..." -ForegroundColor Cyan
$searchIndexOutput = Join-Path $outputDir "search-index.json"
& node (Join-Path $here "tools\build-search-index.js") --output $searchIndexOutput
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Search index generation failed — site will build without search."
} else {
    Write-Host "Search index written to $searchIndexOutput" -ForegroundColor Green
}

# Step 3: Run Vellum
$vellumCmd = "vellum"

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
