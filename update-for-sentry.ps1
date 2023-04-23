Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function UpdateSourceFiles([string]$Path)
{
    $files = Get-ChildItem -Recurse $Path -Filter '*.cs'
    foreach ($file in $files)
    {
        $text = Get-Content $file.FullName -Raw
        # Make classes and structs internal
        $text = $text -replace 'public( +[a-z ]+(class|struct))', 'internal$1'
        $text = "#nullable disable`n`n" + ($text -replace "#nullable disable[`n`r]+", '')
        Set-Content $file.FullName $text
    }
}

UpdateSourceFiles -Path 'src/TraceEvent'
UpdateSourceFiles -Path 'src/FastSerialization'