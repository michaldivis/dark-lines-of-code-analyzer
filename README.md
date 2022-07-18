# DarkLinesOfCodeAnalyzer

A simple Roslyn analyzer that checks the amount of lines of code in your files and shows a warning if there are too many.

## Roadmap

The analyzer is very basic at the moment, the planned feature roadmap:
- ✅ check files for maximum amount of lines
- 🔲 ignore blank lines
- 🔲 make the maximum amount of lines configurable
- 🔲 only check .cs files
- 🔲 check method bodies for maximum amount of lines as well as entire files

## Nuget

[![nuget](https://img.shields.io/nuget/v/Divis.DarkLinesOfCodeAnalyzer?label=Divis.DarkLinesOfCodeAnalyzer&color=black&logo=NuGet&style=flat-square)](https://www.nuget.org/packages/Divis.DarkLinesOfCodeAnalyzer) [![nuget](https://img.shields.io/nuget/dt/Divis.DarkLinesOfCodeAnalyzer?color=black&label=downloads&logo=NuGet&style=flat-square)](https://www.nuget.org/packages/Divis.DarkLinesOfCodeAnalyzer)
```powershell
PM> Install-Package Divis.DarkLinesOfCodeAnalyzer
```