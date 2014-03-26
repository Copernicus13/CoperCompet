@ECHO Off

title GoogleCodeJam launcher

DEL /Q Data\Output\*.out 2> nul
RD /S /Q bin 2> nul

ECHO ÛßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßÛ
ECHO Û                            þþþþþ ¸Coper þþþþþ                             Û
ECHO ÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛ

SET Choice=h

SET MsBuildCmd=%WinDir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
SET MsBuildArgs=/nologo /v:q

:Start
ECHO ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ» ÚÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿
ECHO º Choose project(s) to run:     º ³ Global Options (as a prefix)            ³
ECHO ÌÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¹ ÃÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´
ECHO º a. StoreCredit                º ³ @ Input from console, Output to console ³
ECHO º b. ReverseWords               º ³ * Output to console                     ³
ECHO º c. T9Spelling                 º ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ
ECHO º d. MinimumScalarProduct       º
ECHO º e. Milkshakes                 º
ECHO º f. Numbers                    º
ECHO º g. AlienLanguage              º
ECHO º h. OldMagician                º
ECHO º z. All                        º
ECHO º p. Make a pause               º
ECHO º q. Quit                       º
ECHO ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼

:Choice
SET /P Choice=[default=%Choice%]^>
:Choice2
SET idx=0
SET cpt=1
SET Choice=%Choice:z=ab%
CALL :FuncBuild 2008\2008.vcxproj
:ChoiceInnerLoop
CALL SET char=%%Choice:~%idx%,1%%
SET /A idx+=1
IF "%char%"=="" PAUSE & GOTO :EOF
IF "%char%"=="@" SET consoleInput=1
IF "%char%"=="*" SET consoleOutput=1
IF /I "%char%"=="a" CALL :FuncRun 2010 StoreCredit
IF /I "%char%"=="b" CALL :FuncRun 2010 ReverseWords
IF /I "%char%"=="c" CALL :FuncRun 2010 T9Spelling
IF /I "%char%"=="d" CALL :FuncRun 2008 MinimumScalarProduct
IF /I "%char%"=="e" CALL :FuncRun 2008 Milkshakes
IF /I "%char%"=="f" CALL :FuncRun 2008 Numbers
IF /I "%char%"=="g" CALL :FuncRun 2008 AlienLanguage
IF /I "%char%"=="h" CALL :FuncRun 2008 OldMagician
IF /I "%char%"=="p" PAUSE
IF /I "%char%"=="q" GOTO :EOF
GOTO :ChoiceInnerLoop


:FuncBuild
ECHO Building %1
%MsBuildCmd% %MsBuildArgs% /t:rebuild %1 /p:Platform=Win32 /p:Configuration=Release /p:SolutionDir=%~dp0
GOTO :EOF


:FuncRun
IF "%consoleInput%"=="1" (
  start bin\%~n1.exe %2
) ELSE (
  IF "%consoleOutput%"=="1" (
    FOR %%A IN (data\Input\%2-*.in) DO TYPE %%A | bin\%~n1.exe %2
  ) ELSE (
    FOR %%A IN (data\Input\%2-*.in) DO TYPE %%A | bin\%~n1.exe %2 > data\Output\%%~nA.out
  )
)
GOTO :EOF
