using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Linq;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class MethodAnalyzer
    {
        private const int _maxLinesPerMethod = 10;

        public static void Analyze(CodeBlockAnalysisContext context)
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
                Diagnostics.ReportMethodTooLong(context, method, amountOfLines, _maxLinesPerMethod);
            }
        }
    }
}
