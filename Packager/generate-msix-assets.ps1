param(
    [Parameter(Mandatory = $true)]
    [string]$Master,

    [string]$StagingDir = ".\Images",

    [string[]]$TargetDirs = @(
        ".\win-x64\publish\Images",
        ".\win-arm64\publish\Images"
    )
)

if (-not (Test-Path $Master)) {
    Write-Error "Master image not found: $Master"
    exit 1
}

$magick = (Get-Command magick -ErrorAction SilentlyContinue)
if (-not $magick) {
    Write-Error "ImageMagick 'magick' command not found on PATH. Install from https://imagemagick.org/script/download.php"
    exit 1
}

$OutDir = $StagingDir
New-Item -ItemType Directory -Path $OutDir -Force | Out-Null

function New-SquareAsset {
    param(
        [string]$FileName,
        [int]$Size
    )
    $Path = Join-Path $OutDir $FileName
    & magick $Master -filter Lanczos -resize "${Size}x${Size}" -define png:compression-level=9 $Path
    Write-Host "  $Path ($Size x $Size)"
}

function New-PaddedAsset {
    param(
        [string]$FileName,
        [int]$CanvasW,
        [int]$CanvasH,
        [double]$FillRatio = 0.42
    )
    $Path = Join-Path $OutDir $FileName
    $iconSize = [int]([Math]::Min($CanvasW, $CanvasH) * $FillRatio)
    & magick $Master -filter Lanczos -resize "${iconSize}x${iconSize}" `
        -background none -gravity center -extent "${CanvasW}x${CanvasH}" `
        -define png:compression-level=9 $Path
    Write-Host "  $Path ($CanvasW x $CanvasH, icon $iconSize px)"
}

Write-Host "`nSquare44x44Logo (scale variants)"
New-SquareAsset "Square44x44Logo.png"            44
New-SquareAsset "Square44x44Logo.scale-100.png"  44
New-SquareAsset "Square44x44Logo.scale-125.png"  55
New-SquareAsset "Square44x44Logo.scale-150.png"  66
New-SquareAsset "Square44x44Logo.scale-200.png"  88
New-SquareAsset "Square44x44Logo.scale-400.png"  176

Write-Host "`nSquare44x44Logo (targetsize, plain)"
foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-$size.png" $size
}

Write-Host "`nSquare44x44Logo (targetsize, altform-unplated - dark taskbar)"
foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-${size}_altform-unplated.png" $size
}

Write-Host "`nSquare44x44Logo (targetsize, altform-lightunplated - light taskbar)"
foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-${size}_altform-lightunplated.png" $size
}

Write-Host "`nSquare150x150Logo"
New-SquareAsset "Square150x150Logo.png"            150
New-SquareAsset "Square150x150Logo.scale-100.png"  150
New-SquareAsset "Square150x150Logo.scale-125.png"  188
New-SquareAsset "Square150x150Logo.scale-150.png"  225
New-SquareAsset "Square150x150Logo.scale-200.png"  300
New-SquareAsset "Square150x150Logo.scale-400.png"  600

Write-Host "`nLargeTile"
New-SquareAsset "LargeTile.png"            310
New-SquareAsset "LargeTile.scale-100.png"  310
New-SquareAsset "LargeTile.scale-125.png"  388
New-SquareAsset "LargeTile.scale-150.png"  465
New-SquareAsset "LargeTile.scale-200.png"  620
New-SquareAsset "LargeTile.scale-400.png"  1240

Write-Host "`nSmallTile"
New-SquareAsset "SmallTile.png"            71
New-SquareAsset "SmallTile.scale-100.png"  71
New-SquareAsset "SmallTile.scale-125.png"  89
New-SquareAsset "SmallTile.scale-150.png"  107
New-SquareAsset "SmallTile.scale-200.png"  142
New-SquareAsset "SmallTile.scale-400.png"  284

Write-Host "`nStoreLogo"
New-SquareAsset "StoreLogo.png"            50
New-SquareAsset "StoreLogo.scale-100.png"  50
New-SquareAsset "StoreLogo.scale-125.png"  63
New-SquareAsset "StoreLogo.scale-150.png"  75
New-SquareAsset "StoreLogo.scale-200.png"  100
New-SquareAsset "StoreLogo.scale-400.png"  200

Write-Host "`nWide310x150Logo"
New-PaddedAsset "Wide310x150Logo.png"            310  150
New-PaddedAsset "Wide310x150Logo.scale-100.png"  310  150
New-PaddedAsset "Wide310x150Logo.scale-125.png"  388  188
New-PaddedAsset "Wide310x150Logo.scale-150.png"  465  225
New-PaddedAsset "Wide310x150Logo.scale-200.png"  620  300
New-PaddedAsset "Wide310x150Logo.scale-400.png"  1240 600

Write-Host "`nSplashScreen"
New-PaddedAsset "SplashScreen.png"            620  300 0.35
New-PaddedAsset "SplashScreen.scale-100.png"  620  300 0.35
New-PaddedAsset "SplashScreen.scale-125.png"  775  375 0.35
New-PaddedAsset "SplashScreen.scale-150.png"  930  450 0.35
New-PaddedAsset "SplashScreen.scale-200.png"  1240 600 0.35
New-PaddedAsset "SplashScreen.scale-400.png"  2480 1200 0.35

Write-Host "`nGenerated $((Get-ChildItem $OutDir -File).Count) files in staging dir: $OutDir"

foreach ($target in $TargetDirs) {
    New-Item -ItemType Directory -Path $target -Force | Out-Null
    Copy-Item -Path (Join-Path $OutDir "*") -Destination $target -Force
    Write-Host "Copied to: $target"
}

Write-Host "`nDone."
