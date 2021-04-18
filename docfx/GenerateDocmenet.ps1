$Current = $PSScriptRoot

$WebPDotNetRoot = Split-Path $Current -Parent
$SourceRoot = Join-Path $WebPDotNetRoot src
$WebPDotNetProjectRoot = Join-Path $SourceRoot WebPDotNet

docfx init -q -o docs
Set-Location $Current