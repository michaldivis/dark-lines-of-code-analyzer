using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace DarkLinesOfCodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DarkLinesOfCodePerMethodAnalyzer : DiagnosticAnalyzer
    {
        private const int _maxLinesPerMethod = 10;

        private const string _title = "The method contains too many lines of code";
        private const string _messageFormat = @"The method '{0}' contains {1} lines of code, maximum recommended amount of lines per method is {2} lines";
        private const string _description = "A method shouldn't contain too many lines of code";

        private const string _category = "Design";

        private static readonly DiagnosticDescriptor _rule =
            new DiagnosticDescriptor(
                Contants.DiagnosticId,
                _title,
                _messageFormat,
                _category,
                DiagnosticSeverity.Info,
                isEnabledByDefault: true,
                description: _description,
                helpLinkUri: Contants.ProjectUrl);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterCodeBlockAction(AnalyzeCodeBlock);
        }

        private static void AnalyzeCodeBlock(CodeBlockAnalysisContext context)
        {
            if (context.OwningSymbol.Kind != SymbolKind.Method)
            {
                return;
            }

            var method = (IMethodSymbol)context.OwningSymbol;
            var block = (BlockSyntax)context.CodeBlock.ChildNodes().FirstOrDefault(n => n.Kind() == SyntaxKind.Block);

            if (block is null)
            {
                return;
            }

            if (block.Statements.Count == 0)
            {
                return;
            }

            var amountOfLines = block.SyntaxTree.GetText().Lines.Count;

            if (amountOfLines > _maxLinesPerMethod)
            {
                foreach (var location in method.Locations)
                {
                    var diagnostic = Diagnostic.Create(_rule, location, method.Name, amountOfLines, _maxLinesPerMethod);
                    context.ReportDiagnostic(diagnostic);
                }                
            }
        }
    }
}
