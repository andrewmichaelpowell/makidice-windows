# Maki Dice (Windows)
# github.com/andrewmichaelpowell

$makepri = (Get-ChildItem -Path C:\ -Filter MakePri.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName
& $makepri createconfig /cf "C:\Packager\priconfig.xml" /dq en-US /o

$makeappx = (Get-ChildItem -Path C:\ -Filter MakeAppx.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1).FullName

& $makepri new /pr "C:\Packager\win-x64\publish" /cf "C:\Packager\priconfig.xml" /mn "C:\Packager\win-x64\publish\AppxManifest.xml" /of "C:\Packager\win-x64\publish\resources.pri" /o
& $makeappx pack /d "C:\Packager\win-x64\publish" /p "C:\Packager\msix\MakiDice_x64.msix" /o

& $makepri new /pr "C:\Packager\win-arm64\publish" /cf "C:\Packager\priconfig.xml" /mn "C:\Packager\win-arm64\publish\AppxManifest.xml" /of "C:\Packager\win-arm64\publish\resources.pri" /o
& $makeappx pack /d "C:\Packager\win-arm64\publish" /p "C:\Packager\msix\MakiDice_arm64.msix" /o

& $makeappx bundle /d "C:\Packager\msix" /p "C:\Packager\MakiDice.msixbundle" /o