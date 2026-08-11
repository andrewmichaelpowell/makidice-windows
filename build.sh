#!/bin/bash

# Maki Dice (Windows)
# github.com/andrewmichaelpowell

rm -fr bin
rm -fr obj
dotnet publish -c Release -r win-arm64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfContained=true -p:EnableWindowsTargeting=true
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfContained=true -p:EnableWindowsTargeting=true
zip -r ./bin/makidice-windows-arm64.zip -j ./bin/Release/net9.0-windows/win-arm64/publish/*
zip -r ./bin/makidice-windows-x64.zip -j ./bin/Release/net9.0-windows/win-x64/publish/*