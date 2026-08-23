# Maki Dice (Windows)
# github.com/andrewmichaelpowell

# brew install ghostscript
# brew install imagemagick

$MasterImage = "./Resources/Icon.png"
$OutputDirectory = "./Packages/Assets"

if (Test-Path $OutputDirectory) { Remove-Item -Recurse -Force $OutputDirectory }
$null = New-Item -ItemType Directory -Force -Path $OutputDirectory

function New-SquareAsset {
    param(
        [string]$FileName,
        [int]$Size
    )
    $Path = Join-Path $OutputDirectory $FileName
    & magick $MasterImage -filter Lanczos -resize "${Size}x${Size}" -define png:compression-level=9 $Path
}

function New-PaddedAsset {
    param(
        [string]$FileName,
        [int]$CanvasW,
        [int]$CanvasH,
        [double]$FillRatio = 0.42
    )
    $Path = Join-Path $OutputDirectory $FileName
    $iconSize = [int]([Math]::Min($CanvasW, $CanvasH) * $FillRatio)
    & magick $MasterImage -filter Lanczos -resize "${iconSize}x${iconSize}" -background none -gravity center -extent "${CanvasW}x${CanvasH}" -define png:compression-level=9 $Path
}

New-SquareAsset "Square44x44Logo.png" 44
New-SquareAsset "Square44x44Logo.scale-100.png" 44
New-SquareAsset "Square44x44Logo.scale-125.png" 55
New-SquareAsset "Square44x44Logo.scale-150.png" 66
New-SquareAsset "Square44x44Logo.scale-200.png" 88
New-SquareAsset "Square44x44Logo.scale-400.png" 176

foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-$size.png" $size
}

foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-${size}_altform-unplated.png" $size
}

foreach ($size in 16, 24, 32, 48, 256) {
    New-SquareAsset "Square44x44Logo.targetsize-${size}_altform-lightunplated.png" $size
}

New-SquareAsset "Square150x150Logo.png" 150
New-SquareAsset "Square150x150Logo.scale-100.png" 150
New-SquareAsset "Square150x150Logo.scale-125.png" 188
New-SquareAsset "Square150x150Logo.scale-150.png" 225
New-SquareAsset "Square150x150Logo.scale-200.png" 300
New-SquareAsset "Square150x150Logo.scale-400.png" 600

New-SquareAsset "Square310x310Logo.png" 310
New-SquareAsset "Square310x310Logo.scale-100.png" 310
New-SquareAsset "Square310x310Logo.scale-125.png" 388
New-SquareAsset "Square310x310Logo.scale-150.png" 465
New-SquareAsset "Square310x310Logo.scale-200.png" 620
New-SquareAsset "Square310x310Logo.scale-400.png" 1240

New-SquareAsset "Square71x71Logo.png" 71
New-SquareAsset "Square71x71Logo.scale-100.png" 71
New-SquareAsset "Square71x71Logo.scale-125.png" 89
New-SquareAsset "Square71x71Logo.scale-150.png" 107
New-SquareAsset "Square71x71Logo.scale-200.png" 142
New-SquareAsset "Square71x71Logo.scale-400.png" 284

New-SquareAsset "StoreLogo.png" 50
New-SquareAsset "StoreLogo.scale-100.png" 50
New-SquareAsset "StoreLogo.scale-125.png" 63
New-SquareAsset "StoreLogo.scale-150.png" 75
New-SquareAsset "StoreLogo.scale-200.png" 100
New-SquareAsset "StoreLogo.scale-400.png" 200

New-PaddedAsset "Wide310x150Logo.png" 310 150
New-PaddedAsset "Wide310x150Logo.scale-100.png" 310 150
New-PaddedAsset "Wide310x150Logo.scale-125.png" 388 188
New-PaddedAsset "Wide310x150Logo.scale-150.png" 465 225
New-PaddedAsset "Wide310x150Logo.scale-200.png" 620 300
New-PaddedAsset "Wide310x150Logo.scale-400.png" 1240 600

New-PaddedAsset "SplashScreen.png" 620 300 0.35
New-PaddedAsset "SplashScreen.scale-100.png" 620 300 0.35
New-PaddedAsset "SplashScreen.scale-125.png" 775 375 0.35
New-PaddedAsset "SplashScreen.scale-150.png" 930 450 0.35
New-PaddedAsset "SplashScreen.scale-200.png" 1240 600 0.35
New-PaddedAsset "SplashScreen.scale-400.png" 2480 1200 0.35