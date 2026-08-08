# Maki Dice (Windows)
# github.com/andrewmichaelpowell

$makepri = (Get-ChildItem -Path C:\ -Filter MakePri.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName
& $makepri createconfig /cf ".\priconfig.xml" /dq en-US /o

$makeappx = (Get-ChildItem -Path C:\ -Filter MakeAppx.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName

& $makepri new /pr ".\win-x64\publish" /cf ".\priconfig.xml" /mn ".\win-x64\publish\AppxManifest.xml" /of ".\win-x64\publish\resources.pri" /o
& $makeappx pack /d ".\win-x64\publish" /p ".\msix\MakiDice_x64.msix" /o

& $makepri new /pr ".\win-arm64\publish" /cf ".\priconfig.xml" /mn ".\win-arm64\publish\AppxManifest.xml" /of ".\win-arm64\publish\resources.pri" /o
& $makeappx pack /d ".\win-arm64\publish" /p ".\msix\MakiDice_arm64.msix" /o

& $makeappx bundle /d ".\msix" /p ".\MakiDice.msixbundle" /o