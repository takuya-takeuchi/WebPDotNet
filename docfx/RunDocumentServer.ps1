$Current = $PSScriptRoot

$WebPDotNetRoot = Split-Path $Current -Parent
$SourceRoot = Join-Path $WebPDotNetRoot src
$WebPDotNetProjectRoot = Join-Path $SourceRoot WebPDotNet
$DocumentDir = Join-Path $WebPDotNetProjectRoot docfx
$Json = Join-Path $Current docfx.json

docfx "${Json}" --serve
Set-Location $Current