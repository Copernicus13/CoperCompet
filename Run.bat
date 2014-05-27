@ECHO Off

title GoogleCodeJam launcher

DEL /Q Data\Output\*.out 2> nul
RD /S /Q bin 2> nul

SET map=
REM Practice
SET map=%map%aa-AlienNumbers;ab-AlwaysTurnLeft;ac-EggDrop;ad-ShoppingPlan;ae-TriangleTrilemma;af-ThePriceIsWrong;
SET map=%map%ag-RandomRoute;ah-HexagonGame;ai-OldMagician;aj-SquareFields;ak-Cycles;
REM 2008
SET map=%map%ba-SavingUniverse;bb-TrainTimetable;bc-FlySwatter;bd-MinimumScalarProduct;be-Milkshakes;bf-Numbers;
REM 2009
SET map=%map%ca-AlienLanguage;
REM 2010 Africa
SET map=%map%da-ReverseWords;db-StoreCredit;dc-T9Spelling
REM 2014
SET map=%map%ha-MagicTrick;hb-CookieClickerAlpha;hc-MinesweeperMaster;hd-DeceitfulWar;he-TheRepeater;hf-NewLotteryGame

ECHO ÛßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßßÛ
ECHO Û                            þþþþþ ¸Coper þþþþþ                             Û
ECHO ÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛ

SET Choice=a
SET Current=he

SET MsBuildCmd=%WinDir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
SET MsBuildArgs=/nologo /v:q

:Start
ECHO ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ» ÚÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ¿
ECHO º Choose project(s) to run:     º ³ Global Options (as a prefix)            ³
ECHO ÌÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¹ ÃÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄ´
ECHO º a. *Current*                  º ³ @ Input from console, Output to console ³
ECHO º z. All                        º ³ * Output to console                     ³
ECHO º p. Make a pause               º ÀÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÄÙ
ECHO º q. Quit                       º
ECHO ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼

:Choice
SET /P Choice=[default=%Choice%]^>
:Choice2
SET idx=0
SET cpt=1
CALL :FuncBuild GoogleCodeJam\GoogleCodeJam.vcxproj
:ChoiceInnerLoop
CALL SET char=%%Choice:~%idx%,1%%
SET /A idx+=1
IF "%char%"=="" PAUSE & GOTO :EOF
IF "%char%"=="@" SET consoleInput=1
IF "%char%"=="*" SET consoleOutput=1
IF /I "%char%"=="a" GOTO :Current
IF /I "%char%"=="z" (
  FOR %%A IN (%map%) DO (
    FOR /F "tokens=1,2 delims=-" %%B IN ("%%A") DO CALL :FuncRun %%C
  )
)
IF /I "%char%"=="p" PAUSE
IF /I "%char%"=="q" GOTO :EOF
GOTO :ChoiceInnerLoop


:Current
CALL SET Current=%%map:*%Current%-=%%
SET Current=%Current:;=&rem.%
CALL :FuncRun %Current%
GOTO :EOF


:FuncBuild
ECHO Building %1
%MsBuildCmd% %MsBuildArgs% /t:rebuild %1 /p:Platform=Win32 /p:Configuration=Release /p:SolutionDir=%~dp0
GOTO :EOF


:FuncRun
ECHO Running %1
IF "%consoleInput%"=="1" (
  start bin\GoogleCodeJam.exe %1
) ELSE (
  IF "%consoleOutput%"=="1" (
    FOR %%A IN (data\Input\%1-*.in) DO TYPE %%A | bin\GoogleCodeJam.exe %1
  ) ELSE (
    FOR %%A IN (data\Input\%1-*.in) DO TYPE %%A | bin\GoogleCodeJam.exe %1 > data\Output\%%~nA.out
  )
)
GOTO :EOF
