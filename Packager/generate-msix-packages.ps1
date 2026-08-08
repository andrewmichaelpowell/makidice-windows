# Maki Dice (Windows)
# github.com/andrewmichaelpowell

$makepri = (Get-ChildItem -Path C:\ -Filter MakePri.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName
& $makepri createconfig /cf "C:\Package\priconfig.xml" /dq en-US /o

$makeappx = (Get-ChildItem -Path C:\ -Filter MakeAppx.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName

& $makepri new /pr "C:\Package\win-x64\publish" /cf "C:\Package\priconfig.xml" /mn "C:\Package\win-x64\publish\AppxManifest.xml" /of "C:\Package\win-x64\publish\resources.pri" /o
& $makeappx pack /d "C:\Package\win-x64\publish" /p "C:\Package\msix\MakiDice_x64.msix" /o

& $makepri new /pr "C:\Package\win-arm64\publish" /cf "C:\Package\priconfig.xml" /mn "C:\Package\win-arm64\publish\AppxManifest.xml" /of "C:\Package\win-arm64\publish\resources.pri" /o
& $makeappx pack /d "C:\Package\win-arm64\publish" /p "C:\Package\msix\MakiDice_arm64.msix" /o

& $makeappx bundle /d "C:\Package\msix" /p "C:\Package\MakiDice.msixbundle" /o