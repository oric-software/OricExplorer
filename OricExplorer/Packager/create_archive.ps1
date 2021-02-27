$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$PSScriptRoot\..\bin\release\OricExplorer.exe").FileVersion

Compress-Archive "$PSScriptRoot\..\bin\release\*.dll", "$PSScriptRoot\..\bin\release\*.exe" "$PSScriptRoot\..\..\dist\OricExplorer_v$version.zip"