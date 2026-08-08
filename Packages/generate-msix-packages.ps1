# Maki Dice (Windows)
# github.com/andrewmichaelpowell

$makepri = (Get-ChildItem -Path C:\ -Filter MakePri.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName
& $makepri createconfig /cf "C:\Packages\priconfig.xml" /dq en-US /o

$makeappx = (Get-ChildItem -Path C:\ -Filter MakeAppx.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName

& $makepri new /pr "C:\Packages\win-x64\publish" /cf "C:\Packages\priconfig.xml" /mn "C:\Packages\win-x64\publish\AppxManifest.xml" /of "C:\Packages\win-x64\publish\resources.pri" /o
& $makeappx pack /d "C:\Packages\win-x64\publish" /p "C:\Packages\msix\MakiDice_x64.msix" /o

& $makepri new /pr "C:\Packages\win-arm64\publish" /cf "C:\Packages\priconfig.xml" /mn "C:\Packages\win-arm64\publish\AppxManifest.xml" /of "C:\Packages\win-arm64\publish\resources.pri" /o
& $makeappx pack /d "C:\Packages\win-arm64\publish" /p "C:\Packages\msix\MakiDice_arm64.msix" /o

& $makeappx bundle /d "C:\Packages\msix" /p "C:\Packages\MakiDice.msixbundle" /o