using DarkLinesOfCodeAnalyzer.Properties;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class Diagnostics
    {
        public static ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(FileTooLong, MethodTooLong);

        private static readonly LocalizableString DL0100Title = LoadString(nameof(Resources.DL0100Title));
        private static readonly LocalizableString DL0100Message = LoadString(nameof(Resources.DL0100Message));
        private static readonly LocalizableString DL0100Description = LoadString(nameof(Resources.DL0100Description));
        private static readonly LocalizableString DL0200Title = LoadString(nameof(Resources.DL0200Title));
        private static readonly LocalizableString DL0200Message = LoadString(nameof(Resources.DL0200Message));
        private static readonly LocalizableString DL0200Description = LoadString(nameof(Resources.DL0200Description));

        private const string Category = "Design";

        private static readonly DiagnosticDescriptor FileTooLong =
            new DiagnosticDescriptor(
                DiagnosticIds.FileTooLong,
                DL0100Title,
                DL0100Message,
                Category,
                DiagnosticSeverity.Info,
                isEnabledByDefault: true,
                description: DL0100Description,
                helpLinkUri: Contants.ProjectUrl);

        private static readonly DiagnosticDescriptor MethodTooLong =
            new DiagnosticDescriptor(
                DiagnosticIds.MethodTooLong,
                DL0200Title,
                DL0200Message,
                Category,
                DiagnosticSeverity.Info,
                isEnabledByDefault: true,
                description: DL0200Description,
                helpLinkUri: Contants.ProjectUrl);

        public static void ReportFileTooLong(SyntaxTreeAnalysisContext context, int amountOfLines, int maxLinesPerFile)
        {
            var location = context.Tree.GetLocation(context.Tree.GetText().Lines.FirstOrDefault().Span);
            var diagnostic = Diagnostic.Create(FileTooLong, location, amountOfLines, maxLinesPerFile);
            context.ReportDiagnostic(diagnostic);
        }

        public static void ReportMethodTooLong(CodeBlockAnalysisContext context, IMethodSymbol method, int amountOfLines, int maxLinesPerMethod)
        {
            foreach (var location in method.Locations)
            {
                var diagnostic = Diagnostic.Create(MethodTooLong, location, method.Name, amountOfLines, maxLinesPerMethod);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static LocalizableResourceString LoadString(string name) =>
            new LocalizableResourceString(name, Resources.ResourceManager, typeof(Resources));
    }
}
