Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function UpdateSourceFiles([string]$Path)
{
    $files = Get-ChildItem -Recurse $Path -Filter '*.cs'
    foreach ($file in $files)
    {
        $oldText = Get-Content $file.FullName -Raw
        $text = $oldText

        # Make types internal.
        $text = $text -replace 'public( +([a-z ]+)?(class|struct|enum|interface|delegate) +)', 'internal$1'
        $text = $text -creplace "(`n +)(class|struct|enum|interface) ", '$1internal $2 '

        # Allow nullable types.
        $text = "#nullable disable`n`n" + ($text -replace "#nullable disable[`n`r]+", '')

        # Only write in case we see a change to avoid unnecessary git changes due to Encoding differences.
        if ($oldText -ne $text)
        {
            Set-Content $file.FullName $text -NoNewline
        }
    }
}

UpdateSourceFiles -Path 'src/TraceEvent'
UpdateSourceFiles -Path 'src/FastSerialization'
UpdateSourceFiles -Path 'src/Utilities'