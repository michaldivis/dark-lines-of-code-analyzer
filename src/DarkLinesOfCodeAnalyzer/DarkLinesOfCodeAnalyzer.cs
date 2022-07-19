using Microsoft.CodeAnalysis;
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
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterSyntaxTreeAction(AnalyzeSyntaxTree);
            context.RegisterCodeBlockAction(AnalyzeCodeBlock);
        }

        private static void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context)
        {
            HandleAnalyze(() => FileAnalyzer.Analyze(context));
        }

        private static void AnalyzeCodeBlock(CodeBlockAnalysisContext context)
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
