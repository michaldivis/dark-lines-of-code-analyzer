using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace DarkLinesOfCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DarkLinesOfCodeAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "DarkLinesOfCodeAnalyzer";
        public const int MaxLinesOfCode = 100;

        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Design";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Info, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterSyntaxTreeAction(AnalyzeSyntaxTree);
        }

        private static void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context)
        {
            var amountOfLines = context.Tree.GetText().Lines.Count;

            if (amountOfLines > MaxLinesOfCode)
            {
                var location = context.Tree.GetLocation(context.Tree.GetText().Lines.FirstOrDefault().Span);
                var diagnostic = Diagnostic.Create(Rule, location, amountOfLines, MaxLinesOfCode);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
