$GraphicsProfile = "OpenGL"
$Suffix = ".ogl"

$EffectsDir = Split-Path $MyInvocation.MyCommand.Path
$2mgfxExe = "$EffectsDir\..\..\..\MonoGame\2MGFX\2MGFX.exe"
Write-Host $2mgfxExe

Get-ChildItem $EffectsDir -Filter *.fx |
ForEach-Object {
    $input = $_.FullName
    $output = "$EffectsDir\$($_.BaseName)$Suffix.mgfx"
    & $2mgfxExe $input $output /Profile:$GraphicsProfile
}