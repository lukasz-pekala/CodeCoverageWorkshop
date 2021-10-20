# CodeCoverageWorkshop
A project created to test different possibilities of code coverage generation engines and to present code coverage in various IDE (VS, VS Code, etc.)

[![Build](https://github.com/lukasz-pekala/CodeCoverageWorkshop/actions/workflows/dotnet.yml/badge.svg)](https://github.com/lukasz-pekala/CodeCoverageWorkshop/actions/workflows/dotnet.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=lukasz-pekala_CodeCoverageWorkshop&metric=alert_status)](https://sonarcloud.io/dashboard?id=lukasz-pekala_CodeCoverageWorkshop)


## Essential part of SonarCloud (SonarQube) configuration
```powershell
.\.sonar\scanner\dotnet-sonarscanner begin `
  /k:"lukasz-pekala_CodeCoverageWorkshop" `
  /o:"lukasz-pekala" `
  /d:sonar.login="${{ secrets.SONAR_TOKEN }}" `
  /d:sonar.host.url="https://sonarcloud.io" `
  /d:sonar.cs.nunit.reportsPaths="**/TestResults/*/*.trx" `
  /d:sonar.cs.opencover.reportsPaths="CodeCoverageWorkshop.Logic.xUnit.Test/CoverageData/coverage.opencover.xml,CodeCoverageWorkshop.Logic.NUnit.Test/CoverageData/coverage.opencover.xml" `   /d:sonar.coverage.exclusions="**/*.conf.js,**/*.spec.ts,**/*.html,**/wwwroot/**/*,**/obj/**,**/bin/**,**/.git/**,**/package.json,**/angular.json,**/appsettings*json,**/node_modules/**,**/Upgrades/Migrations/**"
  
dotnet restore
dotnet build --no-restore
dotnet test --no-build --verbosity normal --logger trx /p:CollectCoverage=true /p:CoverletOutput=.\CoverageData\ /p:CoverletOutputFormat=opencover

.\.sonar\scanner\dotnet-sonarscanner end /d:sonar.login="${{ secrets.SONAR_TOKEN }}" 
```

# dotnet test and coverlet

## dotnet test example

```powershell
dotnet restore
dotnet build --no-restore
dotnet test --no-build --verbosity normal --logger trx /p:CollectCoverage=true /p:CoverletOutput=.\CoverageData\ /p:CoverletOutputFormat=opencover
```

## coverlet examples
```powershell
dotnet test /p:CollectCoverage=true
```
```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutput=.\CoverageData\ /p:CoverletOutputFormat=opencover
```
```powershell
dotnet test /p:CollectCoverage=true /p:Threshold=\"80,100,70\" /p:ThresholdType=\"line,branch,method\"
```

## coverlet - więcej informacji
https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/MSBuildIntegration.md


# ReportGenerator - instalacja

Dla .NET Core/.NET 5 zainstalujmy ReportGenerator globalnie. 

```powershell
dotnet tool install -g dotnet-reportgenerator-globaltool
```

lub lokalnie:

```powershell
dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools

dotnet new tool-manifest
dotnet tool install dotnet-reportgenerator-globaltool
```

tworząc plik .config\dotnet-tools.json

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "dotnet-reportgenerator-globaltool": {
      "version": "4.8.12",
      "commands": [
        "reportgenerator"
      ]
    }
  }
}
```

## ReportGenerator - wygenerowanie raportu
Niestety ReportGenerator nie potrafi przetworzyć danych wygenerowanych przez Coverlet w domyślnym formacie (pliki coverage.json)
Zmieńmy więc sposób generowania danych o Coverleta tak by otrzymać wyniki w formacie OpenCover

```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutput=.\CoverageData\ /p:CoverletOutputFormat=opencover
```

Wygenerujmy raport w oparciu o dostępne dane

```powershell
reportgenerator -reports:".\CodeCoverageWorkshop.Logic.xUnit.Test\CoverageData\coverage.opencover.xml;.\CodeCoverageWorkshop.Logic.NUnit.Test\CoverageData\coverage.opencover.xml" -targetdir:.\CoverageReports -reporttypes:"Html;HtmlSummary;MarkdownSummary;TeamCitySummary"
```

# Code Coverage Exclusions
[assembly: ExcludeFromCodeCoverage]

.NET 5:
```C#
[AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
```
https://docs.microsoft.com/pl-pl/dotnet/api/system.diagnostics.codeanalysis.excludefromcodecoverageattribute?view=net-5.0

.NET 4.X
```C#
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
```
https://docs.microsoft.com/pl-pl/dotnet/api/system.diagnostics.codeanalysis.excludefromcodecoverageattribute?view=netframework-4.8

# dotCover
## dotCover - How to configure
https://www.jetbrains.com/help/dotcover/Running_Coverage_Analysis_from_the_Command_LIne.html

## dotCover example
```powershell
dotnet tool install JetBrains.dotCover.GlobalTool -g
```

```powershell
dotnet dotcover test --no-build --dcReportType=Html
```
