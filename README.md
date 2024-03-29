# DarkLinesOfCodeAnalyzer

A simple Roslyn analyzer that checks the amount of lines of code in your files and shows a warning if there are too many.

> **Rule of 30**\
> This analyzer makes use of the “Rule of 30” in [Refactoring in Large Software Projects](https://www.amazon.com/Refactoring-Large-Software-Projects-Restructurings/dp/0470858923) by Martin Lippert and Stephen Roock:
> 
> <ol type="a">
>   <li>Methods should not have more than an average of 30 code lines (not counting line spaces and comments).</li>
>   <li>A class should contain an average of less than 30 methods, resulting in up to 900 lines of code.</li>
>   <li>A package shouldn’t contain more than 30 classes, thus comprising up to 27,000 code lines.</li>
>   <li>Subsystems with more than 30 packages should be avoided. Such a subsystem would count up to 900 classes with up to 810,000 lines of code.</li>
>   <li>A system with 30 subsystems would thus possess 27,000 classes and 24.3 million code lines.</li>
> </ol>

## Nuget

[![nuget](https://img.shields.io/nuget/v/Divis.DarkLinesOfCodeAnalyzer?label=Divis.DarkLinesOfCodeAnalyzer&color=black&logo=NuGet&style=flat-square)](https://www.nuget.org/packages/Divis.DarkLinesOfCodeAnalyzer) [![nuget](https://img.shields.io/nuget/dt/Divis.DarkLinesOfCodeAnalyzer?color=black&label=downloads&logo=NuGet&style=flat-square)](https://www.nuget.org/packages/Divis.DarkLinesOfCodeAnalyzer)
```powershell
PM> Install-Package Divis.DarkLinesOfCodeAnalyzer
```

## Roadmap

Here's the planned feature roadmap:
| Feature | Status |
| --- | --- |
| max 900 lines per class | ✅ |
| max 30 lines per method | ✅ |
| ignore blank lines | 🔲 |

## Example
The resulting warning might look like this:
```log
> C:\Projects\demo-app\DemoConsoleApp\WeatherService.cs(5,5,1078,6): warning DL0100: The class 'WeatherService' contains 1076 lines of code, maximum recommended amount of lines per class is 900 lines
> C:\Projects\demo-app\DemoConsoleApp\WeatherService.cs(8,9,1077,10): warning DL0200: The method 'GetForecastForCity' contains 48 lines of code, maximum recommended amount of lines per method is 30 lines
```
