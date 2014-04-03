@ECHO Off

title GoogleCodeJam launcher

DEL /Q Data\Output\*.out 2> nul
RD /S /Q bin 2> nul

ECHO �����������������������������������������������������������������������������
ECHO �                            ����� �Coper �����                             �
ECHO �����������������������������������������������������������������������������

SET Choice=h

SET MsBuildCmd=%WinDir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
SET MsBuildArgs=/nologo /v:q

:Start
ECHO �������������������������������ͻ �����������������������������������������Ŀ
ECHO � Choose project(s) to run:     � � Global Options (as a prefix)            �
ECHO �������������������������������͹ �����������������������������������������Ĵ
ECHO � a. StoreCredit                � � @ Input from console, Output to console �
ECHO � b. ReverseWords               � � * Output to console                     �
ECHO � c. T9Spelling                 � �������������������������������������������
ECHO � d. MinimumScalarProduct       �
ECHO � e. Milkshakes                 �
ECHO � f. Numbers                    �
ECHO � g. AlienLanguage              �
ECHO � h. OldMagician                �
ECHO � i. SquareFields               �
ECHO � j. SavingUniverse             �
ECHO � k. TrainTimetable             �
ECHO � z. All                        �
ECHO � p. Make a pause               �
ECHO � q. Quit                       �
ECHO �������������������������������ͼ

:Choice
SET /P Choice=[default=%Choice%]^>
:Choice2
SET idx=0
SET cpt=1
SET Choice=%Choice:z=ab%
CALL :FuncBuild GoogleCodeJam\GoogleCodeJam.vcxproj
:ChoiceInnerLoop
CALL SET char=%%Choice:~%idx%,1%%
SET /A idx+=1
IF "%char%"=="" PAUSE & GOTO :EOF
IF "%char%"=="@" SET consoleInput=1
IF "%char%"=="*" SET consoleOutput=1
IF /I "%char%"=="a" CALL :FuncRun StoreCredit
IF /I "%char%"=="b" CALL :FuncRun ReverseWords
IF /I "%char%"=="c" CALL :FuncRun T9Spelling
IF /I "%char%"=="d" CALL :FuncRun MinimumScalarProduct
IF /I "%char%"=="e" CALL :FuncRun Milkshakes
IF /I "%char%"=="f" CALL :FuncRun Numbers
IF /I "%char%"=="g" CALL :FuncRun AlienLanguage
IF /I "%char%"=="h" CALL :FuncRun OldMagician
IF /I "%char%"=="i" CALL :FuncRun SquareFields
IF /I "%char%"=="j" CALL :FuncRun SavingUniverse
IF /I "%char%"=="k" CALL :FuncRun TrainTimetable
IF /I "%char%"=="p" PAUSE
IF /I "%char%"=="q" GOTO :EOF
GOTO :ChoiceInnerLoop


:FuncBuild
ECHO Building %1
%MsBuildCmd% %MsBuildArgs% /t:rebuild %1 /p:Platform=Win32 /p:Configuration=Release /p:SolutionDir=%~dp0
GOTO :EOF


:FuncRun
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
