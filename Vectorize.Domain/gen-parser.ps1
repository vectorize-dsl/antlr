$grammarFile = '../../grammar/Vectorize.g4'
$toolsDir = '../../tools'
$antlrTool = "$toolsDir/antlr4.jar"
$antlrDownloadUrl = 'https://www.antlr.org/download/antlr-4.7.2-complete.jar'

if (!(Test-Path $antlrTool)) {
    Write-Output "Downloading ANTLR 4..."
    New-Item -ItemType Directory -Force $toolsDir
    Start-BitsTransfer -Source $antlrDownloadUrl -Destination $antlrTool
}

java -jar $antlrTool -Dlanguage=CSharp -visitor -package Vectorize.Domain.Parser -o Parser $grammarFile