if Exist bin (
    @REM None..
) else (
    mkdir bin
)

if Exist "show.ico" (
    csc /out:bin\showAssembly.exe /target:exe /checked+ /win32icon:show.ico show.cs iconBytes.cs utils.cs handlers.cs
) else (
    echo Falied compilation
)

if %ERRORLEVEL% equ 1 (
    pause
)