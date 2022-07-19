using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class ClassAnalyzer
    {
        private const int _maxLinesPerClass = 900;

        public static void Analyze(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ClassDeclarationSyntax classSyntax))
            {
                return;
            }

            var amountOfLines = classSyntax.GetText().Lines.Count;

            if (amountOfLines > _maxLinesPerClass)
            {
                var location = context.Node.GetLocation();
                Diagnostics.ReportClassTooLong(context, location, classSyntax.Identifier.ValueText, amountOfLines, _maxLinesPerClass);
            }
        }
    }
}
