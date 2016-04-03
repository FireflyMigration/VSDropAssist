@echo off
REM Change Current Directory to the location of this batch file
CD /D %~dp0
REM check the file whether signed...
signtool verify /pa /v %1 2>nul 1>nul
IF %errorlevel% EQU 0 (
echo %1 already singed, will be skipped.
GOTO succeeded
)
REM sign the file...
signtool.exe sign /f kieron.pfx /p smash19 /d %1
if %errorlevel% neq 0 exit /b %errorlevel%
set timestamp_server=http://timestamp.verisign.com/scripts/timstamp.dll
for /L %%a in (1,1,10) do (
    REM try to timestamp the file...
    signtool.exe timestamp /t %timestamp_server% %1 2>nul 1>nul
    if errorlevel 0 if not errorlevel 1 (
echo Successfully timestamped: %1
GOTO succeeded
)
echo Timestamping failed for %1
    REM wait 2 seconds...
    ping -n 2 127.0.0.1 > nul
)
REM return an error code...
echo signfile.bat exit code is 1.
exit /b 1
:succeeded
REM return a successful code...
echo signfile.bat exit code is 0.
exit /b 0