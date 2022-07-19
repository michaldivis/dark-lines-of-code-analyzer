using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace DarkLinesOfCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DarkLinesOfCodeAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => Diagnostics.SupportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze|GeneratedCodeAnalysisFlags.ReportDiagnostics);

            context.RegisterSyntaxNodeAction(AnalyzeClassDeclaration, SyntaxKind.ClassDeclaration);
            context.RegisterSyntaxNodeAction(AnalyzeMethodDeclaration, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeClassDeclaration(SyntaxNodeAnalysisContext context)
        {
            HandleAnalyze(() => ClassAnalyzer.Analyze(context));
        }

        private static void AnalyzeMethodDeclaration(SyntaxNodeAnalysisContext context)
        {
            HandleAnalyze(() => MethodAnalyzer.Analyze(context));
        }

        private static void HandleAnalyze(Action analyze)
        {
            try
            {
                analyze?.Invoke();
            }
            catch (Exception ex)
            {
                // Include stack trace info by ToString() the exception as part of the message.
                // Only the first line is included, so we have to remove newlines
                var exDetails = Regex.Replace(ex.ToString(), @"\r\n?|\n|\r", " ");
                throw new Exception($"Uncaught exception in analyzer: {exDetails}");
            }
        }
    }
}
