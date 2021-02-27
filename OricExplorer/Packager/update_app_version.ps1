$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$PSScriptRoot\..\bin\release\OricExplorer.exe").FileVersion

$xml = @"
<?xml version="1.0" encoding="utf-8"?>
<OricExplorer>
  <version>$version</version>
  <url>https://github.com/oric-software/OricExplorer/blob/master/dist</url>
</OricExplorer>
"@

$xml | Out-File -FilePath "$PSScriptRoot\..\..\dist\app_version.xml"