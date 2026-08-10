# Maki Dice (Windows)
# github.com/andrewmichaelpowell

if (Test-Path .\bundle) { Remove-Item -Recurse -Force .\bundle }

$null = New-Item -ItemType Directory -Force -Path .\bundle\win-arm64\publish\Assets
$null = New-Item -ItemType Directory -Force -Path .\bundle\win-x64\publish\Assets
$null = New-Item -ItemType Directory -Force -Path .\bundle\msix

Copy-Item -Path .\bin\Release\net9.0-windows\win-arm64\publish\* -Destination .\bundle\win-arm64\publish\
Copy-Item -Path .\Packages\Manifests\win-arm64\AppxManifest.xml -Destination .\bundle\win-arm64\publish\AppxManifest.xml
Copy-Item -Path .\Packages\Assets\* -Destination .\bundle\win-arm64\publish\Assets\

Copy-Item -Path .\bin\Release\net9.0-windows\win-x64\publish\* -Destination .\bundle\win-x64\publish\
Copy-Item -Path .\Packages\Manifests\win-x64\AppxManifest.xml -Destination .\bundle\win-x64\publish\AppxManifest.xml
Copy-Item -Path .\Packages\Assets\* -Destination .\bundle\win-x64\publish\Assets\

$makepri = (Get-ChildItem -Path C:\ -Filter MakePri.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName
$makeappx = (Get-ChildItem -Path C:\ -Filter MakeAppx.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName

& $makepri createconfig /cf ".\bundle\priconfig.xml" /dq en-US /o
& $makepri new /pr ".\bundle\win-arm64\publish" /cf ".\bundle\priconfig.xml" /mn ".\bundle\win-arm64\publish\AppxManifest.xml" /of ".\bundle\win-arm64\publish\resources.pri" /o
& $makeappx pack /d ".\bundle\win-arm64\publish" /p ".\bundle\msix\MakiDice_arm64.msix" /o
& $makepri new /pr ".\bundle\win-x64\publish" /cf ".\bundle\priconfig.xml" /mn ".\bundle\win-x64\publish\AppxManifest.xml" /of ".\bundle\win-x64\publish\resources.pri" /o
& $makeappx pack /d ".\bundle\win-x64\publish" /p ".\bundle\msix\MakiDice_x64.msix" /o
& $makeappx bundle /d ".\bundle\msix" /p ".\bundle\MakiDice.msixbundle" /o