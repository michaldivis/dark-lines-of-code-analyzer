using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DarkLinesOfCode
{
    internal static class ConstructorAnalyzer
    {
        public static void Analyze(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is ConstructorDeclarationSyntax ctorSyntax))
            {
                return;
            }

            var amountOfLines = ctorSyntax.GetText().Lines.Count;

            if (amountOfLines > Constants.MaxLinesPerMethod)
            {
                var location = context.Node.GetLocation();
                Diagnostics.ReportMethodTooLong(context, location, $"{ctorSyntax.Identifier.ValueText} ctor", amountOfLines);
            }
        }
    }
}
