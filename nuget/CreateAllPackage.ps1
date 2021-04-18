$targets = @(
   "CPU"
)

$ScriptPath = $PSScriptRoot
$WebPDotNet = Split-Path $ScriptPath -Parent

$source = Join-Path $WebPDotNet src | `
          Join-Path -ChildPath WebPDotNet
dotnet restore ${source}
dotnet build -c Release ${source}

foreach ($target in $targets)
{
   pwsh CreatePackage.ps1 $target
}