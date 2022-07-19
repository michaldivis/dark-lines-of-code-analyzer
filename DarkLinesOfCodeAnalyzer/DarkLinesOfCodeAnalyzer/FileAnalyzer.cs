using Microsoft.CodeAnalysis.Diagnostics;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class FileAnalyzer
    {
        private const int _maxLinesPerFile = 100;

        public static void Analyze(SyntaxTreeAnalysisContext context)
        {
            var amountOfLines = context.Tree.GetText().Lines.Count;

            if (amountOfLines > _maxLinesPerFile)
            {
                Diagnostics.ReportFileTooLong(context, amountOfLines, _maxLinesPerFile);
            }
        }
    }
}
