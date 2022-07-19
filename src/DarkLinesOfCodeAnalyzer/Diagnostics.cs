using DarkLinesOfCodeAnalyzer.Properties;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace DarkLinesOfCodeAnalyzer
{
    internal static class Diagnostics
    {
        public static ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(ClassTooLong, MethodTooLong);

        private static readonly LocalizableString DL0100Title = LoadString(nameof(Resources.DL0100Title));
        private static readonly LocalizableString DL0100Message = LoadString(nameof(Resources.DL0100Message));
        private static readonly LocalizableString DL0100Description = LoadString(nameof(Resources.DL0100Description));
        private static readonly LocalizableString DL0200Title = LoadString(nameof(Resources.DL0200Title));
        private static readonly LocalizableString DL0200Message = LoadString(nameof(Resources.DL0200Message));
        private static readonly LocalizableString DL0200Description = LoadString(nameof(Resources.DL0200Description));

        private const string Category = "Design";

        private static readonly DiagnosticDescriptor ClassTooLong =
            new DiagnosticDescriptor(
                DiagnosticIds.ClassTooLong,
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

        public static void ReportClassTooLong(SyntaxNodeAnalysisContext context, Location location, string className, int amountOfLines, int maxLinesPerClass)
        {
            var diagnostic = Diagnostic.Create(ClassTooLong, location, className, amountOfLines, maxLinesPerClass);
            context.ReportDiagnostic(diagnostic);
        }

        public static void ReportMethodTooLong(SyntaxNodeAnalysisContext context, Location location, string methodName, int amountOfLines, int maxLinesPerMethod)
        {
            var diagnostic = Diagnostic.Create(MethodTooLong, location, methodName, amountOfLines, maxLinesPerMethod);
            context.ReportDiagnostic(diagnostic);
        }

        private static LocalizableResourceString LoadString(string name)
        {
            return new LocalizableResourceString(name, Resources.ResourceManager, typeof(Resources));
        }
    }
}
