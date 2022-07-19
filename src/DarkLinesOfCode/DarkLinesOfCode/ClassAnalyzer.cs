using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DarkLinesOfCode
{
    internal static class ClassAnalyzer
    {
        public static void Analyze(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ClassDeclarationSyntax classSyntax))
            {
                return;
            }

            var amountOfLines = classSyntax.GetText().Lines.Count;

            if (amountOfLines > Constants.MaxLinesPerClass)
            {
                var location = context.Node.GetLocation();
                Diagnostics.ReportClassTooLong(context, location, classSyntax.Identifier.ValueText, amountOfLines);
            }
        }
    }
}
