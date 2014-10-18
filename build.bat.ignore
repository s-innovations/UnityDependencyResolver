@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild YourSolution.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package
mkdir Build
cmd /c %nuget% pack "SInnovations.Katana.UnityDependencyResolver.WebApi\SInnovations.Katana.UnityDependencyResolver.csproj" -IncludeReferencedProjects -o Build -p Configuration=%config% %version%
cmd /c %nuget% pack "SInnovations.Katana.UnityDependencyResolver.WebApi\SInnovations.Katana.UnityDependencyResolver.WebApi.csproj" -IncludeReferencedProjects -o Build -p Configuration=%config% %version%