[xml]$xml = Get-Content "$PSScriptRoot\..\..\dist\app_version.xml"
$version = $xml.SelectNodes('//version') | Select-Object -Expand '#text'

Compress-Archive "$PSScriptRoot\..\bin\release\*.dll", "$PSScriptRoot\..\bin\release\*.exe" "$PSScriptRoot\..\..\dist\OricExplorer_v$version.zip"