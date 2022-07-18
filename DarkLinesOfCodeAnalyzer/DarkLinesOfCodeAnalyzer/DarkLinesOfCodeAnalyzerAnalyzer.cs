using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace DarkLinesOfCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DarkLinesOfCodeAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        private const string _projectUrl = "https://github.com/michaldivis/dark-lines-of-code-analyzer";
        private const string _diagnosticId = "DarkLinesOfCodeAnalyzer";
        private const int _maxLinesOfCode = 100;

        private const string _title = "The file contains too many lines of code";
        private const string _messageFormat = "'{0}' lines of code found. Maximum recommended amount is {1} lines";
        private const string _description = "A file shouldn't contain too many lines of code";

        private const string _category = "Design";

        private static readonly DiagnosticDescriptor _rule = 
            new DiagnosticDescriptor(_diagnosticId, 
                _title, 
                _messageFormat, 
                _category, 
                DiagnosticSeverity.Info, 
                isEnabledByDefault: true, 
                description: _description, 
                helpLinkUri: _projectUrl);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterSyntaxTreeAction(AnalyzeSyntaxTree);
        }

        private static void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context)
        {
            var amountOfLines = context.Tree.GetText().Lines.Count;

            if (amountOfLines > _maxLinesOfCode)
            {
                var location = context.Tree.GetLocation(context.Tree.GetText().Lines.FirstOrDefault().Span);
                var diagnostic = Diagnostic.Create(_rule, location, amountOfLines, _maxLinesOfCode);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
