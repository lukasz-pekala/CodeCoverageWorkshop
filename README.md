# CodeCoverageWorkshop
A project created to test different possibilities of code coverage generation engines and to present code coverage in various IDE (VS, VS Code, etc.)

[![Build](https://github.com/lukasz-pekala/CodeCoverageWorkshop/actions/workflows/dotnet.yml/badge.svg)](https://github.com/lukasz-pekala/CodeCoverageWorkshop/actions/workflows/dotnet.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=lukasz-pekala_CodeCoverageWorkshop&metric=alert_status)](https://sonarcloud.io/dashboard?id=lukasz-pekala_CodeCoverageWorkshop)

## dotnet test example

```
dotnet restore
dotnet build --no-restore
dotnet test --no-build --verbosity normal --logger trx /p:CollectCoverage=true /p:CoverletOutput=.\CoverageData\ /p:CoverletOutputFormat=opencover
```

## dotCover example

```
dotnet dotcover test --no-build --dcReportType=Html
```

## dotCover - How to configure
https://www.jetbrains.com/help/dotcover/Running_Coverage_Analysis_from_the_Command_LIne.html
