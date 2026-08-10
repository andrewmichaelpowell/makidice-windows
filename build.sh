#!/bin/bash

# Maki Dice (Windows)
# github.com/andrewmichaelpowell

rm -fr bin
rm -fr obj
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfContained=true -p:EnableWindowsTargeting=true
dotnet publish -c Release -r win-arm64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfContained=true -p:EnableWindowsTargeting=true