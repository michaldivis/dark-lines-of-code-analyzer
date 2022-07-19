using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class MethodAnalyzer
    {
        public static void Analyze(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is MethodDeclarationSyntax methodSyntax))
            {
                return;
            }

            var amountOfLines = methodSyntax.GetText().Lines.Count;

            if (amountOfLines > Constants.MaxLinesPerMethod)
            {
                var location = context.Node.GetLocation();
                Diagnostics.ReportMethodTooLong(context, location, methodSyntax.Identifier.ValueText, amountOfLines);
            }
        }
    }
}
