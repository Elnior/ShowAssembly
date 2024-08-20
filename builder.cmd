if Exist bin (
    @REM None..
) else (
    mkdir bin
)

if Exist "show.ico" (
    csc /out:bin\showAssembly.exe /target:exe /checked+ show.cs iconBytes.cs
) else (
    echo Falied compilation
)

pause